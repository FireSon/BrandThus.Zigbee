namespace BrandThus.Zigbee.Types;
    byte[] IZigbeeType.data { get; set; }
    public static implicit operator Bmp16(uint value)
    {
        return IZigbeeType.Create<Bmp16>(value, 3);
    }