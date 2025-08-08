using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

using Dalamud.Bindings.ImGui;
using Dalamud.Interface.Windowing;
using Dalamud.Plugin;
using Dalamud.Plugin.Services;
using Dalamud.Utility;

using FFXIVClientStructs.FFXIV.Client.Game.UI;

using HuntBuddy.Attributes;
using HuntBuddy.Ipc;
using HuntBuddy.Windows;

using Lumina.Excel;
using Lumina.Excel.Sheets;

using Map = Lumina.Excel.Sheets.Map;

namespace HuntBuddy;

public class Plugin: IDalamudPlugin {
	public string Name => "Hunt Buddy";

	private readonly PluginCommandManager<Plugin> commandManager;

	private int lastState;

	// Dictionary<string ExpansionName, Dictionary<KeyValuePair<uint MobTerritoryType, string MobTerritoryName>, List<MobHuntEntry MobsInZone>>>
	public readonly Dictionary<string, Dictionary<KeyValuePair<uint, string>, List<MobHuntEntry>>> MobHuntEntries;
	public readonly ConcurrentBag<MobHuntEntry> CurrentAreaMobHuntEntries;
	public bool MobHuntEntriesReady = true;
	public readonly Configuration Configuration;
	public static TeleportConsumer? TeleportConsumer { get; private set; }
	public static EspConsumer? EspConsumer { get; private set; }

	private WindowSystem WindowSystem {
		get;
	}

	internal MainWindow MainWindow {
		get;
	}

	private ConfigurationWindow ConfigurationWindow {
		get;
	}

	public static Plugin Instance {
		get;
		internal set;
	} = null!;

	public Plugin(IDalamudPluginInterface pluginInterface) {
		Instance = this;

		pluginInterface.Create<Service>();

		this.commandManager = new PluginCommandManager<Plugin>(this, Service.Commands);
		this.MobHuntEntries = [];
		this.CurrentAreaMobHuntEntries = [];
		this.Configuration = (Configuration)(Service.PluginInterface.GetPluginConfig() ?? new Configuration());
		this.Configuration.IconBackgroundColourU32 =
			ImGui.ColorConvertFloat4ToU32(this.Configuration.IconBackgroundColour);

		this.MainWindow = new MainWindow();
		this.ConfigurationWindow = new ConfigurationWindow();

		this.WindowSystem = new WindowSystem("HuntBuddy");
		this.WindowSystem.AddWindow(this.MainWindow);
		this.WindowSystem.AddWindow(new LocalHuntsWindow());
		this.WindowSystem.AddWindow(this.ConfigurationWindow);

		Plugin.TeleportConsumer = new TeleportConsumer();
		Plugin.EspConsumer = new EspConsumer();
		Service.ClientState.TerritoryChanged += this.ClientStateOnTerritoryChanged;
		Service.PluginInterface.UiBuilder.Draw += this.WindowSystem.Draw;
		Service.PluginInterface.UiBuilder.OpenConfigUi += this.OpenConfigUi;
		Service.PluginInterface.UiBuilder.OpenMainUi += this.OpenMainUi;
		Service.Framework.Update += this.FrameworkOnUpdate;
	}

	private unsafe void FrameworkOnUpdate(IFramework framework) {
		if (this.lastState == MobHunt.Instance()->ObtainedFlags) {
			return;
		}

		this.lastState = MobHunt.Instance()->ObtainedFlags;
		this.PluginCommand(string.Empty, "reload");
	}

	private void ClientStateOnTerritoryChanged(ushort e) {
		this.CurrentAreaMobHuntEntries.Clear();

		foreach (MobHuntEntry mobHuntEntry in this.MobHuntEntries.SelectMany(
					 expansionEntry => expansionEntry.Value
						 .Where(entry => entry.Key.Key == Service.ClientState.TerritoryType)
						 .SelectMany(entry => entry.Value))) {
			this.CurrentAreaMobHuntEntries.Add(mobHuntEntry);
		}
	}

	private void DrawInterface() => this.MainWindow.Toggle();

	public void OpenConfigUi() => this.ConfigurationWindow.Toggle();
	public void OpenMainUi() => this.MainWindow.Toggle();

	private void Dispose(bool disposing) {
		if (!disposing) {
			return;
		}

		this.MobHuntEntriesReady = false;
		Service.ClientState.TerritoryChanged -= this.ClientStateOnTerritoryChanged;
		Service.Framework.Update -= this.FrameworkOnUpdate;
		Service.PluginInterface.UiBuilder.Draw -= this.WindowSystem.Draw;
		Service.PluginInterface.UiBuilder.OpenConfigUi -= this.OpenConfigUi;
		Service.PluginInterface.UiBuilder.OpenMainUi -= this.OpenMainUi;

		this.WindowSystem.RemoveAllWindows();

		this.commandManager.Dispose();
	}

