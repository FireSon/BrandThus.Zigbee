namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// The Appliance Statistics provides a mechanism for transmitting appliance statistics to a collection unit (gateway).
/// The statistics can be in format of data logs.
/// <summary>
[Cluster(0x0b03, "Appliance Statistics")]
public static class ZclApplianceStatistics
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclApplianceStatistics));


}
