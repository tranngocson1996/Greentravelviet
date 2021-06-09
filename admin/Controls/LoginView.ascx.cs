using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Controls_LoginView : UserControl
{
    protected void lsAdmin_LoggingOut(object sender, LoginCancelEventArgs e)
    {
        MembershipUser logoutUser = Membership.GetUser();
        logoutUser.Comment = string.Empty;
        Membership.UpdateUser(logoutUser);
        FormsAuthentication.SignOut();
    }
}