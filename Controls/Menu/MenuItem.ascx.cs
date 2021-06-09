using System;
using BIC.Data;
using BIC.Utils;
using BIC.WebControls;

public partial class Controls_Menu_MenuItem :BaseUIControl
{
    public string CssClass { get; set; }
    public int ParentId { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { 
            menuParent.ParentId = BicConvert.ToInt32(ParentId);
            menuParent.Language = BicLanguage.CurrentLanguage;
            menuParent.LoadData();
        }
    }
    public string _Getlink(string url, string name)
    {
        if (url.Contains("{4}/{3}"))
        {
            string link = "/{0}{1}{2}" + url;
            link = string.Format(link, "", "", "", name, BicLanguage.CurrentLanguage);
            return link;
        }
        else
        {
            return url;
        }

    }
}