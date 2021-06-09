using System;
using BIC.Utils;
using BIC.Entity;
using BIC.WebControls;
using BIC.Biz;

public partial class Controls_Tour_TourListing : BaseUIControl
{
    protected int MenuUserId { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        string urlName = BicRouting.GetRequestString("menu_name", "");
        if (urlName == string.Empty) return;

        MenuUserEntity menu = MenuUserBiz.GetMenuUserByUrlName(urlName);
        if (menu != null)
        {
            MenuUserId = menu.MenuUserId;
            LoadData();
        }
    }
    protected void LoadData()
    {
        CaptionListing.MenuUserId = MenuUserId;
        TourListing.MenuUserId = MenuUserId.ToString();
        TourListing.PageSize = 12;
        TourListing.LoadData();

        pager.PageSize = TourListing.PageSize;
        pager.PageIndex = TourListing.PageIndex;
        pager.TotalItems = TourListing.TotalItem;
    }
    protected void pager_PageIndexChanged(object sender, PagerUIEventArgs e)
    {
        TourListing.PageIndex = pager.PageIndex = e.NewPageIndex;
        TourListing.LoadData();
    }
    protected void ddlFilter_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindingTourListView();
    }

    protected void BindingTourListView()
    {
        string MenuUserID = string.Empty;
        string condition = string.Empty;
        //ProductList.QueryCondition = "";
        //Lọc theo khoảng giá
        //if (!string.IsNullOrEmpty(hdPrice.Value))
        //    condition += string.Format("(CONVERT (int,REPLACE((CASE WHEN Price = '' THEN OldPrice ELSE Price END ),',','')) BETWEEN {0} AND {1})", lblPriceStart.Text.Replace(",", ""), lblPriceEnd.Text.Replace(",", ""));
        //switch (ddlFilter.SelectedValue)
        //{
        //    case "1":
        //        TourListing.OrderBy = "IsNew DESC, ModifiedDate DESC";
        //        break;
        //    case "2":
        //        condition += string.IsNullOrEmpty(condition) ? "Mota2 != ''" : " AND Mota2 != ''";
        //        TourListing.OrderBy = "IsNew DESC, ModifiedDate DESC";
        //        break;
        //    case "3":
        //        TourListing.OrderBy = "CONVERT (int,REPLACE((CASE WHEN Mota2 = '' THEN GiaHienThi ELSE Mota2 END ),',','')) DESC";
        //        break;
        //    case "4":
        //        TourListing.OrderBy = "CONVERT (int,REPLACE((CASE WHEN Mota2 = '' THEN GiaHienThi ELSE Mota2 END ),',',''))";
        //        break;
        //    default:
        //        TourListing.OrderBy = "ModifiedDate DESC";
        //        break;
        //}
        //if (!string.IsNullOrEmpty(hdDesign.Value))
        //    MenuUserID += string.Format(",{0}", hdDesign.Value);
        //if (!string.IsNullOrEmpty(hdQuality.Value))
        //    MenuUserID += string.Format(",{0}", hdQuality.Value);
        //if (!string.IsNullOrEmpty(hdMadeIn.Value))
        //    MenuUserID += string.Format(",{0}", hdMadeIn.Value);
        //if (!string.IsNullOrEmpty(hdBrand.Value))
        //    MenuUserID += hdBrand.Value;

        //if (!string.IsNullOrEmpty(MenuUserID))
        //{
        //    var arrayMenuUserId = BicString.SplitComma(MenuUserID);
        //    var queryMenuUserId = arrayMenuUserId.Aggregate(string.Empty, (current, s) => current + string.Format("{1} MenuUserID LIKE '%,{0},%'", s, current == string.Empty ? "" : " AND "));
        //    condition += string.Format(" {1} ({0})", queryMenuUserId, string.IsNullOrEmpty(condition) ? "" : "AND");
        //}
        //TourListing.QueryCondition = condition;
        //TourListing.MenuUserId = MenuUserID;
        //TourListing.PageSize = 12;
        //TourListing.Prefix = "";
        //TourListing.LoadData();

    }

    public string IsNone(string value)
    {
        return (string.IsNullOrEmpty(value) ? "none" : "");
    }

}