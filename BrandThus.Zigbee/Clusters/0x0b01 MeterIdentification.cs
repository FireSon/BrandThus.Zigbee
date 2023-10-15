namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Attributes and commands that provide an interface to meter identification.
/// <summary>
[Cluster(0x0b01, "Meter Identification")]
public static class ZclMeterIdentification
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclMeterIdentification));

    public static ReportAttribute CompanyName { get; } = zcl.Report(0x0000, "CompanyName", r => r.ReadString());
    public static ReportAttribute MeterTypeID { get; } = zcl.Report(0x0001, "MeterTypeID", r => r.ReadUInt16());
    public static ReportAttribute DataQualityID { get; } = zcl.Report(0x0004, "DataQualityID", r => r.ReadUInt16());
    public static ReportAttribute CustomerName { get; } = zcl.Report(0x0005, "CustomerName", r => r.ReadString());
    public static ReportAttribute Model { get; } = zcl.Report(0x0006, "Model", r => r.ReadString());
    public static ReportAttribute PartNumber { get; } = zcl.Report(0x0007, "PartNumber", r => r.ReadString());
    public static ReportAttribute ProductRevision { get; } = zcl.Report(0x0008, "ProductRevision", r => r.ReadString());
    public static ReportAttribute SoftwareRevision { get; } = zcl.Report(0x000a, "SoftwareRevision", r => r.ReadString());
    public static ReportAttribute UtilityName { get; } = zcl.Report(0x000b, "UtilityName", r => r.ReadString());
    public static ReportAttribute POD { get; } = zcl.Report(0x000c, "POD", r => r.ReadUInt16());
    public static ReportAttribute AvailablePower { get; } = zcl.Report(0x000d, "AvailablePower", r => r.ReadByte());
    public static ReportAttribute PowerThreshold { get; } = zcl.Report(0x000e, "PowerThreshold", r => r.ReadByte());

}
