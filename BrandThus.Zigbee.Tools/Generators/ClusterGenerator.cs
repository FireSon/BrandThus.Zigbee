using Microsoft.CodeAnalysis;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;
using System.Xml;

namespace BrandThus.Zigbee.Tools.Generators;

[Generator]
public class ClusterGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
#if DEBUG
        //if (!Debugger.IsAttached)
        //{
        //    Debugger.Launch();
        //}
#endif

        // find all additional files that end with .txt
        var textFiles = context.AdditionalTextsProvider
            .Where(static file => file.Path.EndsWith("general.xml") || file.Path.EndsWith("generate.json"));

        // read their contents and save their name
        var namesAndContents = textFiles.Select((text, cancellationToken) =>
            (name: Path.GetFileNameWithoutExtension(text.Path), content: text.GetText(cancellationToken)!.ToString())).Collect();

        context.RegisterSourceOutput(namesAndContents, GenerateCode);
    }

    private static List<string> ReadJson(string json, string name)
    {
        var result = new List<string>();
        var idx = json.IndexOf($"\"{name}\":");
        if (idx > 0)
        {
            idx = json.IndexOf('[', idx) + 1;
            var idx2 = json.IndexOf(']', idx);
            var values = json.Substring(idx, idx2 - idx - 1).Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace("\"", "");
            foreach (var v in values.Split(','))
                if (!string.IsNullOrWhiteSpace(v))
                    result.Add(v.Trim());
        }
        return result;
    }

    private static void GenerateCode(SourceProductionContext context, ImmutableArray<(string name, string content)> args)
    {
        //Read the manufacturers codes
        var json = args.FirstOrDefault(a => a.name.ToLower() == "generate").content;
        var mfcodes = ReadJson(json, "Manufacturers");
        var skip = ReadJson(json, "SkipCluster");

        var xml = args.FirstOrDefault(a => a.name.ToLower() == "general").content;
        var xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(xml);

        #region Get the cluster  
        var clusters = new List<ZigbeeCluster>();
        foreach (XmlNode n in xmlDoc.GetElementsByTagName("cluster"))
        {
            var descr = n.SelectSingleNode("description");
            var cluster = new ZigbeeCluster()
            {
                Id = n.Attributes.GetNamedItem("id").Value,
                Name = n.Attributes.GetNamedItem("name").Value,
                Description = descr?.InnerText,
                Mfcode = n.Attributes.GetNamedItem("mfcode")?.Value,
                Attributes = new List<ZigbeeAttribute>(),
                Commands = new List<ZigbeeCommand>(),
            };

            if (clusters.Any(c => c.Name == cluster.Name))
                cluster.Name += cluster.Mfcode;
            clusters.Add(cluster);
        }
        #endregion

        #region Attributes
        foreach (XmlNode n in xmlDoc.GetElementsByTagName("attribute"))
        {
            if (n.ParentNode.Name == "payload")
                continue;

            var descr = n.SelectSingleNode("description");
            var attr = new ZigbeeAttribute()
            {
                Id = n.Attributes.GetNamedItem("id")?.Value,
                Name = n.Attributes.GetNamedItem("name")?.Value,
                Type = n.Attributes.GetNamedItem("type")?.Value,
                Access = n.Attributes.GetNamedItem("access")?.Value,
                Required = n.Attributes.GetNamedItem("required")?.Value,
                Description = descr != null ? descr.InnerText : n.Attributes.GetNamedItem("description")?.Value,
                Mfcode = n.Attributes.GetNamedItem("mfcode")?.Value,
                Values = new List<ZigbeeValue>()
            };

            if (n.ParentNode.Name == "attribute-set")
                attr.Group = n.ParentNode.Attributes.GetNamedItem("description").Value;

            foreach (var v in n.ChildNodes.Cast<XmlNode>().Where(c => c.Name == "value"))
                attr.Values.Add(new ZigbeeValue()
                {
                    Value = v.Attributes.GetNamedItem("value").Value,
                    Name = v.Attributes.GetNamedItem("name").Value,
                });

            var p = n.ParentNode;
            while (p.Name != "cluster")
                p = p.ParentNode;
            var id = p.Attributes.GetNamedItem("id").Value;
            var mf = p.Attributes.GetNamedItem("mfcode")?.Value;
            var cluster = clusters.FirstOrDefault(c => c.Id == id && c.Mfcode == mf);
            cluster.Attributes.Add(attr);
        }
        #endregion

        #region Commands
        foreach (XmlNode n in xmlDoc.GetElementsByTagName("command"))
        {
            var descr = n.SelectSingleNode("description");
            var cmd = new ZigbeeCommand()
            {
                Id = n.Attributes.GetNamedItem("id")?.Value,
                Name = n.Attributes.GetNamedItem("name")?.Value,
                Dir = n.Attributes.GetNamedItem("dir")?.Value,
                Required = n.Attributes.GetNamedItem("required")?.Value,
                Description = descr != null ? descr.InnerText : n.Attributes.GetNamedItem("description")?.Value,
                Mfcode = n.Attributes.GetNamedItem("mfcode")?.Value,
                Payload = new List<ZigbeePayload>()
            };

            var pl = n.SelectSingleNode("payload");
            if (pl != null)
                foreach (var a in pl.ChildNodes.Cast<XmlNode>().Where(c => c.Name == "attribute"))
                {
                    descr = a.SelectSingleNode("description");
                    var payload = new ZigbeePayload()
                    {
                        Type = a.Attributes.GetNamedItem("type").Value,
                        Name = a.Attributes.GetNamedItem("name").Value,
                        Description = descr != null ? descr.InnerText : a.Attributes.GetNamedItem("description")?.Value,
                        Values = new List<ZigbeeValue>()
                    };
                    if (string.IsNullOrWhiteSpace(payload.Name))
                        payload.Name = "arg";
                    if (cmd.Payload.Any(p => p.Name == payload.Name))
                        payload.Name += cmd.Payload.Count.ToString();
                    cmd.Payload.Add(payload);

                    foreach (var v in a.ChildNodes.Cast<XmlNode>().Where(c => c.Name == "value"))
                    {
                        var vn = v.Attributes.GetNamedItem("name").Value;
                        if (payload.Values.Any(pv => pv.Name == vn))
                            vn += payload.Values.Count.ToString(); 
                        payload.Values.Add(new ZigbeeValue()
                        {
                            Value = v.Attributes.GetNamedItem("value").Value,
                            Name = vn,
                        });
                    }
                }

            var p = n.ParentNode;
            while (p.Name != "cluster")
                p = p.ParentNode;
            var id = p.Attributes.GetNamedItem("id").Value;
            var mf = p.Attributes.GetNamedItem("mfcode")?.Value;
            var cluster = clusters.FirstOrDefault(c => c.Id == id && c.Mfcode == mf);
            cluster.Commands.Add(cmd);
        }
        #endregion

        var sb = new StringBuilder();
        foreach (var c in clusters)
        {
            if (skip.Any(s => string.Equals(s, c.Name, StringComparison.OrdinalIgnoreCase)) || mfcodes.Contains(c.Mfcode))
                continue;

            //Check for attributes & commands
            var attrs = c.Attributes.Where(a => !a.Name.StartsWith("Unknown") && (string.IsNullOrEmpty(a.Mfcode) || mfcodes.Contains(a.Mfcode))).ToList();
            var cmds = c.Commands.Where(a => string.IsNullOrEmpty(a.Mfcode) || mfcodes.Contains(a.Mfcode)).ToList();
            if (attrs.Count == 0 && cmds.Count == 0) continue;
             
            //Generate the code
            sb.Clear();
            var clusterName = c.Name.Property();
            var classname = "Zcl" + clusterName;
            sb.NameSpaces("System", "System.ComponentModel");
            sb.AppendLine();
            sb.AppendLine("namespace BrandThus.Zigbee.Clusters");
            sb.Indent();

            if (!string.IsNullOrWhiteSpace(c.Description))
                sb.Comment(c.Description);
            sb.Code($"[Cluster({c.Id}, \"{c.Name}\")]");
            sb.Code($"public static class {classname}");
            sb.Indent();
            sb.Code($"private static readonly ZigbeeCluster zcl = new ZigbeeCluster(typeof({classname}));");
            sb.AppendLine();

            var hasAttr = false;
            foreach (var g in attrs.GroupBy(a => a.Group))
            {
                hasAttr = true;
                var region = string.IsNullOrWhiteSpace(g.Key) ? "Attributes" : g.Key;
                var suffix = region.Contains("Phase A") ? "A" : region.Contains("Phase B") ? "B" : region.Contains("Phase C") ? "C" : "";
                sb.Region(region);
                foreach (var a in g)
                {
                    if (!string.IsNullOrWhiteSpace(a.Description))
                        sb.Comment(a.Description);
                    var aname = a.Name.Property();
                    var access = a.Access.ToUpper();
                    var aType = a.TypeName;

                    if (a.Type.StartsWith("enum"))
                    {
                        sb.Region(aname + "Enum");
                        sb.Code($"public enum {aname}Enum");
                        sb.Indent();
                        var items = new List<string>();
                        foreach (var v in a.Values)
                        {
                            if (items.Contains(v.Name))
                                v.Name += items.Count.ToString();
                            items.Add(v.Name); 
                            sb.Code($"[Description(\"{v.Name}\")]");
                            sb.Code($"{v.Name.Property()} = {v.Value},");
                        }
                        sb.UnIndent();
                        sb.RegionEnd();
                        aType = aname + "Enum";
                        sb.Code($"public static Digital{access}<{aType}> {aname}{suffix} {{ get; }} = zcl.{a.Type.ToUpperCase()}{access}<{aType}>({a.Id}, \"{a.Name}\");");
                    }
                    else if (a.IsAnalog)
                        sb.Code($"public static Analog{access}<{aType}> {aname}{suffix} {{ get; }} = zcl.{a.Type.ToUpperCase()}{access}({a.Id}, \"{a.Name}\");");
                    else
                        sb.Code($"public static Digital{access}<{aType}> {aname}{suffix} {{ get; }} = zcl.{a.Type.ToUpperCase()}{access}({a.Id}, \"{a.Name}\");");
                }
                sb.RegionEnd();
            }

            if (cmds.Count > 0)
            {
                if (hasAttr) sb.AppendLine();
                sb.Region("Commands");
                foreach (var cmd in cmds)
                {
                    if (!string.IsNullOrWhiteSpace(cmd.Description))
                        sb.Comment(cmd.Description);
                    var param = string.Join(", ", cmd.Payload.Select(p => $"{p.TypeName} {p.Name.Parameter()}"));
                    if (param.Length > 0)
                    {
                        sb.Code($"public static ZigbeeRequest {cmd.Name.Property()}(this ZigbeeNode node, {param}) =>");
                        sb.Code($"\tzcl[node, {cmd.Id}, w => w + {string.Join(" + ", cmd.Payload.Select(p => p.Name.Parameter()))}];");
                    }
                    else
                        sb.Code($"public static ZigbeeRequest {cmd.Name.Property()}(this ZigbeeNode node{param}) => zcl[node, {cmd.Id}];");
                }
                sb.RegionEnd();
            }
            sb.UnIndent();
            sb.UnIndent();

            context.AddSource($"{c.Id} {clusterName}.g.cs", sb.ToString());
        }
    }

    private class ZigbeeCluster
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Mfcode { get; set; }
        public List<ZigbeeAttribute> Attributes { get; set; }
        public List<ZigbeeCommand> Commands { get; set; }
    }

    private class ZigbeeAttribute
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Group { get; set; }
        public string Type { get; set; }
        public string Access { get; set; }
        public string Required { get; set; }
        public string Mfcode { get; set; }
        public List<ZigbeeValue> Values { get; set; }

        public bool IsAnalog => !Type.StartsWith("utc") && !Type.StartsWith("sec") && (Type.StartsWith("u") || Type.StartsWith("s") || Type.StartsWith("f"));
        public string TypeName => ZigbeePayload.GetTypeName(Type);
    }

    private class ZigbeeValue
    {
        public string Value { get; set; }
        public string Name { get; set; }
    }

    private class ZigbeeCommand
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Dir { get; set; }
        public string Required { get; set; }
        public string Mfcode { get; set; }
        public List<ZigbeePayload> Payload { get; set; }
    }

    private class ZigbeePayload
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ZigbeeValue> Values { get; set; }

        public string TypeName => GetTypeName(Type);
        internal static string GetTypeName(string type) => type switch
        {
            "cstring" => "string",
            "ostring" => "string",
            "lostring" => "string",
            "seckey" => "string",
            "bool" => "bool",
            "bmp8" => "byte",
            "bmp16" => "ushort",
            "bmp24" => "uint",
            "bmp32" => "uint",
            "dat8" => "byte",
            "dat16" => "ushort",
            "dat24" => "uint",
            "dat32" => "uint",
            "enum8" => "byte",
            "enum16" => "ushort",
            "u8" => "byte",
            "u16" => "ushort",
            "u24" => "uint",
            "u32" => "uint",
            "u48" => "ulong",
            "u64" => "ulong",
            "uid" => "long",
            "s8" => "sbyte",
            "s16" => "short",
            "s24" => "int",
            "s32" => "int",
            "utc" => "DateTime",
            "float" => "Single",
            "array" => "byte[]",
            _ => "????"
        };
    }
}