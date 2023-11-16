namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Attributes and commands for transmitting or notifying the occurrence of an event, such as "temperature reached"
/// and of an alert such as alarm, fault or warning. It is based on the "Signal event" syntax of EN50523 and completed
/// where necessary.
/// <summary>
[Cluster(0x0b02, "Appliance Events and Alerts")]
public static class ZclApplianceEventsAndAlerts
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclApplianceEventsAndAlerts));

    /// <summary>
    /// The get group identifiers request command is used to retrieve the actual group identifiers that the endpoint is
    /// using in its multicast communication in controlling different (remote) devices.
    /// <summary>
    public static Task GetAlerts(this ZigbeeNode node) => node.Zcl(zcl, 0x00);

}
