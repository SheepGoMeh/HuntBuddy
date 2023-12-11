using System.Numerics;
using Dalamud.Interface.Windowing;
using ImGuiNET;

namespace HuntBuddy.Windows;

/// <summary>
/// Configuration window.
/// </summary>
public class ConfigurationWindow : Window
{
    public ConfigurationWindow() : base(
        $"{Plugin.Instance.Name} configuration",
        ImGuiWindowFlags.NoDocking,
        true)
    {
        this.Size = Vector2.Zero;
        this.SizeCondition = ImGuiCond.Always;
    }

    public override void PreOpenCheck()
    {
        if (Plugin.Instance.Configuration.LockWindowPositions)
        {
            this.Flags |= ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoMove;
        }
    }

    public override void Draw()
    {
        var save = false;

        save |= ImGui.Checkbox("Lock plugin window positions", ref Plugin.Instance.Configuration.LockWindowPositions);
        save |= ImGui.Checkbox("Include hunt area on map by default", ref Plugin.Instance.Configuration.IncludeAreaOnMap);
        save |= ImGui.Checkbox("Show hunts in local area", ref Plugin.Instance.Configuration.ShowLocalHunts);
        save |= ImGui.Checkbox(
            "Show icons of hunts in local area",
            ref Plugin.Instance.Configuration.ShowLocalHuntIcons);
        save |= ImGui.Checkbox(
            "Hide background of local hunts window",
            ref Plugin.Instance.Configuration.HideLocalHuntBackground);
        save |= ImGui.Checkbox(
            "Hide completed targets in local hunts window",
            ref Plugin.Instance.Configuration.HideCompletedHunts);
        save |= ImGui.SliderFloat("Hunt icon scale", ref Plugin.Instance.Configuration.IconScale, 0.2f, 2f, "%.2f");
        if (ImGui.ColorEdit4("Hunt icon background colour", ref Plugin.Instance.Configuration.IconBackgroundColour))
        {
            Plugin.Instance.Configuration.IconBackgroundColourU32 =
                ImGui.ColorConvertFloat4ToU32(Plugin.Instance.Configuration.IconBackgroundColour);
            save = true;
        }

        if (save)
        {
            Plugin.Instance.Configuration.Save();
        }
    }
}