namespace BrandThus.Zigbee.Descriptors;

public record PowerDescriptor(ushort BitsFlag)
{
    public PowerSourceLevel CurrentPowerSourceLevel => (PowerSourceLevel)((BitsFlag & 0xF000) >> 12);

    public PowerSource CurrentPowerSource => (PowerSource)((BitsFlag & 0xF00) >> 8);

    public PowerSource AvailablePowerSource => (PowerSource)((BitsFlag & 0xF0) >> 4);

    public PowerMode CurrentPowerMode => (PowerMode)(BitsFlag & 0xF);

    public override string ToString()
    {
        return BitsFlag.ToString("X4");
    }
}

[Flags]
public enum PowerSource
{
    Unknown = 0,
    PermanentMains = 1,
    RechargeableBattery = 2,
    DisposableBattery = 4,
    Reserved = 8
}

public enum PowerMode
{
    ReceiverOnWhenIdle,
    ReceiverOnPeriodically,
    ReceiverOnWhenStimulated,
    Reserved
}

public enum PowerSourceLevel
{
    CriticalLow = 0,
    Low = 4,
    High = 8,
    FullyCharged = 12
}
