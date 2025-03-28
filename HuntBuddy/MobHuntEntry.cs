﻿namespace HuntBuddy;

public class MobHuntEntry {
	public string? Name { get; init; }

	public string? TerritoryName { get; init; }

	public string? ExpansionName { get; init; }

	public uint ExpansionId { get; init; }

	public uint MapId { get; init; }

	public uint TerritoryType { get; init; }

	public uint MobHuntId { get; init; }

	public bool IsEliteMark { get; init; }

	public byte BillNumber { get; set; }

	public byte MobIndex { get; set; }

	public uint NeededKills { get; set; }

	public uint Icon { get; init; }
}
