using System;
using System.Web.UI;
using System.Web.Security;
using BIC.Utils;

public partial class Controls_User_PasswordRecovery : System.Web.UI.UserControl
{
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        var user = Membership.GetUser(txtUsername.Text) ?? Membership.GetUser(txtEmail.Text);

        if (user != null)
        {
            user.UnlockUser();
            string newpassword = user.ResetPassword();
            if (SendMailUser(user.Email, user.UserName, newpassword))

                BicAjax.Alert("Khôi phục password thành công! Chúng tôi đã gửi password mới tới email của bạn.");
            else
                BicAjax.Alert("Rất xin lỗi bạn, đã có lỗi xảy ra trong quá trình khôi phục email! Vui lòng thử lại sau.");

        }
        else
            BicAjax.Alert("Tài khoản này không tồn tại trên hệ thống!");
    }

    protected bool SendMailUser(string email, string username, string password)
    {
        var subjectToMember = "Khôi phục password tài khoản từ website TrustLand.vn";

        var contentToMember = "Bạn vừa yêu cầu thay đổi password trên website TrustLand.vn. Dưới đây là thông tin tài khoản mới của bạn:<br/>";
            contentToMember += "<b>UserName:</b>" + username + "<br/>";
            contentToMember += "<b>Mật khẩu mới:</b>" + password + "<br/>";
            contentToMember += "Cảm ơn bạn đã trở thành thành viên tại TrustLand.vn!";

        var subjectToWebMaster = "Một thành viên của TrustLand.vn vừa yêu cầu thay đổi mật khẩu. <br/>";

        var contentToWebMaster = "<b>UserName:</b>" + username + "<br/>";
            contentToWebMaster += "<b>Mật khẩu mới:</b>" + password + "<br/>";

        //-------- send mail to member and web master -----------------
        var test = BicEmail.SendToCustomer(email, subjectToMember, contentToMember);
        var masterTest = BicEmail.SendContactToWebMaster(contentToWebMaster, email, subjectToWebMaster);
        
        if (test == true && masterTest == true)
            return true;
        else
            return false;
    }
}