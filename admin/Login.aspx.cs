using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Utils;
using System.Data;

public partial class Admin_Login : Page
{
    protected MembershipUser loginUser;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlAdminLanguage_LoadData();
            lgMain.Focus();
        }
    }

    protected void ddlAdminLanguage_LoadData()
    {
        if (!IsPostBack)
        {
            var ds = new DataSet();
            ds.ReadXml(HttpContext.Current.Server.MapPath(string.Format("~/admin/XMLData/Language.xml")));
            var ddlAdminLanguage = ((DropDownList)lgMain.FindControl("ddlAdminLanguage"));
            ddlAdminLanguage.Items.Clear();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dr["admin"].ToString() == "true")
                    ddlAdminLanguage.Items.Add(new ListItem(dr["name"].ToString(), dr["key"].ToString()));
            }
            if (BicControl.DropExistValue(BicXML.ToString("DefaultLanguageAdmin", "SearchEngine"), ddlAdminLanguage))
                ddlAdminLanguage.SelectedValue = BicXML.ToString("DefaultLanguageAdmin", "SearchEngine");
        }
    }

    protected void lgMain_LoggedIn(object sender, EventArgs e)
    {
        string UserName = ((TextBox)lgMain.FindControl("UserName")).Text;
        if (loginUser == null)
            loginUser = Membership.GetUser(UserName);
        if (loginUser != null)
        {
            loginUser.LastLoginDate = DateTime.Now;
            loginUser.LastActivityDate = DateTime.Now;
            //khởi tạo phiên làm việc mới của người dùng
            Guid g = Guid.NewGuid();

            HttpCookie c = Response.Cookies[FormsAuthentication.FormsCookieName];
            FormsAuthenticationTicket ft = FormsAuthentication.Decrypt(c.Value);

            //Sinh ID của phiên làm việc
            var ftNew =
                new FormsAuthenticationTicket(
                    ft.Version,
                    ft.Name,
                    ft.IssueDate,
                    ft.Expiration,
                    ft.IsPersistent,
                    g.ToString(),
                    ft.CookiePath);
            //Lưu ngày hết hiệu lục và ID phiên làm việc vào membership
            loginUser.Comment =
                "LoginExpiration;" + ft.Expiration +
                "|LoginSessionID;" + g;
            Membership.UpdateUser(loginUser);

            Response.Cookies.Remove(FormsAuthentication.FormsCookieName);

            var newAuthCookie =
                new HttpCookie(
                    FormsAuthentication.FormsCookieName,
                    FormsAuthentication.Encrypt(ftNew));
            newAuthCookie.HttpOnly = c.HttpOnly;
            newAuthCookie.Path = c.Path;
            newAuthCookie.Secure = c.Secure;
            newAuthCookie.Domain = c.Domain;
            newAuthCookie.Expires = c.Expires;

            //And set it back in the response
            Response.Cookies.Add(newAuthCookie);

            //store login log
            LoginLogBiz.InsertLoginLog(UserName);
        }
    }

    protected void lgMain_LoggingIn(object sender, LoginCancelEventArgs e)
    {
        var ddlAdminLanguage = ((DropDownList)lgMain.FindControl("ddlAdminLanguage"));
        lgMain.DestinationPageUrl = string.Format("{0}Admin/Default.aspx?l={1}", BicApplication.URLRoot, ddlAdminLanguage.SelectedValue);
        ProfileCommon profile = Profile;
        string UserName = ((TextBox)lgMain.FindControl("UserName")).Text;
        if (loginUser == null)
        {
            loginUser = Membership.GetUser(UserName);
            profile = Profile.GetProfile(UserName);
        }

        var tx = (Label)lgMain.FindControl("FailureText");
        if (loginUser != null)
        {
            if (loginUser.IsApproved == false)
            {
                e.Cancel = true;
                tx.Text = "Tài khoản của bạn đã bị khóa bởi quản trị - liên hệ quản trị để được trợ giúp!";
            }
            if (loginUser.IsLockedOut)
            {
                e.Cancel = true;
                tx.Text = string.Format(
                    "Bạn đã đăng nhập không thành công {0} lần,<br/> tài khoản của bạn đã bị khóa!",
                    Membership.MaxInvalidPasswordAttempts);
            }
            if (!profile.TypeOfUser.Equals("System") && loginUser.UserName != "administrator")
            {
                e.Cancel = true;
                tx.Text =
                    "Tài khoản của bạn không có quyền đăng nhập khu vực quản trị,<br/> liên hệ quản trị viên để được giúp đỡ!";
            }
        }
        else
            tx.Text = "Tài khoản này không tồn tại!";
    }

}