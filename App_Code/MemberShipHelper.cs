using System;
using System.Web;
using System.Web.Security;

public class FormsAuthSessionEnforcement : IHttpModule
{
    #region IHttpModule Members

    public void Init(HttpApplication context)
    {
        context.PostAuthenticateRequest += OnPostAuthenticate;
    }

    public void Dispose()
    {
    }

    #endregion

    private void OnPostAuthenticate(Object sender, EventArgs e)
    {
        var a = (HttpApplication) sender;
        HttpContext c = a.Context;
        var g = new Guid();
        //If the user was authenticated with Forms Authentication
        //Then check the session ID.
        if (c.User.Identity.IsAuthenticated)
        {
            FormsAuthenticationTicket ft =
                ((FormsIdentity) c.User.Identity).Ticket;
            try
            {
                g = new Guid(ft.UserData);
            }
            catch
            {
            }

            MembershipUser loginUser = null;

            try
            {
                loginUser = Membership.GetUser(ft.Name);
            }
            catch
            {
            }

            Guid currentSession;
            //If there isn't any session information in Membership at this point
            //then it is likely the user logged out, and an old cookie is
            //being replayed.
            if (loginUser != null)
            {
                if (!String.IsNullOrEmpty(loginUser.Comment))
                {
                    string currentSessionString =
                        loginUser.Comment.Split("|".ToCharArray())[1];
                    currentSession = new Guid(currentSessionString.Split(";".ToCharArray())[1]);
                }
                else
                    currentSession = Guid.Empty;

                //If the session in the cookie does not match the current session as stored
                //in the Membership database, then terminate this request
                try
                {
                    if (g != currentSession)
                    {
                        FormsAuthentication.SignOut();
                        FormsAuthentication.RedirectToLoginPage();
                    }
                }
                catch
                {
                }
            }
        }
    }
}