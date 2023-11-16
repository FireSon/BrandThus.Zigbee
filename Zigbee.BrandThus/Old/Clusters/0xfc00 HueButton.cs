namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Hue-specific cluster for Hue dimmer family.
/// <summary>
[Cluster(0xfc00, "Hue Button")]
public static class ZclHueButton
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclHueButton));

    public static Task ButtonActionNotification(this ZigbeeNode node, ushort button, byte eventType, byte typeOfNextAttribute0x0002, byte action, byte typeOfNextAttribute0x0004, short durationRotation) => node.Zcl(zcl, 0x00, w => w+ button+ eventType+ typeOfNextAttribute0x0002+ action+ typeOfNextAttribute0x0004+ durationRotation);
}
