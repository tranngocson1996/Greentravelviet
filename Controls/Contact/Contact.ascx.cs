using System;
using System.Web.UI.WebControls;
using BIC.Handler;
using BIC.Utils;
using BIC.WebControls;
using BIC.Biz;

public partial class Controls_Contact_Contact : BaseUIControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var MenuName = BicRouting.GetRequestString("menu_name", "0");
            var menuUserEntity = MenuUserBiz.GetMenuUserByUrlName(MenuName);
            if (string.IsNullOrEmpty(MenuName)) return;
            if (!IsPostBack)
            {
                if (menuUserEntity != null)
                {
                    mnCap.MenuUserId = menuUserEntity.MenuUserId;
                }
            }
        }
    }
    protected void FeedBack(object sender, CommandEventArgs e)
    {
        try
        {
            if (e.CommandName.Equals("Send"))
            {
                //if (radCapcha.IsValid)
                    SendEmail();
                //else { BicAjax.Alert("Sai mã xác thực!"); }
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

    private void SendEmail()
    {
        var pro = BicSession.ToString("UrlProduct");
        var content = BicHtml.GetContents(string.Format("~/Controls/Contact/contact_{0}.htm", base.Language));
        content = content.Replace("[DateTime]", DateTime.Now.ToString("dd/MM/yyyy"));
        content = content.Replace("[Domain]", BicXML.ToString("Domain", "MailConfig"));
        content = content.Replace("[Sender]", txtFullName.Text.Trim());
        content = content.Replace("[Email]", txtEmail.Text);
        //content = content.Replace("[Address]", txtAdress.Text);
        content = content.Replace("[Phone]", txtPhone.Text);
        content = content.Replace("[Content]", (string.IsNullOrEmpty(pro) ? string.Empty : pro + "<br />") + txtContent.Text);
        content = content.Replace("[SaleMail]", BicXML.ToString("SaleMail", "MailConfig"));

        if (BicEmail.SendContactToWebMaster(content, txtEmail.Text, txtFullName.Text))
            if (BicEmail.SendToCustomer(txtEmail.Text, BicLanguage.CurrentLanguage == "vi" ? "Liên hệ" : "Contact", content))
            {
                if (Convert.ToBoolean(Session["muahang"]))
                    rapContact.Alert(BicResource.GetValue("Message", "SEND_MAIL_ORDER"));
                else
                {
                    rapContact.Alert(BicResource.GetValue("Message", "SEND_MAIL_SUCCESS"));
                    Session["muahang"] = false;
                }
                ClearForm();
                //Response.Redirect(Request.RawUrl);
            }
    }

    private void ClearForm()
    {
        //txtAdress.Text = string.Empty;
        txtContent.Text = string.Empty;
        txtEmail.Text = string.Empty;
        txtPhone.Text = string.Empty;
        txtFullName.Text = string.Empty;
        Session["UrlProduct"] = null;
    }
}