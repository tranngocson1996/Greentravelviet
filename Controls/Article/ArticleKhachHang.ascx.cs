using System;
using BIC.Biz;
using BIC.Utils;
using BIC.WebControls;
using System.Globalization;

public partial class Controls_Article_ArticleKhachHang : BaseUIControl
{
    private int MenuUserId;
    private string _name;
    protected void Page_Load(object sender, EventArgs e)
    {
        _name = BicRouting.GetRequestString("menu_name", "0");
        var menuEtt = MenuUserBiz.GetMenuUserByUrlName(_name);
        if (menuEtt != null)
        {
            MenuUserId = menuEtt.MenuUserId = BicLanguage.CurrentLanguage == "vi" ? 19 : 63;
            if (!IsPostBack)
            {
                BindingArticleListView();
            }
        }
    }


    // Hàm đọc danh sách tin tức theo MenuUserID    
    protected void BindingArticleListView()
    {
        ArticleList.MenuUserId = MenuUserId.ToString();
        ArticleList.LoadData();
    }

}