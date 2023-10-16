namespace BrandThus.Zigbee;

public abstract class ZigbeeRequest(Func<ZigbeeWriter, ZigbeeWriter>? write = null)
{
    #region Properties
    internal ZigbeeNode Dst = default!;
    internal ZigBeeAddressMode DstMode = ZigBeeAddressMode.Nwk;
    internal byte DstEndPoint;
    internal ZigbeeNode Src = default!;
    internal ZigBeeAddressMode SrcMode = ZigBeeAddressMode.Nwk;
    internal byte SrcEndPoint;
    internal ushort ClusterId;
    internal ushort ProfileId;
    internal byte Options;
    internal byte Radius = 31;
    internal byte TransactionId;
    internal TaskCompletionSource<bool> TaskSource = new();
    internal byte Retry = 0;
    protected Func<ZigbeeWriter, ZigbeeWriter>? write = write;
    #endregion

    #region WritePayload
    internal abstract void WritePayLoad(ZigbeeWriter writer);
    #endregion

    #region SendAsync
    public Task SendAsync() => Src.Manager.SendAsync(this); 
    #endregion
}

#region ZigBeeAddressMode
public enum ZigBeeAddressMode
{
    None,
    Group,
    Nwk,
    Ieee,
    NwkAndIeee
} 
#endregion
