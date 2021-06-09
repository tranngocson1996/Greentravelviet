<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="TourDetail.aspx.cs" Inherits="_TourDetail" %>
<%@ Register Src="~/Controls/Tour/TourDetail.ascx" TagPrefix="uc1" TagName="TourDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="Server">
    <uc1:TourDetail runat="server" id="TourDetail1" />
</asp:Content>