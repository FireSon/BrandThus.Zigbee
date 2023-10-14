using BrandThus.Zigbee.Types;
using BrandThus.Zigbee.Zdo;
using System.Text;

namespace BrandThus.Zigbee;

public abstract class ZigbeeReader
{
    #region Properties
    public bool IsReady => Offset >= Payload;

    internal byte[] Buffer = new byte[1024];
    internal int Payload;
    internal int Offset;
    internal int Length;
    #endregion

    #region Indexer
    public byte this[int index] => Buffer[index];
    #endregion

    #region Read routines
    public byte ReadByte() => Buffer[Offset++];
    public byte[] ReadBytes(int length)
    {
        byte[] result = Buffer.Skip(Offset).Take(length).ToArray();
        Offset += length;
        return result;
    }
    public ZdoStatus ReadStatus() => (ZdoStatus)ReadByte();
    public Int24 ReadInt24() => IZigbeeType.Read<Int24>(this, 3);
    public Int40 ReadInt40() => IZigbeeType.Read<Int40>(this, 5);
    public Int48 ReadInt48() => IZigbeeType.Read<Int48>(this, 6);
    public Int56 ReadInt56() => IZigbeeType.Read<Int56>(this, 7);
    public UInt24 ReadUInt24() => IZigbeeType.Read<UInt24>(this, 3);
    public UInt40 ReadUInt40() => IZigbeeType.Read<UInt40>(this, 5);
    public UInt48 ReadUInt48() => IZigbeeType.Read<UInt48>(this, 6);
    public UInt56 ReadUInt56() => IZigbeeType.Read<UInt56>(this, 7);

    private T Read<T>(Func<byte[], int, T> read, byte size)
    {
        var result = read(Buffer, Offset);
        Offset += size;
        return result;
    }

    public short ReadInt16() => Read(BitConverter.ToInt16, 2);
    public ushort ReadUInt16() => Read(BitConverter.ToUInt16, 2);
    public int ReadInt32() => Read(BitConverter.ToInt32, 4);
    public uint ReadUInt32() => Read(BitConverter.ToUInt32, 4);
    public long ReadInt64() => Read(BitConverter.ToInt64, 8);
    public ulong ReadUInt64() => Read(BitConverter.ToUInt64, 8);
    public bool ReadBool() => ReadByte() != 0;

    public string ReadString(int size) => Encoding.Default.GetString(ReadBytes(size));
    #endregion

    #region Clear
    public void Clear() => Offset = 0;
    #endregion

    #region Add
    public void Add(byte v) => Buffer[Offset++] = v;
    #endregion
}


