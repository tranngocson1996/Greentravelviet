using System;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_Hotel_AdditionHotel : BaseUserControl
{

    private HotelEntity LoadDataToEntity()
    {
        var hotelEntity = new HotelEntity
                              {
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
            switch (e.CommandName)
            {
                case "AddNew":
                    if (HotelBiz.InsertHotel(LoadDataToEntity()))
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

}
