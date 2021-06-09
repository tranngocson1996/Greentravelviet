using System;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_FAQ_AdditionFAQ : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (BicSession.ToString("FAQLang") != string.Empty)
                ddlLanguage.SelectedValue = BicSession.ToString("FAQLang");

           
        }
    }

    
    private FAQEntity LoadDataToEntity()
    {
        var faqEntity = new FAQEntity();
        faqEntity.LanguageKey = ddlLanguage.SelectedValue;
       
        faqEntity.Title = BicConvert.ToString(txtTitle.Text);
        faqEntity.FaqQuestion = BicConvert.ToString(txtFaqQuestion.Text);
        faqEntity.FaqAnswer = BicConvert.ToString(reFaqAnswer.Html);
        faqEntity.FullName = BicConvert.ToString(txtFullName.Text);
        faqEntity.Email = BicConvert.ToString(txtEmail.Text);
        faqEntity.Mobile = BicConvert.ToString(txtMobile.Text);
     
        faqEntity.IsActive = chkIsActive.Checked;
        return faqEntity;
    }

    protected void Save(object sender, CommandEventArgs e)
    {
        try
        {
            switch (e.CommandName)
            {
                case "AddNew":
                    if (FAQBiz.InsertFAQ(LoadDataToEntity()))
                    {
                        BicSession.SetValue("FAQLang", ddlLanguage.SelectedValue);
                               
                        BicAdmin.NavigateToList();
                    }
                    else
                        BicAjax.Alert(BicMessage.InsertFail);
                    break;
            }
        }
        catch (Exception ex)
        {
            BicAjax.Alert(ex.Message);
        }
    }

    protected void ddlLanguage_SelectedIndexChanged(object o, EventArgs e)
    {
        BicSession.SetValue("FAQLang", ddlLanguage.SelectedValue);
      
    }

 
}
