using System;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_Email_ViewEmail : BaseUserControl
{

    public int Id;
    protected void Page_Load(object sender, EventArgs e)
    {
        Id = BicHtml.GetRequestString("id", 0);
        if (!IsPostBack)
            LoadDataFromEntity();
    }
	private void LoadDataFromEntity()
    {
		EmailEntity emailEntity = EmailBiz.GetEmailByID(Id);
        if (emailEntity != null)
        {
			lblDBEmail.Text = BicConvert.ToString(emailEntity.Email);
			lblDBInterval.Text = BicConvert.ToString(emailEntity.Interval);
			lblDBLastSend.Text = BicConvert.ToString(emailEntity.LastSend);
			lblDBCreatedTime.Text = BicConvert.ToString(emailEntity.CreatedTime);
			chkIsActive.Checked = BicConvert.ToBoolean(emailEntity.IsActive);
	    }
    }
}
