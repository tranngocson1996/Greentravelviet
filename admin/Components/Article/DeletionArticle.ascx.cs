using System;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class admin_Components_Article_DeletionArticle : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = BicHtml.GetRequestString("id", 0);
        //if (!PermissionHelper.ByMenuUsers(_oldMenu))
        //{
        //    BicAjax.Alert(BicMessage.UpdatePermission);
        //    return;
        //}
        ArticleEntity article = ArticleBiz.GetArticleByID(id);
        if (article != null)
            ArticleUtils.ClearAritcleCacheByMenuUserIds(article.MenuUserID); //Clear Article Cache
        ArticleBiz.DeleteArticle(id);
                BicAdmin.NavigateToList();
    }
}