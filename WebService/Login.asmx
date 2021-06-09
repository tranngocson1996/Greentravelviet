<%@ WebService Language="C#" Class="Login" %>
using System;
using System.Web;
using System.Data;
using System.Globalization;
using System.Text;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Security;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]

public class Login : WebService
{
    [WebMethod]
    public int user_validation(string username)
    {
        if (Membership.GetUser(username) != null)
            return 1;       //error username is exist
        else
            return 0;       //no error
    }

    [WebMethod]
    public int email_validation(string email)
    {
        if (Membership.GetUserNameByEmail(email) != null)
            return 1;      //email exists
        else
            return 0;        //no error
    }


    [WebMethod]
    public int CheckUsername_Email(string username, string email)
    {
        try
        {
            var getUser = Membership.GetUser(username);
            if (getUser.Email == email)
                return 1;
            else
            {
                return 0;
            }
        }
        catch (Exception)
        {

            return 0;
        }
        
    }


    [WebMethod(EnableSession = true)]
    public bool VerifyLogin(string username, string password, string rememberMe)
    {
        try
        {
            if (Membership.ValidateUser(username, password))
            {
                FormsAuthentication.SetAuthCookie(username, true);
                BicSession.SetValue("UsernameWasLoggedIn", username);

                if (rememberMe == "checked")
                {
                    var loginCookie = new HttpCookie("loginCookie");
                    loginCookie["username"] = BicSecurity.Encrypt(username, true);
                    loginCookie["password"] = BicSecurity.Encrypt(password, true);

                    loginCookie.Expires = DateTime.Now.AddDays(30);
                    HttpContext.Current.Response.Cookies.Add(loginCookie);
                }
                else
                    HttpContext.Current.Response.Cookies.Remove("loginCookie");

                return true;
            }
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }


    [WebMethod(EnableSession = true)]
    public bool Logout(string username)
    {
        try
        {
            FormsAuthentication.SetAuthCookie(username, false);
            FormsAuthentication.SignOut();
            BicSession.SetValue("UsernameWasLoggedIn", "");
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}