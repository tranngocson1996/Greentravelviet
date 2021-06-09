using System;
using System.Web.UI;
using BIC.Utils;

public partial class Controls_Article_Tools_BottomToolbar : UserControl
{
    public int ArticleID { get; set; }
    public string Type { get; set; }
    public int ViewCount;
    public DateTime ModifiedDate;
    public string Review { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if(IsPostBack) return;
        var menu = BicRouting.GetRequestString("menu_name");
        btnGoBack.NavigateUrl = Common.GetSiteUrl() + "/" + BicLanguage.CurrentLanguage + "/" + menu + ".nl.html";
        ltlModifiedDate.Text = string.Format(BicResource.GetValue("LastUpdate"), BicDateTime.ToShortDateTime(ModifiedDate));//Đọc cấu trúc từ file Resource dạng "Cập nhật {0}"
        ltlViewCount.Text = BicResource.GetValue("ViewCount") + ViewCount;//Đọc cấu trúc từ file Resource dạng "Lượt xem {0}"
    }
}