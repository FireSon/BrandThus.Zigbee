namespace BrandThus.Zigbee.Types;public struct UInt40 : IZigbeeType{	byte[] IZigbeeType.data { get; set; }	public static implicit operator UInt40(uint value)	{		return IZigbeeType.Create<UInt40>(value, 5);	}	public static implicit operator UInt40(ulong value)	{		return IZigbeeType.Create<UInt40>(value, 5);	}}