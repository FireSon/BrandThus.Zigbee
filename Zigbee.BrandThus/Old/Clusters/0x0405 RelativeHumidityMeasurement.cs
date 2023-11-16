namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Percentage of water in the air
/// <summary>
[Cluster(0x0405, "Relative humidity measurement")]
public static class ZclRelativeHumidityMeasurement
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclRelativeHumidityMeasurement));

    #region Relative Humidity Measurement Information
    public static ReportAttribute MeasuredValue { get; } = zcl.Report(0x0000, "Measured Value", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute MinMeasuredValue { get; } = zcl.Report(0x0001, "Min Measured Value", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute MaxMeasuredValue { get; } = zcl.Report(0x0002, "Max Measured Value", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute Tolerance { get; } = zcl.Report(0x0003, "Tolerance", ZigbeeType.U16, r => r.ReadUInt16());
    #endregion 

}
