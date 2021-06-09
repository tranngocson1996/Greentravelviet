using System;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_Tour_ViewTour : BaseUserControl
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
		TourEntity tourEntity = TourBiz.GetTourByID(Id);
        if (tourEntity != null)
        {
			lblDBTenTour.Text = BicConvert.ToString(tourEntity.TenTour);
			lblDBNhomTour.Text = BicConvert.ToString(tourEntity.NhomTour);
			lblDBMaTour.Text = BicConvert.ToString(tourEntity.MaTour);
			lblDBGiaHienThi.Text = BicConvert.ToString(tourEntity.GiaHienThi);
			lblDBChiTietGia.Text = BicConvert.ToString(tourEntity.ChiTietGia);
			lblDBSoNgay.Text = BicConvert.ToString(tourEntity.SoNgay);
			lblDBSoDem.Text = BicConvert.ToString(tourEntity.SoDem);
			lblDBLichTrinh.Text = BicConvert.ToString(tourEntity.LichTrinh);
			lblDBLichTrinhHienThi.Text = BicConvert.ToString(tourEntity.LichTrinhHienThi);
			lblDBPhuongTien.Text = BicConvert.ToString(tourEntity.PhuongTien);
			lblDBPhuongTienHienThi.Text = BicConvert.ToString(tourEntity.PhuongTienHienThi);
			lblDBKhoiHanhTu.Text = BicConvert.ToString(tourEntity.KhoiHanhTu);
			lblDBGioiThieuChung.Text = BicConvert.ToString(tourEntity.GioiThieuChung);
			lblDBGioiThieuChiTiet.Text = BicConvert.ToString(tourEntity.GioiThieuChiTiet);
			BicImage.ViewImage(isImageID, tourEntity.ImageID,120,90, true);
			lblDBThuVienAnh.Text = BicConvert.ToString(tourEntity.ThuVienAnh);
			lblDBVideo.Text = BicConvert.ToString(tourEntity.Video);
			lblDBLuotXem.Text = BicConvert.ToString(tourEntity.LuotXem);
			chkIsNew.Checked = BicConvert.ToBoolean(tourEntity.IsNew);
            lblTag.Text = BicConvert.ToString(tourEntity.Tag);
            lblSeoTitle.Text = BicConvert.ToString(tourEntity.SEOTitle);
			chkIsActive.Checked = BicConvert.ToBoolean(tourEntity.IsActive);
	    }
    }
}
