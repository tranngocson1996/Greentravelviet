using System;
using System.Web.UI;
using BIC.Biz;
using BIC.Utils;
using BIC.WebControls;
using BIC.Data;

public partial class admin_Components_MenuUser_DeletionMenuUser : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //int id = BicHtml.GetRequestString("id", 0);
        //if (!PermissionHelper.ByMenuUsers(_oldMenu))
        //{
        //    BicAjax.Alert(BicMessage.UpdatePermission);
        //    return;
        //}
        //var dh = new DataHelper();
        //if (dh.IsExist("ParentID", id, "MenuUser"))
        //{
        //    BicAjax.Alert(BicMessage.DeleteChildFirst);
        //    BicAjax.Navigate(Page.ResolveUrl(string.Format("~/admin/default.aspx?mid=3&cid=3&action=list&l={0}",BicLanguage.CurrentLanguageAdmin)));
        //}
        //else if (MenuUserBiz.DeleteMenuUser(BicConvert.ToInt32(id)))
        //{
        //    BicAdmin.NavigateToList();
        //}
    }
}