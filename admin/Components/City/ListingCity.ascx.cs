using System;
using System.Data;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;
using Telerik.Web.UI;

public partial class Admin_Components_City_ListingCity : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            radMenuContext.LoadContentFile("~/admin/XMLData/Grid/Edit_View_Delete.xml");
            radMenuContext.Items[2].Attributes.Add("onclick",
                                                    string.Format("var as;as=confirm('{0}');document.getElementById('confirmdelete').value = as;", BicMessage.Delete));
        }
    }

    private void GetDataSource()
    {
        var bicData = new BicGetData
        {
            TableName = "City"
        };

        bicData.Sorting.Add(new SortingItem("Priority", false));
        bicData.Selecting.Add(CityEntity.FIELD_CITYID);
        bicData.Selecting.Add(CityEntity.FIELD_CITYNAME);
        bicData.Selecting.Add(CityEntity.FIELD_PRIORITY);
        bicData.Selecting.Add(CityEntity.FIELD_ISACTIVE);
        bicData.Selecting.Add(CityEntity.FIELD_CHUYEN_NHANH);
        bicData.Selecting.Add(CityEntity.FIELD_CHUYEN_CHAM);
        bicData.Selecting.Add(CityEntity.FIELD_MIEN_PHI_NHANH);
        bicData.Selecting.Add(CityEntity.FIELD_MIEN_PHI_CHAM);
        if (txtSearch.Text != String.Empty)
            bicData.Conditioning.Add(new ConditioningItem(CityEntity.FIELD_CITYNAME, "%" + BicConvert.ToString(txtSearch.Text) + "%", Operator.LIKE, CompareType.STRING));
        if (ddlIsActive.SelectedValue != "2")
            bicData.Conditioning.Add(new ConditioningItem("IsActive", ddlIsActive.SelectedValue, Operator.EQUAL, CompareType.NUMERIC));
        var data = bicData.GetAllData();
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
        var id = BicConvert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["CityID"]);
        CityBiz.DeleteCity(id);
        GetDataSource();
        rgManager.DataBind();
    }

    protected void rgManager_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        GetDataSource();
    }

    protected void rgManager_ItemDataBound(object sender, GridItemEventArgs e)
    {
        var ddlCurrentPosition = (DropDownList)e.Item.FindControl("ddlCurrentPosition");
        var drv = (DataRowView)e.Item.DataItem; if (drv == null) return;
        if (ddlCurrentPosition != null) { CityBiz.PositionWithPriorityEdit(ddlCurrentPosition); ddlCurrentPosition.SelectedValue = BicConvert.ToString(drv["Priority"]); }
        var ibtnIsActive = (ImageButton)e.Item.FindControl("ibtnIsActive");
        if (ibtnIsActive != null) ibtnIsActive.Enabled = Approved;
    }

    protected void radMenuContext_ItemClick(object sender, RadMenuEventArgs e)
    {
        var index = Convert.ToInt32(Request.Form["radGridClickedRowIndex"]);
        var id = Convert.ToInt32(rgManager.Items[index].GetDataKeyValue("CityID"));
        var cityEntity = CityBiz.GetCityByID(id);
        switch (e.Item.Value)
        {
            case "Add":
                BicAdmin.NavigateToAdd();
                break;
            case "View":
                BicAdmin.NavigateToView(id.ToString());
                break;
            case "Delete":
                if (Deleted && cityEntity.IsActive && Approved == false)
                    BicAjax.Alert("Bạn không có quyền xóa bản ghi đã duyệt.");
                else
                    if (Deleted)
                    {
                        var confirm = Convert.ToBoolean(Request.Form["confirmdelete"]);
                        if (confirm)
                        {
                            CityBiz.DeleteCity(id);
                            GetDataSource();
                            rgManager.DataBind();
                        }
                    }
                    else
                        if (Deleted == false)
                            BicAjax.Alert(BicMessage.DenyDelete);
                break;
            case "Edit":
                if (Edited && cityEntity.IsActive && Approved == false)
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
        rgManager.DataBind();
    }

    protected void rgManager_ItemCommand(object source, GridCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Change":
                var dhChange = new DataHelper();
                dhChange.ChangePosition(
                    BicConvert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["CityID"]), "CityID",
                    BicConvert.ToInt32(((DropDownList)e.Item.FindControl("ddlCurrentPosition")).SelectedItem.Text),
                    "City");
                GetDataSource();
                rgManager.DataBind();
                break;
            case "IsActive":
                if (BicRadGrid.ExecuteBooleanCommand(e, e.CommandName, "CityId", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["CityID"].ToString(), "City"))
                    GetDataSource();
                else
                    e.Canceled = true;
                rgManager.DataBind();
                break;
        }
    }
}