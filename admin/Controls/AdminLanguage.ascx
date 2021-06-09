<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdminLanguage.ascx.cs" Inherits="Controls_Language" %>
<%@ Import Namespace="BIC.Utils" %>
<div id="AdminLanguage">
    <span><%=BicResource.GetValue("Admin","Admin_AdminLanguege_Language") %></span>
    <bic:Language ControlForResource="true" ID="ddlAdminLanguage" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlAdminLanguage_SelectedIndexChanged" />
</div>
