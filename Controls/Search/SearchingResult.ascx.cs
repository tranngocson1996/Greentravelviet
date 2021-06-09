using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Controls_Search_SearchingResult : BaseUIControl
{
    //_code la ma san pham
    //_type la chung loai san pham

    public string Keyword, Code, Type, MenuUserId;
    public int Result;

    protected void Page_Load(object sender, EventArgs e)
    {
        Keyword = BicRouting.GetRequestString("k", string.Empty);
        MenuUserId = BicRouting.GetRequestString("t", string.Empty);

        searching.PageSize = pager.PageSize = 10;
        if (!IsPostBack)
        {
       
            if (!string.IsNullOrEmpty(MenuUserId))
            {
                searching.MenuUserId = MenuUserId;
            }
            if (!string.IsNullOrEmpty(Keyword))
            {
                searching.QueryCondition = string.Format("(LanguageKey = '{0}' AND Title Like N'%{1}%' OR  BriefDescription Like N'%{1}%') AND TypeOfControl != '3' ", BicLanguage.CurrentLanguage, Keyword);
            }
            searching.LoadData();
            Result = searching.TotalItem;
            pager.Visible = searching.TotalItem >= pager.PageSize;
        }
        pager.TotalItems = searching.TotalItem;
        
    }

    protected void pager_PageIndexChanged(object sender, PagerUIEventArgs e)
    {
        searching.PageIndex = pager.PageIndex = e.NewPageIndex;
        searching.LoadData();
        Result = searching.TotalItem;
    }

    protected void searchingArticle_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            var dr = (DataRowView)e.Item.DataItem;
            if (dr != null)
            {
                var menuCaption = (HyperLink)e.Item.FindControl("mnuSearch");
                var menuUserEntity =
                    MenuUserBiz.GetByIdShort(BicConvert.ToInt32(BicConvert.ToInt32(dr["MainMenuUserID"])));
                if (menuUserEntity == null) return;
                menuCaption.NavigateUrl = menuUserEntity.URL;
                menuCaption.Text = BicString.HighlightKeyWords(menuUserEntity.Name, Keyword, "highlight", string.Empty);
                menuCaption.Target = menuUserEntity.Target;
            }

        }
    }

   
}