using System;
using System.Data;
using System.Web.Security;
using BIC.Utils;
using BIC.WebControls;
using Telerik.Web.UI;

public partial class Admin_Components_Roles_ListingRoles : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            radMenuContext.LoadContentFile(string.Format("~/admin/XMLData/Grid/MenuContextRoles_" + BicLanguage.CurrentLanguageAdmin + ".xml"));
            radMenuContext.Items[1].Attributes.Add("onclick", string.Format("var as;as=confirm('{0}');document.getElementById('confirmdelete').value = as;", BicMessage.Delete));
        }
    }
    private void GetDataSource()
    {
        var dtRole = new DataTable();
        dtRole.Columns.Add(new DataColumn("RoleName"));
        dtRole.Columns.Add(new DataColumn("RoleNumber"));
        string[] sRoles = Roles.GetAllRoles();
        foreach (string t in sRoles)
        {
            if (BicMemberShip.CurrentUserName != "administrator" && t == "Administrator")
                dtRole.Rows.Add(t, GetNumberUserInRole(t) - 1);
            else
                dtRole.Rows.Add(t, GetNumberUserInRole(t));
        }
        rgManager.VirtualItemCount = dtRole.Rows.Count;
        rgManager.DataSource = dtRole;
    }
    protected int GetNumberUserInRole(string rolename)
    {
        int number = Roles.GetUsersInRole(rolename).Length;
        return number;
    }
    protected void rgManager_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        GetDataSource();
    }
    protected void radMenuContext_ItemClick(object sender, RadMenuEventArgs e)
    {
        string rolename = Request.Form["radGridSelectedRowIndex"];
        switch (e.Item.Value)
        {
            case "Delete":
                bool confirm = Convert.ToBoolean(Request.Form["confirmdelete"]);
                if (confirm)
                {
                    DeleteRole(rolename.ToLower());
                    rgManager.Rebind();
                }
                break;
            case "View":
                BicAjax.Navigate(BicAdmin.UrlDefault + "?mid=36&cid=21&role=" + rolename + "&l=" + BicHtml.GetRequestString("l", "vi"));
                break;
        }
    }
    protected void DeleteRole(string rolename)
    {
        if (rolename == "administrator")
        {
            BicAjax.Alert("Nhóm quyền Administrator không thể xóa!");
            return;
        }
        try
        {
            if (!Roles.DeleteRole(rolename))
                BicAjax.Alert("Có lỗi, xóa quyền không thành công.");
            //Bind lại dữ liệu sau khi xóa
        }
        catch (Exception ex)
        {
            BicAjax.Alert(ex.Message);
        }
    }
}