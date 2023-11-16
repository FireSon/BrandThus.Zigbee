namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// The Binary Output (Basic) cluster provides an interface for setting the value of a binary output, and accessing
/// various characteristics of that value.
/// <summary>
[Cluster(0x0010, "Binary Output (Basic)")]
public static class ZclBinaryOutputBasic
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclBinaryOutputBasic));

    public static ReportAttribute ActiveText { get; } = zcl.Report(0x0004, "Active Text", ZigbeeType.Cstring, r => r.ReadString());
    public static ReportAttribute Description { get; } = zcl.Report(0x001c, "Description", ZigbeeType.Cstring, r => r.ReadString());
    public static ReportAttribute InactiveText { get; } = zcl.Report(0x002e, "Inactive Text", ZigbeeType.Cstring, r => r.ReadString());
    public static ReportAttribute MinOffTime { get; } = zcl.Report(0x0042, "Min Off Time", ZigbeeType.U32, r => r.ReadUInt32());
    public static ReportAttribute MinOnTime { get; } = zcl.Report(0x0043, "Min On Time", ZigbeeType.U32, r => r.ReadUInt32());
    public static ReportAttribute OutOfService { get; } = zcl.Report(0x0051, "Out of service", ZigbeeType.Bool, r => r.ReadBool());
    public enum PolarityEnum
    {
        Normal = 0,
        Reverse = 1,
    }

    public static ReportAttribute Polarity { get; } = zcl.Report(0x0054, "Polarity", ZigbeeType.Enum8, r => (PolarityEnum)r.ReadByte());
    public static ReportAttribute PresentValue { get; } = zcl.Report(0x0055, "Present value", ZigbeeType.Bool, r => r.ReadBool());
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
    public static ReportAttribute RelinquishDefault { get; } = zcl.Report(0x0068, "Relinquish Default", ZigbeeType.Bool, r => r.ReadBool());
    public static ReportAttribute StatusFlags { get; } = zcl.Report(0x006f, "Status flags", ZigbeeType.Bmp8, r => r.ReadByte());
    public static ReportAttribute ApplicationType { get; } = zcl.Report(0x0100, "Application Type", ZigbeeType.U32, r => r.ReadUInt32());
    #region Xiaomi Specific
    public static ReportAttribute Interlock { get; } = zcl.Report(0xff06, "Interlock", ZigbeeType.Bool, r => r.ReadBool());
    #endregion 

}
