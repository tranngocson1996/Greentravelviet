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

public partial class admin_Components_Product_CommentProduct : UserControl
{
    public int ProductID
    {
        get { return (int) ViewState["ProductID"]; }
        set { ViewState["ProductID"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetDataSource();
        }
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
        bicData.Conditioning.Add(new ConditioningItem(CommentEntity.FIELD_ID, ProductID.ToString(), Operator.EQUAL,
            CompareType.NUMERIC));
        DataTable data = bicData.GetPagingData();
        lvRelatedProduct.DataSource = data;
        lvRelatedProduct.DataBind();
        pRelatedProduct.TotalItems = bicData.TotalItems;
    }

    protected void pRelatedProduct_OnPageIndexChanged(object sender, PagerUIEventArgs e)
    {
        pRelatedProduct.PageIndex = e.NewPageIndex;
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

    protected void lvRelatedProduct_ItemCommand(object source, ListViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "IsActive":
                var dhIsActive = new DataHelper();
                int updateIsActive = e.CommandArgument.Equals("True") ? 0 : 1;
                dhIsActive.UpdateColumn("IsActive", updateIsActive, "CommentID",
                    ((HiddenField) e.Item.FindControl("HiddenField1")).Value, "Comment");


                string cmdText = string.Format(
                    "update Product SET ActiveComment = (select count(CommentID) from Comment where ID = {0} and Comment.IsActive = 1) Where ProductID ={0} update Product SET InActiveComment = (select count(CommentID) from Comment where ID = {0} and Comment.IsActive = 0) Where ProductID ={0}",
                    ProductID);
                var cn = new SqlConnection(HttpContext.Current.Cache["LocalSqlServer"].ToString());
                cn.Open();
                var cmd = new SqlCommand(cmdText, cn);
                cmd.ExecuteNonQuery();
                cn.Close();
                cn.Dispose();
                RemoveCache();
                //var productEntity = ProductBiz.GetProductByID(ProductID);
                //if (productEntity != null)
                //{
                //    //productEntity.ActiveComment = updateIsActive == 0 ? productEntity.ActiveComment - 1 :productEntity.ActiveComment + 1;
                //    //productEntity.InActiveComment = updateIsActive == 0 ? productEntity.InActiveComment + 1 : productEntity.InActiveComment - 1;
                //    //ProductBiz.UpdateProduct(productEntity);

                //}
                GetDataSource();
                break;
        }
    }
}