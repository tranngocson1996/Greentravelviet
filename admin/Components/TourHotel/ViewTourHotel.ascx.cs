using System;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_TourHotel_ViewTourHotel : BaseUserControl
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
		TourHotelEntity tourhotelEntity = TourHotelBiz.GetTourHotelByID(Id);
        if (tourhotelEntity != null)
        {
			lblDBTenKhachSan.Text = BicConvert.ToString(tourhotelEntity.TenKhachSan);
			lblDBThanhPho.Text = BicConvert.ToString(tourhotelEntity.ThanhPho);
			lblDBHang.Text = BicConvert.ToString(tourhotelEntity.Hang);
			lblDBMoTaChiTiet.Text = BicConvert.ToString(tourhotelEntity.MoTaChiTiet);
			chkIsActive.Checked = BicConvert.ToBoolean(tourhotelEntity.IsActive);
			BicImage.ViewImage(isImageId, tourhotelEntity.ImageId,120,90, true);
			lblDBAnhKhachSan.Text = BicConvert.ToString(tourhotelEntity.AnhKhachSan);
			lblDBLuotXem.Text = BicConvert.ToString(tourhotelEntity.LuotXem);
			lblDBDiachi.Text = BicConvert.ToString(tourhotelEntity.Diachi);
			lblDBSoDienThoai.Text = BicConvert.ToString(tourhotelEntity.SoDienThoai);
			lblDBWebsite.Text = BicConvert.ToString(tourhotelEntity.Website);
			lblDBEmail.Text = BicConvert.ToString(tourhotelEntity.Email);
			lblDBPrice.Text = BicConvert.ToString(tourhotelEntity.Price);
			lblDBGiaChiTiet.Text = BicConvert.ToString(tourhotelEntity.GiaChiTiet);
			lblDBGiaTu.Text = BicConvert.ToString(tourhotelEntity.GiaTu);
            lblTag.Text = BicConvert.ToString(tourhotelEntity.Tag);
            lblSeoTitle.Text = BicConvert.ToString(tourhotelEntity.SEOTitle);
	    }
    }
}
