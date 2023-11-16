namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// The Analog Output (Basic) cluster provides an interface for setting the value of an analog output (typically to
/// the environment) and accessing various characteristics of that value.
/// <summary>
[Cluster(0x000d, "Analog Output (Basic)")]
public static class ZclAnalogOutputBasic
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclAnalogOutputBasic));

    public static ReportAttribute Description { get; } = zcl.Report(0x001c, "Description", ZigbeeType.Cstring, r => r.ReadString());
    public static ReportAttribute MaxPresentValue { get; } = zcl.Report(0x0041, "Max Present Value", ZigbeeType.Float, r => r.ReadSingle());
    public static ReportAttribute MinPresentValue { get; } = zcl.Report(0x0045, "Min Present Value", ZigbeeType.Float, r => r.ReadSingle());
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
    public static ReportAttribute Resolution { get; } = zcl.Report(0x006a, "Resolution", ZigbeeType.Float, r => r.ReadSingle());
    public static ReportAttribute StatusFlags { get; } = zcl.Report(0x006f, "Status flags", ZigbeeType.Bmp8, r => r.ReadByte());
    public enum EngineeringUnitsEnum
    {
    }

    public static ReportAttribute EngineeringUnits { get; } = zcl.Report(0x0075, "Engineering Units", ZigbeeType.Enum16, r => (EngineeringUnitsEnum)r.ReadInt16());
    public static ReportAttribute ApplicationType { get; } = zcl.Report(0x0100, "Application Type", ZigbeeType.U32, r => r.ReadUInt32());
    public static ReportAttribute Xiaomi0xf000 { get; } = zcl.Report(0xf000, "Xiaomi 0xf000", ZigbeeType.U32, r => r.ReadUInt32());
}
