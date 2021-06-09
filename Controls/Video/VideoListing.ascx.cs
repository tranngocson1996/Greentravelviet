using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Controls_Gallery_GalleryListing : BaseUIControl
{
    private int _menuUserId;
    private string _name;
    public string VideoList { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            _name = BicRouting.GetRequestString("menu_name", string.Empty);
            if (string.IsNullOrEmpty(_name)) return;
            var menuEtt = MenuUserBiz.GetMenuUserByUrlName(_name);
            if (menuEtt != null)
            {
                _menuUserId = menuEtt.MenuUserId;
                BindingArticleListView();
                VideoList = GetVideoList(_menuUserId.ToString());
            }
        }
    }

    protected void BindingArticleListView()
    {
        ProductList.MenuUserId = _menuUserId.ToString();
        ProductList.PageSize = 12;
        ProductList.PageIndex = pager.PageIndex = 0;
        ProductList.LoadData();
        pager.PageSize = ProductList.PageSize;
        pager.PageIndex = ProductList.PageIndex;
        pager.TotalItems = ProductList.TotalItem;
    }
    protected string GetVideoList(string menuUserId)
    {
        var sb = new StringBuilder();

        var bicData = new BicGetData
        {
            TableName = "Article",
            PageSize = 12
        };

        string imgPath = string.Empty;
        bicData.TableName = "Article";
        bicData.Sorting.Add(new SortingItem("Priority", false));
        bicData.Selecting.Add(ArticleEntity.FIELD_LINK);
        bicData.Selecting.Add(ArticleEntity.FIELD_IMAGEID);
        bicData.Selecting.Add(ArticleEntity.FIELD_TITLE);
        bicData.Selecting.Add(ArticleEntity.FIELD_BRIEFDESCRIPTION);
        bicData.Conditioning.Add(new ConditioningItem(ArticleEntity.FIELD_ISACTIVE, "1", Operator.EQUAL, CompareType.NUMERIC));
        bicData.Conditioning.Add(new ConditioningItem(ArticleEntity.FIELD_MENUUSERID, "N'%" + menuUserId + "%'", Operator.LIKE, CompareType.NUMERIC));
        bicData.Conditioning.Add(new ConditioningItem(ArticleEntity.FIELD_LANGUAGEKEY, BicLanguage.CurrentLanguage, Operator.EQUAL, CompareType.STRING));
        bicData.Conditioning.Add(new ConditioningItem(ArticleEntity.FIELD_TYPEOFCONTROL, "3", Operator.EQUAL, CompareType.STRING));
        DataTable data = bicData.GetAllData();

        if (data.Rows.Count > 0)
        {
            for (int i = 0; i < data.Rows.Count; i++)
            {
                imgPath = BicImage.GetPathImage(BicConvert.ToInt32(data.Rows[i]["ImageID"].ToString()));
                sb.Append("{");
                sb.Append(string.Format("file: \"{0}\",", data.Rows[i]["Link"].ToString()));
                sb.Append(string.Format("image: \"{0}\",", imgPath));
                sb.Append(string.Format("title: \"{0}\"", data.Rows[i]["Title"].ToString()));
                if (i == data.Rows.Count - 1)
                    sb.Append("}");
                else
                    sb.Append("},");                
            }
        }
        return sb.ToString();
    }
    protected void pager_PageIndexChanged(object sender, PagerUIEventArgs e)
    {
        ProductList.PageIndex = pager.PageIndex = e.NewPageIndex;
        ProductList.LoadData();
    }
}