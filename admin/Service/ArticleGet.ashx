<%@ WebHandler Language="C#" Class="ArticleGet" %>

using System;
using System.Data;
using System.Web;
using BIC.Data;

public class ArticleGet : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        var keyword = context.Request.QueryString["q"];
        var pagesize = int.Parse(context.Request.QueryString["size"]);
        var data = new BicGetData("Article");
        data.Selecting.Add("ArticleId,Title,CreatedDate");
        data.Sorting.Add(new SortingItem("ArticleId", false));
        data.PageSize = pagesize;
        data.PageIndex = 0;
        data.Conditioning.Add(new ConditioningItem("Title", "%" + keyword + "%", Operator.LIKE));
        var st = data.BuildSQLString();
        var dt = data.GetPagingData();
        context.Response.ContentType = "text/plain";
        foreach (DataRow dataRow in dt.Rows)
        {
            context.Response.Write(string.Format("{1} - {2:dd/MM/yyyy}"+ Environment.NewLine, dataRow[0], dataRow["Title"], dataRow["CreatedDate"]));
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