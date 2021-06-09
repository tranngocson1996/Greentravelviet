using System;
using System.Data;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class admin_Components_MenuAdmin_AdditionMenuAdmin : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindingControl();
            MenuAdminBiz.BuildMenuAdminTree(ddlParentID);
        }
    }
    private void BindingControl()
    {
        var bic = new BicGetData();
        bic.Selecting.Add(ControlEntity.FIELD_CONTROLID);
        bic.Selecting.Add(ControlEntity.FIELD_CONTROLNAME);
        bic.TableName = "Control";
        bic.Sorting.Add(new SortingItem(ControlEntity.FIELD_CONTROLNAME, false));
        bic.Conditioning.Add(new ConditioningItem(ControlEntity.FIELD_ISACTIVE, "1", Operator.EQUAL, CompareType.NUMERIC));
        DataTable data = bic.GetAllData();
        ddlControl.DataTextField = ControlEntity.FIELD_CONTROLNAME;
        ddlControl.DataValueField = ControlEntity.FIELD_CONTROLID;
        ddlControl.DataSource = data;
        ddlControl.DataBind();
        ddlControl.Items.Insert(0, new ListItem(BicResource.GetValue("Admin","Admin_MenuAdmin_Select"), "0"));
    }
    protected void Save(object sender, CommandEventArgs e)
    {
        InsertMenu();
    }
    protected void InsertMenu()
    {
        if (MenuAdminBiz.InsertMenuAdmin(LoadDataToEntity()))
        {
            ClearInputData();
            tvMain.BindingTreeView();
            MenuAdminBiz.BuildMenuAdminTree(ddlParentID);
        }
        else
            BicAjax.Alert(BicMessage.InsertFail);
    }
    private MenuAdminEntity LoadDataToEntity()
    {
        var menuadminEntity = new MenuAdminEntity {Name = txtName.Text, MenuUrl = txtUrl.Value, IsActive = !chkIsActive.Checked, Description = reDescription.Html, Target = ddlTarget.SelectedValue, Icon = txtIcon.Value, KeyBoard = ddlAlphabetica.SelectedValue, TypeOfMenu = 1, ParentID = BicConvert.ToInt32(ddlParentID.SelectedValue), ControlID = BicConvert.ToInt32(ddlControl.SelectedValue)};
        return menuadminEntity;
    }
    private void ClearInputData()
    {
        txtName.Text = string.Empty;
        txtUrl.Value = string.Empty;
        chkIsActive.Checked = false;
        txtIcon.Value = string.Empty;
        ddlControl.SelectedIndex = 0;
        ddlTarget.SelectedIndex = 0;
    }
}