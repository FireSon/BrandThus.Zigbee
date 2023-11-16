namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Provides an interface to Wind Speed Measurement functionality
/// <summary>
[Cluster(0x040B, "Wind Speed Measurement")]
public static class ZclWindSpeedMeasurement
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclWindSpeedMeasurement));

    #region Wind Speed Measurement Information
    /// <summary>
    /// "100 x Wind Speed in m/s. The maximum resolution this format allows is 0.01"
    /// <summary>
    public static ReportAttribute MeasuredValue { get; } = zcl.Report(0x0000, "Measured Value", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute MinMeasuredValue { get; } = zcl.Report(0x0001, "Min Measured Value", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute MaxMeasuredValue { get; } = zcl.Report(0x0002, "Max Measured Value", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute Tolerance { get; } = zcl.Report(0x0003, "Tolerance", ZigbeeType.U16, r => r.ReadUInt16());
    #endregion 

}
