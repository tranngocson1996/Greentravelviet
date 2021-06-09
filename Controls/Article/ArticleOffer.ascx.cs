using System;
using BIC.WebControls;
using BIC.Utils;

public partial class Controls_Article_ArticleOffer : BaseUIControl
{
    public int MenuUserId { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            MenuUserId = mnCap.MenuUserId = BicLanguage.CurrentLanguage == "vi" ? 21 : 76;
            BindingArticleListView();
        }
    }
    // Hàm đọc danh sách tin tức theo MenuUserID    
    protected void BindingArticleListView()
    {
        ArticleList.MenuUserId = MenuUserId.ToString();
        ArticleList.Prefix = "";
        ArticleList.PageSize = 5;
        ArticleList.SelectFields = "ImageName,BriefDescription";
        ArticleList.ExtensionLink = ExtensionLink.HTML;
        ArticleList.LoadData();
    }
}