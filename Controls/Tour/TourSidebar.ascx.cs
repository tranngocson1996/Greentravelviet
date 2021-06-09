using System;
using BIC.Utils;
using BIC.WebControls;
using BIC.Biz;

public partial class Controls_Tour_TourSidebar : BaseUIControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var menuid = SetMenuUserId(43, 72);
        if (IsPostBack) return;
        var entity = MenuUserBiz.GetMenuUserByID(menuid);
        hiliTourCaption.MenuUserId = entity.MenuUserId;
        //hiliTourCaption.ImageUrl =BicLanguage.CurrentLanguage=="vi"?"/Styles/img/caption_tourkm_vi.png":"/Styles/img/caption_tourkm_en.png";
        subHiLiTour.MenuUserId = menuid.ToString();
        subHiLiTour.PageSize = 3;
        subHiLiTour.LoadData();

    }
    private int SetMenuUserId(int menuVi, int menuEn)
    {
        return BicLanguage.CurrentLanguage == "vi" ? menuVi : menuEn;
    }

    public string IsNone(string value)
    {
        return (string.IsNullOrEmpty(value) == true ? "none" : "");
    }
}