namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Typical range example: 0 to 1000 PPB. Typical value example: 31 PPB
/// <summary>
[Cluster(0x0423, "Manganese measurement")]
public static class ZclManganeseMeasurement
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclManganeseMeasurement));

    #region Manganese Information
    public static ReportAttribute MeasuredValue { get; } = zcl.Report(0x0000, "Measured Value", r => r.ReadSingle());
    public static ReportAttribute MinMeasuredValue { get; } = zcl.Report(0x0001, "Min Measured Value", r => r.ReadSingle());
    public static ReportAttribute MaxMeasuredValue { get; } = zcl.Report(0x0002, "Max Measured Value", r => r.ReadSingle());
    public static ReportAttribute Tolerance { get; } = zcl.Report(0x0003, "Tolerance", r => r.ReadSingle());
    #endregion 

}
