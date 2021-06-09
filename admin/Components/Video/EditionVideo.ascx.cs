using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;
using Telerik.Web.UI;

public partial class Admin_Components_Article_EditionArticle : BaseUserControl
{
    private int _id;

    protected void Page_Load(object sender, EventArgs e)
    {
        _id = BicHtml.GetRequestString("id", 0);
        if (!IsPostBack)
        {
            chkIsActive.Enabled = Approved;
            BicXML.BindDropDownListFromXML(ddlTintieudiem, "~/admin/XMLData/Tintieudiem.xml");
            BicXML.BindDropDownListFromXML(ddlTypeNews, "~/admin/XMLData/ModelNews.xml");
            //ArticleBiz.PositionWithPriorityEdit(ddlPosition);
            LoadDataFromEntity();
            CommentArticle1.ArticleID = _id;
            RelatedArticle1.Lang = ddlLanguage.SelectedValue;
        }
    }

    public void RemoveCache()
    {
        var keyList = new List<string>();
        IDictionaryEnumerator cacheEnum = HttpContext.Current.Cache.GetEnumerator();
        while (cacheEnum.MoveNext())
        {
            keyList.Add(cacheEnum.Key.ToString());
        }
        foreach (string key in keyList)
        {
            HttpContext.Current.Cache.Remove(key);
        }
    }

    private void LoadDataFromEntity()
    {
        BizObject.PurgeCacheItems("IDArticle_Article_" + _id); //clear cache bài viết trước khi lấy dữ liệu ra
        ArticleEntity articleEntity = ArticleBiz.GetArticleByID(_id);
        if (articleEntity == null) return;
        txtTitle.Text = BicConvert.ToString(articleEntity.Title);
        reBriefDescription.Content = BicConvert.ToString(articleEntity.BriefDescription);
        reBody.Content = BicConvert.ToString(articleEntity.Body);
        isImageId.ImageID = BicConvert.ToString(articleEntity.ImageID);
        isVideoID.VideoID = BicConvert.ToString(articleEntity.VideoID);
        txtSource.Text = BicConvert.ToString(articleEntity.Source);
        txtViewCount.Text = BicConvert.ToString(articleEntity.ViewCount);
        txtLink.Text = BicConvert.ToString(articleEntity.Link);
        txtAllowUser.Text = BicConvert.ToString(articleEntity.AllowUsers);
        chkCommentEnable.Checked = BicConvert.ToBoolean(articleEntity.CommentsEnabled);
        //chkHome.Checked = BicConvert.ToBoolean(articleEntity.IsHome);
        //RelatedArticle1.MenuUserId = 0 + MenuUserBiz.GetCheckedNodes(tvMenuUser);
        RelatedArticle1.RelatedArticleId = articleEntity.TinLienQuan;
        ismImageId.ImageIDArray = articleEntity.ImageArray;
        ddlTypeNews.SelectedValue = "1";
        chkNew.Checked = BicConvert.ToBoolean(articleEntity.IsNew);
        chkIsActive.Checked = BicConvert.ToBoolean(articleEntity.IsActive);
        ddlLanguage.SelectedValue = articleEntity.LanguageKey;
        cbTarget.SelectedValue = articleEntity.Target;
        txtVote.Text = articleEntity.VoteCount.ToString();
        txtPageTitle.Text = articleEntity.PageTitle;
        txtSeoTitle.Text = articleEntity.SeoTitle;
        chkIsFull.Checked = articleEntity.IsFull;
        txtTag.Text = articleEntity.Tag;
        ddlTintieudiem.SelectedValue = articleEntity.TinTieuDiem.ToString();
        ntxPosition.Text = articleEntity.Priority.ToString();
        txtMetaDescription.Text = articleEntity.MetaDescription;
        txtMetaKeyword.Text = articleEntity.MetaKeyWord;

        MenuUserUtils.BindingRadTreeView(tvMenuUser, ddlLanguage.SelectedValue, "video", "cot1");
        MenuUserUtils.BindingRadTreeView(RadTreeView1, ddlLanguage.SelectedValue, "video", "cot2");
        MenuUserUtils.BindingRadTreeView(RadTreeView2, ddlLanguage.SelectedValue, "video", "cot3");
        tvMenuUser.ExpandAllNodes();
        RadTreeView1.ExpandAllNodes();
        RadTreeView2.ExpandAllNodes();
        MenuUserUtils.SetCheckedNodes(tvMenuUser, articleEntity.MenuUserID);
        MenuUserUtils.SetCheckedNodes(RadTreeView1, articleEntity.MenuUserID);
        MenuUserUtils.SetCheckedNodes(RadTreeView2, articleEntity.MenuUserID);
        hdTreeMenu.Value = articleEntity.MenuUserID;

        reBody.CssFiles.Add(articleEntity.IsFull
                                ? new EditorCssFile("~/BICSkins/BICCMS/Editor/EditorContentAreaStylesFull.css")
                                : new EditorCssFile("~/BICSkins/BICCMS/Editor/EditorContentAreaStyles.css"));
    }

