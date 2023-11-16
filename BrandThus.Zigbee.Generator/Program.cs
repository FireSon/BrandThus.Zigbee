using BrandThus.Zigbee.Generator;
using System.Text;
using System.Xml;
using System.Xml.Linq;

Console.WriteLine("Generate Zigbee Clusters!");

var xmlDoc = new XmlDocument();
xmlDoc.Load(Path.Combine("..", "..", "..", "general.xml"));

var sb = new StringBuilder();
foreach (XmlNode cl in xmlDoc.GetElementsByTagName("cluster"))
{
    if (cl.Attributes.GetNamedItem("id") is not XmlNode id ||
        cl.Attributes.GetNamedItem("name") is not XmlNode name)
        continue;
    if (name.Value.Contains("specific") || id.Value == "0xfc03")
        continue;

    var descr = cl.SelectSingleNode("description");
    var server = cl.SelectSingleNode("server");
    var client = cl.SelectSingleNode("client");
    if (!(server?.ChildNodes.Count > 0 || client?.ChildNodes.Count > 0))
        continue;

    var clusterName = name.Value?.Property();
    sb.Clear();
    
    var classname = "Zcl" + clusterName;
    sb.AppendLine("namespace BrandThus.Zigbee.Clusters;");
    sb.AppendLine();

    if (descr != null)
        sb.Comment(descr.InnerText);
    sb.Code($"[Cluster({id.Value}, \"{name.Value}\")]");
    sb.Code($"public static class {classname}");
    sb.Indent();
    sb.Code($"private static readonly ZigbeeCluster zcl = new(typeof({classname}));");
    sb.AppendLine();

    bool isFirst = true;
    bool isCommand = false;
    string prefix = "";
    string suffix = "";
    var attrb = new List<string>();
    if (server != null)
    {
        foreach (XmlNode c in server.ChildNodes)
            doNodes(c);
        isCommand = true;
        if (!isFirst) sb.AppendLine(); 
        foreach (XmlNode c in server.ChildNodes)
            doNodes(c);
    }
    if (client?.ChildNodes.Count > 0)
    {
        sb.AppendLine();
        foreach (XmlNode c in client.ChildNodes)
            doNodes(c);
    }
    void doNodes(XmlNode n)
    {
        string attr(string name) => n.Attributes?.GetNamedItem(name)?.Value ?? string.Empty;
        string nattr(string name) => attr(name).Property();
        string load(string cast) => attr("type") switch
        {
            "cstring" => "r => r.ReadString()",
            "ostring" => "r => r.ReadString()",
            "lostring" => "r => r.ReadString()",
            "seckey" => "r => r.ReadString()",
            "bool" => "r => r.ReadBool()",
            "bmp8" => "r => r.ReadByte()",
            "bmp16" => "r => r.ReadInt16()",
            "bmp24" => "r => r.ReadInt24()",
            "bmp32" => "r => r.ReadInt32()",
            "dat16" => "r => r.ReadInt16()",

            "enum8" => $"r => ({cast})r.ReadByte()",
            "enum16" => $"r => ({cast})r.ReadInt16()",

            "u8" => "r => r.ReadByte()",
            "u16" => "r => r.ReadUInt16()",
            "u24" => "r => r.ReadUInt24()",
            "u32" => "r => r.ReadUInt32()",
            "u48" => "r => r.ReadUInt48()",
            "u64" => "r => r.ReadUInt64()",
            "uid" => "r => r.ReadInt64()",
            "s8" => "r => r.ReadSByte()",
            "s16" => "r => r.ReadInt16()",
            "s24" => "r => r.ReadInt24()",
            "s32" => "r => r.ReadInt32()",
            "utc" => "r => r.ReadDateTime()",
            "array" => "r => r.ReadArray()",
            "float" => "r => r.ReadSingle()",
            _ => "r => r.ReadByte()",
        };
        string zType(XmlNode x) => x.Attributes.GetNamedItem("type").Value switch
        {
            "cstring" => "string",
            "ostring" => "string",
            "bool" => "bool",
            "bmp8" => "byte",
            "bmp16" => "Int16",
            "enum8" => "byte",
            "enum16" => "Int16",
            "u8" => "byte",
            "u16" => "ushort",
            "u32" => "uint",
            "u64" => "ulong",
            "uid" => "Int64",
            "s8" => "byte",
            "s16" => "short",
            "s32" => "int",
            "utc" => "DateTime",
            _ => "Byte",
        };
        string xName(XmlNode x)
        {
            var name = x.Attributes.GetNamedItem("name").Value;
            if (string.IsNullOrEmpty(name))
                name = x.ChildNodes.Cast<XmlNode>().FirstOrDefault(c => c.Name == "description")?.InnerText + x.Attributes.GetNamedItem("id").Value;
            return name ?? string.Empty;
        }

        if ((isCommand && n.Name != "command") || (!isCommand && n.Name == "command"))
            return;

        switch (n.Name)
        {
            case "attribute-set":
                if (!isFirst) sb.AppendLine(); else isFirst = false;

                var dscr = attr("description");
                var idx = dscr.IndexOf("specific");
                suffix = dscr.Contains("Phase A") ? "A" : dscr.Contains("Phase B") ? "B" : dscr.Contains("Phase C") ? "C" : "";
                if (idx > 0)
                    prefix = dscr.Substring(0, idx).Property();
                sb.Region(dscr);
                foreach (XmlNode c in n.ChildNodes)
                    doNodes(c);
                sb.RegionEnd();
                prefix = "";
                suffix = "";
                break;
            case "attribute":
                var name = prefix + nattr("name") + suffix;
                var aid = attr("id");
                var type = attr("type");
                if (name.Contains("Unknown") || attrb.Contains(aid))
                    return;
                attrb.Add(aid);

                var cast = "";
                if (type.StartsWith("enum"))
                {
                    cast = $"{name}Enum";
                    sb.Code($"public enum {cast}");
                    sb.Indent();
                    var items1 = new List<string>();
                    foreach (var v in n.ChildNodes.Cast<XmlNode>().Where(c => c.Name == "value"))
                    {
                        var pname = xName(v).Property().ToUpperCase();
                        if (items1.Contains(pname))
                        {
                            var cnt = 2;
                            while (items1.Contains(pname + cnt.ToString())) cnt++;
                            pname += cnt.ToString();
                        }
                        items1.Add(pname);
                        sb.Code($"{pname} = {v.Attributes.GetNamedItem("value").Value},");
                    }
                    sb.UnIndent();
                    sb.AppendLine();
                }

                var descr = n.ChildNodes.Cast<XmlNode>().FirstOrDefault(c => c.Name == "description");
                if (descr != null)
                    sb.Comment(descr.InnerText);

                sb.Code($"public static ReportAttribute {name} {{ get; }} = zcl.Report({aid}, \"{attr("name")}\", ZigbeeType.{attr("type").ToCamelCase()}, {load(cast)});");
                break;
            case "command":
                aid = attr("id");
                name = nattr("name");

                List<XmlNode> payload = [];
                foreach (XmlNode c in n.ChildNodes)
                    if (c.Name == "payload")
                    {
                        payload = c.ChildNodes.Cast<XmlNode>().Where(c => c.Name == "attribute").ToList();
                        break;
                    }

                var args = "";
                var write = "";
                var items = new List<string>();
                foreach (var v in payload)
                {
                    var pname = xName(v).Parameter();
                    if (items.Contains(pname))
                    {
                        var cnt = 2;
                        while (items.Contains(pname + cnt.ToString())) cnt++;
                        pname += cnt.ToString();
                    }
                    items.Add(pname);
                    args += $", {zType(v)} {pname}";
                    write += $"+ {pname}";
                }

                if (!string.IsNullOrEmpty(write))
                    write = ", w => w" + write;

                descr = n.ChildNodes.Cast<XmlNode>().FirstOrDefault(c => c.Name == "description");
                if (descr != null)
                    sb.Comment(descr.InnerText);
                sb.Code($"public static Task {name}(this ZigbeeNode node{args}) => node.Zcl(zcl, {aid}{write});");
                break;
        }
    }

    sb.UnIndent();
    File.WriteAllText(Path.Combine("..", "..", "..", "..", "BrandThus.Zigbee", "Clusters", $"{id.Value} {clusterName}.cs"), sb.ToString());
}
