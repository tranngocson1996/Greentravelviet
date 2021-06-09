using System;
using BIC.WebControls;
using BIC.Utils;

public partial class Controls_Article_ArticleListingHome : BaseUIControl
{
    public int MenuUserId { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (MenuUserId == 0)
                MenuUserId = BicLanguage.CurrentLanguage == "vi" ? 46 : 62;
            BindingArticleListView();
        }
    }
    // Hàm đọc danh sách tin tức theo MenuUserID    
    protected void BindingArticleListView()
    {
        ArticleList.MenuUserId = MenuUserId.ToString();
        ArticleList.Prefix = "";
        ArticleList.PageSize = 10;
        ArticleList.ExtensionLink = ExtensionLink.HTML;
        ArticleList.LoadData();
    }
}