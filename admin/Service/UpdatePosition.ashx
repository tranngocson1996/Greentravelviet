<%@ WebHandler Language="C#" Class="UpdatePosition" %>

using System;
using System.Web;
using BIC.Data;
using BIC.Utils;

public class UpdatePosition : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        var dhChange = new DataHelper();
        dhChange.ChangePosition(
            BicConvert.ToInt32(QueryString("currentID", "0")), QueryString("columID", string.Empty),
            BicConvert.ToInt32(QueryString("position", "0")), QueryString("tableName", string.Empty));
        context.Response.Write("");
    }
    public string QueryString(string param, string defaultValue)
    {
        return !string.IsNullOrEmpty(HttpContext.Current.Request.QueryString[param]) ? HttpContext.Current.Request.QueryString[param] : defaultValue;
    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}