using System;
using System.Collections.Generic;
using BIC.Entity;
using BIC.Utils;
using BIC.Biz;
using System.Globalization;
using System.Linq;

public partial class Controls_Tour_TourDetail : BIC.WebControls.BaseUIControl
{
    private int MenuUserId { get; set; }
    private string TourName { get; set; }
    public string MaTour { get; set; }
    public string DateBegin { get; set; }
    public string DayAndNight { get; set; }
    public string PriceOld { get; set; }
    public string TourId { get; set; }
    public string PhuongTienHienThi { get; set; }
    public int Ngay { get; set; }
    public int Dem { get; set; }
    public string DateFini { get; set; }

    private string _currentSelectedTab = string.Empty;
    public int countImg = 0;
    public string Tag { get; set; }

    public string CssClass = "detail-tour-video";
    public string CssClassMa = "";
    public string CssClassTime = "";
    public string CssClassTime1 = "";
    public string CssClassTime2 = "hidden";
    public string CssClassTime3 = "hidden";
    public string CssClassTime4 = "hidden";
    public string CssClassTrung = "";
    public string CssClassNgayDi = "hidden";
    public string CssClassNgayVe = "hidden";

    public class AttackImage
    {
        public string Url { set; get; }
        public string UrlFull { get; set; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        string urlName = BicRouting.GetRequestString("menu-name", "");
        MenuUserEntity menu = MenuUserBiz.GetMenuUserByUrlName(urlName);
        if (menu != null)
        {
            MenuUserId = menu.MenuUserId;
        }
        TourName = BicRouting.GetRequestString("name", "");
        if (IsPostBack || string.IsNullOrEmpty(TourName)) return;
        BindingTourDetail();
    }

    private void BindingTourDetail()
    {
        var tourEntity = TourBiz.GetTourByUrlName(TourName);
        if (tourEntity != null)
        {
            //begin: set parent caption
            //CaptionDetailID.MenuUserId = tourEntity.MainMenuUserId;
            //end: set parent caption
            lblTitle.Text = tourEntity.TenTour;
            ltrDetail.Text = tourEntity.GioiThieuChung;
            ltrLichTrinhCuThe.Text = tourEntity.GioiThieuChiTiet;
            ltrChiTietGia.Text = tourEntity.ChiTietGia;
            ltrVideo.Text = tourEntity.Video;
            TourId = tourEntity.TourID.ToString();
            LoadImageArray(tourEntity.ThuVienAnh);
            //LoadImageArrayTest(tourEntity.ThuVienAnh + "," + tourEntity.ImageID);

            LoadToViewFromEntity(tourEntity);

            if (tourEntity.SEOTitle == string.Empty)
            {
                Page.Title = string.Format("{0}", tourEntity.TenTour);
                Page.MetaDescription = BicString.TrimText(tourEntity.GioiThieuChiTiet, 250);
            }
            else
                Page.Title = Page.MetaDescription = Page.MetaKeywords = tourEntity.SEOTitle;

            TourBiz.UpdateViewCount(tourEntity.TourID);

            if (string.IsNullOrEmpty(tourEntity.Video))
            {
                CssClass = "hidden";
            }
            if (string.IsNullOrEmpty(tourEntity.MaTour))
            {
                CssClassMa = "hidden";
            }
            if (tourEntity.SoNgay <= 0)
            {
                CssClassTime = "hidden";
            }
            if (tourEntity.SoNgay == 2)
            {
                CssClassTime1 = "hidden";
                CssClassTime2 = "";
                CssClassTime3 = "hidden";
                CssClassTime4 = "hidden";
            }
            if (tourEntity.SoNgay > 2)
            {
                CssClassTime1 = "hidden";
                CssClassTime2 = "hidden";
                CssClassTime3 = "";
                CssClassTime4 = "hidden";
            }
            if (tourEntity.SoNgay == 1)
            {
                CssClassTime1 = "hidden";
                CssClassTime2 = "hidden";
                CssClassTime3 = "hidden";
                CssClassTime4 = "";
            }
        }
    }

    private void LoadToViewFromEntity(TourEntity tour)
    {
        MaTour = tour.MaTour;
        DateBegin = Common.ConvertDate(tour.NoiDi);
        DateFini = Common.ConvertDate(tour.NoiDen);
        PriceOld = Common.GetPrice(tour.GiaHienThi, tour.Mota2);
        PhuongTienHienThi = tour.PhuongTienHienThi;
        Ngay = tour.SoNgay;
        Dem = tour.SoDem;

        //if (DateBegin == DateFini)
        //{
        //    CssClassTrung = "";
        //    CssClassNgayDi = "hidden";
        //    CssClassNgayVe = "hidden";
        //}

    }
    public void LoadImageArray(string imageArray)
    {
        if (string.IsNullOrEmpty(imageArray)) return;
        var images = imageArray.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        IList<AttackImage> attackImages = images.Select(image => new AttackImage
        {
            Url = BicImage.GetPathImageThumb(BicConvert.ToInt32(image)),
            UrlFull = BicImage.GetPathImage(BicConvert.ToInt32(image))
        }).ToList();

        if (attackImages.Count > 0)
        {
            // pthumb.Visible = true;
            countImg = attackImages.Count;

            rptImageArr.DataSource = rptImageArrThumb.DataSource = attackImages;
            rptImageArr.DataBind();
            rptImageArrThumb.DataBind();


            //ListImage.DataSource = attackImages;
            //ListImage.DataBind();
        }
    }

    public string IsNone(string value)
    {
        return (string.IsNullOrEmpty(value) == true ? "none" : "");
    }

    public string GetSafe(string oldPrice, string newPrice)
    {
        try
        {
            string result = string.Empty;
            if (string.IsNullOrEmpty(oldPrice) || string.IsNullOrEmpty(newPrice))
                result = "none";
            else
            {
                double old = BicConvert.ToDouble(BicString.Number(oldPrice));
                double newO = BicConvert.ToDouble(BicString.Number(newPrice));

                if (old > newO)
                {
                    result = (Math.Round((old - newO) * 100 / (old), 0)).ToString();
                }
                else
                {
                    result = "none";
                }
            }
            return result;
        }
        catch (Exception ex)
        {
            return "none";
        }
    }

    public string ToNo(string price)
    {
        try
        {
            if (string.IsNullOrEmpty(price))
            {
                return "";
            }
            else
            {
                return BicString.ToStringNO(price) + " " + BicResource.GetValue("donvigia");
            }
        }
        catch (Exception ex)
        {
            return price;
        }
    }

}