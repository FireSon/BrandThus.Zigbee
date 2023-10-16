namespace BrandThus.Zigbee.Zdo;

public class ZdoRequest(Func<ZigbeeWriter, ZigbeeWriter>? write = null) : ZigbeeRequest(write)
{
    #region WritePayLoad
    internal override void WritePayLoad(ZigbeeWriter writer)
    {
        writer.WriteByte(TransactionId);
        write?.Invoke(writer);
    } 
    #endregion
}

public enum ZigBeeAddressMode
{
    None,
    Group,
    Nwk,
    Ieee,
    NwkAndIeee
}
