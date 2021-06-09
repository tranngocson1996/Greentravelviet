using System;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_FAQ_EditionFAQ : BaseUserControl
{
    protected int Id;

    protected void Page_Load(object sender, EventArgs e)
    {
        Id = BicHtml.GetRequestString("id", 0);
        if (!IsPostBack)
        {
            if (BicSession.ToString("FAQLang") != string.Empty)
                ddlLanguage.SelectedValue = BicSession.ToString("FAQLang");

         
            LoadDataFromEntity();
        }
    }

    private void LoadDataFromEntity()
    {
        FAQEntity faqEntity = FAQBiz.GetFAQByID(Id);
        if (faqEntity != null)
        {
            ddlLanguage.SelectedValue = faqEntity.LanguageKey;
           
            txtTitle.Text = BicConvert.ToString(faqEntity.Title);
            txtFaqQuestion.Html = BicConvert.ToString(faqEntity.FaqQuestion);
            reFaqAnswer.Html = BicConvert.ToString(faqEntity.FaqAnswer);
            txtFullName.Text = BicConvert.ToString(faqEntity.FullName);
            txtEmail.Text = BicConvert.ToString(faqEntity.Email);
            txtMobile.Text = BicConvert.ToString(faqEntity.Mobile);
       
            chkIsActive.Checked = BicConvert.ToBoolean(faqEntity.IsActive);
        }
    }

    private FAQEntity LoadDataToEntity()
    {
        FAQEntity faqEntity = new FAQEntity();
        faqEntity.Faqid = Id;

        faqEntity.LanguageKey = ddlLanguage.SelectedValue;
       
        faqEntity.Title = BicConvert.ToString(txtTitle.Text);
        faqEntity.FaqQuestion = BicConvert.ToString(txtFaqQuestion.Html);
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
            if (e.CommandName == "Update")
            {
                if (FAQBiz.UpdateFAQ(LoadDataToEntity()))
                {
                    BicSession.SetValue("FAQLang", ddlLanguage.SelectedValue);
                    BicAdmin.NavigateToList();
                }
                else
                    BicAjax.Alert(BicMessage.UpdateFail);
            }
        }
        catch (Exception ex)
        {
            BicAjax.Alert(ex.Message);
        }
    }
}