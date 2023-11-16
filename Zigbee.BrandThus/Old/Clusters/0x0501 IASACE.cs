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

    public static Task Arm(this ZigbeeNode node, byte armMode, string armDisarmCode, byte zoneID) => node.Zcl(zcl, 0x00, w => w+ armMode+ armDisarmCode+ zoneID);
    public static Task Bypass(this ZigbeeNode node, byte numberOfZones, byte zoneID, string armDisarmCode) => node.Zcl(zcl, 0x01, w => w+ numberOfZones+ zoneID+ armDisarmCode);
    public static Task Emergency(this ZigbeeNode node) => node.Zcl(zcl, 0x02);
    public static Task Fire(this ZigbeeNode node) => node.Zcl(zcl, 0x03);
    public static Task Panic(this ZigbeeNode node) => node.Zcl(zcl, 0x04);
    public static Task GetZoneIDMap(this ZigbeeNode node) => node.Zcl(zcl, 0x05);
    public static Task GetZoneInformation(this ZigbeeNode node, byte zoneID) => node.Zcl(zcl, 0x06, w => w+ zoneID);
    public static Task GetPanelStatus(this ZigbeeNode node) => node.Zcl(zcl, 0x07);
    public static Task GetBypassedZoneList(this ZigbeeNode node) => node.Zcl(zcl, 0x08);
    public static Task GetZoneStatus(this ZigbeeNode node, byte startingZoneID, byte maxNumberOfZoneIDs, bool zoneStatusMaskFlag, Int16 zoneStatusMask) => node.Zcl(zcl, 0x09, w => w+ startingZoneID+ maxNumberOfZoneIDs+ zoneStatusMaskFlag+ zoneStatusMask);

    public static Task ArmResponse(this ZigbeeNode node, byte armNotification, string armDisarmCode, byte zoneID) => node.Zcl(zcl, 0x00, w => w+ armNotification+ armDisarmCode+ zoneID);
    public static Task GetZoneIDMapResponse(this ZigbeeNode node, Int16 zoneIDMapSection0) => node.Zcl(zcl, 0x01, w => w+ zoneIDMapSection0);
    public static Task GetZoneInformationResponse(this ZigbeeNode node, byte zoneID, Int16 zoneType, Int64 iEEEAddress, string zoneLabel) => node.Zcl(zcl, 0x02, w => w+ zoneID+ zoneType+ iEEEAddress+ zoneLabel);
    public static Task ZoneStatusChanged(this ZigbeeNode node, byte zoneID, Int16 zoneStatus, byte audibleNotification, string zoneLabel) => node.Zcl(zcl, 0x03, w => w+ zoneID+ zoneStatus+ audibleNotification+ zoneLabel);
    public static Task PanelStatusChanged(this ZigbeeNode node, byte panelStatus, byte secondsRemaining, byte audibleNotification, byte alarmStatus, string zoneLabel) => node.Zcl(zcl, 0x04, w => w+ panelStatus+ secondsRemaining+ audibleNotification+ alarmStatus+ zoneLabel);
    public static Task GetPanelStatusResponse(this ZigbeeNode node, byte panelStatus, byte secondsRemaining, byte audibleNotification, byte alarmStatus, string zoneLabel) => node.Zcl(zcl, 0x05, w => w+ panelStatus+ secondsRemaining+ audibleNotification+ alarmStatus+ zoneLabel);
    public static Task SetBypassedZoneList(this ZigbeeNode node, byte numberOfZones, byte zoneID1, byte zoneID2, byte zoneID3, byte zoneID4, byte zoneID5, byte zoneID6, byte zoneID7, byte zoneID8) => node.Zcl(zcl, 0x06, w => w+ numberOfZones+ zoneID1+ zoneID2+ zoneID3+ zoneID4+ zoneID5+ zoneID6+ zoneID7+ zoneID8);
    public static Task BypassResponse(this ZigbeeNode node, byte numberOfZones, byte bypassResultForZoneID1, byte bypassResultForZoneID2, byte bypassResultForZoneID3, byte bypassResultForZoneID4, byte bypassResultForZoneID5, byte bypassResultForZoneID6, byte bypassResultForZoneID7, byte bypassResultForZoneID8) => node.Zcl(zcl, 0x07, w => w+ numberOfZones+ bypassResultForZoneID1+ bypassResultForZoneID2+ bypassResultForZoneID3+ bypassResultForZoneID4+ bypassResultForZoneID5+ bypassResultForZoneID6+ bypassResultForZoneID7+ bypassResultForZoneID8);
    public static Task GetZoneStatusResponse(this ZigbeeNode node, bool zoneStatusComplete, byte numberOfZones, byte zoneID1, Int16 zoneID1ZoneStatus, byte zoneID2, Int16 zoneID2ZoneStatus, byte zoneID3, Int16 zoneID3ZoneStatus, byte zoneID4, Int16 zoneID4ZoneStatus) => node.Zcl(zcl, 0x08, w => w+ zoneStatusComplete+ numberOfZones+ zoneID1+ zoneID1ZoneStatus+ zoneID2+ zoneID2ZoneStatus+ zoneID3+ zoneID3ZoneStatus+ zoneID4+ zoneID4ZoneStatus);
}
