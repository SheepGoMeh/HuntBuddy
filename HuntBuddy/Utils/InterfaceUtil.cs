using System.Numerics;

using Dalamud.Interface;
using Dalamud.Interface.Textures.TextureWraps;
using Dalamud.Plugin.Services;
using Dalamud.Interface.Textures;
using ImGuiNET;

using Lumina.Data.Files;

using Lumina.Extensions;

namespace HuntBuddy.Utils;

/// <summary>
/// Interface utilities class.
/// </summary>
public static class InterfaceUtil {
	/// <summary>
	/// Draws hunt icons from game images.
	/// </summary>
	/// <param name="mobHuntEntry"><see cref="MobHuntEntry"/> containing relevant information.</param>
	public static void DrawHuntIcon(MobHuntEntry mobHuntEntry) {
		Vector2 cursorPos = ImGui.GetCursorScreenPos();
		Vector2 imageSize = mobHuntEntry.ExpansionId < 3 ? new Vector2(192f, 128f) : new Vector2(210f);
		imageSize *= ImGui.GetIO().FontGlobalScale * Plugin.Instance.Configuration.IconScale;

		ImGui.InvisibleButton("canvas", imageSize);

		ImDrawListPtr drawList = ImGui.GetWindowDrawList();
		if (mobHuntEntry is { ExpansionId: 4, IsEliteMark: false }) // Endwalker uses circle for non elite mobs
		{
			drawList.AddCircleFilled(
				cursorPos + (imageSize / 2f),
				imageSize.X / 2f,
				Plugin.Instance.Configuration.IconBackgroundColourU32);
		}
		else {
			drawList.AddRectFilled(
				cursorPos,
				cursorPos + imageSize,
				Plugin.Instance.Configuration.IconBackgroundColourU32);
		}

		drawList.AddImage(LoadIcon(mobHuntEntry.Icon).ImGuiHandle, cursorPos, cursorPos + imageSize);
	}

	/// <summary>
	/// Returns a IDalamudTextureWrap for an icon.
	/// Will request a Hi-Res version and fallback to normal resolution otherwise.
	/// </summary>
	/// <param name="id">Icon ID</param>
	/// <returns>IDalamudTextureWrap for the icon, or an empty wrap if the icon is not found.</returns>
	private static IDalamudTextureWrap LoadIcon(uint id) {
		if (Service.TextureProvider.TryGetFromGameIcon(new GameIconLookup {
			IconId = id,
			HiRes = true,
		}, out var texture)) {
			return texture.GetWrapOrEmpty();
		}
		return Service.TextureProvider.GetFromGameIcon(new GameIconLookup {
			IconId = id,
			HiRes = false,
		}).GetWrapOrEmpty();
	}

	/// <summary>
	/// Renders a button with an icon.
	/// </summary>
	/// <param name="icon">Desired <see cref="FontAwesomeIcon"/> to be rendered.</param>
	/// <param name="id">Button ID.</param>
	/// <returns>True if pressed.</returns>
	public static bool IconButton(FontAwesomeIcon icon, string? id) {
		ImGui.PushFont(UiBuilder.IconFont);

		string? text = icon.ToIconString();

		if (id != null) {
			text += $"##{id}";
		}

		bool result = ImGui.Button(text);

		ImGui.PopFont();

		return result;
	}

	/// <summary>
	/// Renders a button with an icon.
	/// </summary>
	/// <param name="icon">Desired <see cref="FontAwesomeIcon"/> to be rendered.</param>
	/// <returns>True if pressed.</returns>
	public static bool IconButton(FontAwesomeIcon icon) => IconButton(icon, null);

	/// <summary>
	/// Draws horizontally-centered text in an ImGui window.
	/// </summary>
	/// <param name="text">The text to draw. Should be a single line.</param>
	// I hate centering text in ImGui
	public static void DrawCenteredText(string text) {
		float width = ImGui.CalcTextSize(text).X;
		float space = ImGui.GetContentRegionAvail().X;
		ImGui.SetCursorPosX((space / 2) - (width / 2));
		ImGui.Text(text);
	}

	/// <summary>
	/// Draw a tooltip with simple text content, using the specified text wrapping position.
	/// </summary>
	/// <param name="maxWidth">The textwrap position for the tooltip text.</param>
	/// <param name="text">The text of the tooltip.</param>
	public static void DrawWrappedTooltip(float maxWidth, string text) {
		ImGui.BeginTooltip();
		ImGui.PushTextWrapPos(maxWidth);
		ImGui.Text(text);
		ImGui.PopTextWrapPos();
		ImGui.EndTooltip();
	}
}
