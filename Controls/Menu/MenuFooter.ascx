<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MenuFooter.ascx.cs" Inherits="Controls_Menu_MenuFooter" %>
<%@ Import Namespace="BIC.Utils" %>
<bic:MenuListView ID="menuParent" runat="server" SelectFields="ParentId" OnItemDataBound="MenuParentItemDataBound">
    <LayoutTemplate>
        <ul class="root-menu">
            <asp:PlaceHolder runat="server" ID="ItemPlaceHolder"></asp:PlaceHolder>
        </ul>
    </LayoutTemplate>
    <ItemTemplate>
        <li class="item<%# CheckMenuPro(Eval("MenuUserID").ToString()) == true? " active":"" %>">
            <a class="<%# IsParent(Eval("MenuUserID").ToString()) == true? "lvRoot":"lvItem" %>" href='<%# Eval("Url") %>'><%# Eval("Name") %></a>
            <i class="fa fa-angle-double-down tns-toggle" aria-hidden="true"></i>
            <bic:MenuListView runat="server" ID="menuChild" SelectFields="ParentId">
                <LayoutTemplate>
                    <ul class="sub-menu<%# CheckMenuPro(Eval("MenuUserID").ToString()) == true? "":" hidden" %> tns-menu-footer">
                        <asp:PlaceHolder runat="server" ID="ItemPlaceHolder"></asp:PlaceHolder>
                    </ul>
                </LayoutTemplate>
                <ItemTemplate>
                    <li class="sub-item<%# CheckMenuPro(Eval("MenuUserID").ToString()) == true? " active":"" %>">
                        <a href='<%#Eval("Url")  %>'><%# Eval("Name") %></a>
                        <bic:MenuListView runat="server" ID="menu3" SelectFields="ParentId">
                            <LayoutTemplate>
                                <ul class="<%# CheckMenuPro(Eval("MenuUserID").ToString()) == true? "":" hidden" %>">
                                    <asp:PlaceHolder runat="server" ID="ItemPlaceHolder"></asp:PlaceHolder>
                                </ul>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <li class="sub-item<%# CheckMenuPro(Eval("MenuUserID").ToString()) == true? " active":"" %>">
                                    <a href='<%#Eval("Url")  %>'><%# Eval("Name") %></a>
                                </li>
                            </ItemTemplate>
                        </bic:MenuListView>
                    </li>
                </ItemTemplate>
            </bic:MenuListView>
        </li>
    </ItemTemplate>
</bic:MenuListView>

