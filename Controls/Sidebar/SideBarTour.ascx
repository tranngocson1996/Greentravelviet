<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SideBarTour.ascx.cs" Inherits="Controls_SideBar_SideBarTour" %>
<%@ Import Namespace="BIC.Utils" %>
<%@ Register Src="~/Controls/Search/Searching.ascx" TagPrefix="uc1" TagName="Searching" %>
<%@ Register Src="~/Controls/Tour/TourSidebar.ascx" TagPrefix="uc1" TagName="TourSidebar" %>
<%@ Register Src="~/Controls/Menu/MenuLeft2.ascx" TagPrefix="uc1" TagName="MenuLeft2" %>




<div class="box-search-tour">
    <uc1:Searching runat="server" ID="ucSearching" />
</div>
<div class="danhsach-tour">
    <div class="widget-title box-title">
        <h2>
            <span class="text"><%=BicLanguage.CurrentLanguage== "vi"? "Danh sách tour": "Tour List" %></span>
        </h2>
    </div>
    <uc1:MenuLeft2 runat="server" ID="ucMenuLeft2" />
</div>
<div class="tour-noibat">
    <uc1:TourSidebar runat="server" ID="TourSidebar" />
</div>
