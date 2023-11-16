namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// BOSCH Thermotechnik indoor air quality
/// <summary>
[Cluster(0xfdef, "AIR Measurement")]
public static class ZclAIRMeasurement
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclAIRMeasurement));

    /// <summary>
    /// Air pressure (mBar)
    /// <summary>
    public static ReportAttribute AirPressure { get; } = zcl.Report(0x4001, "Air pressure", ZigbeeType.U16, r => r.ReadUInt16());
    /// <summary>
    /// Temperature (°C)
    /// <summary>
    public static ReportAttribute Temperature { get; } = zcl.Report(0x4002, "Temperature", ZigbeeType.S16, r => r.ReadInt16());
    /// <summary>
    /// Relative humidity (%)
    /// <summary>
    public static ReportAttribute Humidity { get; } = zcl.Report(0x4003, "Humidity", ZigbeeType.U8, r => r.ReadByte());
    /// <summary>
    /// Air quality VOC (ppm)
    /// <summary>
    public static ReportAttribute AirQuality { get; } = zcl.Report(0x4004, "Air quality", ZigbeeType.U16, r => r.ReadUInt16());
    /// <summary>
    /// Ambient light brightness (lux)
    /// <summary>
    public static ReportAttribute Brightness { get; } = zcl.Report(0x4005, "Brightness", ZigbeeType.U16, r => r.ReadUInt16());
    /// <summary>
    /// Noise level (dB)
    /// <summary>
    public static ReportAttribute Loudness { get; } = zcl.Report(0x4006, "Loudness", ZigbeeType.U8, r => r.ReadByte());
    /// <summary>
    /// Relative timestamp since start(seconds)
    /// <summary>
    public static ReportAttribute timestamp { get; } = zcl.Report(0x4008, "timestamp", ZigbeeType.U32, r => r.ReadUInt32());
    public enum TriggerEnum
    {
        ByTimer = 0x00,
        ByDoubleTap = 0x01,
    }

    /// <summary>
    /// Trigger of this measurement
    /// <summary>
    public static ReportAttribute Trigger { get; } = zcl.Report(0x4009, "Trigger", ZigbeeType.Enum8, r => (TriggerEnum)r.ReadByte());
    public enum ModeOfOperationEnum
    {
        NormalDayMode = 0x00,
        NightUpSideDown = 0x01,
    }

    /// <summary>
    /// Device orientation
    /// <summary>
    public static ReportAttribute ModeOfOperation { get; } = zcl.Report(0x400B, "ModeOfOperation", ZigbeeType.Enum8, r => (ModeOfOperationEnum)r.ReadByte());
}
