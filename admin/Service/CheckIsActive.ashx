<%@ WebHandler Language="C#" Class="CheckIsActive" %>

using System.Web;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;

public class CheckIsActive : IHttpHandler
{
    #region IHttpHandler Members
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        switch(QueryString("tableName", string.Empty))
        {
            case "Article":
                ArticleEntity entity = ArticleBiz.GetArticleByID(BicConvert.ToInt32(QueryString("columID", "0")));
                if(entity != null)
                {
                    entity.IsActive = !entity.IsActive;
                    ArticleBiz.UpdateArticle(entity);
                    context.Response.Write((!entity.IsActive).ToString().ToLower());
                }
                break;
        }
    }
    public bool IsReusable
    {
        get { return false; }
    }
    #endregion

    public string QueryString(string param, string defaultValue)
    {
        return !string.IsNullOrEmpty(HttpContext.Current.Request.QueryString[param]) ? HttpContext.Current.Request.QueryString[param] : defaultValue;
    }
}