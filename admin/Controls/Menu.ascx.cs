using System;
using System.Web.UI;
using BIC.Biz;

public partial class admin_Controls_Menu : UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            MenuAdminBiz.BuiltMenuAdmin(rmnuMenu, 1);
    }
}