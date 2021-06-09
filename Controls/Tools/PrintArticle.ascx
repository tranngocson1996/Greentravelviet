<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PrintArticle.ascx.cs" Inherits="Controls_Tools_PrintArticle" %>
<%@ Import Namespace="BIC.Utils" %>
<%=Include.PrintArticle() %>
<div class="printBlock">
    <div class="topLogo">
    </div>
    <div class="newsTitle">
        <asp:Label runat="server" ID="lblArticle" CssClass="title" />
    </div>
    <div class="content">
        <asp:Literal runat="server" ID="ltlBody"></asp:Literal>
    </div>
    <div class="printBtn">
        <a href='#' onclick="window.print()">
            <%= BicResource.GetValue("Print") %></a>
    </div>
    <div class="bottomLogo">
    </div>
</div>