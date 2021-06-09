<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Adv.ascx.cs" Inherits="Controls_Adv_Adv" %>
<div class="adv-box">
    <div>
        <asp:ListView runat="server" ID="rptAdv">
            <ItemTemplate>
                <div class='item <%#Container.DataItemIndex == 0?"first":"last" %>'>
                    <%#Eval("URL").ToString().Trim()==""?"":"<a href='"+Eval("URL")+"' target='"+Eval("Target").ToString().Trim()+"'>" %>
                    <%#Eval("Description")%>
                    <%#Eval("URL").ToString().Trim()==""?"":"</a>" %>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>
</div>
