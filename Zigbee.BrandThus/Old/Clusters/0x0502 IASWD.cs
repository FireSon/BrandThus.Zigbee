namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// The IAS WD cluster provides an interface to the functionality of any Warning Device equipment of the IAS system.
/// Using this cluster, a ZigBee enabled CIE device can access a ZigBee enabled IAS WD device and issue alarm warning
/// indications (siren, strobe lighting, etc.) when a system alarm condition is detected.
/// <summary>
[Cluster(0x0502, "IAS WD")]
public static class ZclIASWD
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclIASWD));

    public static ReportAttribute MaxDuration { get; } = zcl.Report(0x0000, "Max Duration", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute TuyaAlarmMode { get; } = zcl.Report(0xF000, "Tuya Alarm mode", ZigbeeType.U8, r => r.ReadByte());
    public static Task StartWarning(this ZigbeeNode node, byte options, ushort warningDuration, byte strobeDutyCycle, byte strobeLevel) => node.Zcl(zcl, 0x00, w => w+ options+ warningDuration+ strobeDutyCycle+ strobeLevel);
    public static Task Squawk(this ZigbeeNode node, byte options) => node.Zcl(zcl, 0x01, w => w+ options);
}
