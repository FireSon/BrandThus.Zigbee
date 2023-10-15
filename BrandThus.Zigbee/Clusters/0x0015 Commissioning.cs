namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Attributes and commands for commissioning and managing a ZigBee device.
/// <summary>
[Cluster(0x0015, "Commissioning")]
public static class ZclCommissioning
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclCommissioning));

    #region Startup Parameters I
    public static ReportAttribute ShortAddress { get; } = zcl.Report(0x0000, "Short Address", r => r.ReadUInt16());
    public static ReportAttribute ExtendedPANID { get; } = zcl.Report(0x0001, "Extended PAN ID", r => r.ReadInt64());
    public static ReportAttribute PANID { get; } = zcl.Report(0x0002, "PAN ID", r => r.ReadUInt16());
    public static ReportAttribute ChannelMask { get; } = zcl.Report(0x0003, "Channel Mask", r => r.ReadInt32());
    public static ReportAttribute ProtocolVersion { get; } = zcl.Report(0x0004, "Protocol Version", r => r.ReadByte());
    public static ReportAttribute StackProfile { get; } = zcl.Report(0x0005, "Stack Profile", r => r.ReadByte());
    public static ReportAttribute StartupControl { get; } = zcl.Report(0x0006, "Startup Control", r => r.ReadByte());
    #endregion 

    #region Startup Parameters II
    public static ReportAttribute TrustCenterAddress { get; } = zcl.Report(0x0010, "Trust Center Address", r => r.ReadInt64());
    public static ReportAttribute TrustCenterMasterKey { get; } = zcl.Report(0x0011, "Trust Center Master Key", r => r.ReadString());
    public static ReportAttribute NetworkKey { get; } = zcl.Report(0x0012, "Network Key", r => r.ReadString());
    public static ReportAttribute UseInsecureJoin { get; } = zcl.Report(0x0013, "Use Insecure Join", r => r.ReadBool());
    public static ReportAttribute PreconfiguredLinkKey { get; } = zcl.Report(0x0014, "Preconfigured Link Key", r => r.ReadString());
    public static ReportAttribute NetworkKeySeqNum { get; } = zcl.Report(0x0015, "Network Key Seq Num", r => r.ReadByte());
    public static ReportAttribute NetworkKeyType { get; } = zcl.Report(0x0016, "Network Key Type", r => r.ReadByte());
    public static ReportAttribute NetworkManagerAddress { get; } = zcl.Report(0x0017, "Network Manager Address", r => r.ReadUInt16());
    #endregion 

    #region Join Parameters
    public static ReportAttribute ScanAttemps { get; } = zcl.Report(0x0020, "Scan Attemps", r => r.ReadByte());
    public static ReportAttribute TimeBetweenScans { get; } = zcl.Report(0x0021, "Time Between Scans", r => r.ReadUInt16());
    public static ReportAttribute RejoinInterval { get; } = zcl.Report(0x0022, "Rejoin Interval", r => r.ReadUInt16());
    public static ReportAttribute MaxRejoinInterval { get; } = zcl.Report(0x0023, "Max Rejoin Interval", r => r.ReadUInt16());
    #endregion 

    #region End Device Parameters
    public static ReportAttribute IndirectPollRate { get; } = zcl.Report(0x0030, "Indirect Poll Rate", r => r.ReadUInt16());
    #endregion 

    #region Concentrator Parameters
    public static ReportAttribute ConcentratorFlag { get; } = zcl.Report(0x0040, "Concentrator Flag", r => r.ReadBool());
    public static ReportAttribute ConcentratorRadius { get; } = zcl.Report(0x0041, "Concentrator Radius", r => r.ReadByte());
    public static ReportAttribute ConcentratorDiscoveryTime { get; } = zcl.Report(0x0042, "Concentrator Discovery Time", r => r.ReadByte());
    #endregion 

    #region DE Setup Parameters
    public static ReportAttribute MACAddress { get; } = zcl.Report(0xde01, "MAC Address", r => r.ReadInt64());
    #endregion 

    public static Task RestartDevice => Task.CompletedTask;
    public static Task SaveStartupParameters => Task.CompletedTask;
    public static Task RestoreStartupParameters => Task.CompletedTask;
    public static Task ResetStartupParameters => Task.CompletedTask;

    public static Task RestartDeviceResponse => Task.CompletedTask;
    public static Task SaveStartupParametersResponse => Task.CompletedTask;
    public static Task RestoreStartupParametersResponse => Task.CompletedTask;
    public static Task ResetStartupParametersResponse => Task.CompletedTask;
}
