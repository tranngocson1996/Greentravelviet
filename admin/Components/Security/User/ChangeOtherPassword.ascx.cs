using System;
using System.Web.Security;
using System.Web.UI.WebControls;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_ChangeOtherPassword : BaseUserControl
{
    protected void Save(object sender, CommandEventArgs e)
    {
        try
        {
            switch (e.CommandName)
            {
                case "ChangePassword":
                    ChangePass();
                    break;
            }
        }
        catch (Exception ex)
        {
            BicAjax.Alert(ex.Message);
        }
    }
    protected void ChangePass()
    {
        string userName = Request.Form["txtUserName"];
        MembershipUser user = Membership.GetUser(userName);
        string resetpass = user.ResetPassword();
        BicAjax.Alert(user.ChangePassword(resetpass, ConfirmNewPassword.Text) ? string.Format(BicResource.GetValue("Admin", "Admin_Security_User_Message6"), userName) : string.Format(BicResource.GetValue("Admin", "Admin_Security_User_Message7"), userName));
    }
}