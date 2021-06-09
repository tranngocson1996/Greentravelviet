<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListingMenuAdmin.ascx.cs" Inherits="admin_Components_MenuAdmin_ListingMenuAdmin" %>
<%@ Import Namespace="BIC.Utils" %>
<%@ Register Src="TreeviewMenuAdmin.ascx" TagName="TreeviewMenuAdmin" TagPrefix="uc1" %>
<script>
    $(function() {Scroll($("#content1"), $("#slider1"));Scroll($("#content1"), $("#slider2"));});
</script>
<div class="form-tool">
    <a href='<%= BicAdmin.UrlAdd() %>' class="btn-addnew"><%=BicResource.GetValue("Admin","System_Add")%></a>
</div>
<div class="form-view-tree">
    <div class="main-wrapp">
        <div class="main">
            <div class="wrapp">
                <img src='<%= Page.ResolveUrl(string.Format("~/admin/Styles/img/menu_help_{0}.jpg", BicLanguage.CurrentLanguageAdmin)) %>' />
            </div>
        </div>
    </div>
    <div class="side-wrapp">
        <div class="slider-wrapper-top">
            <div class="content-slider" id="slider2">
            </div>
        </div>
        <div class="side" id="content1">
            <uc1:TreeviewMenuAdmin ID="tvMain" runat="server" />
        </div>
        <div class="slider-wrapper">
            <div class="content-slider" id="slider1">
            </div>
        </div>
    </div>
</div>
<div class="form-tool-bottom">
    <a href='<%= BicAdmin.UrlAdd() %>' class="btn-addnew"><%=BicResource.GetValue("Admin","System_Add")%></a>
</div>