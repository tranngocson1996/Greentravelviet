using System;
using System.Web.UI.WebControls;
using BIC.Utils;
using BIC.WebControls;

public partial class Controls_Language : BaseUIControl
{
    public string TextLanguge;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        switch (BicLanguage.CurrentLanguage)
        {
            case "vi":
                TextLanguge = "VIETNAM";
                ltrCoverImage.Text = string.Format("<img src='/Styles/images/vi.jpg' class='img-logolang' />");
                break;
            case "en":
                TextLanguge = "ENGLISH";
                ltrCoverImage.Text = string.Format("<img src='/Styles/images/en.png' class='img-logolang' />");
                break;
        }
    }

    protected void LanguageCommand(object sender, CommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "vi":
                Response.Redirect(string.Format("{0}vi/trang-chu.html", BicApplication.URLRoot));
                break;
            case "en":
                Response.Redirect(string.Format("{0}en/home.html", BicApplication.URLRoot));
                break;
        }
    }
}