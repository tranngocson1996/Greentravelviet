<%@ WebHandler Language="C#" Class="ListImageTelerik" %>

using System;
using System.Text;
using System.Web;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;

public class ListImageTelerik : IHttpHandler
{
    #region IHttpHandler Members
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/html";
        var sb = new StringBuilder();
        string q = context.Request.QueryString["id"];
        const bool isThumb = false;
        if(!string.IsNullOrEmpty(q))
        {
            string[] list = q.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach(string s in list)
            {
                ImageEntity imageEntity = ImageBiz.GetImageByID(BicConvert.ToInt32(s.Trim()));
                if(imageEntity != null)
                {
                    sb.Append("<img class='img-editor'").Append(" alt='' border='0'").Append(" src='");
                    sb.Append(!string.IsNullOrEmpty(imageEntity.Name) ? string.Format(isThumb ? "{0}thumb/{1}" : "{0}{1}", BicApplication.URLPath(imageEntity.Path), imageEntity.Name) : imageEntity.Path).Append("' />"+Environment.NewLine);
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