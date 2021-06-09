using System;
using BIC.Utils;
using BIC.WebControls;

public partial class Controls_SideBar_SideBarTour : BaseUIControl
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