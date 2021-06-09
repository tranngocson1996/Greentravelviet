using System;
using BIC.WebControls;
using BIC.Utils;

public partial class Controls_SideBar_SideBarArticle : BaseUIControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindingArticleListView();
        }
        ucMenuLeft2.MenuUserID = BicLanguage.CurrentLanguage == "vi" ? 42 : 65;
    }
    // Hàm đọc danh sách tin tức theo MenuUserID    
    protected void BindingArticleListView()
    {

    }
}