using System;
using System.Data;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;
using Telerik.Web.UI;

public partial class Admin_Components_Hotel_ListingHotel : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            radMenuContext.LoadContentFile("~/admin/XMLData/Grid/Edit_View_Delete.xml");
            radMenuContext.Items[2].Attributes.Add("onclick",
                                                    string.Format("var as;as=confirm('{0}?');document.getElementById('confirmdelete').value = as;", BicMessage.Delete));
        }
    }

    private void GetDataSource()
    {
        BicGetData bicData = new BicGetData { TableName = "Hotel" };
        bicData.Sorting.Add(new SortingItem("Priority", true));
        bicData.Selecting.Add(HotelEntity.FIELD_HOTELID);
        bicData.Selecting.Add(HotelEntity.FIELD_HOTELNAME);
        bicData.Selecting.Add(HotelEntity.FIELD_ISACTIVE);
        if (txtSearch.Text != String.Empty)
            bicData.Conditioning.Add(new ConditioningItem(HotelEntity.FIELD_HOTELNAME, "%" + BicConvert.ToString(txtSearch.Text) + "%", Operator.LIKE, CompareType.STRING));
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
        var id = BicConvert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["HotelID"]);
        HotelBiz.DeleteHotel(id);
        rgManager.DataBind();
    }

    protected void rgManager_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        GetDataSource();
    }

    protected void radMenuContext_ItemClick(object sender, RadMenuEventArgs e)
    {
        var index = Convert.ToInt32(Request.Form["radGridClickedRowIndex"]);
        var id = Convert.ToInt32(rgManager.Items[index].GetDataKeyValue("HotelID"));
        var hotelEntity = HotelBiz.GetHotelByID(id);
        switch (e.Item.Value)
        {
            case "Add":
                BicAdmin.NavigateToAdd();
                break;
            case "View":
                BicAdmin.NavigateToView(id.ToString());
                break;
            case "Delete":
                if (Deleted == true && hotelEntity.IsActive == true && Approved == false)
                    BicAjax.Alert("Bạn không có quyền xóa bản ghi đã được duyệt");
                else
                    if (Deleted == true)
                    {
                        var confirm = Convert.ToBoolean(Request.Form["confirmdelete"]);
                        if (confirm)
                        {
                            HotelBiz.DeleteHotel(id);
                            rgManager.Rebind();
                        }
                    }
                    else
                        if (Deleted == false)
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
                if (
                    dhIsActive.UpdateColumn("IsActive", updateIsActive, "HotelID",
                                            e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["HotelID"].ToString(),
                                            "Hotel") == false)
                    e.Canceled = true;
                else
                    rgManager.Rebind();
                break;
        }
    }


}

