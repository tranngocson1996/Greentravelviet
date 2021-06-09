<%@ WebHandler Language="C#" Class="ProductReview" %>

using System;
using System.Collections;
using System.Web;
using System.Web.SessionState;
using BIC.Biz;

public class ProductReview : IHttpHandler, IRequiresSessionState
{

    public void ProcessRequest(HttpContext context)
    {
        var productId = context.Request.QueryString["id"];
        var vote = context.Request.QueryString["vote"];
        var digi = context.Request.QueryString["d"];
        if (context.Session["ipvote"] != null)
        {
            var a = (ArrayList)context.Session["ipvote"];
            if (a.IndexOf(productId) >= 0)
            {
                context.Response.ContentType = "text/plain";
                context.Response.Write("success=false");
                return;
            }
            a.Add(productId);
            context.Session["ipvote"] = a;
        }
        else
        {
            var a = new ArrayList();
            a.Add(productId);
            context.Session["ipvote"] = a;
        }
        
        var product = ProductBiz.GetProductByID(int.Parse(productId));
        if (product != null)
        {
            product.Vote = (product.Vote * product.VoteCount + int.Parse(vote)) / (product.VoteCount + 1);
            product.VoteCount = product.VoteCount + 1;
            if (ProductBiz.UpdateProduct(product))
            {
                context.Response.ContentType = "text/plain";
                context.Response.Write("success=true;votecount=" + product.VoteCount + ";vote=" + Math.Round(product.Vote, int.Parse(digi)));
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