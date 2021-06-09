using System;
using BIC.Utils;
using BIC.WebControls;

public partial class Controls_Language : BaseUIControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        if (BicControl.DropExistValue(BicXML.ToString("DefaultLanguageAdmin", "SearchEngine"), ddlAdminLanguage))
            ddlAdminLanguage.SelectedValue = BicHtml.GetRequestString("l") == "" ? BicXML.ToString("DefaultLanguageAdmin", "SearchEngine") : BicHtml.GetRequestString("l");
    }


    protected void ddlAdminLanguage_SelectedIndexChanged(object sender, EventArgs e)
    {
        string currentUrl = Request.Url.PathAndQuery;
        string currentLang = BicHtml.GetRequestString("l");
        string newUrl = "";
        if (currentUrl.IndexOf("?l=") != -1)
            newUrl = currentUrl.Replace("?l=" + currentLang, "?l=" + ddlAdminLanguage.SelectedValue);
        else if (currentUrl.IndexOf("&l=") != -1)
            newUrl = currentUrl.Replace("&l=" + currentLang, "&l=" + ddlAdminLanguage.SelectedValue);
        else
            newUrl = currentUrl + "?l=" + ddlAdminLanguage.SelectedValue;
        Response.Redirect(newUrl);
    }
}