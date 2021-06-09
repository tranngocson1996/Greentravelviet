<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MenuLeft2.ascx.cs" Inherits="Controls_Menu_MenuLeft2" %>
<%@ Import Namespace="BIC.Utils" %>


<div class="menu">
    <bic:MenuListView ID="menuParent" runat="server" SelectFields="ParentId, ImageID" OnItemDataBound="MenuParentItemDataBound">
        <LayoutTemplate>
            <ul>
                <asp:PlaceHolder runat="server" ID="ItemPlaceHolder"></asp:PlaceHolder>
            </ul>
        </LayoutTemplate>
        <ItemTemplate>
            <li class="menu-item <%# CheckMenuPro(Eval("MenuUserID").ToString()) == true? "active":"" %>">
                <%-- <img class="img-circle" src="<%# Page.ResolveUrl("~/" + BicImage.GetPathImage(BicConvert.ToInt32(Eval("ImageID")))) %>" alt="<%# Eval("Name") %>" />--%>
                <a class="menu-link" href='<%# Eval("Url") %>'><%# Eval("Name") %></a>
                <bic:MenuListView runat="server" ID="menuChild" SelectFields="ParentId">
                    <LayoutTemplate>
                        <ul class="sub-menu">
                            <asp:PlaceHolder runat="server" ID="ItemPlaceHolder"></asp:PlaceHolder>
                        </ul>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <li class="menu-item <%# CheckMenuPro(Eval("MenuUserID").ToString()) == true? "active":"" %>">
                            <a href='<%#Eval("Url")  %>' class="menu-link"><%# Eval("Name") %></a>
                        </li>
                    </ItemTemplate>
                </bic:MenuListView>

            </li>
        </ItemTemplate>
    </bic:MenuListView>
</div>
