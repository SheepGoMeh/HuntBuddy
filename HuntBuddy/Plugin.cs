﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

using Dalamud.Interface.Windowing;
using Dalamud.Plugin;
using Dalamud.Plugin.Services;
using Dalamud.Utility;

using FFXIVClientStructs.FFXIV.Client.Game.UI;

using HuntBuddy.Attributes;
using HuntBuddy.Ipc;
using HuntBuddy.Structs;
using HuntBuddy.Windows;

using ImGuiNET;

using Lumina.Excel;
using Lumina.Excel.GeneratedSheets;
using Lumina.Text;

namespace HuntBuddy;

public class Plugin: IDalamudPlugin {
	public string Name => "Hunt Buddy";

	private readonly PluginCommandManager<Plugin> commandManager;

	private ObtainedBillEnum lastState;

	private readonly Dictionary<uint, Dictionary<uint, List<MobHuntEntry>>> pathMap = new();

	// Dictionary<string ExpansionName, Dictionary<KeyValuePair<uint MobTerritoryType, string MobTerritoryName>, List<MobHuntEntry MobsInZone>>>
	public readonly Dictionary<string, Dictionary<KeyValuePair<uint, string>, List<MobHuntEntry>>> MobHuntEntries;
	public readonly ConcurrentBag<MobHuntEntry> CurrentAreaMobHuntEntries;
	public bool MobHuntEntriesReady = true;
	public readonly unsafe MobHuntStruct* MobHuntStruct;
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

		unsafe {
			this.MobHuntStruct =
				(MobHuntStruct*)Service.SigScanner.GetStaticAddressFromSig(
					"48 8D 0D ?? ?? ?? ?? 8B D8 0F B6 52");
		}

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
		if (this.lastState == this.MobHuntStruct->ObtainedBillEnumFlags) {
			return;
		}

		this.lastState = this.MobHuntStruct->ObtainedBillEnumFlags;
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
					this.NextHunt();
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

	private unsafe void NextHunt() {
		if (this.MobHuntEntries.Count <= 0) return;

		Location.OpenType openType = Location.OpenType.None;
		Vector3 playerLocation = Service.ClientState.LocalPlayer!.Position;
		Vector2 playerVec2 = MapUtil.WorldToMap(new Vector2(playerLocation.X, playerLocation.Z), Service.DataManager.GetExcelSheet<TerritoryType>()!.GetRow(Service.ClientState.TerritoryType)!.Map!.Value!);
		MobHuntEntry? chosen = this.CurrentAreaMobHuntEntries
			.Where(FilterPredicate).MinBy(entry =>
				entry.IsEliteMark
					? float.MaxValue
					: float.Min(Vector2.Distance(Location.Database[entry.MobHuntId].Coordinate, playerVec2), Location.Database[entry.MobHuntId].DistanceToAetheryte));
		if (chosen == null) {
			Service.PluginLog.Information("No marks in current zone, looking in current expansion");
			openType = this.Configuration.IncludeAreaOnMap
				? Location.OpenType.ShowOpen
				: Location.OpenType.MarkerOpen;
			ExVersion expansion =
				Service.DataManager.Excel.GetSheet<TerritoryType>()!.GetRow(Service.ClientState
					.TerritoryType)!.ExVersion.Value!;
			Service.PluginLog.Information(
				$"Player is in a zone from {expansion.Name}; known expansions are {string.Join(", ", this.MobHuntEntries.Keys)}");
			
			Telepo* tp = Telepo.Instance();
			if (tp == null || tp->UpdateAetheryteList() == null) {
				return;
			}

			Dictionary<uint, uint> prices = [];
			int unlockedAetherytes = tp->TeleportList.Count;
			for (int i = 0; i < unlockedAetherytes; ++i) {
				TeleportInfo info = tp->TeleportList[i];
				prices[info.AetheryteId] = info.GilCost;
			}

			List<MobHuntEntry> candidates = this.pathMap.TryGetValue(expansion.RowId, out Dictionary<uint, List<MobHuntEntry>>? entry)
				? entry
					.Values
					.SelectMany(l => l)
					.Where(FilterPredicate)
					.ToList()
				: [];
			// if we didn't find any candidates, we try a different method to fill it
			if (candidates.Count == 0) {
				Service.PluginLog.Information(
					"Nothing available in current expansion, looking globally");
				candidates =
					this.MobHuntEntries.Values
						.SelectMany(dict => dict.Values)
						.SelectMany(l => l)
						.Where(FilterPredicate)
						.ToList();
			}

			// regardless of HOW we got our candidates, assuming we did in fact get them, we pick one
			// note that this can't be merged into the above block because the above MAY run, and if so MUST run first,
			// but this block must ALWAYS run, regardless
			if (candidates.Count >= 1) {
				Service.PluginLog.Information($"Found {candidates.Count}");
				chosen = candidates
					.OrderBy(x => prices[Location.Database[x.MobHuntId].NearestAetheryteId])
					.ThenBy(x => Location.Database[x.MobHuntId].DistanceToAetheryte)
					.First();
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
				long remaining = chosen.NeededKills -
				                 this.MobHuntStruct->CurrentKills[chosen.CurrentKillsOffset];
				Service.Chat.Print($"Hunting {remaining}x {chosen.Name} in {chosen.TerritoryName}");
				Location.CreateMapMarker(
					chosen.TerritoryType,
					chosen.MapId,
					chosen.MobHuntId,
					chosen.Name,
					openType);
			}
			if (this.Configuration is { EnableXivEspIntegration: true, AutoSetEspSearchOnNextHuntCommand: true } && Plugin.EspConsumer?.IsAvailable == true)
				Plugin.EspConsumer.SearchFor(chosen.Name!);
		}
		else {
			Service.PluginLog.Information("Unable to find a hunt mark to target");
			Service.Chat.Print(
				"Couldn't find any hunt marks. Either you have no bills, or this is a bug.");
		}

		return;

		bool FilterPredicate(MobHuntEntry entry) => entry.IsEliteMark ||
		                                            this.MobHuntStruct->CurrentKills[entry.CurrentKillsOffset] <
		                                            entry.NeededKills;
	}

