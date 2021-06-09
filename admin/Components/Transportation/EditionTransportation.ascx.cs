using System;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.Data;
using BIC.WebControls;
using System.Web.UI.WebControls;

public partial class Admin_Components_Transportation_EditionTransportation : BaseUserControl
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
		TransportationEntity transportationEntity = TransportationBiz.GetTransportationByID(Id);
        if (transportationEntity != null)
        {
		   ddlLanguage.SelectedValue = transportationEntity.LanguageKey;
     	    txtTenPhuongTien.Text = BicConvert.ToString(transportationEntity.TenPhuongTien);
     	    ddlPosition.SelectedValue = transportationEntity.Priority.ToString();
     	    chkIsActive.Checked = BicConvert.ToBoolean(transportationEntity.IsActive);
        }
    }
	
    private TransportationEntity LoadDataToEntity()
    {
     	TransportationEntity transportationEntity = new TransportationEntity();
		transportationEntity.TransportationID = Id;
		
		transportationEntity.LanguageKey = ddlLanguage.SelectedValue;
     	transportationEntity.TenPhuongTien = BicConvert.ToString(txtTenPhuongTien.Text);
     	transportationEntity.Priority = BicConvert.ToInt32(ddlPosition.SelectedValue);
     	transportationEntity.IsActive = chkIsActive.Checked;
		return transportationEntity;
    }

    protected void Save(object sender, CommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Update")
            {
                TransportationBiz.UpdateTransportation(LoadDataToEntity());
                BicAdmin.NavigateToList();
            }
        }
        catch (Exception ex)
        {
            BicAjax.Alert(ex.Message);
        }
    }
}
