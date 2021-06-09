<%@ WebHandler Language="C#" Class="Tour" %>

using System;
using System.Web;

public class Tour : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        int i = !string.IsNullOrEmpty(context.Request.QueryString["day"]) ? BIC.Utils.BicConvert.ToInt32(context.Request.QueryString["day"].Replace(",", "")) - 1 : 0;
        context.Response.Write(i.ToString());
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}