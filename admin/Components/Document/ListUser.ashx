<%@ WebHandler Language="C#" Class="ListUser" %>

using System;
using System.Web;
using System.Web.Security;
using System.Text;
using BIC.Utils;

public class ListUser : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        var sb = new StringBuilder();
        string[] sRoles = Roles.GetAllRoles();
        sb.Append("<script type='text/javascript'>$(function() {$('#browser').treeview();})</script>");
        sb.Append("<div class='checkkall'><input type='checkbox' id='checkkall'/>Tất cả</div>");
        sb.Append("<ul id='browser' class='filetree'>");
        int i = 0;

        foreach(var t in sRoles)
        {
            sb.Append("<li class='closed' id='roles").Append(i++).Append("'><span >").Append("<input class='roles' id='chk").Append(i++).Append("' type='checkbox' value='").Append(t).Append("'/>").Append(t).Append("</span>");
            sb.Append("<ul>");
            string[] allUsersInRole = Roles.GetUsersInRole(t);
            int j = 0;
            foreach(var user in allUsersInRole)
            {
                if(!user.Equals("administrator"))
                    sb.Append("<li>").Append("<input class='user' id='chk").Append(i++).Append(j++).Append("' type='checkbox' value='").Append(user).Append("'/>").Append(user).Append("</li>");
            }
            sb.Append("</ul></li>");
        }
        sb.Append("</ul>");
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