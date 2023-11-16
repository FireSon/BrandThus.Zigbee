namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// The Binary Input (Basic) cluster provides an interface for reading the value of a binary measurement and accessing
/// various characteristics of that measurement. The cluster is typically used to implement a sensor that measures
/// a two-state physical quantity.
/// <summary>
[Cluster(0x000f, "Binary Input (Basic)")]
public static class ZclBinaryInputBasic
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclBinaryInputBasic));

    public static ReportAttribute ActiveText { get; } = zcl.Report(0x0004, "Active Text", ZigbeeType.Cstring, r => r.ReadString());
    public static ReportAttribute Description { get; } = zcl.Report(0x001c, "Description", ZigbeeType.Cstring, r => r.ReadString());
    public static ReportAttribute InactiveText { get; } = zcl.Report(0x002e, "Inactive Text", ZigbeeType.Cstring, r => r.ReadString());
    public static ReportAttribute OutOfService { get; } = zcl.Report(0x0051, "Out of Service", ZigbeeType.Bool, r => r.ReadBool());
    public enum PolarityEnum
    {
        Normal = 0,
        Reverse = 1,
    }

    public static ReportAttribute Polarity { get; } = zcl.Report(0x0054, "Polarity", ZigbeeType.Enum8, r => (PolarityEnum)r.ReadByte());
    public static ReportAttribute PresentValue { get; } = zcl.Report(0x0055, "Present Value", ZigbeeType.Bool, r => r.ReadBool());
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
    public static ReportAttribute StatusFlags { get; } = zcl.Report(0x006F, "Status Flags", ZigbeeType.Bmp8, r => r.ReadByte());
    public static ReportAttribute ApplicationType { get; } = zcl.Report(0x0100, "Application Type", ZigbeeType.U32, r => r.ReadUInt32());
    #region Develco specific
    public static ReportAttribute DevelcoIASActivation { get; } = zcl.Report(0x8000, "IAS Activation", ZigbeeType.U16, r => r.ReadUInt16());
    #endregion 


}
