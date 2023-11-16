namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// An interface for setting an analog value, typically used as a control system parameter, and accessing various
/// characteristics of that value.
/// <summary>
[Cluster(0x000e, "Analog Value (Basic)")]
public static class ZclAnalogValueBasic
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclAnalogValueBasic));

    public static ReportAttribute Description { get; } = zcl.Report(0x001c, "Description", ZigbeeType.Cstring, r => r.ReadString());
    public static ReportAttribute OutOfService { get; } = zcl.Report(0x0051, "Out of service", ZigbeeType.Bool, r => r.ReadBool());
    public static ReportAttribute PresentValue { get; } = zcl.Report(0x0055, "Present value", ZigbeeType.Float, r => r.ReadSingle());
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
    public static ReportAttribute RelinquishDefault { get; } = zcl.Report(0x0068, "Relinquish Default", ZigbeeType.Float, r => r.ReadSingle());
    public static ReportAttribute StatusFlags { get; } = zcl.Report(0x006f, "Status flags", ZigbeeType.Bmp8, r => r.ReadByte());
    public enum EngineeringUnitsEnum
    {
    }

    public static ReportAttribute EngineeringUnits { get; } = zcl.Report(0x0075, "Engineering Units", ZigbeeType.Enum16, r => (EngineeringUnitsEnum)r.ReadInt16());
    public static ReportAttribute ApplicationType { get; } = zcl.Report(0x0100, "Application Type", ZigbeeType.U32, r => r.ReadUInt32());
}
