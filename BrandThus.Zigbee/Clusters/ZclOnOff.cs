using System.Threading.Tasks;

namespace BrandThus.Zigbee.Clusters;

public static class ZclOnOff
{
    public static ZigbeeCluster Cluster = new(6, "OnOff");

    public static ZigbeeAttribute Onoff { get; } = Cluster.Report(0, "OnOff", 16, analog: false, r => r.ReadBool());
    public static ZigbeeAttribute Globalscenecontrol { get; } = Cluster.Report(16384, "GlobalSceneControl", 16, analog: false, r => r.ReadBool());
    public static ZigbeeAttribute Ontime { get; } = Cluster.Report(16385, "OnTime", 33, analog: true, r => r.ReadUInt16());
    public static ZigbeeAttribute Offwaittime { get; } = Cluster.Report(16386, "OffWaitTime", 33, analog: true, r => r.ReadUInt16());
    public static ZigbeeAttribute PoweronOnoff { get; } = Cluster.Report(16387, "PowerOn OnOff", 48, analog: false, r => (PoweronOnoffEnum)r.ReadByte());
    public static ZigbeeAttribute ButtonPress { get; } = Cluster.Report(32768, "Button Press", 32, analog: true, r => r.ReadByte());
    public static ZigbeeAttribute LightMode { get; } = Cluster.Report(32769, "Light mode", 48, analog: false, r => (LightModeEnum)r.ReadByte());
    public static ZigbeeAttribute PowerOnState { get; } = Cluster.Report(32770, "Power on state", 48, analog: false, r => (PowerOnStateEnum)r.ReadByte());

    public static Task Off(this ZigbeeNode node) => node.Zcl(Cluster, 0);
    public static Task On(this ZigbeeNode node) => node.Zcl(Cluster, 1);
    public static Task Toggle(this ZigbeeNode node) => node.Zcl(Cluster, 2);
    public static Task OffWithEffect(this ZigbeeNode node, byte effectidentifier, byte effectvariant) =>
        node.Zcl(Cluster, 40, w => w + effectidentifier + effectvariant);
    public static Task OnWithRecallGlobalScene(this ZigbeeNode node) => node.Zcl(Cluster, 41);
    public static Task OnWithTimedOff(this ZigbeeNode node, byte onoffcontrol, ushort ontime, ushort offwaittime) =>
        node.Zcl(Cluster, 42, w => w + onoffcontrol + ontime + offwaittime);

    #region PoweronOnoffEnum
    public enum PoweronOnoffEnum : byte
    {
        Off = 0,
        On = 1,
        Previous = byte.MaxValue
    }
    #endregion

    #region LightModeEnum
    public enum LightModeEnum : byte
    {
        Mode1,
        Mode2,
        Mode3
    }
    #endregion

    #region PowerOnStateEnum
    public enum PowerOnStateEnum : byte
    {
        Off,
        On,
        LastState
    } 
    #endregion
}
