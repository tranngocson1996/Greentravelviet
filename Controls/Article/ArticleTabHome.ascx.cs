using System;
using BIC.Utils;
using BIC.WebControls;
using System.Web.UI.WebControls;
using System.Data;
using BIC.Biz;

public partial class Controls_Article_ArticleTabHome : BaseUIControl
{
    public int MenuUserId { get; set; }
    public int PageSize { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (MenuUserId > 0)
                mnCap.MenuUserId = MenuUserId;
            else
                mnCap.MenuUserId = BicLanguage.CurrentLanguage == "vi" ? 41 : 41;

            BindingArticleListView();
        }
    }
    protected void BindingArticleListView()
    {
        menuTab.ParentId = MenuUserId;
        menuTab.PageSize = 30;
        menuTab.LoadData();

        menuTabContent.ParentId = MenuUserId;
        menuTabContent.PageSize = 30;
        menuTabContent.LoadData();

        if (menuTabContent.Items.Count < 1)
        {
            menuTabContent.MenuUserId = MenuUserId;
            //menuTabContent.ModelMenuID = 1;
            //menuTabContent.QueryCondition = string.Format(" MenuUserID = {0}", MenuUserId);
            menuTabContent.PageSize = 30;
            menuTabContent.LoadData();
        }
    }
    protected void menuTabContent_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        var lvArticleTab = (ArticleListViewTop)e.Item.FindControl("lvArticleTab");
        if (lvArticleTab == null) return;
        var dr = (DataRowView)e.Item.DataItem;

        lvArticleTab.MenuUserId = BicConvert.ToInt32(dr["MenuUserId"]) == 0 ? MenuUserId.ToString() : BicConvert.ToInt32(dr["MenuUserId"]).ToString();
        lvArticleTab.Prefix = "";
        lvArticleTab.PageSize = PageSize;
        lvArticleTab.LoadData();

    }

}