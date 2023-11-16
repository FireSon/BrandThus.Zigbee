namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// The Appliance Control cluster provides an interface to remotely control and to program household appliances. Example
/// of control is Start, Stop and Pause commands.
/// <summary>
[Cluster(0x001b, "Appliance Control")]
public static class ZclApplianceControl
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclApplianceControl));


}
