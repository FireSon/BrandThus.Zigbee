using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrandThus.Zigbee
{
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
        //public void Read(params byte[] values) => Array.ForEach(values, ReadByte);
        public sbyte ReadSByte() => (sbyte)ReadByte();
        public bool ReadBool() => ReadByte() != 0;
        public short ReadInt16() => (short)(Buffer[Offset++] + (Buffer[Offset++] << 8));
        public ushort ReadUInt16() => (ushort)(Buffer[Offset++] + (Buffer[Offset++] << 8));
        public uint ReadUInt24() => (uint)(Buffer[Offset++] + (Buffer[Offset++] << 8) + (Buffer[Offset++] << 16));
        public int ReadInt24() => (Buffer[Offset++] + (Buffer[Offset++] << 8) + (Buffer[Offset++] << 16));
        public int ReadInt32() => (int)(Buffer[Offset++] + (Buffer[Offset++] << 8) + (Buffer[Offset++] << 16) + (Buffer[Offset++] << 24));
        public uint ReadUInt32() => (uint)(Buffer[Offset++] + (Buffer[Offset++] << 8) + (Buffer[Offset++] << 16) + (Buffer[Offset++] << 24));
        public ulong ReadUInt48() => (ulong)(Buffer[Offset++] + (Buffer[Offset++] << 8) + (Buffer[Offset++] << 16) + (Buffer[Offset++] << 24) + (Buffer[Offset++] << 32) + (Buffer[Offset++] << 40));
        public long ReadInt64() => (long)(Buffer[Offset++] + (Buffer[Offset++] << 8) + (Buffer[Offset++] << 16) + (Buffer[Offset++] << 24) + (Buffer[Offset++] << 32) + (Buffer[Offset++] << 40) + (Buffer[Offset++] << 48) + (Buffer[Offset++] << 56));
        public ulong ReadUInt64() => (ulong)(Buffer[Offset++] + (Buffer[Offset++] << 8) + (Buffer[Offset++] << 16) + (Buffer[Offset++] << 24) + (Buffer[Offset++] << 32) + (Buffer[Offset++] << 40) + (Buffer[Offset++] << 48) + (Buffer[Offset++] << 56));
        public DateTime ReadDateTime() => DateTime.Now;
        public Single ReadSingle() => 1;

        public byte[] ReadBytes(int length)
        {
            byte[] result = Buffer.Skip(Offset).Take(length).ToArray();
            Offset += length;
            return result;
        }
        public string ReadString(int size) => Encoding.ASCII.GetString(ReadBytes(size));
        public string ReadString() => ReadString(ReadByte());
        public byte[] ReadArray() => ReadBytes(ReadByte());
        public List<T> ReadList<T>(Func<ZigbeeReader, T> read)
        {
            int size = ReadByte();
            var result = new List<T>(size);
            while (size-- > 0)
                result.Add(read(this));
            return result;
        }
        #endregion

        #region Clear
        public void Clear() => Offset = 0;
        #endregion

        #region Add
        public void Add(byte v) => Buffer[Offset++] = v;
        #endregion
    }
}