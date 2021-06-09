using System;
using System.Web.UI.WebControls;
using BIC.Handler;
using BIC.Utils;
using BIC.WebControls;

public partial class Controls_Contact_TuVanContact : BaseUIControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void FeedBack(object sender, CommandEventArgs e)
    {
        try
        {
            if (e.CommandName.Equals("Send"))
            {
                //if (radCapcha.IsValid)
                if (SendEmail())
                {
                    BicAjax.Alert("Gửi câu hỏi thành công!");
                }
                else { BicAjax.Alert("Lỗi, hiện tại không thể gửi câu hỏi!"); }
            }
            if (e.CommandName.Equals("Cancel"))
            {
                ClearForm();
            }
        }
        catch (Exception ex)
        {
            LogEvent.LogToFile(ex.ToString());

        }
    }

    private bool SendEmail()
    {
        string content = BicHtml.GetContents(string.Format("~/Controls/Contact/register_{0}.htm", base.Language));
        content = content.Replace("[DateTime]", DateTime.Now.ToString("dd/MM/yyyy"));
        content = content.Replace("[Domain]", BicXML.ToString("Domain", "MailConfig"));
        content = content.Replace("[Sender]", txtFullName.Text.Trim());
        content = content.Replace("[Email]", txtEmail.Text);
        content = content.Replace("[Phone]", txtPhone.Text);
        content = content.Replace("[Content]", txtQuestion.Text);
        content = content.Replace("[SaleMail]", BicXML.ToString("WebMasterEmail", "MailConfig"));

        string content_cus = @"<p>Chào bạn " + txtFullName.Text + @"</p>
                                <p>Cảm ơn bạn đã gửi câu hỏi cho chúng tôi.</p>
                                <p>Chúng tôi sẽ liên hệ với bạn ngay khi tiếp nhận được thông tin.</p>
                                <p>Trân trọng!</p>
                                <p>Royal Green</p>";

        if (!BicEmail.SendContactToWebMaster(content, txtEmail.Text, txtFullName.Text)) return false;
        if (!BicEmail.SendToCustomer(txtEmail.Text,
            BicLanguage.CurrentLanguage == "vi"
                ? "Câu hỏi tư vấn gửi về Royal Green"
                : "Question send to Royal Green", content_cus)) return true;
        ClearForm();
        Page.ClientScript.RegisterStartupScript(GetType(), "CallMyFunction", "$('#register').hide();", true);
        //Response.Redirect(Request.RawUrl);
        return true;
    }

    private void ClearForm()
    {
        txtEmail.Text = string.Empty;
        txtPhone.Text = string.Empty;
        txtFullName.Text = string.Empty;
        txtQuestion.Text = string.Empty;
    }
}