using System;
using System.Web.UI;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;

public partial class Controls_Article_Tools_BottomToolbar : UserControl
{
    public int ArticleID { get; set; }
    public string Type { get; set; }
    public int ViewCount;
    public DateTime ModifiedDate;

    protected void Page_Load(object sender, EventArgs e)
    {
        if(IsPostBack) return;
        ltlModifiedDate.Text = string.Format(BicResource.GetValue("LastUpdate"), BicDateTime.ToShortDateTime(ModifiedDate));//Đọc cấu trúc từ file Resource dạng "Cập nhật {0}"
        ltlViewCount.Text = ArticleBiz.GetArticleByID(BicRouting.GetRequestString("id", 0)).ViewCount.ToString();
    }
}