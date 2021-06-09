using System;
using BIC.Biz;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_City_ViewCity : BaseUserControl
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
        var cityEntity = CityBiz.GetCityByID(Id);
        if (cityEntity == null) return;
        lblDBCityName.Text = BicConvert.ToString(cityEntity.CityName);
        chkIsActive.Checked = BicConvert.ToBoolean(cityEntity.IsActive);
        lbChuyenNhanh.Text = string.Format("{0:N0}", BicConvert.ToDecimal(cityEntity.ChuyenNhanh));
        lbChuyenCham.Text = string.Format("{0:N0}", BicConvert.ToDecimal(cityEntity.ChuyenCham));
        lbMienPhiNhanh.Text = string.Format("{0:N0}", BicConvert.ToDecimal(cityEntity.MienPhiNhanh));
        lbMienPhiCham.Text = string.Format("{0:N0}", BicConvert.ToDecimal(cityEntity.MienPhiCham));
    }
}