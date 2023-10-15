namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// The IAS ACE cluster defines an interface to the functionality of any Ancillary Control Equipment of the IAS system.
/// Using this cluster, a ZigBee enabled ACE device can access a IAS CIE device and manipulate the IAS system, on
/// behalf of a level-2 user.
/// <summary>
[Cluster(0x0501, "IAS ACE")]
public static class ZclIASACE
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclIASACE));

    public static Task Arm => Task.CompletedTask;
    public static Task Bypass => Task.CompletedTask;
    public static Task Emergency => Task.CompletedTask;
    public static Task Fire => Task.CompletedTask;
    public static Task Panic => Task.CompletedTask;
    public static Task GetZoneIDMap => Task.CompletedTask;
    public static Task GetZoneInformation => Task.CompletedTask;
    public static Task GetPanelStatus => Task.CompletedTask;
    public static Task GetBypassedZoneList => Task.CompletedTask;
    public static Task GetZoneStatus => Task.CompletedTask;

    public static Task ArmResponse => Task.CompletedTask;
    public static Task GetZoneIDMapResponse => Task.CompletedTask;
    public static Task GetZoneInformationResponse => Task.CompletedTask;
    public static Task ZoneStatusChanged => Task.CompletedTask;
    public static Task PanelStatusChanged => Task.CompletedTask;
    public static Task GetPanelStatusResponse => Task.CompletedTask;
    public static Task SetBypassedZoneList => Task.CompletedTask;
    public static Task BypassResponse => Task.CompletedTask;
    public static Task GetZoneStatusResponse => Task.CompletedTask;
}
