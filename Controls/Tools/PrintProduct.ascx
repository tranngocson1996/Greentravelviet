<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PrintProduct.ascx.cs" Inherits="Controls_Tools_PrintProduct" %>
<%@ Import Namespace="BIC.Utils" %>
<%=Include.PrintProduct() %>
<div class="printBlock">
    <div class="topLogo">
    </div>
    <div class="newsTitle">
        <asp:Label runat="server" ID="lblProduct" CssClass="title" />
    </div>
    <div class="clear"></div>
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