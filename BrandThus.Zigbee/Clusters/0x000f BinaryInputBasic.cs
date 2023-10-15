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

    public static ReportAttribute ActiveText { get; } = zcl.Report(0x0004, "Active Text", r => r.ReadString());
    public static ReportAttribute Description { get; } = zcl.Report(0x001c, "Description", r => r.ReadString());
    public static ReportAttribute InactiveText { get; } = zcl.Report(0x002e, "Inactive Text", r => r.ReadString());
    public static ReportAttribute OutOfService { get; } = zcl.Report(0x0051, "Out of Service", r => r.ReadBool());
    public static ReportAttribute Polarity { get; } = zcl.Report(0x0054, "Polarity", r => r.ReadByte());
    public static ReportAttribute PresentValue { get; } = zcl.Report(0x0055, "Present Value", r => r.ReadBool());
    public static ReportAttribute Reliability { get; } = zcl.Report(0x0067, "Reliability", r => r.ReadByte());
    public static ReportAttribute StatusFlags { get; } = zcl.Report(0x006F, "Status Flags", r => r.ReadByte());
    public static ReportAttribute ApplicationType { get; } = zcl.Report(0x0100, "Application Type", r => r.ReadUInt32());
    #region Develco specific
    public static ReportAttribute DevelcoIASActivation { get; } = zcl.Report(0x8000, "IAS Activation", r => r.ReadUInt16());
    #endregion 


}
