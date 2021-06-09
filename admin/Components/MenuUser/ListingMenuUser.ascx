<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListingMenuUser.ascx.cs" Inherits="admin_Components_MenuAdmin_ListingMenuUser" %>
<%@ Import Namespace="BIC.Utils" %>
<%@ Register Src="TreeviewMenuUser.ascx" TagName="TreeviewMenuUser" TagPrefix="uc1" %>
<script language="javascript" type="text/jscript">
    $(function () { Scroll($("#content1"), $("#slider1")); Scroll($("#content1"), $("#slider2")); });
</script>
<div class="input-box">
    <div class="item first">
        <div class="label">
            <%=BicResource.GetValue("Admin","System_Language")%>
        </div>
        <div class="input">
            <bic:Language ID="ddlLanguage" runat="server" AutoPostBack="True" CssClass="input-select" OnSelectedIndexChanged="ddlLanguage_SelectedIndexChanged" />
        </div>
    </div>
    <div class="item last">
        <div class="label">
            <%=BicResource.GetValue("Admin","Admin_MenuUser_ModelMenu")%>
        </div>
        <div class="input">
            <asp:DropDownList runat="server" ID="ddlModelMenu" DataValueField="key" DataTextField="name" AutoPostBack="True" CssClass="input-select" OnSelectedIndexChanged="ddlModelMenu_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
    </div>
</div>
<div class="form-tool">
    <telerik:RadCodeBlock ID="RadCodeBlock3" runat="server">
        <a href='<%= BicAdmin.UrlAdd() %>' class="btn-addnew"><%=BicResource.GetValue("Admin","System_Add")%> 
        </a>
    </telerik:RadCodeBlock>
</div>
<div class="form-view-tree">
    <div class="main-wrapp">
        <div class="main">
            <div class="wrapp">
                <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
                    <img alt="" src='<%= Page.ResolveUrl(string.Format("~/admin/Styles/img/menu_help_{0}.jpg", BicLanguage.CurrentLanguageAdmin)) %>' />
                </telerik:RadCodeBlock>
                <p style="font-size: 13px;">
                    <%= BicResource.GetValue("Admin", "Admin_MenuUser_User_Guide") %>
                </p>
            </div>
        </div>
    </div>
    <div class="side-wrapp">
        <div class="slider-wrapper-top">
            <div class="content-slider" id="slider2">
            </div>
        </div>
        <div class="side" id="content1">
            <uc1:TreeviewMenuUser ID="tvMenuUser" runat="server" />
        </div>
        <div class="slider-wrapper">
            <div class="content-slider" id="slider1">
            </div>
        </div>
    </div>
</div>
<div class="form-tool-bottom">
    <telerik:RadCodeBlock ID="RadCodeBlock2" runat="server">
        <a href='<%= BicAdmin.UrlAdd() %>' class="btn-addnew"><%=BicResource.GetValue("Admin","System_Add")%> 
        </a>
    </telerik:RadCodeBlock>
</div>
