namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Hue-specific cluster for Hue dimmer family.
/// <summary>
[Cluster(0xfc00, "Hue Button")]
public static class ZclHueButton
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclHueButton));

    public static Task ButtonActionNotification => Task.CompletedTask;
}
