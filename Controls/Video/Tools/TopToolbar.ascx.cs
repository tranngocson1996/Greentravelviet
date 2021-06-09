using System;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Controls_Article_Tools_TopToolbar : BaseUIControl
{
    public int ArticleID { get; set; }

    public string Type { get; set; }
    public int ViewCount;
    public DateTime ModifiedDate;

    protected void Page_Load(object sender, EventArgs e)
    {
        ArticleID = BicRouting.GetRequestString("id", 0);
        ltlModifiedDate.Text = string.Format(BicResource.GetValue("LastUpdate"), BicDateTime.ToShortDateTime(ModifiedDate));//Đọc cấu trúc từ file 
        ltlViewCount.Text = ViewCount.ToString();
    }
}