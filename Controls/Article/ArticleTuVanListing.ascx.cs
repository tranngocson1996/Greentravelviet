using System;
using BIC.Biz;
using BIC.Utils;
using BIC.WebControls;

public partial class Controls_Article_ArticleTuVanListing : BaseUIControl
{
    private int MenuUserId;
    private string _name;
    protected void Page_Load(object sender, EventArgs e)
    {
        _name = BicRouting.GetRequestString("menu_name", "0");
        var menuEtt = MenuUserBiz.GetMenuUserByUrlName(_name);
        if (menuEtt != null)
        {
            MenuUserId = mnCap.MenuUserId = menuEtt.MenuUserId;
            ltrDesc.Text = !string.IsNullOrEmpty(BicString.StripHtml(menuEtt.Description)) ? string.Format("<div class=\"desc\">{0}</div>", menuEtt.Description) : "";
            if (!IsPostBack)
            {
                BindingArticleListView();
            }
        }
        pager.PageSize = ArticleList.PageSize;
        pager.PageIndex = ArticleList.PageIndex;
        pager.TotalItems = ArticleList.TotalItem;
    }


    // Hàm đọc danh sách tin tức theo MenuUserID    
    protected void BindingArticleListView()
    {
        ArticleList.MenuUserId = MenuUserId.ToString();
        ArticleList.LoadData();
    }

    protected void pager_PageIndexChanged(object sender, PagerUIEventArgs e)
    {
        ArticleList.MenuUserId = MenuUserId.ToString();
        ArticleList.PageIndex = pager.PageIndex = e.NewPageIndex;
        ArticleList.LoadData();
    }
}