namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Typical range example: 0 to 10 PPM. Typical value example: 0.191 PPM
/// <summary>
[Cluster(0x0421, "Copper measurement")]
public static class ZclCopperMeasurement
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclCopperMeasurement));

    #region Copper Information
    public static ReportAttribute MeasuredValue { get; } = zcl.Report(0x0000, "Measured Value", r => r.ReadSingle());
    public static ReportAttribute MinMeasuredValue { get; } = zcl.Report(0x0001, "Min Measured Value", r => r.ReadSingle());
    public static ReportAttribute MaxMeasuredValue { get; } = zcl.Report(0x0002, "Max Measured Value", r => r.ReadSingle());
    public static ReportAttribute Tolerance { get; } = zcl.Report(0x0003, "Tolerance", r => r.ReadSingle());
    #endregion 

}
