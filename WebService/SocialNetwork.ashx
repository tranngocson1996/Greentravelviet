<%@ WebHandler Language="C#" Class="SocialNetwork" %>

using System;
using System.Web;
using BIC.Utils;

public class SocialNetwork : IHttpHandler
{
    private string[] urls = {
                                //"http://www.facebook.com/plugins/like.php?href={0}&amp;send=false&amp;layout=button_count&amp;width=100&amp;show_faces=false&amp;action=like&amp;colorscheme=light&amp;font&amp;height=21",
                                "Facebook.aspx?url={0}",
                                "https://plusone.google.com/u/0/_/+1/fastbutton?url={0}%2F&size=medium&count=true&db=1&hl=en-US&jsh=r%3Bgc%2F22821001-a70f00f0",
                                "http://www.facebook.com/plugins/like.php?href={0}&amp;send=true&amp;layout=button_count&amp;width=100&amp;show_faces=false&amp;action=like&amp;colorscheme=light&amp;font&amp;height=21"
                            };

    private string[] socials = { "facebook","google","fbshare" };

    public void ProcessRequest(HttpContext context)
    {
        try
        {
            var type = context.Request.QueryString["Social"].Trim();
            var href = context.Request.QueryString["Url"];
            href = context.Server.HtmlEncode(href);
            var content = Utils.GetWebContent(string.Format(urls[Array.IndexOf(socials, type.ToLower())], href));
            if (string.IsNullOrEmpty(content) || content.Contains("errorTitleText") || content.Contains("http://www.google.com.vn/search")) // List string contain in each browser
            {
                context.Response.ContentType = "text/html";
                context.Response.Write(string.Format("<html><body><link href='{2}' rel='stylesheet' type='text/css'><a href='javascript:alert(\"Chức năng này tạm thời không tải được. Xin hãy kiểm tra lại đường truyền.\");' style='border:none;text-decoration:none;'><img src='{0}{1}_blocked.png' /></a></body></html>", BicApplication.URLRoot + "Styles/img/", type, BicApplication.URLRoot + "Styles/reset.css"));
            }
            else
            {
                context.Response.ContentType = "text/html";
                context.Response.Write(content);
            }
        }
        catch (Exception)
        {
            context.Response.ContentType = "text/html";
            context.Response.Write("This social cannot be supported! Please contact to administrator.");
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