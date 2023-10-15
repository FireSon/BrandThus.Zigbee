namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Attributes and commands for group configuration and manipulation.
/// <summary>
[Cluster(0x0004, "Groups")]
public static class ZclGroups
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclGroups));

    public static ReportAttribute NameSupport { get; } = zcl.Report(0000, "Name Support", r => r.ReadByte());
    public static ReportAttribute IKEAScene { get; } = zcl.Report(0x0001, "IKEA Scene", r => r.ReadUInt32());
    public static Task AddGroup => Task.CompletedTask;
    public static Task ViewGroup => Task.CompletedTask;
    public static Task GetGroupMembership => Task.CompletedTask;
    public static Task RemoveGroup => Task.CompletedTask;
    public static Task RemoveAllGroups => Task.CompletedTask;

    public static Task AddGroupResponse => Task.CompletedTask;
    public static Task ViewGroupResponse => Task.CompletedTask;
    public static Task GetGroupMembershipResponse => Task.CompletedTask;
    public static Task RemoveGroupResponse => Task.CompletedTask;
}
