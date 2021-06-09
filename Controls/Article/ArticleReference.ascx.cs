using System;
using BIC.Utils;
using BIC.WebControls;
using System.Globalization;

public partial class Controls_Article_ArticleReference : BaseUIControl
{
    public int ArticleId { get; set; }
    public string MenuUserId { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;

        lvReference.MenuUserId = MenuUserId;
        // End Code
        lvReference.IgnoreArticleId = ArticleId.ToString();
        lvReference.ArticleId = ArticleId;
        lvReference.PageSize = 3;
        lvReference.LoadData();
        Visible = lvReference.Items.Count > 0;
    }
    public string CovertDate(string date)
    {
        var day = BicConvert.ToDateTime(date).ToString("dd", CultureInfo.CreateSpecificCulture("en-US"));
        var mouth = BicConvert.ToDateTime(date).ToString("MM", CultureInfo.CreateSpecificCulture("en-US"));
        //var year = BicConvert.ToDateTime(date).ToString("yyyy", CultureInfo.CreateSpecificCulture("en-US"));
        return string.Format("<span class=\"day\">{0}<br></span><span class=\"month\">tháng {1}</span>", day, mouth);
    }
}