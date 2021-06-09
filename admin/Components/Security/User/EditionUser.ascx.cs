using System;
using System.Collections.Generic;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_EditUser : BaseUserControl
{
    private string _role = string.Empty;
    private string _sUserName = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        _sUserName = BicHtml.GetRequestString("UserName");
        _role = BicHtml.GetRequestString("role", string.Empty);
        if (!IsPostBack)
        {
  
            if (_sUserName == "administrator" && BicMemberShip.CurrentUserName != "administrator")
               BicAdmin.NavigateToDefault();
            MembershipUser user = Membership.GetUser(_sUserName);
            if (user != null)
            {
                lblUserName.Text = user.UserName;
                lblRegistered.Text = user.CreationDate.ToString("f");
                lblLastLogin.Text = user.LastLoginDate.ToString("f");
                chkApproved.Checked = user.IsApproved;
                chkLookOut.Checked = user.IsLockedOut;
                chkLookOut.Enabled = user.IsLockedOut;
                Email.Text = user.Email;
            }
            //if (user.IsOnline)
            //    lblOnline.Text = "Đang trực tuyến";
            //else
            //    lblOnline.Text = "Không trực tuyến";
            BindingRoles();
            GetProfile();
            if (!string.IsNullOrEmpty(_role))
                tbTop.LinkBack = string.Format("{0}admin/default.aspx?mid=36&cid=21&role={1}&l={2}", BicApplication.URLRoot, _role, BicHtml.GetRequestString("l", "vi"));
            
        }
    }
    protected void BindingRoles()
    {
        chklRoles.DataSource = Roles.GetAllRoles();
        chklRoles.DataBind();
        foreach (string sRole in Roles.GetRolesForUser(_sUserName))
        {
            chklRoles.Items.FindByText(sRole).Selected = true;
        }
    }
    protected void lbtnResetPassword_Click(object sender, EventArgs e)
    {
        MembershipUser user = Membership.GetUser(_sUserName);
        if (user.IsLockedOut)
        {
            //BicAjax.Alert(string.Format("Tài khoản \"{0}\" đã bị khóa \\n Bạn cần mở khóa trước khi thiết lập lại mật khẩu!", _sUserName));
            BicAjax.Alert(string.Format(BicResource.GetValue("Admin", "Admin_Security_User_Message8"), _sUserName));
            return;
        }
        //lblResetPassword.Text = user.ResetPassword();
    }
    //Trả về profile cua user được select
    private void GetProfile()
    {
        ProfileCommon profile = Profile.GetProfile(_sUserName);
        if (profile != null)
        {
            txtFullName.Value = profile.FullName;
            txtAddress.Value = profile.Address;
            txtPhone.Value = profile.Phone;
            txtMobile.Value = profile.Mobile;
            ddlTypeOfUser.SelectedValue = profile.TypeOfUser;
            txtCompany.Text = profile.Company;
            txtDescription.Text = profile.Description;
        }
    }
    public void SaveProfile()
    {
        ProfileCommon profile = Profile.GetProfile(_sUserName);
        if (profile != null)
        {
            profile.FullName = txtFullName.Value;
            profile.Address = txtAddress.Value;
            profile.Phone = txtPhone.Value;
            profile.Mobile = txtMobile.Value;
            profile.TypeOfUser = ddlTypeOfUser.SelectedValue;
            profile.Description = txtDescription.Text;
            profile.Company = txtCompany.Text;
            profile.Save();
        }
    }
    protected void Save(object sender, CommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Update")
            {
                Update();
            }
        }
        catch (Exception ex)
        {
            BicAjax.Alert(ex.Message);
        }
    }
    protected void Update()
    {
        MembershipUser user = Membership.GetUser(_sUserName);
        if (Membership.GetUserNameByEmail(Email.Text) != null && user.Email != Email.Text)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "noimageedited", "alert('Email này đã có người sử dụng, hãy chọn tài khoản khác!');", true);
            Email.Focus();
            return;
        }
        user.IsApproved = chkApproved.Checked;
        if (chkLookOut.Checked == false)
        {
            user.UnlockUser();
        }
        user.Email = Email.Text;
        string[] currentRoles = Roles.GetRolesForUser(_sUserName);
        if (currentRoles.Length > 0)
            Roles.RemoveUserFromRoles(_sUserName, currentRoles);
        var newRoles = new List<string>();
        foreach (ListItem lItem in chklRoles.Items)
        {
            if (lItem.Selected)
                newRoles.Add(lItem.Text);
        }
        if (newRoles.Count > 0)
            Roles.AddUserToRoles(_sUserName, newRoles.ToArray());
        SaveProfile();
        Membership.UpdateUser(user);
        BicAdmin.NavigateToList();
    }
}