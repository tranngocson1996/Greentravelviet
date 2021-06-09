using System;
using System.IO;
using System.Linq;
using System.Web.Security;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Handler;
using BIC.Utils;

public partial class Controls_User_MemberManage : System.Web.UI.UserControl
{
    public string LoginStatus
    {
        get { return BicMemberShip.CurrentUserName == string.Empty ? "hidden" : ""; }

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        string url = Request.Url.ToString();
        if (url.Contains("shopping-cart"))
        {
            liCart.Visible = false;
            liCart2.Visible = false;
        }
        if (IsPostBack)
        {
            // không clear trường password sau khi postback
            if (!string.IsNullOrEmpty(Txt_MatKhau.Text.Trim()))
                Txt_MatKhau.Attributes["value"] = Txt_MatKhau.Text;
            if (!string.IsNullOrEmpty(Txt_XacNhanMatKhau.Text.Trim()))
                Txt_XacNhanMatKhau.Attributes["value"] = Txt_XacNhanMatKhau.Text;
        }
        else
        {
            LoaddlDateOfBirth();
            BindDropDownCity();
            BindDropDownDistrict();
        }
        //Login
        Txt_User.Attributes.Add("onkeypress", "return clickButton(event,'" + btn_login.ClientID + "')");
        Txt_Password.Attributes.Add("onkeypress", "return clickButton(event,'" + btn_login.ClientID + "')");
        //Register
        Txt_TenDangNhap.Attributes.Add("onkeypress", "return clickButton1(event,'" + btn_dangky.ClientID + "')");
        Txt_MatKhau.Attributes.Add("onkeypress", "return clickButton1(event,'" + btn_dangky.ClientID + "')");
        Txt_XacNhanMatKhau.Attributes.Add("onkeypress", "return clickButton1(event,'" + btn_dangky.ClientID + "')");
        Txt_Ten.Attributes.Add("onkeypress", "return clickButton1(event,'" + btn_dangky.ClientID + "')");
        Txt_DienThoai.Attributes.Add("onkeypress", "return clickButton1(event,'" + btn_dangky.ClientID + "')");
        txtDateOfBirth.Attributes.Add("onkeypress", "return clickButton1(event,'" + btn_dangky.ClientID + "')");
        txtCompany.Attributes.Add("onkeypress", "return clickButton1(event,'" + btn_dangky.ClientID + "')");
        txtAddress.Attributes.Add("onkeypress", "return clickButton1(event,'" + btn_dangky.ClientID + "')");
        Txt_Email.Attributes.Add("onkeypress", "return clickButton1(event,'" + btn_dangky.ClientID + "')");
        capComment.Attributes.Add("onkeypress", "return clickButton1(event,'" + btn_dangky.ClientID + "')");

        if (BicMemberShip.CurrentUserName == "")
        {
            From_DN.Visible = true;
        }
        else
        {
            From_DN.Visible = false;
        }
        var link = Request.Url.ToString();
        if (link.Contains("/shopping-cart."))
        {
            //LinkButton4.Visible = false;
            LinkButton3.Text = "Thông tin cá nhân";
        }
        else
        {
            //LinkButton4.Visible = true;
        }
    }
    protected void LoaddlDateOfBirth()
    {
        for (int i = 1; i <= 31; i++)
        {
            if (i == 1) { ddlDay.Items.Add(new ListItem("Ngày", "0")); }
            ddlDay.Items.Add(new ListItem(i.ToString(), i.ToString()));
        }

        for (int i = 1; i <= 12; i++)
        {
            if (i == 1) { ddlMonth.Items.Add(new ListItem("Tháng", "0")); }
            ddlMonth.Items.Add(new ListItem(i.ToString(), i.ToString()));
        }

        for (int i = DateTime.Now.Year; i >= (DateTime.Now.Year - 80); i--)
        {
            if (i == 1) { ddlYear.Items.Add(new ListItem("Năm", "0")); }
            ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
        }
    }
    protected void lb_Register_Onclick(object sender, EventArgs e)
    {
        Panel_Register.Attributes.CssStyle.Add("display", "block");
        Panel_Login.Attributes.CssStyle.Add("display", "none");
    }
    protected void Close_Register_Click(object sender, EventArgs e)
    {
        Panel_Register.Attributes.CssStyle.Add("display", "none");
        Panel_Login.Attributes.CssStyle.Add("display", "none");
    }

