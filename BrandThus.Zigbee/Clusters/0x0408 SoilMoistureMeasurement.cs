namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Percentage of water in the soil
/// <summary>
[Cluster(0x0408, "Soil Moisture measurement")]
public static class ZclSoilMoistureMeasurement
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclSoilMoistureMeasurement));

    #region Soil Moisture Measurement Information
    public static ReportAttribute MeasuredValue { get; } = zcl.Report(0x0000, "Measured Value", r => r.ReadUInt16());
    public static ReportAttribute MinMeasuredValue { get; } = zcl.Report(0x0001, "Min Measured Value", r => r.ReadUInt16());
    public static ReportAttribute MaxMeasuredValue { get; } = zcl.Report(0x0002, "Max Measured Value", r => r.ReadUInt16());
    public static ReportAttribute Tolerance { get; } = zcl.Report(0x0003, "Tolerance", r => r.ReadUInt16());
    #endregion 

}
