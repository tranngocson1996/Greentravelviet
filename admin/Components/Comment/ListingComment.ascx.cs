using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;
using Telerik.Web.UI;

public partial class Admin_Components_Comment_ListingComment : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        radMenuContext.LoadContentFile("~/admin/XMLData/Grid/Edit_View_Delete_" + BicLanguage.CurrentLanguageAdmin + ".xml");
        radMenuContext.Items[2].Attributes.Add("onclick", string.Format("var as;as=confirm('{0}?');document.getElementById('confirmdelete').value = as;", BicMessage.Delete));
        //radMenuContext.Items[1].Text = string.Format("Trả lời");
        ddlIsActive.SelectedValue = "2";
        //TypeOfComment();
        if (BicSession.ToString("CommentLang") != string.Empty)
            ddlLanguage.SelectedValue = BicSession.ToString("CommentLang");
        TypeOfComment();
        ddlTypeOfComment.SelectedValue = "0";
        if (BicSession.ToString("CommentType") != string.Empty)
            ddlTypeOfComment.SelectedValue = BicSession.ToString("CommentType");
    }
    protected void ddlLanguage_SelectedIndexChanged(object o, EventArgs e)
    {
        BicSession.SetValue("CommentLang", ddlLanguage.SelectedValue);
        GetDataSource();
        rgManager.DataBind();
    }
    protected void TypeOfComment()
    {
        //BicXML.BindDropDownListFromXML(ddlTypeOfComment, string.Format("{0}admin/XMLData/TypeOfComment_" + BicLanguage.CurrentLanguageAdmin + ".xml", BicApplication.URLRoot));
        ddlTypeOfComment.Items.Insert(0, new ListItem(BicResource.GetValue("Admin", "Admin_Comment_All"), "0"));
        ddlTypeOfComment.Items.Insert(1, new ListItem(BicResource.GetValue("Admin", "Admin_Comment_IsHot"), "1"));
    }
    public string Title(object id, object typeid)
    {
        var title = string.Empty;
        var type = BicConvert.ToInt32(typeid, 0);
        if (type == 1)
        {
            if (ArticleBiz.GetArticleByID(BicConvert.ToInt32(id)) != null)
            {
                var danhmuc = ArticleBiz.GetArticleByID(BicConvert.ToInt32(id)).MenuUserID;
                var listmenu = (!string.IsNullOrEmpty(danhmuc) ? danhmuc : ",0,").Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
                var menuentity = MenuUserBiz.GetMenuUserByID(BicConvert.ToInt32(listmenu[0]));
                var parent = MenuUserBiz.GetMenuUserByID(menuentity.ParentID);
                title = (parent != null ? (parent.Name + " / ") : string.Empty) + (menuentity != null ? (menuentity.Name + " / ") : string.Empty) + ArticleBiz.GetArticleByID(BicConvert.ToInt32(id)).Title;
            }
        }
        if (type == 2)
        {
            var product = ProductBiz.GetProductByID(BicConvert.ToInt32(id));
            if (product != null)
            {
                //var danhmuc = ProductBiz.GetProductByID(BicConvert.ToInt32(id)).MenuUserID;
                //var listmenu = (!string.IsNullOrEmpty(danhmuc) ? danhmuc : ",0,").Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
                //var menuentity = MenuUserBiz.GetMenuUserByID(BicConvert.ToInt32(listmenu[0]));
                //var parent = MenuUserBiz.GetMenuUserByID(menuentity.ParentID);
                //title = (parent != null ? (parent.Name + " / ") : string.Empty) + (menuentity != null ? (menuentity.Name + " / ") : string.Empty) + ProductBiz.GetProductByID(BicConvert.ToInt32(id)).Title;
                title = product.Title;
            }
        }
        return title;

    }
    private void GetDataSource()
    {
        var bicData = new BicGetData { TableName = "Comment", PageSize = rgManager.MasterTableView.PageSize, PageIndex = rgManager.MasterTableView.CurrentPageIndex };
        bicData.Joining.Add(new JoinItem("Comment", "Product", "ID", "ProductID"));
        bicData.Sorting.Add(new SortingItem(CommentEntity.FIELD_CREATEDATE, true));
        bicData.Selecting.Add(CommentEntity.FIELD_COMMENTID);
        bicData.Selecting.Add(CommentEntity.FIELD_FULLNAME);
        bicData.Selecting.Add(CommentEntity.FIELD_ID);
        //bicData.Selecting.Add("Comment.Title");
        bicData.Selecting.Add(CommentEntity.FIELD_EMAIL);
        bicData.Selecting.Add(CommentEntity.FIELD_DESCRIPTION);
        bicData.Selecting.Add(CommentEntity.FIELD_TYPEOFCOMMENT);
        bicData.Selecting.Add(CommentEntity.FIELD_CREATEDATE);
        bicData.Selecting.Add("Comment.IsActive" + ",DongY,KhongDongY");
        bicData.Selecting.Add(CommentEntity.FIELD_GIOITINH);
        bicData.Selecting.Add(CommentEntity.FIELD_ISHOT);
        bicData.Selecting.Add("Product.Title");
        if (ddlIsActive.SelectedValue != "2")
            bicData.Conditioning.Add(new ConditioningItem("Comment.IsActive", BicConvert.ToString(ddlIsActive.SelectedValue), Operator.EQUAL, CompareType.NUMERIC));

        if (ddlTypeOfComment.SelectedValue != "0")
        {
            //bicData.Conditioning.Add(new ConditioningItem("Address",
            //                                              ddlLanguage.SelectedValue,
            //                                              Operator.EQUAL, CompareType.STRING));
            //bicData.Conditioning.Add(new ConditioningItem("TypeOfComment",
            //                                              BicConvert.ToString(ddlTypeOfComment.SelectedValue),
            //                                              Operator.EQUAL, CompareType.NUMERIC));
            bicData.Conditioning.Add(new ConditioningItem("Comment.IsHot", "1", Operator.EQUAL));
        }
        //else
        //{
        //    bicData.Conditioning.Add(new ConditioningItem("Address",
        //                                                  ddlLanguage.SelectedValue,
        //                                                  Operator.EQUAL, CompareType.STRING));
        //}
        if (txtSearch.Text != String.Empty)
        {
            bicData.Conditioning.Add(new ConditioningItem { TypeOfCondition = TypeOfCondition.QUERY, Query = string.Format("({0} like N'%{1}%' or {2} like N'%{1}%')", CommentEntity.FIELD_FULLNAME, txtSearch.Text.Trim(), "Product.Title") });
        }
        var data = bicData.GetPagingData();
        rgManager.VirtualItemCount = bicData.TotalItems;
        rgManager.DataSource = data;
    }
    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {
        GetDataSource();
        rgManager.DataBind();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        GetDataSource();
        rgManager.DataBind();
    }
    protected void rgManager_DeleteCommand(object source, GridCommandEventArgs e)
    {
        int id = BicConvert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["CommentID"]);
        CommentBiz.DeleteComment(id);
        rgManager.DataBind();
    }
    protected void rgManager_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        GetDataSource();
    }
    protected void radMenuContext_ItemClick(object sender, RadMenuEventArgs e)
    {
        int index = Convert.ToInt32(Request.Form["radGridClickedRowIndex"]);
        int id = Convert.ToInt32(rgManager.Items[index].GetDataKeyValue("CommentID"));
        CommentEntity commentEntity = CommentBiz.GetCommentByID(id);
        switch (e.Item.Value)
        {
            case "Add":
                Response.Redirect(Request.Url.ToString().Replace("=list", "=add&commentid=" + id));
                break;
            case "View":
                BicAdmin.NavigateToView(id.ToString());
                break;
            case "Delete":
                if (Deleted && commentEntity.IsActive && Approved == false)
                {
                    BicAjax.Alert(string.Format(BicResource.GetValue("Admin", "Admin_Comment_Message2")));
                }
                else if (Deleted)
                {
                    bool confirm = Convert.ToBoolean(Request.Form["confirmdelete"]);
                    if (confirm)
                    {
                        CommentBiz.DeleteComment(id);
                        rgManager.Rebind();
                    }
                }
                else if (Deleted == false)
                    BicAjax.Alert(BicMessage.DenyDelete);
                break;
            case "Edit":
                BicAdmin.NavigateToEdit(id.ToString());
                break;
        }
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
    protected void rgManager_ItemCommand(object source, GridCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "IsActive":
                var dhIsActive = new DataHelper();
                int updateIsActive = e.CommandArgument.Equals("True") ? 0 : 1;
                if (dhIsActive.UpdateColumn("IsActive", updateIsActive, "CommentID", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["CommentID"].ToString(), "Comment") == false)
                    e.Canceled = true;
                else
                {
                    var comment =
                        CommentBiz.GetCommentByID(
                            BicConvert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["CommentID"]));
                    if (comment != null)
                    {
                        var cmdText = string.Format(
                       "update Article SET ActiveComment = (select count(CommentID) from Comment where ID = {0} and Comment.IsActive = 1) Where ArticleID ={0} update Article SET InActiveComment = (select count(CommentID) from Comment where ID = {0} and Comment.IsActive = 0) Where ArticleID ={0}",
                       comment.Id);
                        var cn = new SqlConnection(HttpContext.Current.Cache["LocalSqlServer"].ToString());
                        cn.Open();
                        var cmd = new SqlCommand(cmdText, cn);
                        cmd.ExecuteNonQuery();
                        cn.Close();
                        cn.Dispose();
                        RemoveCache();
                    }
                    rgManager.Rebind();
                }
                break;
            case "IsHot":
                var dhIsHot = new DataHelper();
                int updateIsHot = e.CommandArgument.Equals("True") ? 0 : 1;
                if (dhIsHot.UpdateColumn("IsHot", updateIsHot, "CommentID", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["CommentID"].ToString(), "Comment") == false)
                    e.Canceled = true;
                RemoveCache();
                rgManager.Rebind();
                //else
                //{
                //    var comment =
                //        CommentBiz.GetCommentByID(
                //            BicConvert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["CommentID"]));
                //    if (comment != null)
                //    {
                //        var cmdText = string.Format(
                //       "update Article SET ActiveComment = (select count(CommentID) from Comment where ID = {0} and Comment.IsActive = 1) Where ArticleID ={0} update Article SET InActiveComment = (select count(CommentID) from Comment where ID = {0} and Comment.IsActive = 0) Where ArticleID ={0}",
                //       comment.Id);
                //        var cn = new SqlConnection(HttpContext.Current.Cache["LocalSqlServer"].ToString());
                //        cn.Open();
                //        var cmd = new SqlCommand(cmdText, cn);
                //        cmd.ExecuteNonQuery();
                //        cn.Close();
                //        cn.Dispose();
                //        RemoveCache();
                //    }
                //    rgManager.Rebind();
                //}
                break;

            case "TypeOfComment":
                var dhTypeOfComment = new DataHelper();
                int updateTypeOfComment = BicConvert.ToInt32(e.CommandArgument).Equals(99) ? 1 : 99;
                if (dhTypeOfComment.UpdateColumn("TypeOfComment", updateTypeOfComment, "CommentID", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["CommentID"].ToString(), "Comment") == false)
                    e.Canceled = true;
                else
                {
                    RemoveCache();
                    rgManager.Rebind();

                }
                break;
        }
    }
    protected void ddlIsActived_SelectedIndexChanged(object o, EventArgs e)
    {
        BicSession.SetValue("CommentType", ddlTypeOfComment.SelectedValue);
        GetDataSource();
        rgManager.DataBind();
    }

}