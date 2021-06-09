using System;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.Data;
using BIC.WebControls;

public partial class Admin_Components_Transportation_AdditionTransportation : BaseUserControl
{
	protected void Page_Load(object sender, EventArgs e)
    {      
        if (!IsPostBack)
        {
            TransportationBiz.PositionWithPriorityAdd(ddlPosition);
        }
    }
    private TransportationEntity LoadDataToEntity()
    {
     	var transportationEntity = new TransportationEntity();
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
            switch (e.CommandName)
            {
                case "AddNew":
                    TransportationBiz.InsertTransportation(LoadDataToEntity());
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
