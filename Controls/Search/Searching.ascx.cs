using System;
using System.Collections.Generic;
using System.Data;
using BIC.Data;
using BIC.Handler;
using BIC.Utils;
using BIC.WebControls;
using Telerik.Web.UI;


public partial class Controls_Search_Searching : BaseUIControl
{
    public string Code = string.Empty;
    public string Type=string.Empty;
    public string Keyword = string.Empty;
    public string MenuUserId = string.Empty;
    private string _link = string.Empty;
    private  DataHelper db=new DataHelper();
    public class MenuPrice
    {
        public string Name { get; set; }
        public string Text { get; set; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) return;
        
        string idKhoanggia = BicLanguage.CurrentLanguage == "vi" ? "121" : "142";
        string idLoaiHinh = BicLanguage.CurrentLanguage == "vi" ? "118" : "141";
        LoadPriceOver(idKhoanggia);
        LoadDropDownList(idLoaiHinh, drlLoaiHinh,"MenuUserID");
        LoadDropDownListContry(drlDiaDiem);
        LoadDropDownListDay(drlSoLuongNgay);
    }

    private void LoadDropDownList(string parentId, RadComboBox dropDownList,string dataValueFiled)
    {
        try
        {
            string query =
                string.Format(
                    "SELECT * FROM MenuUser WHERE Parentid='{0}' and LanguageKey='{1}' and IsActive='1'  order by Priority asc",
                    parentId, BicLanguage.CurrentLanguage);
            DataTable data = db.ExecuteSQL(query);
            dropDownList.DataSource = data;
            dropDownList.DataValueField = dataValueFiled;  
            dropDownList.DataTextField = "Name";
            dropDownList.DataBind();
        }
        catch (Exception ex)
        {
            LogEvent.LogToFile(ex.ToString());
        }
    }

    private void LoadPriceOver(string parentId)
    {
        try
        {
            string query =
                string.Format(
                    "SELECT * FROM MenuUser WHERE Parentid='{0}' and LanguageKey='{1}' and IsActive='1'  order by Priority asc",
                    parentId, BicLanguage.CurrentLanguage);
            DataTable data = db.ExecuteSQL(query);
            IList<MenuPrice> arrPrice = new List<MenuPrice>();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                MenuPrice mnPrice = new MenuPrice()
                {
                    Name = data.Rows[i]["Name"].ToString(),
                    Text = ChangePrice(data.Rows[i]["Name"].ToString())
                };
                arrPrice.Add(mnPrice);
            }

            drlGia.DataSource = arrPrice;
            drlGia.DataValueField = "Name";
            drlGia.DataTextField = "Text";
            drlGia.DataBind();
        }
        catch (Exception ex)
        {
            LogEvent.LogToFile(ex.ToString());
        }
    }
    private void LoadDropDownListContry(RadComboBox dropDownList)
    {
        try
        {
            string query =
                string.Format(
                    "select * from TourRoute where IsActive='1'");
            DataTable data = db.ExecuteSQL(query);
            dropDownList.DataSource = data;
            dropDownList.DataValueField = "Name";
            dropDownList.DataTextField = "Name";
            dropDownList.DataBind();
        }
        catch (Exception ex)
        {
            LogEvent.LogToFile(ex.ToString());
        }
    }
    private void LoadDropDownListDay(RadComboBox dropDownList)
    {
        try
        {
            string query =
                string.Format(
                    "select distinct SoNgay from Tour");
            DataTable data = db.ExecuteSQL(query);
            dropDownList.DataSource = data;
            dropDownList.DataValueField = "SoNgay";
            dropDownList.DataTextField = "SoNgay";
            dropDownList.DataBind();
        }
        catch (Exception ex)
        {
            LogEvent.LogToFile(ex.ToString());
        }
    }

    protected void ibtSearch_Click(object sender, EventArgs e)
    {
        //Get data from views
        string diadiem = drlDiaDiem.SelectedValue;
        string loaihinh = drlLoaiHinh.SelectedValue;
        string songay = drlSoLuongNgay.SelectedValue;
        string khoanggia = drlGia.SelectedValue;
        string key = txtSearch.Value;

        //Get data from views
        Session["diadiem"] = null;
        Session["loaihinh"] = null;
        Session["songay"] = null;
        Session["khoanggia"] = null;
        Session["giabatdau"] = null;
        Session["giaketthuc"] = null;
        Session["key"] = null;
        //Begin: update sessison
        Session["diadiem"] = diadiem;
        Session["loaihinh"] = loaihinh;
        Session["songay"] = songay;
        Session["khoanggia"] = khoanggia;
        SplitGia(khoanggia);
        Session["key"] = key;
        //End: update sessison
        if (string.IsNullOrEmpty(diadiem)&&string.IsNullOrEmpty(key)&&string.IsNullOrEmpty(loaihinh)&&string.IsNullOrEmpty(songay)&&string.IsNullOrEmpty(khoanggia))
        {
            string alert = BicLanguage.CurrentLanguage == "vi"
                   ? "Bạn chưa chọn điều kiện  tìm kiếm"
                   : "You don't choose condition  to search";
            BicAjax.Alert(alert);
        }
        else
        {
            _link = string.Format("{0}{1}/searchTour.html", BicApplication.URLRoot, BicLanguage.CurrentLanguage);
            NavigateToSearchPage(_link);
        }
    }

   
    private void SplitGia(string khoanggia)
    {
        if (!string.IsNullOrEmpty(khoanggia))
        {
            string[] khoanggiaTour = khoanggia.Split(new char[] {'-'});
            if (khoanggiaTour.Length > 1)
            {

                if (BicConvert.ToInt32(BicString.Number(khoanggiaTour[1])) > BicConvert.ToInt32(BicString.Number(khoanggiaTour[0])))
                {
                    Session["giabatdau"] = BicString.Number(khoanggiaTour[0]);
                    Session["giaketthuc"] = BicString.Number(khoanggiaTour[1]);
                }
                else
                {
                    Session["giabatdau"] = null;
                    Session["giaketthuc"] = null;
                }
            }
        }
    }

    private string ChangePrice(string khoanggia)
    {
        string result = string.Empty;
        if (!string.IsNullOrEmpty(khoanggia))
        {
            string[] khoanggiaTour = khoanggia.Split(new char[] { '-' });
            if (khoanggiaTour.Length > 1)
            {
                if (BicConvert.ToInt32(BicString.Number(khoanggiaTour[1])) > BicConvert.ToInt32(BicString.Number(khoanggiaTour[0])))
                {
                    result = string.Format("{0} - {1}", BicString.ToStringNO(BicString.Number(khoanggiaTour[0])),
                        BicString.ToStringNO(BicString.Number(khoanggiaTour[1])));
                }
                else
                {
                   
                   
                }
            }
        }
        return result;
    }
    private void NavigateToSearchPage(string link)
    {
        BicHtml.Navigate(link);
    }
}