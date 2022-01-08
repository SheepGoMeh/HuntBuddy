using System;
using System.Runtime.InteropServices;

namespace HuntBuddy.Structs
{
	// Signature to get struct address
	// D1 48 8D 0D ? ? ? ? 48 83 C4 20 5F E9 ? ? ? ?
	[StructLayout(LayoutKind.Explicit, Size = 0x198)]
	public unsafe struct MobHuntStruct
	{
		[FieldOffset(0x1A)] public fixed byte BillOffset[18];
		[FieldOffset(0x2C)] public fixed int CurrentKills[5 * 18];
	}
}