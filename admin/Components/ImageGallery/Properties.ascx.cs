using System;
using System.Web.UI;
using BIC.Utils;

public partial class admin_Components_ImageGallery_Properties : UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtUrl.Value = BicHtml.GetRequestString("p");
            txtWidth.Value = BicHtml.GetRequestString("w");
            hdWidth.Value = BicHtml.GetRequestString("w");
            txtHeight.Value = BicHtml.GetRequestString("h");
            hdHeight.Value = BicHtml.GetRequestString("h");
            hdImageViewer.Value = "../ImageViewer.aspx?p=" + txtUrl.Value + "&w=" + txtWidth.Value + "&h=" +
                                  txtHeight.Value;
        }
    }
}