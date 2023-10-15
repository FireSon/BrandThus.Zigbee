namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Attributes and commands for determining basic information about a device and setting user device information.
/// The Appliance Identification Cluster is a transposition of EN50523 "Identify Product" functional block.
/// <summary>
[Cluster(0x0b00, "Appliance Identification")]
public static class ZclApplianceIdentification
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclApplianceIdentification));


}
