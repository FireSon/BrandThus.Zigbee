namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Provides an interface to Electrical Conductivity measurement functionality
/// <summary>
[Cluster(0x040A, "Electrical Conductivity")]
public static class ZclElectricalConductivity
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclElectricalConductivity));

    #region Electrical Conductivity Information
    /// <summary>
    /// "Electrical Conductivity in mS/m. The maximum resolution this format allows is 0.1"
    /// <summary>
    public static ReportAttribute MeasuredValue { get; } = zcl.Report(0x0000, "Measured Value", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute MinMeasuredValue { get; } = zcl.Report(0x0001, "Min Measured Value", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute MaxMeasuredValue { get; } = zcl.Report(0x0002, "Max Measured Value", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute Tolerance { get; } = zcl.Report(0x0003, "Tolerance", ZigbeeType.U16, r => r.ReadUInt16());
    #endregion 

}
