namespace BrandThus.Zigbee.Types;public struct Int40 : IZigbeeType{	byte[] IZigbeeType.data { get; set; }	public static implicit operator Int40(int value)	{		return IZigbeeType.Create<Int40>(value, 5);	}	public static implicit operator Int40(long value)	{		return IZigbeeType.Create<Int40>(value, 5);	}}