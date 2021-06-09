using System;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_Document_EditionDocument : BaseUserControl
{
    protected int Id;
    private string _docName = string.Empty;
    private string _docNameNew = string.Empty;
    private string _docTypeNew = string.Empty;
    private string _docSizeNew = string.Empty;
    protected static string TypeOfControl = "docs";

    protected void Page_Load(object sender, EventArgs e)
    {
        Id = BicHtml.GetRequestString("id", 0);
        if(!IsPostBack)
        {
           
            //DocumentBiz.PositionWithPriorityEdit(ddlPosition);
            LoadDataFromEntity();
        }
    }

    protected void rauUpload_FileUploaded(object sender, Telerik.Web.UI.FileUploadedEventArgs e)
    {
        _docSizeNew = e.File.ContentLength.ToString();
        _docTypeNew = e.File.GetExtension();
        // _docNameNew = BicImage.ConvertImageName(e.File.FileName);
		_docNameNew = e.File.FileName;
        string fullPath = Server.MapPath(ruDoc.TargetFolder + "/" + _docNameNew);
        e.File.SaveAs(fullPath, true);
    }

    private void LoadDataFromEntity()
    {
        DocumentEntity documentEntity = DocumentBiz.GetDocumentByID(Id);
        if(documentEntity != null)
        {
            _docName = documentEntity.Name;
            
            txtDisplayName.Text = BicConvert.ToString(documentEntity.DisplayName);
            txtDocumentNo.Text = BicConvert.ToString(documentEntity.DocumentNo);
            txtViewNo.Text = BicConvert.ToString(documentEntity.ViewNo);
            txtBriefDescription.Text = BicConvert.ToString(documentEntity.BriefDescription);
            txtUserNameView.Text = ddlLanguage.SelectedValue;
            txtUserNameEdit.Text = BicConvert.ToString(documentEntity.UserNameEdit);
            chkIsActive.Checked = BicConvert.ToBoolean(documentEntity.IsActive);
            linkdoc.Text = documentEntity.Name;
            chkIsNew.Checked = documentEntity.IsNew;
            ntxPosition.Text = documentEntity.Priority.ToString();
            chkIsNews.Checked = documentEntity.IsNew;

            //load ngon ngu va loai tai lieu
            MenuUserEntity menuUserEntity = MenuUserBiz.GetMenuUserByID(BicConvert.ToInt32(documentEntity.DocumentTypeID));
            if(menuUserEntity != null)
            {ddlLanguage.SelectedValue = menuUserEntity.LanguageKey;}
            ddlDocumentTypeID.Language = ddlLanguage.SelectedValue;
            ddlDocumentTypeID.LoadData();

            ddlDocumentTypeID.SelectedValue = BicConvert.ToString(documentEntity.DocumentTypeID);
        }
    }

    private DocumentEntity LoadDataToEntity()
    {
        var documentEntity = DocumentBiz.GetDocumentByID(Id);
        if(!string.IsNullOrEmpty(_docNameNew))
        {
            DeleteOldDoc();
            documentEntity.Name = _docNameNew;
            documentEntity.Size = BicConvert.ToInt32(_docSizeNew);
            documentEntity.Ext = _docTypeNew;
        }
        documentEntity.DocumentTypeID = BicConvert.ToInt32(ddlDocumentTypeID.SelectedValue);
        documentEntity.DisplayName = BicConvert.ToString(txtDisplayName.Text);
        documentEntity.DocumentNo = BicConvert.ToString(txtDocumentNo.Text);
        documentEntity.ViewNo = BicConvert.ToInt32(txtViewNo.Text);
        documentEntity.BriefDescription = BicConvert.ToString(txtBriefDescription.Text);
        documentEntity.UserNameView = ddlLanguage.SelectedValue;
        documentEntity.UserNameEdit = BicConvert.ToString(txtUserNameEdit.Text);
        documentEntity.IsActive = chkIsActive.Checked;
        documentEntity.ModifiedBy = BicMemberShip.CurrentUserName;
        documentEntity.ModifiedDate = DateTime.Now;
        documentEntity.IsNew = chkIsNews.Checked;

        documentEntity.Priority = BicConvert.ToInt32(ntxPosition.Text);
        return documentEntity;
    }

    protected void DeleteOldDoc()
    {
        try
        {
            BicFile.Delete(
                Server.MapPath(string.Format("{0}{1}", BicApplication.URLPath("FileUpload/Documents"), _docName)));
        }
        catch(Exception ex)
        {
            BicAjax.Alert(ex.Message);
        }
    }

    protected void Save(object sender, CommandEventArgs e)
    {
        if(e.CommandName == "Update")
        {
            if(ddlDocumentTypeID.SelectedValue == "0")
                BicAjax.Alert("Bạn chưa chọn danh mục tài liệu.");
            else
            {
                DocumentBiz.UpdateDocument(LoadDataToEntity());
                BicAdmin.NavigateToList();
            }
        }
    }

    protected void linkdoc_Click(object sender, EventArgs e)
    {
        Dowload(Id);
    }

    protected void Dowload(int id)
    {
        var documentEntity = DocumentBiz.GetDocumentByID(id);
        if(documentEntity != null)
        {
            try
            {
                Response.ContentType = documentEntity.Ext;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + documentEntity.Name);
                Response.TransmitFile(MapPath("~/FileUpload/Documents/") + documentEntity.Name);
                Response.End();
            }
            catch(Exception ex)
            {
                BicAjax.Alert(ex.Message);
            }
        }
    }

    protected void ddlLanguage_SelectedIndexChanged(object o, EventArgs e)
    {
        ddlDocumentTypeID.Items.Clear();
        ddlDocumentTypeID.Language = ddlLanguage.SelectedValue;
        ddlDocumentTypeID.LoadData();
    }
}