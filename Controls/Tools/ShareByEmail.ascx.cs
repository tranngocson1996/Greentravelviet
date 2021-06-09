using System;
using System.Web.UI;
using BIC.Handler;
using BIC.Utils;
using BIC.WebControls;

public partial class Controls_Article_Tools_ShareByEmail : BaseUIControl
{
    protected void ibtSend_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            string lang = Language;
            string urlPage = Request.QueryString["target"]; //URL of page for sharing

            bool checkValidation = true;

            //check sender missing or not

            if (txtSender.Text == string.Empty)
            {
                checkValidation = false;
                BicAjax.Alert(BicResource.GetValue("Message", "SHARE_BY_MAIL_SENDER_MISSING"));
            }

            //check FromEmail field
            if (txtEmailFrom.Text == string.Empty)
            {
                checkValidation = false;
                BicAjax.Alert(BicResource.GetValue("Message", "SHARE_BY_MAIL_MAIL_FROM_MISSING"));
            }

            //check ToEmail field
            if (txtEmailTo.Text == string.Empty)
            {
                checkValidation = false;
                BicAjax.Alert(BicResource.GetValue("Message", "SHARE_BY_MAIL_MAIL_TO_MISSING"));
            }

            //incase whole conditions is okay, send mail!
            if (urlPage != string.Empty && checkValidation)
            {
                string subject = txtEmailFrom.Text.Trim() + " has shared something with you!";

                string content =
                    BicHtml.GetContents(string.Format("~/Controls/Tools/share_by_email_{0}.htm", base.Language));
                content = content.Replace("[Sender]", txtSender.Text);
                content = content.Replace("[FromEmail]", txtEmailFrom.Text);
                content = content.Replace("[URL]", urlPage);
                content = content.Replace("[Note]", txtEmailContent.Text);
                content = content.Replace("[Website]",
                                          string.Format("<a href='{0}'>{1}</a>", Request.Url.Host,
                                                        BicApplication.GetBaseURL));

                //in case user wanna send this link to many emails, split them before progressing!
                string[] emailArr = BicString.SplitComma(txtEmailTo.Text);
                foreach (string emailTo in emailArr)
                {
                    if (BicEmail.SendToCustomer(emailTo, subject, content))
                    {
                        BicAjax.Alert(BicResource.GetValue("Message", "SEND_MAIL_SUCCESS"));
                    }
                }
            }
            else
            {
                BicAjax.Alert(BicResource.GetValue("Message", "SHARE_BY_MAIL_SYSTEM_ERR"));
            }
        }
        catch (Exception ex)
        {
            LogEvent.LogToFile(ex.ToString());
        }
    }

    protected void ibtReset_Click(object sender, ImageClickEventArgs e)
    {
        txtSender.Text = "";
        txtEmailFrom.Text = "";
        txtEmailTo.Text = "";
        txtEmailContent.Text = "";
    }
}