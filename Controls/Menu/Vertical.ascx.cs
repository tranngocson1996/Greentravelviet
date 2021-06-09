using System;
using System.Data;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Controls_Menu_Vertical : BIC.WebControls.BaseUIControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var dt = new DataHelper();
            var query = string.Format("select * from MenuUser where ( TypeID = 1 OR TypeID = 2 OR TypeID=8) AND ParentID is null AND IsActive = 1 AND LanguageKey = '{0}' Order by Priority", BicLanguage.CurrentLanguage);
            var key="Menu_Menu_Vertical"+query;
            menuParent.DataSource = Common.GetDataCacheTable(key, query, dt);
            menuParent.DataBind();
        }
    }
    
    protected string settt(string MenuID)
    {
        string kq = "nochild";
        var dt = new DataHelper();
        string query = string.Format("select menuUserID,ParentID from MenuUser where ParentID = {0} AND IsActive = 1",
            MenuID);
        var key = "Menu_Menu_Vertical" + query;
        var data = Common.GetDataCacheTable(key, query, dt);
        if (data.Rows.Count > 0)
            kq = "child";
        return kq;
    }
    protected void MenuParentItemDataBound(object sender, ListViewItemEventArgs e)
    {
        var dr = (DataRowView)e.Item.DataItem;
        var menuChild = (MenuListView)e.Item.FindControl("menuChild");
        menuChild.ParentId = BicConvert.ToInt32(dr["MenuUserId"]);
        menuChild.PageSize = 1000;
        menuChild.Language = BicLanguage.CurrentLanguage;
        menuChild.LoadData();
    }
    protected string getcap3(string idmenu, string parentid)
    {
        string chuoi = "";
        var bicData = new BicGetData { TableName = "MenuUser", PageSize = 200 };
        bicData.Sorting.Add(new SortingItem("Priority", false));
        bicData.Selecting.Add(MenuUserEntity.FIELD_MENUUSERID);
        bicData.Selecting.Add(MenuUserEntity.FIELD_NAME);
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
            chuoi = "<ul id='nav" + idmenu + "' class='rpSlide2' style='' >";
            for (int i1 = 0; i1 < data.Rows.Count; i1++)
            {

                chuoi += "<li class='item'><a href='" +
                        _Getlink(data.Rows[i1]["URL"].ToString(), data.Rows[i1]["UrlName"].ToString()) +
                        "' class='mnc1'>" + data.Rows[i1]["Name"].ToString() + "</a></li>";
            }
            chuoi += "</ul>";
        }
        return chuoi;
    }
    public string _Getlink(string url, string name)
    {
        if (url.Contains("{4}/{3}"))
        {
            string link = "/{0}{1}{2}" + url;
            link = string.Format(link, "", "", "", name, BicLanguage.CurrentLanguage);
            return link;
        }
        else
        {
            return url;
        }
    }
    public string _Getlink2(string url, string name)
    {
        string link = "{0}{1}{2}" + url;
        link = string.Format(link, "", "", "", name, "");
        return link;
    }
}