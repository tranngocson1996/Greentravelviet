using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;

/// <summary>
/// Summary description for Download
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class Download : WebService {
    [WebMethod]
    public string UpdateViewCount(string documentId)
    {
        string strSuccess = string.Empty;
        DocumentEntity documentEntity = DocumentBiz.GetDocumentByID(BicConvert.ToInt32(documentId));
        if (documentEntity != null)
        {
            documentEntity.ViewNo++;
            DocumentBiz.UpdateDocument(documentEntity);
            strSuccess = "update document successfully";
        }
        return strSuccess;
    }
    
}
