namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Attributes and commands for touchlink commissioning.
/// <summary>
[Cluster(0x1000, "Touchlink Commissioning")]
public static class ZclTouchlinkCommissioning
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclTouchlinkCommissioning));

    public static Task GetGroupIdentifiers => Task.CompletedTask;
    public static Task GetEndpointList => Task.CompletedTask;
    public static Task WriteMACAddress => Task.CompletedTask;

    public static Task GetGroupIdentifiersResponse => Task.CompletedTask;
    public static Task GetEndpointListResponse => Task.CompletedTask;
}
