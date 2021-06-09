using System;
using System.Collections.Generic;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Controls_Navigate_NavigatePath : BaseUIControl
{   
    public string UrlName { get; set; }
    public bool VisibleHomePage { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        UrlName = BicRouting.GetRequestString("menu_name");
        if (!IsPostBack)
            LoadData();
    }

    protected void LoadData()
    {
        VisibleHomePage = true;
        string result = string.Empty;
        string liItem = string.Empty;
        string breakcumb = @"<ol itemscope itemtype='http://schema.org/BreadcrumbList'>{0}</ol>";
        string li = @" <li itemprop='itemListElement' itemscope  itemtype='http://schema.org/ListItem'>  {0} </li>";           
              
       
        List<MenuUserEntity> items = MenuUserBiz.GetNavigatePathById(MenuUserBiz.MenuUserGetIDByURLName(UrlName));
        if (items == null) return;
        int i = 1;
        int position = 1;

        if (VisibleHomePage)
        {
            string temp = string.Format("<a class='home' itemprop='item'  href='{0}{1}/home.h.html'><span itemprop='name'>{2}&nbsp;>&nbsp;</span></a><meta itemprop='position' content='{3}' />  ", BicApplication.URLRoot, Language, BicLanguage.CurrentLanguage == "vi" ? "Trang chủ" : "Home", position);
            liItem += string.Format(li, temp);
            position++;
        }
        foreach (MenuUserEntity item in items)
        {            
            if (i == 1)
            {
                if (i == items.Count)
                {
                    string temp =
                        string.Format("<a href='{0}' itemprop='item'   target='{2}' class='arr firt' id='menu{3}'><span itemprop='name'>{1}<span></a><meta itemprop='position' content='{4}' /></a>",
                            item.URL, item.Name.Replace("</br>", ""), item.Target, item.MenuUserId, position);
                    liItem += string.Format(li, temp);
                }
                else
                {
                    string temp =
                        string.Format("<a href='{0}' itemprop='item'  target='{2}' class='arr firt' id='menu{3}'><span itemprop='name'>{1}&nbsp; >&nbsp; <span></a><meta itemprop='position' content='{4}' /></a>", item.URL, item.Name.Replace("</br>", ""), item.Target, item.Target, item.MenuUserId, position);
                    liItem += string.Format(li, temp);
                }             
            }
            else
            {
                if (i == items.Count)
                {
                    string temp =
                        string.Format("<a href='{0}' itemprop='item' class='arr' target='{2}'><span itemprop='name'>{1} <span></a><meta itemprop='position' content='{3}' /></a>", item.URL,
                            item.Name.Replace("</br>", ""), item.Target,position);
                    liItem += string.Format(li, temp);
                }
                else
                {
                    string temp =
                     string.Format("<a href='{0}'  itemprop='item' class='arr' target='{2}'><span itemprop='name'>{1} &nbsp;> &nbsp;<span></a><meta itemprop='position' content='{3}' /></a>", item.URL, item.Name.Replace("</br>", ""), item.Target, position);
                    liItem += string.Format(li, temp);
                }
            }
            i++;
            position++;
        }
        result = string.Format(breakcumb, liItem);
        lblNavigatePath.Text = result;
    }
}