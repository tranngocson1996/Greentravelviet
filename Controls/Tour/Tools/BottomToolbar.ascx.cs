using System;
using System.Web.UI;
using BIC.Utils;
using BIC.WebControls;

public partial class Controls_Tour_Tools_BottomToolbar : BaseUIControl
{
    public int ViewCount;
    public DateTime ModifiedDate;
    public string SendMailUrl { get; set; }
    public string Tourid;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        SendMailUrl = string.Format("{0}{1}/ShareByEmail.bic?target={2}", BicApplication.URLRoot, Language, Request.Url.ToString());    
        //ltlModifiedDate.Text = string.Format(BicResource.GetValue("LastUpdate"), BicDateTime.ToShortDateTime(ModifiedDate));//Đọc cấu trúc từ file Resource dạng "Cập nhật {0}"
        ltlViewCount.Text = string.Format(BicResource.GetValue("ViewCount"), ViewCount);//Đọc cấu trúc từ file Resource dạng "Lượt xem {0}"
    }
}