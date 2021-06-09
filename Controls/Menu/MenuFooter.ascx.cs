using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;


public partial class Controls_Menu_MenuFooter : BaseUIControl
{
    public int MenuUserID;
    public int TypeId { get; set; }
    protected string urlname;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            menuParent.ModelMenuID = 4;
            menuParent.Language = Language;
            menuParent.PageSize = 30;
            menuParent.LoadData();
        }
    }

    public bool CheckMenuPro(string menuId)
    {
        bool flag = false;
        var lang = BicLanguage.CurrentLanguage;
        urlname = BicRouting.GetRequestString("menu_name", "0");
        string link = Request.Path;
        List<MenuUserEntity> items = MenuUserBiz.GetNavigatePathById(MenuUserBiz.MenuUserGetIDByURLName(urlname));
        foreach (MenuUserEntity item in items)
        {
            if (item.MenuUserId.ToString() == menuId || item.ParentID.ToString() == menuId)
            {
                flag = true;
            }
        }
        return flag;
    }

    protected void MenuParentItemDataBound(object sender, ListViewItemEventArgs e)
    {
        var menuChild = (MenuListView)e.Item.FindControl("menuChild");
        if (menuChild == null) return;
        var dr = (DataRowView)e.Item.DataItem;
        menuChild.ParentId = BicConvert.ToInt32(dr["MenuUserId"]);
        menuChild.PageSize = 1000;
        menuChild.Language = BicLanguage.CurrentLanguage;
        menuChild.ItemDataBound += MenuChild_ItemDataBound;
        menuChild.LoadData();

    }
    private void MenuChild_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        MenuListView menu3 = e.Item.FindControl("menu3") as MenuListView;
        if (menu3 == null) return;
        var dr = (DataRowView)e.Item.DataItem;
        menu3.ParentId = BicConvert.ToInt32(dr["MenuUserId"]);
        menu3.PageSize = 1000;
        menu3.Language = BicLanguage.CurrentLanguage;
        //menu3.ItemDataBound += MenuChild_ItemDataBound;
        menu3.LoadData();
        // throw new NotImplementedException();
    }
    public bool IsParent(string parentID)
    {
        DataHelper dh = new DataHelper();
        string sql = "SELECT COUNT(ParentID) FROM MenuUser WHERE ParentID=N'" + parentID + "' AND IsActive = 1";
        DataTable data = dh.GetTable(sql, false);
        return BicConvert.ToInt32(data.Rows[0][0].ToString()) > 0 ? true : false;
    }
}