<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Step4.ascx.cs" Inherits="Controls_ShoppingCart_MessageSuccess" %>
<%@ Import Namespace="BIC.Utils" %>

<div class="successMsg text-center">
    <span>
        <%=BicResource.GetValue("ShoppingCart","Success") %>
    </span>
</div>
<div class="order-success text-center">
    <a href='<%= Common.GetSiteUrl() %>' class="btn-bg">Trở về trang chủ</a>
    <asp:LinkButton runat="server" ID="btnGoToOrder" Text="Tới trang quản lý đơn hàng" OnClick="btRedirect_Click" CssClass="btn-bg" Visible="false"></asp:LinkButton>
</div>
