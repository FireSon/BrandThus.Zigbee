using System;
using System.Reflection;

namespace BrandThus.Zigbee
{
    public class ZigbeeCluster
    {
        #region Constructor
        public ZigbeeCluster(Type type)
        {
            var c = type.GetCustomAttribute<ClusterAttribute>();
            if (c != null)
                Id = c.ClusterId;
            Name = c != null ? c.Name : string.Empty;
        }
        #endregion

        #region Properties
        public ushort Id { get; set; }
        public string Name { get; set; }
        #endregion

        #region Analog attributes
        internal AnalogR<sbyte> S8R(ushort id, string name) => new AnalogR<sbyte>(this, id, name, ZigbeeType.S8, r => r.ReadSByte());
        internal AnalogRW<sbyte> S8RW(ushort id, string name) => new AnalogRW<sbyte>(this, id, name, ZigbeeType.S8, r => r.ReadSByte());
        internal AnalogW<sbyte> S8W(ushort id, string name) => new AnalogW<sbyte>(this, id, name, ZigbeeType.S8, r => r.ReadSByte());

        internal AnalogR<short> S16R(ushort id, string name) => new AnalogR<short>(this, id, name, ZigbeeType.S16, r => r.ReadInt16());
        internal AnalogRW<short> S16RW(ushort id, string name) => new AnalogRW<short>(this, id, name, ZigbeeType.S16, r => r.ReadInt16());
        internal AnalogW<short> S16W(ushort id, string name) => new AnalogW<short>(this, id, name, ZigbeeType.S16, r => r.ReadInt16());

        internal AnalogR<int> S24R(ushort id, string name) => new AnalogR<int>(this, id, name, ZigbeeType.S24, r => r.ReadInt24());

        internal AnalogR<int> S32R(ushort id, string name) => new AnalogR<int>(this, id, name, ZigbeeType.S32, r => r.ReadInt32());
        internal AnalogRW<int> S32RW(ushort id, string name) => new AnalogRW<int>(this, id, name, ZigbeeType.S32, r => r.ReadInt32());
        internal AnalogW<int> S32W(ushort id, string name) => new AnalogW<int>(this, id, name, ZigbeeType.S32, r => r.ReadInt32());

        internal AnalogR<byte> U8R(ushort id, string name) => new AnalogR<byte>(this, id, name, ZigbeeType.U8, r => r.ReadByte());
        internal AnalogRW<byte> U8RW(ushort id, string name) => new AnalogRW<byte>(this, id, name, ZigbeeType.U8, r => r.ReadByte());
        internal AnalogW<byte> U8W(ushort id, string name) => new AnalogW<byte>(this, id, name, ZigbeeType.U8, r => r.ReadByte());

        internal AnalogR<ushort> U16R(ushort id, string name) => new AnalogR<ushort>(this, id, name, ZigbeeType.U16, r => r.ReadUInt16());
        internal AnalogRW<ushort> U16RW(ushort id, string name) => new AnalogRW<ushort>(this, id, name, ZigbeeType.U16, r => r.ReadUInt16());
        internal AnalogW<ushort> U16W(ushort id, string name) => new AnalogW<ushort>(this, id, name, ZigbeeType.U16, r => r.ReadUInt16());

        internal AnalogR<uint> U24R(ushort id, string name) => new AnalogR<uint>(this, id, name, ZigbeeType.U24, r => r.ReadUInt24());
        internal AnalogRW<uint> U24RW(ushort id, string name) => new AnalogRW<uint>(this, id, name, ZigbeeType.U24, r => r.ReadUInt24());
        internal AnalogW<uint> U24W(ushort id, string name) => new AnalogW<uint>(this, id, name, ZigbeeType.U24, r => r.ReadUInt24());

        internal AnalogR<uint> U32R(ushort id, string name) => new AnalogR<uint>(this, id, name, ZigbeeType.U32, r => r.ReadUInt32());
        internal AnalogRW<uint> U32RW(ushort id, string name) => new AnalogRW<uint>(this, id, name, ZigbeeType.U32, r => r.ReadUInt32());
        internal AnalogW<uint> U32W(ushort id, string name) => new AnalogW<uint>(this, id, name, ZigbeeType.U32, r => r.ReadUInt32());

        internal AnalogR<ulong> U48R(ushort id, string name) => new AnalogR<ulong>(this, id, name, ZigbeeType.U48, r => r.ReadUInt48());
        internal AnalogW<ulong> U48W(ushort id, string name) => new AnalogW<ulong>(this, id, name, ZigbeeType.U48, r => r.ReadUInt48());

        internal AnalogR<Int64> UidR(ushort id, string name) => new AnalogR<Int64>(this, id, name, ZigbeeType.Uid, r => r.ReadInt64());
        internal AnalogRW<Int64> UidRW(ushort id, string name) => new AnalogRW<Int64>(this, id, name, ZigbeeType.Uid, r => r.ReadInt64());
        internal AnalogW<Int64> UidW(ushort id, string name) => new AnalogW<Int64>(this, id, name, ZigbeeType.Uid, r => r.ReadInt64());

        internal AnalogR<Single> FloatR(ushort id, string name) => new AnalogR<Single>(this, id, name, ZigbeeType.Float, r => r.ReadSingle());
        internal AnalogRW<Single> FloatRW(ushort id, string name) => new AnalogRW<Single>(this, id, name, ZigbeeType.Float, r => r.ReadSingle());
        internal AnalogW<Single> FloatW(ushort id, string name) => new AnalogW<Single>(this, id, name, ZigbeeType.Float, r => r.ReadSingle());
        #endregion

