using System;
using System.Activities.Statements;
using System.Web.UI.WebControls;
using BIC.Utils;
using System.Data;
using BIC.Entity;
using BIC.WebControls;
using BIC.Biz;

public partial class Controls_Tour_TourSearch : BIC.WebControls.BaseUIControl
{

    public int ToueHotelid;
    public int TabId;
    private string _condition = string.Empty;
    public int result { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        _condition = "";

        //Session["diadiem"] = null;
        //Session["loaihinh"] = null;
        //Session["songay"] = null;
        //Session["khoanggia"] = null;
        //Session["key"] = null;
        //Session["giabatdau"] = null;
        //Session["giaketthuc"] = null;

        if (Session["diadiem"] != null)
        {
            if (Session["diadiem"].ToString() != "0" && !string.IsNullOrEmpty(Session["diadiem"].ToString()))
            {
                _condition += " AND LichTrinhHienThi like N'%" + Session["diadiem"].ToString() + "%' ";
            }
            string diadiem = Session["diadiem"].ToString();
        }
        if (Session["loaihinh"] != null)
        {
            if (Session["loaihinh"].ToString() != "0"&& !string.IsNullOrEmpty(Session["loaihinh"].ToString()))
            {
                _condition += " AND ChiTietGia = '" + Session["loaihinh"].ToString() + "' ";
            }
        }
        if (Session["songay"] != null)
        {
            if (Session["songay"].ToString() != "0" && !string.IsNullOrEmpty(Session["songay"].ToString()))
            { _condition +=  " AND SoNgay = '" + Session["songay"].ToString() + "' "; }
        }
        if(Session["khoanggia"] != null)
        {
            if (Session["khoanggia"].ToString() != "0" && !string.IsNullOrEmpty(Session["khoanggia"].ToString()))
            {
                if (Session["giabatdau"] != null && Session["giaketthuc"] != null)
                {
                    if (Session["giabatdau"].ToString() != "0" && Session["giaketthuc"].ToString() != "0")
                    {
                        _condition += " AND GiaHienThi >=" + BicConvert.ToInt32(Session["giabatdau"].ToString()) +
                                      " AND GiaHienThi <=" + BicConvert.ToInt32(Session["giaketthuc"].ToString());
                    }
                }
            }
        }
        if (Session["key"] != null)
        {
            if (Session["key"].ToString() != "0" && !string.IsNullOrEmpty(Session["key"].ToString()))
            {
                _condition +=
                    string.Format(
                        " AND (TenTour like N'%{0}%' OR GioiThieuChung like N'%{1}%'  OR GioiThieuChiTiet like N'%{2}%' OR Mota3 like N'%{3}%')",
                        Session["key"].ToString(), Session["key"].ToString(), Session["key"].ToString(),
                        Session["key"].ToString());
            }
        }
       
        
        lvpTourListing.PageSize = pager.PageSize = 12;
        lvpTourListing.QueryCondition = string.Format("LanguageKey = '{0}' {1} ", BicLanguage.CurrentLanguage, _condition);
        lvpTourListing.LoadData();
        result = lvpTourListing.TotalItem;
        pager.TotalItems = lvpTourListing.TotalItem;
        string query = string.Format("LanguageKey = '{0}' {1} ", BicLanguage.CurrentLanguage, _condition);
    }
   
    protected void pager_PageIndexChanged(object sender, PagerUIEventArgs e)
    {
        lvpTourListing.PageIndex = pager.PageIndex = e.NewPageIndex;
        lvpTourListing.LoadData();
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