using System;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_Transportation_ViewTransportation : BaseUserControl
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
		TransportationEntity transportationEntity = TransportationBiz.GetTransportationByID(Id);
        if (transportationEntity != null)
        {
			lblDBTenPhuongTien.Text = BicConvert.ToString(transportationEntity.TenPhuongTien);
			chkIsActive.Checked = BicConvert.ToBoolean(transportationEntity.IsActive);
	    }
    }
}
