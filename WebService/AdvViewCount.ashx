<%@ WebHandler Language="C#" Class="CommentReview" %>

using System;
using System.Text;
using System.Web;
using System.Web.SessionState;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Utils;

public class CommentReview : IHttpHandler, IRequiresSessionState
{
    public void ProcessRequest(HttpContext context)
    {
        var viewcount = ConvertToBase64("viewcount");
        var advId = context.Request.QueryString["id"];
        AdvEntity advEntity = AdvBiz.GetAdvByID(BicConvert.ToInt32(advId));
        var ip = ConvertToBase64(HttpContext.Current.Request.UserHostAddress + advId);
        var cookie = new HttpCookie(ip);
        if (HttpContext.Current.Request.Cookies[ip] != null)
            cookie = HttpContext.Current.Request.Cookies[ip];

        else
            HttpContext.Current.Response.Cookies.Add(cookie);
        if (string.IsNullOrEmpty(cookie.Value) || cookie.Value != viewcount)
        {
            if (advEntity != null)
            {
                var dh = new DataHelper();
                dh.UpdateColumn("ViewCount", advEntity.ViewCount + 1, "AdvID", advEntity.AdvID.ToString(), "Adv");
                AdvBiz.PurgeCacheItems("Adv_Adv");
                HttpContext.Current.Response.Cookies.Add(cookie);
                BicAjax.Open(advEntity.Url, advEntity.Target);
            }
        }

    }
    private string ConvertToBase64(object input)
    {
        try
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(input.ToString())).Replace("=", "");
        }
        catch (Exception)
        {
            return input.ToString();
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}