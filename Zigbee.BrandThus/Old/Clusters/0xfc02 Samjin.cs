namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Samjin manufacturer-specifc cluster for SmartThings multi sensor.
/// <summary>
[Cluster(0xfc02, "Samjin")]
public static class ZclSamjin
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclSamjin));

    public static ReportAttribute MotionThresholdMultiplier { get; } = zcl.Report(0x0000, "Motion Threshold Multiplier", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute Active { get; } = zcl.Report(0x0010, "Active", ZigbeeType.Bmp8, r => r.ReadByte());
    public static ReportAttribute AccelerationX { get; } = zcl.Report(0x0012, "Acceleration X", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute AccelerationY { get; } = zcl.Report(0x0013, "Acceleration Y", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute AccelerationZ { get; } = zcl.Report(0x0014, "Acceleration Z", ZigbeeType.S16, r => r.ReadInt16());
}