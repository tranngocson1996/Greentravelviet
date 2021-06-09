using BIC.Utils;
using BIC.WebControls;
using System;

public partial class admin_Components_Video_UploadVideo : BasePageAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {
        EditVideo1.Visible = (Session["VideoID"] != null);
        UpVideo1.Visible = (Session["VideoID"] == null);
        hdfLangForVideo.Value = BicHtml.GetRequestString("l") == ""
                                   ? BicXML.ToString("DefaultLanguageAdmin", "SearchEngine")
                                   : BicHtml.GetRequestString("l");
    }
}