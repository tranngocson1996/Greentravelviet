using System;
using BIC.Biz;
using BIC.Data;
using BIC.Utils;
using BIC.WebControls;

public partial class admin_Components_MenuAdmin_DeletionMenuAdmin : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = BicHtml.GetRequestString("id", 0);
        var dh = new DataHelper();
        if (dh.IsExist("ParentID", id.ToString(), "MenuAdmin"))
            BicAjax.Confirm(BicMessage.DeleteChildFirst, BicAdmin.UrlList());
        else if (MenuAdminBiz.DeleteMenuAdmin(id))
            BicAdmin.NavigateToList();
    }
}