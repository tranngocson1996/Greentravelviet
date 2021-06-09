using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BIC.Data;
using BIC.Entity;
using BIC.WebControls;

public partial class admin_Components_Article_CommentArticle : UserControl
{
    public int ArticleID
    {
        get { return (int) ViewState["ArticleID"]; }
        set { ViewState["ArticleID"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            GetDataSource();
    }

    private void GetDataSource()
    {
        var bicData = new BicGetData {TableName = "Comment", PageSize = 10};
        bicData.Sorting.Add(new SortingItem(CommentEntity.FIELD_ISACTIVE, false));
        bicData.Sorting.Add(new SortingItem(CommentEntity.FIELD_CREATEDATE, true));
        bicData.Selecting.Add(CommentEntity.FIELD_COMMENTID);
        bicData.Selecting.Add(CommentEntity.FIELD_TITLE);
        bicData.Selecting.Add(CommentEntity.FIELD_DESCRIPTION);
        bicData.Selecting.Add(CommentEntity.FIELD_CREATEDATE);
        bicData.Selecting.Add(CommentEntity.FIELD_ISACTIVE);
        bicData.Conditioning.Add(new ConditioningItem(CommentEntity.FIELD_ID, ArticleID.ToString(), Operator.EQUAL,
                                                      CompareType.NUMERIC));
        DataTable data = bicData.GetPagingData();
        lvRelatedArticle.DataSource = data;
        lvRelatedArticle.DataBind();
        pRelatedArticle.TotalItems = bicData.TotalItems;
    }

    protected void pRelatedArticle_OnPageIndexChanged(object sender, PagerUIEventArgs e)
    {
        pRelatedArticle.PageIndex = e.NewPageIndex;
        GetDataSource();
    }

    public void RemoveCache()
    {
        var keyList = new List<string>();
        IDictionaryEnumerator cacheEnum = HttpContext.Current.Cache.GetEnumerator();
        while (cacheEnum.MoveNext())
        {
            keyList.Add(cacheEnum.Key.ToString());
        }
        foreach (string key in keyList)
        {
            HttpContext.Current.Cache.Remove(key);
        }
    }

    protected void lvRelatedArticle_ItemCommand(object source, ListViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "IsActive":
                var dhIsActive = new DataHelper();
                int updateIsActive = e.CommandArgument.Equals("True") ? 0 : 1;
                dhIsActive.UpdateColumn("IsActive", updateIsActive, "CommentID",
                                        ((HiddenField) e.Item.FindControl("HiddenField1")).Value, "Comment");


                string cmdText = string.Format(
                    "update Article SET ActiveComment = (select count(CommentID) from Comment where ID = {0} and Comment.IsActive = 1) Where ArticleID ={0} update Article SET InActiveComment = (select count(CommentID) from Comment where ID = {0} and Comment.IsActive = 0) Where ArticleID ={0}",
                    ArticleID);
                var cn = new SqlConnection(HttpContext.Current.Cache["LocalSqlServer"].ToString());
                cn.Open();
                var cmd = new SqlCommand(cmdText, cn);
                cmd.ExecuteNonQuery();
                cn.Close();
                cn.Dispose();
                RemoveCache();
                //var articleEntity = ArticleBiz.GetArticleByID(ArticleID);
                //if (articleEntity != null)
                //{
                //    //articleEntity.ActiveComment = updateIsActive == 0 ? articleEntity.ActiveComment - 1 :articleEntity.ActiveComment + 1;
                //    //articleEntity.InActiveComment = updateIsActive == 0 ? articleEntity.InActiveComment + 1 : articleEntity.InActiveComment - 1;
                //    //ArticleBiz.UpdateArticle(articleEntity);

                //}
                GetDataSource();
                break;
        }
    }
}