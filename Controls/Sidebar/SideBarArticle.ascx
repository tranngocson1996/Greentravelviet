<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SideBarArticle.ascx.cs" Inherits="Controls_SideBar_SideBarArticle" %>
<%@ Import Namespace="BIC.Utils" %>
<%@ Register Src="~/Controls/Article/ArticleSidebar.ascx" TagPrefix="uc1" TagName="ArticleSidebar" %>
<%@ Register TagPrefix="uc1" TagName="MenuLeft2" Src="~/Controls/Menu/MenuLeft2.ascx" %>

<aside id="sidebar" class="col-lg-3 col-md-3 col-sm-4 col-xs-12 sidebar">
    <div class="danhsach-tour">
        <div class="widget-title box-title">
            <h2>
                <span class="text"><%=BicLanguage.CurrentLanguage== "vi"? "Danh sách tour": "Tour List" %></span>
            </h2>
        </div>
        <uc1:MenuLeft2 runat="server" ID="ucMenuLeft2" />
    </div>
    <div class="tin-xem-nhieu">
        <uc1:ArticleSidebar runat="server" ID="ucArticleSidebar" />
    </div>
</aside>


