using System;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_City_AdditionCity : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            CityBiz.PositionWithPriorityAdd(ddlPosition);
    }

    private CityEntity LoadDataToEntity()
    {
        var cityEntity = new CityEntity
                             {
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
            switch (e.CommandName)
            {
                case "AddNew":
                    CityBiz.InsertCity(LoadDataToEntity());
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