using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Dalamud.Data;
using Dalamud.Game;
using Dalamud.Game.ClientState;
using Dalamud.Game.Command;
using Dalamud.Game.Gui;
using Dalamud.IoC;
using Dalamud.Plugin;
using Dalamud.Utility;
using Lumina.Excel.GeneratedSheets;
using HuntBuddy.Attributes;
using HuntBuddy.Ipc;
using HuntBuddy.Structs;
using ImGuiNET;
using ImGuiScene;
using Lumina.Data.Files;

namespace HuntBuddy
{
	public class Plugin : IDalamudPlugin
	{
		public string Name => "Hunt Buddy";

		[PluginService]
		[RequiredVersion("1.0")]
		public static DalamudPluginInterface PluginInterface { get; set; } = null!;

		[PluginService]
		[RequiredVersion("1.0")]
		public static CommandManager Commands { get; set; } = null!;

		[PluginService]
		[RequiredVersion("1.0")]
		public static ChatGui Chat { get; set; } = null!;

		[PluginService]
		[RequiredVersion("1.0")]
		public static DataManager DataManager { get; set; } = null!;

		[PluginService]
		[RequiredVersion("1.0")]
		public static SigScanner SigScanner { get; set; } = null!;

		[PluginService]
		[RequiredVersion("1.0")]
		public static GameGui GameGui { get; set; } = null!;

		[PluginService]
		[RequiredVersion("1.0")]
		public static ClientState ClientState { get; set; } = null!;

		[PluginService]
		[RequiredVersion("1.0")]
		public static Framework Framework { get; set; } = null!;

		private readonly PluginCommandManager<Plugin> commandManager;
		private readonly Interface pluginInterface;
		private ObtainedBillEnum lastState;
		public readonly Dictionary<string, Dictionary<KeyValuePair<uint, string>, List<MobHuntEntry>>> MobHuntEntries;
		public readonly ConcurrentBag<MobHuntEntry> CurrentAreaMobHuntEntries;
		public bool MobHuntEntriesReady = true;
		public readonly unsafe MobHuntStruct* MobHuntStruct;
		public readonly Configuration Configuration;
		public static TeleportConsumer? TeleportConsumer;

		public Plugin()
		{
			this.commandManager = new PluginCommandManager<Plugin>(this, Commands);
			this.pluginInterface = new Interface(this);
			this.MobHuntEntries = new Dictionary<string, Dictionary<KeyValuePair<uint, string>, List<MobHuntEntry>>>();
			this.CurrentAreaMobHuntEntries = new ConcurrentBag<MobHuntEntry>();
			this.Configuration = (Configuration)(PluginInterface.GetPluginConfig() ?? new Configuration());
			this.Configuration.IconBackgroundColourU32 =
				ImGui.ColorConvertFloat4ToU32(this.Configuration.IconBackgroundColour);

			unsafe
			{
				this.MobHuntStruct =
					(MobHuntStruct*)SigScanner.GetStaticAddressFromSig(
						"48 8D 0D ?? ?? ?? ?? 8B D8 0F B6 52");
			}

			Plugin.TeleportConsumer = new TeleportConsumer();
			Plugin.ClientState.TerritoryChanged += this.ClientStateOnTerritoryChanged;
			Plugin.PluginInterface.UiBuilder.Draw += this.DrawInterface;
			Plugin.PluginInterface.UiBuilder.Draw += this.pluginInterface.DrawLocalHunts;
			Plugin.PluginInterface.UiBuilder.OpenConfigUi += this.OpenConfigUi;
			Plugin.Framework.Update += this.FrameworkOnUpdate;
		}

		private unsafe void FrameworkOnUpdate(Framework framework)
		{
			if (this.lastState == this.MobHuntStruct->ObtainedBillEnumFlags)
			{
				return;
			}

			this.lastState = this.MobHuntStruct->ObtainedBillEnumFlags;
			this.PluginCommand(string.Empty, "reload");
		}

		private void ClientStateOnTerritoryChanged(object? sender, ushort e)
		{
			this.CurrentAreaMobHuntEntries.Clear();

			foreach (var mobHuntEntry in this.MobHuntEntries.SelectMany(
				         expansionEntry => expansionEntry.Value
					         .Where(entry => entry.Key.Key == Plugin.ClientState.TerritoryType)
					         .SelectMany(entry => entry.Value)))
			{
				this.CurrentAreaMobHuntEntries.Add(mobHuntEntry);
			}
		}

		private void OpenConfigUi()
		{
			this.pluginInterface.DrawInterface = !this.pluginInterface.DrawInterface;
		}

		private void DrawInterface()
		{
			this.pluginInterface.DrawInterface = this.pluginInterface.DrawInterface && this.pluginInterface.Draw();
		}

