using System;
using BIC.Utils;
using BIC.WebControls;

public partial class admin_Components_ImageGallery_ImageManager : BasePageAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Image";
        hdfLangManager.Value = BicHtml.GetRequestString("l") == ""
            ? BicXML.ToString("DefaultLanguageAdmin", "SearchEngine")
            : BicHtml.GetRequestString("l");
    }
}