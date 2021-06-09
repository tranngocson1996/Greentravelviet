<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Searching.aspx.cs" Inherits="Searching" %>

<%@ Register Src="~/Controls/Search/SearchingResult.ascx" TagPrefix="uc1" TagName="SearchingResult" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="Server">
    <section class="page-content">
        <div class="container">
            <uc1:SearchingResult runat="server" ID="SearchingResult" />
        </div>
    </section>
</asp:Content>

