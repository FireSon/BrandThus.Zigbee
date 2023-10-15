namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// The tunneling cluster provides an interface for tunneling protocols.
/// <summary>
[Cluster(0x0704, "Smart Energy Tunneling (Complex Metering)")]
public static class ZclSmartEnergyTunnelingComplexMetering
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclSmartEnergyTunnelingComplexMetering));

    public static ReportAttribute CloseTunnelTimeout { get; } = zcl.Report(0000, "Close Tunnel Timeout", r => r.ReadUInt16());
}
