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
        string load() => attr("type") switch
        {
            "cstring" => "r => r.ReadString()",
            "ostring" => "r => r.ReadString()",
            "seckey" => "r => r.ReadString()",
            "bool" => "r => r.ReadBool()",
            "bmp8" => "r => r.ReadByte()",
            "bmp16" => "r => r.ReadInt16()",
            "bmp32" => "r => r.ReadInt32()",
            "enum8" => "r => r.ReadByte()",
            "enum16" => "r => r.ReadInt16()",
            "u8" => "r => r.ReadByte()",
            "u16" => "r => r.ReadUInt16()",
            "u24" => "r => r.ReadUInt24()",
            "u32" => "r => r.ReadUInt32()",
            "u48" => "r => r.ReadUInt48()",
            "uid" => "r => r.ReadInt64()",
            "s16" => "r => r.ReadInt16()",
            "s32" => "r => r.ReadInt32()",
            "utc" => "r => r.ReadDateTime()",
            "float" => "r => r.ReadSingle()",
            _ => "r => r.ReadByte()",
        };

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
                if (name.Contains("Unknown") || attrb.Contains(aid))
                    return;
                attrb.Add(aid);
                sb.Code($"public static ReportAttribute {name} {{ get; }} = zcl.Report({aid}, \"{attr("name")}\", {load()});");
                break;
            case "command":
                sb.Code($"public static Task {nattr("name")} => Task.CompletedTask;");
                break;
        }
    }

    sb.UnIndent();
    File.WriteAllText(Path.Combine("..", "..", "..", "..", "BrandThus.Zigbee", "Clusters", $"{id.Value} {clusterName}.cs"), sb.ToString());
}

//foreach (var d in domains.Values)
//{
//    sb.Clear();
//    //sb.NameSpaces(namespaces.ToArray());
//    //sb.AppendLine();
//    sb.AppendLine("namespace BrandThus.Zigbee.Clusters;");

//    //Write the clusters
//    foreach (var e in d.Clusters)
//        if (!string.IsNullOrEmpty(e.Help))
//        {
//            sb.AppendLine();

//            var classname = "Zcl" + e.Name.Replace(" ", "");
//            sb.Comment(e.Help);
//            sb.Code($"public static class {classname}");
//            sb.Indent();
//            bool isFirst = true, isServer = true;
//            //Add the attributes
//            foreach (XmlNode child in e.Node.ChildNodes)
//                switch (child.Name)
//                {
//                    case "server": 
//                        doNodes(child);
//                        break;
//                    case "client":
//                        isFirst = true;
//                        isServer = false;
//                        doNodes(child);
//                        break;
//                }

//            void doNodes(XmlNode n)
//            {
//                if (n.Name == "attribute-set" && n.Attributes.GetNamedItem("description") is XmlNode descr)
//                {
//                    if (!isFirst) sb.AppendLine();
//                    sb.Code($"//{descr.Value}");
//                }
//                //else if (n.Name == "attribute" && n.Attributes.GetNamedItem("name") is XmlNode name)
//                //{
//                //    isFirst = false;
//                //    sb.Code($"//{name.Value}");
//                //}
//                else if (n.Name == "command" && n.Attributes.GetNamedItem("name") is XmlNode cname)
//                {
//                    if (!isFirst) sb.AppendLine();
//                    isFirst = false;
//                    sb.Code($"//Task {cname.Value}");
//                }

//                foreach (XmlNode c in n.ChildNodes)
//                    doNodes(c);
//            }

//            sb.UnIndent();
//        }

//    File.WriteAllText(Path.Combine("..", "..", "..", "..", "BrandThus.Zigbee", "Clusters", $"{d.Name.Replace(" ","")}.cs"), sb.ToString());
//}

//Console.WriteLine();

//internal class Domain
//{
//    internal string? Name { get; set; }
//    internal string? Help { get; set; }
//    internal List<Cluster> Clusters = new();
//}

//internal class Cluster
//{
//    internal string? Name { get; set; }
//    internal string? Id { get; set; }
//    internal string? Help { get; set; }
//    internal XmlNode Node = default!;
//}