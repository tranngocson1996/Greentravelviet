<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SliderLogo.ascx.cs" Inherits="Controls_Adv_Adv" %>

<div class="brand">
    <ul class="owl-carousel">
        <asp:ListView ID="dlSliderList" runat="server">
            <ItemTemplate>
                <li class="item">
                    <%#Eval("Description") %>
                </li>
            </ItemTemplate>
        </asp:ListView>
    </ul>
</div>
