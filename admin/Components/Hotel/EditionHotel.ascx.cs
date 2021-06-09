using System;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;
using System.Web.UI.WebControls;

public partial class Admin_Components_Hotel_EditionHotel : BaseUserControl
{
    protected int Id;
    protected void Page_Load(object sender, EventArgs e)
    {
        Id = BicHtml.GetRequestString("id", 0);

        if (!IsPostBack)
        {
            LoadDataFromEntity();
        }
    }

    private void LoadDataFromEntity()
    {
        var hotelEntity = HotelBiz.GetHotelByID(Id);
        if (hotelEntity != null)
        {
            txtHotelName.Text = BicConvert.ToString(hotelEntity.HotelName);
            isImageID.ImageID = BicConvert.ToString(hotelEntity.ImageID);
            reBody.Content = BicConvert.ToString(hotelEntity.Description);
        }
    }

    private HotelEntity LoadDataToEntity()
    {
        var hotelEntity = new HotelEntity
        {
            HotelID = Id,
            HotelName = BicConvert.ToString(txtHotelName.Text),
            ImageID = BicConvert.ToInt32(isImageID.ImageID),
            Description = BicConvert.ToString(Server.HtmlDecode(reBody.Content)),
            IsActive = BicConvert.ToBoolean(chkIsActive.Checked)
        };
        return hotelEntity;
    }

    protected void Save(object sender, CommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Update")
            {
                if (HotelBiz.UpdateHotel(LoadDataToEntity()))
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
}
