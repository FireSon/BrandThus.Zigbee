namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Attributes and commands for setting devices light color. The color is specified in the RGB range from 0 - 255.
/// <summary>
[Cluster(0xde06, "RGB Color")]
public static class ZclRGBColor
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclRGBColor));

    public static ReportAttribute CurrentColorSet { get; } = zcl.Report(0000, "CurrentColorSet", ZigbeeType.U32, r => r.ReadUInt32());
    public static ReportAttribute ColorSetCount { get; } = zcl.Report(0001, "ColorSetCount", ZigbeeType.U8, r => r.ReadByte());
    /// <summary>
    /// On receipt of this command, the color of the light shall be changed and the current index updatet.
    /// <summary>
    public static Task SetColor(this ZigbeeNode node, byte red, byte green, byte blue, byte setIndex, byte options) => node.Zcl(zcl, 00, w => w+ red+ green+ blue+ setIndex+ options);
}
