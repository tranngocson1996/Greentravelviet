using System;
using System.Collections;
using System.Web;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Site : BaseMasterPage
{   
    public Hashtable Hashtable
    {
        set { HttpContext.Current.Session.Add("cart", value); }
        get
        {
            var hashtable = (Hashtable)HttpContext.Current.Session["cart"] ?? new Hashtable();
            return hashtable;
        }
    }
    protected SeoEntity SeoInfo = new SeoEntity();
    public string count = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        var seo = new Seo();
        SeoInfo = seo.GetSeoInfo("ShareLogo.jpg");

        Page.Title = SeoInfo.MetaTitle;
        Page.MetaKeywords = SeoInfo.MetaKeyword;
        Page.MetaDescription = SeoInfo.MetaDescription;
        //count = string.IsNullOrEmpty(BicSession.ToString("TotalQuanlity")) ? "0" : BicSession.ToString("TotalQuanlity");
    }

    public string _Getlink(string url, string name)
    {
        if (url.Contains("{4}/{3}"))
        {
            string link = "/{0}{1}{2}" + url;
            link = string.Format(link, "", "", "", name, BicLanguage.CurrentLanguage);
            return link;
        }
        else
        {
            return url;
        }

    }
}