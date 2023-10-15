namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// An interface for reading the value of an analog measurement and accessing various characteristics of that measurement.
/// <summary>
[Cluster(0x000c, "Analog Input (Basic)")]
public static class ZclAnalogInputBasic
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclAnalogInputBasic));

    public static ReportAttribute Description { get; } = zcl.Report(0x001c, "Description", r => r.ReadString());
    public static ReportAttribute MaxPresentValue { get; } = zcl.Report(0x0041, "Max Present Value", r => r.ReadSingle());
    public static ReportAttribute MinPresentValue { get; } = zcl.Report(0x0045, "Min Present Value", r => r.ReadSingle());
    public static ReportAttribute OutOfService { get; } = zcl.Report(0x0051, "Out of service", r => r.ReadBool());
    public static ReportAttribute PresentValue { get; } = zcl.Report(0x0055, "Present value", r => r.ReadSingle());
    public static ReportAttribute Reliability { get; } = zcl.Report(0x0067, "Reliability", r => r.ReadByte());
    public static ReportAttribute Resolution { get; } = zcl.Report(0x006a, "Resolution", r => r.ReadSingle());
    public static ReportAttribute StatusFlags { get; } = zcl.Report(0x006f, "Status flags", r => r.ReadByte());
    public static ReportAttribute EngineeringUnits { get; } = zcl.Report(0x0075, "Engineering Units", r => r.ReadInt16());
    public static ReportAttribute ApplicationType { get; } = zcl.Report(0x0100, "Application Type", r => r.ReadUInt32());
}
