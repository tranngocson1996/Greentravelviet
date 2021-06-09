using System;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Handler;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_Document_AdditionDocument : BaseUserControl
{
    private string docname = string.Empty;
    private string doctype = string.Empty;
    private string docsize = string.Empty;
    protected static string TypeOfControl = "docs";

    protected void rauUpload_FileUploaded(object sender, Telerik.Web.UI.FileUploadedEventArgs e)
    {
        try
        {
            docsize = e.File.ContentLength.ToString();
            doctype = e.File.GetExtension();
            docname = BicImage.ConvertImageName(e.File.FileName);
            string fullPath = Server.MapPath(ruDoc.TargetFolder + "/" + docname + doctype);
            e.File.SaveAs(fullPath, true);
        }
        catch (Exception ex)
        {
            throw;
        }
        
    }

    private DocumentEntity LoadDataToEntity()
    {
        var documentEntity = new DocumentEntity
                                 {
                                     Name = docname+doctype,
                                     Size = BicConvert.ToInt32(docsize),
                                     Ext = doctype,
                                     DocumentTypeID = BicConvert.ToInt32(ddlDocumentTypeID.SelectedValue),
                                     DisplayName = BicConvert.ToString(txtDisplayName.Text),
                                     DocumentNo = BicConvert.ToString(txtDocumentNo.Text),
                                     ViewNo = BicConvert.ToInt32(txtViewNo.Text),
                                     BriefDescription = BicConvert.ToString(txtBriefDescription.Text),
                                     UserNameView = ddlLanguage.SelectedValue,
                                     UserNameEdit = BicConvert.ToString(txtUserNameEdit.Text),
                                     IsNew = chkIsNews.Checked,
                                     IsActive = chkIsActive.Checked,
                                     CreatedBy = BicMemberShip.CurrentUserName,
                                     CreatedDate = DateTime.Now,
                                     ModifiedBy = BicMemberShip.CurrentUserName,
                                     ModifiedDate = DateTime.Now,
                                     Priority = BicConvert.ToInt32(ntxPosition.Text),
                                 };
        return documentEntity;
    }

    protected void Save(object sender, CommandEventArgs e)
    {
        try
        {
            switch(e.CommandName)
            {
                case "AddNew":
                    if(ddlDocumentTypeID.SelectedValue == "0")
                        BicAjax.Alert("Bạn chưa chọn danh mục tài liệu");
                    else
                    {
                        if(string.IsNullOrEmpty(docname))
                        {
                            BicAjax.Alert("Bạn chưa chọn tài liệu cần tải lên.");
                            return;
                        }
                        DocumentBiz.InsertDocument(LoadDataToEntity());
                        BicAdmin.NavigateToList();
                    }
                    break;
            }
        }
        catch(Exception ex)
        {
            BicAjax.Alert(ex.Message);
        }
    }

    protected void ddlLanguage_SelectedIndexChanged(object o, EventArgs e)
    {
        ddlDocumentTypeID.Items.Clear();  
        ddlDocumentTypeID.Language = ddlLanguage.SelectedValue;
        ddlDocumentTypeID.TypeOfControl =BIC.WebControls.TypeOfControl.Docs;
        ddlDocumentTypeID.LoadData();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlDocumentTypeID.Language = ddlLanguage.SelectedValue;
            ddlDocumentTypeID.TypeOfControl = BIC.WebControls.TypeOfControl.Docs;
            ddlDocumentTypeID.LoadData();
            PositionWithPriorityAdd();
        }
    }
    public void PositionWithPriorityAdd()
    {
        try
        {
            var dh = new DataHelper();
            int maxPosition = BicConvert.ToInt32(dh.CountItem("DocumentID", "Document"));
            if (maxPosition > 0){ ntxPosition.MaxValue = maxPosition;}
        }
        catch (Exception ex)
        {
            LogEvent.LogToFile(ex.ToString());
        }
    }
}