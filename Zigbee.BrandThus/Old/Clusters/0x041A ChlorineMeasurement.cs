namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Typical range example: 0.1 to 2.4 PPM. Typical value example: 1.28 PPM
/// <summary>
[Cluster(0x041A, "Chlorine measurement")]
public static class ZclChlorineMeasurement
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclChlorineMeasurement));

    #region Chlorine Information
    public static ReportAttribute MeasuredValue { get; } = zcl.Report(0x0000, "Measured Value", ZigbeeType.Float, r => r.ReadSingle());
    public static ReportAttribute MinMeasuredValue { get; } = zcl.Report(0x0001, "Min Measured Value", ZigbeeType.Float, r => r.ReadSingle());
    public static ReportAttribute MaxMeasuredValue { get; } = zcl.Report(0x0002, "Max Measured Value", ZigbeeType.Float, r => r.ReadSingle());
    public static ReportAttribute Tolerance { get; } = zcl.Report(0x0003, "Tolerance", ZigbeeType.Float, r => r.ReadSingle());
    #endregion 

}
