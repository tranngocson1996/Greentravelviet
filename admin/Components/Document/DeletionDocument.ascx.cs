using System;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_Document_DeletionDocument : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = BicHtml.GetRequestString("id", 0);
        DocumentEntity _documentEntity = DocumentBiz.GetDocumentByID(id);
        if (_documentEntity != null)
        {
            if (BicFile.Delete(Server.MapPath(string.Format("{0}{1}", BicApplication.URLPath("FileUpload/Documents"), _documentEntity.Name))))
            {
                if (!DocumentBiz.DeleteDocument(id))
                    BicAjax.Confirm(BicMessage.DeleteFail, BicAdmin.UrlList());
            }
        }

        BicAdmin.NavigateToList();
    }
}