		private void Dispose(bool disposing)
		{
			if (!disposing)
			{
				return;
			}

			this.MobHuntEntriesReady = false;
			Plugin.ClientState.TerritoryChanged -= this.ClientStateOnTerritoryChanged;
			Plugin.Framework.Update -= this.FrameworkOnUpdate;
			Plugin.PluginInterface.UiBuilder.Draw -= this.DrawInterface;
			Plugin.PluginInterface.UiBuilder.Draw -= this.pluginInterface.DrawLocalHunts;
			Plugin.PluginInterface.UiBuilder.OpenConfigUi -= this.OpenConfigUi;

			this.commandManager.Dispose();
		}

		[Command("/phb")]
		[HelpMessage("Toggles UI\nArguments:\nreload - Reloads data\nlocal - Toggles the local hunt marks window")]
		public void PluginCommand(string command, string args)
		{
			if (args == "reload")
			{
				this.MobHuntEntriesReady = false;
				Task.Run(this.ReloadData);
			}
			else if (args == "local")
			{
				this.Configuration.ShowLocalHunts = !this.Configuration.ShowLocalHunts;
				this.Configuration.Save();
			}
			else
			{
				this.OpenConfigUi();
			}
		}

		public unsafe void ReloadData()
		{
			this.MobHuntEntries.Clear();
			var mobHuntList = new List<MobHuntEntry>();
			var mobHuntOrderSheet = Plugin.DataManager.Excel.GetSheet<MobHuntOrder>()!;

			foreach (var billNumber in Enum.GetValues<BillEnum>())
			{
				if (!this.MobHuntStruct->ObtainedBillEnumFlags.HasFlag((ObtainedBillEnum)(1 << (int)billNumber)))
				{
					continue;
				}

				var mobHuntOrderTypeRow =
					Plugin.DataManager.Excel.GetSheet<MobHuntOrderType>()!.GetRow((uint)billNumber)!;

				var rowId = mobHuntOrderTypeRow.OrderStart.Value!.RowId +
				            (uint)(this.MobHuntStruct->BillOffset[mobHuntOrderTypeRow.RowId] - 1);

				if (rowId > mobHuntOrderSheet.RowCount)
				{
					continue;
				}

				var mobHuntOrderRows = mobHuntOrderSheet.Where(x => x.RowId == rowId);

				foreach (var mobHuntOrderRow in mobHuntOrderRows)
				{
					var mobHuntEntry =
						mobHuntList.FirstOrDefault(x => x.MobHuntId == mobHuntOrderRow.Target.Value!.Name.Row);

					if (mobHuntEntry == null)
					{
						mobHuntList.Add(
							new MobHuntEntry
							{
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
								IsEliteMark = billNumber is BillEnum.ArrElite or BillEnum.HwElite or BillEnum.SbElite
									or BillEnum.ShbElite or BillEnum.EwElite,
								CurrentKillsOffset = (5 * (uint)billNumber) + mobHuntOrderRow.SubRowId,
								NeededKills = mobHuntOrderRow.NeededKills,
								Icon = Plugin.LoadIcon(mobHuntOrderRow.Target.Value.Icon)
							});
					}
					else
					{
						if (mobHuntEntry.NeededKills < mobHuntOrderRow.NeededKills)
						{
							mobHuntEntry.NeededKills = mobHuntOrderRow.NeededKills;
						}
					}
				}
			}

			foreach (var entry in mobHuntList)
			{
				var key = entry.ExpansionName ?? "Unknown";
				var subKey = new KeyValuePair<uint, string>(entry.TerritoryType, entry.TerritoryName ?? "Unknown");

				if (!this.MobHuntEntries.ContainsKey(key))
				{
					this.MobHuntEntries[key] = new Dictionary<KeyValuePair<uint, string>, List<MobHuntEntry>>();
				}

				if (!this.MobHuntEntries[key].ContainsKey(subKey))
				{
					this.MobHuntEntries[key][subKey] = new List<MobHuntEntry>();
				}

				this.MobHuntEntries[key][subKey].Add(entry);
			}

			this.ClientStateOnTerritoryChanged(null, 0);

			this.MobHuntEntriesReady = true;
		}

		private static TexFile? GetHdIcon(uint id)
		{
			var path = $"ui/icon/{id / 1000 * 1000:000000}/{id:000000}_hr1.tex";
			return Plugin.DataManager.GetFile<TexFile>(path);
		}

		private static TextureWrap LoadIcon(uint id)
		{
			var icon = Plugin.GetHdIcon(id) ?? Plugin.DataManager.GetIcon(id)!;
			var iconData = icon.GetRgbaImageData();

			return Plugin.PluginInterface.UiBuilder.LoadImageRaw(iconData, icon.Header.Width, icon.Header.Height, 4);
		}

		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}