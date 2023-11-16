namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// The shade configuration cluster provides an interface for reading information about a shade, and configuring its
/// open and closed limits.
/// <summary>
[Cluster(0x0100, "Shade Configuration")]
public static class ZclShadeConfiguration
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclShadeConfiguration));

    #region Shade Information Attribute Set
    public static ReportAttribute PhysicalClosedLimit { get; } = zcl.Report(0x0000, "Physical Closed Limit", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute MotorStepSize { get; } = zcl.Report(0x0001, "MotorStepSize", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute Status { get; } = zcl.Report(0x0002, "Status", ZigbeeType.Bmp8, r => r.ReadByte());
    #endregion 

    #region Shade Settings Attribute Set
    public static ReportAttribute ClosedLimit { get; } = zcl.Report(0x0010, "Closed Limit", ZigbeeType.U16, r => r.ReadUInt16());
    public enum ModeEnum
    {
        Normal = 0x00,
        Configure = 0x01,
        Invalid = 0xff,
    }

    public static ReportAttribute Mode { get; } = zcl.Report(0x0011, "Mode", ZigbeeType.Enum8, r => (ModeEnum)r.ReadByte());
    #endregion 

}
