using System;
using System.Data;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;
using Telerik.Web.UI;

public partial class Admin_Components_Control_ListingControl : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            radMenuContext.LoadContentFile("~/admin/XMLData/Grid/Edit_View_Delete_"+BicLanguage.CurrentLanguageAdmin+".xml" );
            radMenuContext.Items[2].Attributes.Add("onclick", string.Format("var as;as=confirm('{0}?');document.getElementById('confirmdelete').value = as;", BicMessage.Delete));
            rgManager.MasterTableView.CurrentPageIndex = Session["ControlPageIndex"] != null ? BicSession.ToInt32("ControlPageIndex") : 0;
        }
    }
    protected void rgManager_PageIndexChanged(object source, GridPageChangedEventArgs e)
    {
        rgManager.MasterTableView.CurrentPageIndex = e.NewPageIndex;
        BicSession.SetValue("ControlPageIndex", rgManager.MasterTableView.CurrentPageIndex);
        GetDataSource();
        rgManager.DataBind();
    }
    private void GetDataSource()
    {
        var bicData = new BicGetData {TableName = "Control", PageSize = rgManager.PageSize, PageIndex = rgManager.CurrentPageIndex};
        bicData.Sorting.Add(new SortingItem("ControlName", false));
        bicData.Selecting.Add(ControlEntity.FIELD_CONTROLID);
        bicData.Selecting.Add(ControlEntity.FIELD_CONTROLNAME);
        bicData.Selecting.Add(ControlEntity.FIELD_FOLDERNAME);
        bicData.Selecting.Add(ControlEntity.FIELD_LOADURL);
        bicData.Selecting.Add(ControlEntity.FIELD_ISACTIVE);
        if (txtSearch.Text != String.Empty)
            bicData.Conditioning.Add(new ConditioningItem(ControlEntity.FIELD_CONTROLNAME, "%" + BicConvert.ToString(txtSearch.Text) + "%", Operator.LIKE, CompareType.STRING));
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
        int id = BicConvert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ControlID"]);
        ControlBiz.DeleteControl(id);
        rgManager.DataBind();
    }
    protected void rgManager_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        GetDataSource();
    }
    protected void radMenuContext_ItemClick(object sender, RadMenuEventArgs e)
    {
        int index = Convert.ToInt32(Request.Form["radGridClickedRowIndex"]);
        int id = Convert.ToInt32(rgManager.Items[index].GetDataKeyValue("ControlID"));
        ControlEntity controlEntity = ControlBiz.GetControlByID(id);
        switch (e.Item.Value)
        {
            case "Add":
                BicAdmin.NavigateToAdd();
                break;
            case "View":
                BicAdmin.NavigateToView(id.ToString());
                break;
            case "Delete":
                if (Deleted && controlEntity.IsActive && Approved == false)
                    BicAjax.Alert(string.Format(BicResource.GetValue("Admin", "Admin_Controls_Message1")));
                else if (Deleted)
                {
                    bool confirm = Convert.ToBoolean(Request.Form["confirmdelete"]);
                    if (confirm)
                    {
                        ControlBiz.DeleteControl(id);
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
    protected void rgManager_ItemCommand(object source, GridCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "IsActive":
                var dhIsActive = new DataHelper();
                int updateIsActive = e.CommandArgument.Equals("True") ? 0 : 1;
                if (dhIsActive.UpdateColumn("IsActive", updateIsActive, "ControlID", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ControlID"].ToString(), "Control") == false)
                    e.Canceled = true;
                else
                    rgManager.Rebind();
                break;
        }
    }
}