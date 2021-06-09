using BIC.Utils;

/// <summary>
///  Render content html
/// </summary>
public class HtmlViewer
{
    public static string Date(object date, object lang)
    {
        string datemark = lang.ToString().ToLower().Equals("vi") ? " (dd/MM/yyyy)" : " (MM/dd/yyyy)";
        return string.Format("<span class='span-date'>{0}</span>", BicConvert.ToDateTime(date).ToString(datemark));
    }

    public static string Price(object price, object lang)
    {
        string outprice = BicConvert.ToDouble(price).ToString("### ###") + " " +
                          BicXML.ToString("Unit", "ConfigProduct_" + lang);
        return BicConvert.ToDouble(price) == 0 ? "---" : outprice;
    }

    public static string Title(string sText, int iNumChar, string sPlus)
    {
        string sOutput;
        if (sText.Length <= iNumChar)
        {
            sOutput = sText;
        }
        else
        {
            sOutput = sText.Substring(0, iNumChar);

            for (int i = iNumChar; i < sText.Length; i++)
            {
                char sChar = sText[i];
                if (!sChar.ToString().EndsWith(" "))
                    sOutput += sChar.ToString();
                else
                    break;
            }
            sOutput += sPlus;
        }
        if (sText.Length <= iNumChar)
            return sOutput;
        return sOutput;
    }
}