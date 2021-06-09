using System;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.Data;
using BIC.WebControls;
using System.Web.UI.WebControls;

public partial class Admin_Components_Email_EditionEmail : BaseUserControl
{
	protected int Id;
	protected void Page_Load(object sender, EventArgs e)
    {      
        Id = BicHtml.GetRequestString("id", 0);
		if (!IsPostBack)
        {
            chkIsActive.Enabled = Approved;
            //EmailBiz.PositionWithPriorityEdit(ddlPosition);
			LoadDataFromEntity();
        }
    }
    private void LoadDataFromEntity()
    {
		EmailEntity emailEntity = EmailBiz.GetEmailByID(Id);
        if (emailEntity != null)
        {
     	    txtEmail.Text = BicConvert.ToString(emailEntity.Email);
     	    txtInterval.Text = BicConvert.ToString(emailEntity.Interval);
     	    txtLastSend.Text = BicConvert.ToString(emailEntity.LastSend);
            //ddlPosition.SelectedValue = emailEntity.Priority.ToString();
     	    txtCreatedTime.Text = BicConvert.ToString(emailEntity.CreatedTime);
     	    chkIsActive.Checked = BicConvert.ToBoolean(emailEntity.IsActive);
        }
    }
	
    private EmailEntity LoadDataToEntity()
    {
     	EmailEntity emailEntity = new EmailEntity();
		emailEntity.EmailID = Id;
		
     	emailEntity.Email = BicConvert.ToString(txtEmail.Text);
     	emailEntity.Interval = BicConvert.ToInt32(txtInterval.Text);
     	emailEntity.LastSend= BicConvert.ToDateTime(txtLastSend.Text );
        //emailEntity.Priority = BicConvert.ToInt32(ddlPosition.SelectedValue);
     	emailEntity.CreatedTime= BicConvert.ToDateTime(txtCreatedTime.Text );
     	emailEntity.IsActive = chkIsActive.Checked;
		return emailEntity;
    }

    protected void Save(object sender, CommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Update")
            {
                EmailBiz.UpdateEmail(LoadDataToEntity());
                BicAdmin.NavigateToList();
            }
        }
        catch (Exception ex)
        {
            BicAjax.Alert(ex.Message);
        }
    }
}
