using System;
using System.Data;
using System.Web.Security;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;
using Telerik.Web.UI;

public partial class admin_Components_Security_SetPermissionToControl : BaseUserControl
{
    private string _role;
    protected void Page_Load(object sender, EventArgs e)
    {
        _role = BicHtml.GetRequestString("role");
        if (!IsPostBack)
        {
            BindingRoles();
            if (_role != string.Empty)
                ddlRole.SelectedValue = _role;
            BinddingControlRole();
        }
    }
    protected void BindingRoles()
    {
        ddlRole.DataSource = Roles.GetAllRoles();
        ddlRole.DataBind();
    }
    private void BinddingControlRole()
    {
        DataTable data = ControlRoleBiz.ControlRolesGetPermistionByRoleName(ddlRole.SelectedValue);
        if (!BicMemberShip.CurrentUserName.Equals("administrator"))
        {
            rgManager.DataSource = data.Select(txtSearch.Text != string.Empty ? string.Format("ControlName like '%{0}%' and IsActive = 1", txtSearch.Text) : string.Format("IsActive = 1", txtSearch.Text));
        }
        else
        {
            rgManager.DataSource = txtSearch.Text != string.Empty ? (object) data.Select(string.Format("ControlName like '%{0}%'", txtSearch.Text)) : data;
        }
        rgManager.VirtualItemCount = data.Rows.Count;
    }
    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {
        BinddingControlRole();
        rgManager.DataBind();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BinddingControlRole();
        rgManager.DataBind();
    }
    protected void rgManager_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        BinddingControlRole();
    }
    protected void rgManager_ItemCommand(object source, GridCommandEventArgs e)
    {
        if (e.Item.ItemIndex != -1)
        {
            int controlId = BicConvert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ControlID"]);
            ControlRoleEntity controlRoleEntity = ControlRoleBiz.ControlRolesGetByRoleNameAndControlID(controlId, ddlRole.SelectedValue) ?? new ControlRoleEntity();
            controlRoleEntity.RoleName = ddlRole.SelectedValue;
            controlRoleEntity.ControlID = controlId;
            switch (e.CommandName)
            {
                case "Viewed":
                    bool viewed = e.CommandArgument.Equals("True") ? false : true;
                    controlRoleEntity.Viewed = viewed;
                    if (ControlRoleBiz.InsertUpdateControlRole(controlRoleEntity) == false)
                        e.Canceled = true;
                    else
                    {
                        BinddingControlRole();
                        rgManager.Rebind();
                    }
                    break;
                case "Edited":
                    bool edited = e.CommandArgument.Equals("True") ? false : true;
                    controlRoleEntity.Edited = edited;
                    if (ControlRoleBiz.InsertUpdateControlRole(controlRoleEntity) == false)
                        e.Canceled = true;
                    else
                    {
                        BinddingControlRole();
                        rgManager.Rebind();
                    }
                    break;
                case "Added":
                    bool added = e.CommandArgument.Equals("True") ? false : true;
                    controlRoleEntity.Added = added;
                    if (ControlRoleBiz.InsertUpdateControlRole(controlRoleEntity) == false)
                        e.Canceled = true;
                    else
                    {
                        BinddingControlRole();
                        rgManager.Rebind();
                    }
                    break;
                case "Deleted":
                    bool deleted = e.CommandArgument.Equals("True") ? false : true;
                    controlRoleEntity.Deleted = deleted;
                    if (ControlRoleBiz.InsertUpdateControlRole(controlRoleEntity) == false)
                        e.Canceled = true;
                    else
                    {
                        BinddingControlRole();
                        rgManager.Rebind();
                    }
                    break;
                case "Approved":
                    bool approved = e.CommandArgument.Equals("True") ? false : true;
                    controlRoleEntity.Approved = approved;
                    if (ControlRoleBiz.InsertUpdateControlRole(controlRoleEntity) == false)
                        e.Canceled = true;
                    else
                    {
                        BinddingControlRole();
                        rgManager.Rebind();
                    }
                    break;
                case "CheckAll":
                    bool checkAll = e.CommandArgument.Equals("True") ? false : true;
                    controlRoleEntity.Viewed = checkAll;
                    controlRoleEntity.Added = checkAll;
                    controlRoleEntity.Edited = checkAll;
                    controlRoleEntity.Deleted = checkAll;
                    controlRoleEntity.Approved = checkAll;
                    if (ControlRoleBiz.InsertUpdateControlRole(controlRoleEntity) == false)
                        e.Canceled = true;
                    else
                    {
                        BinddingControlRole();
                        rgManager.Rebind();
                    }
                    break;
            }
        }
    }
    protected void ddlRole_SelectedIndexChanged(object sender, EventArgs e)
    {
        BinddingControlRole();
        rgManager.DataBind();
    }
}