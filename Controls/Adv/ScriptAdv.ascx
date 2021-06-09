<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ScriptAdv.ascx.cs" Inherits="Controls_Adv_ScriptAdv" %>
<asp:ListView ID="dlSliderList" runat="server">
    <ItemTemplate>
        <%#Eval("Description")%>
    </ItemTemplate>
</asp:ListView>
