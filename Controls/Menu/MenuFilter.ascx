<%@ Control Language="C#" AutoEventWireup="true" CodeFile="~/Controls/Menu/MenuFilter.ascx.cs" Inherits="Controls_Menu_MenuFilter" %>
<%@ Import Namespace="BIC.Utils" %>

<div class="menu-filter-list">
    <div class="filter-desc">
        <asp:Literal ID="ltrDesc" runat="server"></asp:Literal>
    </div>
    <div class="filter-list">
        <ul>
            <bic:MenuListView ID="menuParent" runat="server" SelectFields="MenuIcon,MenuUserID,Name,ImageID">
                <ItemTemplate>
                    <li>
                        <a class="item" rel="nofollow" data-item="<%# Eval("MenuUserID") %>" href="javascript:void(0)"><img src="<%# BicImage.GetPathImage(BicConvert.ToInt32(Eval("ImageID"))) %>" alt="<%# Eval("Name") %>" /> <%# Eval("Name") %></a></li>
                </ItemTemplate>
            </bic:MenuListView>
        </ul>
    </div>
</div>
