using System;
using BIC.Utils;

public partial class Controls_ShoppingCart_MessageSuccess : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btRedirect_Click(object sender, EventArgs e)
    {
        BicSession.SetValue("SelectTabOrder", "1");
        Response.Redirect(Common.GetLinkShort("/vi/edit-profile.html"));
    }
}