using System;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_TourRoute_ViewTourRoute : BaseUserControl
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
		TourRouteEntity tourrouteEntity = TourRouteBiz.GetTourRouteByID(Id);
        if (tourrouteEntity != null)
        {
			lblDBName.Text = BicConvert.ToString(tourrouteEntity.Name);
			lblDBLatitude.Text = BicConvert.ToString(tourrouteEntity.Latitude);
			lblDBLongitude.Text = BicConvert.ToString(tourrouteEntity.Longitude);
			chkIsActive.Checked = BicConvert.ToBoolean(tourrouteEntity.IsActive);
	    }
    }
}
