using System;
using BIC.Biz;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_District_ViewDistrict : BaseUserControl
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
        var districtEntity = DistrictBiz.GetDistrictByID(Id);
        if (districtEntity == null) return;
        lblDBCityID.Text = BicConvert.ToString(districtEntity.CityID);
        lblDBDistrictName.Text = BicConvert.ToString(districtEntity.DistrictName);
        chkIsActive.Checked = BicConvert.ToBoolean(districtEntity.IsActive);
        lbChuyenNhanh.Text = string.Format("{0:N0}", BicConvert.ToDecimal(districtEntity.ChuyenNhanh));
        lbChuyenCham.Text = string.Format("{0:N0}", BicConvert.ToDecimal(districtEntity.ChuyenCham));
        lbMienPhiNhanh.Text = string.Format("{0:N0}", BicConvert.ToDecimal(districtEntity.MienPhiNhanh));
        lbMienPhiCham.Text = string.Format("{0:N0}", BicConvert.ToDecimal(districtEntity.MienPhiCham));
    }
}