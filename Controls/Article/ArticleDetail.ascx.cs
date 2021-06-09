using System;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;
using System.Globalization;

public partial class Controls_Article_ArticleDetail : BaseUIControl
{
    protected int Id;
    protected string MenuUserId;
    public string SendMailUrl;
    public string ModifidedDate { get; set; }
    public string View { get; set; }
    public string ImageShare = string.Empty;
    public string Title = string.Empty;
    public string UrlShare = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        string name = BicRouting.GetRequestString("menu_name");     

        MenuUserEntity menuEtt = MenuUserBiz.GetMenuUserByUrlName(name);
        if (menuEtt != null)
        {
            MenuUserId = menuEtt.MenuUserId.ToString();
            mnCap.MenuUserId = menuEtt.MenuUserId;
        }
        if (IsPostBack) return;
        BindingArticleDetail();
    }



    /// <summary>
    /// Nạp dữ liệu lên các điều khiển của trang chi tiết
    /// </summary>
    protected void BindingArticleDetail()
    {
        string title = BicRouting.GetRequestString("name");//Lấy về ID của bài viết chi tiết
        ArticleEntity articleEntity = ArticleBiz.GetArticleByUrlName(title);
        if (articleEntity != null)
        {
            Id = articleEntity.ArticleID;
            articleReference.MenuUserId = MenuUserId;
            articleReference.ArticleId = Id;
            ModifidedDate = articleEntity.ModifiedDate.ToShortDateString();
            View = ltrview.Text = articleEntity.ViewCount.ToString();
            Title = articleEntity.Title;
            ImageShare = Common.GetSiteUrl() + BicImage.GetPathImage(articleEntity.ImageID);
            UrlShare = Request.Url.ToString();

            ltlTitle.Text = articleEntity.Title;
            ltlDescription.Text = articleEntity.Body;
            ltrDate.Text = articleEntity.ModifiedDate.ToShortDateString();
            SendMailUrl = string.Format("{0}{1}/ShareByEmail.html?target={2}", BicApplication.URLRoot, Language, Request.Url);
        }
        else
            Visible = false;
    }
    private string CovertDate(DateTime date)
    {
        var str1 = BicConvert.ToDateTime(date.ToString()).ToString("dd", CultureInfo.CreateSpecificCulture("en-US"));
        var str2 = BicConvert.ToDateTime(date.ToString()).ToString("MMM", CultureInfo.CreateSpecificCulture("en-US"));
        var str = "<b>" + str1 + "</b>" + str2;
        return str;
    }
    public string UrlEncode(string url)
    {
        return System.Web.HttpUtility.UrlEncode(url);
    }
}