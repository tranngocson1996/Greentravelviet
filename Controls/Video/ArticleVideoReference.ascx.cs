using System;
using BIC.Utils;
using BIC.WebControls;

public partial class Controls_Video_ArticleVideoReference : BaseUIControl
{
    public int _MenuUserId { get; set; }
    public int _ArticleId { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindingArticleListView();
        }
       
    }
    protected void BindingArticleListView()
    {
        lvReference.MenuUserId = _MenuUserId.ToString();
        lvReference.IgnoreArticleId = _ArticleId.ToString();
        lvReference.Prefix = "vd";
        lvReference.PageSize = 12;
        lvReference.LoadData();
    }
    
}