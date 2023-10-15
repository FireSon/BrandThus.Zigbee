namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Provides an interface to pH measurement functionality
/// <summary>
[Cluster(0x0409, "pH Measurement")]
public static class ZclpHMeasurement
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclpHMeasurement));

    #region pH measurement Information
    public static ReportAttribute MeasuredValue { get; } = zcl.Report(0x0000, "Measured Value", r => r.ReadUInt16());
    public static ReportAttribute MinMeasuredValue { get; } = zcl.Report(0x0001, "Min Measured Value", r => r.ReadUInt16());
    public static ReportAttribute MaxMeasuredValue { get; } = zcl.Report(0x0002, "Max Measured Value", r => r.ReadUInt16());
    public static ReportAttribute Tolerance { get; } = zcl.Report(0x0003, "Tolerance", r => r.ReadUInt16());
    #endregion 

}