using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using BIC.Utils;

public class IncludeAdmin
{
    #region Include Default

    public static StringBuilder sb;
    public static string rootCss = "~/admin/Styles/{0}";
    public static string rootJs = "~/admin/Scripts/{0}";
    public static string rootBicSkin = "~/BICSkins/BICCMS/{0}";

    public static string LoginCss()
    {
        sb = new StringBuilder();
        sb.Append(CssAdd(string.Format(rootCss, "Login.css")));
        return sb.ToString();
    }

    public static string DefaultCss()
    {
        sb = new StringBuilder();
        sb.Append(CssAdd(string.Format(rootCss, "Reset.css")));
        sb.Append(CssAdd(string.Format(rootCss, "Layout.css")));
        sb.Append(CssAdd(string.Format(rootCss, "Site.css")));
        return sb.ToString();
    }

    #endregion Include Default

    #region Telerik

    public static string RadEditor()
    {
        sb = new StringBuilder();
        sb.Append(JsAdd(string.Format(rootJs, "telerik/radedit.js")));
        return sb.ToString();
    }


    #endregion Telerik

    #region Jquery

    public static string JqueryUI()
    {
        sb = new StringBuilder();
        sb.Append(JsAdd(string.Format(rootJs, string.Format("clock_{0}.js", !string.IsNullOrEmpty(BicLanguage.CurrentLanguageAdmin) ? BicLanguage.CurrentLanguageAdmin : BicXML.ToString("DefaultLanguage", "SearchEngine")))));
        sb.Append(JsAdd(string.Format(rootJs, "jquery-1.7.1.min.js")));
        sb.Append(JsAdd(string.Format(rootJs, "jquery-ui/js/jquery-framedialog.js")));
        sb.Append(JsAdd(string.Format(rootJs, "jquery-ui/js/jquery-ui-1.8.16.custom.min.js")));
        sb.Append(JsAdd(string.Format(rootJs, "admin.js")));
        sb.Append(CssAdd(string.Format(rootJs, "jquery-ui/css/ui-lightness/jquery-ui-1.8.16.custom.css")));
        return sb.ToString();
    }

    public static string JqueryJcrop()
    {
        sb = new StringBuilder();
        sb.Append(JsAdd(string.Format(rootJs, "jquery.Jcrop/jquery.Jcrop.pack.js")));
        sb.Append(JsAdd(string.Format(rootJs, "jquery.Jcrop/JCropImage.js")));
        sb.Append(CssAdd(string.Format(rootJs, "jquery.Jcrop/jquery.Jcrop.css")));
        return sb.ToString();
    }

    public static string HighSlide()
    {
        sb = new StringBuilder();
        sb.Append(JsAdd(string.Format(rootJs, "highslide/highslide-full.packed.js")));
        sb.Append(CssAdd(string.Format(rootJs, "highslide/highslide-ie6.css")));
        sb.Append(CssAdd(string.Format(rootJs, "highslide/highslide.css")));
        return sb.ToString();
    }

    public static string ColorBox()
    {
        sb = new StringBuilder();
        sb.Append(JsAdd(string.Format(rootJs, "colorbox/jquery.colorbox-min.js")));
        sb.Append(CssAdd(string.Format(rootJs, "colorbox/colorbox.css")));
        return sb.ToString();
    }

    public static string TreeView()
    {
        sb = new StringBuilder();
        sb.Append(JsAdd(string.Format(rootJs, "jquery.treeview/jquery.treeview.js")));
        sb.Append(JsAdd(string.Format(rootJs, "jquery.treeview/jquery.cookie.js")));
        sb.Append(CssAdd(string.Format(rootJs, "jquery.treeview/jquery.treeview.css")));
        return sb.ToString();
    }

    public static string Autocomplete()
    {
        sb = new StringBuilder();
        sb.Append(JsAdd(string.Format(rootJs, "jquery.autocomplete/jquery.autocomplete.min.js")));
        sb.Append(JsAdd(string.Format(rootJs, "SelectUser.js")));
        sb.Append(CssAdd(string.Format(rootJs, "jquery.autocomplete/jquery.autocomplete.css")));
        return sb.ToString();
    }

    #endregion Jquery

    #region BICSkin

    public static string BICSkin()
    {
        sb = new StringBuilder();
        sb.Append(CssAdd(string.Format(rootBicSkin, "ComboBox.BICCMS.css")));
        sb.Append(CssAdd(string.Format(rootBicSkin, "Editor.BICCMS.css")));
        sb.Append(CssAdd(string.Format(rootBicSkin, "Grid.BICCMS.css")));
        sb.Append(CssAdd(string.Format(rootBicSkin, "Input.BICCMS.css")));
        sb.Append(CssAdd(string.Format(rootBicSkin, "Menu.BICCMS.css")));
        //sb.Append(CssAdd(string.Format(rootBicSkin, "RadAjax.css")));
        //sb.Append(CssAdd(string.Format(rootBicSkin, "RadMenu.css")));
        //sb.Append(CssAdd(string.Format(rootBicSkin, "RadTreeView.css")));
        //sb.Append(CssAdd(string.Format(rootBicSkin, "RadTreeViewTelerik.css")));
        return sb.ToString();
    }

