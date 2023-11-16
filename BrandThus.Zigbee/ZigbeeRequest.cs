using System;
using System.Text;
using System.Threading.Tasks;

namespace BrandThus.Zigbee
{
    public abstract class ZigbeeRequest
    {
        #region Constructor
        public ZigbeeRequest(Func<ZigbeeWriter, ZigbeeWriter>? write = null)
        {
            Write = write;
        }
        #endregion

        #region Properties
        internal ZigbeeNode Dst = default!;
        internal byte DstEndPoint;
        internal ZigbeeNode Src = default!;
        internal byte SrcEndPoint;
        internal ushort ClusterId;
        internal ushort ProfileId;
        internal byte Options;
        internal byte Radius = 30;
        internal byte TransactionId;
        internal TaskCompletionSource<bool>? TaskSource;
        internal byte Retry = 0;
        protected Func<ZigbeeWriter, ZigbeeWriter>? Write;
        #endregion

        #region WriteRequest
        internal void WriteRequest(ZigbeeWriter w)
        {
            w.Length = 0;
            w.Write(TransactionId);
            w.Write((byte)0);
            if (Dst.Addr64 != 0L)
            {
                w.Write((byte)3);
                w.WriteUInt64(Dst.Addr64);
            }
            else
            {
                w.Write((byte)2);
                w.WriteUInt16(Dst.Addr16);
            }
            w.Write(DstEndPoint);
            w.WriteUInt16(ProfileId);
            w.WriteUInt16(ClusterId);
            w.Write(SrcEndPoint);
            ushort idx = w.Length;
            w.Length += 2;
            WritePayLoad(w);
            ushort frameLength = (ushort)(w.Length - idx - 2);
            w[idx] = (byte)frameLength;
            w[++idx] = (byte)(frameLength >> 8);
            w.Write(Options);
            w.Write(Radius);
        }
        #endregion

        #region WritePayload
        internal abstract void WritePayLoad(ZigbeeWriter writer);
        #endregion

        #region SendAsync
        public Task SendAsync() => Dst.Manager.SendAsync(this);
        #endregion

        #region Enqueue
        public void Enqueue() => Dst.Requests.Add(this);
        #endregion
    }
}
