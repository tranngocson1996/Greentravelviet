using System;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_Room_ViewRoom : BaseUserControl
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
        RoomEntity roomEntity = RoomBiz.GetRoomByID(Id);
        if (roomEntity == null) return;
        lblDBRoomName.Text = BicConvert.ToString(roomEntity.RoomName);
        lblDBPrice.Text = BicConvert.ToString(roomEntity.Price);
        BicImage.ViewImageFix(htmlImage, roomEntity.ImageID, 102, 66, true);
        lblDBImageArray.Text = BicConvert.ToString(roomEntity.ImageArray);
        lblDBBriefDescription.Text = BicConvert.ToString(roomEntity.BriefDescription);
        lblDBDescription.Text = BicConvert.ToString(roomEntity.Description);
        chkIsActive.Checked = BicConvert.ToBoolean(roomEntity.IsActive);
        lblDBViewed.Text = BicConvert.ToString(roomEntity.Viewed);        
    }
}