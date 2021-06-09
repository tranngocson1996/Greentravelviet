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

public partial class Admin_Components_Tour_AdditionTour : BaseUserControl
{
    private DataHelper db=new DataHelper();
  
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(BicSession.ToString("TourLanguage")))
                ddlLanguage.SelectedValue = BicSession.ToString("TourLanguage");
            LoadDropDownListYTuong();
            tvMenuUser.WebServiceSettings.Method = "GetNodesTours";
            tvMenuUser.WebServiceSettings.Path = BicApplication.URLRoot + "Webservice/MenuService.asmx";
            chkIsActive.Enabled = Approved;

            MenuUserUtils.BindingRadTreeView(tvMenuUser, ddlLanguage.SelectedValue, "tours", "cot1");
            MenuUserUtils.BindingRadTreeView(tvMenuUser2, ddlLanguage.SelectedValue, "tours", "cot2");
            MenuUserUtils.BindingRadTreeView(tvMenuUser3, ddlLanguage.SelectedValue, "tours", "cot3");
            //TourBiz.PositionWithPriorityAdd(ddlPosition);
            LoadLichtrinh(ddlLichTrinh);
            LoadLichtrinh(ddlKhoiHanhTu);
            LoadPhuongtien();
            //Common.GetCountries(ddlQuocGia);
            //ddlQuocGia.Items.RemoveAt(0);
            LoadDropDownListContry(ddlQuocGia);
            ddlQuocGia.Items.Insert(0, new ListItem(BicResource.GetValue("Country"), "0"));
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
        }
    }

    private TourEntity LoadDataToEntity()
    {
        TelerikUtility radTelerik = new TelerikUtility();
        var tourEntity = new TourEntity
                             {
                                 LanguageKey = ddlLanguage.SelectedValue,
                                 TenTour = BicConvert.ToString(txtTenTour.Text),
                                 NhomTour = (MenuUserBiz.GetCheckedNodes(tvMenuUser) + MenuUserBiz.GetCheckedNodes(tvMenuUser2) + MenuUserBiz.GetCheckedNodes(tvMenuUser3)).ToString().Replace(",,",","),
                                 MaTour = BicConvert.ToString(txtMaTour.Text),
                                 GiaHienThi = BicConvert.ToString(txtGiaHienThi.Text),
                                 ChiTietGia = BicConvert.ToString(txtChiTietGia.Text),
                                 SoNgay = BicConvert.ToInt32(txtSoNgay.Text),
                                 SoDem = BicConvert.ToInt32(txtSoNgay.Text)-1>=0?BicConvert.ToInt32(txtSoNgay.Text)-1:0,
                                 LichTrinh = radTelerik.GetCheckedCombobox(ddlLichTrinh),
                                 LichTrinhHienThi = BicConvert.ToString(txtLichTrinhHienThi.Text),
                                 Mota2 = txtGiaCu.Text,
                                 PhuongTien = radTelerik.GetCheckedCombobox(ddlPhuongTien),
                                 PhuongTienHienThi=BicConvert.ToString(txtPhuongTienHienThi.Text),
                                 //PhuongTienHienThi = BicConvert.ToString(txtNgayVe.Text),
                                 KhoiHanhTu = BicConvert.ToInt32(ddlKhoiHanhTu.SelectedValue),
                                 Country = ddlQuocGia.SelectedValue,
                                 Mota1 = "",
                                 Mota3 = BicConvert.ToString(txtKhoiHanh.Text),
                                 NoiDen = txtNgayVe.SelectedDate.ToString(),
                                 NoiDi = txtNgayDi.SelectedDate.ToString(),                                
                                 GioiThieuChung = BicConvert.ToString(reGioiThieuChung.Content),
                                 GioiThieuChiTiet = BicConvert.ToString(reGioiThieuChiTiet.Content),
                                 ImageID = BicConvert.ToInt32(isImageID.ImageID),
                                 ThuVienAnh = BicConvert.ToString(ismThuVienAnh.ImageIDArray),
                                 Video = BicConvert.ToString(reVideo.Content),
                                 Priority = BicConvert.ToInt32(txtPosition.Text),
                                 LuotXem = BicConvert.ToInt32(txtLuotXem.Text),
                                 IsNew = chkIsNew.Checked,
                                 Tag = txtTag.Text,
                                 SEOTitle = txtSeoTitle.Text,
                                 KhachSan = BicConvert.ToInt32(ddlVungMien.SelectedValue),
                                 IsActive = chkIsActive.Checked,
                                 PageTitle = txtPageTitle.Text,
                                 MetaDescription = txtMetaDescription.Text,
                                 MetaKeyWord = txtMetaKeyword.Text
                             };
        return tourEntity;
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

    protected void Save(object sender, CommandEventArgs e)
    {
        try
        {
            switch (e.CommandName)
            {
                case "AddNew":
                    if (tvMenuUser.CheckedNodes.Count == 0 && tvMenuUser2.CheckedNodes.Count == 0 && tvMenuUser3.CheckedNodes.Count == 0)
                    {
                        BicAjax.Alert("Bạn phải chọn ít nhất một danh mục.");
                    }
                    else
                    {
                        TourBiz.InsertTour(LoadDataToEntity());
                        BicAdmin.NavigateToList();
                    }
                    break;
            }
        }
        catch (Exception ex)
        {
            BicAjax.Alert(ex.Message);
        }
    }

    protected void ddlVungMien_SelectedIndexChanged(object o, EventArgs e)
    {
        ddlVungMienSub.Visible = ddlVungMien.SelectedValue == "0";
    }

    protected void ddlLanguage_SelectedIndexChanged(object o, EventArgs e)
    {
        BicSession.SetValue("ArticleLanguage", ddlLanguage.SelectedValue);
        MenuUserUtils.BindingRadTreeView(tvMenuUser, ddlLanguage.SelectedValue, "tours");
        LoadPhuongtien();
        LoadDropDownListYTuong();
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
    }

    protected void tvMenuUser_NodeExpand(object sender, Telerik.Web.UI.RadTreeNodeEventArgs e)
    {
        DataTable dt = MenuUserBiz.GetMenuUserByTypeOfControl(BicConvert.ToInt32(e.Node.Value), "tours");
        foreach (DataRow entity in dt.Rows)
        {
            var node = new RadTreeNode();
            node.Value = entity["MenuUserId"].ToString();
            node.Text = entity["Name"].ToString();
            node.Enabled = BicConvert.ToBoolean(entity["EnableCheck"]);
            if (BicConvert.ToInt32(entity["ChildrenCount"]) > 0)
            {
                node.ExpandMode = TreeNodeExpandMode.ServerSideCallBack;
            }
            e.Node.Nodes.Add(node);
        }
    }
}