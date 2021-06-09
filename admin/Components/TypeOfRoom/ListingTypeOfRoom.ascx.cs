using System;
using System.Data;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;
using Telerik.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Components_TypeOfRoom_ListingTypeOfRoom : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //GetHotel();
            GetRoom();
            radMenuContext.LoadContentFile("~/admin/XMLData/Grid/Edit_View_Delete.xml");
            radMenuContext.Items[2].Attributes.Add("onclick",
                                                    string.Format("var as;as=confirm('{0}?');document.getElementById('confirmdelete').value = as;", BicMessage.Delete));
        }
    }

    //protected void GetHotel()
    //{
    //    BicGetData bicData = new BicGetData { TableName = "Hotel" };
    //    bicData.Sorting.Add(new SortingItem("Priority", true));
    //    bicData.Selecting.Add(HotelEntity.FIELD_HOTELID);
    //    bicData.Selecting.Add(HotelEntity.FIELD_HOTELNAME);
    //    DataTable dt = bicData.GetAllData();
    //    ddlHotel.DataSource = dt;
    //    ddlHotel.DataTextField = HotelEntity.FIELD_HOTELNAME;
    //    ddlHotel.DataValueField = HotelEntity.FIELD_HOTELID;
    //    ddlHotel.DataBind();

    //}
    protected void GetRoom()
    {
        var data = new BicGetData
        {
            TableName = "Room"
        };
        //Sorting Modified Date by Descending
        var sortField = new SortingItem(RoomEntity.FIELD_PRIORITY, true);
        data.Sorting.Add(sortField);
        data.Selecting.Add(RoomEntity.FIELD_ROOMID);
        data.Selecting.Add(RoomEntity.FIELD_ROOMNAME);
        data.Selecting.Add(RoomEntity.FIELD_PRICE);
        data.Selecting.Add(RoomEntity.FIELD_IMAGEID);
        data.Conditioning.Add(new ConditioningItem
        {
            Column = RoomEntity.FIELD_LANGUAGEKEY,
            Value = ddlLanguage.SelectedValue,
            Operator = Operator.EQUAL,
            CompareType = CompareType.STRING
        });
        var dt = data.GetAllData();
        ddlRoomName.DataSource = dt;
        ddlRoomName.DataTextField = "RoomName";
        ddlRoomName.DataValueField = "RoomID";
        ddlRoomName.DataBind();
        ddlRoomName.Items.Insert(0, new ListItem("[ Select ]", "0"));
    }
    private void GetDataSource()
    {
        var bicData = new BicGetData {TableName = "TypeOfRoom"};
        bicData.Sorting.Add(new SortingItem("Priority", true));
        bicData.Selecting.Add(TypeOfRoomEntity.FIELD_TYPEOFROOMID);
        bicData.Selecting.Add(TypeOfRoomEntity.FIELD_ROOMNAME);
        bicData.Selecting.Add(TypeOfRoomEntity.FIELD_MAXPEOPLE);
        bicData.Selecting.Add(TypeOfRoomEntity.FIELD_NAME);
        bicData.Selecting.Add(TypeOfRoomEntity.FIELD_PRICE);
        bicData.Selecting.Add(TypeOfRoomEntity.FIELD_ISACTIVE);
        //bicData.Conditioning.Add(new ConditioningItem
        //{
        //    Column = RoomEntity.FIELD_LANGUAGEKEY,
        //    Value = ddlLanguage.SelectedValue,
        //    Operator = Operator.EQUAL,
        //    CompareType = CompareType.STRING
        //});

        if (txtSearch.Text != String.Empty)
            bicData.Conditioning.Add(new ConditioningItem(TypeOfRoomEntity.FIELD_ROOMNAME, "%" + BicConvert.ToString(txtSearch.Text) + "%", Operator.LIKE, CompareType.STRING));
        if (ddlRoomName.SelectedValue != "0")
            bicData.Conditioning.Add(new ConditioningItem(TypeOfRoomEntity.FIELD_ROOMID, ddlRoomName.SelectedValue, Operator.EQUAL, CompareType.STRING));
        
        var data = bicData.GetPagingData();
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
        var id = BicConvert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["TypeOfRoomID"]);
        TypeOfRoomBiz.DeleteTypeOfRoom(id);
        rgManager.DataBind();
    }

    protected void rgManager_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        GetDataSource();
    }

    protected void radMenuContext_ItemClick(object sender, RadMenuEventArgs e)
    {
        var index = Convert.ToInt32(Request.Form["radGridClickedRowIndex"]);
        var id = Convert.ToInt32(rgManager.Items[index].GetDataKeyValue("TypeOfRoomID"));
        switch (e.Item.Value)
        {
            case "Add":
                BicAdmin.NavigateToAdd();
                break;
            case "View":
                BicAdmin.NavigateToView(id.ToString());
                break;
            case "Delete":
                var confirm = Convert.ToBoolean(Request.Form["confirmdelete"]);
                if (confirm)
                {
                    TypeOfRoomBiz.DeleteTypeOfRoom(id);
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
        GetRoom();
        GetDataSource();
        rgManager.DataBind();
    }


    protected void ddlRoomName_SelectedIndexChanged(object o, EventArgs e)
    {
        GetDataSource();
        rgManager.DataBind();
    }


    protected void ddlHotel_SelectedIndexChanged(object o, EventArgs e)
    {
        GetRoom();
        GetDataSource();
        rgManager.DataBind();
    }
    protected void rgManager_ItemCommand(object source, GridCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "IsActive":
                DataHelper dhIsActive = new DataHelper();
                int updateIsActive = e.CommandArgument.Equals("True") ? 0 : 1;
                if (dhIsActive.UpdateColumn("IsActive", updateIsActive, "TypeOfRoomID", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["TypeOfRoomID"].ToString(), "TypeOfRoom") == false)
                    e.Canceled = true;
                else
                    rgManager.Rebind();
                break;
        }
    }


}

