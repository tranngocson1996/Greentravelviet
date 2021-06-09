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
        string q = context.Request.QueryString["id"];
        const bool isThumb = true;
        if (!string.IsNullOrEmpty(q))
        {
            if (!string.IsNullOrEmpty(context.Request.QueryString["ismulti"]) &&
                context.Request.QueryString["ismulti"] == "0")
            {
                if (q.Equals("0") && BicConvert.ToInt32(q) == 0)
                {
                    sb.Append(
                        string.Format(
                            "<img class='imgSelect' alt='' id='htmlImage' src='{0}admin/Styles/icon/select_image_{1}.jpg'/>",
                            BicApplication.URLRoot, context.Request.QueryString["l"]));
                }
                else
                {
                    string[] list = q.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
                    ImageEntity imageEntity = ImageBiz.GetImageByID(BicConvert.ToInt32(list[0].Trim()));
                    if (imageEntity != null)
                    {
                        sb.Append("<img id='")
                            .Append(imageEntity.ImageID)
                            .Append("' class='imgSelect' alt='")
                            .Append(!string.IsNullOrEmpty(imageEntity.Name)
                                ? imageEntity.Name.SubString(13)
                                : imageEntity.Path)
                            .Append("' border='0' width='119px' height='84px' src='");
                        sb.Append(!string.IsNullOrEmpty(imageEntity.Name)
                            ? string.Format(isThumb ? "{0}thumb/{1}" : "{0}{1}",
                                BicApplication.URLPath(imageEntity.Path), imageEntity.Name)
                            : imageEntity.Path).Append("' />");
                        sb.Append("<div class='image-del'></div>");
                    }
                    else
                    {
                        sb.Append("<img class='imgSelect' alt='' id='htmlImage' src='")
                            .Append(BicApplication.URLPath("admin/Styles/icon"))
                            .Append(string.Format("select_image_{0}.jpg'/>", context.Request.QueryString["l"]));
                    }
                }
            }
            else
            {
                string[] list = q.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
                foreach (string s in list)
                {
                    ImageEntity imageEntity = ImageBiz.GetImageByID(BicConvert.ToInt32(s.Trim()));
                    if (imageEntity != null)
                    {
                        sb.Append("<div class='item ui-state-default'>")
                            .Append("<img id='")
                            .Append(imageEntity.ImageID)
                            .Append("' alt='")
                            .Append(!string.IsNullOrEmpty(imageEntity.Name)
                                ? imageEntity.Name.SubString(13)
                                : imageEntity.Path)
                            .Append("' border='0' width='119px' height='84px' src='");
                        sb.Append(!string.IsNullOrEmpty(imageEntity.Name)
                            ? string.Format(isThumb ? "{0}thumb/{1}" : "{0}{1}",
                                BicApplication.URLPath(imageEntity.Path), imageEntity.Name)
                            : imageEntity.Path).Append("' />");
                        sb.Append("<div id='ibtnDelete")
                            .Append(imageEntity.ImageID)
                            .Append("' val='")
                            .Append(imageEntity.ImageID)
                            .Append("' class='img-del'></div></div>");
                    }
                }
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

public static class Ext
{
    public static string SubString(this string input, int startIndex)
    {
        try
        {
            return input.Substring(13);
        }
        catch (Exception)
        {
            return input;
        }
    }
}