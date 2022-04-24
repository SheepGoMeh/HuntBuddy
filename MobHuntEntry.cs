using System;
using ImGuiScene;

namespace HuntBuddy
{
	public class MobHuntEntry : IDisposable
	{
		public string? Name { get; init; }
		public string? TerritoryName { get; init; }
		public string? ExpansionName { get; init; }
		public uint ExpansionId { get; init; }
		public uint MapId { get; init; }
		public uint TerritoryType { get; init; }
		public uint MobHuntId { get; init; }
		public bool IsEliteMark { get; init; }
		public uint CurrentKillsOffset { get; init; }
		public uint NeededKills { get; set; }
		public TextureWrap Icon { get; init; } = null!;

		public void Dispose()
		{
			Icon.Dispose();
		}
	}
}