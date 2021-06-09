<%@ WebHandler Language="C#" Class="Comment" %>

using System;
using System.Linq;
using System.Web;
using BIC.Biz;
using BIC.Utils;

public class Comment : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        var parentid = context.Request.QueryString["id"];
        var comments = CommentBiz.GetByParent(BicConvert.ToInt32(parentid));
        var htmloutput = @"<div class='ccItem'>
                            <div class='ccAvatar {1}'>
                            </div>
                            <div class='ccInfo'>
                                <span class='ccName'>{0}<i>{2:(HH:mm - dd.MM.yyyy)}</i></span>
                                <div class='cagree'>
                                    <a class='agree' value='{6}'><i>({3})</i> Đồng ý</a>|<a class='disagree' value='{6}'><i>({4})</i> Không đồng ý</a>
                                </div>
                            </div>
                            <div class='ccComment f8'>
                                <i class='oq'></i>{5}
                            </div>
                        </div>";
        context.Response.ContentType = "text/plain";
        foreach (var commentEntity in comments.Where(commentEntity => commentEntity.IsActive != null && commentEntity.IsActive.Value))
        {
            context.Response.Write(string.Format(htmloutput, commentEntity.FullName, (commentEntity.GioiTinh != null && !commentEntity.GioiTinh.Value ? string.Empty : "male") + (string.IsNullOrEmpty(commentEntity.Address) ? string.Empty : " member"), commentEntity.CreateDate, commentEntity.DongY, commentEntity.KhongDongY, commentEntity.Description, commentEntity.CommentID));
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