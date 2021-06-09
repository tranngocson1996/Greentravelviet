using System;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Handler;
using BIC.Utils;
using BIC.WebControls;

public partial class Controls_Tour_BookTour : BaseUIControl
{
    public string CssClass = "";
    private string TourId { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        TourId = BicRouting.GetRequestString("id");
        if (!string.IsNullOrEmpty(TourId))
            BindingBookTour();
    }

    private void BindingBookTour()
    {
        try
        {
            var tourEntity = TourBiz.GetTourByID(BicConvert.ToInt32(TourId));
            if (string.IsNullOrEmpty(tourEntity.Mota2) || tourEntity.Mota2 == "0")
                if (string.IsNullOrEmpty(tourEntity.GiaHienThi) || tourEntity.GiaHienThi == "0")
                    CssClass = "hidden";
                else
                    ltrGiaHienThi.Text = ToNo(tourEntity.GiaHienThi);
            ltrGiaHienThi.Text = ToNo(tourEntity.Mota2);
            ltrMaTour.Text = tourEntity.MaTour;
            ltrSoNgay.Text = tourEntity.SoNgay.ToString();
            ltrNgayBatDau.Text = Common.ConvertDate(tourEntity.NoiDi);
            ltrNgayKetThuc.Text = Common.ConvertDate(tourEntity.NoiDen);
            ltrTenTour.Text = tourEntity.TenTour;
            var vichi = tourEntity.LichTrinhHienThi.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
            if (vichi.Length > 1)
            {
                ltrDiemDi.Text = vichi[0];
                ltrDiemDen.Text = vichi[vichi.Length - 1];
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace);
        }
    }

    private string ToNo(string price)
    {
        try
        {
            if (string.IsNullOrEmpty(price))
                return "";
            return BicString.ToStringNO(price);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace);
            return price;
        }
    }

    protected void FeedBack(object sender, CommandEventArgs e)
    {
        try
        {
            if (e.CommandName.Equals("Send"))
                SendEmail();
            if (e.CommandName.Equals("Cancel"))
            {
            }
        }
        catch (Exception ex)
        {
            LogEvent.LogToFile(ex.ToString());
        }
        ClearForm();
    }

    private void SendEmail()
    {
        var content = BicHtml.GetContents(string.Format("~/Controls/Tour/booktour_{0}.htm", Language));
        content = content.Replace("[DateTime]", DateTime.Now.ToString("dd/MM/yyyy"));
        content = content.Replace("[Domain]", BicXML.ToString("Domain", "MailConfig"));
        content = content.Replace("[Sender]", txtFullName.Text.Trim());
        content = content.Replace("[Email]", txtEmail.Text);
        content = content.Replace("[Address]", txtAddress.Text);
        content = content.Replace("[Phone]", txtPhone.Text);
        content = content.Replace("[SaleMail]", BicXML.ToString("SaleMail", "MailConfig"));
        content = content.Replace("[HinhThucThanhToan]", GetHinhThucThanhToan());
        try
        {
            TourId = BicRouting.GetRequestString("id");
            var tourEntity = TourBiz.GetTourByID(BicConvert.ToInt32(TourId));
            content = content.Replace("[TenTour]", tourEntity.TenTour);
            content = content.Replace("[MaTour]", tourEntity.MaTour);
            var vichi = tourEntity.LichTrinhHienThi.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
            if (vichi.Length > 1)
            {
                content = content.Replace("[DiTu]", vichi[0]);
                content = content.Replace("[DiemDen]", vichi[vichi.Length - 1]);
            }
            content = content.Replace("[MongMuon]", c_lich.Value);
            content = content.Replace("[NgayXuatPhat]", tourEntity.NoiDi);
            content = content.Replace("[NgayKetThuc]", tourEntity.NoiDen);
            content = content.Replace("[SoNgay]", tourEntity.SoNgay.ToString());
            content = content.Replace("[Gia]", BicString.ToStringNO(tourEntity.GiaHienThi));
            
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace);
        }
        if (BicEmail.SendContactToWebMaster(content, txtEmail.Text, txtFullName.Text))
            if (BicEmail.SendToCustomer(txtEmail.Text, BicLanguage.CurrentLanguage == "vi" ? "Đặt tour" : "Book tour",
                content))
            {
                rapContact.Alert(BicResource.GetValue("BOOK_TOUR_SUCESSFULL"));
                ClearForm();
            }
    }

    private string GetHinhThucThanhToan()
    {
        var result = string.Empty;
        if (rbnChuyenKhoan.Checked)
            result = rbnChuyenKhoan.Text;
        if (rbnOnline.Checked)
            result = rbnOnline.Text;
        if (rbnTienMat.Checked)
            result = rbnTienMat.Text;
        return result;
    }

    private void ClearForm()
    {
        txtAddress.Text = string.Empty;
        txtEmail.Text = string.Empty;
        txtPhone.Text = string.Empty;
        txtFullName.Text = string.Empty;
        rbnChuyenKhoan.Checked = false;
        rbnOnline.Checked = false;
        rbnTienMat.Checked = false;
    }
}