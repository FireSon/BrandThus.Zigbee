namespace BrandThus.Zigbee.Zdo;

public class ZdoRequest(Func<ZigbeeWriter, ZigbeeWriter>? write = null) : ZigbeeRequest(write)
{
    internal override void WritePayLoad(ZigbeeWriter writer)
    {
        writer.WriteByte(TransactionId);
        write?.Invoke(writer);
    }
}

public enum ZigBeeAddressMode
{
    None,
    Group,
    Nwk,
    Ieee,
    NwkAndIeee
}
