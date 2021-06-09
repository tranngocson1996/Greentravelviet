using System;
using BIC.Utils;
using BIC.WebControls;

public partial class Controls_Social_Like : BaseUIControl
{
    public int ArticleID { get; set; }

    public string Type { get; set; }

    public string SendMailUrl { get; set; }

    public int ViewCount;
    public DateTime ModifiedDate;

    protected void Page_Load(object sender, EventArgs e)
    {
     
    }
}