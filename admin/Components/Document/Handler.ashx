<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;
using System.Web.Security;
using System.Text;

public class Handler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        MembershipUserCollection allUsers = Membership.GetAllUsers();
        string[] k = context.Request.QueryString["q"].Split(',');
        var sb = new StringBuilder();
        if(k.Length != 0)
        {
            allUsers = Membership.FindUsersByName("%" + k[(k.Length - 1)].Trim() + "%");
            foreach(MembershipUser user in allUsers)
            {
                if(!user.UserName.Equals("administrator"))
                    sb.Append(user).Append(Environment.NewLine);
            }
            string[] sRoles = Roles.GetAllRoles();
            foreach(var t in sRoles)
            {
                if(t.ToLower().IndexOf(k[(k.Length - 1)].Trim().ToLower()) != -1)
                    sb.Append(t).Append(Environment.NewLine);
            }
        }
        context.Response.Write(sb.ToString());
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}