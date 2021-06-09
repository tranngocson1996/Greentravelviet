<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="BookTour.aspx.cs" Inherits="_BookTour" %>
<%@ Register Src="~/Controls/Tour/BookTour.ascx" TagPrefix="uc1" TagName="BookTour" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="Server">
    <uc1:BookTour runat="server" id="BookTour1" />
</asp:Content>