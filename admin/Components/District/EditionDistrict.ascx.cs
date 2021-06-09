using System;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_District_EditionDistrict : BaseUserControl
{
    protected int Id;

    protected void Page_Load(object sender, EventArgs e)
    {
        Id = BicHtml.GetRequestString("id", 0);
        if (IsPostBack) return;
        //Call GettingCityIDCollection() method
        GettingCityIDCollection();
        chkIsActive.Enabled = Approved;
        ArticleBiz.PositionWithPriorityEdit(ddlPosition);
        LoadDataFromEntity();
    }

    //Geting data for CityID
    protected void GettingCityIDCollection()
    {
        var data = new BicGetData { TableName = "City" };
        data.Selecting.Add("CityName");
        data.Selecting.Add("CityID");
        ddlCityID.DataSource = data.GetAllData();
        ddlCityID.DataTextField = "CityName";
        ddlCityID.DataValueField = "CityID";
        ddlCityID.DataBind();
        ddlCityID.Items.Insert(0, new ListItem("Lựa chọn", "0"));
    }

    private void LoadDataFromEntity()
    {
        var districtEntity = DistrictBiz.GetDistrictByID(Id);
        if (districtEntity == null) return;
        ddlCityID.SelectedValue = BicConvert.ToString(districtEntity.CityID);
        txtDistrictName.Text = BicConvert.ToString(districtEntity.DistrictName);
        ddlPosition.SelectedValue = districtEntity.Priority.ToString();
        chkIsActive.Checked = BicConvert.ToBoolean(districtEntity.IsActive);
        txtChuyenNhanh.Text = districtEntity.ChuyenNhanh;
        txtChuyenCham.Text = districtEntity.ChuyenCham;
        txtMienPhiNhanh.Text = districtEntity.MienPhiNhanh;
        txtMienPhiCham.Text = districtEntity.MienPhiCham;
    }

    private DistrictEntity LoadDataToEntity()
    {
        var districtEntity = new DistrictEntity
        {
            DistrictID = Id,
            CityID = BicConvert.ToInt32(ddlCityID.SelectedValue),
            DistrictName = BicConvert.ToString(txtDistrictName.Text),
            Priority = BicConvert.ToInt32(ddlPosition.SelectedValue),
            IsActive = chkIsActive.Checked,
            ChuyenNhanh = txtChuyenNhanh.Text.Trim(),
            ChuyenCham = txtChuyenCham.Text.Trim(),
            MienPhiNhanh = txtMienPhiNhanh.Text.Trim(),
            MienPhiCham = txtMienPhiCham.Text.Trim(),
        };

        return districtEntity;
    }

    protected void Save(object sender, CommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "Update") return;
            if (ddlCityID.SelectedValue == "0")
            {
                BicAjax.Alert("Bạn chưa chọn Tỉnh/Thành phố");
                ddlCityID.Focus(); return;
            }
            DistrictBiz.UpdateDistrict(LoadDataToEntity());
            BicAdmin.NavigateToList();
        }
        catch (Exception ex)
        {
            BicAjax.Alert(ex.Message);
        }
    }
}