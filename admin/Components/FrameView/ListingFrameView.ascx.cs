using System;
using System.Data;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;
using Telerik.Web.UI;

public partial class Admin_Components_FrameView_ListingFrameView : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            radMenuContext.LoadContentFile("~/admin/XMLData/Grid/Edit_View_Delete_"+BicLanguage.CurrentLanguageAdmin+".xml");
            radMenuContext.Items[2].Attributes.Add("onclick", string.Format("var as;as=confirm('{0}?');document.getElementById('confirmdelete').value = as;", BicMessage.Delete));
            rgManager.MasterTableView.CurrentPageIndex = Session["FrameViewPageIndex"] != null ? BicSession.ToInt32("FrameViewPageIndex") : 0;
        }
    }
    protected void rgManager_PageIndexChanged(object source, GridPageChangedEventArgs e)
    {
        rgManager.MasterTableView.CurrentPageIndex = e.NewPageIndex;
        BicSession.SetValue("FrameViewPageIndex", rgManager.MasterTableView.CurrentPageIndex);
        GetDataSource();
        rgManager.DataBind();
    }
    private void GetDataSource()
    {
        var bicData = new BicGetData {TableName = "FrameView", PageSize = rgManager.MasterTableView.PageSize, PageIndex = rgManager.MasterTableView.CurrentPageIndex};
        bicData.Sorting.Add(new SortingItem("Priority", true));
        bicData.Selecting.Add(FrameViewEntity.FIELD_FRAMEVIEWID);
        bicData.Selecting.Add(FrameViewEntity.FIELD_NAME);
        bicData.Selecting.Add(FrameViewEntity.FIELD_GROUPNAME);
        bicData.Selecting.Add(FrameViewEntity.FIELD_TYPEOFCONTROL);
        bicData.Selecting.Add(FrameViewEntity.FIELD_URLCONTROL);
        bicData.Selecting.Add(FrameViewEntity.FIELD_NEWCOLUMN1);
        bicData.Selecting.Add(FrameViewEntity.FIELD_NEWCOLUMN2);
        bicData.Selecting.Add("IsActive");
        bicData.Selecting.Add("ResourceKey");
        if (txtSearch.Text != String.Empty)
            bicData.Conditioning.Add(new ConditioningItem(FrameViewEntity.FIELD_NAME, "%" + BicConvert.ToString(txtSearch.Text) + "%", Operator.LIKE, CompareType.STRING));
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
        int id = BicConvert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["FrameViewID"]);
        FrameViewBiz.DeleteFrameView(id);
        rgManager.DataBind();
    }
    protected void rgManager_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        GetDataSource();
    }
    protected void radMenuContext_ItemClick(object sender, RadMenuEventArgs e)
    {
        int index = Convert.ToInt32(Request.Form["radGridClickedRowIndex"]);
        int id = Convert.ToInt32(rgManager.Items[index].GetDataKeyValue("FrameViewID"));
        FrameViewEntity frameViewEntity = FrameViewBiz.GetFrameViewByID(id);
        switch (e.Item.Value)
        {
            case "Add":
                BicAdmin.NavigateToAdd();
                break;
            case "View":
                BicAdmin.NavigateToView(id.ToString());
                break;
            case "Delete":
                if (Deleted && frameViewEntity.IsActive && Approved == false)
                    BicAjax.Alert(string.Format(BicResource.GetValue("Admin","Admin_FrameView_Message1")));
                else if (Deleted)
                {
                    bool confirm = Convert.ToBoolean(Request.Form["confirmdelete"]);
                    if (confirm)
                    {
                        FrameViewBiz.DeleteFrameView(id);
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
                if (dhIsActive.UpdateColumn("IsActive", updateIsActive, "FrameViewID", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["FrameViewID"].ToString(), "FrameView") == false)
                    e.Canceled = true;
                else
                    rgManager.Rebind();
                break;
        }
    }
}