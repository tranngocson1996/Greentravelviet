using System;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_TourHotel_EditionTourHotel : BaseUserControl
{
	protected int Id;

	protected void Page_Load(object sender, EventArgs e)
	{
		Id = BicHtml.GetRequestString("id", 0);
		if (!IsPostBack)
		{
			tvMenuUser.WebServiceSettings.Method = "GetNodesTours";
			tvMenuUser.WebServiceSettings.Path = BicApplication.URLRoot + "Webservice/MenuService.asmx";
			chkIsActive.Enabled = Approved;
            //TourHotelBiz.PositionWithPriorityAdd(ddlPosition);
			LoadDataFromEntity();
		}
	}

	private void LoadDataFromEntity()
	{
		TourHotelEntity tourhotelEntity = TourHotelBiz.GetTourHotelByID(Id);
		if (tourhotelEntity != null)
		{
			ddlLanguage.SelectedValue = tourhotelEntity.LanguageKey;
			txtTenKhachSan.Text = BicConvert.ToString(tourhotelEntity.TenKhachSan);
			MenuUserUtils.BindingRadTreeViewRecursion(tvMenuUser, ddlLanguage.SelectedValue, "hotels");
			MenuUserBiz.SetCheckedNodes(tvMenuUser, tourhotelEntity.ThanhPho);
			radRating.Value = BicConvert.ToInt32(tourhotelEntity.Hang);
			ddlKieu.SelectedValue = tourhotelEntity.Kieu;
			ddlKieu.Text = tourhotelEntity.Kieu;
			reMoTaChiTiet.Content = BicConvert.ToString(tourhotelEntity.MoTaChiTiet);
			ddlPosition.SelectedValue = tourhotelEntity.Priority.ToString();
			chkIsActive.Checked = BicConvert.ToBoolean(tourhotelEntity.IsActive);
			isImageId.ImageID = BicConvert.ToString(tourhotelEntity.ImageId);
			ismAnhKhachSan.ImageIDArray = BicConvert.ToString(tourhotelEntity.AnhKhachSan);
			txtLuotXem.Text = BicConvert.ToString(tourhotelEntity.LuotXem);
			txtDiachi.Text = BicConvert.ToString(tourhotelEntity.Diachi);
			txtSoDienThoai.Text = BicConvert.ToString(tourhotelEntity.SoDienThoai);
			txtWebsite.Text = BicConvert.ToString(tourhotelEntity.Website);
			txtEmail.Text = BicConvert.ToString(tourhotelEntity.Email);
			txtPrice.Text = BicConvert.ToString(tourhotelEntity.Price);
			reGiaChiTiet.Content = BicConvert.ToString(tourhotelEntity.GiaChiTiet);
			txtGiaTu.Text = BicConvert.ToString(tourhotelEntity.GiaTu);
			reRoom.Content = BicConvert.ToString(tourhotelEntity.Room);
			reThietBiPhong.Content = BicConvert.ToString(tourhotelEntity.ThietBiPhong);                         
            txtSeoTitle.Text = tourhotelEntity.SEOTitle;
            txtTag.Text = BicConvert.ToString(tourhotelEntity.Tag);
		}
	}

	private TourHotelEntity LoadDataToEntity()
	{
		TourHotelEntity tourhotelEntity = new TourHotelEntity();
		tourhotelEntity.TourHotelID = Id;

		tourhotelEntity.LanguageKey = ddlLanguage.SelectedValue;
		tourhotelEntity.TenKhachSan = BicConvert.ToString(txtTenKhachSan.Text);
		tourhotelEntity.ThanhPho = MenuUserBiz.GetCheckedNodes(tvMenuUser);
		tourhotelEntity.Hang = BicConvert.ToInt32(radRating.Value);
		tourhotelEntity.Kieu = BicConvert.ToString(ddlKieu.SelectedValue);
		tourhotelEntity.MoTaChiTiet = BicConvert.ToString(reMoTaChiTiet.Content);
		tourhotelEntity.Priority = BicConvert.ToInt32(ddlPosition.SelectedValue);
		tourhotelEntity.IsActive = chkIsActive.Checked;
		tourhotelEntity.ImageId = BicConvert.ToInt32(isImageId.ImageID);
		tourhotelEntity.AnhKhachSan = BicConvert.ToString(ismAnhKhachSan.ImageIDArray);
		tourhotelEntity.LuotXem = BicConvert.ToInt32(txtLuotXem.Text);
		tourhotelEntity.Diachi = BicConvert.ToString(txtDiachi.Text);
		tourhotelEntity.SoDienThoai = BicConvert.ToString(txtSoDienThoai.Text);
		tourhotelEntity.Website = BicConvert.ToString(txtWebsite.Text);
		tourhotelEntity.Email = BicConvert.ToString(txtEmail.Text);
		tourhotelEntity.Price = BicConvert.ToString(txtPrice.Text);
		tourhotelEntity.GiaChiTiet = BicConvert.ToString(reGiaChiTiet.Content);
		tourhotelEntity.GiaTu = BicConvert.ToDouble(txtGiaTu.Text);
		tourhotelEntity.Room = BicConvert.ToString(reRoom.Content);
		tourhotelEntity.ThietBiPhong = BicConvert.ToString(reThietBiPhong.Content);
        tourhotelEntity.Tag = BicConvert.ToString(txtTag.Text);
        tourhotelEntity.SEOTitle = BicConvert.ToString(txtSeoTitle.Text);
		return tourhotelEntity;
	}

	protected void Save(object sender, CommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "Update")
			{
				if (tvMenuUser.CheckedNodes.Count == 0)
				{
					BicAjax.Alert("Bạn phải chọn ít nhất một danh mục.");
				}
				else
				{
					TourHotelBiz.UpdateTourHotel(LoadDataToEntity());
					BicAdmin.NavigateToList();
				}
			}
		}
		catch (Exception ex)
		{
			BicAjax.Alert(ex.Message);
		}
	}
}