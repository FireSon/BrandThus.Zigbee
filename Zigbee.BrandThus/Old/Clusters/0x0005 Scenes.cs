namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Attributes and commands for scene configuration and manipulation.
/// <summary>
[Cluster(0x0005, "Scenes")]
public static class ZclScenes
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclScenes));

    public static ReportAttribute SceneCount { get; } = zcl.Report(0x0000, "Scene Count", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute CurrentScene { get; } = zcl.Report(0x0001, "Current Scene", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute CurrentGroup { get; } = zcl.Report(0x0002, "Current Group", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute SceneValid { get; } = zcl.Report(0x0003, "Scene Valid", ZigbeeType.Bool, r => r.ReadBool());
    public static ReportAttribute NameSupport { get; } = zcl.Report(0x0004, "Name Support", ZigbeeType.Bmp8, r => r.ReadByte());
    public static ReportAttribute LastConfiguredBy { get; } = zcl.Report(0x0005, "Last ConfiguredBy", ZigbeeType.Uid, r => r.ReadInt64());
    /// <summary>
    /// Add a scenes to the group (empty).
    /// <summary>
    public static Task AddScene(this ZigbeeNode node, ushort groupID, byte sceneID, ushort transitionTime, byte nameLength) => node.Zcl(zcl, 0x00, w => w+ groupID+ sceneID+ transitionTime+ nameLength);
    /// <summary>
    /// Views the scenes of a group.
    /// <summary>
    public static Task ViewScene(this ZigbeeNode node, ushort groupID, byte sceneID) => node.Zcl(zcl, 0x01, w => w+ groupID+ sceneID);
    /// <summary>
    /// Removes a scenes of a group.
    /// <summary>
    public static Task RemoveScene(this ZigbeeNode node, ushort groupID, byte sceneID) => node.Zcl(zcl, 0x02, w => w+ groupID+ sceneID);
    /// <summary>
    /// Removes all scenes of a group.
    /// <summary>
    public static Task RemoveAllScenes(this ZigbeeNode node, ushort groupID) => node.Zcl(zcl, 0x03, w => w+ groupID);
    /// <summary>
    /// Stores a scene of a group for a device.
    /// <summary>
    public static Task StoreScene(this ZigbeeNode node, ushort groupID, byte sceneID) => node.Zcl(zcl, 0x04, w => w+ groupID+ sceneID);
    /// <summary>
    /// Recalls a scene of a group for a device.
    /// <summary>
    public static Task RecallScene(this ZigbeeNode node, ushort groupID, byte sceneID) => node.Zcl(zcl, 0x05, w => w+ groupID+ sceneID);
    /// <summary>
    /// Get the scenes of a group for a device.
    /// <summary>
    public static Task GetSceneMembership(this ZigbeeNode node, ushort groupID) => node.Zcl(zcl, 0x06, w => w+ groupID);
    /// <summary>
    /// Views the scenes of a group.
    /// <summary>
    public static Task EnhancedViewScene(this ZigbeeNode node, ushort groupID, byte sceneID) => node.Zcl(zcl, 0x41, w => w+ groupID+ sceneID);
    /// <summary>
    /// Command sent by TRADFRI remote control on press left or right. Set Direction to 1 for left or leave at 0 for right.
    /// Leave the Unknown parameters at their default values.
    /// <summary>
    public static Task IKEAStep(this ZigbeeNode node, byte direction, byte unknown, ushort unknown2) => node.Zcl(zcl, 0x07, w => w+ direction+ unknown+ unknown2);
    /// <summary>
    /// Command sent by TRADFRI remote control on hold left or right. Set Direction to 1 for left or leave at 0 for right.
    /// Leave the Unknown parameter at its default value.
    /// <summary>
    public static Task IKEAMove(this ZigbeeNode node, byte direction, ushort unknown) => node.Zcl(zcl, 0x08, w => w+ direction+ unknown);
    /// <summary>
    /// Command sent by TRADFRI remote control on release (after hold). Leave the Unknown parameter at its default value.
    /// <summary>
    public static Task IKEAStop(this ZigbeeNode node, ushort unknown) => node.Zcl(zcl, 0x09, w => w+ unknown);

    /// <summary>
    /// Response to the add scene command.
    /// <summary>
    public static Task AddSceneResponse(this ZigbeeNode node, byte status, ushort groupID, byte sceneID) => node.Zcl(zcl, 0x00, w => w+ status+ groupID+ sceneID);
    /// <summary>
    /// Response to the view scene command.
    /// <summary>
    public static Task ViewSceneResponse(this ZigbeeNode node, byte status, ushort groupID, byte sceneID, ushort transitionTime) => node.Zcl(zcl, 0x01, w => w+ status+ groupID+ sceneID+ transitionTime);
    /// <summary>
    /// Response to the remove scene command.
    /// <summary>
    public static Task RemoveSceneResponse(this ZigbeeNode node, byte status, ushort groupID, byte sceneID) => node.Zcl(zcl, 0x02, w => w+ status+ groupID+ sceneID);
    /// <summary>
    /// Response to the remove all scenes command.
    /// <summary>
    public static Task RemoveAllScenesResponse(this ZigbeeNode node, byte status, ushort groupID) => node.Zcl(zcl, 0x03, w => w+ status+ groupID);
    /// <summary>
    /// Response to the store scene command.
    /// <summary>
    public static Task StoreSceneResponse(this ZigbeeNode node, byte status, ushort groupID, byte sceneID) => node.Zcl(zcl, 0x04, w => w+ status+ groupID+ sceneID);
    /// <summary>
    /// Shows details about scene membership.
    /// <summary>
    public static Task GetSceneMembershioResponse(this ZigbeeNode node, byte status, byte capacity, ushort groupID, byte sceneCount) => node.Zcl(zcl, 0x06, w => w+ status+ capacity+ groupID+ sceneCount);
    /// <summary>
    /// A scene description.
    /// <summary>
    public static Task EnhancedViewSceneResponse(this ZigbeeNode node, byte status, ushort groupID, byte sceneID, ushort transitionTime, string name) => node.Zcl(zcl, 0x41, w => w+ status+ groupID+ sceneID+ transitionTime+ name);
}
