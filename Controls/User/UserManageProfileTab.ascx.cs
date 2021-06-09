using System;
using System.Linq;
using System.Web.Security;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Utils;
using BIC.WebControls;

public partial class Controls_User_UserProfile : BaseUIControl
{
    public string CssClass1 { get; set; }
    public string CssClass2 { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string username = BicMemberShip.CurrentUserName;
            MembershipUser user = Membership.GetUser(username);
            if (user != null && !string.IsNullOrEmpty(username))
            {
                ProfileCommon profile = Profile.GetProfile(username);
                txtAcount.Value = user.UserName;
                txtCompany.Value = profile.Company;
                txtEmail.Value = user.Email;
                txtFacebookID.Value = profile.FacebookId;
                txtFacebookLink.Value = profile.FacebookLink;
                txtFullName.Value = profile.FullName;
                txtGoogleID.Value = profile.GoogleId;
                txtGoogleLink.Value = profile.GoogleLink;
                txtPhone.Value = profile.Phone;

                txtPoint.Value = profile.Point == "0" ? "0" : BicConvert.ToDouble(profile.Point).ToString("##,###");
                txtCurPoint.Value = profile.CurrentPoint == "0" ? "0" : BicConvert.ToDouble(profile.CurrentPoint).ToString("##,###");
                txtUsedPoint.Value = profile.UsedPoint == "0" ? "0" : BicConvert.ToDouble(profile.UsedPoint).ToString("##,###");
                //txtGiftPoint.Text = profile.GiftPoint == "0" ? "0" : BicConvert.ToDouble(profile.GiftPoint).ToString("##,###");
                var note = BicString.SplitSemicolon(profile.PointHistory).Aggregate(string.Empty, (current, s) => current + (s + "\n"));
                txtPointNote.Value = note;

                BindDropDownCity();
                if (Common.DropExistValue(profile.City, ddlThanhPho))
                {
                    ddlThanhPho.SelectedValue = BicConvert.ToString(profile.City);
                    BindDropDownDistrict();
                    //Binding quan huyen
                    if (Common.DropExistValue(profile.District, ddlDistrict))
                    {
                        ddlDistrict.SelectedValue = BicConvert.ToString(profile.District);
                    }
                }

                //Binding css column hidden
                if (!profile.TypeOfAccount.Equals("google") && !profile.TypeOfAccount.Equals("facebook"))
                {
                    //CssClass1 = " col-lg-offset-3 col-md-offset-3  col-sm-offset-0 col-xs-offset-0 ";
                    //CssClass2 = " hidden ";
                }
            }
        }
        
    }

    protected void BindDropDownCity()
    {
        // Bind Dropdown city
        ddlThanhPho.Items.Clear();
        var lstCity = CityBiz.GetAllCitys();
        if (!lstCity.Any()) return;
        ddlThanhPho.DataSource = lstCity;
        ddlThanhPho.DataTextField = "CityName";
        ddlThanhPho.DataValueField = "CityID";
        ddlThanhPho.DataBind();
        ddlThanhPho.Items.Insert(0, new ListItem("-- Chọn Tỉnh/Thành phố --", "0"));
    }
    protected void ddlThanhPho_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        BindDropDownDistrict();
    }
    protected void BindDropDownDistrict()
    {
        // Bind Dropdown district
        ddlDistrict.Items.Clear();
        if (ddlThanhPho.SelectedValue == "0")
            ddlDistrict.Items.Insert(0, new ListItem("-- Chọn Quận/Huyện --", "0"));
        else
        {
            var lstDist = DistrictBiz.GetDistrictByCityID(BicConvert.ToInt32(ddlThanhPho.SelectedValue));
            if (lstDist.Any())
            {
                ddlDistrict.DataSource = lstDist;
                ddlDistrict.DataTextField = "DistrictName";
                ddlDistrict.DataValueField = "DistrictID";
                ddlDistrict.DataBind();
                ddlDistrict.Items.Insert(0, new ListItem("-- Chọn Quận/Huyện --", "0"));
            }
            else
            {
                ddlDistrict.Items.Clear();
                ddlDistrict.Items.Insert(0, new ListItem("-- Chọn Quận/Huyện --", "0"));
            }
        }
    }

    protected void btnUpdate_OnClick(object sender, EventArgs e)
    {
        var user = Membership.GetUser(BicMemberShip.CurrentUserName);
        ProfileCommon profile = Profile.GetProfile(BicMemberShip.CurrentUserName);
        if (profile != null && user != null)
        {
            //Cap nhat membership
            user.Email = txtEmail.Value.Trim();
            Membership.UpdateUser(user);
            //Cap nhat Profile trong web.config
            profile.Company = txtCompany.Value;
            profile.FacebookId = txtFacebookID.Value;
            profile.FacebookLink = txtFacebookLink.Value;
            profile.FullName = txtFullName.Value;
            profile.GoogleId = txtGoogleID.Value;
            profile.GoogleLink = txtGoogleLink.Value;
            profile.Phone = txtPhone.Value;
            profile.City = ddlThanhPho.SelectedValue;
            profile.District = ddlDistrict.SelectedValue;

            try
            {
                profile.Save();
                BicAjax.Alert(BicResource.GetValue("Message", "USER_UPDATE_SUCC"));
            }

            catch (Exception ex)
            {
                BicAjax.Alert(BicResource.GetValue("Message", "USER_UPDATE_FAIL") + "\n" + ex.Message);
            }
        }
        else
        {
            BicAjax.Alert(BicResource.GetValue("Message", "USER_UPDATE_FAIL"));
        }
    }
}