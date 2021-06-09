using System;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_District_AdditionDistrict : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Call GettingCityIDCollection() method
            GettingCityIDCollection();
            DistrictBiz.PositionWithPriorityAdd(ddlPosition);
        }
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

    private DistrictEntity LoadDataToEntity()
    {
        var districtEntity = new DistrictEntity
        {
            CityID = BicConvert.ToInt32(ddlCityID.SelectedValue),
            DistrictName = BicConvert.ToString(txtDistrictName.Text),
            Priority = BicConvert.ToInt32(ddlPosition.SelectedValue),
            IsActive = chkIsActive.Checked,
            ChuyenNhanh = txtChuyenNhanh.Text.Trim(),
            ChuyenCham = txtChuyenCham.Text.Trim(),
            MienPhiNhanh = txtMienPhiNhanh.Text.Trim(),
            MienPhiCham = txtMienPhiCham.Text.Trim()
        };
        return districtEntity;
    }

    protected void Save(object sender, CommandEventArgs e)
    {
        try
        {
            switch (e.CommandName)
            {
                case "AddNew":
                    if (ddlCityID.SelectedValue == "0")
                    {
                        BicAjax.Alert("Bạn chưa chọn Tỉnh/Thành phố");
                        ddlCityID.Focus();
                        return;
                    }
                    DistrictBiz.InsertDistrict(LoadDataToEntity());
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