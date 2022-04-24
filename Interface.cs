using System;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Dalamud.Game.Text.SeStringHandling.Payloads;
using Dalamud.Interface;
using Dalamud.Logging;
using HuntBuddy.Structs;
using ImGuiNET;
using Lumina.Excel.GeneratedSheets;

namespace HuntBuddy
{
	public class Interface
	{
		private readonly Plugin _plugin;

		public bool DrawInterface;
		private bool _drawConfigurationInterface;

		public Interface(Plugin plugin)
		{
			this._plugin = plugin;
		}

		public unsafe bool Draw()
		{
			var draw = true;

			var fontGlobalScale = ImGui.GetIO().FontGlobalScale;

			ImGui.SetNextWindowSize(new Vector2(400 * ImGui.GetIO().FontGlobalScale, 500), ImGuiCond.Once);

			if (!ImGui.Begin($"{this._plugin.Name}", ref draw, ImGuiWindowFlags.NoDocking))
			{
				return draw;
			}

			if (!this._plugin.MobHuntEntriesReady)
			{
				ImGui.Text("Reloading data ...");
				ImGui.End();
				return draw;
			}

			if (Interface.IconButton(FontAwesomeIcon.Redo, "Reload"))
			{
				ImGui.End();
				this._plugin.MobHuntEntriesReady = false;
				Task.Run(() => this._plugin.ReloadData());
				return draw;
			}

			if (ImGui.IsItemHovered())
			{
				ImGui.BeginTooltip();
				ImGui.Text("Click this button to reload daily hunt data");
				ImGui.EndTooltip();
			}
			
			ImGui.SameLine();

			if (Interface.IconButton(FontAwesomeIcon.Cog, "Config"))
			{
				this._drawConfigurationInterface = !this._drawConfigurationInterface;
			}

			foreach (var expansionEntry in this._plugin.MobHuntEntries.Where(expansionEntry =>
				         ImGui.TreeNode(expansionEntry.Key)))
			{
				foreach (var entry in expansionEntry.Value.Where(entry =>
				         {
					         var treeOpen = ImGui.TreeNodeEx(entry.Key.Value, ImGuiTreeNodeFlags.AllowItemOverlap);
					         ImGui.SameLine();
					         var killedCount = entry.Value.Count(x =>
						         this._plugin.MobHuntStruct->CurrentKills[x.CurrentKillsOffset] == x.NeededKills);

					         if (killedCount != entry.Value.Count)
					         {
						         ImGui.Text($"({killedCount}/{entry.Value.Count})");
					         }
					         else
					         {
						         ImGui.TextColored(new Vector4(0f, 1f, 0f, 1f),
							         $"({killedCount}/{entry.Value.Count})");
					         }

					         return treeOpen;
				         }))
				{
					ImGui.Indent();
					foreach (var mobHuntEntry in entry.Value)
					{
						if (Location.Database.ContainsKey(mobHuntEntry.MobHuntId))
						{
							if (Interface.IconButton(FontAwesomeIcon.MapMarked, $"##{mobHuntEntry.MobHuntId}"))
							{
								Location.OpenMapLink(mobHuntEntry.TerritoryType, mobHuntEntry.MapId,
									mobHuntEntry.MobHuntId);
							}

							if (ImGui.IsItemHovered())
							{
								ImGui.BeginTooltip();
								ImGui.Text("Show hunt location on the map");
								ImGui.EndTooltip();
							}

							ImGui.SameLine();

							if (Plugin.TeleportConsumer?.Subscribed == true)
							{
								if (Interface.IconButton(FontAwesomeIcon.StreetView, $"t##{mobHuntEntry.MobHuntId}"))
								{
									Location.TeleportToNearestAetheryte(mobHuntEntry.TerritoryType, mobHuntEntry.MapId,
										mobHuntEntry.MobHuntId);
								}

								if (ImGui.IsItemHovered())
								{
									ImGui.BeginTooltip();
									ImGui.Text("Teleport to nearest aetheryte");
									ImGui.EndTooltip();
								}

								ImGui.SameLine();
							}
						}

						var currentKills = this._plugin.MobHuntStruct->CurrentKills[mobHuntEntry.CurrentKillsOffset];
						ImGui.Text(mobHuntEntry.Name);
						if (ImGui.IsItemHovered())
						{
							ImGui.PushStyleColor(ImGuiCol.PopupBg, Vector4.Zero);
							ImGui.BeginTooltip();
							this.DrawHuntIcon(mobHuntEntry);
							ImGui.PopStyleColor();
							ImGui.EndTooltip();
						}

						ImGui.SameLine();
						if (currentKills != mobHuntEntry.NeededKills)
						{
							ImGui.Text($"({currentKills}/{mobHuntEntry.NeededKills})");
						}
						else
						{
							ImGui.TextColored(new Vector4(0f, 1f, 0f, 1f),
								$"({currentKills}/{mobHuntEntry.NeededKills})");
						}
					}

					ImGui.Unindent();
					ImGui.TreePop();
				}

				ImGui.TreePop();
			}

			ImGui.End();

			if (this._drawConfigurationInterface)
			{
				this.DrawConfiguration();
			}

			return draw;
		}

