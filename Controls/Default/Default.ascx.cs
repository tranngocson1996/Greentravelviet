using System;
using BIC.Utils;
using BIC.WebControls;

public partial class Controls_Article_ArticleDetail : BaseUIControl
{
    public string CssClass = "tour-them";
    public string CssClass1 = "tour-them";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (BicLanguage.CurrentLanguage == "vi")
        {
            CssClass = "hidden";
        }
        else
        {
            CssClass1 = "hidden";
        }
    }
    public string _Getlink(string url, string name)
    {
        if (url.Contains("{4}/{3}"))
        {
            var link = "/{0}{1}{2}" + url;
            link = string.Format(link, "", "", "", name, BicLanguage.CurrentLanguage);
            return link;
        }
        else
        {
            return url;
        }
    }
}