using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Handler;
using BIC.Utils;
using BIC.WebControls;
using Telerik.Web.UI;

public partial class Admin_Components_Tour_EditionTour : BaseUserControl
{
    protected int Id;
    private DataHelper db = new DataHelper();
    string idLoaiHinh = BicLanguage.CurrentLanguageAdmin == "vi" ? "118" : "141";
    protected void Page_Load(object sender, EventArgs e)
    {
        Id = BicHtml.GetRequestString("id", 0);
        if (!IsPostBack)
        {
            if (ddlLanguage.SelectedValue == "vi")
            {
                ddlVungMien.Items.Clear();
                ddlVungMien.Items.Insert(0, new ListItem("Tour trong nước", "0"));
                ddlVungMien.Items.Insert(1, new ListItem("Tour quốc tế", "1"));
                ddlVungMien.DataBind();
                ddlVungMienSub.Items.Clear();
                ddlVungMienSub.Items.Insert(0, new ListItem("Miền Bắc", "2"));
                ddlVungMienSub.Items.Insert(1, new ListItem("Miền Trung", "3"));
                ddlVungMienSub.Items.Insert(2, new ListItem("Miền Nam", "4"));
                ddlVungMienSub.DataBind();
            }
            else
            {
                ddlVungMien.Items.Clear();
                ddlVungMien.Items.Insert(0, new ListItem("Inbound", "0"));
                ddlVungMien.Items.Insert(1, new ListItem("Outbound", "1"));
                ddlVungMien.DataBind();
                ddlVungMienSub.Items.Clear();
                ddlVungMienSub.Items.Insert(0, new ListItem("Northern", "2"));
                ddlVungMienSub.Items.Insert(1, new ListItem("Central", "3"));
                ddlVungMienSub.Items.Insert(2, new ListItem("Southern", "4"));
                ddlVungMienSub.DataBind();
            }
            LoadDropDownListYTuong();
            //Common.GetCountries(ddlQuocGia);
            //ddlQuocGia.Items.RemoveAt(0);
            LoadDropDownListContry(ddlQuocGia);
            ddlQuocGia.Items.Insert(0, new ListItem(BicResource.GetValue("Country"), "0"));
            tvMenuUser.WebServiceSettings.Method = "GetNodesTours";
            tvMenuUser.WebServiceSettings.Path = BicApplication.URLRoot + "Webservice/MenuService.asmx";
            chkIsActive.Enabled = Approved;
            //TourBiz.PositionWithPriorityEdit(ddlPosition);
            LoadLichtrinh(ddlLichTrinh);
            LoadLichtrinh(ddlKhoiHanhTu);
            LoadPhuongtien();
            LoadDataFromEntity();
        }
    }
    private void LoadDropDownListContry(DropDownList dropDownList)
    {
        try
        {
            string query =
                string.Format(
                    "SELECT * FROM Country");
            DataTable data = db.ExecuteSQL(query);
            dropDownList.DataSource = data;
            dropDownList.DataValueField = "countryname";
            dropDownList.DataTextField = "countryname";
            dropDownList.DataBind();
        }
        catch (Exception ex)
        {
            LogEvent.LogToFile(ex.ToString());
        }
    }
    private void LoadYTuongTour1()
    {
        try
        {
            string mappath2 = HttpContext.Current.Server.MapPath(string.Format("~/admin/XMLData/YTuongTour_{0}.xml", ddlLanguage.SelectedValue));
            XDocument xmldoc2 = XDocument.Load(mappath2);
            IEnumerable<XElement> q2 = from xe2 in xmldoc2.Descendants("type") select xe2;
            var dt2 = new DataTable();
            dt2.Columns.Add("key");
            dt2.Columns.Add("name");
            dt2.Columns.Add("value");
            foreach (XElement xe2 in q2)
            {
                DataRow row = dt2.NewRow();
                row[0] = xe2.Attribute("key").Value;
                row[1] = xe2.Attribute("name").Value;
                row[2] = xe2.Attribute("value").Value;
                dt2.Rows.Add(row); // Thêm dòng mới vào dtb
            }
            ddlYTuong.DataSource = dt2;
            ddlYTuong.DataValueField = "value";
            ddlYTuong.DataTextField = "name";
            ddlYTuong.DataBind();
            ddlYTuong.Items.Insert(0, new ListItem(BicResource.GetValue("YTuongDuLich"), "0"));
        }
        catch (Exception ex)
        {
            LogEvent.LogToFile(ex.ToString());
        }
    }
    private void LoadDropDownListYTuong()
    {
        string parentId = BicLanguage.CurrentLanguageAdmin == "vi" ? "118" : "141";
        try
        {
            string query =
                string.Format(
                    "SELECT * FROM MenuUser WHERE Parentid='{0}' and LanguageKey='{1}' and IsActive='1'  order by Priority asc",
                    parentId, BicLanguage.CurrentLanguageAdmin);
            DataTable data = db.ExecuteSQL(query);
            ddlYTuong.DataSource = data;
            ddlYTuong.DataValueField = "MenuUserID";
            ddlYTuong.DataTextField = "Name";
            ddlYTuong.DataBind();
            ddlYTuong.Items.Insert(0, new ListItem(BicResource.GetValue("YTuongDuLich"), "0"));
        }
        catch (Exception ex)
        {
            LogEvent.LogToFile(ex.ToString());
        }
    }
    private void LoadDataFromEntity()
    {
        TelerikUtility radTelerik = new TelerikUtility();
        TourEntity tourEntity = TourBiz.GetTourByID(Id);
        if (tourEntity != null)
        {
            ddlLanguage.SelectedValue = tourEntity.LanguageKey;
            txtTenTour.Text = BicConvert.ToString(tourEntity.TenTour);
            txtMaTour.Text = BicConvert.ToString(tourEntity.MaTour);
            txtGiaHienThi.Text = BicConvert.ToString(tourEntity.GiaHienThi);
            ddlYTuong.SelectedValue = BicConvert.ToString(tourEntity.ChiTietGia);
            txtSoNgay.Text = BicConvert.ToString(tourEntity.SoNgay);
            txtNgayVe.SelectedDate = BicConvert.ToDateTime(tourEntity.NoiDen);
            txtNgayDi.SelectedDate = BicConvert.ToDateTime(tourEntity.NoiDi);
            txtGiaCu.Text = BicConvert.ToString(tourEntity.Mota2);
            radTelerik.SetCheckedCombobox(ddlLichTrinh, tourEntity.LichTrinh);
            if (tourEntity.LichTrinh != "1")
            {
                ddlVungMien.SelectedValue = "0";
                ddlVungMienSub.SelectedValue = tourEntity.LichTrinh.Trim();
                ddlVungMienSub.Visible = true;
            }
            else
            {
                ddlVungMien.SelectedValue = "1";
                ddlVungMienSub.Visible = false;
            }
            //LoadLichtrinh(ddlLichTrinh);
            //LoadLichtrinh(ddlKhoiHanhTu);
            //LoadPhuongtien();

            txtLichTrinhHienThi.Text = BicConvert.ToString(tourEntity.LichTrinhHienThi);
            radTelerik.SetCheckedCombobox(ddlPhuongTien, tourEntity.PhuongTien);
            txtPhuongTienHienThi.Text = BicConvert.ToString(tourEntity.PhuongTienHienThi);
            ddlKhoiHanhTu.SelectedValue = BicConvert.ToString(tourEntity.KhoiHanhTu);
            ddlKhoiHanhTu.Text = TourRouteBiz.GetTourRouteByID(BicConvert.ToInt32(tourEntity.KhoiHanhTu)) != null ? TourRouteBiz.GetTourRouteByID(BicConvert.ToInt32(tourEntity.KhoiHanhTu)).Name : "";
            reMoTaChung.Content = BicConvert.ToString(tourEntity.Mota1);
            reGioiThieuChung.Content = BicConvert.ToString(tourEntity.GioiThieuChung);
            reGioiThieuChiTiet.Content = BicConvert.ToString(tourEntity.GioiThieuChiTiet);
            txtChiTietGia.Content = BicConvert.ToString(tourEntity.ChiTietGia);

            isImageID.ImageID = BicConvert.ToString(tourEntity.ImageID);
            ismThuVienAnh.ImageIDArray = BicConvert.ToString(tourEntity.ThuVienAnh);
            reVideo.Content = BicConvert.ToString(tourEntity.Video);
            txtPosition.Text = tourEntity.Priority.ToString();
            txtKhoiHanh.Text = tourEntity.Mota3;
            txtLuotXem.Text = BicConvert.ToString(tourEntity.LuotXem);
            chkIsNew.Checked = BicConvert.ToBoolean(tourEntity.IsNew);
            txtGiaCu.Text = BicConvert.ToString(tourEntity.GiaTu);
            txtGiaCu.Text = tourEntity.Mota2;
            chkIsHot.Checked = BicConvert.ToString(tourEntity.Mota1).Trim() == "True" ? true : false;
            txtTag.Text = BicConvert.ToString(tourEntity.Tag);
            txtSeoTitle.Text = BicConvert.ToString(tourEntity.SEOTitle);
            chkIsActive.Checked = BicConvert.ToBoolean(tourEntity.IsActive);
            MenuUserUtils.BindingRadTreeView(tvMenuUser, ddlLanguage.SelectedValue, "tours", "cot1");
            MenuUserUtils.BindingRadTreeView(tvMenuUser2, ddlLanguage.SelectedValue, "tours", "cot2");
            MenuUserUtils.BindingRadTreeView(tvMenuUser3, ddlLanguage.SelectedValue, "tours", "cot3"); ;
            MenuUserBiz.SetCheckedNodes(tvMenuUser, tourEntity.NhomTour);
            MenuUserBiz.SetCheckedNodes(tvMenuUser2, tourEntity.NhomTour);
            MenuUserBiz.SetCheckedNodes(tvMenuUser3, tourEntity.NhomTour);
            ddlQuocGia.SelectedValue = tourEntity.Country;
            txtPageTitle.Text = tourEntity.PageTitle;
            txtMetaDescription.Text = tourEntity.MetaDescription;
            txtMetaKeyword.Text = tourEntity.MetaKeyWord;
        }
    }

