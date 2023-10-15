namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Cloudiness of particles in water where an average person would notice a 5 or higher. Typical range example: 0
/// to 10. Typical value example: 0.18
/// <summary>
[Cluster(0x0420, "Turbidity measurement")]
public static class ZclTurbidityMeasurement
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclTurbidityMeasurement));

    #region Turbidity Information
    public static ReportAttribute MeasuredValue { get; } = zcl.Report(0x0000, "Measured Value", r => r.ReadSingle());
    public static ReportAttribute MinMeasuredValue { get; } = zcl.Report(0x0001, "Min Measured Value", r => r.ReadSingle());
    public static ReportAttribute MaxMeasuredValue { get; } = zcl.Report(0x0002, "Max Measured Value", r => r.ReadSingle());
    public static ReportAttribute Tolerance { get; } = zcl.Report(0x0003, "Tolerance", r => r.ReadSingle());
    #endregion 

}
