using System;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.Data;
using BIC.WebControls;
using System.Web.UI.WebControls;

public partial class Admin_Components_TourRoute_EditionTourRoute : BaseUserControl
{
	protected int Id;
	protected void Page_Load(object sender, EventArgs e)
    {      
        Id = BicHtml.GetRequestString("id", 0);
		if (!IsPostBack)
        {
            chkIsActive.Enabled = Approved;
            ArticleBiz.PositionWithPriorityEdit(ddlPosition);
			LoadDataFromEntity();
        }
    }
    private void LoadDataFromEntity()
    {
		TourRouteEntity tourrouteEntity = TourRouteBiz.GetTourRouteByID(Id);
        if (tourrouteEntity != null)
        {
     	    txtName.Text = BicConvert.ToString(tourrouteEntity.Name);
     	    txtLatitude.Text = BicConvert.ToString(tourrouteEntity.Latitude);
     	    txtLongitude.Text = BicConvert.ToString(tourrouteEntity.Longitude);
     	    ddlPosition.SelectedValue = tourrouteEntity.Priority.ToString();
     	    chkIsActive.Checked = BicConvert.ToBoolean(tourrouteEntity.IsActive);
        }
    }
	
    private TourRouteEntity LoadDataToEntity()
    {
     	TourRouteEntity tourrouteEntity = new TourRouteEntity();
		tourrouteEntity.TourRouteID = Id;
		
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
            if (e.CommandName == "Update")
            {
                TourRouteBiz.UpdateTourRoute(LoadDataToEntity());
                BicAdmin.NavigateToList();
            }
        }
        catch (Exception ex)
        {
            BicAjax.Alert(ex.Message);
        }
    }
}
