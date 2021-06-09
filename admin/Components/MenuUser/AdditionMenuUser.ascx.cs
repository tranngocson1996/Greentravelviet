using System;
using System.Data;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;
using Telerik.Web.UI;

public partial class admin_Components_MenuUser_AdditionMenuUser : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
        {
            MenuUserUtils.BindingModelMenu(ddlModelMenu, BicLanguage.CurrentLanguageAdmin);
            if (BicControl.DropExistValue(BicSession.ToString("Language"), ddlLanguage))
                ddlLanguage.SelectedValue = BicSession.ToString("Language");
            if (BicControl.DropExistValue(BicSession.ToString("ModelMenu"), ddlModelMenu))
                ddlModelMenu.SelectedValue = BicSession.ToString("ModelMenu");
            MenuUserUtils.BindingModelMenu(ddlRefrenceMenu, BicLanguage.CurrentLanguageAdmin);
            ddlRefrenceMenu.Items.Insert(0, new ListItem(BicResource.GetValue("Admin", "Admin_MenuUser_SelectTheFunction"), "0"));
            GettingFrameViewIdCollection();
            tvMenuUser.BindingTreeView(ddlLanguage.SelectedValue, ddlModelMenu.SelectedValue);
            BindingMenuUserTreeView(ddlLanguage.SelectedValue, ddlModelMenu.SelectedValue);
            rcbMenuUser.EmptyMessage = BicResource.GetValue("Admin", "Admin_MenuUser_OriginalList");
            //bool test = BicXML.ToBoolean("EnableImageDescription", "SettingMenuUser");
        }
    }
    //Getting data for FrameViewID
    protected void GettingFrameViewIdCollection()
    {
        var bicData = new BicGetData { TableName = "FrameView" };
        bicData.Sorting.Add(new SortingItem("Priority", false));
        bicData.Conditioning.Add(new ConditioningItem("IsActive", "1", Operator.EQUAL, CompareType.NUMERIC));
        bicData.Selecting.Add("Name");
        bicData.Selecting.Add("FrameViewID");
        ddlFrameViewID.DataSource = bicData.GetAllData();
        ddlFrameViewID.DataTextField = BicResource.GetValue("Admin", "Name");
        ddlFrameViewID.DataValueField = "FrameViewID";
        ddlFrameViewID.DataBind();
        ddlFrameViewID.Items.Insert(0, new ListItem(BicResource.GetValue("Admin", "Admin_MenuUser_SelectTheFunction"), "0"));
        foreach (ListItem li in ddlFrameViewID.Items)
        {
            li.Text = BicResource.GetValue("Admin", li.Text);
        }
    }
    protected void ddlModelMenu_SelectedIndexChanged(object o, EventArgs e)
    {
        BicSession.SetValue("ModelMenu", ddlModelMenu.SelectedValue);
        BicAdmin.NavigateToList();
        tvMenuUser.BindingTreeView(ddlLanguage.SelectedValue, ddlModelMenu.SelectedValue);
        BindingMenuUserTreeView(ddlLanguage.SelectedValue, ddlModelMenu.SelectedValue);

    }
    protected void ddlLanguage_SelectedIndexChanged(object o, EventArgs e)
    {
        BicSession.SetValue("Language", ddlLanguage.SelectedValue);
        tvMenuUser.BindingTreeView(ddlLanguage.SelectedValue, ddlModelMenu.SelectedValue);
        BindingMenuUserTreeView(ddlLanguage.SelectedValue, ddlModelMenu.SelectedValue);
        BicAdmin.NavigateToList();
    }
    protected void ddlFrameViewID_SelectedIndexChanged(object sender, EventArgs e)
    {
        FrameViewEntity frameViewEntity = FrameViewBiz.GetFrameViewByID(BicConvert.ToInt32(ddlFrameViewID.SelectedValue));
        if (frameViewEntity != null)
        {
            txtUrl.Text = BicConvert.ToString(frameViewEntity.URLControl);
        }
        else
            txtUrl.Text = string.Empty;
    }
    protected void Save(object sender, CommandEventArgs e)
    {
        try
        {
            switch (e.CommandName)
            {
                case "AddNew":
                    InsertMenu();
                    break;
            }
        }
        catch (Exception ex)
        {
            BicAjax.Alert(ex.Message);
        }
    }
    protected void InsertMenu()
    {
        if (MenuUserBiz.InsertMenuUser(LoadDataToEntity()))
        {
            ClearInputData();
            tvMenuUser.BindingTreeView(ddlLanguage.SelectedValue, ddlModelMenu.SelectedValue);
            BindingMenuUserTreeView(ddlLanguage.SelectedValue, ddlModelMenu.SelectedValue);
            //BicAdmin.NavigateToList();
        }
        else
            BicAjax.Alert(BicMessage.InsertFail);
    }
    private MenuUserEntity LoadDataToEntity()
    {
        int parentId = 0;
        var tvParentId = rcbMenuUser.Items[0].FindControl("tvParentId") as RadTreeView;
        if (tvMenuUser != null)
            parentId = BicConvert.ToInt32(tvParentId.SelectedValue);
        var menuuserEntity = new MenuUserEntity
        {
            LanguageKey = ddlLanguage.SelectedValue,
            IsActive = chkIsActive.Checked,
            Name = txtName.Text,
            ParentID = parentId,
            TypeID = BicConvert.ToInt32(ddlModelMenu.SelectedValue),
            URL = BicConvert.ToString(txtUrl.Text),
            FrameViewID = BicConvert.ToInt32(ddlFrameViewID.SelectedValue),
            ImageID = BicConvert.ToInt32(isImageID.ImageID),
            Target = ddlTarget.SelectedValue,
            PageSize = BicConvert.ToInt32(txtPageSize.Text),
            UserName = txtUserName.Value,
            IsNew = BicConvert.ToBoolean(chkIsNew.Checked),
            RequireLogin = chkRequireLogin.Checked,
            Description = Server.HtmlDecode(reDescription.Content),
            SEOTitle = txtSEOTitle.Text,
            RefrenceMenu = ddlRefrenceMenu.SelectedValue,
            ImageArray = ismImageId.ImageIDArray,
            ExclusiveSiteMap = chkExclusiveSiteMap.Checked,
            ExclusiveNavigatePath = chkExclusiveNavigatePath.Checked,
            ExclusiveMenu = chkExclusiveMenu.Checked,
            MetaDescription = txtMetaDescription.Text,
            MetaKeyword = txtMetaKeyword.Text,
            PageTitle = txtPageTitle.Text.Trim()
        };
        return menuuserEntity;
    }
    private void ClearInputData()
    {
        txtName.Text = string.Empty;
        //txtPageSize.Text = string.Empty;
        //txtUrl.Text = string.Empty;
        //txtMetaDescription.Text = string.Empty;
        //txtMetaKeyword.Text = string.Empty;
        //txtSEOTitle.Text = string.Empty;
        //chkIsActive.Checked = true;
        //chkIsNew.Checked = false;
        //chkExclusiveMenu.Checked = true;
        //chkExclusiveNavigatePath.Checked = true;
        //chkExclusiveSiteMap.Checked = true;
        //chkRequireLogin.Checked = true;
        //ddlTarget.SelectedIndex = 0;
        //ddlFrameViewID.SelectedIndex = 0;
        //ddlRefrenceMenu.SelectedIndex = 0;
        //rcbMenuUser.EmptyMessage = "[Chọn danh mục]";
        //reDescription.Content = string.Empty;

        //ismImageId.ImageIDArray = string.Empty;
        //isImageID.ImageID = "0";
        //txtPageTitle.Text = string.Empty;

    }
    public void BindingMenuUserTreeView(string language, string modelMenu)
    {
        var tvParentId = rcbMenuUser.Items[0].FindControl("tvParentId") as RadTreeView;
        if (tvParentId == null) return;
        tvParentId.Nodes.Clear();
        var bic = new BicGetData();
        bic.Selecting.Add("ParentID");
        bic.Selecting.Add("MenuUserID");
        bic.Selecting.Add("Name");
        bic.TableName = "MenuUser";
        bic.Sorting.Add(new SortingItem("ParentID", false));
        bic.Sorting.Add(new SortingItem("Priority", false));
        bic.Conditioning.Add(new ConditioningItem("LanguageKey", language, Operator.EQUAL, CompareType.STRING));
        bic.Conditioning.Add(new ConditioningItem("TypeID", modelMenu, Operator.EQUAL, CompareType.NUMERIC));
        DataTable data = bic.GetAllData();
        tvParentId.DataTextField = "Name";
        tvParentId.DataFieldID = "MenuUserID";
        tvParentId.DataValueField = "MenuUserID";
        tvParentId.DataFieldParentID = "ParentID";
        tvParentId.DataSource = data;
        tvParentId.DataBind();
        tvParentId.ExpandAllNodes();
    }
}