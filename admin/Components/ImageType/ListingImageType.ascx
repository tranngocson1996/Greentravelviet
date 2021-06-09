<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListingImageType.ascx.cs" Inherits="Admin_Components_ImageType_ListingImageType" %>
<%@ Import Namespace="BIC.Utils" %>
<%@ Register Src="TreeviewImageType.ascx" TagName="TreeviewImageType" TagPrefix="uc1" %>
<script>
    $(function() {Scroll($("#content1"), $("#slider1"));Scroll($("#content1"), $("#slider2"));});
</script>
<div class="form-tool">
    <a href='<%= BicAdmin.UrlAdd() %>' class="btn-addnew">  <%=BicResource.GetValue("Admin","System_Add") %></a>
</div>
<div class="form-view-tree">
    <div class="main-wrapp">
        <div class="main">
            <div class="wrapp">
                <img src='<%= Page.ResolveUrl("~/admin/Styles/img/menu_help.jpg") %>' />
            </div>
        </div>
    </div>
    <div class="side-wrapp">
        <div class="slider-wrapper-top">
            <div class="content-slider" id="slider2">
            </div>
        </div>
        <div class="side" id="content1">
            <uc1:TreeviewImageType ID="tvMain" runat="server" />
        </div>
        <div class="slider-wrapper">
            <div class="content-slider" id="slider1">
            </div>
        </div>
    </div>
</div>
<div class="form-tool-bottom">
    <a href='<%= BicAdmin.UrlAdd() %>' class="btn-addnew">  <%=BicResource.GetValue("Admin","System_Add") %></a>
</div>