    private void LoadLichtrinh(RadComboBox radCombobox)
    {
        BicGetData bicData = new BicGetData();
        bicData.TableName = "TourRoute";
        bicData.Sorting.Add(new SortingItem("Name", false));
        bicData.Selecting.Add(TourRouteEntity.FIELD_TOURROUTEID);
        bicData.Selecting.Add(TourRouteEntity.FIELD_NAME);
        bicData.Selecting.Add(TourRouteEntity.FIELD_PRIORITY);
        bicData.Selecting.Add(TourRouteEntity.FIELD_ISACTIVE);
        bicData.Conditioning.Add(new ConditioningItem("IsActive", "1", Operator.EQUAL, CompareType.NUMERIC));
        radCombobox.DataSource = bicData.GetAllData();
        radCombobox.DataBind();
    }
    protected void ddlVungMien_SelectedIndexChanged(object o, EventArgs e)
    {
        if (ddlVungMien.SelectedValue != "0")
        {
            ddlVungMienSub.Visible = false;
        }
        else
        {
            ddlVungMienSub.Visible = true;
        }
    }
    protected void ddlLanguage_SelectedIndexChanged(object o, EventArgs e)
    {
        if (ddlLanguage.SelectedValue == "vi")
        {
            ddlVungMien.Items.Clear();
            ddlVungMien.Items.Insert(0, new ListItem("Tour trong nước", "0"));
            ddlVungMien.Items.Insert(1, new ListItem("Tour quốc tế", "1"));
            ddlVungMien.DataBind();
            ddlVungMienSub.Items.Clear();
            ddlVungMienSub.Items.Insert(0, new ListItem("Miền Bắc", "2"));
            ddlVungMienSub.Items.Insert(1, new ListItem("Miền Trung", "3"));
            ddlVungMienSub.Items.Insert(2, new ListItem("Miền Nam", "4"));
            ddlVungMienSub.DataBind();
        }
        else
        {
            ddlVungMien.Items.Clear();
            ddlVungMien.Items.Insert(0, new ListItem("Inbound", "0"));
            ddlVungMien.Items.Insert(1, new ListItem("Outbound", "1"));
            ddlVungMien.DataBind();
            ddlVungMienSub.Items.Clear();
            ddlVungMienSub.Items.Insert(0, new ListItem("Northern", "2"));
            ddlVungMienSub.Items.Insert(1, new ListItem("Central", "3"));
            ddlVungMienSub.Items.Insert(2, new ListItem("Southern", "4"));
            ddlVungMienSub.DataBind();
        }
        LoadDropDownListYTuong();
    }

