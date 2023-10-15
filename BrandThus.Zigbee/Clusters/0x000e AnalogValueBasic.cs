namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// An interface for setting an analog value, typically used as a control system parameter, and accessing various
/// characteristics of that value.
/// <summary>
[Cluster(0x000e, "Analog Value (Basic)")]
public static class ZclAnalogValueBasic
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclAnalogValueBasic));

    public static ReportAttribute Description { get; } = zcl.Report(0x001c, "Description", r => r.ReadString());
    public static ReportAttribute OutOfService { get; } = zcl.Report(0x0051, "Out of service", r => r.ReadBool());
    public static ReportAttribute PresentValue { get; } = zcl.Report(0x0055, "Present value", r => r.ReadSingle());
    public static ReportAttribute Reliability { get; } = zcl.Report(0x0067, "Reliability", r => r.ReadByte());
    public static ReportAttribute RelinquishDefault { get; } = zcl.Report(0x0068, "Relinquish Default", r => r.ReadSingle());
    public static ReportAttribute StatusFlags { get; } = zcl.Report(0x006f, "Status flags", r => r.ReadByte());
    public static ReportAttribute EngineeringUnits { get; } = zcl.Report(0x0075, "Engineering Units", r => r.ReadInt16());
    public static ReportAttribute ApplicationType { get; } = zcl.Report(0x0100, "Application Type", r => r.ReadUInt32());
}
