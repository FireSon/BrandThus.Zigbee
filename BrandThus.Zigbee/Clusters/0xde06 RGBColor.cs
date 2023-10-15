namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Attributes and commands for setting devices light color. The color is specified in the RGB range from 0 - 255.
/// <summary>
[Cluster(0xde06, "RGB Color")]
public static class ZclRGBColor
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclRGBColor));

    public static ReportAttribute CurrentColorSet { get; } = zcl.Report(0000, "CurrentColorSet", r => r.ReadUInt32());
    public static ReportAttribute ColorSetCount { get; } = zcl.Report(0001, "ColorSetCount", r => r.ReadByte());
    public static Task SetColor => Task.CompletedTask;
}