    protected void btn_dangky_Click(object sender, EventArgs e)
    {
        Register();
    }



    //private void BindingCity()
    //{
    //    ddlCity.DataSource = CityBiz.GetAllCitys();
    //    ddlCity.DataTextField = "CityName";
    //    ddlCity.DataValueField = "CityID";
    //    ddlCity.DataBind();
    //    ddlCity.Items.Insert(0, new ListItem("[ Chọn thành phố ]", "0"));
    //}

    protected void Register()
    {
        try
        {
            //------ term agreement -----------
            //if (chkTermAgree.Checked)
            //{
            //-------- check valid of capcha confimation -----------
            if (capComment.IsValid)
            {
                string confirmCode = BicConvert.ToString(Guid.NewGuid());

                var user = Membership.CreateUser(Txt_TenDangNhap.Value.Trim().ToLower(), Txt_MatKhau.Text,
                                                 Txt_Email.Value);

                user.IsApproved = true;
                Membership.UpdateUser(user);

                string date;
                if (ddlDay.SelectedValue != "0" && ddlMonth.SelectedValue != "0" && ddlYear.SelectedValue != "0")
                { date = ddlDay.SelectedValue + "/" + ddlMonth.SelectedValue + "/" + ddlYear.SelectedValue; }
                else { date = "1/1/1940"; }

                var profile = Profile.GetProfile(user.UserName);
                profile.FullName = Txt_Ten.Text;
                //if (ddlCity.SelectedIndex != 0)
                //{
                //    profile.City = ddlCity.SelectedItem.Text;
                //}
                //else
                //{
                //    profile.City = string.Empty;
                //}
                profile.Address = txtAddress.Text;
                profile.Phone = Txt_DienThoai.Text;
                profile.Mobile = Txt_DienThoai.Text;
                profile.ConfirmStatus = true;
                if (ddlCity.SelectedIndex != 0)
                    profile.City = ddlCity.SelectedItem.Text;
                if (ddlDistrict.SelectedIndex != 0)
                    profile.District = ddlDistrict.SelectedItem.Text;
                //profile.Nip = txtNip.Text;
                profile.Company = txtCompany.Text;
                //profile.GioiTinh = "True";

                profile.Birth = date;
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
                //if (!chkNotEmail.Checked)
                //{
                if (SendMailUser(Txt_Email.Value, Txt_TenDangNhap.Value))
                {

                    //Message_Server.InnerHtml =
                    //    "<div id='Message_Server' style='color: #339900 !important;' runat='server' class='Div_Message ThongBao'>" +
                    //    BicResource.GetValue("UserManager", "REGISTER_SUCC") + "</div>";

                    BicAjax.Alert(BicResource.GetValue("UserManager", "REGISTER_SUCC"));

                    ClearForm();
                    Panel_Register.Attributes.CssStyle.Add("display", "none");
                    //   BicAjax.Alert(BicResource.GetValue("Message", "REGISTER_SUCC"));
                }
                //}
                else
                {
                    //Message_Server.InnerHtml =
                    //      "<div id='Message_Server' style='color: #339900 !important;' runat='server' class='Div_Message ThongBao'>" +
                    //      BicResource.GetValue("UserManager", "REGISTER_SUCC") + "</div>";
                    BicAjax.Alert(BicResource.GetValue("UserManager", "REGISTER_SUCCNOTEMAIL"));
                    ClearForm();
                    //Panel_Register.Attributes.CssStyle.Add("display", "none");
                }


            }
            else
                Message_Server.InnerHtml =
                    "<div id='Message_Server' runat='server' class='Div_Message ThongBao'>" +
                    BicResource.GetValue("UserManager", "REGISTER_ERR_CAPTCHA") + "</div>";
            //}
            //else
            //{
            //    Message_Server.InnerHtml = "<div id='Message_Server' runat='server' class='Div_Message ThongBao'>" +
            //                               BicResource.GetValue("UserManager", "Register_Terms_Aggreement") + "</div>";
            //}
        }
        catch (Exception e)
        {
            Message_Server.InnerHtml = "<div id='Message_Server' runat='server' class='Div_Message ThongBao'>" +
                                       e.Message + "!</div>";
        }


    }


