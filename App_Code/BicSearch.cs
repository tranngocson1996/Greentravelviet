using System;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for SetColourText
/// </summary>
public class BicSearch
{
    public static string SearchText(string content, string keys)
    {
        // convert keys to rexgex strings

        string sanitizedSearchStr = keys.Replace(" ", "|");
        string patternStr = "(?is)(" + String.Join("|", keys) + "|" + sanitizedSearchStr +
                            @")(?<=(^|[>\.\^,;:!@#\$%&\\+\?*\(\{\[\)\s]+)\1(?=($|[<\.\^,;:!@#\$%&\\+\?*\(\{\[\)\s]+)))";
        var theRegex = new Regex(patternStr, RegexOptions.IgnoreCase);
        string resultStr = theRegex.Replace(content, HighlightFunc);

        return resultStr;
    }

    private static string HighlightFunc(Match matchArg)
    {
        return "<span class='search-key'>" + matchArg.Value + "</span>";
    }
}