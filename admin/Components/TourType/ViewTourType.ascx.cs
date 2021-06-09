using System;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_TourType_ViewTourType : BaseUserControl
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
		TourTypeEntity tourtypeEntity = TourTypeBiz.GetTourTypeByID(Id);
        if (tourtypeEntity != null)
        {
			lblDBTenHinhThuc.Text = BicConvert.ToString(tourtypeEntity.TenHinhThuc);
			lblDBMota.Text = BicConvert.ToString(tourtypeEntity.Mota);
			lblDBPriority.Text = BicConvert.ToString(tourtypeEntity.Priority);
			chkIsActive.Checked = BicConvert.ToBoolean(tourtypeEntity.IsActive);
	    }
    }
}
