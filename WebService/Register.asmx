<%@ WebService Language="C#" Class="Register" %>

using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Security;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;
using System.Collections;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]

public class Register : WebService
{

    [WebMethod]
    public bool checkuser(string username)
    {
        if (Membership.GetUser(username.Trim()) != null || Roles.RoleExists(username.Trim()))
            return true;
        else
            return false;
    }

    [WebMethod]
    public int user_validation(string username)
    {
        if (Membership.GetUser(username) != null || Roles.RoleExists(username.Trim()))
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

    [WebMethod(EnableSession = true)]
    public bool VerifyLogin(string username, string password)
    {
        try
        {
            if (Membership.ValidateUser(username, password))
            {
                FormsAuthentication.SetAuthCookie(username, true);
                BicSession.SetValue("UsernameWasLoggedIn", username);
                string test = BicSession.ToString("UsernameWasLoggedIn");
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
            HttpCookie cookei = FormsAuthentication.GetAuthCookie(FormsAuthentication.FormsCookieName, false);
            cookei.Expires = DateTime.Now.AddDays(-1);
            FormsAuthentication.SetAuthCookie(username, false);
            FormsAuthentication.SignOut();
            Session["UsernameWasLoggedIn"] = null;
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}