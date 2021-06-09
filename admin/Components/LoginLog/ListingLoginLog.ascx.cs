using System;
using System.Data;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;
using Telerik.Web.UI;

public partial class Admin_Components_LoginLog_ListingLoginLog : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        rgManager.MasterTableView.CurrentPageIndex = Session["LoginLogPageIndex"] != null ? BicSession.ToInt32("LoginLogPageIndex") : 0;
    }
    protected void rgManager_PageIndexChanged(object source, GridPageChangedEventArgs e)
    {
        rgManager.MasterTableView.CurrentPageIndex = e.NewPageIndex;
        BicSession.SetValue("LoginLogPageIndex", rgManager.MasterTableView.CurrentPageIndex);
        GetDataSource();
        rgManager.DataBind();
    }
    private void GetDataSource()
    {
        var bicData = new BicGetData {TableName = "LoginLog", PageSize = rgManager.MasterTableView.PageSize, PageIndex = rgManager.MasterTableView.CurrentPageIndex};
        bicData.Sorting.Add(new SortingItem("Priority", true));
        bicData.Selecting.Add(LoginLogEntity.FIELD_LOGINLOGID);
        bicData.Selecting.Add(LoginLogEntity.FIELD_USERNAME);
        bicData.Selecting.Add(LoginLogEntity.FIELD_LOGINTIME);
        if (txtSearch.Text != String.Empty)
            bicData.Conditioning.Add(new ConditioningItem(LoginLogEntity.FIELD_USERNAME, "%" + BicConvert.ToString(txtSearch.Text) + "%", Operator.LIKE, CompareType.STRING));
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
        int id = BicConvert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["LoginLogID"]);
        LoginLogBiz.DeleteLoginLog(id);
        rgManager.DataBind();
    }
    protected void rgManager_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        GetDataSource();
    }
    protected void rgManager_ItemCommand(object source, GridCommandEventArgs e)
    {
        switch (e.CommandName)
        {
        }
    }
}