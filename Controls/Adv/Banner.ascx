<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Banner.ascx.cs" Inherits="Controls_Adv_Banner" %>

<div class="bn-items owl-carousel">
    <asp:ListView ID="dlSliderList" runat="server">
        <ItemTemplate>
            <div class="bn-item">
                <%#Eval("URL").ToString().Trim()==""?"":"<a href='"+Eval("URL")+"' target='"+Eval("Target").ToString().Trim()+"'>" %>
                <%#Eval("Description")%>
                <%#Eval("URL").ToString().Trim()==""?"":"</a>" %>
            </div>
        </ItemTemplate>
    </asp:ListView>
</div>
