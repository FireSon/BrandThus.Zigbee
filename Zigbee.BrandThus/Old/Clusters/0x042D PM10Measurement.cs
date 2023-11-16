namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// PM10 concentration measurement
/// <summary>
[Cluster(0x042D, "PM10 Measurement")]
public static class ZclPM10Measurement
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclPM10Measurement));

    #region PM10 Information
    public static ReportAttribute MeasuredValue { get; } = zcl.Report(0x0000, "Measured Value", ZigbeeType.Float, r => r.ReadSingle());
    public static ReportAttribute MinMeasuredValue { get; } = zcl.Report(0x0001, "Min Measured Value", ZigbeeType.Float, r => r.ReadSingle());
    public static ReportAttribute MaxMeasuredValue { get; } = zcl.Report(0x0002, "Max Measured Value", ZigbeeType.Float, r => r.ReadSingle());
    public static ReportAttribute Tolerance { get; } = zcl.Report(0x0003, "Tolerance", ZigbeeType.Float, r => r.ReadSingle());
    #endregion 

}
