<%@ WebHandler Language="C#" Class="ListImg" %>

using System;
using System.Text;
using System.Web;
using BIC.Biz;
using BIC.Entity;
using BIC.Handler;
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
        try
        {
            if (!string.IsNullOrEmpty(q))
            {
                {
                    if (q.Equals("0") && BicConvert.ToInt32(q) == 0)
                    {
                        sb.Append(string.Format("<img class='imgSelect' alt='' id='htmlImage' src='{0}admin/Styles/icon/select_Video.jpg'/>", BicApplication.URLRoot));
                    }
                    else
                    {
                        string[] list = q.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
                        ImageEntity imageEntity = ImageBiz.GetImageByID(VideoBiz.GetVideoByID(BicConvert.ToInt32(list[0].Trim())).ImageID);
                        if (imageEntity != null)
                        {
                            sb.Append("<img id='").Append(imageEntity.ImageID).Append("' class='imgSelect' alt='").Append(!string.IsNullOrEmpty(imageEntity.Name) ? imageEntity.Name : imageEntity.Path).Append("' border='0' width='119px' height='84px' src='");
                            sb.Append(!string.IsNullOrEmpty(imageEntity.Name) ? string.Format(isThumb ? "{0}thumb/{1}" : "{0}{1}", BicApplication.URLPath(imageEntity.Path), imageEntity.Name) : imageEntity.Path).Append("' />");
                            sb.Append("<div class='image-del'></div>");
                        }
                        else
                        {
                            sb.Append("<img class='imgSelect' alt='' id='htmlImage' src='").Append(BicApplication.URLPath("admin/Styles/icon")).Append("select_Video.jpg'/>");
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            LogEvent.LogToEvent(ex.ToString());
            sb.Append(string.Format("<img class='imgSelect' alt='' id='htmlImage' src='{0}admin/Styles/icon/select_Video.jpg'/>", BicApplication.URLRoot));
        }
        context.Response.Write(sb.ToString());
    }
    public bool IsReusable
    {
        get { return false; }
    }
    #endregion
}