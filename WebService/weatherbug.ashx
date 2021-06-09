<%@ WebHandler Language="C#" Class="weatherbug" %>

using System;
using System.Linq;
using System.Web;
using BIC.Utils;
using System.Text.RegularExpressions;
public class weatherbug : IHttpHandler
{
    private string[] rates = { "USD", "EUR" };
    public void ProcessRequest(HttpContext context)
    {
        var key = "Weather_" + context.Request.QueryString["city"];
        try
        {
            var city = context.Request.QueryString["city"];
            if (!string.IsNullOrEmpty(city))
            {
                var content = Utils.GetWebContent(string.Format("http://pogoda.yandex.ru/{0}/", city));
                var regexall = new Regex("<table class=\"b-rotator-place\"(.+?)</table>");
                var regexwe = new Regex("<div class=\"b-thermometer__now\">(.+?)</div>");
                var regexim = new Regex("<img class=\"b-ico\"(.+?)>");
                var match = regexall.Match(content).ToString();
                string result =
                    (regexim.Match(match).ToString() + regexwe.Match(match).ToString()).Replace(
                        "onclick=\"return {name:'b-ico'}\"", string.Empty).Replace("b-ico", "scwIcon").Replace(
                            "b-thermometer__now", "scwNow").Replace("div", "span");
                context.Response.ContentType = "text/html";
                context.Response.Write(result);
                BizObject.CacheData(key, result);
            }
            else
            {
                city = context.Request.QueryString["rate"];

                if (!string.IsNullOrEmpty(city))
                {
                    var content = Utils.GetWebContent("http://mail.ru/");
                    var regex = new Regex("<span class=\"quotations__item__rate__text\">(.+?)</span>");
                    var results = regex.Matches(content);
                    context.Response.ContentType = "text/html";
                    context.Response.Write(results[Array.IndexOf(rates, city.ToUpper())]);

                    BizObject.CacheData(key, results[Array.IndexOf(rates, city.ToUpper())]);
                    //if (results.Cast<object>().Any(result => double.TryParse(result.ToString().Replace("<td class=\"q1Ttd4\">", string.Empty).Replace("</td>", string.Empty), out rate)))
                    //{
                    //    context.Response.Write(rate);
                    //}
                }
            }
        }
        catch (Exception)
        {
            context.Response.ContentType = "text/html";
            context.Response.Write(BizObject.Cache[key] != null ? BizObject.Cache[key].ToString() : string.Empty);
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