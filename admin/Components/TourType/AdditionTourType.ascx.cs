using System;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_TourType_AdditionTourType : BaseUserControl
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			TourTypeBiz.PositionWithPriorityAdd(ddlPriority);
		}
	}

	private TourTypeEntity LoadDataToEntity()
	{
		var tourtypeEntity = new TourTypeEntity();
		tourtypeEntity.LanguageKey = ddlLanguage.SelectedValue;
		tourtypeEntity.TenHinhThuc = BicConvert.ToString(txtTenHinhThuc.Text);
		tourtypeEntity.Mota = BicConvert.ToString(reMota.Content);
		tourtypeEntity.Priority = BicConvert.ToInt32(ddlPriority.SelectedValue);
		tourtypeEntity.IsActive = chkIsActive.Checked;
		return tourtypeEntity;
	}

	protected void Save(object sender, CommandEventArgs e)
	{
		try
		{
			switch (e.CommandName)
			{
				case "AddNew":
					TourTypeBiz.InsertTourType(LoadDataToEntity());
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