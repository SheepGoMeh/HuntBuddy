using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Dalamud.Data;
using Dalamud.Game;
using Dalamud.Game.ClientState;
using Dalamud.Game.Command;
using Dalamud.Game.Gui;
using Dalamud.IoC;
using Dalamud.Logging;
using Dalamud.Plugin;
using Dalamud.Utility;
using Lumina.Excel.GeneratedSheets;
using FFXIVClientStructs.FFXIV.Client.Game;
using HuntBuddy.Attributes;
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

		private readonly PluginCommandManager<Plugin> _commandManager;
		private readonly Interface _interface;
		public readonly Dictionary<string, Dictionary<KeyValuePair<uint, string>, List<MobHuntEntry>>> MobHuntEntries;
		public readonly ConcurrentBag<MobHuntEntry> CurrentAreaMobHuntEntries;
		public bool MobHuntEntriesReady = true;
		public readonly unsafe MobHuntStruct* MobHuntStruct;
		public readonly Configuration Configuration;

		public Plugin()
		{
			this._commandManager = new PluginCommandManager<Plugin>(this, Commands);
			this._interface = new Interface(this);
			this.MobHuntEntries = new Dictionary<string, Dictionary<KeyValuePair<uint, string>, List<MobHuntEntry>>>();
			this.CurrentAreaMobHuntEntries = new ConcurrentBag<MobHuntEntry>();
			this.Configuration = (Configuration)(PluginInterface.GetPluginConfig() ?? new Configuration());
			this.Configuration.IconBackgroundColourU32 =
				ImGui.ColorConvertFloat4ToU32(this.Configuration.IconBackgroundColour);

			unsafe
			{
				this.MobHuntStruct =
					(MobHuntStruct*)SigScanner.GetStaticAddressFromSig(
						"D1 48 8D 0D ?? ?? ?? ?? 48 83 C4 20 5F E9 ?? ?? ?? ??");
			}

			ClientState.TerritoryChanged += ClientStateOnTerritoryChanged;
			PluginInterface.UiBuilder.Draw += DrawInterface;
			PluginInterface.UiBuilder.Draw += _interface.DrawLocalHunts;
			PluginInterface.UiBuilder.OpenConfigUi += OpenConfigUi;
		}

		private void ClientStateOnTerritoryChanged(object? sender, ushort e)
		{
			CurrentAreaMobHuntEntries.Clear();

			foreach (var mobHuntEntry in MobHuntEntries.SelectMany(expansionEntry => expansionEntry.Value
				         .Where(entry => entry.Key.Key == ClientState.TerritoryType)
				         .SelectMany(entry => entry.Value)))
			{
				CurrentAreaMobHuntEntries.Add(mobHuntEntry);
			}
		}

		private void OpenConfigUi()
		{
			_interface.DrawInterface = !_interface.DrawInterface;
		}

		private void DrawInterface()
		{
			_interface.DrawInterface = _interface.DrawInterface && _interface.Draw();
		}

		private void Dispose(bool disposing)
		{
			if (!disposing)
			{
				return;
			}

			MobHuntEntriesReady = false;
			PluginInterface.UiBuilder.Draw -= DrawInterface;
			PluginInterface.UiBuilder.Draw -= _interface.DrawLocalHunts;
			PluginInterface.UiBuilder.OpenConfigUi -= OpenConfigUi;

			_commandManager.Dispose();
		}

		[Command("/phb")]
		[HelpMessage("Toggles UI")]
		public void PluginCommand(string command, string args)
		{
			OpenConfigUi();
		}

		public unsafe void ReloadData()
		{
			var inventoryContainer = InventoryManager.Instance()->GetInventoryContainer(InventoryType.KeyItems);

			if (inventoryContainer->Loaded == 0)
			{
				PluginLog.Log("Container not loaded!");
				return;
			}

			if (inventoryContainer->Size == 0)
			{
				PluginLog.Log("Container is empty!");
				return;
			}

			var huntBills = new List<KeyValuePair<byte,uint>>();

			for (var i = 0; i != inventoryContainer->Size; ++i)
			{
				var inventoryItemPtr = inventoryContainer->GetInventorySlot(i);

				if (inventoryItemPtr == null || (*inventoryItemPtr).ItemID == 0)
				{
					continue;
				}

				var inventoryItem = *inventoryItemPtr;

				foreach (var row in DataManager.Excel.GetSheet<MobHuntOrderType>()!)
				{
					if (inventoryItem.ItemID == row.EventItem.Row)
					{
						huntBills.Add(new KeyValuePair<byte, uint>(row.Type, row.RowId));
						break;
					}
				}
			}
			
			MobHuntEntries.Clear();
			var mobHuntList = new List<MobHuntEntry>();
			var mobHuntOrderSheet = DataManager.Excel.GetSheet<MobHuntOrder>()!;
			
			foreach (var (mobHuntType, billNumber) in huntBills)
			{
				var mobHuntOrderTypeRow = DataManager.Excel.GetSheet<MobHuntOrderType>()!.GetRow(billNumber)!;
					
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
						mobHuntList.Add(new MobHuntEntry
						{
							Name = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(mobHuntOrderRow.Target.Value!.Name.Value!.Singular),
							TerritoryName = mobHuntOrderRow.Target.Value!.TerritoryType.Value!.PlaceName.Value!.Name,
							ExpansionName = mobHuntOrderRow.Target.Value!.TerritoryType.Value.TerritoryType.Value!.ExVersion.Value!.Name,
							ExpansionId = mobHuntOrderRow.Target.Value!.TerritoryType.Value.TerritoryType.Value!.ExVersion.Row,
							MapId = mobHuntOrderRow.Target.Value!.TerritoryType.Row,
							TerritoryType = mobHuntOrderRow.Target.Value!.TerritoryType.Value.TerritoryType.Row,
							MobHuntId = mobHuntOrderRow.Target.Value!.Name.Row,
							MobHuntType = mobHuntType,
							CurrentKillsOffset = 5 * billNumber + mobHuntOrderRow.SubRowId,
							NeededKills = mobHuntOrderRow.NeededKills,
							Icon = LoadIcon(mobHuntOrderRow.Target.Value.Icon)
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
					
				if (!MobHuntEntries.ContainsKey(key))
				{
					MobHuntEntries[key] = new Dictionary<KeyValuePair<uint, string>, List<MobHuntEntry>>();
				}

				if (!MobHuntEntries[key].ContainsKey(subKey))
				{
					MobHuntEntries[key][subKey] = new List<MobHuntEntry>();
				}
					
				MobHuntEntries[key][subKey].Add(entry);
			}

			ClientStateOnTerritoryChanged(null, 0);

			MobHuntEntriesReady = true;
			_interface.DrawInterface = true;
		}
		
		private static TexFile? GetHdIcon(uint id)
		{
			var path = $"ui/icon/{id / 1000 * 1000:000000}/{id:000000}_hr1.tex";
			return DataManager.GetFile<TexFile>(path);
		}

		private static TextureWrap LoadIcon(uint id)
		{
			var icon     = GetHdIcon(id) ?? DataManager.GetIcon(id)!;
			var iconData = icon.GetRgbaImageData();

			return PluginInterface.UiBuilder.LoadImageRaw(iconData, icon.Header.Width, icon.Header.Height, 4);
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}