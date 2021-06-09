using System;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_FAQ_ViewFAQ : BaseUserControl
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
		FAQEntity faqEntity = FAQBiz.GetFAQByID(Id);
        if (faqEntity != null)
        {

			lblDBTitle.Text = BicConvert.ToString(faqEntity.Title);
			lblDBFaqQuestion.Text = BicConvert.ToString(faqEntity.FaqQuestion);
			lblDBFaqAnswer.Text = BicConvert.ToString(faqEntity.FaqAnswer);
			lblDBFullName.Text = BicConvert.ToString(faqEntity.FullName);
			lblDBEmail.Text = BicConvert.ToString(faqEntity.Email);
			lblDBMobile.Text = BicConvert.ToString(faqEntity.Mobile);
		
			chkIsActive.Checked = BicConvert.ToBoolean(faqEntity.IsActive);
	    }
    }
}
