using System;
using System.Web.UI;

public partial class admin_Components_Shutdown_Shutdown : UserControl
{
    private bool IsOnline;
    protected void Page_Load(object sender, EventArgs e)
    {
        IsOnline = Convert.ToBoolean(Application["IsOnline"]);
        if (!IsOnline)
        {
            lblStatus.Text = "Đang hoạt động";
            btnOnline.Text = "Tắt hệ thống";
            reNote.Html = Application["OfflineReason"].ToString();
        }
        else
        {
            lblStatus.Text = "Ngừng hoạt động";
            btnOnline.Text = "Mở hệ thống";
            reNote.Html = Application["OfflineReason"].ToString();
        }
    }
    protected void btnOnline_Click(object sender, EventArgs e)
    {
        if (IsOnline)
        {
            Application["IsOnline"] = false;
            Application["OfflineReason"] = reNote.Html;
        }
        else
        {
            Application["IsOnline"] = true;
        }
        Server.Transfer(Request.RawUrl);
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Application["OfflineReason"] = reNote.Html;
    }
}