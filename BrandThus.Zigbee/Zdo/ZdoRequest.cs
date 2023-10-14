namespace BrandThus.Zigbee.Zdo;

public class ZdoRequest(Func<ZigbeeWriter, ZigbeeWriter>? write = null) : ZigbeeRequest(write)
{
    internal override void WritePayLoad(ZigbeeWriter writer)
    {
        throw new NotImplementedException();
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
