using System;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_City_EditionCity : BaseUserControl
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
        var cityEntity = CityBiz.GetCityByID(Id);
        if (cityEntity == null) return;
        txtCityName.Text = BicConvert.ToString(cityEntity.CityName);
        ddlPosition.SelectedValue = cityEntity.Priority.ToString();
        chkIsActive.Checked = BicConvert.ToBoolean(cityEntity.IsActive);
        txtChuyenNhanh.Text = cityEntity.ChuyenNhanh;
        txtChuyenCham.Text = cityEntity.ChuyenCham;
        txtMienPhiNhanh.Text = cityEntity.MienPhiNhanh;
        txtMienPhiCham.Text = cityEntity.MienPhiCham;
    }

    private CityEntity LoadDataToEntity()
    {
        var cityEntity = new CityEntity
        {
            CityID = Id,
            CityName = BicConvert.ToString(txtCityName.Text),
            Priority = BicConvert.ToInt32(ddlPosition.SelectedValue),
            IsActive = chkIsActive.Checked,
            ChuyenNhanh = txtChuyenNhanh.Text.Trim(),
            ChuyenCham = txtChuyenCham.Text.Trim(),
            MienPhiNhanh = txtMienPhiNhanh.Text.Trim(),
            MienPhiCham = txtMienPhiCham.Text.Trim()

        };
        return cityEntity;
    }

    protected void Save(object sender, CommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "Update") return;
            CityBiz.UpdateCity(LoadDataToEntity());
            BicAdmin.NavigateToList();
        }
        catch (Exception ex)
        {
            BicAjax.Alert(ex.Message);
        }
    }
}