	public unsafe void ReloadData() {
		this.MobHuntEntries.Clear();
		List<MobHuntEntry> mobHuntList = [];
		ExcelSheet<MobHuntOrder>? mobHuntOrderSheet = Service.DataManager.Excel.GetSheet<MobHuntOrder>()!;

		foreach (BillEnum billNumber in Enum.GetValues<BillEnum>()) {
			if (!this.MobHuntStruct->ObtainedBillEnumFlags.HasFlag((ObtainedBillEnum)(1 << (int)billNumber))) {
				continue;
			}

			MobHuntOrderType mobHuntOrderTypeRow =
				Service.DataManager.Excel.GetSheet<MobHuntOrderType>()!.GetRow((uint)billNumber)!;

			uint rowId = mobHuntOrderTypeRow.OrderStart.Value!.RowId +
						 (uint)(this.MobHuntStruct->BillOffset[mobHuntOrderTypeRow.RowId] - 1);

			if (rowId > mobHuntOrderSheet.RowCount) {
				continue;
			}

			IEnumerable<MobHuntOrder> mobHuntOrderRows = mobHuntOrderSheet.Where(x => x.RowId == rowId);

			foreach (MobHuntOrder mobHuntOrderRow in mobHuntOrderRows) {
				MobHuntEntry? mobHuntEntry =
					mobHuntList.FirstOrDefault(x => x.MobHuntId == mobHuntOrderRow.Target.Value!.Name.Row);

				if (mobHuntEntry == null) {
					mobHuntList.Add(
						new MobHuntEntry {
							Name = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(
								mobHuntOrderRow.Target.Value!.Name.Value!.Singular),
							TerritoryName =
								mobHuntOrderRow.Target.Value!.TerritoryType.Value!.PlaceName.Value!.Name,
							ExpansionName = mobHuntOrderRow.Target.Value!.TerritoryType.Value.TerritoryType.Value!
								.ExVersion.Value!.Name,
							ExpansionId = mobHuntOrderRow.Target.Value!.TerritoryType.Value.TerritoryType.Value!
								.ExVersion.Row,
							MapId = mobHuntOrderRow.Target.Value!.TerritoryType.Row,
							TerritoryType = mobHuntOrderRow.Target.Value!.TerritoryType.Value.TerritoryType.Row,
							MobHuntId = mobHuntOrderRow.Target.Value!.Name.Row,
							IsEliteMark = mobHuntOrderTypeRow.Type == 2,
							CurrentKillsOffset = (5 * (uint)billNumber) + mobHuntOrderRow.SubRowId,
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

		this.pathMap.Clear();

		foreach (MobHuntEntry entry in mobHuntList) {
			string key = entry.ExpansionName ?? "Unknown";
			KeyValuePair<uint, string> subKey =
				new(entry.TerritoryType, entry.TerritoryName ?? "Unknown");

			(uint nearestAetheryteId, float distanceToNearestAetheryte) = Location.FindNearestAetheryte(entry.TerritoryType, entry.MapId, entry.MobHuntId);
			Location.Database[entry.MobHuntId].NearestAetheryteId = nearestAetheryteId;
			Location.Database[entry.MobHuntId].DistanceToAetheryte = distanceToNearestAetheryte;

			if (!this.MobHuntEntries.ContainsKey(key)) {
				this.MobHuntEntries[key] = [];
			}

			if (!this.MobHuntEntries[key].ContainsKey(subKey)) {
				this.MobHuntEntries[key][subKey] = [];
			}

			this.MobHuntEntries[key][subKey].Add(entry);

			if (!this.pathMap.ContainsKey(entry.ExpansionId)) {
				this.pathMap[entry.ExpansionId] = [];
			}

			if (!this.pathMap[entry.ExpansionId].ContainsKey(entry.TerritoryType)) {
				this.pathMap[entry.ExpansionId][entry.TerritoryType] = [];
			}

			this.pathMap[entry.ExpansionId][entry.TerritoryType].Add(entry);
		}

		this.ClientStateOnTerritoryChanged(0);

		this.MobHuntEntriesReady = true;
	}

	public void Dispose() {
		this.Dispose(true);
		GC.SuppressFinalize(this);
	}
}
