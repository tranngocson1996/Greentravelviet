using System;
using BIC.Utils;
using BIC.WebControls;

public partial class Controls_Article_Tools_TopToolbar : BaseUIControl
{
    public int ArticleID { get; set; }

    public string Type { get; set; }

    public string SendMailUrl { get; set; }
    public int ViewCount;
    public DateTime ModifiedDate;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        //ltlModifiedDate.Text = string.Format(BicResource.GetValue("LastUpdate"), BicDateTime.ToShortDateTime(ModifiedDate));//Đọc cấu trúc từ file Resource dạng "Cập nhật {0}"
        //ltlViewCount.Text = BicResource.GetValue("ViewCount") + ViewCount;//Đọc cấu trúc từ file Resource dạng "Lượt xem {0}"
        //viewcount.Visible = BicXML.ToString("DisplayViewCountArticle", string.Format("Config_{0}", BicLanguage.CurrentLanguage)).Equals("1");
        SendMailUrl = string.Format("{0}{1}/ShareByEmail.html?target={2}", BicApplication.URLRoot, Language, Request.Url);
        //ArticleID = BicRouting.GetRequestString("id", 0);
    }
}