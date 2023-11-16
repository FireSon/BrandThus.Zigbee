namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Attributes and commands for commissioning and managing a ZigBee device.
/// <summary>
[Cluster(0x0015, "Commissioning")]
public static class ZclCommissioning
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclCommissioning));

    #region Startup Parameters I
    public static ReportAttribute ShortAddress { get; } = zcl.Report(0x0000, "Short Address", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute ExtendedPANID { get; } = zcl.Report(0x0001, "Extended PAN ID", ZigbeeType.Uid, r => r.ReadInt64());
    public static ReportAttribute PANID { get; } = zcl.Report(0x0002, "PAN ID", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute ChannelMask { get; } = zcl.Report(0x0003, "Channel Mask", ZigbeeType.Bmp32, r => r.ReadInt32());
    public static ReportAttribute ProtocolVersion { get; } = zcl.Report(0x0004, "Protocol Version", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute StackProfile { get; } = zcl.Report(0x0005, "Stack Profile", ZigbeeType.U8, r => r.ReadByte());
    public enum StartupControlEnum
    {
        PartOfTheNetwork = 0x00,
        FormANetwork = 0x01,
        RejoinTheNetwork = 0x02,
        StartFromScratch = 0x03,
    }

    public static ReportAttribute StartupControl { get; } = zcl.Report(0x0006, "Startup Control", ZigbeeType.Enum8, r => (StartupControlEnum)r.ReadByte());
    #endregion 

    #region Startup Parameters II
    public static ReportAttribute TrustCenterAddress { get; } = zcl.Report(0x0010, "Trust Center Address", ZigbeeType.Uid, r => r.ReadInt64());
    public static ReportAttribute TrustCenterMasterKey { get; } = zcl.Report(0x0011, "Trust Center Master Key", ZigbeeType.Seckey, r => r.ReadString());
    public static ReportAttribute NetworkKey { get; } = zcl.Report(0x0012, "Network Key", ZigbeeType.Seckey, r => r.ReadString());
    public static ReportAttribute UseInsecureJoin { get; } = zcl.Report(0x0013, "Use Insecure Join", ZigbeeType.Bool, r => r.ReadBool());
    public static ReportAttribute PreconfiguredLinkKey { get; } = zcl.Report(0x0014, "Preconfigured Link Key", ZigbeeType.Seckey, r => r.ReadString());
    public static ReportAttribute NetworkKeySeqNum { get; } = zcl.Report(0x0015, "Network Key Seq Num", ZigbeeType.U8, r => r.ReadByte());
    public enum NetworkKeyTypeEnum
    {
        Standard = 0x01,
        HighSecurity = 0x05,
    }

    public static ReportAttribute NetworkKeyType { get; } = zcl.Report(0x0016, "Network Key Type", ZigbeeType.Enum8, r => (NetworkKeyTypeEnum)r.ReadByte());
    public static ReportAttribute NetworkManagerAddress { get; } = zcl.Report(0x0017, "Network Manager Address", ZigbeeType.U16, r => r.ReadUInt16());
    #endregion 

    #region Join Parameters
    public static ReportAttribute ScanAttemps { get; } = zcl.Report(0x0020, "Scan Attemps", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute TimeBetweenScans { get; } = zcl.Report(0x0021, "Time Between Scans", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute RejoinInterval { get; } = zcl.Report(0x0022, "Rejoin Interval", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute MaxRejoinInterval { get; } = zcl.Report(0x0023, "Max Rejoin Interval", ZigbeeType.U16, r => r.ReadUInt16());
    #endregion 

    #region End Device Parameters
    public static ReportAttribute IndirectPollRate { get; } = zcl.Report(0x0030, "Indirect Poll Rate", ZigbeeType.U16, r => r.ReadUInt16());
    #endregion 

    #region Concentrator Parameters
    public static ReportAttribute ConcentratorFlag { get; } = zcl.Report(0x0040, "Concentrator Flag", ZigbeeType.Bool, r => r.ReadBool());
    public static ReportAttribute ConcentratorRadius { get; } = zcl.Report(0x0041, "Concentrator Radius", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute ConcentratorDiscoveryTime { get; } = zcl.Report(0x0042, "Concentrator Discovery Time", ZigbeeType.U8, r => r.ReadByte());
    #endregion 

    #region DE Setup Parameters
    public static ReportAttribute MACAddress { get; } = zcl.Report(0xde01, "MAC Address", ZigbeeType.Uid, r => r.ReadInt64());
    #endregion 

    /// <summary>
    /// The Restart Device command is used to optionally install a set of startup parameters in a device and run the startup
    /// procedure so as to put the new values into effect. The new values may take effect immediately or after an optional
    /// delay with optional jitter. The server will send a Restart Device Response command back to the client device before
    /// executing the procedure or starting the countdown timer required to time the delay.
    /// <summary>
    public static Task RestartDevice(this ZigbeeNode node, byte options, byte delay, byte jitter) => node.Zcl(zcl, 00, w => w+ options+ delay+ jitter);
    /// <summary>
    /// The Save Startup Parameters Request command allows for the current attribute set to be stored under a given index.
    /// <summary>
    public static Task SaveStartupParameters(this ZigbeeNode node, byte options, byte index) => node.Zcl(zcl, 01, w => w+ options+ index);
    /// <summary>
    /// This command allows a saved startup parameters attribute set to be restored to current status overwriting whatever
    /// was there previously.
    /// <summary>
    public static Task RestoreStartupParameters(this ZigbeeNode node, byte options, byte index) => node.Zcl(zcl, 02, w => w+ options+ index);
    /// <summary>
    /// This command allows current startup parameters attribute set and one or all of the saved attribute sets to be
    /// set to default values. There is also an option for erasing the index under which an attribute set is saved thereby
    /// freeing up storage capacity.
    /// <summary>
    public static Task ResetStartupParameters(this ZigbeeNode node, byte options, byte index) => node.Zcl(zcl, 03, w => w+ options+ index);

    /// <summary>
    /// On receipt of this command the client is made aware that the server has received the corresponding request and
    /// is informed of the status of the request.
    /// <summary>
    public static Task RestartDeviceResponse(this ZigbeeNode node, byte status) => node.Zcl(zcl, 00, w => w+ status);
    /// <summary>
    /// On receipt of this command the client is made aware that the server has received the corresponding request and
    /// is informed of the status of the request.
    /// <summary>
    public static Task SaveStartupParametersResponse(this ZigbeeNode node, byte status) => node.Zcl(zcl, 01, w => w+ status);
    /// <summary>
    /// On receipt of this command the client is made aware that the server has received the corresponding request and
    /// is informed of the status of the request.
    /// <summary>
    public static Task RestoreStartupParametersResponse(this ZigbeeNode node, byte status) => node.Zcl(zcl, 02, w => w+ status);
    /// <summary>
    /// On receipt of this command the client is made aware that the server has received the corresponding request and
    /// is informed of the status of the request.
    /// <summary>
    public static Task ResetStartupParametersResponse(this ZigbeeNode node, byte status) => node.Zcl(zcl, 03, w => w+ status);
}
