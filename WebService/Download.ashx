<%@ WebHandler Language="C#" Class="Download" %>

using System;
using System.Web;
public class Download : IHttpHandler {
  public void ProcessRequest (HttpContext context)
    {
        string file = "";

        // get the file name from the querystring
        if (context.Request.QueryString["Name"] != null)
        {
            file = context.Request.QueryString["Name"];
        }
        string filename = context.Server.MapPath("~/FileUpload/Baigiang/" + file);
        System.IO.FileInfo fileInfo = new System.IO.FileInfo(filename);
        try
        {
            if (fileInfo.Exists)
            {
            
                HttpContext.Current.Response.ContentType = "APPLICATION/OCTET-STREAM";
                String Header = "Attachment; Filename=" + file;
                HttpContext.Current.Response.AppendHeader("Content-Disposition", Header);
                System.IO.FileInfo Dfile = new System.IO.FileInfo(HttpContext.Current.Server.MapPath("~/FileUpload/Baigiang/" + file));
                HttpContext.Current.Response.WriteFile(Dfile.FullName);
                HttpContext.Current.Response.End();
            }
            else
            {
                throw new Exception("File not found");
            }
        }
        catch (Exception ex)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write(ex.Message);
        }
        finally
        {
            context.Response.End();
        }
    }
    public bool IsReusable {
        get {
            return false;
        }
    }
}