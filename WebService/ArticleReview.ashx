<%@ WebHandler Language="C#" Class="ArticleReview" %>

using System;
using System.Collections;
using System.Web;
using System.Web.SessionState;
using BIC.Biz;
using BIC.Utils;

public class ArticleReview : IHttpHandler, IRequiresSessionState
{

    public void ProcessRequest(HttpContext context)
    {
        var articleId = context.Request.QueryString["id"];
        var vote = context.Request.QueryString["vote"];
        var digi = context.Request.QueryString["d"];
        if (context.Session["ipvote"] != null)
        {
            var a = (ArrayList)context.Session["ipvote"];
            if (a.IndexOf(articleId) >= 0)
            {
                context.Response.ContentType = "text/plain";
                context.Response.Write("success=false");
                return;
            }
            a.Add(articleId);
            context.Session["ipvote"] = a;
        }
        else
        {
            var a = new ArrayList();
            a.Add(articleId);
            context.Session["ipvote"] = a;
        }
        
        var article = ArticleBiz.GetArticleByID(int.Parse(articleId));
        if (article != null)
        {
            article.Vote = (article.Vote * article.VoteCount + int.Parse(vote)) / (article.VoteCount + 1);
            article.VoteCount = article.VoteCount + 1;
            if (ArticleBiz.UpdateArticle(article))
            {
                context.Response.ContentType = "text/plain";
                context.Response.Write("success=true;votecount=" + article.VoteCount + ";vote=" + Math.Round(article.Vote, int.Parse(digi)));
            }
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