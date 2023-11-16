namespace BrandThus.Zigbee.Zcl;

public class ZclRequest(Func<ZigbeeWriter, ZigbeeWriter>? write = null) : ZigbeeRequest(write)
{
    #region Properties
    internal ZclCommandDirection Direction;
    internal ZclFrameType FrameType;
    internal byte CommandId;
    internal bool DisableDefaultResponse;
    #endregion

    #region WritePayload
    internal override void WritePayLoad(ZigbeeWriter writer)
    {
        writer.WriteByte((byte)((byte)FrameType | ((Direction == ZclCommandDirection.SERVER_TO_CLIENT) ? 8 : 0)) | (DisableDefaultResponse ? 16 : 0));
        writer.WriteByte(TransactionId);
        writer.WriteByte(CommandId);
        write?.Invoke(writer);
    }
    #endregion
}
