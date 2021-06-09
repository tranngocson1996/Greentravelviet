using System;
using System.Data;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;
using Telerik.Web.UI;

public partial class Admin_Components_District_ListingDistrict : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        radMenuContext.LoadContentFile("~/admin/XMLData/Grid/Edit_View_Delete.xml");
        radMenuContext.Items[2].Attributes.Add("onclick",
            string.Format(
                "var as;as=confirm('{0}');document.getElementById('confirmdelete').value = as;",
                BicMessage.Delete));
        //Call GettingCityIDCollection() method
        GettingCityIDCollection();
        if (!string.IsNullOrEmpty(BicSession.ToString("District_CityID")))
            ddlCityID.Items.FindByValue(BicSession.ToString("District_CityID")).Selected = true;
        if (!string.IsNullOrEmpty(BicSession.ToString("District_IsActive")))
            ddlIsActive.Items.FindByValue(BicSession.ToString("District_IsActive")).Selected = true;
    }

    //Geting data for CityID
    protected void GettingCityIDCollection()
    {
        var data = new BicGetData { TableName = "City" };
        data.Selecting.Add("CityName");
        data.Selecting.Add("CityID");
        ddlCityID.DataSource = data.GetAllData();
        ddlCityID.DataTextField = "CityName";
        ddlCityID.DataValueField = "CityID";
        ddlCityID.DataBind();
        ddlCityID.Items.Insert(0, new ListItem("Lựa chọn", "0"));
    }

    private void GetDataSource()
    {
        var bicData = new BicGetData
                          {
                              TableName = "District"
                          };

        bicData.Sorting.Add(new SortingItem("Priority", false));
        bicData.Selecting.Add(DistrictEntity.FIELD_DISTRICTID);
        bicData.Selecting.Add(DistrictEntity.FIELD_DISTRICTNAME);
        bicData.Selecting.Add(DistrictEntity.FIELD_PRIORITY);
        bicData.Selecting.Add(DistrictEntity.FIELD_ISACTIVE);
        bicData.Selecting.Add(DistrictEntity.FIELD_CHUYEN_NHANH);
        bicData.Selecting.Add(DistrictEntity.FIELD_CHUYEN_CHAM);
        bicData.Selecting.Add(DistrictEntity.FIELD_MIEN_PHI_NHANH);
        bicData.Selecting.Add(DistrictEntity.FIELD_MIEN_PHI_CHAM);
        if (ddlCityID.SelectedValue != "0")
            bicData.Conditioning.Add(new ConditioningItem("CityID", ddlCityID.SelectedValue, Operator.EQUAL,
                                                          CompareType.NUMERIC));
        if (txtSearch.Text != String.Empty)
            bicData.Conditioning.Add(new ConditioningItem(DistrictEntity.FIELD_DISTRICTNAME,
                                                          "%" + BicConvert.ToString(txtSearch.Text) + "%", Operator.LIKE,
                                                          CompareType.STRING));
        if (ddlIsActive.SelectedValue != "2")
            bicData.Conditioning.Add(new ConditioningItem("IsActive", ddlIsActive.SelectedValue, Operator.EQUAL,
                                                          CompareType.NUMERIC));
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
        var id = BicConvert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["DistrictID"]);
        DistrictBiz.DeleteDistrict(id);
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
        var drv = (DataRowView)e.Item.DataItem;
        if (drv == null) return;
        if (ddlCurrentPosition != null)
        {
            DistrictBiz.PositionWithPriorityEdit(ddlCurrentPosition);
            ddlCurrentPosition.SelectedValue = BicConvert.ToString(drv["Priority"]);
        }
        var ibtnIsActive = (ImageButton)e.Item.FindControl("ibtnIsActive");
        if (ibtnIsActive != null) ibtnIsActive.Enabled = Approved;
    }

    protected void radMenuContext_ItemClick(object sender, RadMenuEventArgs e)
    {
        var index = Convert.ToInt32(Request.Form["radGridClickedRowIndex"]);
        var id = Convert.ToInt32(rgManager.Items[index].GetDataKeyValue("DistrictID"));
        var districtEntity = DistrictBiz.GetDistrictByID(id);
        switch (e.Item.Value)
        {
            case "Add":
                BicAdmin.NavigateToAdd();
                break;
            case "View":
                BicAdmin.NavigateToView(id.ToString());
                break;
            case "Delete":
                if (Deleted && districtEntity.IsActive && Approved == false)
                    BicAjax.Alert("Bạn không có quyền xóa bản ghi đã duyệt.");
                else if (Deleted)
                {
                    bool confirm = Convert.ToBoolean(Request.Form["confirmdelete"]);
                    if (confirm)
                    {
                        DistrictBiz.DeleteDistrict(id);
                        GetDataSource();
                        rgManager.DataBind();
                    }
                }
                else if (Deleted == false)
                    BicAjax.Alert(BicMessage.DenyDelete);
                break;
            case "Edit":
                if (Edited && districtEntity.IsActive && Approved == false)
                    BicAjax.Alert("Bạn không có quyền sửa bản ghi đã duyệt");
                else if (Edited)
                {
                    BicAdmin.NavigateToEdit(id.ToString());
                }
                else if (Edited == false)
                    BicAjax.Alert(BicMessage.DenyEdit);
                break;
        }
    }

    //protected void ddlLanguage_SelectedIndexChanged(object o, EventArgs e)
    //{
    //    GetDataSource();
    //    rgManager.DataBind();
    //}

    protected void rgManager_ItemCommand(object source, GridCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Change":
                var dhChange = new DataHelper();
                dhChange.ChangePosition(
                    BicConvert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["DistrictID"]),
                    "DistrictID",
                    BicConvert.ToInt32(((DropDownList)e.Item.FindControl("ddlCurrentPosition")).SelectedItem.Text),
                    "District");
                GetDataSource();
                rgManager.DataBind();
                break;
            case "IsActive":
                if (BicRadGrid.ExecuteBooleanCommand(e, e.CommandName, "DistrictId",
                                                     e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["DistrictID"]
                                                         .ToString(), "District"))
                    GetDataSource();
                else
                    e.Canceled = true;
                rgManager.DataBind();
                break;
        }
    }

    protected void ddlCityID_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        BicSession.SetValue("District_CityID", ddlCityID.SelectedValue);
        GetDataSource();
        rgManager.DataBind();
    }

    protected void ddlIsActive_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        BicSession.SetValue("District_IsActive", ddlIsActive.SelectedValue);
        GetDataSource();
        rgManager.DataBind();
    }
}