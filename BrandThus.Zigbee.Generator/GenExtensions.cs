using System.Runtime.Intrinsics.X86;
using System.Text;

namespace BrandThus.Zigbee.Generator
{
    /// <summary>
    /// 
    /// </summary>
    public static class GenExtensions
    {
        public static string ToCamelCase(this string str)
        {
            if (!string.IsNullOrEmpty(str) && str.Length > 1)
            {
                return char.ToUpperInvariant(str[0]) + str.Substring(1);
            }
            return str;
        }
        public static string ToUpperCase(this string str)
        {
            if (!string.IsNullOrEmpty(str) && str.Length > 1)
            {
                return char.ToUpperInvariant(str[0]) + str.Substring(1);
            }
            return str;
        }

        public static string ToLowerCase(this string str)
        {
            if (!string.IsNullOrEmpty(str) && str.Length > 1)
            {
                return char.ToLowerInvariant(str[0]) + str.Substring(1);
            }
            return str;
        }

        private static string indent;
        public static void Indent(this StringBuilder sb)
        {
            sb.AppendLine($"{indent}{{");
            indent += "    ";
        }

        public static void UnIndent(this StringBuilder sb)
        {
            indent = indent.Length > 4 ? indent.Substring(indent.Length - 4) : "";
            sb.AppendLine($"{indent}}}");
        }

        public static void NameSpaces(this StringBuilder sb, params string[] namespaces) => sb.AppendLine(string.Join("\r\n", namespaces.Select(ns => $"using {ns};")));
        public static void Code(this StringBuilder sb, string code) => sb.AppendLine($"{indent}{code}");
        public static void Region(this StringBuilder sb, string code) => sb.AppendLine($"{indent}#region {code}");
        public static void RegionEnd(this StringBuilder sb, string code = null) => sb.AppendLine($"{indent}#endregion {code}");
        public static void Annotation(this StringBuilder sb, params string[] dataAnnotation)
        {
            if (dataAnnotation.Length > 0)
                sb.Append($"{indent}[")
                  .Append(string.Join(", ", dataAnnotation))
                  .AppendLine("]");
        }

        public static void Comment(this StringBuilder sb, string comment)
        {
            if (string.IsNullOrEmpty(comment))
                return;

            sb.AppendLine($"{indent}/// <summary>");
            comment = comment.Trim().Replace("\t", " ");
            while (comment.IndexOf("  ") >= 0) comment = comment.Replace("  ", " ");
            var words = comment.Split(new char[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            int idx = 0;
            while (idx < words.Length)
            {
                sb.Append($"{indent}///");
                int len = 0;
                while (idx < words.Length && len < 110)
                {
                    len += words[idx].Length + 1;
                    sb.Append(" " + words[idx++]);
                }
                sb.AppendLine();
            }
            sb.AppendLine($"{indent}/// <summary>");
        }

        public static string Variable(this string input) =>
            input switch
            {
                null => throw new ArgumentNullException(nameof(input)),
                "" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
                _ => input.First().ToString().ToUpper() + input.Substring(1)
            };

        static Dictionary<Type, string> _typeAlias = new Dictionary<Type, string>
        {
            { typeof(bool), "bool" },
            { typeof(byte), "byte" },
            { typeof(char), "char" },
            { typeof(decimal), "decimal" },
            { typeof(double), "double" },
            { typeof(float), "float" },
            { typeof(int), "int" },
            { typeof(long), "long" },
            { typeof(object), "object" },
            { typeof(sbyte), "sbyte" },
            { typeof(short), "short" },
            { typeof(string), "string" },
            { typeof(uint), "uint" },
            { typeof(ulong), "ulong" },
            // Yes, this is an odd one.  Technically it's a type though.
            { typeof(void), "void" }
        };

        public static string Alias(this Type type)
        {
            // Lookup alias for type
            if (_typeAlias.TryGetValue(type, out string alias))
                return alias;

            // Default to CLR type name
            return type.Name;
        }

        public static string Property(this string value)
        {
            var str = value.ToArray();
            for (int i = 0; i < value.Length - 1; i++)
                if (str[i] == ' ')
                    str[i + 1] = char.ToUpper(str[i+1]);
            value = new String(str);

            foreach (var c in "|,. -\\/–()[]?'’+°&³")
                value = value.Replace(new string(c, 1), "");

            value = value.Replace("é", "e");
            value = value.Replace("ü", "u");
            value = value.Replace("%", "Pct");
            
            if (value.Length > 0 && char.IsDigit(value[0]))
                value = "_" + value;
            return value;
        }
        public static string Parameter(this string value) => ToLowerCase(Property(value));
    }
}
