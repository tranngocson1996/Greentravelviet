using System;
using System.Web.UI.WebControls;
using BIC.Handler;
using BIC.Utils;
using BIC.WebControls;
using BIC.Biz;
using System.IO;
using Oauth2Login.Service;
using System.Web.Security;

public partial class Controls_User_ModalRegister : BaseUIControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }
    protected void btnLoginFacebook_OnClick(object sender, EventArgs e)
    {
        var service = BaseOauth2Service.GetService("facebook");
        if (service != null)
        {
            var url = service.BeginAuthentication();
            Response.Redirect(url);
        }
    }
    protected void btnLoginGoogle_OnClick(object sender, EventArgs e)
    {
        var service = BaseOauth2Service.GetService("Google");
        if (service != null)
        {
            var url = service.BeginAuthentication();
            Response.Redirect(url);
        }
    }
    protected void Login(string username,string password)
    {
        if (Membership.ValidateUser(username, password))
        {
            FormsAuthentication.SetAuthCookie(username, true);
            BicSession.SetValue("UsernameWasLoggedIn", username);
        }
    }
    protected void Register()
    {
        try
        {
            string confirmCode = BicConvert.ToString(Guid.NewGuid());
            var user = Membership.CreateUser(RegUserName.Value.Trim().ToLower(), RegPassword.Value, RegEmail.Value);
            user.IsApproved = true;
            Membership.UpdateUser(user);
            var profile = Profile.GetProfile(user.UserName);
            profile.FullName = RegUserName.Value;

            profile.Address = "";
            profile.Phone = RegPhone.Value;
            profile.Mobile = RegPhone.Value;
            profile.ConfirmStatus = true;
            profile.City = "";
            profile.District = "";
            profile.Company = "";

            profile.Birth = "";
            profile.ConfirmCode = confirmCode;
            profile.TypeOfUser = "User"; // Tài khoản User (Tài khoản quản trị nhận giá trị Systeam)
            profile.CurrentPoint = "0"; // Điểm tích lũy được
            profile.GiftPoint = "0"; // Điểm được tặng
            profile.UsedPoint = "0"; // Điểm đã sử dụng
            profile.Point = "0"; // Tổng điểm tích lũy
            profile.PointHistory = "";
            profile.Save();
            // Tạo folder chứa ảnh cho từng user
            if (user.ProviderUserKey != null)
            {
                var folderName = user.ProviderUserKey.ToString();
                const string path = "FileUpload/User/";
                var fullPath = string.Format("~/{0}/", path + folderName);
                if (!Directory.Exists(Server.MapPath(fullPath)))
                {
                    Directory.CreateDirectory(Server.MapPath(fullPath));
                }
            }

            if (SendMailUser(RegEmail.Value, RegUserName.Value))
            {
                BicAjax.Alert(BicResource.GetValue("UserManager", "REGISTER_SUCC"));
            }
            else
            {
                BicAjax.Alert(BicResource.GetValue("UserManager", "REGISTER_SUCCNOTEMAIL"));               
            }

            Login(RegUserName.Value.Trim().ToLower(),RegPassword.Value);
            ClearForm();

        }
        catch (Exception ex)
        {
            messenger.InnerHtml = ex.Message;
        }
    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        if(string.IsNullOrEmpty(RegUserName.Value) || !Common.IsEmail(RegEmail.Value) || string.IsNullOrEmpty(RegPassword.Value) || string.IsNullOrEmpty(RegPhone.Value))
        {
            messenger.InnerHtml = "Vui lòng nhập đủ thông tin";
        }
        else
        {
            Register();
        }
    }
    private void ClearForm()
    {
        RegEmail.Value = string.Empty;
        RegPassword.Value = string.Empty;
        RegPasswordComfirm.Value = string.Empty;
        RegPhone.Value = string.Empty;
        RegUserName.Value = string.Empty;
    }

    protected bool SendMailUser(string email, string user)
    {
        try
        {
            string subject = BicResource.GetValue("Register_Mail_Notice") + " " + Request.Url.Host;
            string content = BicHtml.GetContents(string.Format("~/Controls/User/notice_account_{0}.htm", BicLanguage.CurrentLanguage));
            content = content.Replace("[Domain]", BicXML.ToString("Domain", "MailConfig"));
            content = content.Replace("[Username]", user);
            content = content.Replace("[SaleMail]", BicXML.ToString("WebMasterEmail", "MailConfig"));
            content = content.Replace("[Email]", email);
            return BicEmail.SendToCustomer(email, subject, content) && BicEmail.SendContactToWebMaster(content, email, subject);
        }
        catch (Exception ex)
        {
            LogEvent.LogToFile(ex.ToString());
            return false;
        }
    }
}