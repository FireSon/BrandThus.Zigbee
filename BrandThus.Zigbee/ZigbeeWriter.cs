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
    public static ZigbeeWriter operator +(ZigbeeWriter w, byte v) { w.Write(v); return w; }
    public static ZigbeeWriter operator +(ZigbeeWriter w, byte[] v) { w.Write(v); return w; }
    public static ZigbeeWriter operator +(ZigbeeWriter w, int v) { w.Write(v); return w; }
    public static ZigbeeWriter operator +(ZigbeeWriter w, uint v) { w.Write(v); return w; }
    public static ZigbeeWriter operator +(ZigbeeWriter w, long v) { w.Write(v); return w; }
    public static ZigbeeWriter operator +(ZigbeeWriter w, ulong v) { w.Write(v); return w; }
    public static ZigbeeWriter operator +(ZigbeeWriter w, ushort v) { w.Write(v); return w; }
    public static ZigbeeWriter operator +(ZigbeeWriter w, bool v) { w.Write(v); return w; }
    public static ZigbeeWriter operator +(ZigbeeWriter w, string v) { w.Write(v); return w; }
    public static ZigbeeWriter operator +(ZigbeeWriter w, DateTime v) { w.Write(v); return w; }
    public static ZigbeeWriter operator +(ZigbeeWriter w, IZigbeeType v) { v.Write(w); return w; }

    public static ZigbeeWriter operator +(ZigbeeWriter w, List<byte> v)
    {
        w.Write((ushort)v.Count);
        foreach (byte e in v)
            w.WriteByte(e);
        return w;
    }
    public static ZigbeeWriter operator +(ZigbeeWriter w, List<ushort> v)
    {
        w.Write((ushort)v.Count);
        foreach (ushort e in v)
            w.Write(e);
        return w;
    }
    #endregion

    #region Write routines
    private void Write(byte b) => Buffer[Length++] = b;
    public void Write(params byte[] values) => Array.ForEach(values, Write);
    public void WriteByte(int value) => Write((byte)value);
    public void Write(bool value) => Write((byte)(value ? 1 : 0));
    public void Write(short value) => Write((byte)value, (byte)(value >> 8));
    public void Write(ushort value) => Write((byte)value, (byte)(value >> 8));
    public void Write(int value) => Write((byte)value, (byte)(value >> 8), (byte)(value >> 16), (byte)(value >> 24));
    public void Write(uint value) => Write((byte)value, (byte)(value >> 8), (byte)(value >> 16), (byte)(value >> 24));
    public void Write(long value) => Write((byte)value, (byte)(value >> 8), (byte)(value >> 16), (byte)(value >> 24), (byte)(value >> 32), (byte)(value >> 40), (byte)(value >> 48), (byte)(value >> 56));
    public void Write(ulong value) => Write((byte)value, (byte)(value >> 8), (byte)(value >> 16), (byte)(value >> 24), (byte)(value >> 32), (byte)(value >> 40), (byte)(value >> 48), (byte)(value >> 56));
    public void Write(DateTime value) { Console.WriteLine(value); }
    public void Write(string value) 
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