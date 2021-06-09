using System;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.Data;
using BIC.WebControls;

public partial class Admin_Components_Email_AdditionEmail : BaseUserControl
{
	protected void Page_Load(object sender, EventArgs e)
    {      
        if (!IsPostBack)
        {
            //EmailBiz.PositionWithPriorityAdd(ddlPosition);
        }
    }
    private EmailEntity LoadDataToEntity()
    {
     	var emailEntity = new EmailEntity();
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
            switch (e.CommandName)
            {
                case "AddNew":
                    EmailBiz.InsertEmail(LoadDataToEntity());
                    BicAdmin.NavigateToList();
                    break;
            }
        }
        catch (Exception ex)
        {
            BicAjax.Alert(ex.Message);
        }
    }

}
