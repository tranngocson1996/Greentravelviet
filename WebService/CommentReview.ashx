<%@ WebHandler Language="C#" Class="CommentReview" %>

using System;
using System.Text;
using System.Web;
using System.Web.SessionState;
using BIC.Biz;
using BIC.Utils;

public class CommentReview : IHttpHandler, IRequiresSessionState
{
    const string HTMLOUTPUT = @"<a class='agree' value='{2}'><i>({0})</i> Đồng ý</a>|<a class='disagree' value='{2}'><i>({1})</i> Không đồng ý</a>";
    const string REP = @"|<a class='comment' value='{0}'>Trả lời</a>";
    
    public void ProcessRequest(HttpContext context)
    {
        var khongdongy = ConvertToBase64("KhongDongY");
        var dongy = ConvertToBase64("DongY");
        var commentid = context.Request.QueryString["id"];
        var review = BicConvert.ToInt32(context.Request.QueryString["vote"]);
        var comment = CommentBiz.GetCommentByID(int.Parse(commentid));
        var reply = context.Request.QueryString["aid"];
        var ip = ConvertToBase64(HttpContext.Current.Request.UserHostAddress + commentid);
        var cookie = new HttpCookie(ip);
        if (HttpContext.Current.Request.Cookies[ip] != null)
            cookie = HttpContext.Current.Request.Cookies[ip];

        else
            HttpContext.Current.Response.Cookies.Add(cookie);
        switch (review)
        {
            case 0:
                if (string.IsNullOrEmpty(cookie.Value) || cookie.Value != dongy)
                    comment.DongY = comment.DongY + 1;
                if (cookie.Value == khongdongy)
                    comment.KhongDongY = comment.KhongDongY - 1;
                cookie.Value = dongy;
                break;
            case 1:
                if (string.IsNullOrEmpty(cookie.Value) || cookie.Value != khongdongy)
                    comment.KhongDongY = comment.KhongDongY + 1;
                if (cookie.Value == dongy)
                    comment.DongY = comment.DongY - 1;
                cookie.Value = khongdongy;
                break;
        }
        HttpContext.Current.Response.Cookies.Add(cookie);
        CommentBiz.UpdateComment(comment);
        context.Response.ContentType = "text/plain";
        context.Response.Write(string.Format(HTMLOUTPUT, comment.DongY, comment.KhongDongY, comment.CommentID) + (!string.IsNullOrEmpty(reply) && reply != "undefined" ? string.Format(REP, reply) : string.Empty));
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