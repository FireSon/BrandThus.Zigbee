namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// The Multistate Output (Basic) cluster provides an interface for setting the value of an output that can take one
/// of a number of discrete values, and accessing characteristics of that value.
/// <summary>
[Cluster(0x0013, "Multistate Output (Basic)")]
public static class ZclMultistateOutputBasic
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclMultistateOutputBasic));

    public static ReportAttribute Description { get; } = zcl.Report(0x001c, "Description", r => r.ReadString());
    public static ReportAttribute NumberOfStates { get; } = zcl.Report(0x004a, "Number of states", r => r.ReadUInt16());
    public static ReportAttribute OutOfService { get; } = zcl.Report(0x0051, "Out of service", r => r.ReadBool());
    public static ReportAttribute PresentValue { get; } = zcl.Report(0x0055, "Present value", r => r.ReadUInt16());
    public static ReportAttribute Reliability { get; } = zcl.Report(0x0067, "Reliability", r => r.ReadByte());
    public static ReportAttribute RelinquishDefault { get; } = zcl.Report(0x0068, "Relinquish Default", r => r.ReadUInt16());
    public static ReportAttribute StatusFlags { get; } = zcl.Report(0x006f, "Status flags", r => r.ReadByte());
    public static ReportAttribute ApplicationType { get; } = zcl.Report(0x0100, "Application Type", r => r.ReadUInt32());
    public static ReportAttribute Xiaomi0xf000 { get; } = zcl.Report(0xf000, "Xiaomi 0xf000", r => r.ReadUInt32());
}
