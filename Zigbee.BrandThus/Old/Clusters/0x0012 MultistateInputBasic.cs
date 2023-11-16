namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Provides an interface for reading the value of a multistate measurement and accessing various characteristics
/// of that measurement. The cluster is typically used to implement a sensor that measures a physical quantity that
/// can take on one of a number of discrete states.
/// <summary>
[Cluster(0x0012, "Multistate Input (Basic)")]
public static class ZclMultistateInputBasic
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclMultistateInputBasic));

    public static ReportAttribute Description { get; } = zcl.Report(0x001c, "Description", ZigbeeType.Cstring, r => r.ReadString());
    public static ReportAttribute NumberOfStates { get; } = zcl.Report(0x004a, "Number of states", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute OutOfService { get; } = zcl.Report(0x0051, "Out of service", ZigbeeType.Bool, r => r.ReadBool());
    public static ReportAttribute PresentValue { get; } = zcl.Report(0x0055, "Present value", ZigbeeType.U16, r => r.ReadUInt16());
    public enum ReliabilityEnum
    {
        NoFaultDetected = 0,
        NoSensor = 1,
        OverRange = 2,
        UnderRange = 3,
        OpenLoop = 4,
        ShortedLoop = 5,
        NoOutput = 6,
        UnreliableOther = 7,
        ProcessError = 8,
        MultiStateFault = 9,
        ConfigurationError = 10,
    }

    public static ReportAttribute Reliability { get; } = zcl.Report(0x0067, "Reliability", ZigbeeType.Enum8, r => (ReliabilityEnum)r.ReadByte());
    public static ReportAttribute StatusFlags { get; } = zcl.Report(0x006f, "Status flags", ZigbeeType.Bmp8, r => r.ReadByte());
    public static ReportAttribute ApplicationType { get; } = zcl.Report(0x0100, "Application Type", ZigbeeType.U32, r => r.ReadUInt32());
}
