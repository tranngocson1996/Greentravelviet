using System;
using System.IO;
using System.Text;
using System.Web;
using BIC.WebControls;

public partial class Admin_Components_Log_ListingLog : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        string userDomainName = Environment.UserDomainName;
        string machineName = Environment.MachineName;
        string userName = Environment.UserName;
        string productName = System.Windows.Forms.Application.ProductName;
        var sb = new StringBuilder();
        if (!Directory.Exists(Server.MapPath("~/Exception")))
        {
            Directory.CreateDirectory(Server.MapPath("~/Exception"));
        }
        string fileName = HttpContext.Current.Server.MapPath(string.Format("~/Exception/ExceptionLog.{0}.{1}.{2}.{3}.log", productName, userDomainName, machineName, userName));
        try
        {
            using (var read = new StreamReader(fileName, Encoding.UTF8))
            {
                while (read.Peek() >= 0)
                {
                    sb.Append("<p>").Append(read.ReadLine()).Append("</p>");
                }
            }
            ltLog.Text = sb.ToString();
        }
        catch (Exception exception)
        {
            ltLog.Text = string.Format("Lỗi khi đọc file Log: {0}", exception);
        }
    }
}