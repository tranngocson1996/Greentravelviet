<%@ WebHandler Language="C#" Class="ListImg" %>

using System;
using System.IO;
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
        try
        {
            context.Response.ContentType = "text/plain";
            var sb = new StringBuilder();
            string q = context.Request.QueryString["id"];
            int mess = 0;
            int count = 0;
            if (!string.IsNullOrEmpty(q))
            {
                string[] list = q.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
                foreach (string s in list)
                {
                    ImageEntity imageEntity = ImageBiz.GetImageByID(BicConvert.ToInt32(s));
                    if (imageEntity != null)
                    {
                        if (!string.IsNullOrEmpty(imageEntity.Name))
                        {
                            string pathfile = BicApplication.URLPath(imageEntity.Path) + imageEntity.Name;
                            string paththumb = BicApplication.URLPath(imageEntity.Path + "thumb") + imageEntity.Name;
                            string realfile = BicApplication.RealPath + imageEntity.Path + imageEntity.Name;
                            string realthumb = BicApplication.RealPath + imageEntity.Path + "thumb/" + imageEntity.Name;
                            if (File.Exists(realfile))
                            {
                                if (BicFile.Delete(pathfile, realfile))
                                {
                                    if (File.Exists(realthumb))
                                    {
                                        if (BicFile.Delete(paththumb, realthumb))
                                        {
                                            if (ImageBiz.DeleteImage(BicConvert.ToInt32(s)))
                                                count++;
                                        }
                                    }
                                    else
                                    {
                                        if (ImageBiz.DeleteImage(BicConvert.ToInt32(s)))
                                            count++;
                                    }
                                }
                            }
                            else
                            {
                                if (File.Exists(realthumb))
                                {
                                    if (BicFile.Delete(paththumb, realthumb))
                                    {
                                        if (ImageBiz.DeleteImage(BicConvert.ToInt32(s)))
                                            count++;
                                    }
                                }
                                else
                                {
                                    if (ImageBiz.DeleteImage(BicConvert.ToInt32(s)))
                                        count++;
                                }
                            }
                        }
                        else
                        {
                            if (ImageBiz.DeleteImage(BicConvert.ToInt32(s)))
                                count++;
                        }
                    }
                }
                mess = list.Length - count;
            }
            context.Response.Write(mess.ToString());
        }
        catch (Exception ex)
        {
            LogEvent.LogToFile(ex.ToString());
        }
    }

    public bool IsReusable
    {
        get { return false; }
    }

    #endregion
}