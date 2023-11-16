namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Attributes and commands for group configuration and manipulation.
/// <summary>
[Cluster(0x0004, "Groups")]
public static class ZclGroups
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclGroups));

    public static ReportAttribute NameSupport { get; } = zcl.Report(0000, "Name Support", ZigbeeType.Bmp8, r => r.ReadByte());
    public static ReportAttribute IKEAScene { get; } = zcl.Report(0x0001, "IKEA Scene", ZigbeeType.U32, r => r.ReadUInt32());
    /// <summary>
    /// Add a group to the device.
    /// <summary>
    public static Task AddGroup(this ZigbeeNode node, ushort groupID, string groupName) => node.Zcl(zcl, 00, w => w+ groupID+ groupName);
    /// <summary>
    /// Get the name of a group.
    /// <summary>
    public static Task ViewGroup(this ZigbeeNode node, ushort groupID) => node.Zcl(zcl, 01, w => w+ groupID);
    /// <summary>
    /// Get the group membership of the device.
    /// <summary>
    public static Task GetGroupMembership(this ZigbeeNode node, byte groupCount, ushort groupList) => node.Zcl(zcl, 02, w => w+ groupCount+ groupList);
    /// <summary>
    /// Remove a group from the device.
    /// <summary>
    public static Task RemoveGroup(this ZigbeeNode node, ushort groupID) => node.Zcl(zcl, 03, w => w+ groupID);
    /// <summary>
    /// Remove all group from the device.
    /// <summary>
    public static Task RemoveAllGroups(this ZigbeeNode node) => node.Zcl(zcl, 04);

    /// <summary>
    /// The Response to the add group request.
    /// <summary>
    public static Task AddGroupResponse(this ZigbeeNode node, byte status, ushort groupID) => node.Zcl(zcl, 00, w => w+ status+ groupID);
    /// <summary>
    /// The Response to the view group request.
    /// <summary>
    public static Task ViewGroupResponse(this ZigbeeNode node, byte status, ushort groupID, string groupName) => node.Zcl(zcl, 01, w => w+ status+ groupID+ groupName);
    /// <summary>
    /// The Response to the get group membership request.
    /// <summary>
    public static Task GetGroupMembershipResponse(this ZigbeeNode node, byte capacity, byte groupCount, ushort groupList) => node.Zcl(zcl, 02, w => w+ capacity+ groupCount+ groupList);
    /// <summary>
    /// The Response to the remove group request.
    /// <summary>
    public static Task RemoveGroupResponse(this ZigbeeNode node, byte status, ushort groupID) => node.Zcl(zcl, 03, w => w+ status+ groupID);
}
