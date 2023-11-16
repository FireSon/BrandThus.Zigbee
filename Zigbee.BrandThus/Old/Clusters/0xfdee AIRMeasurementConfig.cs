namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// BOSCH Thermotechnik indoor air quality configuration
/// <summary>
[Cluster(0xfdee, "AIR Measurement Config")]
public static class ZclAIRMeasurementConfig
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclAIRMeasurementConfig));

}
