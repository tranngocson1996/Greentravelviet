<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImageManager.aspx.cs" Inherits="admin_Components_ImageGallery_ImageManager" %>
<%@ Import Namespace="BIC.Utils" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>BIC Image Tools</title>
        <%= IncludeAdmin.DefaultCss() %>
        <%= IncludeAdmin.JqueryUI() %>
        <%= IncludeAdmin.AdminImageManager() %>
        <script type="text/javascript">
        var lang = '<%= BicHtml.GetRequestString("l", BicXML.ToString("DefaultLanguageAdmin", "SearchEngine")) %>';
        if (location.href.match("ismulti")) {
            $(".galery #ifLoad").attr("src", "Gallery.aspx?ismulti=0&l=" + lang);
            $("#lnkgalery").attr("href", "Gallery.aspx?ismulti=0&l=" + lang);
        }
    </script>
    </head>
    <body class="galery">
        <form id="form1" runat="server">
            <asp:HiddenField ID="hdfLangManager" runat="server" />
            <div id="topgallery" class="top_gallery">
                <div class="logo">
                </div>
                <div class="version">
                    BIC Image Tools 2014 - ver 2.6.8
                </div>
            </div>
            <div class="middle_gallery">
                <div id="tabs">
                    <ul>
                        <li class="tab-galery">
                            <a id="lnkgalery" href='Gallery.aspx?l=<%= BicHtml.GetRequestString("l") == "" ? BicXML.ToString("DefaultLanguage", "SearchEngine") : BicHtml.GetRequestString("l") %>' target="ifLoad"><%= BicResource.GetValue("Admin", "Admin_Gallery_ThuVienAnh") %></a></li>
                        <li class="tab-upload">
                            <a id="lnkupload" href='Upload.aspx?l=<%= BicHtml.GetRequestString("l") == "" ? BicXML.ToString("DefaultLanguage", "SearchEngine") : BicHtml.GetRequestString("l") %>' target="ifLoad"><%= BicResource.GetValue("Admin", "Admin_Gallery_UploadAnh") %></a></li>
                        <li class="tab-category">
                            <a id="lnkcategory" target="ifLoad" href='<%= Page.ResolveUrl(string.Format("~/admin/Components/ImageType/ImageTypeManager.aspx?l={0}", BicHtml.GetRequestString("l") == "" ? BicXML.ToString("DefaultLanguage", "SearchEngine") : BicHtml.GetRequestString("l"))) %>'><%= BicResource.GetValue("Admin", "Admin_Gallery_DanhMucAnh") %></a></li>
                    </ul>
                    <div id="tabs-1">
                        <iframe name="ifLoad" id="ifLoad" src='Gallery.aspx?l=<%= BicHtml.GetRequestString("l") == "" ? BicXML.ToString("DefaultLanguage", "SearchEngine") : BicHtml.GetRequestString("l") %>' scrolling="no" marginheight="0" marginwidth="0" frameborder="0" width="100%"></iframe>
                    </div>
                </div>
            </div>
        </form>
    </body>
</html>