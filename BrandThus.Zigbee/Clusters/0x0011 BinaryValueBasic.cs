namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// The Binary Value (Basic) cluster provides an interface for setting a binary value, typically used as a control
/// system parameter, and accessing various characteristics of that value.
/// <summary>
[Cluster(0x0011, "Binary Value (Basic)")]
public static class ZclBinaryValueBasic
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclBinaryValueBasic));

    public static ReportAttribute ActiveText { get; } = zcl.Report(0x0004, "Active Text", r => r.ReadString());
    public static ReportAttribute Description { get; } = zcl.Report(0x001c, "Description", r => r.ReadString());
    public static ReportAttribute InactiveText { get; } = zcl.Report(0x002e, "Inactive Text", r => r.ReadString());
    public static ReportAttribute MinOffTime { get; } = zcl.Report(0x0042, "Min Off Time", r => r.ReadUInt32());
    public static ReportAttribute MinOnTime { get; } = zcl.Report(0x0043, "Min On Time", r => r.ReadUInt32());
    public static ReportAttribute OutOfService { get; } = zcl.Report(0x0051, "Out of service", r => r.ReadBool());
    public static ReportAttribute PresentValue { get; } = zcl.Report(0x0055, "Present value", r => r.ReadBool());
    public static ReportAttribute Reliability { get; } = zcl.Report(0x0067, "Reliability", r => r.ReadByte());
    public static ReportAttribute RelinquishDefault { get; } = zcl.Report(0x0068, "Relinquish Default", r => r.ReadBool());
    public static ReportAttribute StatusFlags { get; } = zcl.Report(0x006f, "Status flags", r => r.ReadByte());
    public static ReportAttribute ApplicationType { get; } = zcl.Report(0x0100, "Application Type", r => r.ReadUInt32());
}
