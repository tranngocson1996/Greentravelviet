using System;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_Hotel_ViewHotel : BaseUserControl
{

    public int Id;
    protected void Page_Load(object sender, EventArgs e)
    {
        Id = BicHtml.GetRequestString("id", 0);
        if (!IsPostBack)
            LoadDataFromEntity();
    }
	private void LoadDataFromEntity()
    {
		HotelEntity hotelEntity = HotelBiz.GetHotelByID(Id);
        if (hotelEntity != null)
        {
			lblDBHotelName.Text = BicConvert.ToString(hotelEntity.HotelName);
			lblDBImageID.Text = BicConvert.ToString(hotelEntity.ImageID);
			lblDBDescription.Text = BicConvert.ToString(hotelEntity.Description);
	    }
    }
}
