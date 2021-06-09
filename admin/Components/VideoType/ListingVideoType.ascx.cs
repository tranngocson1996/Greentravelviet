using System;
using System.Data;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;
using Telerik.Web.UI;

public partial class Admin_Components_VideoType_ListingVideoType : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            radMenuContext.LoadContentFile("~/admin/XMLData/Grid/Edit_View_Delete.xml");
            radMenuContext.Items[2].Attributes.Add("onclick", string.Format("var as;as=confirm('{0}?');document.getElementById('confirmdelete').value = as;", BicMessage.Delete));
            rgManager.MasterTableView.CurrentPageIndex = Session["VideoTypePageIndex"] != null ? BicSession.ToInt32("VideoTypePageIndex") : 0;
        }
    }
    protected void rgManager_PageIndexChanged(object source, GridPageChangedEventArgs e)
    {
        rgManager.MasterTableView.CurrentPageIndex = e.NewPageIndex;
        BicSession.SetValue("VideoTypePageIndex", rgManager.MasterTableView.CurrentPageIndex);
        GetDataSource();
        rgManager.DataBind();
    }
    private void GetDataSource()
    {
        var bicData = new BicGetData {TableName = "VideoType", PageSize = rgManager.MasterTableView.PageSize, PageIndex = rgManager.MasterTableView.CurrentPageIndex};
        bicData.Sorting.Add(new SortingItem("Priority", true));
        bicData.Selecting.Add(VideoTypeEntity.FIELD_VIDEOTYPEID);
        bicData.Selecting.Add(VideoTypeEntity.FIELD_NAME);
        bicData.Selecting.Add(VideoTypeEntity.FIELD_ISACTIVE);
        if (txtSearch.Text != String.Empty)
            bicData.Conditioning.Add(new ConditioningItem(VideoTypeEntity.FIELD_NAME, "%" + BicConvert.ToString(txtSearch.Text) + "%", Operator.LIKE, CompareType.STRING));
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
        int id = BicConvert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["VideoTypeID"]);
        VideoTypeBiz.DeleteVideoType(id);
        rgManager.DataBind();
    }
    protected void rgManager_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        GetDataSource();
    }
    protected void radMenuContext_ItemClick(object sender, RadMenuEventArgs e)
    {
        int index = Convert.ToInt32(Request.Form["radGridClickedRowIndex"]);
        int id = Convert.ToInt32(rgManager.Items[index].GetDataKeyValue("VideoTypeID"));
        VideoTypeEntity videoTypeEntity = VideoTypeBiz.GetVideoTypeByID(id);
        switch (e.Item.Value)
        {
            case "Add":
                BicAdmin.NavigateToAdd();
                break;
            case "View":
                BicAdmin.NavigateToView(id.ToString());
                break;
            case "Delete":
                if (Deleted && videoTypeEntity.IsActive && Approved == false)
                    BicAjax.Alert("Bạn không có quyền xóa bản ghi đã được duyệt");
                else if (Deleted)
                {
                    bool confirm = Convert.ToBoolean(Request.Form["confirmdelete"]);
                    if (confirm)
                    {
                        VideoTypeBiz.DeleteVideoType(id);
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
                if (dhIsActive.UpdateColumn("IsActive", updateIsActive, "VideoTypeID", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["VideoTypeID"].ToString(), "VideoType") == false)
                    e.Canceled = true;
                else
                    rgManager.Rebind();
                break;
        }
    }
}