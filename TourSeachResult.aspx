<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="TourSeachResult.aspx.cs" Inherits="TourSeachResult" %>
<%@ Register Src="~/Controls/Tour/TourSearch.ascx" TagPrefix="uc1" TagName="TourSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">
    <uc1:TourSearch runat="server" ID="TourSearch1" />
</asp:Content>

