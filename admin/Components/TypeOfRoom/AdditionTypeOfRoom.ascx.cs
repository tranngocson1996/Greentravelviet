using System;
using System.Data;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_TypeOfRoom_AdditionTypeOfRoom : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           // GetHotel();
            GetRoom();
        }
    }
    protected void rcbLanguage_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetRoom();
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
        //data.Conditioning.Add(new ConditioningItem(HotelEntity.FIELD_HOTELID, ddlHotel.SelectedValue, Operator.EQUAL, CompareType.NUMERIC));
        DataTable dt = data.GetAllData();
        ddlRoomName.DataSource = dt;
        ddlRoomName.DataTextField = "RoomName";
        ddlRoomName.DataValueField = "RoomID";
        ddlRoomName.DataBind();
    }
    private TypeOfRoomEntity LoadDataToEntity()
    {
        var typeofroomEntity = new TypeOfRoomEntity
                                   {
                                       RoomName = BicConvert.ToString(ddlRoomName.SelectedItem.Text),
                                       Name = BicConvert.ToString(txtName.Text),
                                       Price = BicConvert.ToString(txtPrice.Text),
                                       IsActive = chkIsActive.Checked,
                                       MaxPeople = BicConvert.ToInt32(txtMaxPerson.Text),
                                       RoomID = BicConvert.ToInt32(ddlRoomName.SelectedValue),
                                   };
        return typeofroomEntity;
    }

    protected void Save(object sender, CommandEventArgs e)
    {
        try
        {
            switch (e.CommandName)
            {
                case "AddNew":
                    if (TypeOfRoomBiz.InsertTypeOfRoom(LoadDataToEntity()))
                        BicAdmin.NavigateToList();
                    else
                        BicAjax.Alert(BicMessage.InsertFail);
                    break;
            }
        }
        catch (Exception ex)
        {
            BicAjax.Alert(ex.Message);
        }
    }


    protected void ddlHotel_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetRoom();
    }
}
