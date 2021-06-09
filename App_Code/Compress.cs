using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using BIC.Utils;

/// <summary>
/// Summary description for Compress
/// </summary>
public class Compress
{
    public Compress()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static string CompressCSS(string body)
    {
        body = Regex.Replace(body, "/\\*.+?\\*/", "", RegexOptions.Singleline);
        //body = Regex.Replace(body, "}?.+\\{\\}", string.Empty, RegexOptions.Multiline);
        while (body.Contains(Environment.NewLine)) body = body.Replace(Environment.NewLine, string.Empty);
        while (body.Contains("  ")) body = body.Replace("  ", " ");
        body = body.Replace(Environment.NewLine, string.Empty);
        body = body.Replace("\\t", string.Empty);
        body = body.Replace(" 0px", " 0");
        body = body.Replace(" {", "{");
        body = body.Replace(" :", ":");
        body = body.Replace(": ", ":");
        body = body.Replace(", ", ",");
        body = body.Replace("; ", ";");
        body = body.Replace(";}", "}");
        body = body.Replace("  ", " ");
        body = body.Replace("	", " ");
        body = body.Replace(Environment.NewLine, " ");
        body = body.Replace(" ;", ";").Replace("; ", ";");
        body = body.Replace(" :", ":").Replace(": ", ":");
        body = body.Replace(" {", "{").Replace("{ ", "{");
        body = body.Replace(" }", "}").Replace("} ", "}");
        while (body.Contains("  ")) body = body.Replace("  ", " ");
        body = Regex.Replace(body, "/\\*[^\\*]*\\*+([^/\\*]*\\*+)*/", string.Empty);
        body = Regex.Replace(body, "(?<=[>])\\s{2,}(?=[<])|(?<=[>])\\s{2,}(?=&nbsp;)|(?<=&ndsp;)\\s{2,}(?=[<])", string.Empty);
        return body;
    }
    public static IList<System.IO.FileInfo> GetFiles(object Dir, object[] Files)
    {
        var serverPath = Dir.ToString();
        if (!serverPath.StartsWith("~/"))
        {
            if (serverPath.StartsWith("/"))
                serverPath = "~" + serverPath;
            else
                serverPath = "~/" + serverPath;
        }

        string path = HttpContext.Current.Server.MapPath(serverPath);

        if (!path.EndsWith("/"))
            path = path + "/";

        return (from name in Files where File.Exists(path + name) select new FileInfo(path + name)).ToList();
    }
    
    public static string CombineCss(object dir, object[] files)
    {
        var allCSS = string.Empty;
        foreach (var fi in GetFiles(dir, files))
        {
            using (var sr = new StreamReader(fi.FullName))
                allCSS += sr.ReadToEnd();
        }
        allCSS = CompressCSS(allCSS);

        return allCSS;
    }

    private static string _root = BicApplication.URLRoot;
    private static string ResolveUrl(object input)
    {
        try
        {
            return input.ToString().Replace("~/", _root);
        }
        catch (Exception)
        {
            return input.ToString();
        }
        
    }
    public static string CombineScripts(object dir, object[] file)
    {
        return CombineScripts(dir, file, true);
    }

    public static string CombineScripts(object dir, object[] file,bool compress)
    {
        var allJs = string.Empty;
        var content = string.Empty;
        var seperator = "{1}" + Environment.NewLine;
        var regexcomment = "\\/\\/(.+)\\n";
        foreach (FileInfo fi in GetFiles(dir, file))
        {
            using (var sr = new StreamReader(fi.FullName))
                content += sr.ReadToEnd();
            if (!fi.FullName.Contains("min") && !fi.FullName.Contains("pack"))
            {
                content = Regex.Replace(content, "/\\*.+?\\*/", " ", RegexOptions.Singleline);
                var ms = Regex.Matches(content, regexcomment, RegexOptions.Multiline);
                if (compress)
                {
                    foreach (var m in from object m in ms where !(content.Contains(":" + m)) select m)
                    {
                        content = content.Replace(m.ToString(), string.Empty);
                    }
                    content = content.Replace(Environment.NewLine, " ");
                    while (content.Contains(" ;") || content.Contains("; "))
                        content = content.Replace(" ;", ";").Replace("; ", ";");
                    while (content.Contains(" :") || content.Contains(": "))
                        content = content.Replace(" :", ":").Replace(": ", ":");
                    while (content.Contains(" {") || content.Contains("{ "))
                        content = content.Replace(" {", "{").Replace("{ ", "{");
                    while (content.Contains(" }") || content.Contains("} "))
                        content = content.Replace(" }", "}").Replace("} ", "}");
                    while (content.Contains(" )") || content.Contains(") "))
                        content = content.Replace(" )", ")").Replace(") ", ")");
                    while (content.Contains(" (") || content.Contains("( "))
                        content = content.Replace(" (", "(").Replace("( ", "(");
                    while (content.Contains(" =") || content.Contains("= "))
                        content = content.Replace(" =", "=").Replace("= ", "=");
                    while (content.Contains(" +") || content.Contains("+ "))
                        content = content.Replace(" +", "+").Replace("+ ", "+");
                    while (content.Contains(" -") || content.Contains("- "))
                        content = content.Replace(" -", "-").Replace("- ", "-");
                    while (content.Contains(" /") || content.Contains("/ "))
                        content = content.Replace(" /", "/").Replace("/ ", "/");
                    while (content.Contains(" *") || content.Contains("* "))
                        content = content.Replace(" *", "*").Replace("* ", "*");
                    while (content.Contains("  "))
                        content = content.Replace("  ", " ");
                }
            }
            allJs += string.Format(seperator, fi.Name, ReplaceReg(content));
            content = string.Empty;
        }
        return allJs;
    }

    private static string[] _reg = new string[] {"---space---","[urlroot]"};
    private static string[] _rep = new string[] {" ",BicApplication.URLRoot};
    private static string ReplaceReg(string input)
    {
        input = _reg.Aggregate(input, (current, str) => current.Replace(str, _rep[Array.IndexOf(_reg, str)]));
        return input;
    }
}