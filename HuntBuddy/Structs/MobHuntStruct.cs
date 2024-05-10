using System;
using System.Runtime.InteropServices;

namespace HuntBuddy.Structs;

public enum BillEnum: uint {
	ArrRank1,
	HwRank1,
	HwRank2,
	HwRank3,
	ArrElite,
	HwElite,
	SbRank1,
	SbRank2,
	SbRank3,
	SbElite,
	ShbRank1,
	ShbRank2,
	ShbRank3,
	ShbElite,
	EwRank1,
	EwRank2,
	EwRank3,
	EwElite,
}

[Flags]
public enum ObtainedBillEnum: uint {
	ArrRank1 = 1,
	HwRank1 = 1 << 1,
	HwRank2 = 1 << 2,
	HwRank3 = 1 << 3,
	ArrElite = 1 << 4,
	HwElite = 1 << 5,
	SbRank1 = 1 << 6,
	SbRank2 = 1 << 7,
	SbRank3 = 1 << 8,
	SbElite = 1 << 9,
	ShbRank1 = 1 << 10,
	ShbRank2 = 1 << 11,
	ShbRank3 = 1 << 12,
	ShbElite = 1 << 13,
	EwRank1 = 1 << 14,
	EwRank2 = 1 << 15,
	EwRank3 = 1 << 16,
	EwElite = 1 << 17,
}

// Signature to get struct address
// D1 48 8D 0D ? ? ? ? 48 83 C4 20 5F E9 ? ? ? ?
[StructLayout(LayoutKind.Explicit, Size = 0x198)]
public unsafe struct MobHuntStruct {
	[FieldOffset(0x1A)] public fixed byte BillOffset[18];
	[FieldOffset(0x2C)] public fixed int CurrentKills[5 * 18];
	[FieldOffset(0x194)] public readonly ObtainedBillEnum ObtainedBillEnumFlags;
}
