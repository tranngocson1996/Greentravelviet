using System;
using System.Data;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;
using Telerik.Web.UI;

public partial class Admin_Components_Adv_ListingAdv : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (BicSession.ToString("AdvLanguage") != string.Empty)
                ddlLanguage.SelectedValue = BicSession.ToString("AdvLanguage");
            TypeOfAdvBuilder();
            if (BicSession.ToString("TypeAdvLanguage") != string.Empty)
                ddlTypeOfAdvID.SelectedValue = BicSession.ToString("TypeAdvLanguage");
            radMenuContext.LoadContentFile("~/admin/XMLData/Grid/Edit_View_Delete.xml");
            radMenuContext.Items[2].Attributes.Add("onclick", string.Format("var as;as=confirm('{0}');document.getElementById('confirmdelete').value = as;", BicMessage.Delete));            
            rgManager.MasterTableView.CurrentPageIndex = Session["AdvPageIndex"] != null ? BicSession.ToInt32("AdvPageIndex") : 0;
        }
    }
    protected void TypeOfAdvBuilder()
    {
        BicXML.BindDropDownListFromXML(ddlTypeOfAdvID, string.Format("{0}admin/XMLData/TypeOfAdv_{1}.xml", BicApplication.URLRoot, ddlLanguage.SelectedValue));
        ddlTypeOfAdvID.Items.Insert(0, new ListItem(string.Format("Tất cả", "Admin_Adv_Sectbox"), "0"));
    }
    protected void rgManager_PageIndexChanged(object source, GridPageChangedEventArgs e)
    {
        rgManager.MasterTableView.CurrentPageIndex = e.NewPageIndex;
        BicSession.SetValue("AdvPageIndex", rgManager.MasterTableView.CurrentPageIndex);
        GetDataSource();
        rgManager.DataBind();
    }
    private void GetDataSource()
    {
        var bicData = new BicGetData {TableName = "Adv", PageSize = rgManager.MasterTableView.PageSize, PageIndex = rgManager.MasterTableView.CurrentPageIndex};
        bicData.Sorting.Add(new SortingItem("Priority", false));
        bicData.Selecting.Add(AdvEntity.FIELD_ADVID);
        bicData.Selecting.Add(AdvEntity.FIELD_NAME);
        bicData.Selecting.Add(AdvEntity.FIELD_VIEWCOUNT);
        bicData.Selecting.Add(AdvEntity.FIELD_EXPIREDATE);
        bicData.Selecting.Add(AdvEntity.FIELD_ISACTIVE);
        bicData.Conditioning.Add(new ConditioningItem("LanguageKey", ddlLanguage.SelectedValue, Operator.EQUAL, CompareType.STRING));
        if (txtSearch.Text != String.Empty)
            bicData.Conditioning.Add(new ConditioningItem(AdvEntity.FIELD_NAME, "%" + BicConvert.ToString(txtSearch.Text) + "%", Operator.LIKE, CompareType.STRING));
        if (ddlTypeOfAdvID.SelectedValue != "0")
            bicData.Conditioning.Add(new ConditioningItem(AdvEntity.FIELD_TYPEOFADVID, ddlTypeOfAdvID.SelectedValue, Operator.EQUAL, CompareType.NUMERIC));
        if (ddlIsActive.SelectedValue != "2")
        {
            bicData.Conditioning.Add(new ConditioningItem("IsActive", BicConvert.ToString(ddlIsActive.SelectedValue), Operator.EQUAL, CompareType.NUMERIC));
        }
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
        int id = BicConvert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["AdvID"]);
        AdvBiz.DeleteAdv(id);
        rgManager.DataBind();
    }
    protected void rgManager_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        GetDataSource();
    }
    protected void radMenuContext_ItemClick(object sender, RadMenuEventArgs e)
    {
        int index = Convert.ToInt32(Request.Form["radGridClickedRowIndex"]);
        int id = Convert.ToInt32(rgManager.Items[index].GetDataKeyValue("AdvID"));
        switch (e.Item.Value)
        {
            case "Add":
                BicAdmin.NavigateToAdd();
                break;
            case "View":
                BicAdmin.NavigateToView(id.ToString());
                break;
            case "Delete":
                bool confirm = Convert.ToBoolean(Request.Form["confirmdelete"]);
                if (confirm)
                {
                    AdvBiz.DeleteAdv(id);
                    rgManager.Rebind();
                }
                break;
            case "Edit":
                BicAdmin.NavigateToEdit(id.ToString());
                break;
        }
    }
    protected void ddlLanguage_SelectedIndexChanged(object o, EventArgs e)
    {
        BicSession.SetValue("AdvLanguage",ddlLanguage.SelectedValue);
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
                if (dhIsActive.UpdateColumn("IsActive", updateIsActive, "AdvID", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["AdvID"].ToString(), "Adv") == false)
                    e.Canceled = true;
                else
                    rgManager.Rebind();
                break;
        }
    }
    protected void ddlTypeOfAdvID_SelectedIndexChanged(object sender, EventArgs e)
    {
        BicSession.SetValue("TypeAdvLanguage", ddlTypeOfAdvID.SelectedValue);
        GetDataSource();
        rgManager.DataBind();
    }
}