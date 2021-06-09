using System;
using System.Data;
using System.Web.UI;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Handler;
using BIC.Utils;
using BIC.WebControls;
using Telerik.Web.UI;

public partial class Admin_Components_ArticleGallery_ListingArticleGallery : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        // * Load menu chuột phải
        radMenuContext.LoadContentFile("~/admin/XMLData/Grid/Copy_Edit_View_Delete_Move_" +
                                       BicLanguage.CurrentLanguageAdmin + ".xml");

        if (Deleted)
            radMenuContext.Items[3].Attributes.Add("onclick",
                                                   string.Format(
                                                       "var as;as=confirm('{0}');document.getElementById('confirmdelete').value = as;",
                                                       BicMessage.Delete));

        // * Lưu lại các biến Session
        if (BicSession.ToString("ArticleLanguage") != string.Empty)
            ddlLanguage.SelectedValue = BicSession.ToString("ArticleLanguage");


        if (!string.IsNullOrEmpty(BicSession.ToString("ArticlePageIndex")))
            rgManager.MasterTableView.CurrentPageIndex = BicSession.ToInt32("ArticlePageIndex");

        if (!string.IsNullOrEmpty(BicSession.ToString("ArticleActive")))
            ddlIsActive.SelectedValue = BicSession.ToString("ArticleActive");

        if (!string.IsNullOrEmpty(BicSession.ToString("ArticleCommentNew")))
            ddlType.SelectedValue = BicSession.ToString("ArticleCommentNew");

        if (!string.IsNullOrEmpty(BicSession.ToString("ArticleSort")))
            rblSort.SelectedValue = BicSession.ToString("ArticleSort");

        if (!string.IsNullOrEmpty(BicSession.ToString("ArticleTinTieuDiem")))
            ddlTinTieuDiem.SelectedValue = BicSession.ToString("ArticleTinTieuDiem");

        if (!string.IsNullOrEmpty(BicSession.ToString("ArticleSearch")))
            txtSearch.Text = BicSession.ToString("ArticleSearch");

        if (BicConvert.ToString(Session["ArticleDate1"]) != string.Empty)
            radBDBeginDate.SelectedDate = BicConvert.ToDateTime(BicSession.ToString("ArticleDate1"));

        if (BicConvert.ToString(Session["ArticleDate2"]) != string.Empty)
            radBDEndDate.SelectedDate = BicConvert.ToDateTime(BicSession.ToString("ArticleDate2"));
        // * * *

        // * Load cây danh mục
        BindingRadTreeView();
        // * * *
        if (!string.IsNullOrEmpty(BicSession.ToString("ArticleMenu")))
        {
            MenuUserUtils.SetCheckedNodes(tvMenuUser, BicSession.ToString("ArticleMenu"));
            hdTreeMenu.Value = BicSession.ToString("ArticleMenu");
        }
        GetDataSource();

        //Set link button Add
        addLink.HRef = BicAdmin.UrlAdd();
        addLink.Visible = Added;
        //Phan quyen xoa
        lbtnDeleteSelected.Visible = Deleted;

        rblSort.Items[6].Enabled = BicXML.ToBoolean("EnableComment", "SettingArticle");
        rblSort.Items[7].Enabled = BicXML.ToBoolean("EnableComment", "SettingArticle");
    }

    protected void BindingRadTreeView()
    {
        MenuUserUtils.BindingRadTreeView(tvMenuUser, ddlLanguage.SelectedValue, "gallery");
    }

    public bool EnableIsNew(object createdtime)
    {
        bool time = false;
        if (createdtime != null)
        {
            time = DateTime.Compare(Convert.ToDateTime(createdtime).AddDays(7), DateTime.Now) > 0;
        }
        return time;
    }

    protected string ConvertDate(string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;
        string[] date = input.Split(new[] { '/', '-' }, StringSplitOptions.RemoveEmptyEntries);
        return date[1] + "/" + date[0] + "/" + date[2];
    }

    protected void rgManager_PageIndexChanged(object source, GridPageChangedEventArgs e)
    {
        rgManager.MasterTableView.CurrentPageIndex = e.NewPageIndex;
        BicSession.SetValue("ArticlePageIndex", rgManager.MasterTableView.CurrentPageIndex);
        GetDataSource();
    }

    private void GetDataSource()
    {
        var bicData = new BicGetData
                          {
                              TableName = "Article",
                              PageSize = rgManager.MasterTableView.PageSize,
                              PageIndex = rgManager.MasterTableView.CurrentPageIndex
                          };
        bicData.Selecting.Add(
            "ImageID, ArticleID,dbo.MenuUserIdToNames(MenuUserId) Nhom, MenuUserID,Title, Priority,CreatedDate,ModifiedDate,IsNew,ActiveComment,InActiveComment, ImageName,IsActive,ViewCount,UrlName");

        switch (rblSort.SelectedValue)
        {
            case "0":
                bicData.Sorting.Add(new SortingItem("CreatedDate", true));
                break;
            case "1":
                bicData.Sorting.Add(new SortingItem("CreatedDate", false));
                break;
            case "2":
                bicData.Sorting.Add(new SortingItem("ViewCount", true));
                break;
            case "3":
                bicData.Sorting.Add(new SortingItem("ViewCount", false));
                break;
            case "4":
                bicData.Sorting.Add(new SortingItem("ActiveComment", true));
                break;
            case "5":
                bicData.Sorting.Add(new SortingItem("ActiveComment", false));
                break;
            case "6":
                bicData.Sorting.Add(new SortingItem("ModifiedDate", true));
                break;
            case "7":
                bicData.Sorting.Add(new SortingItem("ModifiedDate", false));
                break;
            case "8":
                bicData.Sorting.Add(new SortingItem("Priority", false));
                break;
            case "9":
                bicData.Sorting.Add(new SortingItem("Priority", true));
                break;
        }

        // Fix  Lấy ra danh sách Ảnh
        bicData.Conditioning.Add(new ConditioningItem("TypeOfControl", "2", Operator.EQUAL, CompareType.NUMERIC));

        if (txtSearch.Text != String.Empty)
        {
            bicData.Conditioning.Add(new ConditioningItem(ArticleEntity.FIELD_TITLE,
                                                          "%" + BicConvert.ToString(txtSearch.Text).Replace("'", "''") +
                                                          "%", Operator.LIKE, CompareType.STRING));
        }
        if (tvMenuUser.CheckedNodes.Count > 0)
        {
            string[] arr = BicString.SplitComma(hdTreeMenu.Value);
            var con = new ConditioningItem
                          {
                              TypeOfCondition = TypeOfCondition.QUERY,
                          };


            for (int index = 0; index < arr.Length; index++)
            {
                if (index == 0)
                    con.Query = string.Format("MenuUserID like '%,{0},%'", arr[index]);
                else
                    con.Query = con.Query + string.Format(" or MenuUserID like '%,{0},%'", arr[index]);
            }
            bicData.Conditioning.Add(con);
        }

        bicData.Conditioning.Add(new ConditioningItem("LanguageKey", BicConvert.ToString(ddlLanguage.SelectedValue),
                                                      Operator.EQUAL, CompareType.STRING));

        if (ddlIsActive.SelectedValue != "2")
            bicData.Conditioning.Add(new ConditioningItem("IsActive", BicConvert.ToString(ddlIsActive.SelectedValue),
                                                          Operator.EQUAL, CompareType.NUMERIC));
        if (ddlTinTieuDiem.SelectedValue != "2")
            bicData.Conditioning.Add(new ConditioningItem("TinTieuDiem",
                                                          BicConvert.ToString(ddlTinTieuDiem.SelectedValue),
                                                          Operator.EQUAL, CompareType.NUMERIC));
        if (ddlType.SelectedValue != "2")
            bicData.Conditioning.Add(new ConditioningItem("TinLienQuan",
                                                           BicConvert.ToString(ddlType.SelectedValue),
                                                           Operator.EQUAL, CompareType.NUMERIC));

        if (!string.IsNullOrEmpty(radBDBeginDate.DateInput.Text))
        {
            bicData.Conditioning.Add(new ConditioningItem
                                         {
                                             TypeOfCondition = TypeOfCondition.QUERY,
                                             Query =
                                                 string.Format("ModifiedDate >= '{0}'",
                                                               radBDBeginDate.SelectedDate.Value)
                                         });
        }
        if (!string.IsNullOrEmpty(radBDEndDate.DateInput.Text))
        {
            bicData.Conditioning.Add(new ConditioningItem
                                         {
                                             TypeOfCondition = TypeOfCondition.QUERY,
                                             Query = string.Format("ModifiedDate <= '{0}'",
                                                                   radBDEndDate.SelectedDate.Value.AddDays(1))
                                         });
        }

        DataTable data = bicData.GetPagingData();
        rgManager.VirtualItemCount = bicData.TotalItems;
        rgManager.DataSource = data;
        rgManager.DataBind();
    }

    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {
        BicSession.SetValue("ArticleSearch", txtSearch.Text.Trim());
        rgManager.CurrentPageIndex = 0;
        GetDataSource();
    }

    protected void rgManager_ItemCreated(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridPagerItem)
        {
            var pager = (GridPagerItem)e.Item;
            var PageSizeComboBox = (RadComboBox)pager.FindControl("PageSizeComboBox");
            if (PageSizeComboBox != null)
            {
                var comboItem = new RadComboBoxItem("All");
                PageSizeComboBox.Items.Insert(0, comboItem);
                PageSizeComboBox.AutoPostBack = true;
                PageSizeComboBox.SelectedIndexChanged += PageSizeComboBox_SelectedIndexChanged;
            }
        }
    }

    private void PageSizeComboBox_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        GetDataSource();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BicSession.SetValue("ArticleSearch", txtSearch.Text.Trim());
        GetDataSource();
    }

    protected void rgManager_DeleteCommand(object source, GridCommandEventArgs e)
    {
        try
        {
            int id = BicConvert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ArticleID"]);
            ArticleEntity article = ArticleBiz.GetArticleByID(id);
            //if (!PermissionHelper.ByMenuUsers(articleEntity.MenuUserID))
            //{
            //    BicAjax.Alert(BicMessage.DeletePermission + articleEntity.Title);
            //    return;
            //}
            if (Deleted && article.IsActive && Approved == false)
                BicAjax.Alert(string.Format(BicResource.GetValue("Admin", "Admin_Article_Message1")));
            else if (Deleted)
            {
                int countComment = CommentBiz.CommentCount(id, 1);
                if (countComment == 0)
                {
                    ArticleBiz.DeleteArticle(id);
                    //clear cache bài viết trước khi lấy dữ liệu ra
                    //GetDataSource();
                }
                else
                {
                    BicAjax.Alert(string.Format(BicResource.GetValue("Admin", "Admin_Article_Message2")));
                }
            }
        }
        catch (Exception ex)
        {
            LogEvent.LogToFile(ex.ToString());
            rgManager.Controls.Add(
                new LiteralControl(string.Format(BicResource.GetValue("Admin", "Admin_Article_Message3"))));
            e.Canceled = true;
        }
    }

    protected void radMenuContext_ItemClick(object sender, RadMenuEventArgs e)
    {
        int index = Convert.ToInt32(Request.Form["radGridClickedRowIndex"]);
        int id = Convert.ToInt32(rgManager.Items[index].GetDataKeyValue("ArticleID"));
        ArticleEntity articleEntity = ArticleBiz.GetArticleByID(id);
        switch (e.Item.Value)
        {
            case "Add":
                BicAdmin.NavigateToAdd();
                break;
            case "View":
                try
                {
                    string link = string.Format(BicApplication.URLRoot + "{0}/{1}/{2}.html",
                                                 articleEntity.LanguageKey, articleEntity.MenuUserName,
                                                 rgManager.Items[index].GetDataKeyValue("UrlName"));
                    BicAjax.Open(link, "_blank");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                break;
            case "Delete":

                if (Deleted && articleEntity.IsActive && Approved == false)
                    BicAjax.Alert(string.Format(BicResource.GetValue("Admin", "Admin_Article_Message1")));
                else if (Deleted)
                {
                    //if (!PermissionHelper.ByMenuUsers(articleEntity.MenuUserID))
                    //{
                    //    BicAjax.Alert(BicMessage.DeletePermission + articleEntity.Title);
                    //    return;
                    //}
                    bool confirm = Convert.ToBoolean(Request.Form["confirmdelete"]);
                    if (confirm)
                    {
                        int countComment = CommentBiz.CommentCount(id, 1);
                        if (countComment == 0)
                        {
                            ArticleBiz.DeleteArticle(id);

                            GetDataSource();
                        }
                        else
                        {
                            BicAjax.Alert(string.Format(BicResource.GetValue("Admin", "Admin_Article_Message2")));
                        }
                    }
                }
                else if (Deleted == false)
                    BicAjax.Alert(BicMessage.DenyDelete);
                break;
            case "Edit":
                if (Edited && articleEntity.IsActive && Approved == false)
                    BicAjax.Alert(string.Format(BicResource.GetValue("Admin", "Admin_Article_Message1")));
                else if (Edited)
                {
                    BicAdmin.NavigateToEdit(id.ToString());
                }
                else if (Edited == false)
                    BicAjax.Alert(BicMessage.DenyEdit);
                break;
            case "Copy":
                BicAjax.Navigate(string.Format("{0}?mid={1}&cid={2}&action=add&id={3}&l={4}", "~/admin/default.aspx",
                                               BicHtml.GetRequestString("mid", "0"),
                                               BicHtml.GetRequestString("cid", "0"), id,
                                               BicHtml.GetRequestString("l", "vi")));
                break;
        }
    }

    protected void rgManager_ItemCommand(object source, GridCommandEventArgs e)
    {
        try
        {
            switch (e.CommandName)
            {
                case "IsNew":
                    var dhIsNew = new DataHelper();
                    int updateIsNew = e.CommandArgument.Equals("True") ? 0 : 1;
                    if (
                        dhIsNew.UpdateColumn("IsNew", updateIsNew, "ArticleID",
                                             e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ArticleID"].ToString
                                                 (),
                                             "Article") == false)
                        e.Canceled = true;
                    else
                        GetDataSource();

                    break;

                case "IsActive":
                    if (BicRadGrid.ExecuteBooleanCommand(e, e.CommandName, "ArticleId",
                                                         e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex][
                                                             "ArticleID"].ToString(), "Article"))
                        GetDataSource();
                    else
                        e.Canceled = true;
                    break;
                case "Edit":
                    ArticleEntity articleEntity = ArticleBiz.GetArticleByID(BicConvert.ToInt32(e.CommandArgument));
                    if (Edited && articleEntity.IsActive && Approved == false)
                        BicAjax.Alert(string.Format(BicResource.GetValue("Admin", "Admin_Article_Message1")));
                    else if (Edited)
                    {
                        BicAdmin.NavigateToEdit(e.CommandArgument.ToString());
                    }
                    else if (Edited == false)
                        BicAjax.Alert(BicMessage.DenyEdit);
                    break;
            }
        }
        catch (Exception ex)
        {
            LogEvent.LogToFile(ex.ToString());
        }
    }


    protected void btnclear_OnClick(object sender, EventArgs e)
    {
        ddlLanguage.SelectedValue = BicXML.ToString("DefaultLanguage", "SearchEngine");
        BicSession.SetValue("ArticleLanguage", BicXML.ToString("DefaultLanguage", "SearchEngine"));

        ddlIsActive.SelectedIndex = 0;
        BicSession.SetValue("ArticleActive", string.Empty);

        ddlTinTieuDiem.SelectedIndex = 0;
        BicSession.SetValue("ArticleTinTieuDiem", string.Empty);

        ddlType.SelectedIndex = 0;
        BicSession.SetValue("ArticleCommentNew", string.Empty);

        radBDBeginDate.Clear();
        BicSession.SetValue("ArticleDate1", string.Empty);
        radBDEndDate.Clear();
        BicSession.SetValue("ArticleDate2", string.Empty);

        rblSort.SelectedIndex = -1;
        BicSession.SetValue("ArticleSort", string.Empty);

        tvMenuUser.UncheckAllNodes();
        BicSession.SetValue("ArticleMenu", string.Empty);
        hdTreeMenu.Value = string.Empty;

        txtSearch.Text = string.Empty;
        BicSession.SetValue("ArticleSearch", string.Empty);
        BindingRadTreeView();
        rgManager.CurrentPageIndex = 0;
        BicSession.SetValue("ArticlePageIndex", 0);
        GetDataSource();
    }

    protected void btnFind_OnClick(object sender, EventArgs e)
    {
        BicSession.SetValue("ArticleLanguage", ddlLanguage.SelectedValue);
        BicSession.SetValue("ArticleMenu", hdTreeMenu.Value);
        BicSession.SetValue("ArticleLanguageKey", ddlLanguage.SelectedValue);
        BicSession.SetValue("ArticleActive", ddlIsActive.SelectedValue);
        BicSession.SetValue("ArticleCommentNew", ddlType.SelectedValue);
        BicSession.SetValue("ArticleSort", rblSort.SelectedValue);
        BicSession.SetValue("ArticleTinTieuDiem", ddlTinTieuDiem.SelectedValue);
        BicSession.SetValue("ArticleSearch", txtSearch.Text);
        BicSession.SetValue("ArticleDate1", radBDBeginDate.SelectedDate);
        BicSession.SetValue("ArticleDate2", radBDEndDate.SelectedDate);
        BicSession.SetValue("ArticlePageIndex", 0);
        rgManager.CurrentPageIndex = 0;
        GetDataSource();
    }

    protected void ddlLanguage_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindingRadTreeView();
        GetDataSource();
    }

    protected void lbtnDeleteSelected_Click(object sender, EventArgs e)
    {
        foreach (GridDataItem item in rgManager.SelectedItems)
        {
            if (item.Selected)
            {
                // Access data key
                int id = BicConvert.ToInt32(item.GetDataKeyValue("ArticleID"));
                // Access column

                ArticleEntity articleEntity = ArticleBiz.GetArticleByID(id);
                if (articleEntity == null) return;

                if (Deleted && articleEntity.IsActive && Approved == false)
                    BicAjax.Alert(string.Format(BicResource.GetValue("Admin", "Admin_Article_Message1")));
                else if (Deleted)
                {                 
                    ArticleBiz.DeleteArticle(id);
                }
                else if (Deleted == false)
                {
                    BicAjax.Alert(BicMessage.DenyDelete);
                }
            }
        }
        GetDataSource();
    }

    protected void ddlType_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        BindingRadTreeView();
        GetDataSource();
    }
}