<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VideoManager.aspx.cs" Inherits="admin_Components_Video_VideoManager" %>
<%@ Import Namespace="BIC.Utils" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BIC Video Tools</title>
    <%= IncludeAdmin.DefaultCss() %>
    <%= IncludeAdmin.JqueryUI() %>
    <%= IncludeAdmin.AdminImageManager() %>
    <script type="text/javascript">
        //$(document).ready(function () { $(".galery #ifLoad").attr("src", "ListVideo.aspx"); $("#lnkgalery").attr("href", "ListVideo.aspx"); });
        
    </script>
</head>
<body class="galery">
    <form id="form1" runat="server">
    <div id="topgallery" class="top_gallery">
        <div class="logo">
        </div>
        <%--<div class="version">
            BIC Video Tools 2014 - ver 2.6.8</div>--%>
    </div>
    <div class="middle_gallery">
        <div id="tabs">
            <ul>
                <li class="tab-galery">
                    <a id="lnkgalery" href='ListVideo.aspx?l=<%=BicHtml.GetRequestString("l") == "" ? BicXML.ToString("DefaultLanguageAdmin", "SearchEngine") : BicHtml.GetRequestString("l") %>' target="ifLoad"><%=BicResource.GetValue("Admin","Admin_Video_Thuvienvideo") %></a></li>
                <li class="tab-upload">
                    <a id="lnkupload" href='UploadVideo.aspx?l=<%=BicHtml.GetRequestString("l") == "" ? BicXML.ToString("DefaultLanguageAdmin", "SearchEngine") : BicHtml.GetRequestString("l") %>' target="ifLoad"><%=BicResource.GetValue("Admin","Admin_Video_uploadVideo") %></a></li>
            </ul>
            <div id="tabs-1">
                <iframe name="ifLoad" id="ifLoad" src='ListVideo.aspx?l=<%=BicHtml.GetRequestString("l") == "" ? BicXML.ToString("DefaultLanguageAdmin", "SearchEngine") : BicHtml.GetRequestString("l") %>' scrolling="no" marginheight="0" marginwidth="0" frameborder="0" width="100%"></iframe>
            </div>
        </div>
    </div>
    </form>
</body>
</html>