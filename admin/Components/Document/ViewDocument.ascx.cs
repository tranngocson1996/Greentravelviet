using System;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_Document_ViewDocument : BaseUserControl
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
        DocumentEntity documentEntity = DocumentBiz.GetDocumentByID(Id);
        if (documentEntity != null)
        {
            lblDBDocumentTypeID.Text = BicConvert.ToString(documentEntity.DocumentTypeID);
            lblDBDisplayName.Text = BicConvert.ToString(documentEntity.DisplayName);
            lblDBDocumentNo.Text = BicConvert.ToString(documentEntity.DocumentNo);
            lblDBViewNo.Text = BicConvert.ToString(documentEntity.ViewNo);
            lblDBBriefDescription.Text = BicConvert.ToString(documentEntity.BriefDescription);
            lblDBUserNameView.Text = BicConvert.ToString(documentEntity.UserNameView);
            lblDBUserNameEdit.Text = BicConvert.ToString(documentEntity.UserNameEdit);
            chkIsActive.Checked = BicConvert.ToBoolean(documentEntity.IsActive);
        }
    }
}