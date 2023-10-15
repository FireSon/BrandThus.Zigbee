namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Percentage of water on the leaves of plants
/// <summary>
[Cluster(0x0407, "Leaf Wetness measurement")]
public static class ZclLeafWetnessMeasurement
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclLeafWetnessMeasurement));

    #region Leaf Wetness Measurement Information
    public static ReportAttribute MeasuredValue { get; } = zcl.Report(0x0000, "Measured Value", r => r.ReadUInt16());
    public static ReportAttribute MinMeasuredValue { get; } = zcl.Report(0x0001, "Min Measured Value", r => r.ReadUInt16());
    public static ReportAttribute MaxMeasuredValue { get; } = zcl.Report(0x0002, "Max Measured Value", r => r.ReadUInt16());
    public static ReportAttribute Tolerance { get; } = zcl.Report(0x0003, "Tolerance", r => r.ReadUInt16());
    #endregion 

}
