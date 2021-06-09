using System;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.UI;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Data;
using BIC.Handler;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;
using Telerik.Web.UI;

public partial class Admin_Components_Category_ListingCategory : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            radMenuContext.LoadContentFile("~/admin/XMLData/Grid/Edit_View_Delete.xml");
            radMenuContext.Items[2].Attributes.Add("onclick",
                                                    string.Format("var as;as=confirm('{0}');document.getElementById('confirmdelete').value = as;", BicMessage.Delete));
            rgManager.MasterTableView.CurrentPageIndex = Session["CategoryPageIndex"] != null ? BicSession.ToInt32("CategoryPageIndex") : 0;
            GetDataSource();
            addLink.HRef = BicAdmin.UrlAdd();
            TypeOfAdvBuilder();
        }
    }
    protected void TypeOfAdvBuilder()
    {
        BicXML.BindDropDownListFromXML(ddlTypeOfCategory, string.Format("{0}admin/XMLData/TypeOfCategory_{1}.xml", BicApplication.URLRoot, BicLanguage.CurrentLanguageAdmin));
        ddlTypeOfCategory.Items.Insert(0, new ListItem(string.Format(BicResource.GetValue("Admin", "Admin_Category_DropDownList")), "0"));
    }
    private void GetDataSource()
    {
        var bicData = new BicGetData
        {
            TableName = "Category",
            PageSize = rgManager.MasterTableView.PageSize,
            PageIndex = rgManager.MasterTableView.CurrentPageIndex
        };

        bicData.Sorting.Add(new SortingItem("Priority", false));
        bicData.Selecting.Add(CategoryEntity.FIELD_CATEGORYID);
        bicData.Selecting.Add(CategoryEntity.FIELD_TYPEOFCATEGORY);
        bicData.Selecting.Add(CategoryEntity.FIELD_NAME);
        bicData.Selecting.Add(CategoryEntity.FIELD_VALUE);
        bicData.Selecting.Add(CategoryEntity.FIELD_ISACTIVE);
        if (ddlTypeOfCategory.SelectedValue != "0")
            bicData.Conditioning.Add(new ConditioningItem(CategoryEntity.FIELD_TYPEOFCATEGORY, ddlTypeOfCategory.SelectedValue, Operator.EQUAL, CompareType.NUMERIC));
        if (ddlIsActive.SelectedValue != "2")
            bicData.Conditioning.Add(new ConditioningItem("IsActive", ddlIsActive.SelectedValue, Operator.EQUAL, CompareType.NUMERIC));
        
        DataTable data = bicData.GetPagingData();
        rgManager.VirtualItemCount = bicData.TotalItems;
        rgManager.DataSource = data;
        rgManager.DataBind();
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

    protected void rgManager_PageIndexChanged(object source, GridPageChangedEventArgs e)
    {
        rgManager.MasterTableView.CurrentPageIndex = e.NewPageIndex;
        BicSession.SetValue("CategoryPageIndex", rgManager.MasterTableView.CurrentPageIndex);
        GetDataSource();

    }
    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {
        GetDataSource();

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        GetDataSource();

    }

    protected void rgManager_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        GetDataSource();
    }
    protected void rgManager_ItemDataBound(object sender, GridItemEventArgs e)
    {
        var ibtnIsActive = (ImageButton)e.Item.FindControl("ibtnIsActive");
        if (ibtnIsActive != null) ibtnIsActive.Enabled = Approved;

    }
    protected void radMenuContext_ItemClick(object sender, RadMenuEventArgs e)
    {
        var index = Convert.ToInt32(Request.Form["radGridClickedRowIndex"]);
        var id = Convert.ToInt32(rgManager.Items[index].GetDataKeyValue("CategoryID"));
        var categoryEntity = CategoryBiz.GetCategoryByID(id);
        switch (e.Item.Value)
        {
            case "Add":
                BicAdmin.NavigateToAdd();
                break;
            case "View":
                BicAdmin.NavigateToView(id.ToString());
                break;
            case "Delete":
                if (Deleted && categoryEntity.IsActive && Approved == false)
                    BicAjax.Alert("Bạn không có quyền xóa bản ghi đã duyệt.");
                else
                    if (Deleted)
                    {
                        var confirm = Convert.ToBoolean(Request.Form["confirmdelete"]);
                        if (confirm)
                        {
                            CategoryBiz.DeleteCategory(id);
                            GetDataSource();

                        }
                    }
                    else
                        if (Deleted == false)
                            BicAjax.Alert(BicMessage.DenyDelete);
                break;
            case "Edit":
                if (Edited && categoryEntity.IsActive && Approved == false)
                    BicAjax.Alert("Bạn không có quyền sửa bản ghi đã duyệt");
                else
                    if (Edited)
                    {
                        BicAdmin.NavigateToEdit(id.ToString());
                    }
                    else
                        if (Edited == false)
                            BicAjax.Alert(BicMessage.DenyEdit);
                break;
        }
    }

    protected void ddlLanguage_SelectedIndexChanged(object o, EventArgs e)
    {
        GetDataSource();

    }

    protected void ddlTypeOfCategory_SelectedIndexChanged(object o, EventArgs e)
    {
        GetDataSource();

    }

    protected void rgManager_ItemCommand(object source, GridCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "IsActive":
                if (BicRadGrid.ExecuteBooleanCommand(e, e.CommandName, "CategoryId", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["CategoryID"].ToString(), "Category"))
                    GetDataSource();
                else
                    e.Canceled = true;
                break;
        }
    }
    protected void lbtnDeleteSelected_Click(object sender, EventArgs e)
    {
        if (!Deleted)
            BicAjax.Alert(BicMessage.DenyDelete);
        else
        {
            foreach (GridDataItem item in rgManager.SelectedItems)
            {
                if (item.Selected)
                {
                    // Access data key
                    int id = BicConvert.ToInt32(item.GetDataKeyValue("CategoryID"));
                    // Access column

                    CategoryEntity categoryEntity = CategoryBiz.GetCategoryByID(id);
                    if (categoryEntity == null) return;

                    if (categoryEntity.IsActive && Approved == false)
                        BicAjax.Alert(string.Format(BicResource.GetValue("Admin", "Admin_Article_Message1")));
                    else
                    {
                        CategoryBiz.DeleteCategory(id);
                    }

                }
            }
            GetDataSource();
        }

    }


}

