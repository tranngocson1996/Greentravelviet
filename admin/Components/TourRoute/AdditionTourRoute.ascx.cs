using System;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.Data;
using BIC.WebControls;

public partial class Admin_Components_TourRoute_AdditionTourRoute : BaseUserControl
{
	protected void Page_Load(object sender, EventArgs e)
    {      
        if (!IsPostBack)
        {
            TourRouteBiz.PositionWithPriorityAdd(ddlPosition);
        }
    }
    private TourRouteEntity LoadDataToEntity()
    {
     	var tourrouteEntity = new TourRouteEntity();
     	tourrouteEntity.Name = BicConvert.ToString(txtName.Text);
     	tourrouteEntity.Latitude = BicConvert.ToString(txtLatitude.Text);
     	tourrouteEntity.Longitude = BicConvert.ToString(txtLongitude.Text);
     	tourrouteEntity.Priority = BicConvert.ToInt32(ddlPosition.SelectedValue);
     	tourrouteEntity.IsActive = chkIsActive.Checked;
		return tourrouteEntity;
    }

    protected void Save(object sender, CommandEventArgs e)
    {
        try
        {
            switch (e.CommandName)
            {
                case "AddNew":
                    TourRouteBiz.InsertTourRoute(LoadDataToEntity());
                    BicAdmin.NavigateToList();
                    break;
            }
        }
        catch (Exception ex)
        {
            BicAjax.Alert(ex.Message);
        }
    }

}
