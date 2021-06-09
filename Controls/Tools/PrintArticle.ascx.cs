using System;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Controls_Tools_PrintArticle : BaseUIControl
{
    protected int Id;

    protected void Page_Load(object sender, EventArgs e)
    {
        Id = BicRouting.GetRequestString("id", 0);

        if (!IsPostBack)
        {
            BindingArticleDetail();
        }
    }

    protected void BindingArticleDetail()
    {
        ArticleEntity articleEntity = ArticleBiz.GetArticleByID(Id);
        if (articleEntity != null)
        {
            Page.Title = string.Format("{1} - {0}", articleEntity.Title,
                                       BicXML.ToString("PrefixArticle", "SearchEngine"));

            lblArticle.Text = articleEntity.Title;
            ltlBody.Text = articleEntity.Body;
        }
        else
            Page.Visible = false;
    }
}