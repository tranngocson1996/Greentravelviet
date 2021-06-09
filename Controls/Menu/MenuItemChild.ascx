<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MenuItemChild.ascx.cs" Inherits="Controls_Menu_MenuItem" %>

<asp:ListView ID="menuParent" runat="server">
    <ItemTemplate>
        <a href='<%#_Getlink(Eval("URL").ToString(),Eval("UrlName").ToString()) %>' title='<%# Eval("Name") %>'>
            <img src="/FileUpload/Images/<%#Eval("ImageName") %>" class="img-responsive w100" />
        </a>
    </ItemTemplate>
</asp:ListView>
