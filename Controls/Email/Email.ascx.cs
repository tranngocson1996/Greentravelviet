using System;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Controls_Email_Email : BaseUIControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ibtSend_Click(object sender, EventArgs e)
    {
        try
        {
            if (CheckEmail() == false)
            {
                BicAjax.Alert(BicResource.GetValue("EmailNotFormat"));
            }
            else if (CheckExitsEmail(txtsend.Text))
            {
                BicAjax.Alert(BicResource.GetValue("EmailExisting"));
            }
            else
                if (EmailBiz.InsertEmail(LoadDataToEntity()))
                {
                    if (!SendMailUser(txtsend.Text)) return;
                    BicAjax.Alert(BicResource.GetValue("EmailSuccess"));
                    txtsend.Text = BicResource.GetValue("EmailAddress");
                }

        }
        catch
        {

            BicAjax.Alert(BicResource.GetValue("EmailRegisterFalse"));
        }
    }

    private bool CheckEmail()
    {
        var flag = true;
        const string match = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
        var reg = new Regex(match);
        if (reg.IsMatch(txtsend.Text))
        {
        }
        else
        {
            flag = false;
        }
        return flag;
    }

    protected bool SendMailUser(string email)
    {
        var activeUrl = BicApplication.GetBaseURL + String.Format("{0}/{1}/email.html", Language, email);
        var subject = BicResource.GetValue("EmailRegister");

        var content = BicHtml.GetContents(string.Format("~/Controls/Email/email_{0}.htm", Language));
        content = content.Replace("[Domain]", BicXML.ToString("Domain", "MailConfig"));
        content = content.Replace("[Website]", BicXML.ToString("Domain", "MailConfig"));//string domainName = Request.Url.Host.ToLower();
        content = content.Replace("[ActiveUrl]", activeUrl);
        content = content.Replace("[SaleMail]", BicXML.ToString("WebMasterEmail", "MailConfig"));
        //var contentMaster = BicHtml.GetContents("~/Controls/Email/Listemail_vi.htm");
        //contentMaster = contentMaster.Replace("[Email]", ListEmail());
        //contentMaster = contentMaster.Replace("[Domain]", BicXML.ToString("Domain", "MailConfig"));
        //contentMaster = contentMaster.Replace("[Website]", BicXML.ToString("Domain", "MailConfig"));
        //contentMaster = contentMaster.Replace("[SaleMail]", BicXML.ToString("WebMasterEmail", "MailConfig"));
        //BicEmail.SendToWebMaster(subject, contentMaster, email, subject);
        return BicEmail.SendToCustomer(email, subject, content);
    }


    private static string ListEmail()
    {
        var list = string.Empty;
        var bicData = new BicGetData
        {
            TableName = "Email"

        };
        bicData.Sorting.Add(new SortingItem("Priority", true));
        bicData.Conditioning.Add(new ConditioningItem("IsActive", "1", Operator.EQUAL, CompareType.NUMERIC));
        var data = bicData.GetAllData();
        return data.Rows.Cast<DataRow>().Aggregate(list, (current, dr) => current + (dr[EmailEntity.FIELD_EMAIL] + ", "));
    }
    private EmailEntity LoadDataToEntity()
    {
        var emailEntity = new EmailEntity
        {
            Email = BicConvert.ToString(txtsend.Text),
            Interval = 0,
            LastSend = DateTime.Now,
            CreatedTime = DateTime.Now,
            Priority = 0,
            IsActive = true
        };
        return emailEntity;

    }

    private static bool CheckExitsEmail(string email)
    {
        var flag = false;
        var bicData = new BicGetData
        {
            TableName = "Email"
        };
        bicData.Selecting.Add(EmailEntity.FIELD_EMAILID);
        var whereMenu = string.Format(" (Email ='{0}')", email);

        bicData.Conditioning.Add(new ConditioningItem
        {
            TypeOfCondition = TypeOfCondition.QUERY,
            Query = whereMenu,
            CombineCondition = CombineCondition.AND
        });
        var data = bicData.GetAllData();
        if (data.Rows.Count > 0)
        {
            flag = true;
        }
        return flag;
    }



    protected bool SendMail(string email)
    {
        var content = BicHtml.GetContents("~/Controls/Email/Cancelemail_vi.htm");
        content = content.Replace("[Domain]", BicXML.ToString("Domain", "MailConfig"));
        content = content.Replace("[Email]", email);
        content = content.Replace("[ListEmail]", ListEmail());
        content = content.Replace("[Website]", BicResource.GetValue("BussinessWebsite"));
        content = content.Replace("[SaleMail]", BicXML.ToString("WebMasterEmail", "MailConfig"));
        return BicEmail.SendToWebMaster(BicResource.GetValue("RegisterEmail"), content, email, BicResource.GetValue("RegisterEmail"));
    }
    //private int BindingEmail(string emailName)
    //{
    //    var emailId = 0;
    //    var bicData = new BicGetData
    //    {
    //        TableName = "Email"
    //    };

    //    bicData.Selecting.Add(EmailEntity.FIELD_EMAILID);
    //    var whereMenu = string.Format(" (Email ='{0}')", emailName);

    //    bicData.Conditioning.Add(new ConditioningItem
    //    {
    //        TypeOfCondition = TypeOfCondition.QUERY,
    //        Query = whereMenu,
    //        CombineCondition = CombineCondition.AND
    //    });
    //    var data = bicData.GetAllData();
    //    if (data.Rows.Count <= 0) return emailId;
    //    foreach (DataRow dr in data.Rows)
    //    {
    //        emailId = BicConvert.ToInt32(dr[EmailEntity.FIELD_EMAILID].ToString());
    //    }
    //    return emailId;
    //}

}