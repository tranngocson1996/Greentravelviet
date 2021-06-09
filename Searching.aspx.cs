using System;
using BIC.WebControls;
using BIC.Utils;

public partial class Searching : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Page.Title = BicLanguage.CurrentLanguage == "vi" ? "Tìm kiếm" : "Searching";
        }
    }
}