using System;
using System.Collections.Generic;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using BIC.Utils;
using BIC.WebControls;

public partial class Components_CreateUser : BaseUIControl
{
    private string _role = string.Empty;
    protected void Save(object sender, CommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Insert")
                CreateUser();
        }
        catch (Exception ex)
        {
            BicAjax.Alert(ex.Message);
        }
    }
    protected void CreateUser()
    {
        if (Membership.GetUser(UserName.Text) != null)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "noimageedited", string.Format("alert('" + BicResource.GetValue("Admin", "Admin_Security_User_Message1") + "');"), true);
            return;
        }
        if (Membership.GetUserNameByEmail(UserName.Text) != null)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "noimageedited", string.Format("alert('" + BicResource.GetValue("Admin", "Admin_Security_User_Message2") + "');"), true);
            return;
        }
        if (Password.Text.Length < 4)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "noimageedited", string.Format("alert('" + BicResource.GetValue("Admin", "Admin_Security_User_Message3") + "');"), true);
            return;
        }
        try
        {
            string sUserName = UserName.Text;
            MembershipUser user = Membership.CreateUser(UserName.Text.Trim().ToLower(), Password.Text, Email.Text);
            ProfileCommon profile = Profile.GetProfile(user.UserName);
            Guid g = Guid.NewGuid();
            profile.FullName = txtFullName.Text;
            profile.Address = txtAddress.Text;
            profile.Description = txtDescription.Text;
            profile.Company = txtCompany.Text;
            profile.Phone = txtPhone.Text;
            profile.Mobile = txtMobile.Text;
            profile.TypeOfUser = ddlTypeOfUser.SelectedValue;
            profile.ConfirmCode = g.ToString();
            profile.Save();
            string[] currentRoles = Roles.GetRolesForUser(sUserName);
            if (currentRoles.Length > 0)
                Roles.RemoveUserFromRoles(sUserName, currentRoles);
            var newRoles = new List<string>();
            foreach (ListItem lItem in chklRoles.Items)
            {
                if (lItem.Selected)
                    newRoles.Add(lItem.Text);
            }
            if (newRoles.Count > 0)
                Roles.AddUserToRoles(sUserName, newRoles.ToArray());
            BicHtml.Alert(string.Format(BicResource.GetValue("Admin", "Admin_Security_User_Message4")));
            ClearForm();
        }
        catch (Exception ex)
        {
            BicHtml.Alert(string.Format(BicResource.GetValue("Admin", "Admin_Security_User_Message5") + "\n" + ex.Message));
        }
    }
    private void ClearForm()
    {
        txtPhone.Text = string.Empty;
        txtMobile.Text = string.Empty;
        txtFullName.Text = string.Empty;
        txtDescription.Text = string.Empty;
        txtCompany.Text = string.Empty;
        txtAddress.Text = string.Empty;
        Email.Text = string.Empty;
        Password.Text = string.Empty;
        UserName.Text = string.Empty;
    }
    protected void BindingRoles()
    {
        chklRoles.DataSource = Roles.GetAllRoles();
        chklRoles.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        _role = BicHtml.GetRequestString("role", string.Empty);
        if (!IsPostBack)
        {
            BindingRoles();
            if (!string.IsNullOrEmpty(_role))
                tbTop.LinkBack = string.Format("{0}admin/default.aspx?mid=36&cid=21&role={1}&l={2}", BicApplication.URLRoot, _role, BicHtml.GetRequestString("l", "vi"));
        }
    }
}