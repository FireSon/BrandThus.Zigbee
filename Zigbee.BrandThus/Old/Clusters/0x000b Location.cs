namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Measure distance between devices.
/// <summary>
[Cluster(0x000b, "Location")]
public static class ZclLocation
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclLocation));

    public static Task DistanceMeasure(this ZigbeeNode node, ushort targetAddress, byte resolution) => node.Zcl(zcl, 0x40, w => w+ targetAddress+ resolution);

    /// <summary>
    /// Returns the result of a distance measure.
    /// <summary>
    public static Task DistanceMeasureResponse(this ZigbeeNode node, ushort targetAddress, ushort distanceMeter, ushort qualityIndex) => node.Zcl(zcl, 0x40, w => w+ targetAddress+ distanceMeter+ qualityIndex);
}
