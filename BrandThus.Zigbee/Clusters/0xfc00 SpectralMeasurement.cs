namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Dresden Elektronik Specific clusters.
/// <summary>
[Cluster(0xfc00, "Spectral Measurement")]
public static class ZclSpectralMeasurement
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclSpectralMeasurement));

    public static ReportAttribute On { get; } = zcl.Report(0x0000, "On", r => r.ReadByte());
    public static ReportAttribute XValue { get; } = zcl.Report(0x0001, "X-Value", r => r.ReadUInt16());
    public static ReportAttribute YValue { get; } = zcl.Report(0x0002, "Y-Value", r => r.ReadUInt16());
    public static ReportAttribute ZValue { get; } = zcl.Report(0x0003, "Z-Value", r => r.ReadUInt16());
}
