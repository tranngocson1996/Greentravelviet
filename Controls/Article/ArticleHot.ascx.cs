using System;
using BIC.WebControls;
using BIC.Utils;

public partial class Controls_Article_ArticleHot : BaseUIControl
{
    public int MenuUserId { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            mnCap.MenuUserId = MenuUserId;
            if (MenuUserId == 0)
                MenuUserId = mnCap.MenuUserId = BicLanguage.CurrentLanguage == "vi" ? 6 : 6;

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