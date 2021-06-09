using System;
using BIC.Utils;
using BIC.WebControls;
using System.Web.Security;

public partial class Controls_User_UserManageChangePassTab : BaseUIControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    protected void btnChangePass_Click(object sender, EventArgs e)
    {
        if (txtNewPassword.Value.Length > 3)
        {
            if ((txtNewPassword.Value == txtReNewPassword.Value))
            {
                var username = BicMemberShip.CurrentUserName;
                if (username != null)
                {
                    var user = Membership.GetUser(username);
                    if (user != null)
                    {
                        BicAjax.Alert(user.ChangePassword(txtPassWord.Value, txtNewPassword.Value)
                       ? "Thay đổi mật khẩu thành công !"
                       : "Mật khẩu cũ không chính xác !");
                        ClearForm();
                    }
                    else
                        BicAjax.Alert("Bạn chưa đăng nhập !");
                }
                else
                    BicAjax.Alert("Bạn chưa đăng nhập !");
            }
            else
                BicAjax.Alert("Mật khẩu xác nhận không phù hợp !");
        }
        else
            BicAjax.Alert("mật khẩu quá ngắn!");
    }

    private void ClearForm()
    {
        txtPassWord.Value = "";
        txtNewPassword.Value = "";
        txtReNewPassword.Value = "";
    }
}