    #endregion BICSkin

    #region User

    public static string SelectUsers()
    {
        sb = new StringBuilder();
        sb.Append(CssAdd("~/admin/Components/Security/User/select_users.css"));
        return sb.ToString();
    }

    #endregion User

    #region Gallery Image

    public static string JsImageGallery()
    {
        sb = new StringBuilder();
        sb.Append(JsAdd("~/admin/Components/ImageGallery/ImageManager.js"));
        return sb.ToString();
    }

    public static string JsImageGalleryForVideo()
    {
        sb = new StringBuilder();
        sb.Append(JsAdd("~/admin/Components/ImageGallery/ImageManagerForVideo.js"));
        return sb.ToString();
    }
    public static string JsImageLibraryManager()
    {
        sb = new StringBuilder();
        sb.Append(JsAdd("~/admin/Components/ImageLibrary/ImageLibraryManager.js"));
        return sb.ToString();
    }

    public static string JsImageSelector()
    {
        sb = new StringBuilder();
        sb.Append(JsAdd("~/admin/Components/ImageGallery/ImageSelector.js"));
        return sb.ToString();
    }
    //Cuongnp Start
    public static string JsImageSelectorForVideo()
    {
        sb = new StringBuilder();
        sb.Append(JsAdd("~/admin/Components/ImageGallery/ImageSelectorForVideo.js"));
        return sb.ToString();
    }
    //Cuongnp End
    public static string JsVideoSelector()
    {
        sb = new StringBuilder();
        sb.Append(JsAdd("~/admin/Components/Video/VideoSelector.js"));
        return sb.ToString();
    }

    public static string JsImageSelectMulti()
    {
        sb = new StringBuilder();
        sb.Append(JsAdd("~/admin/Components/ImageGallery/ImageSelectMulti.js"));
        return sb.ToString();
    }

    public static string ImgEditStyles()
    {
        sb = new StringBuilder();
        sb.Append(CssAdd(string.Format(rootCss, "Gallery/ImgEditStyles.css")));
        return sb.ToString();
    }

    public static string AdminImageGallery()
    {
        sb = new StringBuilder();
        sb.Append(CssAdd(string.Format(rootCss, "Gallery/ImageGallery.css")));
        return sb.ToString();
    }

    public static string AdminImageManager()
    {
        sb = new StringBuilder();
        sb.Append(CssAdd(string.Format(rootCss, "Gallery/ImageManager.css")));
        return sb.ToString();
    }

    public static string AdminImageLibrary()
    {
        sb = new StringBuilder();
        sb.Append(CssAdd(string.Format(rootCss, "Gallery/ImageLibrary.css")));
        return sb.ToString();
    }

    public static string AdminImageUpload()
    {
        sb = new StringBuilder();
        sb.Append(CssAdd(string.Format(rootCss, "Gallery/ImageUpload.css")));
        sb.Append(JsAdd("~/admin/Components/ImageGallery/ImageUpload.js"));
        return sb.ToString();
    }

    #endregion Gallery Image

    #region Video
    public static string JsVideoGallery()
    {
        sb = new StringBuilder();
        sb.Append(JsAdd("~/admin/Components/Video/VideoManager.js"));
        return sb.ToString();
    }
    public static string AdminVideoManager()
    {
        sb = new StringBuilder();
        sb.Append(AdminImageManager());
        return sb.ToString();
    }

    #endregion Video

    #region CssMedthod

    public static string CssAdd(string path)
    {
        string result = string.Empty;
        var page = HttpContext.Current.Handler as Page;
        string mark = "<link type='text/css'  rel='stylesheet' href='{0}' />";
        if (page != null) result = string.Format(mark, page.ResolveUrl(path));
        return result;
    }

    #endregion CssMedthod

    #region JsMedthod

    public static string JsAdd(string path)
    {
        string result = string.Empty;
        var page = HttpContext.Current.Handler as Page;
        string mark = "<script type='text/javascript' src='{0}'></script>";
        if (page != null)
        {
            result = string.Format(mark, page.ResolveUrl(path));
            page.RegisterClientScriptBlock("bic", result);
        }
        return result;
    }

    #endregion JsMedthod


}

public static class ExtStringForIncludeAdmin
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