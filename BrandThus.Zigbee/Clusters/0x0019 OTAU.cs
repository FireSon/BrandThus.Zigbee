namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Over the air upgrade.
/// <summary>
[Cluster(0x0019, "OTAU")]
public static class ZclOTAU
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclOTAU));


    public static Task QueryNextImage => Task.CompletedTask;
    public static Task UpgradeEndResponse => Task.CompletedTask;
}
