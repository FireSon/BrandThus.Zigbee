namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Attributes and commands that provide an interface to meter identification.
/// <summary>
[Cluster(0x0b01, "Meter Identification")]
public static class ZclMeterIdentification
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclMeterIdentification));

    public static ReportAttribute CompanyName { get; } = zcl.Report(0x0000, "CompanyName", ZigbeeType.Cstring, r => r.ReadString());
    public static ReportAttribute MeterTypeID { get; } = zcl.Report(0x0001, "MeterTypeID", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute DataQualityID { get; } = zcl.Report(0x0004, "DataQualityID", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute CustomerName { get; } = zcl.Report(0x0005, "CustomerName", ZigbeeType.Cstring, r => r.ReadString());
    public static ReportAttribute Model { get; } = zcl.Report(0x0006, "Model", ZigbeeType.Ostring, r => r.ReadString());
    public static ReportAttribute PartNumber { get; } = zcl.Report(0x0007, "PartNumber", ZigbeeType.Ostring, r => r.ReadString());
    public static ReportAttribute ProductRevision { get; } = zcl.Report(0x0008, "ProductRevision", ZigbeeType.Ostring, r => r.ReadString());
    public static ReportAttribute SoftwareRevision { get; } = zcl.Report(0x000a, "SoftwareRevision", ZigbeeType.Ostring, r => r.ReadString());
    public static ReportAttribute UtilityName { get; } = zcl.Report(0x000b, "UtilityName", ZigbeeType.Cstring, r => r.ReadString());
    public static ReportAttribute POD { get; } = zcl.Report(0x000c, "POD", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute AvailablePower { get; } = zcl.Report(0x000d, "AvailablePower", ZigbeeType.S24, r => r.ReadInt24());
    public static ReportAttribute PowerThreshold { get; } = zcl.Report(0x000e, "PowerThreshold", ZigbeeType.S24, r => r.ReadInt24());

}