    private void LoadPhuongtien()
    {
        BicGetData bicData = new BicGetData();
        bicData.TableName = "Transportation";
        bicData.Sorting.Add(new SortingItem("TenPhuongTien", false));
        bicData.Selecting.Add(TransportationEntity.FIELD_TRANSPORTATIONID);
        bicData.Selecting.Add(TransportationEntity.FIELD_TENPHUONGTIEN);
        bicData.Selecting.Add(TransportationEntity.FIELD_PRIORITY);
        bicData.Selecting.Add(TransportationEntity.FIELD_ISACTIVE);
        bicData.Selecting.Add(TransportationEntity.FIELD_LANGUAGEKEY);
        bicData.Conditioning.Add(new ConditioningItem("IsActive", "1", Operator.EQUAL, CompareType.NUMERIC));
        bicData.Conditioning.Add(new ConditioningItem("LanguageKey", ddlLanguage.SelectedValue, Operator.EQUAL, CompareType.STRING));
        ddlPhuongTien.DataSource = bicData.GetAllData();
        ddlPhuongTien.DataBind();
    }

    private TourEntity LoadDataToEntity()
    {
        TelerikUtility radTelerik = new TelerikUtility();
        TourEntity tourEntity = new TourEntity();
        tourEntity.TourID = Id;
        tourEntity.LanguageKey = ddlLanguage.SelectedValue;
        tourEntity.TenTour = BicConvert.ToString(txtTenTour.Text);
        tourEntity.NhomTour = (MenuUserBiz.GetCheckedNodes(tvMenuUser) + MenuUserBiz.GetCheckedNodes(tvMenuUser2) + MenuUserBiz.GetCheckedNodes(tvMenuUser3)).ToString().Replace(",,", ",");
        tourEntity.MaTour = BicConvert.ToString(txtMaTour.Text);
        tourEntity.GiaHienThi = BicConvert.ToString(txtGiaHienThi.Text);
        tourEntity.ChiTietGia = ddlYTuong.SelectedValue;
        tourEntity.GiaTu = BicConvert.ToInt32(txtGiaCu.Text);
        tourEntity.SoNgay = BicConvert.ToInt32(txtSoNgay.Text);
        tourEntity.SoDem = BicConvert.ToInt32(txtSoNgay.Text) - 1 >= 0 ? BicConvert.ToInt32(txtSoNgay.Text) - 1 : 0;
        tourEntity.Country = ddlQuocGia.SelectedValue;

        tourEntity.LichTrinh = radTelerik.GetCheckedCombobox(ddlLichTrinh);
        tourEntity.LichTrinhHienThi = BicConvert.ToString(txtLichTrinhHienThi.Text);
        tourEntity.PhuongTien = radTelerik.GetCheckedCombobox(ddlPhuongTien);
        tourEntity.PhuongTienHienThi = BicConvert.ToString(txtPhuongTienHienThi.Text);

        tourEntity.KhoiHanhTu = BicConvert.ToInt32(ddlKhoiHanhTu.SelectedValue);
        tourEntity.Mota1 = "";
        tourEntity.GioiThieuChung = BicConvert.ToString(reGioiThieuChung.Content);
        tourEntity.GioiThieuChiTiet = BicConvert.ToString(reGioiThieuChiTiet.Content);
        tourEntity.ChiTietGia = BicConvert.ToString(txtChiTietGia.Content);
        tourEntity.ImageID = BicConvert.ToInt32(isImageID.ImageID);
        tourEntity.ThuVienAnh = BicConvert.ToString(ismThuVienAnh.ImageIDArray);
        tourEntity.Video = BicConvert.ToString(reVideo.Content);
        tourEntity.Priority = BicConvert.ToInt32(txtPosition.Text);
        tourEntity.LuotXem = BicConvert.ToInt32(txtLuotXem.Text);
        tourEntity.Tag = BicConvert.ToString(txtTag.Text);
        tourEntity.SEOTitle = BicConvert.ToString(txtSeoTitle.Text);
        tourEntity.NoiDen = txtNgayVe.SelectedDate.ToString();
        tourEntity.NoiDi = txtNgayDi.SelectedDate.ToString();
        tourEntity.Mota2 = txtGiaCu.Text;
        tourEntity.Mota3 = BicConvert.ToString(txtKhoiHanh.Text);
        tourEntity.IsNew = chkIsNew.Checked;
        tourEntity.IsActive = chkIsActive.Checked;
        tourEntity.PageTitle = txtPageTitle.Text;
        tourEntity.MetaDescription = txtMetaDescription.Text;
        tourEntity.MetaKeyWord = txtMetaKeyword.Text;
        return tourEntity;
    }

    protected void Save(object sender, CommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Update")
            {
                if (tvMenuUser.CheckedNodes.Count == 0 && tvMenuUser2.CheckedNodes.Count == 0 && tvMenuUser3.CheckedNodes.Count == 0)
                {
                    BicAjax.Alert("Bạn phải chọn ít nhất một danh mục.");
                }
                else
                {
                    TourBiz.UpdateTour(LoadDataToEntity());
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