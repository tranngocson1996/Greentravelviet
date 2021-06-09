<%@ WebHandler Language="C#" Class="ListImg" %>

using System;
using System.Text;
using System.Web;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;

public class ListImg : IHttpHandler
{
    #region IHttpHandler Members
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/html";
        var sb = new StringBuilder();
        string q = context.Request.QueryString["menuid"];
        if(!string.IsNullOrEmpty(q))
        {


            string[] list = q.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            if(list != null)
            {
                sb.Append("<ul id='MenuDrop'>");
                foreach(var s in list)
                {
                    var menuEntity = MenuUserBiz.GetMenuUserByID(BicConvert.ToInt32(s));
                    if(menuEntity != null)
                        sb.Append("<li id='" + menuEntity.MenuUserId + "'>" + menuEntity.Name + "</li>");
                }
                sb.Append("</ul>");
            }

        }
        context.Response.Write(sb.ToString());
    }
    public bool IsReusable
    {
        get { return false; }
    }
    #endregion
}