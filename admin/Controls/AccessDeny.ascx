<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AccessDeny.ascx.cs" Inherits="admin_Controls_AccessDeny" %>
<%@ Import Namespace="BIC.Utils" %>
<div class="form-view-welcome">
    <div class="form-tool">
        <%= BicXML.ToString("AdminTitle", "SearchEngine") %>
    </div>
    <center>
        <img src='<%= Page.ResolveUrl("~/admin/Styles/img/denied_" + BicLanguage.CurrentLanguageAdmin + ".png") %>' />
    </center>
</div>
