using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using BIC.Utils;

public partial class admin_ApproveUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Update();

    }
    protected void Update()
    {
        MembershipUser user = Membership.GetUser(txtUser.Text);

        if (user != null)
        {
            user.IsApproved = true;

            user.UnlockUser();

            Membership.UpdateUser(user);
        }
        BicAjax.Alert("Thành công!");
    }
    protected void btnResetPass_Click(object sender, EventArgs e)
    {
        string userName = txtUser.Text;
        MembershipUser user = Membership.GetUser(userName);
        if (user != null)
        {
            string resetpass = user.ResetPassword();
            Response.Write(resetpass);
        }
       
    }
}