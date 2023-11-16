using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrandThus.Zigbee
{
    #region ZigbeeAttribute
    public abstract class ZigbeeAttribute
    {
        #region Constructor
        internal ZigbeeAttribute(ZigbeeCluster cluster, ushort id, string name, ZigbeeType type)
        {
            Cluster = cluster;
            AttrId = id;
            Name = name;
            Type = type;
            Attributes[id + (cluster.Id << 16)] = this;
        }
        #endregion

        #region Properties
        public ZigbeeCluster Cluster { get; set; }
        public ushort AttrId { get; set; }
        public string Name { get; set; }
        public ZigbeeType Type { get; set; }

        internal static Dictionary<int, ZigbeeAttribute> Attributes = new Dictionary<int, ZigbeeAttribute>();
        #endregion

        #region Read
        internal abstract object Read(ZigbeeReader reader);
        #endregion
    }

    public class ZigbeeAttribute<T> : ZigbeeAttribute
    {
        #region Constructor
        internal ZigbeeAttribute(ZigbeeCluster cluster, ushort id, string name, ZigbeeType type, Func<ZigbeeReader, T> read) : 
            base(cluster, id, name, type) => ReadValue = read;
        #endregion

        #region Properties
        internal Func<ZigbeeReader, T> ReadValue;
        internal override object Read(ZigbeeReader reader) => ReadValue(reader);
        #endregion
    }
    #endregion

    #region IReadable
    public interface IReadable
    {
        public ZigbeeCluster Cluster { get; }
        public ushort AttrId { get; }
    }
    #endregion

    #region Attributes
    public class Attributes : List<IReadable>
    {
        public void Read(ZigbeeNode node) => node.Read(this.ToArray());
    }
    #endregion

    #region Analog
    public class Analog<T> : ZigbeeAttribute<T>
    {
        internal Analog(ZigbeeCluster cluster, ushort id, string name, ZigbeeType type, Func<ZigbeeReader, T> read, Action<ZigbeeWriter, T> write) :
            base(cluster, id, name, type, read) => Write = write;
        internal Action<ZigbeeWriter, T> Write;
        
        public void Report(ZigbeeNode node, ushort minTime, ushort maxTime, T t) => node.Report(this, minTime, maxTime, t);
    }

    public class AnalogR<T> : Analog<T>, IReadable
    {
        internal AnalogR(ZigbeeCluster cluster, ushort id, string name, ZigbeeType type, Func<ZigbeeReader, T> read, Action<ZigbeeWriter, T> write) : 
            base(cluster, id, name, type, read, write) { }

        #region Overloads
        public static Attributes operator +(AnalogR<T> a1, IReadable a2) => new Attributes() { a1, a2 };
        public static Attributes operator +(Attributes l, AnalogR<T> a) { l.Add(a); return l; }
        #endregion

        public void Read(ZigbeeNode node) => node.Read(this);
        public Task ReportAsync(ZigbeeNode node, ushort minTime, ushort maxTime, T t) => node.ReportAsync(this, minTime, maxTime, t);
        public Task<T> ReadAsync(ZigbeeNode node) => node.ReadAsync(this);
    }
    public class AnalogRW<T> : AnalogR<T>
    {
        internal AnalogRW(ZigbeeCluster cluster, ushort id, string name, ZigbeeType type, Func<ZigbeeReader, T> read, Action<ZigbeeWriter, T> write) :
            base(cluster, id, name, type, read, write)
        { }
    }
    public class AnalogW<T> : Analog<T>
    {
        internal AnalogW(ZigbeeCluster cluster, ushort id, string name, ZigbeeType type, Func<ZigbeeReader, T> read, Action<ZigbeeWriter, T> write) :
            base(cluster, id, name, type, read, write)
        { }
    }
    #endregion

    #region Digital
    public class DigitalR<T> : ZigbeeAttribute<T>, IReadable
    {
        internal DigitalR(ZigbeeCluster cluster, ushort id, string name, ZigbeeType type, Func<ZigbeeReader, T> read) : base(cluster, id, name, type, read) { }

        #region Overloads
        public static Attributes operator +(DigitalR<T> a1, IReadable a2) => new Attributes() { a1, a2 };
        public static Attributes operator +(Attributes l, DigitalR<T> a) { l.Add(a); return l; }
        #endregion

        public void Report(ZigbeeNode node, ushort minTime, ushort maxTime) => node.Report(this, minTime, maxTime);
        public Task ReportAsync(ZigbeeNode node, ushort minTime, ushort maxTime) => node.ReportAsync(this, minTime, maxTime);
        public void Read(ZigbeeNode node) => node.Read(this);
        public Task<T> ReadAsync(ZigbeeNode node) => node.ReadAsync(this);
    }
    public class DigitalRW<T> : DigitalR<T>
    {
        internal DigitalRW(ZigbeeCluster cluster, ushort id, string name, ZigbeeType type, Func<ZigbeeReader, T> read) : base(cluster, id, name, type, read) { }
        public void Write(ZigbeeNode node, T t) => node.Write(this, t);
    } 
    #endregion
}