	[Command("/phb")]
	[HelpMessage(
		"Toggles UI\nArguments:\nreload - Reloads data\nlocal - Toggles the local hunt marks window\nnext - Flags the next hunt target to find\nlist - list all hunt targets by expansion")]
	public unsafe void PluginCommand(string command, string args) {
		try {
			switch (args.Trim().ToLower()) {
				case "reload":
					this.MobHuntEntriesReady = false;
					Task.Run(this.ReloadData);
					break;
				case "local":
					this.Configuration.ShowLocalHunts = !this.Configuration.ShowLocalHunts;
					this.Configuration.Save();
					break;
				case "next":
					if (this.MobHuntEntries.Count > 0) {
						bool filterPredicate(MobHuntEntry entry) => entry.IsEliteMark ||
						                                            MobHunt.Instance()->GetKillCount(entry.BillNumber,
							                                            entry.MobIndex) < entry.NeededKills;
						Location.OpenType openType = Location.OpenType.None;
						Vector3 playerLocation = Service.ClientState.LocalPlayer!.Position;
						Map map = Service.DataManager.GetExcelSheet<TerritoryType>()!.GetRow(Service.ClientState
							.TerritoryType)!.Map!.Value!;
						Vector2 playerVec2 = MapUtil.WorldToMap(new Vector2(playerLocation.X, playerLocation.Z), map);
						MobHuntEntry? chosen = this.CurrentAreaMobHuntEntries
							.Where(filterPredicate)
							.OrderBy(entry =>
								entry.IsEliteMark
									? float.MaxValue
									: Vector2.Distance(Location.Database[entry.MobHuntId].Coordinate, playerVec2))
							.FirstOrDefault();
						if (chosen == null) {
							Service.PluginLog.Information("No marks in current zone, looking in current expansion");
							openType = this.Configuration.IncludeAreaOnMap
								? Location.OpenType.ShowOpen
								: Location.OpenType.MarkerOpen;
							string expansion = Service.DataManager.GetExcelSheet<TerritoryType>()
								.GetRow(Service.ClientState.TerritoryType).ExVersion.Value.Name.ToString();
							Service.PluginLog.Information(
								$"Player is in a zone from {expansion}; known expansions are {string.Join(", ", this.MobHuntEntries.Keys)}");
							List<MobHuntEntry> candidates =
								this.MobHuntEntries.TryGetValue(expansion,
									out Dictionary<KeyValuePair<uint, string>, List<MobHuntEntry>>? entry)
									? entry.Values.SelectMany(l => l).Where(filterPredicate).ToList()
									: [];
							// if we didn't find any candidates, we try a different method to fill it
							if (candidates.Count == 0) {
								Service.PluginLog.Information(
									"Nothing available in current expansion, looking globally");
								candidates =
									this.MobHuntEntries.Values
										.SelectMany(dict => dict.Values)
										.SelectMany(l => l)
										.Where(filterPredicate)
										.ToList();
							}

							// regardless of HOW we got our candidates, assuming we did in fact get them, we pick one
							// note that this can't be merged into the above block because the above MAY run, and if so MUST run first,
							// but this block must ALWAYS run, regardless
							if (candidates.Count >= 1) {
								Service.PluginLog.Information($"Found {candidates.Count}");
								chosen = candidates[new Random().Next(candidates.Count)];
							}
						}

						if (chosen != null) {
							if (chosen.IsEliteMark) {
								Service.Chat.Print($"Hunting elite mark {chosen.Name} in {chosen.TerritoryName}");
								if (!this.Configuration.SuppressEliteMarkLocationWarning) {
									Service.Chat.Print("Elite mark spawn locations are not available, since there are so many possibilities and the mob will only ever be in one place at a time."
										+ "\n(You can suppress this warning in the plugin settings)");
								}
							}
							else {
								long remaining = chosen.NeededKills - MobHunt.Instance()->GetKillCount(chosen.BillNumber, chosen.MobIndex);
								Service.Chat.Print($"Hunting {remaining}x {chosen.Name} in {chosen.TerritoryName}");
								Location.CreateMapMarker(
									chosen.TerritoryType,
									chosen.MapId,
									chosen.MobHuntId,
									chosen.Name,
									openType);
							}
							if (this.Configuration.EnableXivEspIntegration && this.Configuration.AutoSetEspSearchOnNextHuntCommand && Plugin.EspConsumer?.IsAvailable == true)
								Plugin.EspConsumer.SearchFor(chosen.Name!);
						}
						else {
							Service.PluginLog.Information("Unable to find a hunt mark to target");
							Service.Chat.Print(
								"Couldn't find any hunt marks. Either you have no bills, or this is a bug.");
						}
					}

					break;
				case "ls":
				case "list":
					if (this.MobHuntEntries.Count < 1) {
						Service.Chat.Print(
							"No hunt marks found. If this doesn't sound right, please use `/phb reload` and try again.");
						break;
					}

					foreach (string expac in this.MobHuntEntries.Keys) {
						Service.Chat.Print(
							$"{expac}: {string.Join(", ", this.MobHuntEntries[expac].Values.SelectMany(e => e).OrderBy(s => s.Name).Select(m => m.Name))}");
					}

					break;
				default:
					this.DrawInterface();
					break;
			}
		}
		catch (Exception e) {
			Service.PluginLog.Error($"Error in command handler: {e}");
		}
	}

