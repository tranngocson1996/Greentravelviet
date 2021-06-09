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

public partial class Admin_Components_Product_ListingProduct : BaseUserControl
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
        if (BicSession.ToString("ProductLanguage") != string.Empty)
            ddlLanguage.SelectedValue = BicSession.ToString("ProductLanguage");


        if (!string.IsNullOrEmpty(BicSession.ToString("ProductPageIndex")))
            rgManager.MasterTableView.CurrentPageIndex = BicSession.ToInt32("ProductPageIndex");

        if (!string.IsNullOrEmpty(BicSession.ToString("ProductActive")))
            ddlIsActive.SelectedValue = BicSession.ToString("ProductActive");

        if (!string.IsNullOrEmpty(BicSession.ToString("ProductCommentNew")))
            ddlCommentNew.SelectedValue = BicSession.ToString("ProductCommentNew");

        if (!string.IsNullOrEmpty(BicSession.ToString("ProductSort")))
            rblSort.SelectedValue = BicSession.ToString("ProductSort");

        if (!string.IsNullOrEmpty(BicSession.ToString("ProductTinTieuDiem")))
            ddlTinTieuDiem.SelectedValue = BicSession.ToString("ProductTinTieuDiem");

        if (!string.IsNullOrEmpty(BicSession.ToString("ProductSearch")))
            txtSearch.Text = BicSession.ToString("ProductSearch");

        if (BicConvert.ToString(Session["ProductDate1"]) != string.Empty)
            radBDBeginDate.SelectedDate = BicConvert.ToDateTime(BicSession.ToString("ProductDate1"));

        if (BicConvert.ToString(Session["ProductDate2"]) != string.Empty)
            radBDEndDate.SelectedDate = BicConvert.ToDateTime(BicSession.ToString("ProductDate2"));
        // * * *

        // * Load cây danh mục
        BindingRadTreeView();
        // * * *
        if (!string.IsNullOrEmpty(BicSession.ToString("ProductMenu")))
        {
            MenuUserUtils.SetCheckedNodes(tvMenuUser, BicSession.ToString("ProductMenu"));
            hdTreeMenu.Value = BicSession.ToString("ProductMenu");
        }
        GetDataSource();

        //Set link button Add
        addLink.HRef = BicAdmin.UrlAdd();
        addLink.Visible = Added;
        //Phan quyen xoa
        lbtnDeleteSelected.Visible = Deleted;

        //rblSort.Items[8].Enabled = BicXML.ToBoolean("EnableComment", "SettingProduct");
        //rblSort.Items[9].Enabled = BicXML.ToBoolean("EnableComment", "SettingProduct");
    }

    protected void BindingRadTreeView()
    {
        MenuUserUtils.BindingRadTreeView(tvMenuUser, ddlLanguage.SelectedValue, "products");
        tvMenuUser.ExpandAllNodes();
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
        string[] date = input.Split(new[] {'/', '-'}, StringSplitOptions.RemoveEmptyEntries);
        return date[1] + "/" + date[0] + "/" + date[2];
    }

    protected void rgManager_PageIndexChanged(object source, GridPageChangedEventArgs e)
    {
        rgManager.CurrentPageIndex = e.NewPageIndex;
        BicSession.SetValue("ProductPageIndex", rgManager.CurrentPageIndex);
        GetDataSource();
    }

    private void GetDataSource()
    {
        var bicData = new BicGetData
        {
            TableName = "Product",
            PageSize = rgManager.PageSize,
            PageIndex = rgManager.CurrentPageIndex
        };
        bicData.Selecting.Add(
            "ImageID, ProductID,dbo.MenuUserIdToNames(MenuUserId) Nhom, MenuUserID,Title, Priority,CreatedDate,ModifiedDate,IsNew,ActiveComment,InActiveComment, ImageName,IsActive,ViewCount,UrlName, Code, Cast(Price as INT) as Price, NewColumn6, OutOfStock");

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

        // Fix  Lấy ra danh sách Tn tức
        //bicData.Conditioning.Add(new ConditioningItem("TypeOfControl", "1", Operator.EQUAL, CompareType.NUMERIC));

        if (txtSearch.Text != String.Empty)
        {
            bicData.Conditioning.Add(new ConditioningItem(ProductEntity.FIELD_TITLE,
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
                    con.Query = con.Query + string.Format(" AND MenuUserID like '%,{0},%'", arr[index]);
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
        if (ddlCommentNew.SelectedValue != "2")
            bicData.Conditioning.Add(ddlCommentNew.SelectedValue.Equals("0")
                ? new ConditioningItem("InActiveComment", "0", Operator.NOT_EQUAL,
                    CompareType.NUMERIC)
                : new ConditioningItem("ActiveComment", "0", Operator.NOT_EQUAL,
                    CompareType.NUMERIC));
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
        BicSession.SetValue("ProductSearch", txtSearch.Text.Trim());
        rgManager.CurrentPageIndex = 0;
        GetDataSource();
    }

    protected void rgManager_ItemCreated(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridPagerItem)
        {
            var pager = (GridPagerItem) e.Item;
            var PageSizeComboBox = (RadComboBox) pager.FindControl("PageSizeComboBox");
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
        BicSession.SetValue("ProductSearch", txtSearch.Text.Trim());
        GetDataSource();
    }

    protected void rgManager_DeleteCommand(object source, GridCommandEventArgs e)
    {
        try
        {
            int id = BicConvert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ProductID"]);
            ProductEntity product = ProductBiz.GetProductByID(id);
            //if (!PermissionHelper.ByMenuUsers(productEntity.MenuUserID))
            //{
            //    BicAjax.Alert(BicMessage.DeletePermission + productEntity.Title);
            //    return;
            //}
            if (Deleted && product.IsActive && Approved == false)
                BicAjax.Alert(string.Format(BicResource.GetValue("Admin", "Admin_Product_Message1")));
            else if (Deleted)
            {
                int countComment = CommentBiz.CommentCount(id, 1);
                if (countComment == 0)
                {
                    ProductBiz.DeleteProduct(id);
                    //clear cache bài viết trước khi lấy dữ liệu ra
                    //GetDataSource();
                }
                else
                {
                    BicAjax.Alert(string.Format(BicResource.GetValue("Admin", "Admin_Product_Message2")));
                }
            }
        }
        catch (Exception ex)
        {
            LogEvent.LogToFile(ex.ToString());
            rgManager.Controls.Add(
                new LiteralControl(string.Format(BicResource.GetValue("Admin", "Admin_Product_Message3"))));
            e.Canceled = true;
        }
    }

    protected void radMenuContext_ItemClick(object sender, RadMenuEventArgs e)
    {
        int index = Convert.ToInt32(Request.Form["radGridClickedRowIndex"]);
        int id = Convert.ToInt32(rgManager.Items[index].GetDataKeyValue("ProductID"));
        ProductEntity productEntity = ProductBiz.GetProductByID(id);
        switch (e.Item.Value)
        {
            case "Add":
                BicAdmin.NavigateToAdd();
                break;
            case "View":
                try
                {
                  
                    string link = string.Format(BicApplication.URLRoot + "{0}/{1}/{2}.html",
                        productEntity.LanguageKey, productEntity.MenuUserName,
                        rgManager.Items[index].GetDataKeyValue("UrlName"));                      
                    BicAjax.Open(link, "_blank");
                }
                catch(Exception ex)
                {
                    throw ex;
                }
                break;
            case "Delete":

                if (Deleted && productEntity.IsActive && Approved == false)
                    BicAjax.Alert(string.Format(BicResource.GetValue("Admin", "Admin_Product_Message1")));
                else if (Deleted)
                {
                    bool confirm = Convert.ToBoolean(Request.Form["confirmdelete"]);
                    if (confirm)
                    {
                        int countComment = CommentBiz.CommentCount(id, 1);
                        if (countComment == 0)
                        {
                            ProductBiz.DeleteProduct(id);

                            GetDataSource();
                        }
                        else
                        {
                            BicAjax.Alert(string.Format(BicResource.GetValue("Admin", "Admin_Product_Message2")));
                        }
                    }
                }
                else if (Deleted == false)
                    BicAjax.Alert(BicMessage.DenyDelete);
                break;
            case "Edit":
                if (Edited && productEntity.IsActive && Approved == false)
                    BicAjax.Alert(string.Format(BicResource.GetValue("Admin", "Admin_Product_Message1")));
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
                        dhIsNew.UpdateColumn("IsNew", updateIsNew, "ProductID",
                            e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ProductID"].ToString
                                (),
                            "Product") == false)
                        e.Canceled = true;
                    else
                        GetDataSource();

                    break;

                case "IsActive":
                    if (BicRadGrid.ExecuteBooleanCommand(e, e.CommandName, "ProductId",
                        e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex][
                            "ProductID"].ToString(), "Product"))
                        GetDataSource();
                    else
                        e.Canceled = true;
                    break;
                case "Edit":
                    ProductEntity productEntity = ProductBiz.GetProductByID(BicConvert.ToInt32(e.CommandArgument));
                    if (Edited && productEntity.IsActive && Approved == false)
                        BicAjax.Alert(string.Format(BicResource.GetValue("Admin", "Admin_Product_Message1")));
                    else if (Edited)
                    {
                        BicAdmin.NavigateToEdit(e.CommandArgument.ToString());
                    }
                    else if (Edited == false)
                        BicAjax.Alert(BicMessage.DenyEdit);
                    break;
                case "OutOfStock":
                    if (BicRadGrid.ExecuteBooleanCommand(e, e.CommandName, "ProductId",
                        e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex][
                            "ProductID"].ToString(), "Product"))
                        GetDataSource();
                    else
                        e.Canceled = true;
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
        
        ddlIsActive.SelectedIndex = 0;
        BicSession.SetValue("ProductActive", string.Empty);

        ddlTinTieuDiem.SelectedIndex = 0;
        BicSession.SetValue("ProductTinTieuDiem", string.Empty);

        ddlCommentNew.SelectedIndex = 0;
        BicSession.SetValue("ProductCommentNew", string.Empty);

        radBDBeginDate.Clear();
        BicSession.SetValue("ProductDate1", string.Empty);
        radBDEndDate.Clear();
        BicSession.SetValue("ProductDate2", string.Empty);

        rblSort.SelectedIndex = -1;
        BicSession.SetValue("ProductSort", string.Empty);

        tvMenuUser.UncheckAllNodes();
        BicSession.SetValue("ProductMenu", string.Empty);
        hdTreeMenu.Value = string.Empty;

        txtSearch.Text = string.Empty;
        BicSession.SetValue("ProductSearch", string.Empty);
        BindingRadTreeView();
        rgManager.CurrentPageIndex = 0;
        BicSession.SetValue("ProductPageIndex", 0);
        GetDataSource();
    }

    protected void btnFind_OnClick(object sender, EventArgs e)
    {
        BicSession.SetValue("ProductLanguage", ddlLanguage.SelectedValue);
        BicSession.SetValue("ProductMenu", hdTreeMenu.Value);
        BicSession.SetValue("ProductLanguageKey", ddlLanguage.SelectedValue);
        BicSession.SetValue("ProductActive", ddlIsActive.SelectedValue);
        BicSession.SetValue("ProductCommentNew", ddlCommentNew.SelectedValue);
        BicSession.SetValue("ProductSort", rblSort.SelectedValue);
        BicSession.SetValue("ProductTinTieuDiem", ddlTinTieuDiem.SelectedValue);
        BicSession.SetValue("ProductSearch", txtSearch.Text);
        BicSession.SetValue("ProductDate1", radBDBeginDate.SelectedDate);
        BicSession.SetValue("ProductDate2", radBDEndDate.SelectedDate);
        BicSession.SetValue("ProductPageIndex", 0);
        rgManager.CurrentPageIndex = 0;
        GetDataSource();
    }

    protected void ddlLanguage_SelectedIndexChanged(object sender, EventArgs e)
    {
        BicSession.SetValue("ProductLanguage", ddlLanguage.SelectedValue);
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
                int id = BicConvert.ToInt32(item.GetDataKeyValue("ProductID"));
                // Access column

                ProductEntity productEntity = ProductBiz.GetProductByID(id);
                if (productEntity == null) return;

                if (Deleted && productEntity.IsActive && Approved == false)
                    BicAjax.Alert(string.Format(BicResource.GetValue("Admin", "Admin_Product_Message1")));
                else if (Deleted)
                {
                    //if (!PermissionHelper.ByMenuUsers(productEntity.MenuUserID))
                    //{
                    //    BicAjax.Alert(BicMessage.DeletePermission + productEntity.Title);
                    //    return;
                    //}


                    ProductBiz.DeleteProduct(id);
                }
                else if (Deleted == false)
                {
                    BicAjax.Alert(BicMessage.DenyDelete);
                }
            }
        }
        GetDataSource();
    }
}