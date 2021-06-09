using System;
using BIC.Biz;
using BIC.Entity;
using BIC.Handler;
using BIC.Utils;
using BIC.WebControls;

public partial class Controls_Article_ArticleVideoDetail : BaseUIControl
{
    protected int Id;
    protected string MenuUserId = string.Empty;
    public string ScriptRunVideo = string.Empty;
    protected string UrlName;
    protected void Page_Load(object sender, EventArgs e)
    {
        Id = BicRouting.GetRequestString("id", 0);//Lấy về ID của bài viết chi tiết
        MenuUserId = BicRouting.GetRequestString("lv", "0");//Lấy về MenuUserId của bài viết chi tiết
        UrlName = BicRouting.GetRequestString("name");
        if (IsPostBack) return;//Nếu là Refresh trang sẽ không chạy đoạn code bên dưới
        BindingArticleDetail();
        
        
        LoadVideo();

    }

    /// <summary>
    /// Nạp dữ liệu lên các điều khiển của trang chi tiết
    /// </summary>
    protected void BindingArticleDetail()
    {
        //ArticleBiz.UpdateArticleViewCount(Id);//Tăng lượt xem lên 1 giá trị
        ArticleEntity articleEntity = ArticleBiz.GetArticleByUrlName(UrlName);
        if (articleEntity != null)
        {
            //Set dữ liệu Trang
            ltvideobody.Text = articleEntity.Body;
            //Page.Title = string.IsNullOrEmpty(Convert.ToString(articleEntity.PageTitle)) ? string.Format("{1} - {0}", articleEntity.Title, MenuUserBiz.GetNameById(BicConvert.ToInt32(MenuUserId))) : articleEntity.PageTitle;
            //Page.MetaKeywords = string.Format("{0} - {1}", articleEntity.Title, MenuUserBiz.GetNameById(BicConvert.ToInt32(MenuUserId)));
            //Page.MetaDescription = articleEntity.Title + " - " + articleEntity.BriefDescription;
            //----------
            ltlTitle.Text = articleEntity.Title;
            ltlTitle.ToolTip = articleEntity.Title;
            ArticleVideoReference._MenuUserId = BicConvert.ToInt32(articleEntity.MainMenuUserID);//Thiết lập MenuUserId cho Control tin liên quan và tiêu đề
            ArticleVideoReference._ArticleId = articleEntity.ArticleID; //Thiết lập ArticleId cho Control tin liên quan, để hệ thống đọc các bài viết cũ hơn bài viết có Id này.
            //Set dữ liệu TopToolbar

        }
        else
            Visible = false;
    }

    protected void LoadVideo()
    {
        ArticleEntity articleEntity = ArticleBiz.GetArticleByUrlName(UrlName);
        if (articleEntity!=null && articleEntity.VideoID != null)
        {
            VideoEntity video = VideoBiz.GetVideoByID(articleEntity.VideoID);
            if (video != null)
            {
               
                string videopath = video.Url == (string.Empty)
                                       ? BicApplication.URLPath("FileUpload/Medias") + video.Path
                                       : video.Url;
                //string videopath = "/FileUpload/Medias/NghiNgo.flv";
      
                ScriptRunVideo = "RunVideoDetail('" + videopath + "', '" +
                                 BicImage.GetPathImage(video.ImageID) + "','" + video.Name + "');";
            }
        }
       
    }
}