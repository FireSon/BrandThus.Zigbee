using System;
using System.Text;

namespace BrandThus.Zigbee
{
    public class ZigbeeWriter
    {
        #region Properties
        internal readonly byte[] Buffer = new byte[1024];
        internal ushort Length;
        #endregion

        #region Indexer
        public byte this[int index] { set => Buffer[index] = value; }
        #endregion

        #region Overloads
        public static ZigbeeWriter operator +(ZigbeeWriter w, byte v) { w.writeByte(v); return w; }
        public static ZigbeeWriter operator +(ZigbeeWriter w, byte[] v) { w.Write(v); return w; }
        public static ZigbeeWriter operator +(ZigbeeWriter w, int v) { w.WriteInt32(v); return w; }
        public static ZigbeeWriter operator +(ZigbeeWriter w, uint v) { w.WriteUInt32(v); return w; }
        public static ZigbeeWriter operator +(ZigbeeWriter w, long v) { w.WriteInt64(v); return w; }
        public static ZigbeeWriter operator +(ZigbeeWriter w, ulong v) { w.WriteUInt64(v); return w; }
        public static ZigbeeWriter operator +(ZigbeeWriter w, ushort v) { w.WriteUInt16(v); return w; }
        public static ZigbeeWriter operator +(ZigbeeWriter w, bool v) { w.WriteBool(v); return w; }
        public static ZigbeeWriter operator +(ZigbeeWriter w, string v) { w.WriteString(v); return w; }
        public static ZigbeeWriter operator +(ZigbeeWriter w, UInt24 v) { w.WriteUInt24(v.Value); return w; }
        public static ZigbeeWriter operator +(ZigbeeWriter w, DateTime v) { w.WriteDateTime(v); return w; }
        #endregion

        #region Write routines
        private void writeByte(byte b) => Buffer[Length++] = b;
        public void Write(params byte[] values) => Array.ForEach(values, writeByte);
        public void WriteByte(int value) => writeByte((byte)value);
        public void WriteSByte(sbyte value) => writeByte((byte)value);
        public void WriteBool(bool value) => writeByte((byte)(value ? 1 : 0));
        public void WriteInt16(short value) => Write((byte)value, (byte)(value >> 8));
        public void WriteUInt16(ushort value) => Write((byte)value, (byte)(value >> 8));
        public void WriteUInt24(uint value) => Write((byte)value, (byte)(value >> 8), (byte)(value >> 16));
        public void WriteInt24(int value) => Write((byte)value, (byte)(value >> 8), (byte)(value >> 16));
        public void WriteInt32(int value) => Write((byte)value, (byte)(value >> 8), (byte)(value >> 16), (byte)(value >> 24));
        public void WriteUInt32(uint value) => Write((byte)value, (byte)(value >> 8), (byte)(value >> 16), (byte)(value >> 24));
        public void WriteInt64(long value) => Write((byte)value, (byte)(value >> 8), (byte)(value >> 16), (byte)(value >> 24), (byte)(value >> 32), (byte)(value >> 40), (byte)(value >> 48), (byte)(value >> 56));
        public void WriteUInt48(ulong value) => Write((byte)value, (byte)(value >> 8), (byte)(value >> 16), (byte)(value >> 24), (byte)(value >> 32), (byte)(value >> 40));
        public void WriteUInt64(ulong value) => Write((byte)value, (byte)(value >> 8), (byte)(value >> 16), (byte)(value >> 24), (byte)(value >> 32), (byte)(value >> 40), (byte)(value >> 48), (byte)(value >> 56));
        public void WriteDateTime(DateTime value) => Write(0);
        public void WriteSingle(Single value) { }
        public void WriteString(string value)
        {
            var b = Encoding.ASCII.GetBytes(value);
            WriteByte(b.Length);
            Write(b);
        } 
        #endregion
    }
}
