namespace BrandThus.Zigbee.Types;

public struct Bmp16 : IZigbeeType
{
    byte[] IZigbeeType.data { get; set; }
    public static implicit operator Bmp16(uint value)
    {
        return IZigbeeType.Create<Bmp16>(value, 3);
    }
}
