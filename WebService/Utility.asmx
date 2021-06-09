<%@ WebService Language="C#" Class="Utility" %>

using System;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.Services.Protocols;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
[System.Web.Script.Services.ScriptService]
public class Utility : System.Web.Services.WebService
{

    [WebMethod(EnableSession = true)]
    public bool UpdateViewVideo(int videoid)
    {
        bool result = false;
        if (videoid != 0)
        {
            VideoEntity videoentity = new VideoEntity();
            videoentity = VideoBiz.GetVideoByID(videoid);
            videoentity.Viewed = videoentity.Viewed + 1;
            if (VideoBiz.UpdateVideo(videoentity))
                result = true;
        }
        return result;
    }
    [WebMethod(EnableSession = true)]
    public string ArticleSlide(int artid, string link)
    {
        StringBuilder sb = new StringBuilder();
        var artentity = new ArticleEntity();
        artentity = ArticleBiz.GetArticleByID(artid);
        sb.Append(artentity.Title).Append(",, ").Append(link).Append(",, ").Append(artentity.Target).Append(",,");
        if (artentity.IsNew)
            sb.Append("<img src='").Append(BicApplication.URLRoot).Append("Styles/icon/newicon.gif").Append("' alt=''/>");
        else
            sb.Append(" ");
        sb.Append(",, ").Append("<a href='").Append(link).Append("' style='display: table-cell;text-align: center; vertical; width:245px;' ><img src='");
        sb.Append(BicApplication.URLRoot).Append(ImageBiz.GetImageByID(artentity.ImageID).Path).Append("thumb/").Append(ImageBiz.GetImageByID(artentity.ImageID).Name);
        sb.Append("' alt='' style='Width:245px; height:auto;'/></a>");
        sb.Append(",,").Append(artentity.BriefDescription);
        return sb.ToString();
    }
}