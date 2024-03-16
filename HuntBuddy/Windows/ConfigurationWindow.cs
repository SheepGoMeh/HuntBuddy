using System.Numerics;

using Dalamud.Interface.Utility;
using Dalamud.Interface.Windowing;

using HuntBuddy.Utils;

using ImGuiNET;

namespace HuntBuddy.Windows;

/// <summary>
/// Configuration window.
/// </summary>
public class ConfigurationWindow: Window {
	public const int BaseTooltipWidth = 450;
	public ConfigurationWindow() : base(
		$"{Plugin.Instance.Name} configuration",
		ImGuiWindowFlags.NoDocking,
		true) {
		this.Size = Vector2.Zero;
		this.SizeCondition = ImGuiCond.Always;
	}

	public override void PreOpenCheck() {
		if (Plugin.Instance.Configuration.LockWindowPositions) {
			this.Flags |= ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoMove;
		}
		else {
			this.Flags &= ~(ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoMove);
		}
	}

	public override void Draw() {
		bool save = false;

		ImGui.BeginDisabled(Plugin.EspConsumer?.IsAvailable == false);

		save |= ImGui.Checkbox("Enable XivEsp plugin integration?", ref Plugin.Instance.Configuration.EnableXivEspIntegration);

		ImGui.Indent();
		save |= ImGui.Checkbox("Set XivEsp search when using '/phb next' command?", ref Plugin.Instance.Configuration.AutoSetEspSearchOnNextHuntCommand);
		ImGui.Unindent();
		if (ImGui.IsItemHovered()) {
			InterfaceUtil.DrawWrappedTooltip(ImGuiHelpers.GlobalScale * BaseTooltipWidth,
				"If enabled and XivEsp is available, the '/phb next' command will automatically set XivEsp's search"
				+ "to the name of the chosen mark, EVEN IF you already have a custom search active.");
		}

		ImGui.EndDisabled();

		ImGui.Spacing();

		save |= ImGui.Checkbox("Lock plugin window positions and sizes",
			ref Plugin.Instance.Configuration.LockWindowPositions);

		save |= ImGui.Checkbox("Include hunt area on map by default",
			ref Plugin.Instance.Configuration.IncludeAreaOnMap);
		if (ImGui.IsItemHovered()) {
			InterfaceUtil.DrawWrappedTooltip(ImGuiHelpers.GlobalScale * BaseTooltipWidth,
				$"{Plugin.Instance.Name} can show an approximate general area for hunt mobs around the flagged location."
				+ "You can always hold SHIFT to toggle this when you click the button to flag a target on your map.");
		}

		save |= ImGui.Checkbox("Show hunts in local area",
			   ref Plugin.Instance.Configuration.ShowLocalHunts);
		if (ImGui.IsItemHovered()) {
			InterfaceUtil.DrawWrappedTooltip(ImGuiHelpers.GlobalScale * BaseTooltipWidth,
				$"If enabled, {Plugin.Instance.Name} will display an extra window with the hunt targets in your current map zone.");
		}

		save |= ImGui.Checkbox("Show icons of hunts in local area",
			ref Plugin.Instance.Configuration.ShowLocalHuntIcons);
		if (ImGui.IsItemHovered()) {
			InterfaceUtil.DrawWrappedTooltip(ImGuiHelpers.GlobalScale * BaseTooltipWidth,
				"These icons are taken from the hunt mark bills the game displays, and so may not be the clearest images available.");
		}

		save |= ImGui.Checkbox("Hide background of local hunts window",
			ref Plugin.Instance.Configuration.HideLocalHuntBackground);

		save |= ImGui.Checkbox("Hide completed targets in local hunts window",
			ref Plugin.Instance.Configuration.HideCompletedHunts);

		save |= ImGui.Checkbox("Suppress chat warning about B-ranks not having locations",
			ref Plugin.Instance.Configuration.SuppressEliteMarkLocationWarning);
		if (ImGui.IsItemHovered()) {
			InterfaceUtil.DrawWrappedTooltip(ImGuiHelpers.GlobalScale * BaseTooltipWidth,
				$"When the '/phb next' command selects a B-rank mark, a warning is printed in your chat log that {Plugin.Instance.Name}"
				+ " DOES NOT provide locations for B-rank hunt marks. If this warning annoys you, you can turn it off.\n"
				+ "\n"
				+ "Do not ask for B-rank locations to be provided.");
		}

		ImGui.Spacing();

		save |= ImGui.SliderFloat("Hunt icon scale", ref Plugin.Instance.Configuration.IconScale, 0.2f, 2f, "%.2f");
		if (ImGui.ColorEdit4("Hunt icon background colour", ref Plugin.Instance.Configuration.IconBackgroundColour)) {
			Plugin.Instance.Configuration.IconBackgroundColourU32 =
				ImGui.ColorConvertFloat4ToU32(Plugin.Instance.Configuration.IconBackgroundColour);
			save = true;
		}

		if (save) {
			Plugin.Instance.Configuration.Save();
		}
	}
}
