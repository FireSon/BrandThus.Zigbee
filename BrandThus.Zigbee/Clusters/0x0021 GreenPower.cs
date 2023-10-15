namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Attributes and commands.
/// <summary>
[Cluster(0x0021, "Green Power")]
public static class ZclGreenPower
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclGreenPower));

    public static ReportAttribute MaxSinkTableEntries { get; } = zcl.Report(0x0000, "Max Sink Table Entries", r => r.ReadByte());
    public static ReportAttribute SinkTable { get; } = zcl.Report(0x0001, "Sink Table", r => r.ReadByte());
    public static ReportAttribute CommunicationMode { get; } = zcl.Report(0x0002, "Communication Mode", r => r.ReadByte());
    public static ReportAttribute CommissioningExitMode { get; } = zcl.Report(0x0003, "Commissioning Exit Mode", r => r.ReadByte());
    public static ReportAttribute CommissioningWindow { get; } = zcl.Report(0x0004, "Commissioning Window", r => r.ReadUInt16());
    public static ReportAttribute SecurityLevel { get; } = zcl.Report(0x0005, "Security Level", r => r.ReadByte());
    public static ReportAttribute Functionality { get; } = zcl.Report(0x0006, "Functionality", r => r.ReadByte());
    public static ReportAttribute ActiveFunctionality { get; } = zcl.Report(0x0007, "Active Functionality", r => r.ReadByte());
    public static ReportAttribute SharedSecurityKeyType { get; } = zcl.Report(0x0020, "Shared Security Key Type", r => r.ReadByte());
    public static ReportAttribute SharedSecurityKey { get; } = zcl.Report(0x0021, "Shared Security Key", r => r.ReadString());
    public static ReportAttribute GPLinkKey { get; } = zcl.Report(0x0022, "GP Link Key", r => r.ReadString());
}
