using System;
using System.Linq;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_Article_ViewArticle : BaseUserControl
{
    public int Id;

    protected void Page_Load(object sender, EventArgs e)
    {
        Id = BicHtml.GetRequestString("id", 0);
        if (IsPostBack) return;
        LoadDataFromEntity();
        tbBottom.PEdit = tbBottom.PDel = tbTop.PEdit = tbTop.PDel = Approved;
    }

    protected string GetNameMenu(string menus)
    {
        string result = string.Empty;
        string[] arrmenu = BicString.SplitComma(menus);
        result = arrmenu.Where(s => !string.IsNullOrWhiteSpace(s)).Aggregate(result,
                                                                             (current, s) =>
                                                                             current +
                                                                             (MenuUserBiz.GetNameById(
                                                                                 BicConvert.ToInt32(s)) + ", "));
        if (result.Length > 2)
            result = result.Remove(result.Length - 2, 2);
        return result;
    }

    protected string GetNameCategory(string categories)
    {
        string result = string.Empty;
        string[] arr = BicString.SplitComma(categories);
        result = arr.Where(s => !string.IsNullOrWhiteSpace(s)).Aggregate(result,
                                                                         (current, s) =>
                                                                         current +
                                                                         (BicXML.ToString(s, "ModelNews_vi") + ", "));
        if (result.Length > 2)
            result = result.Remove(result.Length - 2, 2);
        return result;
    }

    private void LoadDataFromEntity()
    {
        ArticleEntity articleEntity = ArticleBiz.GetArticleByID(Id);
        if (articleEntity == null) return;
        litTitle.Text = BicConvert.ToString(articleEntity.Title);
        litBriefDescription.Text = BicConvert.ToString(articleEntity.BriefDescription);
        litBody.Text = BicConvert.ToString(articleEntity.Body);
        litMenuUser.Text = GetNameMenu(articleEntity.MenuUserID);
        BicImage.ViewImageFix(htmlImage, articleEntity.ImageID, 102, 66, true);
        aImage.HRef = BicImage.GetPathImage(articleEntity.ImageID);
        txtSource.Text = BicConvert.ToString(articleEntity.Source);
        txtViewCount.Text = BicConvert.ToString(articleEntity.ViewCount);
        txtLink.Text = BicConvert.ToString(articleEntity.Link);
        chkCommentEnable.Checked = BicConvert.ToBoolean(articleEntity.CommentsEnabled);
        chkIsHome.Checked = BicConvert.ToBoolean(articleEntity.IsHome);
        chkIsNew.Checked = BicConvert.ToBoolean(articleEntity.IsNew);
        chkIsActive.Checked = BicConvert.ToBoolean(articleEntity.IsActive);
        cbTarget.SelectedValue = BicConvert.ToString(articleEntity.Target);
    }
}