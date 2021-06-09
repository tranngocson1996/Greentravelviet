using System;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_TourType_EditionTourType : BaseUserControl
{
	protected int Id;

	protected void Page_Load(object sender, EventArgs e)
	{
		Id = BicHtml.GetRequestString("id", 0);
		if (!IsPostBack)
		{
			chkIsActive.Enabled = Approved;
			ArticleBiz.PositionWithPriorityEdit(ddlPriority);
			LoadDataFromEntity();
		}
	}

	private void LoadDataFromEntity()
	{
		TourTypeEntity tourtypeEntity = TourTypeBiz.GetTourTypeByID(Id);
		if (tourtypeEntity != null)
		{
			ddlLanguage.SelectedValue = tourtypeEntity.LanguageKey;
			txtTenHinhThuc.Text = BicConvert.ToString(tourtypeEntity.TenHinhThuc);
			reMota.Content = BicConvert.ToString(tourtypeEntity.Mota);
			ddlPriority.SelectedValue = BicConvert.ToString(tourtypeEntity.Priority);
			chkIsActive.Checked = BicConvert.ToBoolean(tourtypeEntity.IsActive);
		}
	}

	private TourTypeEntity LoadDataToEntity()
	{
		TourTypeEntity tourtypeEntity = new TourTypeEntity();
		tourtypeEntity.TourTypeID = Id;

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
			if (e.CommandName == "Update")
			{
				TourTypeBiz.UpdateTourType(LoadDataToEntity());
				BicAdmin.NavigateToList();
			}
		}
		catch (Exception ex)
		{
			BicAjax.Alert(ex.Message);
		}
	}
}