using System;
using System.Data;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;
using Telerik.Web.UI;

public partial class Admin_Components_FAQ_ListingFAQ : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            radMenuContext.LoadContentFile("~/admin/XMLData/Grid/Edit_View_Delete.xml");
            radMenuContext.Items[2].Attributes.Add("onclick",
                                                   string.Format(
                                                       "var as;as=confirm('{0}?');document.getElementById('confirmdelete').value = as;",
                                                       BicMessage.Delete));
            if (BicSession.ToString("FAQLang") != string.Empty)
                ddlLanguage.SelectedValue = BicSession.ToString("FAQLang");
            rgManager.MasterTableView.CurrentPageIndex = Session["FAQsPageIndex"] != null ? BicSession.ToInt32("FAQsPageIndex") : 0;
        }
    }
    protected void rgManager_PageIndexChanged(object source, GridPageChangedEventArgs e)
    {
        rgManager.MasterTableView.CurrentPageIndex = e.NewPageIndex;
        BicSession.SetValue("FAQsPageIndex", rgManager.MasterTableView.CurrentPageIndex);
        GetDataSource();
        rgManager.DataBind();
    }

    private void GetDataSource()
    {
        var bicData = new BicGetData
                          {
                              TableName = "FAQ",
                              PageSize = rgManager.MasterTableView.PageSize,
                              PageIndex = rgManager.MasterTableView.CurrentPageIndex
                          };
        bicData.Sorting.Add(new SortingItem("FAQID", true));
        bicData.Selecting.Add(FAQEntity.FIELD_FAQID);
        bicData.Selecting.Add(FAQEntity.FIELD_TITLE);
        bicData.Selecting.Add(FAQEntity.FIELD_FAQQUESTION);
        bicData.Selecting.Add(FAQEntity.FIELD_FULLNAME);
        bicData.Selecting.Add(FAQEntity.FIELD_CREATEDDATE);
        bicData.Selecting.Add(FAQEntity.FIELD_EMAIL);
        bicData.Selecting.Add(FAQEntity.FIELD_MOBILE);
        bicData.Selecting.Add(FAQEntity.FIELD_VIEWCOUNT);
        bicData.Selecting.Add(FAQEntity.FIELD_ISACTIVE);
        bicData.Conditioning.Add(new ConditioningItem("LanguageKey", ddlLanguage.SelectedValue, Operator.EQUAL,
                                                      CompareType.STRING));
        
        if (txtSearch.Text != String.Empty)
            bicData.Conditioning.Add(new ConditioningItem(FAQEntity.FIELD_FAQQUESTION,
                                                          "%" + BicConvert.ToString(txtSearch.Text) + "%", Operator.LIKE,
                                                          CompareType.STRING));
        if (ddlIsActive.SelectedValue != "2")
            bicData.Conditioning.Add(new ConditioningItem("IsActive",
                                                          BicConvert.ToString(ddlIsActive.SelectedValue), Operator.EQUAL,
                                                          CompareType.NUMERIC));

        DataTable data = bicData.GetPagingData();
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
        int id = BicConvert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["FAQID"]);
        FAQBiz.DeleteFAQ(id);
        rgManager.DataBind();
    }

    protected void rgManager_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        GetDataSource();
    }

    protected void radMenuContext_ItemClick(object sender, RadMenuEventArgs e)
    {
        int index = Convert.ToInt32(Request.Form["radGridClickedRowIndex"]);
        int id = Convert.ToInt32(rgManager.Items[index].GetDataKeyValue("FAQID"));
        FAQEntity _faqEntity = FAQBiz.GetFAQByID(id);
        switch (e.Item.Value)
        {
            case "Add":
                BicAdmin.NavigateToAdd();
                break;
            case "View":
                BicAdmin.NavigateToView(id.ToString());
                break;
            case "Delete":
                if (Deleted && _faqEntity.IsActive && Approved == false)
                    BicAjax.Alert("Bạn không có quyền xóa bản ghi đã duyệt.");
                else if (Deleted)
                {
                    bool confirm = Convert.ToBoolean(Request.Form["confirmdelete"]);
                    if (confirm)
                    {
                        FAQBiz.DeleteFAQ(id);
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

    protected void ddlLanguage_SelectedIndexChanged(object o, EventArgs e)
    {
        BicSession.SetValue("FAQLang", ddlLanguage.SelectedValue);
       
        GetDataSource();
        rgManager.DataBind();
    }

    protected void rgManager_ItemCommand(object source, GridCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "IsActive":
                var dhIsActive = new DataHelper();
                int updateIsActive = e.CommandArgument.Equals("True") ? 0 : 1;
                if (
                    dhIsActive.UpdateColumn("IsActive", updateIsActive, "FAQID",
                                            e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["FAQID"].ToString(),
                                            "FAQ") == false)
                    e.Canceled = true;
                else
                    rgManager.Rebind();
                break;
        }
    }
}