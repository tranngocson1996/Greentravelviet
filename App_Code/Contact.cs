using System;
using System.Web.Services;
using BIC.Utils;

/// <summary>
/// Summary description for Contact
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class Contact:WebService {
    [WebMethod]
    public string SendEmail(string lang, string txtFullName, string txtAdress, string txtEmail, string txtPhone, string txtContent)
    {
        string result = string.Empty;
        string title = lang=="vi"?"Liên hệ":"Contact";
        string content = BicHtml.GetContents(string.Format("~/Controls/Contact/contact_{0}.htm",lang));
        content = content.Replace("[DateTime]", DateTime.Now.ToString("dd/MM/yyyy"));
        content = content.Replace("[Domain]", BicXML.ToString("Domain", "MailConfig"));
        content = content.Replace("[Sender]",txtFullName);
        content = content.Replace("[Email]",txtEmail);
        content = content.Replace("[Address]", txtAdress);
        content = content.Replace("[Phone]",txtPhone);
        content = content.Replace("[Content]", txtContent);
        content = content.Replace("[SaleMail]", BicXML.ToString("SaleMail", "MailConfig"));

        if (BicEmail.SendContactToWebMaster(content, txtEmail, txtFullName))
        {
            if (BicEmail.SendToCustomer(txtEmail, title, content))
            {
                string thongdiep = (lang == "vi"
                    ? "Gửi thông tin liên hệ thành công, chúng tôi sẽ liên hệ với bạn trong thời gian sớm nhất !!!"
                    : "Send information of contact sucessfully. We will call you  the best earliest!!!");
                result = string.Format(thongdiep);
            }
            else
            {
                string thongdiep = (lang == "vi"
                    ? "Hệ thống đang bảo trì"
                    : "The system is stop,please send information after a few minutes");
                result = string.Format(thongdiep);
            }
        }
        else
        {
            string thongdiep = (lang == "vi"
                ? "Hệ thống đang bảo trì"
                : "The system is stop,please send information of pricing after a few minutes");
            result = string.Format(thongdiep);
        }
        return result;
    }
}
