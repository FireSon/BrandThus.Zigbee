namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Attributes and commands for scene configuration and manipulation.
/// <summary>
[Cluster(0x0005, "Scenes")]
public static class ZclScenes
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclScenes));

    public static ReportAttribute SceneCount { get; } = zcl.Report(0x0000, "Scene Count", r => r.ReadByte());
    public static ReportAttribute CurrentScene { get; } = zcl.Report(0x0001, "Current Scene", r => r.ReadByte());
    public static ReportAttribute CurrentGroup { get; } = zcl.Report(0x0002, "Current Group", r => r.ReadUInt16());
    public static ReportAttribute SceneValid { get; } = zcl.Report(0x0003, "Scene Valid", r => r.ReadBool());
    public static ReportAttribute NameSupport { get; } = zcl.Report(0x0004, "Name Support", r => r.ReadByte());
    public static ReportAttribute LastConfiguredBy { get; } = zcl.Report(0x0005, "Last ConfiguredBy", r => r.ReadInt64());
    public static Task AddScene => Task.CompletedTask;
    public static Task ViewScene => Task.CompletedTask;
    public static Task RemoveScene => Task.CompletedTask;
    public static Task RemoveAllScenes => Task.CompletedTask;
    public static Task StoreScene => Task.CompletedTask;
    public static Task RecallScene => Task.CompletedTask;
    public static Task GetSceneMembership => Task.CompletedTask;
    public static Task EnhancedViewScene => Task.CompletedTask;
    public static Task IKEAStep => Task.CompletedTask;
    public static Task IKEAMove => Task.CompletedTask;
    public static Task IKEAStop => Task.CompletedTask;

    public static Task AddSceneResponse => Task.CompletedTask;
    public static Task ViewSceneResponse => Task.CompletedTask;
    public static Task RemoveSceneResponse => Task.CompletedTask;
    public static Task RemoveAllScenesResponse => Task.CompletedTask;
    public static Task StoreSceneResponse => Task.CompletedTask;
    public static Task GetSceneMembershioResponse => Task.CompletedTask;
    public static Task EnhancedViewSceneResponse => Task.CompletedTask;
}
