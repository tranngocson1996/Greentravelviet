using System;
using BIC.Utils;
using BIC.WebControls;

public partial class admin_Components_MenuAdmin_ListingMenuUser : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            MenuUserUtils.BindingModelMenu(ddlModelMenu, BicLanguage.CurrentLanguageAdmin);
            if (BicSession.ToString("Language") != string.Empty)
                ddlLanguage.SelectedValue = BicSession.ToString("Language");
            else
                BicSession.SetValue("Language", ddlLanguage.SelectedValue);
            if (BicSession.ToString("ModelMenu") != string.Empty)
                ddlModelMenu.SelectedValue = BicSession.ToString("ModelMenu");
            else
                BicSession.SetValue("ModelMenu", ddlModelMenu.SelectedValue);
            tvMenuUser.BindingTreeView(ddlLanguage.SelectedValue, ddlModelMenu.SelectedValue);
        }
    }
    protected void ddlModelMenu_SelectedIndexChanged(object o, EventArgs e)
    {
        tvMenuUser.BindingTreeView(ddlLanguage.SelectedValue, ddlModelMenu.SelectedValue);
        BicSession.SetValue("ModelMenu", ddlModelMenu.SelectedValue);
    }
    protected void ddlLanguage_SelectedIndexChanged(object o, EventArgs e)
    {
        tvMenuUser.BindingTreeView(ddlLanguage.SelectedValue, ddlModelMenu.SelectedValue);
        BicSession.SetValue("Language", ddlLanguage.SelectedValue);
    }
}