		public unsafe void DrawLocalHunts()
		{
			if (!this._plugin.Configuration.ShowLocalHunts ||
			    this._plugin.CurrentAreaMobHuntEntries.IsEmpty ||
			    this._plugin.CurrentAreaMobHuntEntries.Count(x =>
				    this._plugin.MobHuntStruct->CurrentKills[x.CurrentKillsOffset] == x.NeededKills) ==
			    this._plugin.CurrentAreaMobHuntEntries.Count)
			{
				return;
			}

			var fontGlobalScale = ImGui.GetIO().FontGlobalScale;

			ImGui.SetNextWindowSize(Vector2.Zero, ImGuiCond.Always);

			var windowFlags = ImGuiWindowFlags.NoNavInputs | ImGuiWindowFlags.NoDocking;

			if (this._plugin.Configuration.HideLocalHuntBackground)
			{
				windowFlags |= ImGuiWindowFlags.NoBackground;
			}

			if (!ImGui.Begin("Hunts in current area", windowFlags))
			{
				return;
			}

			foreach (var mobHuntEntry in this._plugin.CurrentAreaMobHuntEntries)
			{
				var currentKills = this._plugin.MobHuntStruct->CurrentKills[mobHuntEntry.CurrentKillsOffset];

				if (this._plugin.Configuration.HideCompletedHunts && currentKills == mobHuntEntry.NeededKills)
				{
					continue;
				}

				if (Location.Database.ContainsKey(mobHuntEntry.MobHuntId))
				{
					if (Interface.IconButton(FontAwesomeIcon.MapMarked, $"##{mobHuntEntry.MobHuntId}"))
					{
						Location.OpenMapLink(mobHuntEntry.TerritoryType, mobHuntEntry.MapId,
							mobHuntEntry.MobHuntId);
					}

					ImGui.SameLine();
				}

				ImGui.Text($"{mobHuntEntry.Name} ({currentKills}/{mobHuntEntry.NeededKills})");

				if (!this._plugin.Configuration.ShowLocalHuntIcons)
				{
					continue;
				}

				this.DrawHuntIcon(mobHuntEntry);
			}

			ImGui.End();
		}

		private void DrawConfiguration()
		{
			ImGui.SetNextWindowSize(Vector2.Zero, ImGuiCond.Always);

			if (!ImGui.Begin($"{this._plugin.Name} settings", ImGuiWindowFlags.NoDocking))
			{
				return;
			}

			var save = false;

			save |= ImGui.Checkbox("Show hunts in local area", ref this._plugin.Configuration.ShowLocalHunts);
			save |= ImGui.Checkbox("Show icons of hunts in local area", ref this._plugin.Configuration.ShowLocalHuntIcons);
			save |= ImGui.Checkbox("Hide background of local hunts window",
				ref this._plugin.Configuration.HideLocalHuntBackground);
			save |= ImGui.Checkbox("Hide completed targets in local hunts window",
				ref this._plugin.Configuration.HideCompletedHunts);
			save |= ImGui.SliderFloat("Hunt icon scale", ref this._plugin.Configuration.IconScale, 0.2f, 2f, "%.2f");
			if (ImGui.ColorEdit4("Hunt icon background colour", ref this._plugin.Configuration.IconBackgroundColour))
			{
				this._plugin.Configuration.IconBackgroundColourU32 =
					ImGui.ColorConvertFloat4ToU32(this._plugin.Configuration.IconBackgroundColour);
				save = true;
			}

			if (save)
			{
				this._plugin.Configuration.Save();
			}


			ImGui.End();
		}

		private static bool IconButton(FontAwesomeIcon icon, string? id = null)
		{
			ImGui.PushFont(UiBuilder.IconFont);

			var text = icon.ToIconString();
			if (id != null)
			{
				text += $"##{id}";
			}

			var result = ImGui.Button(text);

			ImGui.PopFont();

			return result;
		}

		private void DrawHuntIcon(MobHuntEntry mobHuntEntry)
		{
			var cursorPos = ImGui.GetCursorScreenPos();
			var imageSize = mobHuntEntry.ExpansionId < 3 ? new Vector2(192f, 128f) : new Vector2(210f);
			imageSize *= ImGui.GetIO().FontGlobalScale * this._plugin.Configuration.IconScale;

			ImGui.InvisibleButton("canvas", imageSize);

			var drawList = ImGui.GetWindowDrawList();
			if (mobHuntEntry.ExpansionId == 4 && !mobHuntEntry.IsEliteMark) // Endwalker uses circle for non elite mobs
			{
				drawList.AddCircleFilled(cursorPos + imageSize / 2f, imageSize.X / 2f,
					this._plugin.Configuration.IconBackgroundColourU32);
			}
			else
			{
				drawList.AddRectFilled(cursorPos, cursorPos + imageSize,
					this._plugin.Configuration.IconBackgroundColourU32);
			}

			drawList.AddImage(mobHuntEntry.Icon.ImGuiHandle, cursorPos, cursorPos + imageSize);
		}
	}
}