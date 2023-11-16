namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Attributes and commands for touchlink commissioning.
/// <summary>
[Cluster(0x1000, "Touchlink Commissioning")]
public static class ZclTouchlinkCommissioning
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclTouchlinkCommissioning));

    /// <summary>
    /// The get group identifiers request command is used to retrieve the actual group identifiers that the endpoint is
    /// using in its multicast communication in controlling different (remote) devices.
    /// <summary>
    public static Task GetGroupIdentifiers(this ZigbeeNode node, byte startIndex) => node.Zcl(zcl, 0x41, w => w+ startIndex);
    /// <summary>
    /// The get endpoint list request command is used to retrieve addressing information for each endpoint the device
    /// is using in its unicast communication in controlling different (remote) devices.
    /// <summary>
    public static Task GetEndpointList(this ZigbeeNode node, byte startIndex) => node.Zcl(zcl, 0x42, w => w+ startIndex);
    /// <summary>
    /// Non standard write MAC address (DDEL).
    /// <summary>
    public static Task WriteMACAddress(this ZigbeeNode node, ulong mACAddress) => node.Zcl(zcl, 0xd0, w => w+ mACAddress);

    /// <summary>
    /// The get group identifiers response command allows a remote device to respond to the get group identifiers request
    /// command.
    /// <summary>
    public static Task GetGroupIdentifiersResponse(this ZigbeeNode node, byte total, byte startIndex, byte count, ushort firstGroupID, byte firstGroupType) => node.Zcl(zcl, 0x41, w => w+ total+ startIndex+ count+ firstGroupID+ firstGroupType);
    /// <summary>
    /// The get group identifiers response command allows a remote device to respond to the get group identifiers request
    /// command.
    /// <summary>
    public static Task GetEndpointListResponse(this ZigbeeNode node, byte total, byte startIndex, byte count, ushort nWKAddress, byte endpoint, ushort profileID, ushort deviceID, byte version) => node.Zcl(zcl, 0x42, w => w+ total+ startIndex+ count+ nWKAddress+ endpoint+ profileID+ deviceID+ version);
}
