using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Handler;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_Article_AdditionArticle : BaseUserControl
{
    private int _id;

    //public void PositionWithPriorityAdd()
    //{
    //    try
    //    {
    //        var dh = new DataHelper();
    //        int maxPosition = BicConvert.ToInt32(dh.CountItem("ArticleId", "Article"));
    //        ntxPosition.MaxValue = maxPosition;
    //    }
    //    catch (Exception ex)
    //    {
    //        LogEvent.LogToFile(ex.ToString());
    //    }
    //}

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

    protected void Page_Load(object sender, EventArgs e)
    {
        _id = BicHtml.GetRequestString("id", 0);
        if (!IsPostBack)
        {
            if (BicSession.ToString("ArticleLanguage") != string.Empty)
                ddlLanguage.SelectedValue = BicSession.ToString("ArticleLanguage");
            MenuUserUtils.BindingRadTreeView(tvMenuUser, ddlLanguage.SelectedValue, "video", "cot1");
            MenuUserUtils.BindingRadTreeView(RadTreeView1, ddlLanguage.SelectedValue, "video", "cot2");
            MenuUserUtils.BindingRadTreeView(RadTreeView2, ddlLanguage.SelectedValue, "video", "cot3");
            tvMenuUser.ExpandAllNodes();
            RadTreeView1.ExpandAllNodes();
            RadTreeView2.ExpandAllNodes();
           // PositionWithPriorityAdd();
            ddlTypeNews.Items.Clear();

            BicXML.BindDropDownListFromXML(ddlTintieudiem, "~/admin/XMLData/Tintieudiem.xml");
            BicXML.BindDropDownListFromXML(ddlTypeNews, "~/admin/XMLData/ModelNews.xml");
            //ArticleBiz.PositionWithPriorityEdit(ddlPosition);
            if (_id != 0)
            {
                LoadDataFromEntity();
            }
            RelatedArticle1.Lang = ddlLanguage.SelectedValue;
        }
    }

    private void LoadDataFromEntity()
    {
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
        txtMetaDescription.Text = articleEntity.MetaDescription;
        txtMetaKeyword.Text = articleEntity.MetaKeyWord;
    }

    private ArticleEntity LoadDataToEntity()
    {
        var articleEntity = new ArticleEntity
                                {
                                    Title = txtTitle.Text,
                                    VoteCount = BicConvert.ToInt32(txtVote.Text),
                                    LanguageKey = ddlLanguage.SelectedValue,
                                    BriefDescription = Server.HtmlDecode(reBriefDescription.Content),
                                    Body = Server.HtmlDecode(reBody.Content),
                                    CreatedDate = DateTime.Now,
                                    MenuUserID = "," + BicString.Trim(hdTreeMenu.Value.Replace(",,", ",")) + ",",
                                    CommentsEnabled = chkCommentEnable.Checked,
                                    IsHome = chkIsHome.Checked,
                                    IsActive = chkIsActive.Checked,
                                    IsNew = chkNew.Checked,
                                    ImageID = BicConvert.ToInt32(isImageId.ImageID),
                                    Priority = BicConvert.ToInt32(ntxPosition.Text),
                                    Target = cbTarget.SelectedValue,
                                    Source = txtSource.Text,
                                    Link = txtLink.Text,
                                    CreatedBy = HttpContext.Current.User.Identity.Name,
                                    ModifiedBy = HttpContext.Current.User.Identity.Name,
                                    AllowUsers = txtAllowUser.Text,
                                    ViewCount = BicConvert.ToInt32(txtViewCount.Text),
                                    PageTitle = txtPageTitle.Text,
                                    SeoTitle = txtSeoTitle.Text,
                                    Tag = txtTag.Text,
                                    TinTieuDiem = BicConvert.ToInt32(ddlTintieudiem.SelectedValue),
                                    TinLienQuan = RelatedArticle1.RelatedArticleId,
                                    ImageArray = ismImageId.ImageIDArray,
                                    TypeOfControl = 3,
                                    VideoID = BicConvert.ToInt32(isVideoID.VideoID),
                                    VideoArray = string.Empty,
                                    MetaDescription = txtMetaDescription.Text,
                                    MetaKeyWord = txtMetaKeyword.Text,
                                    IsFull = chkIsFull.Checked
                                };
        return articleEntity;
    }

    protected void Save(object sender, CommandEventArgs e)
    {
        try
        {
            switch (e.CommandName)
            {
                case "AddNew":
                    if (tvMenuUser.CheckedNodes.Count == 0 && RadTreeView1.CheckedNodes.Count == 0 &&
                        RadTreeView2.CheckedNodes.Count == 0)
                    {
                        BicAjax.Alert(string.Format(BicResource.GetValue("Admin", "Admin_Article_Message4")));
                    }
                    else
                    {
                        ArticleEntity article = LoadDataToEntity();
                        ArticleBiz.InsertArticle(article);

                        SaveTags(article.Tag, article.ArticleID);


                        BicAdmin.NavigateToList();
                    }
                    break;
            }
        }
        catch (Exception ex)
        {
            LogEvent.LogToFile(ex.Message);
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


    private void SaveTags(string tags, int ID)
    {
        string[] arrTag = tags.Split(new[] {',', ';'}, StringSplitOptions.RemoveEmptyEntries);
        foreach (string item in arrTag)
        {
            TagEntity tag = TagBiz.GetTagByKey(item.Trim().ToLower(), 1);
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
}