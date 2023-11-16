namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Datek diagnostics cluster attributes.
/// <summary>
[Cluster(0xfeed, "Datek diagnostics")]
public static class ZclDatekDiagnostics
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclDatekDiagnostics));

    public static ReportAttribute LastResetInfo { get; } = zcl.Report(0x0000, "Last reset info", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute LastExtendedResetInfo { get; } = zcl.Report(0x0001, "Last extended reset info", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute RebootCounter { get; } = zcl.Report(0x0002, "Reboot counter", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute LastHopLQI { get; } = zcl.Report(0x0003, "Last hop LQI", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute LastHopRSSI { get; } = zcl.Report(0x0004, "Last hop RSSI", ZigbeeType.S8, r => r.ReadByte());
    public static ReportAttribute TxPower { get; } = zcl.Report(0x0005, "Tx power", ZigbeeType.S8, r => r.ReadByte());
    public static ReportAttribute Button0ClickCounter { get; } = zcl.Report(0x0010, "Button 0 click counter", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute Button0MsClickCounter { get; } = zcl.Report(0x0020, "Button 0 ms click counter", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute ElectricalMeasurementAvg { get; } = zcl.Report(0x0100, "Electrical measurement avg", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute ElectricalMeasurementRaw { get; } = zcl.Report(0x0101, "Electrical measurement raw", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute ElectricalMeasurementNoiseWLoad { get; } = zcl.Report(0x0102, "Electrical measurement noise w load", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute ElectricalMeasurementNoiseWoLoad { get; } = zcl.Report(0x0103, "Electrical measurement noise w/o load", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute ClusterRevision { get; } = zcl.Report(0xFFFD, "Cluster revision", ZigbeeType.U16, r => r.ReadUInt16());
}