    private void ClearForm()
    {
        txtAddress.Text = txtDateOfBirth.Text = Txt_DienThoai.Text = Txt_Email.Value = txtUser_Forgot_Pass.Value = Txt_MatKhau.Text = Txt_Password.Text = Txt_Ten.Text = "";
        Txt_TenDangNhap.Value = Txt_User.Text = txtCompany.Text = Txt_XacNhanMatKhau.Text = "";
        //chkNotEmail.Checked = false;
        //ddlCity.SelectedIndex = 0;
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
    //protected bool SendMailUser(string email, string user, string confirmCode)
    //{
    //    try
    //    {
    //        string activeUrl = BicApplication.GetBaseURL +
    //                           String.Format("{0}/{1}/active.html", user, confirmCode);
    //        string subject = BicResource.GetValue("Register_Mail_Subject") +" "+ Request.Url.Host;
    //        string content = BicHtml.GetContents(string.Format("~/Controls/User/active_account_{0}.htm", BicLanguage.CurrentLanguage));
    //        content = content.Replace("[Domain]", BicXML.ToString("Domain", "MailConfig"));
    //        content = content.Replace("[Username]", user);
    //        content = content.Replace("[SaleMail]", BicXML.ToString("SaleMail", "MailConfig"));
    //        content = content.Replace("[Email]", email);
    //        content = content.Replace("[ActiveUrl]", activeUrl);
    //        return BicEmail.SendToCustomer(email, subject, content) && BicEmail.SendContactToWebMaster(content, email, subject);
    //    }
    //    catch (Exception ex)
    //    {
    //        LogEvent.LogToFile(ex.ToString());
    //        return false;
    //    }
    //}

    protected void Cancel(object sender, EventArgs e)
    {
        MembershipUser logoutUser = Membership.GetUser();
        if (logoutUser != null)
        {
            logoutUser.Comment = string.Empty;
            Membership.UpdateUser(logoutUser);
        }
        FormsAuthentication.SignOut();
        Response.Redirect(Request.Url.AbsolutePath);
    }

    protected void lb_Login_Click(object sender, EventArgs e)
    {
        Panel_Login.Attributes.CssStyle.Add("display", "block");
        Panel_Register.Attributes.CssStyle.Add("display", "none");
    }
    protected void lb_Login_Click2(object sender, EventArgs e)
    {
        var c = BicMemberShip.CurrentUserName;
        if (c != "")
        {
            Response.Redirect("/" + BicLanguage.CurrentLanguage + "/edit-profile.html");
        }
        else
        {
            Panel_Login.Attributes.CssStyle.Add("display", "block");
            Panel_Register.Attributes.CssStyle.Add("display", "none");
        }
    }
    protected void Close_Login_Click(object sender, EventArgs e)
    {
        Panel_Login.Attributes.CssStyle.Add("display", "none");
    }

    //quên mật khẩu

    protected void Close_ForgotPass_Click(object sender, EventArgs e)
    {
        Panel_ForgotPass.Visible = false;
        lblCorrectCode.Text = "";
        txtEmail_Forgot_Pass.Value = "";
        txtUser_Forgot_Pass.Value = "";
    }
    protected void Call_Forgot_Pass_Click(object sender, EventArgs e)
    {
        Panel_Login.Attributes.CssStyle.Add("display", "none");
        Panel_ForgotPass.Visible = true;
    }

    protected void Lbt_Send_Click(object sender, EventArgs e)
    {
        var user = Membership.GetUser(txtUser_Forgot_Pass.Value);

        if (user != null)
        {
            user.UnlockUser();
            string newpassword = user.ResetPassword();
            if (SendMailRecoverPassword(user.Email, user.UserName, newpassword))
                Div_Forgot.InnerHtml =
          "<div id='Div_Forgot'  style='color: #339900 !important;'  runat='server' class='messageForgot ThongBao'>" +
          BicResource.GetValue("UserManager", "RecoverSuccessfull") + "</div>";
            //lblCorrectCode.Text = "<div class='Errortext'>" + BicResource.GetValue("UserManager", "RecoverSuccessfull") + "</div>";
            else
                Div_Forgot.InnerHtml =
           "<div id='Div_Forgot' runat='server' class='messageForgot ThongBao'>" +
           BicResource.GetValue("UserManager", "REGISTER_FAIL_ACTIVE") + "</div>";
            //lblCorrectCode.Text = "<div class='Errortext'>" + BicResource.GetValue("UserManager", "REGISTER_FAIL_ACTIVE") + "</div>";
            txtUser_Forgot_Pass.Value = txtEmail_Forgot_Pass.Value = "";
        }
        else
            Div_Forgot.InnerHtml =
                       "<div id='Div_Forgot' runat='server' class='messageForgot ThongBao'>" +
                       BicResource.GetValue("UserManager", "CheckUserEmail") + "</div>";
        //lblCorrectCode.Text = "<div class='Errortext'>" + BicResource.GetValue("UserManager", "CheckUserEmail") + "</div>";

    }
    protected bool SendMailRecoverPassword(string email, string username, string password)
    {
        var subjectToMember = "Khôi phục mật khẩu tài khoản của bạn từ vnp.com.vn";

        var contentToMember = "Đã thay đổi mật khẩu trên vnp.com.vn Dưới đây bạn sẽ tìm thấy thông tin về tài khoản mới:<br/>";
        contentToMember += "<b>Tên đăng nhập:</b>" + username + "<br/>";
        contentToMember += "<b>Mật khẩu mới:</b>" + password + "<br/>";
        contentToMember += "Cảm ơn bạn đã sử dụng dịch vụ của chúng tôi!";

        var subjectToWebMaster = "Một thành viên của vnp.com.vn vừa yêu cầu thay đổi mật khẩu. <br/>";
        var contentToWebMaster = "<b>Tên đăng nhập:</b>" + username + "<br/>";
        //contentToWebMaster += "<b>Mật khẩu mới:</b>" + password + "<br/>";

        //-------- send mail to member and web master -----------------
        var test = BicEmail.SendToCustomer(email, subjectToMember, contentToMember);
        // var masterTest = BicEmail.SendContactToWebMaster(contentToWebMaster, email, subjectToWebMaster);

        //if (test == true && masterTest == true)
        if (test)
            return true;
        else
            return false;
    }

    protected void chkNotEmail_CheckedChanged(object sender, EventArgs e)
    {
        //if (chkNotEmail.Checked)
        //    trEmail.Visible = false;
        //else
        //    trEmail.Visible = true;
    }

    protected void BindDropDownCity()
    {
        ddlCity.Items.Clear();
        var lstCity = CityBiz.GetAllCitys();
        if (!lstCity.Any()) return;
        ddlCity.DataSource = lstCity;
        ddlCity.DataTextField = "CityName";
        ddlCity.DataValueField = "CityID";
        ddlCity.DataBind();
        ddlCity.Items.Insert(0, new ListItem("-- Chọn Tỉnh/Thành phố --", "0"));
        ddlCity.SelectedIndex = 24;
    }

    protected void BindDropDownDistrict()
    {
        ddlDistrict.Items.Clear();
        if (ddlCity.SelectedValue == "0")
            ddlDistrict.Items.Insert(0, new ListItem("-- Chọn Quận/Huyện --", "0"));
        else
        {
            var lstDist = DistrictBiz.GetDistrictByCityID(BicConvert.ToInt32(ddlCity.SelectedValue));
            if (lstDist.Any())
            {
                ddlDistrict.DataSource = lstDist;
                ddlDistrict.DataTextField = "DistrictName";
                ddlDistrict.DataValueField = "DistrictID";
                ddlDistrict.DataBind();
                ddlDistrict.Items.Insert(0, new ListItem("-- Chọn Quận/Huyện --", "0"));
            }
            else
            {
                ddlDistrict.Items.Clear();
                ddlDistrict.Items.Insert(0, new ListItem("-- Chọn Quận/Huyện --", "0"));
            }
        }
    }

    protected void ddlCity_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        BindDropDownDistrict();
    }
}