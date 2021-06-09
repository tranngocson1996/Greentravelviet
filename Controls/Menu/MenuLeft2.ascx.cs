using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;


public partial class Controls_Menu_MenuLeft2 : BaseUIControl
{
    public int MenuUserID { get; set; }
    public int TypeId { get; set; }
    public string QueryCondition { get; set; }
    public string EnableGetByParentId { get; set; }
    protected string urlname;
    protected void Page_Load(object sender, EventArgs e)
    {
        //var menuUserEntity = MenuUserBiz.GetMenuUserByUrlName(BicRouting.GetRequestString("menu_name"));
        //int menuUserId = 0;
        //if (menuUserEntity != null)
        //    menuUserId = menuUserEntity.MenuUserId;
        //var rootID = MenuUserBiz.GetRootIdByMenuUserID(menuUserId);
        if (IsPostBack) return;
        if (MenuUserID > 0)
            menuParent.ParentId = MenuUserID;
        if (TypeId > 0)
            menuParent.ModelMenuID = TypeId;
        //if (string.IsNullOrEmpty(QueryCondition))
        //    menuParent.QueryCondition = string.Format(" ParentID IN ({0})", QueryCondition);
        //if (EnableGetByParentId != "true")
        //    menuParent.EnableGetByParentId = BIC.WebControls.Boolean.False;
        //else
        //    menuParent.EnableGetByParentId = BIC.WebControls.Boolean.True;
        menuParent.Language = Language;
        menuParent.PageSize = 30;
        menuParent.LoadData();
        Visible = (menuParent.Items.Count > 0);
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
        menuChild.LoadData();

    }
    protected string getcap3(string idmenu, string parentid)
    {
        string chuoi = "";
        //if (parentid != "8")
        //{
        var bicData = new BicGetData { TableName = "MenuUser", PageSize = 200 };
        bicData.Sorting.Add(new SortingItem("Priority", false));
        bicData.Selecting.Add(MenuUserEntity.FIELD_MENUUSERID);
        bicData.Selecting.Add(MenuUserEntity.FIELD_NAME);
        bicData.Selecting.Add(MenuUserEntity.FIELD_IMAGEID);
        bicData.Selecting.Add(MenuUserEntity.FIELD_URL);
        bicData.Selecting.Add(MenuUserEntity.FIELD_URLNAME);
        bicData.Selecting.Add(MenuUserEntity.FIELD_PARENTID);
        bicData.Conditioning.Add(new ConditioningItem("LanguageKey", BicLanguage.CurrentLanguage, Operator.EQUAL,
                                                      CompareType.STRING));
        bicData.Conditioning.Add(new ConditioningItem(MenuUserEntity.FIELD_PARENTID, idmenu, Operator.EQUAL,
                                                      CompareType.STRING));
        DataTable data = bicData.GetPagingData();
        if (data.Rows.Count > 0)
        {
            var url = Request.Url.ToString();
            var url2 = url.ToString().Split('/');
            var menuett = MenuUserBiz.GetMenuUserByUrlName(BicRouting.GetRequestString("menu_name"));
            for (int i = 0; i < data.Rows.Count; i++)
            {
                if (url2.Length >= 4)
                {
                    var link =
                        _Getlink2(data.Rows[i]["URL"].ToString(), data.Rows[i]["UrlName"].ToString()).Replace(
                            "/", "");
                    if (url2[4].ToString() == link.ToString() ||
                        menuett.ParentID.ToString() == data.Rows[i]["MenuUserId"].ToString() ||
                        menuett.MenuUserId.ToString() == data.Rows[i]["MenuUserId"].ToString() || menuett.MenuUserId.ToString() == idmenu)
                    {
                        chuoi = "<ul id='nav" + idmenu + "' class='rpSlide2' style='' >";
                        break;
                    }
                    else
                    {
                        chuoi = "<ul id='nav" + idmenu + "' class='rpSlide2' style='display:none' >";
                    }
                }

            }
            if (string.IsNullOrEmpty(chuoi))
            {
                chuoi = "<ul id='nav" + idmenu + "' class='rpSlide2' style='display:none' >";
            }
            for (int i1 = 0; i1 < data.Rows.Count; i1++)
            {
                if (url2.Length > 4)
                {
                    var urlname = url2[4].ToString().Split('.');
                    chuoi += "<li class='item'><a href='" +
                             _Getlink(data.Rows[i1]["URL"].ToString(), data.Rows[i1]["UrlName"].ToString()) +
                             "' class='mnc1 ";
                    if (urlname[0].ToString() == data.Rows[i1]["UrlName"].ToString())
                        chuoi += "active'>" + data.Rows[i1]["Name"].ToString() + "</a></li>";
                    else if (menuett != null && menuett.ParentID.ToString() == data.Rows[i1]["MenuUserId"].ToString())
                        chuoi += "active'>" + data.Rows[i1]["Name"].ToString() + "</a></li>";
                    else chuoi += " '>" + data.Rows[i1]["Name"].ToString() + "</a></li>";
                }
                else
                {
                    chuoi += "<li class='item'><a href='" +
                            _Getlink(data.Rows[i1]["URL"].ToString(), data.Rows[i1]["UrlName"].ToString()) +
                            "' class='mnc1'>" + data.Rows[i1]["Name"].ToString() + "</a></li>";
                }
            }
            chuoi += "</ul>";
        }
        return chuoi;
    }
    private string Setlink(string url, string urlname)
    {
        string chuoi = "{0}{1}{2}";
        chuoi += url;
        chuoi = string.Format(chuoi, "", "", "", urlname, BicLanguage.CurrentLanguage);
        chuoi = chuoi.Replace("vi/", "");
        return chuoi;
    }
    public string _Getlink(string url, string name)
    {
        string link = "/{0}{1}{2}" + url;
        link = string.Format(link, "", "", "", name, BicLanguage.CurrentLanguage);
        return link;
    }
    public string _Getlink2(string url, string name)
    {
        string link = "{0}{1}{2}" + url;
        link = string.Format(link, "", "", "", name, "");
        return link;
    }
}