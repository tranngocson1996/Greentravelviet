using System;
using System.Data;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;
using Telerik.Web.UI;

public partial class admin_Components_MenuAdmin_EditionMenuUser : BaseUserControl
{
    private int _id;
    private string _oldUserName;
    protected void Page_Load(object sender, EventArgs e)
    {
        _id = BicHtml.GetRequestString("id", 0);
        if (IsPostBack) return;
        GettingFrameViewIDCollection();
        MenuUserUtils.BindingModelMenu(ddlModelMenu, BicLanguage.CurrentLanguageAdmin);
        MenuUserUtils.BindingModelMenu(ddlRefrenceMenu, BicLanguage.CurrentLanguageAdmin);
        ddlRefrenceMenu.Items.Insert(0, new ListItem("[" + BicResource.GetValue("Admin", "Admin_MenuUser_SelectTheFunction") + "]", "0"));
        LoadDataFromEntity();
        tvMenuUser.BindingTreeView(ddlLanguage.SelectedValue, ddlModelMenu.SelectedValue);
        if (string.IsNullOrEmpty(BicHtml.GetRequestString("a"))) return;
        // Bind du lieu vao treeview menuuser khi duplicate menu tu treeview
        BindingMenuUserTreeView(ddlLanguage.SelectedValue, ddlModelMenu.SelectedValue);
        rcbMenuUser.Visible = true;
        hfParentId.Visible = false;
        lblParentId.Visible = false;
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
    //Geting data for FrameViewID
    protected void GettingFrameViewIDCollection()
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
    }
    protected void ddlLanguage_SelectedIndexChanged(object o, EventArgs e)
    {
        BicSession.SetValue("Language", ddlLanguage.SelectedValue);
        tvMenuUser.BindingTreeView(ddlLanguage.SelectedValue, ddlModelMenu.SelectedValue);
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
    private void LoadDataFromEntity()
    {
        MenuUserEntity menuuserEntity = MenuUserBiz.GetMenuUserByID(_id);
        if (menuuserEntity != null)
        {
            ddlLanguage.SelectedValue = menuuserEntity.LanguageKey;
            txtName.Text = menuuserEntity.Name;
            chkIsActive.Checked = menuuserEntity.IsActive;
            MenuUserEntity menuUserParentEntity = MenuUserBiz.GetMenuUserByID(menuuserEntity.ParentID);
            lblParentId.Text = menuUserParentEntity != null ? menuUserParentEntity.Name : BicResource.GetValue("Admin", "Admin_MenuUser_OriginalList");
            hfParentId.Value = menuuserEntity.ParentID.ToString();
            ddlModelMenu.SelectedValue = BicConvert.ToString(menuuserEntity.TypeID);
            txtUrl.Text = BicConvert.ToString(menuuserEntity.URL);
            ddlFrameViewID.SelectedValue = BicConvert.ToString(menuuserEntity.FrameViewID);
            isImageID.ImageID = BicConvert.ToString(menuuserEntity.ImageID);
            ddlTarget.SelectedValue = menuuserEntity.Target;
            txtPageSize.Text = BicConvert.ToString(menuuserEntity.PageSize);
            txtUserName.Value = _oldUserName = BicConvert.ToString(menuuserEntity.UserName);
            chkIsNew.Checked = BicConvert.ToBoolean(menuuserEntity.IsNew);
            reDescription.Content = menuuserEntity.Description;
            ddlRefrenceMenu.SelectedValue = menuuserEntity.RefrenceMenu;
            txtSEOTitle.Text = menuuserEntity.SEOTitle;
            //ddlRefrenceMenu.SelectedValue = BicConvert.ToString(menuuserEntity.RefrenceMenu);
            ismImageId.ImageIDArray = menuuserEntity.ImageArray;
            chkExclusiveSiteMap.Checked = menuuserEntity.ExclusiveSiteMap;
            chkExclusiveNavigatePath.Checked = menuuserEntity.ExclusiveNavigatePath;
            chkExclusiveMenu.Checked = menuuserEntity.ExclusiveMenu;
            txtMetaDescription.Text = menuuserEntity.MetaDescription;
            txtMetaKeyword.Text = menuuserEntity.MetaKeyword;
            txtPageTitle.Text = menuuserEntity.PageTitle;
        }
    }
    protected void Save(object sender, CommandEventArgs e)
    {
        try
        {
            switch (e.CommandName)
            {
                case "Edit":
                    UpdateMenu();
                    break;
            }
        }
        catch (Exception ex)
        {
            BicAjax.Alert(ex.Message);
        }
    }
    protected void UpdateMenu()
    {
        if (BicHtml.GetRequestString("a").Equals("duplicate"))
        {
            if (MenuUserBiz.InsertMenuUser(LoadDataToEntity()))
            {
                BicAdmin.NavigateToList();
            }
            else
            {
                BicHtml.Alert("Có lỗi, Cập nhật danh mục không thành công!");
            }
        }
        else
        {
            if (MenuUserBiz.UpdateMenuUser(LoadDataToEntity()))
            {
                BicAdmin.NavigateToList();
            }
            else
            {
                BicHtml.Alert("Có lỗi, Cập nhật danh mục không thành công!");
            }
        }
    }
    private MenuUserEntity LoadDataToEntity()
    {
        var menuuserEntity = new MenuUserEntity
        {
            MenuUserId = BicConvert.ToInt32(_id),
            LanguageKey = ddlLanguage.SelectedValue,
            IsActive = chkIsActive.Checked,
            Name = txtName.Text,
            //ParentID = BicConvert.ToInt32(hfParentId.Value),
            TypeID = BicConvert.ToInt32(ddlModelMenu.SelectedValue),
            URL = BicConvert.ToString(txtUrl.Text),
            FrameViewID = BicConvert.ToInt32(ddlFrameViewID.SelectedValue),
            ImageID = BicConvert.ToInt32(isImageID.ImageID),
            Target = ddlTarget.SelectedValue,
            PageSize = BicConvert.ToInt32(txtPageSize.Text),
            UserName = txtUserName.Value,
            IsNew = BicConvert.ToBoolean(chkIsNew.Checked),
            RequireLogin = chkRequireLogin.Checked,
            Description = reDescription.Content,
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
        // Lay ParentID khi duplicate menuuser tu treeview
        if (!string.IsNullOrEmpty(BicHtml.GetRequestString("a")))
        {
            var tvParentId = rcbMenuUser.Items[0].FindControl("tvParentId") as RadTreeView;
            if (tvMenuUser != null)
                menuuserEntity.ParentID = BicConvert.ToInt32(tvParentId.SelectedValue);
        }
        else
            menuuserEntity.ParentID = BicConvert.ToInt32(hfParentId.Value);

        if (txtUserName.Value != _oldUserName)
        {
            string[] arrMenu = BicString.SplitComma(MenuUserUtils.GetArrayMenuIdByParent(_id));
            foreach (string s in arrMenu)
            {
                if (BicConvert.ToInt32(s) == 0) break;
                UpdatePermission(BicConvert.ToInt32(s), txtUserName.Value);
            }
        }
        return menuuserEntity;
    }
    protected void UpdatePermission(int menuid, string value)
    {
        var dh = new DataHelper();
        bool b = dh.UpdateColumn("UserName", value, "MenuUserID", menuid.ToString(), "MenuUser");
    }
}