using System;

namespace BrandThus.Zigbee.Zdo
{
    public class PowerDescriptor
    {
        #region Constructor
        public PowerDescriptor(ZigbeeReader r)
        {
            BitsFlag = r.ReadUInt16();
        }
        #endregion

        #region Properties
        public ushort BitsFlag;
        public PowerSourceLevel CurrentPowerSourceLevel => (PowerSourceLevel)((BitsFlag & 0xF000) >> 12);
        public PowerSource CurrentPowerSource => (PowerSource)((BitsFlag & 0xF00) >> 8);
        public PowerSource AvailablePowerSource => (PowerSource)((BitsFlag & 0xF0) >> 4);
        public PowerMode CurrentPowerMode => (PowerMode)(BitsFlag & 0xF);
        #endregion

        #region ToString
        public override string ToString() => $"{CurrentPowerSourceLevel} {CurrentPowerSource} {AvailablePowerSource} {CurrentPowerMode}"; 
        #endregion
    }

    #region PowerSource
    [Flags]
    public enum PowerSource
    {
        Unknown = 0,
        PermanentMains = 1,
        RechargeableBattery = 2,
        DisposableBattery = 4,
        Reserved = 8
    }
    #endregion

    #region PowerMode
    public enum PowerMode
    {
        ReceiverOnWhenIdle,
        ReceiverOnPeriodically,
        ReceiverOnWhenStimulated,
        Reserved
    }
    #endregion

    #region PowerSourceLevel
    public enum PowerSourceLevel
    {
        CriticalLow = 0,
        Low = 4,
        High = 8,
        FullyCharged = 12
    } 
    #endregion
}