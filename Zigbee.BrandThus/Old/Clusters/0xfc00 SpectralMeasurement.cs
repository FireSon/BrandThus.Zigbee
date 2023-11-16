namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Dresden Elektronik Specific clusters.
/// <summary>
[Cluster(0xfc00, "Spectral Measurement")]
public static class ZclSpectralMeasurement
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclSpectralMeasurement));

    /// <summary>
    /// Enable Sensor
    /// <summary>
    public static ReportAttribute On { get; } = zcl.Report(0x0000, "On", ZigbeeType.U8, r => r.ReadByte());
    /// <summary>
    /// X-Value
    /// <summary>
    public static ReportAttribute XValue { get; } = zcl.Report(0x0001, "X-Value", ZigbeeType.U16, r => r.ReadUInt16());
    /// <summary>
    /// Y-Value
    /// <summary>
    public static ReportAttribute YValue { get; } = zcl.Report(0x0002, "Y-Value", ZigbeeType.U16, r => r.ReadUInt16());
    /// <summary>
    /// Z-Value
    /// <summary>
    public static ReportAttribute ZValue { get; } = zcl.Report(0x0003, "Z-Value", ZigbeeType.U16, r => r.ReadUInt16());
}
