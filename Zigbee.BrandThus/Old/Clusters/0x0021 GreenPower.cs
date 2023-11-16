namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Attributes and commands.
/// <summary>
[Cluster(0x0021, "Green Power")]
public static class ZclGreenPower
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclGreenPower));

    /// <summary>
    /// Maximum number of Sink Table entries supported by this device.
    /// <summary>
    public static ReportAttribute MaxSinkTableEntries { get; } = zcl.Report(0x0000, "Max Sink Table Entries", ZigbeeType.U8, r => r.ReadByte());
    /// <summary>
    /// Sink Table, holding information about local bindings between a particular GPD and target‘s local endpoints.
    /// <summary>
    public static ReportAttribute SinkTable { get; } = zcl.Report(0x0001, "Sink Table", ZigbeeType.Lostring, r => r.ReadString());
    /// <summary>
    /// Default communication mode requested by this sink.
    /// <summary>
    public static ReportAttribute CommunicationMode { get; } = zcl.Report(0x0002, "Communication Mode", ZigbeeType.Bmp8, r => r.ReadByte());
    /// <summary>
    /// Conditions for the sink to exit the commissioning mode.
    /// <summary>
    public static ReportAttribute CommissioningExitMode { get; } = zcl.Report(0x0003, "Commissioning Exit Mode", ZigbeeType.Bmp8, r => r.ReadByte());
    /// <summary>
    /// Default duration of the Commissioning window duration, in seconds, as requested by this sink.
    /// <summary>
    public static ReportAttribute CommissioningWindow { get; } = zcl.Report(0x0004, "Commissioning Window", ZigbeeType.U16, r => r.ReadUInt16());
    /// <summary>
    /// The minimum required security level to be supported by the paired GPDs.
    /// <summary>
    public static ReportAttribute SecurityLevel { get; } = zcl.Report(0x0005, "Security Level", ZigbeeType.Bmp8, r => r.ReadByte());
    /// <summary>
    /// The optional GP functionality supported by this sink.
    /// <summary>
    public static ReportAttribute Functionality { get; } = zcl.Report(0x0006, "Functionality", ZigbeeType.Bmp24, r => r.ReadInt24());
    /// <summary>
    /// The optional GP functionality supported by this sink that is active.
    /// <summary>
    public static ReportAttribute ActiveFunctionality { get; } = zcl.Report(0x0007, "Active Functionality", ZigbeeType.Bmp24, r => r.ReadInt24());
    public static ReportAttribute SharedSecurityKeyType { get; } = zcl.Report(0x0020, "Shared Security Key Type", ZigbeeType.Bmp8, r => r.ReadByte());
    public static ReportAttribute SharedSecurityKey { get; } = zcl.Report(0x0021, "Shared Security Key", ZigbeeType.Seckey, r => r.ReadString());
    public static ReportAttribute GPLinkKey { get; } = zcl.Report(0x0022, "GP Link Key", ZigbeeType.Seckey, r => r.ReadString());
}
