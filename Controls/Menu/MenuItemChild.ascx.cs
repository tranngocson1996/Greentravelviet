using System;
using BIC.Data;
using BIC.Utils;
using BIC.WebControls;

public partial class Controls_Menu_MenuItem :BaseUIControl
{
    public string MenuUserIdVi { get; set; }
    public string MenuUserIdEn { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {    
        DataHelper dataHelper=new DataHelper();
        string sql = string.Format("select URL,UrlName,Name,ImageName from MenuUser where MenuUserId='{0}' and IsActive='1'",
            BicLanguage.CurrentLanguage == "vi" ? MenuUserIdVi : MenuUserIdEn);
        var data = dataHelper.ExecuteSQL(sql);
        menuParent.DataSource = data;
        menuParent.DataBind();
    }
    public string _Getlink(string url, string name)
    {
        string link = string.Empty;
        if (url.Contains("{4}/{3}"))
        {
             link = "/{0}{1}{2}" + url;
            link = string.Format(link, "", "", "", name, BicLanguage.CurrentLanguage);
        }
        else
        {
            link= url;
        }
        if (string.IsNullOrEmpty(link))
            link = "javascript:void(0)";
        return link;
    }
}