        #region Digital attributes
        internal DigitalR<T> Enum8R<T>(ushort id, string name) => new DigitalR<T>(this, id, name, ZigbeeType.S8, r => (T)Enum.ToObject(typeof(T), r.ReadByte()));
        internal DigitalRW<T> Enum8RW<T>(ushort id, string name) => new DigitalRW<T>(this, id, name, ZigbeeType.S8, r => (T)Enum.ToObject(typeof(T), r.ReadByte()));

        internal DigitalR<T> Enum16R<T>(ushort id, string name) => new DigitalR<T>(this, id, name, ZigbeeType.S16, r => (T)Enum.ToObject(typeof(T), r.ReadInt16()));
        internal DigitalRW<T> Enum16RW<T>(ushort id, string name) => new DigitalRW<T>(this, id, name, ZigbeeType.S16, r => (T)Enum.ToObject(typeof(T), r.ReadInt16()));

        internal DigitalR<string> CstringR(ushort id, string name) => new DigitalR<string>(this, id, name, ZigbeeType.Cstring, r => r.ReadString());
        internal DigitalRW<string> CstringRW(ushort id, string name) => new DigitalRW<string>(this, id, name, ZigbeeType.Cstring, r => r.ReadString());

        internal DigitalR<string> OstringR(ushort id, string name) => new DigitalR<string>(this, id, name, ZigbeeType.Ostring, r => r.ReadString());
        internal DigitalRW<string> OstringRW(ushort id, string name) => new DigitalRW<string>(this, id, name, ZigbeeType.Ostring, r => r.ReadString());

        internal DigitalR<string> LostringR(ushort id, string name) => new DigitalR<string>(this, id, name, ZigbeeType.Lostring, r => r.ReadString());

        internal DigitalR<bool> BoolR(ushort id, string name) => new DigitalR<bool>(this, id, name, ZigbeeType.Bool, r => r.ReadBool());
        internal DigitalRW<bool> BoolRW(ushort id, string name) => new DigitalRW<bool>(this, id, name, ZigbeeType.Bool, r => r.ReadBool());

        internal DigitalR<byte> Bmp8R(ushort id, string name) => new DigitalR<byte>(this, id, name, ZigbeeType.Bmp8, r => r.ReadByte());
        internal DigitalRW<byte> Bmp8RW(ushort id, string name) => new DigitalRW<byte>(this, id, name, ZigbeeType.Bmp8, r => r.ReadByte());

        internal DigitalR<ushort> Bmp16R(ushort id, string name) => new DigitalR<ushort>(this, id, name, ZigbeeType.Bmp16, r => r.ReadUInt16());
        internal DigitalRW<ushort> Bmp16RW(ushort id, string name) => new DigitalRW<ushort>(this, id, name, ZigbeeType.Bmp16, r => r.ReadUInt16());

        internal DigitalR<uint> Bmp24R(ushort id, string name) => new DigitalR<uint>(this, id, name, ZigbeeType.Bmp24, r => r.ReadUInt24());

        internal DigitalR<uint> Bmp32R(ushort id, string name) => new DigitalR<uint>(this, id, name, ZigbeeType.Bmp32, r => r.ReadUInt32());
        internal DigitalRW<uint> Bmp32RW(ushort id, string name) => new DigitalRW<uint>(this, id, name, ZigbeeType.Bmp32, r => r.ReadUInt32());

        internal DigitalRW<ushort> Dat16RW(ushort id, string name) => new DigitalRW<ushort>(this, id, name, ZigbeeType.Dat16, r => r.ReadUInt16());

        internal DigitalR<byte[]> ArrayR(ushort id, string name) => new DigitalR<byte[]>(this, id, name, ZigbeeType.Array, r => r.ReadArray());
        internal DigitalRW<byte[]> ArrayRW(ushort id, string name) => new DigitalRW<byte[]>(this, id, name, ZigbeeType.Array, r => r.ReadArray());

        internal DigitalR<DateTime> UtcR(ushort id, string name) => new DigitalR<DateTime>(this, id, name, ZigbeeType.Utc, r => r.ReadDateTime());
        internal DigitalRW<DateTime> UtcRW(ushort id, string name) => new DigitalRW<DateTime>(this, id, name, ZigbeeType.Utc, r => r.ReadDateTime());

        internal DigitalRW<string> SeckeyRW(ushort id, string name) => new DigitalRW<string>(this, id, name, ZigbeeType.Seckey, r => r.ReadString());
        internal DigitalR<string> SeckeyR(ushort id, string name) => new DigitalR<string>(this, id, name, ZigbeeType.Seckey, r => r.ReadString());
        #endregion

        #region Request indexer
        internal ZigbeeRequest this[ZigbeeNode node, byte id, Func<ZigbeeWriter, ZigbeeWriter>? write = null] =>
            node.ZclRequest(this, id, write);
        #endregion
    }

    #region ClusterAttribute
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class ClusterAttribute : Attribute
    {
        #region Constructor
        public ClusterAttribute(ushort clusterId, string name)
        {
            ClusterId = clusterId;
            Name = name;
        } 
        #endregion

        #region Properties
        public ushort ClusterId { get; set; } 
        public string Name { get; set; }
        #endregion
    }
    #endregion
}
