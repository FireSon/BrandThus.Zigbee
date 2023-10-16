using BrandThus.Zigbee.Types;
using System.Text;

namespace BrandThus.Zigbee;

public abstract class ZigbeeWriter
{
    #region Properties
    internal readonly byte[] Buffer = new byte[1024];
    internal ushort Length;
    #endregion

    #region Overloads
    public static ZigbeeWriter operator +(ZigbeeWriter w, byte v) { w.WriteByte(v); return w; }
    public static ZigbeeWriter operator +(ZigbeeWriter w, byte[] v) { w.Write(v); return w; }
    public static ZigbeeWriter operator +(ZigbeeWriter w, int v) { w.WriteInt32(v); return w; }
    public static ZigbeeWriter operator +(ZigbeeWriter w, uint v) { w.WriteUInt32(v); return w; }
    public static ZigbeeWriter operator +(ZigbeeWriter w, long v) { w.WriteInt64(v); return w; }
    public static ZigbeeWriter operator +(ZigbeeWriter w, ulong v) { w.WriteUInt64(v); return w; }
    public static ZigbeeWriter operator +(ZigbeeWriter w, ushort v) { w.WriteUInt16(v); return w; }
    public static ZigbeeWriter operator +(ZigbeeWriter w, bool v) { w.WriteBool(v); return w; }
    public static ZigbeeWriter operator +(ZigbeeWriter w, string v) { w.WriteString(v); return w; }
    public static ZigbeeWriter operator +(ZigbeeWriter w, DateTime v) { w.WriteDateTime(v); return w; }
    public static ZigbeeWriter operator +(ZigbeeWriter w, IZigbeeType v) { v.Write(w); return w; }

    public static ZigbeeWriter operator +(ZigbeeWriter w, List<byte> v)
    {
        w.WriteUInt16((ushort)v.Count);
        foreach (byte e in v)
            w.WriteByte((int)e);
        return w;
    }
    public static ZigbeeWriter operator +(ZigbeeWriter w, List<ushort> v)
    {
        w.WriteUInt16((ushort)v.Count);
        foreach (ushort e in v)
            w.WriteUInt16(e);
        return w;
    }
    #endregion

    #region Write routines
    private void WriteByte(byte b) => Buffer[Length++] = b;
    public void Write(params byte[] values) => Array.ForEach(values, WriteByte);
    public void WriteByte(int value) => WriteByte((byte)value);
    public void WriteBool(bool value) => WriteByte((byte)(value ? 1 : 0));
    public void WriteInt16(short value) => Write((byte)value, (byte)(value >> 8));
    public void WriteUInt16(ushort value) => Write((byte)value, (byte)(value >> 8));
    public void WriteInt32(int value) => Write((byte)value, (byte)(value >> 8), (byte)(value >> 16), (byte)(value >> 24));
    public void WriteUInt32(uint value) => Write((byte)value, (byte)(value >> 8), (byte)(value >> 16), (byte)(value >> 24));
    public void WriteInt64(long value) => Write((byte)value, (byte)(value >> 8), (byte)(value >> 16), (byte)(value >> 24), (byte)(value >> 32), (byte)(value >> 40), (byte)(value >> 48), (byte)(value >> 56));
    public void WriteUInt64(ulong value) => Write((byte)value, (byte)(value >> 8), (byte)(value >> 16), (byte)(value >> 24), (byte)(value >> 32), (byte)(value >> 40), (byte)(value >> 48), (byte)(value >> 56));
    public void WriteDateTime(DateTime value) { Console.WriteLine(value); }
    public void WriteString(string value) 
    {
        var b = Encoding.ASCII.GetBytes(value);
        WriteByte(b.Length);
        Write(b);
    }
    #endregion

    #region WriteRequest
    internal abstract void WriteRequest(ZigbeeRequest rq); 
    #endregion
}