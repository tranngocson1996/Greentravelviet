<%@ WebHandler Language="C#" Class="bicweb" %>

using System;
using System.Web;

public class bicweb : IHttpHandler
{
    #region IHttpHandler Members
    public void ProcessRequest(HttpContext context)
    {
        string requeststring = context.Request.QueryString["q"];
        string[] files = requeststring.Split(new[] {',', ';'}, StringSplitOptions.RemoveEmptyEntries);
        foreach (string file in files)
        {
        }
    }
    public bool IsReusable
    {
        get { return false; }
    }
    #endregion
}