using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Dalamud.Interface;
using ImGuiNET;

namespace HuntBuddy
{
	public class Interface
	{
		private readonly Plugin plugin;

		public bool DrawInterface;
		private bool drawConfigurationInterface;

		public Interface(Plugin plugin)
		{
			this.plugin = plugin;
		}

		public unsafe bool Draw()
		{
			var draw = true;

			ImGui.SetNextWindowSize(new Vector2(400 * ImGui.GetIO().FontGlobalScale, 500), ImGuiCond.Once);

			var windowFlags = ImGuiWindowFlags.NoDocking;

			if (this.plugin.Configuration.LockWindowPositions)
			{
				windowFlags |= ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoMove;
			}

			if (!ImGui.Begin($"{this.plugin.Name}", ref draw, windowFlags))
			{
				return draw;
			}

			if (!this.plugin.MobHuntEntriesReady)
			{
				ImGui.Text("Reloading data ...");
				ImGui.End();
				return draw;
			}

			if (Interface.IconButton(FontAwesomeIcon.Redo, "Reload"))
			{
				ImGui.End();
				this.plugin.MobHuntEntriesReady = false;
				Task.Run(() => this.plugin.ReloadData());
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
				this.drawConfigurationInterface = !this.drawConfigurationInterface;
			}

			foreach (var expansionEntry in this.plugin.MobHuntEntries.Where(
				         expansionEntry =>
					         ImGui.TreeNode(expansionEntry.Key)))
			{
				foreach (var entry in expansionEntry.Value.Where(
					         entry =>
					         {
						         var treeOpen = ImGui.TreeNodeEx(entry.Key.Value, ImGuiTreeNodeFlags.AllowItemOverlap);
						         ImGui.SameLine();
						         var killedCount = entry.Value.Count(
							         x =>
								         this.plugin.MobHuntStruct->CurrentKills[x.CurrentKillsOffset] ==
								         x.NeededKills);

						         if (killedCount != entry.Value.Count)
						         {
							         ImGui.Text($"({killedCount}/{entry.Value.Count})");
						         }
						         else
						         {
							         ImGui.TextColored(
								         new Vector4(0f, 1f, 0f, 1f),
								         $"({killedCount}/{entry.Value.Count})");
						         }

						         return treeOpen;
					         }))
				{
					//ImGui.Indent();
					foreach (var mobHuntEntry in entry.Value)
					{
						if (Location.Database.ContainsKey(mobHuntEntry.MobHuntId))
						{
							if (Interface.IconButton(FontAwesomeIcon.MapMarkerAlt, $"pin##{mobHuntEntry.MobHuntId}"))
							{
								Location.CreateMapMarker(
									mobHuntEntry.TerritoryType,
									mobHuntEntry.MapId,
									mobHuntEntry.MobHuntId,
									mobHuntEntry.Name,
									Location.OpenType.None);
							}

							if (ImGui.IsItemHovered())
							{
								ImGui.BeginTooltip();
								ImGui.Text("Place marker on the map");
								ImGui.EndTooltip();
							}

							ImGui.SameLine();

							if (Interface.IconButton(FontAwesomeIcon.MapMarkedAlt, $"open##{mobHuntEntry.MobHuntId}"))
							{
								var includeArea = this.plugin.Configuration.IncludeAreaOnMap;
								if (ImGui.IsKeyDown(ImGuiKey.ModShift))
								{
									includeArea = !includeArea;
								}
								Location.CreateMapMarker(
									mobHuntEntry.TerritoryType,
									mobHuntEntry.MapId,
									mobHuntEntry.MobHuntId,
									mobHuntEntry.Name,
									includeArea ? Location.OpenType.ShowOpen : Location.OpenType.MarkerOpen);
							}

							if (ImGui.IsItemHovered())
							{
								var color = ImGui.IsKeyDown(ImGuiKey.ModShift) ? new Vector4(0f, 0.7f, 0f, 1f) : new Vector4(0.7f, 0.7f, 0.7f, 1f);
								ImGui.BeginTooltip();
								if (this.plugin.Configuration.IncludeAreaOnMap)
								{
									ImGui.Text("Show hunt area on the map");
									ImGui.TextColored(
										color,
										"Hold [SHIFT] to show the location only");
								}
								else
								{
									ImGui.Text("Show hunt location on the map");
									ImGui.TextColored(
										color,
										"Hold [SHIFT] to include the area");
								}
								ImGui.EndTooltip();
							}

							ImGui.SameLine();

							if (Plugin.TeleportConsumer?.Subscribed == true)
							{
								if (Interface.IconButton(FontAwesomeIcon.StreetView, $"t##{mobHuntEntry.MobHuntId}"))
								{
									Location.TeleportToNearestAetheryte(
										mobHuntEntry.TerritoryType,
										mobHuntEntry.MapId,
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

						var currentKills = this.plugin.MobHuntStruct->CurrentKills[mobHuntEntry.CurrentKillsOffset];
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
							ImGui.TextColored(
								new Vector4(0f, 1f, 0f, 1f),
								$"({currentKills}/{mobHuntEntry.NeededKills})");
						}
					}

					//ImGui.Unindent();
					ImGui.TreePop();
				}

				ImGui.TreePop();
			}

			ImGui.End();

			if (this.drawConfigurationInterface)
			{
				this.DrawConfiguration();
			}

			return draw;
		}

		public unsafe void DrawLocalHunts()
		{
			if (!this.plugin.Configuration.ShowLocalHunts ||
			    this.plugin.CurrentAreaMobHuntEntries.IsEmpty ||
			    this.plugin.CurrentAreaMobHuntEntries.Count(
				    x =>
					    this.plugin.MobHuntStruct->CurrentKills[x.CurrentKillsOffset] == x.NeededKills) ==
			    this.plugin.CurrentAreaMobHuntEntries.Count)
			{
				return;
			}

			ImGui.SetNextWindowSize(Vector2.Zero, ImGuiCond.Always);

			var windowFlags = ImGuiWindowFlags.NoNavInputs | ImGuiWindowFlags.NoDocking;

			if (this.plugin.Configuration.HideLocalHuntBackground)
			{
				windowFlags |= ImGuiWindowFlags.NoBackground;
			}

			if (this.plugin.Configuration.LockWindowPositions)
			{
				windowFlags |= ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoMove;
			}

			if (!ImGui.Begin("Hunts in current area", windowFlags))
			{
				return;
			}

			foreach (var mobHuntEntry in this.plugin.CurrentAreaMobHuntEntries)
			{
				var currentKills = this.plugin.MobHuntStruct->CurrentKills[mobHuntEntry.CurrentKillsOffset];

				if (this.plugin.Configuration.HideCompletedHunts && currentKills == mobHuntEntry.NeededKills)
				{
					continue;
				}

				if (Location.Database.ContainsKey(mobHuntEntry.MobHuntId))
				{
					if (Interface.IconButton(FontAwesomeIcon.MapMarkerAlt, $"pin##{mobHuntEntry.MobHuntId}"))
					{
						Location.CreateMapMarker(
							mobHuntEntry.TerritoryType,
							mobHuntEntry.MapId,
							mobHuntEntry.MobHuntId,
							mobHuntEntry.Name,
							Location.OpenType.None);
					}

					if (ImGui.IsItemHovered())
					{
						ImGui.BeginTooltip();
						ImGui.Text("Place marker on the map");
						ImGui.EndTooltip();
					}

					ImGui.SameLine();

					if (Interface.IconButton(FontAwesomeIcon.Compass, $"openRadius##{mobHuntEntry.MobHuntId}"))
					{
						Location.CreateMapMarker(
							mobHuntEntry.TerritoryType,
							mobHuntEntry.MapId,
							mobHuntEntry.MobHuntId,
							mobHuntEntry.Name,
							Location.OpenType.ShowOpen);
					}

					if (ImGui.IsItemHovered())
					{
						ImGui.BeginTooltip();
						ImGui.Text("Show hunt area on the map");
						ImGui.EndTooltip();
					}

					ImGui.SameLine();

					if (Interface.IconButton(FontAwesomeIcon.MapMarkedAlt, $"open##{mobHuntEntry.MobHuntId}"))
					{
						Location.CreateMapMarker(
							mobHuntEntry.TerritoryType,
							mobHuntEntry.MapId,
							mobHuntEntry.MobHuntId,
							mobHuntEntry.Name);
					}

					if (ImGui.IsItemHovered())
					{
						ImGui.BeginTooltip();
						ImGui.Text("Show hunt location on the map");
						ImGui.EndTooltip();
					}

					ImGui.SameLine();
				}

				ImGui.Text($"{mobHuntEntry.Name} ({currentKills}/{mobHuntEntry.NeededKills})");

				if (!this.plugin.Configuration.ShowLocalHuntIcons)
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

			var windowFlags = ImGuiWindowFlags.NoDocking;

			if (this.plugin.Configuration.LockWindowPositions)
			{
				windowFlags |= ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoMove;
			}

			if (!ImGui.Begin($"{this.plugin.Name} settings", windowFlags))
			{
				return;
			}

			var save = false;

			save |= ImGui.Checkbox("Lock plugin window positions", ref this.plugin.Configuration.LockWindowPositions);
			save |= ImGui.Checkbox("Include hunt area on map by default", ref this.plugin.Configuration.IncludeAreaOnMap);
			save |= ImGui.Checkbox("Show hunts in local area", ref this.plugin.Configuration.ShowLocalHunts);
			save |= ImGui.Checkbox(
				"Show icons of hunts in local area",
				ref this.plugin.Configuration.ShowLocalHuntIcons);
			save |= ImGui.Checkbox(
				"Hide background of local hunts window",
				ref this.plugin.Configuration.HideLocalHuntBackground);
			save |= ImGui.Checkbox(
				"Hide completed targets in local hunts window",
				ref this.plugin.Configuration.HideCompletedHunts);
			save |= ImGui.SliderFloat("Hunt icon scale", ref this.plugin.Configuration.IconScale, 0.2f, 2f, "%.2f");
			if (ImGui.ColorEdit4("Hunt icon background colour", ref this.plugin.Configuration.IconBackgroundColour))
			{
				this.plugin.Configuration.IconBackgroundColourU32 =
					ImGui.ColorConvertFloat4ToU32(this.plugin.Configuration.IconBackgroundColour);
				save = true;
			}

			if (save)
			{
				this.plugin.Configuration.Save();
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
			imageSize *= ImGui.GetIO().FontGlobalScale * this.plugin.Configuration.IconScale;

			ImGui.InvisibleButton("canvas", imageSize);

			var drawList = ImGui.GetWindowDrawList();
			if (mobHuntEntry is { ExpansionId: 4, IsEliteMark: false }) // Endwalker uses circle for non elite mobs
			{
				drawList.AddCircleFilled(
					cursorPos + (imageSize / 2f),
					imageSize.X / 2f,
					this.plugin.Configuration.IconBackgroundColourU32);
			}
			else
			{
				drawList.AddRectFilled(
					cursorPos,
					cursorPos + imageSize,
					this.plugin.Configuration.IconBackgroundColourU32);
			}

			drawList.AddImage(mobHuntEntry.Icon.ImGuiHandle, cursorPos, cursorPos + imageSize);
		}
	}
}