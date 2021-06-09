using System;
using BIC.Utils;
using BIC.WebControls;
using System.Web.UI.WebControls;
using System.Data;

public partial class Controls_Tour_TourTabHome : BaseUIControl
{
    public int MenuUserId { get; set; }
    public int PageSize { get; set; }
    public string cssClass { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            mnCap.MenuUserId = MenuUserId = BicLanguage.CurrentLanguage == "vi" ? 11 : 11;
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
        var lvArticleTab = (TourListViewPager)e.Item.FindControl("lvArticleTab");
        if (lvArticleTab == null) return;
        var dr = (DataRowView)e.Item.DataItem;

        lvArticleTab.MenuUserId = BicConvert.ToInt32(dr["MenuUserId"]) == 0 ? MenuUserId.ToString() : BicConvert.ToInt32(dr["MenuUserId"]).ToString();
        lvArticleTab.Prefix = "";
        lvArticleTab.PageSize = 5;
        lvArticleTab.LoadData();

    }

    public string ToNo(string price)
    {
        try
        {
            if (string.IsNullOrEmpty(price))
            {
                cssClass = "hidden";
                return "";
            }
            else
            {
                return BicString.ToStringNO(price);
            }
        }
        catch (Exception ex)
        {
            return price;
        }
    }



}