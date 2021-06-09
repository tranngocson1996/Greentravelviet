<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SiteLogo.ascx.cs" Inherits="Controls_Adv_SiteLogo" %>
<%@ Import Namespace="BIC.Utils" %>
<asp:ListView runat="server" ID="rptAdv">
    <ItemTemplate>
            <%#Eval("URL").ToString().Trim()==""? "<a href='" + BicApplication.URLRoot + "'>":"<a href='"+Eval("URL")+"' target='"+Eval("Target").ToString().Trim()+"'>" %>
            <%#Eval("Description")%>
            <%#Eval("URL").ToString().Trim()=="</a>"?"":"</a>" %>
    </ItemTemplate>
</asp:ListView>