	public unsafe void ReloadData() {
		this.MobHuntEntries.Clear();
		List<MobHuntEntry> mobHuntList = [];
		SubrowExcelSheet<MobHuntOrder> mobHuntOrderSheet = Service.DataManager.GetSubrowExcelSheet<MobHuntOrder>();

		foreach (BillEnum billNumber in Enum.GetValues<BillEnum>()) {
			if ((MobHunt.Instance()->ObtainedFlags & (1 << (int)billNumber)) == 0) {
				continue;
			}

			MobHuntOrderType mobHuntOrderTypeRow =
				Service.DataManager.Excel.GetSheet<MobHuntOrderType>()!.GetRow((uint)billNumber)!;

			uint rowId = mobHuntOrderTypeRow.OrderStart.Value!.RowId +
						 (uint)(MobHunt.Instance()->ObtainedMarkId[(int)mobHuntOrderTypeRow.RowId] - 1);

			IEnumerable<MobHuntOrder> mobHuntOrderRows = mobHuntOrderSheet[rowId];

			foreach (MobHuntOrder mobHuntOrderRow in mobHuntOrderRows) {
				MobHuntEntry? mobHuntEntry =
					mobHuntList.FirstOrDefault(x => x.MobHuntId == mobHuntOrderRow.Target.Value.Name.RowId);

				if (mobHuntEntry == null) {
					mobHuntList.Add(
						new MobHuntEntry {
							Name = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(
								mobHuntOrderRow.Target.Value.Name.Value.Singular.ToString()),
							TerritoryName =
								mobHuntOrderRow.Target.Value.TerritoryType.Value.PlaceName.Value.Name.ToString(),
							ExpansionName = mobHuntOrderRow.Target.Value.TerritoryType.Value.TerritoryType.Value
								.ExVersion.Value.Name.ToString(),
							ExpansionId = mobHuntOrderRow.Target.Value.TerritoryType.Value.TerritoryType.Value
								.ExVersion.RowId,
							MapId = mobHuntOrderRow.Target.Value.TerritoryType.RowId,
							TerritoryType = mobHuntOrderRow.Target.Value.TerritoryType.Value.TerritoryType.RowId,
							MobHuntId = mobHuntOrderRow.Target.Value.Name.RowId,
							IsEliteMark = mobHuntOrderTypeRow.Type == 2,
							BillNumber = (byte)billNumber,
							MobIndex = (byte)mobHuntOrderRow.SubrowId,
							NeededKills = mobHuntOrderRow.NeededKills,
							Icon = mobHuntOrderRow.Target.Value.Icon,
						});
				}
				else {
					if (mobHuntEntry.NeededKills < mobHuntOrderRow.NeededKills) {
						mobHuntEntry.NeededKills = mobHuntOrderRow.NeededKills;
					}
				}
			}
		}

		foreach (MobHuntEntry entry in mobHuntList) {
			string key = entry.ExpansionName ?? "Unknown";
			KeyValuePair<uint, string> subKey =
				new(entry.TerritoryType, entry.TerritoryName ?? "Unknown");

			if (!this.MobHuntEntries.ContainsKey(key)) {
				this.MobHuntEntries[key] = [];
			}

			if (!this.MobHuntEntries[key].ContainsKey(subKey)) {
				this.MobHuntEntries[key][subKey] = [];
			}

			this.MobHuntEntries[key][subKey].Add(entry);
		}

		this.ClientStateOnTerritoryChanged(0);

		this.MobHuntEntriesReady = true;
	}

	public void Dispose() {
		this.Dispose(true);
		GC.SuppressFinalize(this);
	}
}
