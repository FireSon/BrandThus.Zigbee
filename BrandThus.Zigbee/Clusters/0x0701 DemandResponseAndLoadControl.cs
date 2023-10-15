namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// This cluster provides an interface to the functionality of Smart Energy Demand Response and Load Control. Devices
/// targeted by this cluster include thermostats and devices that support load control.
/// <summary>
[Cluster(0x0701, "Demand Response and Load Control")]
public static class ZclDemandResponseAndLoadControl
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclDemandResponseAndLoadControl));


}