    private ArticleEntity LoadDataToEntity()
    {
        ArticleEntity articleEntity = ArticleBiz.GetArticleByID(_id);

        articleEntity.ArticleID = BicHtml.GetRequestString("id", 0);
        articleEntity.Title = txtTitle.Text;
        articleEntity.VoteCount = BicConvert.ToInt32(txtVote.Text);
        articleEntity.LanguageKey = ddlLanguage.SelectedValue;
        articleEntity.BriefDescription = Server.HtmlDecode(reBriefDescription.Content);
        articleEntity.Body = Server.HtmlDecode(reBody.Content);
        articleEntity.CreatedDate = DateTime.Now;
        articleEntity.MenuUserID = "," + BicString.Trim(hdTreeMenu.Value.Replace(",,", ",")) + ",";
        articleEntity.CommentsEnabled = chkCommentEnable.Checked;
        articleEntity.IsHome = chkIsHome.Checked;
        articleEntity.IsActive = chkIsActive.Checked;
        articleEntity.IsNew = chkNew.Checked;
        articleEntity.ImageID = BicConvert.ToInt32(isImageId.ImageID);
        articleEntity.Priority = BicConvert.ToInt32(ntxPosition.Text);
        articleEntity.Target = cbTarget.SelectedValue;
        articleEntity.Source = txtSource.Text;
        articleEntity.Link = txtLink.Text;
        articleEntity.CreatedBy = HttpContext.Current.User.Identity.Name;
        articleEntity.ModifiedBy = HttpContext.Current.User.Identity.Name;
        articleEntity.AllowUsers = txtAllowUser.Text;
        articleEntity.ViewCount = BicConvert.ToInt32(txtViewCount.Text);
        articleEntity.PageTitle = txtPageTitle.Text;
        articleEntity.SeoTitle = txtSeoTitle.Text;
        articleEntity.Tag = txtTag.Text;
        articleEntity.TinTieuDiem = BicConvert.ToInt32(ddlTintieudiem.SelectedValue);
        articleEntity.TinLienQuan = RelatedArticle1.RelatedArticleId;
        articleEntity.ImageArray = ismImageId.ImageIDArray;
        articleEntity.TypeOfControl = 3;
        articleEntity.VideoID = BicConvert.ToInt32(isVideoID.VideoID);
        articleEntity.VideoArray = string.Empty;
        articleEntity.MetaDescription = txtMetaDescription.Text;
        articleEntity.MetaKeyWord = txtMetaKeyword.Text;
        articleEntity.IsFull = chkIsFull.Checked;
        return articleEntity;
    }

    private void SaveTags(string tags, int ID)
    {
        string[] arrTag = tags.Split(new[] {',', ';'}, StringSplitOptions.RemoveEmptyEntries);
        TagEntity tag;
        string[] oldTags = ArticleBiz.GetArticleByID(ID).Tag.Split(new[] {',', ';'},
                                                                   StringSplitOptions.RemoveEmptyEntries);
        foreach (string item in arrTag)
        {
            if (Array.IndexOf(oldTags, item) < 0)
            {
                tag = TagBiz.GetTagByKey(item.Trim().ToLower(), 1);
                if (tag != null)
                {
                    tag.Id += ID + ",";
                    TagBiz.UpdateTag(tag);
                }
                else
                {
                    tag = new TagEntity
                              {
                                  Id = "," + ID + ",",
                                  Keyword = item.Trim().ToLower(),
                                  IsActive = true,
                                  Priority = 1,
                                  TypeID = 1,
                              };
                    TagBiz.InsertTag(tag);
                }
            }
        }
        foreach (string item in oldTags)
        {
            if (Array.IndexOf(arrTag, item) < 0)
            {
                tag = TagBiz.GetTagByKey(item, 1);
                if (tag != null)
                {
                    tag.Id = tag.Id.Replace("," + ID + ",", ",");
                    TagBiz.UpdateTag(tag);
                }
            }
        }
    }

    protected void Save(object sender, CommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Update")
            {
                if (tvMenuUser.CheckedNodes.Count == 0 && RadTreeView1.CheckedNodes.Count == 0 &&
                    RadTreeView2.CheckedNodes.Count == 0)
                {
                    BicAjax.Alert(string.Format(BicResource.GetValue("Admin", "Admin_Article_Message4")));
                }
                else
                {
                    ArticleEntity article = LoadDataToEntity();
                    SaveTags(txtTag.Text, article.ArticleID);
                    ArticleBiz.UpdateArticle(article);
                    RemoveCache();
                    BicAdmin.NavigateToList();
                }
            }
        }
        catch (Exception ex)
        {
            BicAjax.Alert(ex.Message);
        }
    }

    protected void ddlLanguage_SelectedIndexChanged(object o, EventArgs e)
    {
        BicSession.SetValue("ArticleLanguage", ddlLanguage.SelectedValue);
        MenuUserUtils.BindingRadTreeView(tvMenuUser, ddlLanguage.SelectedValue, "video", "cot1");
        MenuUserUtils.BindingRadTreeView(RadTreeView1, ddlLanguage.SelectedValue, "video", "cot2");
        MenuUserUtils.BindingRadTreeView(RadTreeView2, ddlLanguage.SelectedValue, "video", "cot3");
        RelatedArticle1.Lang = ddlLanguage.SelectedValue;
    }
}