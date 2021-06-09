<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdvSidebar.ascx.cs" Inherits="Controls_Adv_AdvSidebar" %>

<div class="advSidebar">
    <asp:ListView ID="dlSliderList" runat="server">
        <ItemTemplate>
            <div class="adv-item">
                <%#Eval("URL").ToString().Trim()==""?"":"<a href='"+Eval("URL")+"' target='"+Eval("Target").ToString().Trim()+"'>" %>
                    <%#Eval("Description")%>
                <%#Eval("URL").ToString().Trim()==""?"":"</a>" %>
            </div>
        </ItemTemplate>
    </asp:ListView>
</div>
