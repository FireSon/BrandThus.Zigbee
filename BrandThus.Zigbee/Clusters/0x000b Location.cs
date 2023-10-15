namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Measure distance between devices.
/// <summary>
[Cluster(0x000b, "Location")]
public static class ZclLocation
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclLocation));

    public static Task DistanceMeasure => Task.CompletedTask;

    public static Task DistanceMeasureResponse => Task.CompletedTask;
}
