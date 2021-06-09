using System;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_TypeOfRoom_ViewTypeOfRoom : BaseUserControl
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
		TypeOfRoomEntity typeofroomEntity = TypeOfRoomBiz.GetTypeOfRoomByID(Id);
        if (typeofroomEntity != null)
        {
			lblDBRoomName.Text = BicConvert.ToString(typeofroomEntity.RoomName);
			lblDBName.Text = BicConvert.ToString(typeofroomEntity.Name);
			lblDBPrice.Text = BicConvert.ToString(typeofroomEntity.Price);
			chkIsActive.Checked = BicConvert.ToBoolean(typeofroomEntity.IsActive);
	    }
    }
}
