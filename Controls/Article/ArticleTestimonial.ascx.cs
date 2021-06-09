using System;
using BIC.WebControls;
using BIC.Utils;

public partial class Controls_Article_ArticleTestimonial : BaseUIControl
{
    public int MenuUserId { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            MenuUserId = mnCap.MenuUserId = BicLanguage.CurrentLanguage == "vi" ? 94 : 95;
            BindingArticleListView();
        }
    }
    // Hàm đọc danh sách tin tức theo MenuUserID    
    protected void BindingArticleListView()
    {
        ArticleList.MenuUserId = MenuUserId.ToString();
        ArticleList.Prefix = "";
        ArticleList.PageSize = 4;
        ArticleList.SelectFields = "ImageName,BriefDescription,CreatedDate";
        ArticleList.ExtensionLink = ExtensionLink.HTML;
        ArticleList.LoadData();
    }
}