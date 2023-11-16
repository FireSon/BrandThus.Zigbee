namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Hue-specific cluster for Hue Entertainment.
/// <summary>
[Cluster(0xfc01, "Hue Entertainment")]
public static class ZclHueEntertainment
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclHueEntertainment));

    public static ReportAttribute Capabilities { get; } = zcl.Report(0x0000, "Capabilities", ZigbeeType.Bmp8, r => r.ReadByte());
    public static ReportAttribute Segments { get; } = zcl.Report(0x0002, "Segments", ZigbeeType.U8, r => r.ReadByte());
}
