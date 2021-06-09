using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;

/// <summary>
/// Summary description for ArticleApi
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class ArticleApi : System.Web.Services.WebService {

    public ArticleApi () {
    }

    [WebMethod]
    public string ReadContent(string id)
    {
        string content = string.Empty;
        ArticleEntity articleEntity = ArticleBiz.GetArticleByID(BicConvert.ToInt32(id));
        if (articleEntity != null)
        {
           content+=string.Format("<div class='title'> {0} </div>",articleEntity.Title);      
           content+=string.Format("<div class='divNoiDung'> {0} </div>",articleEntity.Body);      
        }
        return content;
    }
}
