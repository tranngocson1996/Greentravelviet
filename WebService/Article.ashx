<%@ WebHandler Language="C#" Class="Article" %>

using System.Web;
using BIC.Data;
using BIC.Entity;

public class Article : IHttpHandler
{
    #region IHttpHandler Members

    public void ProcessRequest(HttpContext context)
    {
        int menuId = int.Parse(context.Request.QueryString["mid"]);
        int pageSize = int.Parse(context.Request.QueryString["size"]);
        var bicData = new BicGetData
                          {
                              TableName = "Article",
                              PageSize = pageSize
                          };
        //Sorting Modified Date by Descending                
        bicData.Selecting.Add("ArticleID");
        bicData.Selecting.Add("BriefDescription");
        bicData.Selecting.Add("ImageID");
        bicData.Selecting.Add("Title");
        bicData.Selecting.Add("URLName");
        bicData.Selecting.Add("Target");
        bicData.Selecting.Add("ModifiedDate");
        bicData.Sorting.Add(new SortingItem("CreatedDate", true));
        bicData.Selecting.Add("(case DateDiff(Day,CreatedDate,GetDate()) when 0 then 'Today' else '' end) Today");
        /*language */
        bicData.Conditioning.Add(new ConditioningItem
                                     {
                                         Column = "LanguageKey",
                                         Value = "vi",
                                         CompareType = CompareType.STRING,
                                         Operator = Operator.EQUAL
                                     });
        bicData.Conditioning.Add(new ConditioningItem
                                     {
                                         TypeOfCondition = TypeOfCondition.QUERY,
                                         Query =
                                             string.Format(
                                                 "((select * from dbo.ItemIsExist(MenuUserID,'{0}')) > 0)",
                                                 menuId),
                                         CombineCondition = CombineCondition.AND
                                     });

        bicData.Conditioning.Add(new ConditioningItem
                                     {
                                         Column = ArticleEntity.FIELD_ISACTIVE,
                                         Value = "1",
                                         CompareType = CompareType.NUMERIC,
                                         Operator = Operator.EQUAL
                                     });

        context.Response.ContentType = "text/plain";
        context.Response.Write("Hello World");
    }

    public bool IsReusable
    {
        get { return false; }
    }

    #endregion
}