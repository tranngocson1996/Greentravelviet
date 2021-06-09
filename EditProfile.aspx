<%@ Page  Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EditProfile.aspx.cs" Inherits="EditProfile" %>

<%@ Import Namespace="BIC.Utils" %>
<%@ Register Src="~/Controls/User/UserManageProfileTab.ascx" TagPrefix="uc1" TagName="UserManageProfileTab" %>
<%@ Register Src="~/Controls/User/UserManageChangePassTab.ascx" TagPrefix="uc1" TagName="UserManageChangePassTab" %>
<%@ Register Src="~/Controls/User/DiaryOrder.ascx" TagPrefix="uc1" TagName="DiaryOrder" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
     <%= Include.CssAdd("~/Controls/User/UserProfile.css") %>
    <section class="page-content page-profile">
        <div class="container">
            <!-- Nav tabs -->
            <div class="fw tab-heading">
                <ul class="nav nav-tabs">
                    <li role="presentation" class="<%= TabProfile %>">
                        <a href="#profile" aria-controls="profile" data-toggle="tab"><%=BicResource.GetValue("UserManager","AccountInfomation") %></a>
                    </li>
                    <li role="presentation">
                        <a href="#changepass" aria-controls="changepass" data-toggle="tab"><%=BicResource.GetValue("UserManager","ChangePassword") %></a>
                    </li>
                    <li role="presentation" class="<%= TabOrder %>">
                        <a href="#order" aria-controls="order" data-toggle="tab"><%=BicResource.GetValue("UserManager","OrderManager") %></a>
                    </li>
                </ul>
            </div>
            <!-- Tab panes -->
            <div class="tab-content">
                <div role="tabpanel" class="tab-pane <%= TabProfile %>" id="profile">
                    <uc1:UserManageProfileTab runat="server" ID="UserManageProfileTab" />
                </div>
                <div role="tabpanel" class="tab-pane" id="changepass">
                    <uc1:UserManageChangePassTab runat="server" ID="UserManageChangePassTab" />
                </div>
                <div role="tabpanel" class="tab-pane <%= TabOrder %>" id="order">
                    <uc1:DiaryOrder runat="server" ID="DiaryOrder" />
                </div>
            </div>
        </div>
    </section>
</asp:Content>
