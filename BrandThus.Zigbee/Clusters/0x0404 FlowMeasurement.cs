namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// The server cluster provides an interface to flow measurement measurement functionality, including configuration
/// and provision of notifications of flow measurements.
/// <summary>
[Cluster(0x0404, "Flow measurement")]
public static class ZclFlowMeasurement
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclFlowMeasurement));

    #region Flow Measurement Information
    public static ReportAttribute MeasuredValue { get; } = zcl.Report(0x0000, "Measured Value", r => r.ReadUInt16());
    public static ReportAttribute MinMeasuredValue { get; } = zcl.Report(0x0001, "Min Measured Value", r => r.ReadUInt16());
    public static ReportAttribute MaxMeasuredValue { get; } = zcl.Report(0x0002, "Max Measured Value", r => r.ReadUInt16());
    public static ReportAttribute Tolerance { get; } = zcl.Report(0x0003, "Tolerance", r => r.ReadUInt16());
    #endregion 

}
