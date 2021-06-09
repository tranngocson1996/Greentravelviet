using System;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

public class Include
{
    public static StringBuilder Sb;
    public static string RootCssStyle = "~/Styles/{0}";
    public static string RootCssControl = "~/Controls/{0}";
    public static string RootJs = "~/Scripts/{0}";
    public static string RootBicSkin = "~/BICSkins/Menu/{0}";
    public static string RootBicSkin2 = "~/BICSkins/PanelBar/{0}";

    #region Include Default
    public static string DefaultCss()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootCssStyle, "style.css")));
        Sb.Append(CssAdd(string.Format(RootCssStyle, "responsive.css")));
        return Sb.ToString();
    }
    /// <summary>
    /// Bootstrap fix row margin -10px container 1200px, Animate, Font-Awesome (xxx.min.css)
    /// </summary>
    /// <returns></returns>
    public static string LibraryCss()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootCssStyle, "lib/font-awesome.min.css")));
        Sb.Append(CssAdd(string.Format(RootCssStyle, "lib/bootstrap.min.css")));
        Sb.Append(CssAdd(string.Format(RootCssStyle, "lib/animate.min.css")));
        return Sb.ToString();
    }

    #endregion Include Default

    #region Jquery
    /// <summary>
    /// Jquery, Jquery UI, Bootstrap JS, WOW JS
    /// </summary>
    /// <returns></returns>
    public static string JqueryUI()
    {
        Sb = new StringBuilder();
        Sb.Append(JsAdd(string.Format(RootJs, "jquery-3.3.1.min.js")));
        Sb.Append(JsAdd(string.Format(RootJs, "bootstrap.min.js")));
        return Sb.ToString();
    }
    public static string ShoppingCart()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootCssStyle, "Reset.css")));
        Sb.Append(CssAdd(string.Format(RootJs, "wowjs/animate.css")));
        Sb.Append(CssAdd(string.Format(RootCssStyle, "lib/font-awesome.min.css")));
        Sb.Append(CssAdd(string.Format(RootCssStyle, "lib/bootstrap.min.css")));
        Sb.Append(CssAdd(string.Format(RootCssControl, "ShoppingCart/ShoppingCart.css")));
        return Sb.ToString();
    }
    public static string MainJs()
    {
        Sb = new StringBuilder();
        Sb.Append(JsAdd(string.Format(RootJs, "main.js")));
        return Sb.ToString();
    }
    public static string SlideToLock()
    {
        Sb = new StringBuilder();
        //Sb.Append(JsAdd(string.Format(RootJs, "slidetounlock.js")));
        Sb.Append(CssAdd(string.Format(RootJs, "slideToLock.css")));
        return Sb.ToString();
    }
    public static string Lofslidernews()
    {
        Sb = new StringBuilder();
        Sb.Append(JsAdd(string.Format(RootJs, "lofslidernews/js/jquery.easing.js")));
        Sb.Append(JsAdd(string.Format(RootJs, "lofslidernews/js/script.js")));
        Sb.Append(CssAdd(string.Format(RootJs, "lofslidernews/css/style2.css")));
        return Sb.ToString();
    }
    public static string Scroll()
    {
        Sb = new StringBuilder();
        Sb.Append(JsAdd(string.Format(RootJs, "scroll/js/jquery.tinyscrollbar.min.js")));
        Sb.Append(CssAdd(string.Format(RootJs, "scroll/css/website.css")));
        return Sb.ToString();
    }

    public static string Jszoom()
    {
        Sb = new StringBuilder();
        Sb.Append(JsAdd(string.Format(RootJs, "jszoom/jquery.jqzoom-core-pack.js")));
        Sb.Append(CssAdd(string.Format(RootJs, "jszoom/jquery.jqzoom.css")));
        return Sb.ToString();
    }
    public static string Scrollbar()
    {
        Sb = new StringBuilder();
        Sb.Append(JsAdd(string.Format(RootJs, "jquery-ui/js/jquery.mCustomScrollbar.js")));
        return Sb.ToString();
    }

    public static string HighSlide()
    {
        Sb = new StringBuilder();
        Sb.Append(JsAdd(string.Format(RootJs, "highslide/highslide-full.packed.js")));
        Sb.Append(CssAdd(string.Format(RootJs, "highslide/highslide-ie6.css")));
        Sb.Append(CssAdd(string.Format(RootJs, "highslide/highslide.css")));
        return Sb.ToString();
    }

    public static string ColorBox()
    {
        Sb = new StringBuilder();
        Sb.Append(JsAdd(string.Format(RootJs, "colorbox/jquery.colorbox.js")));
        Sb.Append(CssAdd(string.Format(RootJs, "colorbox/colorbox.css")));
        return Sb.ToString();
    }

    public static string Autocomplete()
    {
        Sb = new StringBuilder();
        Sb.Append(JsAdd(string.Format(RootJs, "jquery.autocomplete/jquery.autocomplete.min.js")));
        Sb.Append(CssAdd(string.Format(RootJs, "jquery.autocomplete/jquery.autocomplete.css")));
        return Sb.ToString();
    }

    public static string Simplemodal()
    {
        Sb = new StringBuilder();
        Sb.Append(JsAdd(string.Format(RootJs, "jquery.simplemodal.js")));
        return Sb.ToString();
    }

    #endregion Jquery

    #region Thư viện Js Chuẩn 2018 - bởi Kỹ thuật BIC
    /// <summary>
    /// Wow Js + Animation Css
    /// </summary>
    /// <returns>wow.js, animation.css</returns>
    public static string WowJs()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootJs, "wowjs/animate.min.css")));
        Sb.Append(JsAdd(string.Format(RootJs, "wowjs/wow.min.js")));
        return Sb.ToString();
    }
    /// <summary>
    /// AOS Js
    /// </summary>
    /// <returns>aos.js, aos.css</returns>
    public static string AOS()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootJs, "aos/aos.css")));
        Sb.Append(JsAdd(string.Format(RootJs, "aos/aos.js")));
        return Sb.ToString();
    }
    /// <summary>
    /// MeanMenu mobile
    /// </summary>
    /// <returns></returns>
    public static string MeanMenu()
    {
        Sb = new StringBuilder();
        Sb.Append(JsAdd(string.Format(RootJs, "meanMenu/jquery.meanmenu.js")));
        return Sb.ToString();
    }
    /// <summary>
    /// Owl Carousel 2.0
    /// </summary>
    /// <returns></returns>
    public static string OwlCarousel()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootJs, "owl-carousel/assets/owl.carousel.css")));
        //Sb.Append(CssAdd(string.Format(RootJs, "owl-carousel/assets/owl.transitions.css")));
        Sb.Append(JsAdd(string.Format(RootJs, "owl-carousel/owl.carousel.min.js")));
        return Sb.ToString();
    }
    /// <summary>
    /// Unite Gallery
    /// </summary>
    /// <returns></returns>
    public static string Unitegallery()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootJs, "unitegallery/css/unite-gallery.css")));
        Sb.Append(CssAdd(string.Format(RootJs, "unitegallery/themes/default/ug-theme-default.css")));
        Sb.Append(JsAdd(string.Format(RootJs, "unitegallery/js/unitegallery.min.js")));
        Sb.Append(JsAdd(string.Format(RootJs, "unitegallery/themes/default/ug-theme-default.js")));
        return Sb.ToString();
    }
    /// <summary>
    /// VenoBox
    /// </summary>
    /// <returns></returns>
    public static string VenoBox()
    {
        Sb = new StringBuilder();
        Sb.Append(JsAdd(string.Format(RootJs, "venobox/venobox.min.js")));
        Sb.Append(CssAdd(string.Format(RootJs, "venobox/venobox.css")));
        return Sb.ToString();
    }
    /// <summary>
    /// BxSlider
    /// </summary>
    /// <returns></returns>
    public static string bxSlider()
    {
        Sb = new StringBuilder();
        Sb.Append(JsAdd(string.Format(RootJs, "bxslider/jquery.bxslider.min.js")));
        Sb.Append(CssAdd(string.Format(RootJs, "bxslider/jquery.bxslider.css")));
        return Sb.ToString();
    }
    /// <summary>
    /// Sticky Sidebar
    /// </summary>
    /// <returns>theia-sticky-sidebar.min.js</returns>
    public static string StickSidebar()
    {
        Sb = new StringBuilder();
        Sb.Append(JsAdd(string.Format(RootJs, "sticky-sidebar/theia-sticky-sidebar.min.js")));
        return Sb.ToString();
    }
    /// <summary>
    /// JwPlayer7
    /// </summary>
    /// <returns></returns>
    public static string Jwplayer7()
    {
        Sb = new StringBuilder();
        Sb.Append(JsAdd(string.Format(RootJs, "jwplayer7/jwplayer.js")));
        return Sb.ToString();
    }
    #endregion

    #region Menu

    public static string Menu(string path)
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootBicSkin, path)));
        return Sb.ToString();
    }

    #endregion Menu

    #region Slide

    public static string CarouFredSel()
    {
        Sb = new StringBuilder();
        Sb.Append(JsAdd(string.Format(RootJs, "carouFredSel/jquery.carouFredSel-6.2.1-packed.js")));
        return Sb.ToString();
    }

    public static string Cycle()
    {
        Sb = new StringBuilder();
        Sb.Append(JsAdd(string.Format(RootJs, "jquery-slide/jquery.cycle.all.min.js")));
        return Sb.ToString();
    }

    public static string NivoSlider()
    {
        Sb = new StringBuilder();
        Sb.Append(JsAdd(string.Format(RootJs, "nivo-slider/jquery.nivo.slider.pack.js")));
        Sb.Append(CssAdd(string.Format(RootJs, "nivo-slider/nivo-slider.css")));
        return Sb.ToString();
    }

    public static string Slides()
    {
        Sb = new StringBuilder();
        Sb.Append(JsAdd(string.Format(RootJs, "slides/slides.min.jquery.js")));
        Sb.Append(CssAdd(string.Format(RootJs, "slides/slides.css")));
        return Sb.ToString();
    }

    public static string Tooltipsy()
    {
        ScriptToBottom("tooltipsy.min.js");
        return string.Empty;
    }

    public static string Infieldlabel()
    {
        Sb = new StringBuilder();
        Sb.Append(JsAdd(string.Format(RootJs, "jquery.infieldlabel.min.js")));
        return Sb.ToString();
    }

    public static string Charcounter()
    {
        Sb = new StringBuilder();
        Sb.Append(JsAdd(string.Format(RootJs, "jquery.charcounter.js")));
        return Sb.ToString();
    }

    #endregion Slide
    public static string Tooltip()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootJs, "tooltip/stickytooltip.css")));
        Sb.Append(JsAdd(string.Format(RootJs, "tooltip/stickytooltip.js")));
        return Sb.ToString();
    }
    public static string fancybox()
    {
        Sb = new StringBuilder();
        Sb.Append(JsAdd(string.Format(RootJs, "fancybox/jquery.fancybox.pack.js")));
        Sb.Append(CssAdd(string.Format(RootJs, "fancybox/jquery.fancybox.css")));
        return Sb.ToString();
    }
    public static string Scrollbox()
    {
        Sb = new StringBuilder();
        Sb.Append(JsAdd(string.Format(RootJs, "scrollbox/jquery.scrollbox.js")));
        return Sb.ToString();
    }
    public static string DatePicker()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootJs, "datepicker/bootstrap-datepicker.min.css")));
        Sb.Append(JsAdd(string.Format(RootJs, "datepicker/bootstrap-datepicker.min.js")));
        return Sb.ToString();
    }

    public static string Mmenu()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootJs, "mmenu/jquery.mmenu.all.css")));
        Sb.Append(JsAdd(string.Format(RootJs, "mmenu/jquery.mmenu.min.all.js")));
        Sb.Append(CssAdd(string.Format(RootCssControl, "Menu/Menu.css")));
        return Sb.ToString();
    }

    public static string Menu()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootCssControl, "Menu/Menu.css")));
        return Sb.ToString();
    }
    public static string Bpopup()
    {
        Sb = new StringBuilder();
        Sb.Append(JsAdd(string.Format(RootJs, "bpopup/jquery.bpopup.min.js")));
        return Sb.ToString();
    }
    public static string NavigatePath()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootCssControl, "Navigate/NavPath.css")));
        return Sb.ToString();
    }
    public static string FAQOld()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootCssControl, "FAQ/FAQOld.css")));
        Sb.Append(JsAdd(string.Format(RootCssControl, "FAQ/FAQ.js")));
        return Sb.ToString();
    }

    #region Style Control

    public static string Adv()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootCssControl, "Adv/Adv.css")));
        return Sb.ToString();
    }

    public static string Footer()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootCssControl, "Footer/Footer.css")));
        return Sb.ToString();
    }

    public static string Voting()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootCssControl, "Voting/Voting.css")));
        return Sb.ToString();
    }

    public static string FAQ()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootCssControl, "FAQ/FAQ.css")));
        Sb.Append(JsAdd(string.Format(RootCssControl, "FAQ/FAQ.js")));
        return Sb.ToString();
    }

    public static string Gallery()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootCssControl, "Gallery/Gallery.css")));
        Sb.Append(JsAdd(string.Format(RootCssControl, "Gallery/Gallery.js")));
        return Sb.ToString();
    }

    public static string Article()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootCssControl, "Article/Article.css")));
        return Sb.ToString();
    }
    public static string ArticleFullRight()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootCssControl, "ArticleFullRight/ArticleFullRight.css")));
        return Sb.ToString();
    }

    public static string QuanHeCoDong()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootCssControl, "QuanHeCoDong/QuanHeCoDong.css")));
        return Sb.ToString();
    }

    public static string ArticleToolbar()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootCssControl, "Article/Tools/Toolbar.css")));
        return Sb.ToString();
    }

    public static string Contact()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootCssControl, "Contact/Contact.css")));
        return Sb.ToString();
    }

    public static string Comment()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootCssControl, "Comment/Comment.css")));
        return Sb.ToString();
    }
    public static string Slick()
    {
        Sb = new StringBuilder();
        Sb.Append(JsAdd(string.Format(RootJs, "slick/slick.js")));
        Sb.Append(CssAdd(string.Format(RootJs, "slick/slick.css")));
        Sb.Append(CssAdd(string.Format(RootJs, "slick/slick-theme.css")));
        return Sb.ToString();
    }
    public static string Download()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootCssControl, "Document/Download.css")));
        Sb.Append(JsAdd(string.Format(RootCssControl, "Document/Download.js")));
        return Sb.ToString();
    }

    public static string Language()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootCssControl, "Language/Language.css")));
        return Sb.ToString();
    }

    public static string LiveSupport()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootCssControl, "LiveSupport/LiveSupport.css")));
        return Sb.ToString();
    }

    public static string Navigate()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootCssControl, "Navigate/Navigate.css")));
        return Sb.ToString();
    }

    public static string Product()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootCssControl, "Product/Product.css")));
        Sb.Append(JsAdd(string.Format(RootCssControl, "Product/Product.js")));
        return Sb.ToString();
    }
    public static string DistributionSystem()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootCssControl, "DistributionSystem/DistributionSystem.css")));
        return Sb.ToString();
    }

    public static string ProductToolbar()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootCssControl, "Product/Tools/Toolbar.css")));
        return Sb.ToString();
    }

    public static string Search()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootCssControl, "Search/Search.css")));
        return Sb.ToString();
    }

    public static string Login()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootCssControl, "User/Login.css")));
        Sb.Append(JsAdd(string.Format(RootCssControl, "User/Login.js")));
        return Sb.ToString();
    }

    public static string LoginStatus()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootCssControl, "User/LoginStatus.css")));
        Sb.Append(JsAdd(string.Format(RootCssControl, "User/LoginStatus.js")));
        return Sb.ToString();
    }



    public static string UserProfile()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootCssControl, "User/UserProfile.css")));
        return Sb.ToString();
    }

    public static string Video()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootCssControl, "Video/Video.css")));
        return Sb.ToString();
    }

    public static string ShareByEmail()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootCssControl, "Tools/ShareByEmail.css")));
        return Sb.ToString();
    }

    public static string PrintArticle()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootCssControl, "Tools/PrintArticle.css")));
        return Sb.ToString();
    }

    public static string PrintProduct()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootCssControl, "Tools/PrintProduct.css")));
        return Sb.ToString();
    }

    #endregion Style Control

    #region CssMedthod

    public static string CssAdd(string path)
    {
        string result = string.Empty;
        var page = HttpContext.Current.Handler as Page;
        const string mark = "<link type='text/css'  rel='stylesheet' href='{0}' />";
        if (page != null) result = string.Format(mark, page.ResolveUrl(path));
        return result;
    }
    public static bool CssToTop(string filename)
    {
        try
        {
            var page = (Page)HttpContext.Current.Handler;
            var header = page.Header;
            var link = (HtmlGenericControl)header.FindControl("lnkCss");
            filename += filename.EndsWith(".css") ? "" : ".css";
            filename = filename.Replace("..", ".").Replace(",", ".css,").Replace(".css.css", ".css");

            if (link != null)
            {
                var linkhref = link.Attributes["href"].ToString();
                var s = string.Empty;
                foreach (var item in filename.Split(',').Where(item => !string.IsNullOrEmpty(item) && !linkhref.Contains(item) && !s.Contains(item)))
                {
                    s += (s != string.Empty ? "," : string.Empty) + item;
                }
                linkhref += (linkhref.Contains("?files=") ? "," : "?files=") + s;
                link.Attributes["href"] = page.ResolveUrl(linkhref);
            }
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public static bool CssToTop(string[] filename)
    {
        var file = string.Empty;
        foreach (string s in filename)
        {
            file += s + (s.EndsWith(".css") ? "," : ".css,");
            file = file.Replace("..", ".");
        }
        file.Remove(file.Length);
        return CssToTop(file);
    }

    #endregion CssMedthod

    #region JsMedthod

    public static string JsAdd(string path)
    {
        var result = string.Empty;
        var page = HttpContext.Current.Handler as Page;
        const string mark = "<script type='text/javascript' src='{0}'></script>";
        if (page != null)
        {
            result = string.Format(mark, page.ResolveUrl(path));
            page.RegisterClientScriptBlock("bic", result);
        }
        return result;
    }

    public static bool ScriptToBottom(string filename)
    {
        try
        {
            var page = (Page)HttpContext.Current.Handler;
            var ltScript = (Literal)(page.Form.FindControl("ltScript"));
            var script = "<script type='text/javascript' src='{0}'></script>";
            var regex = "src\\=\\'.+?\\'";
            if (ltScript == null || ltScript.Text.Contains(filename)) return false;
            if (string.IsNullOrEmpty(ltScript.Text))
            {
                ltScript.Text = string.Format(script, page.ResolveUrl("~/Scripts/Bicweb.ashx?files=" + filename));
            }
            else
            {
                var m = Regex.Match(ltScript.Text, regex).ToString().Replace("src='", string.Empty).Replace("'", "," + filename);
                ltScript.Text = string.Format(script, m);
            }
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public static string JsUserAdd(params string[] a)
    {
        return JsAdd("~/Scripts/" + a);
    }

    #endregion JsMedthod

    public static string JqueryUi()
    {
        Sb = new StringBuilder();
        Sb.Append(JsAdd(string.Format(RootJs, "jquery-ui/jquery-ui.js")));
        Sb.Append(CssAdd(string.Format(RootJs, "jquery-ui/jquery-ui.css")));
        return Sb.ToString();
    }
}

public static class ExtStringForInclude
{
    #region AddToHead

    // Using on Page Load
    public static void ToHeader(this string a)
    {
        var page = HttpContext.Current.Handler as Page;
        if (page != null) page.Header.Controls.Add(new LiteralControl(a));
    }

    #endregion AddToHead
}