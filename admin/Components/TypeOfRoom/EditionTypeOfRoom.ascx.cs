using System;
using System.Data;
using System.Web.Security;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;
using System.Web.UI.WebControls;

public partial class Admin_Components_TypeOfRoom_EditionTypeOfRoom : BaseUserControl
{
    protected int Id;
    protected void Page_Load(object sender, EventArgs e)
    {

        Id = BicHtml.GetRequestString("id", 0);

        if (!IsPostBack)
        {
            //GetHotel();
            LoadDataFromEntity();
            if (BicSession.ToString("RoomTypeLanguage") != string.Empty)
                ddlLanguage.SelectedValue = BicSession.ToString("RoomTypeLanguage"); 
        }
    }
    protected void rcbLanguage_SelectedIndexChanged(object sender, EventArgs e)
    {
        BicSession.SetValue("RoomTypeLanguage", ddlLanguage.SelectedValue);
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
        var sortField = new SortingItem(RoomEntity.FIELD_PRIORITY, false);
        data.Sorting.Add(sortField);
        data.Selecting.Add(RoomEntity.FIELD_ROOMID);
        data.Selecting.Add(RoomEntity.FIELD_ROOMNAME);
        //data.Selecting.Add(RoomEntity.FIELD_HOTELID);
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
    private void LoadDataFromEntity()
    {
        var typeofroomEntity = TypeOfRoomBiz.GetTypeOfRoomByID(Id);
        if (typeofroomEntity == null) return;
        var data = new BicGetData { TableName = "Room" };
        var sortField = new SortingItem(RoomEntity.FIELD_PRIORITY, true);
        data.Sorting.Add(sortField);
        data.Selecting.Add(RoomEntity.FIELD_ROOMID);
        data.Selecting.Add(RoomEntity.FIELD_ROOMNAME);
        data.Selecting.Add(RoomEntity.FIELD_LANGUAGEKEY);

        data.Conditioning.Add(new ConditioningItem(RoomEntity.FIELD_ROOMID, typeofroomEntity.RoomID.ToString(), Operator.EQUAL));
        var room = data.GetAllData();
        BicSession.SetValue("RoomTypeLanguage", room.Rows[0]["LanguageKey"].ToString());
        //if (BicSession.ToString("RoomTypeLanguage") != string.Empty)
        //    ddlLanguage.SelectedValue = BicSession.ToString("RoomTypeLanguage"); 
        //ddlLanguage.SelectedValue = room.Rows[0]["LanguageKey"].ToString();
        GetRoom();
        ddlRoomName.SelectedValue = BicConvert.ToString(room.Rows[0]["RoomID"]);
        txtName.Text = BicConvert.ToString(typeofroomEntity.Name);
        txtPrice.Text = BicConvert.ToString(typeofroomEntity.Price);
        chkIsActive.Checked = BicConvert.ToBoolean(typeofroomEntity.IsActive);
        txtMaxPerson.Text = BicConvert.ToString(typeofroomEntity.MaxPeople);
    }

    private TypeOfRoomEntity LoadDataToEntity()
    {
        var typeofroomEntity = new TypeOfRoomEntity
        {
            RoomName = BicConvert.ToString(ddlRoomName.SelectedItem.Text),
            TypeOfRoomID = Id,
            Name = BicConvert.ToString(txtName.Text),
            Price = BicConvert.ToString(txtPrice.Text),
            IsActive = chkIsActive.Checked,
            MaxPeople = BicConvert.ToInt32(txtMaxPerson.Text),
            RoomID = BicConvert.ToInt32(ddlRoomName.SelectedValue)
        };
        return typeofroomEntity;
    }

    protected void Save(object sender, CommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Update")
            {
                if (TypeOfRoomBiz.UpdateTypeOfRoom(LoadDataToEntity()))
                    BicAdmin.NavigateToList();
                else
                    BicAjax.Alert(BicMessage.UpdateFail);
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
