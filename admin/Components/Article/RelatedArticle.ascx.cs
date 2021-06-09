using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using BIC.Data;
using BIC.Utils;
using BIC.WebControls;

public partial class admin_Components_Article_RelatedArticle : BaseUserControl
{
    public string Lang
    {
        get
        {
            object obj = ViewState["LanguageKey"];
            return string.IsNullOrEmpty(Convert.ToString(obj)) ? string.Empty : (string)obj;
        }
        set { ViewState["LanguageKey"] = value; }
    }

    private DataTable RelatedList
    {
        get { return (DataTable)ViewState["RelatedArticle"]; }
        set { ViewState["RelatedArticle"] = value; }
    }

    public int totalItem
    {
        get { return BicConvert.ToInt32(ViewState["TotalItem"]); }
        set { ViewState["TotalItem"] = value; }
    }

    public string RelatedArticleId
    {
        get
        {
            object obj = ViewState["RelatedArticleId"];
            return string.IsNullOrEmpty(Convert.ToString(obj)) ? string.Empty : (string)obj;
        }
        set { ViewState["RelatedArticleId"] = value; }
    }

    public ArrayList RelatedArticleIds
    {
        get
        {
            var a = new ArrayList();
            a.AddRange(RelatedArticleId.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
            return a;
        }
    }

    public string MenuUserId
    {
        set { lvRelatedArticle.MenuUserId = value; }
    }

    private DataTable LoadArticle()
    {
        if (string.IsNullOrEmpty(RelatedArticleId))
            return null;
        var bicData = new BicGetData("Article");
        bicData.Selecting.Add("ArticleId,Title");
        bicData.Conditioning.Add(new ConditioningItem
                                     {
                                         Query = "ArticleId in (" + RelatedArticleId + ")",
                                         TypeOfCondition = TypeOfCondition.QUERY
                                     });
        bicData.Sorting.Add(
            new SortingItem("(CharIndex(',' + CONVERT(NVARCHAR,ArticleId) +',','," + RelatedArticleId + ",'))", false));
        return bicData.GetAllData();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (RelatedList == null)
            {
                RelatedList = LoadArticle();
                if (RelatedList == null || RelatedList.Rows.Count == 0)
                {
                    RelatedList = new DataTable();
                    RelatedList.Columns.Add("ArticleId");
                    RelatedList.Columns.Add("Title");
                }
                lvArticle.DataSource = RelatedList;
                lvArticle.DataBind();
            }
            GetValue();
        }
        pRelatedArticle.PageIndex = lvRelatedArticle.PageIndex;
        pRelatedArticle.PageSize = lvRelatedArticle.PageSize;
        pRelatedArticle.TotalItems = totalItem;
    }

    public void GetValue()
    {
        lvRelatedArticle.IgnoreArticleId = BicHtml.GetRequestString("id", "0");
        if (!string.IsNullOrEmpty(txtFilter.Text.Trim()))
        {
            lvRelatedArticle.QueryCondition =
                string.Format("LanguageKey = '{0}' and TypeOfControl={1} and Title like N'%{2}%'", Lang, 1,
                              txtFilter.Text.Trim());
        }
        else
        {
            lvRelatedArticle.QueryCondition = string.Format("LanguageKey = '{0}' and TypeOfControl={1} ", Lang, 1);
        }
        lvRelatedArticle.LoadData();
        totalItem = lvRelatedArticle.TotalItem;
    }

    protected void pRelatedArticle_OnPageIndexChanged(object sender, PagerUIEventArgs e)
    {
        lvRelatedArticle.PageIndex = pRelatedArticle.PageIndex = e.NewPageIndex;
        GetValue();
    }

    protected void BtSearchClick(object sender, EventArgs e)
    {
        GetValue();
        lvRelatedArticle.PageIndex = pRelatedArticle.PageIndex = 0;
        pRelatedArticle.PageSize = lvRelatedArticle.PageSize;
        pRelatedArticle.TotalItems = totalItem;
    }

    protected void lvRelatedArticle_OnItemDataBound(object sender, ListViewItemEventArgs e)
    {
        var drv = (DataRowView)e.Item.DataItem;
        var chk = (CheckBox)e.Item.FindControl("chkRelated");
        if (drv != null)
        {
            chk.Checked = (RelatedArticleIds.IndexOf(drv["ArticleId"].ToString()) >= 0);
        }
    }

    protected void chkRelated_OnCheckedChanged(object sender, EventArgs e)
    {
        var relatedArticleIds = new ArrayList();
        relatedArticleIds.AddRange(RelatedArticleIds);
        var chk = (CheckBox)sender;
        DataRow dr;
        if (!chk.Checked)
        {
            dr = RelatedList.Rows[relatedArticleIds.IndexOf(chk.Attributes["Value"])];
            if (dr != null)
            {
                RelatedList.Rows.Remove(dr);
            }
            relatedArticleIds.Remove(chk.Attributes["Value"]);
        }
        else
        {
            string s = chk.Attributes["Value"];
            relatedArticleIds.Add(s);
            dr = RelatedList.NewRow();
            dr["ArticleId"] = s;
            dr["Title"] = chk.Attributes["Title"];
            RelatedList.Rows.Add(dr);
        }
        RelatedArticleId = relatedArticleIds.ToArray().Aggregate(string.Empty,
                                                                 (current, articleId) =>
                                                                 current +
                                                                 ((current == string.Empty ? "" : ",") + articleId));
        lvArticle.DataSource = RelatedList;
        lvArticle.DataBind();
    }

    protected void articleRemove_Command(object sender, CommandEventArgs e)
    {
        var relatedArticleIds = new ArrayList();
        relatedArticleIds.AddRange(RelatedArticleIds);
        DataRow dr = RelatedList.Rows[Convert.ToInt32(e.CommandName)];
        if (dr != null)
        {
            RelatedList.Rows.Remove(dr);
        }
        relatedArticleIds.Remove(e.CommandArgument.ToString());
        RelatedArticleId = relatedArticleIds.ToArray().Aggregate(string.Empty,
                                                                 (current, articleId) =>
                                                                 current +
                                                                 ((current == string.Empty ? "" : ",") + articleId));
        lvArticle.DataSource = RelatedList;
        lvArticle.DataBind();
    }

    protected void Unnamed_Click(object sender, EventArgs e)
    {
        listSelect.Visible = false;
        overlay.Visible = false;
    }

    protected void Unnamed_Click1(object sender, EventArgs e)
    {
        listSelect.Visible = true;
        overlay.Visible = true;
        GetValue();
    }
}