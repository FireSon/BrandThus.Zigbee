namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Over the air upgrade.
/// <summary>
[Cluster(0x0019, "OTAU")]
public static class ZclOTAU
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclOTAU));


    public static Task QueryNextImage(this ZigbeeNode node, byte controlField, ushort manufacturerID, Int16 imageType, byte applicationRelease, byte applicationBuild, byte stackRelease, byte stackBuild) => node.Zcl(zcl, 0x01, w => w+ controlField+ manufacturerID+ imageType+ applicationRelease+ applicationBuild+ stackRelease+ stackBuild);
    public static Task UpgradeEndResponse(this ZigbeeNode node, ushort manufacturerID, ushort imageType, uint fileVersion, uint currentTime, uint upgradeTime) => node.Zcl(zcl, 0x07, w => w+ manufacturerID+ imageType+ fileVersion+ currentTime+ upgradeTime);
}
