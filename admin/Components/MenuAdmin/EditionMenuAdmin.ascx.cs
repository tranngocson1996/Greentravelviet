using System;
using System.Data;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class admin_Components_MenuAdmin_EditionMenuAdmin : BaseUserControl
{
    private int _id;
    protected void Page_Load(object sender, EventArgs e)
    {
        _id = BicHtml.GetRequestString("id", 0);
        if (!IsPostBack)
        {
            BindingControl();
            GetMenu();
        }
    }
    protected void GetMenu()
    {
        if (_id != 0)
        {
            ddlParentID.Enabled = false;
            MenuAdminBiz.BuildMenuAdminTree(ddlParentID);
            LoadDataFromEntity();
        }
    }
    private void LoadDataFromEntity()
    {
        MenuAdminEntity menuadminEntity = MenuAdminBiz.GetMenuAdminByID(_id);
        if (menuadminEntity == null) return;
        txtName.Text = menuadminEntity.Name;
        ltlName.Text = " == " + BicResource.GetValue("Admin", menuadminEntity.Name);
        txtUrl.Value = menuadminEntity.MenuUrl;
        chkIsActive.Checked = !menuadminEntity.IsActive;
        ddlTarget.SelectedValue = menuadminEntity.Target;
        txtIcon.Value = menuadminEntity.Icon;
        ddlAlphabetica.SelectedValue = menuadminEntity.KeyBoard;
        if (BicControl.DropExistValue(menuadminEntity.ParentID, ddlParentID))
            ddlParentID.SelectedValue = menuadminEntity.ParentID.ToString();
        if (BicControl.DropExistValue(menuadminEntity.ControlID, ddlControl))
            ddlControl.SelectedValue = menuadminEntity.ControlID.ToString();
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
        ddlControl.Items.Insert(0, new ListItem(BicResource.GetValue("Admin", "Admin_MenuAdmin_Select"), "0"));
    }
    protected void Save(object sender, CommandEventArgs e)
    {
        UpdateMenu();
    }
    protected void UpdateMenu()
    {
        if (MenuAdminBiz.UpdateMenuAdmin(LoadDataToEntity()))
            BicAdmin.NavigateToList();
        else
            BicAjax.Alert(BicMessage.UpdateFail);
    }
    private MenuAdminEntity LoadDataToEntity()
    {
        var menuadminEntity = new MenuAdminEntity { MenuAdminID = BicConvert.ToInt32(_id), Name = txtName.Text, MenuUrl = txtUrl.Value, IsActive = !chkIsActive.Checked, Description = reDescription.Html, Target = ddlTarget.SelectedValue, Icon = txtIcon.Value, KeyBoard = ddlAlphabetica.SelectedValue, TypeOfMenu = 1, ParentID = BicConvert.ToInt32(ddlParentID.SelectedValue), ControlID = BicConvert.ToInt32(ddlControl.SelectedValue) };
        return menuadminEntity;
    }
}