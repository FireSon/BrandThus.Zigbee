using System;

namespace BrandThus.Zigbee.Conbee;

internal class ConbeeWriter : ZigbeeWriter
{
    internal void WritePayload(Action<byte> write)
    {
        for (int i = 0; i < Length; i++)
        {
            write(Buffer[i]);
        }
    }

    internal override void WriteRequest(ZigbeeRequest rq)
    {
        Length = 0;
        Write(rq.TransactionId);
        Write((byte)0);
        if (rq.Dst.Addr64 != 0L)
        {
            Write((byte)3);
            Write(rq.Dst.Addr64);
        }
        else
        {
            Write((byte)2);
            Write(rq.Dst.Addr16);
        }
        Write(rq.DstEndPoint);
        Write(rq.ProfileId);
        Write(rq.ClusterId);
        Write(rq.SrcEndPoint);
        ushort idx = Length;
        Length += 2;
        rq.WritePayLoad(this);
        ushort frameLength = (ushort)(Length - idx - 2);
        Buffer[idx] = (byte)frameLength;
        Buffer[++idx] = (byte)(frameLength >> 8);
        Write(rq.Options);
        Write(rq.Radius);
    }
}
