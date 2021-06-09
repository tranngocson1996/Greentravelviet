<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Home.ascx.cs" Inherits="admin_Controls_Home" %>
<%@ Import Namespace="BIC.Utils" %>
<div class="form-view-home">
    <div class="box_center">
        <div class="box-bicsrv">
           <%-- <img src="<%= Page.ResolveUrl(BicResource.GetValue("Admin","Admin_Home_Imgbicsrv")) %>" />--%>
        </div>
        <div class="box-home">
            <a class="box-funtion text-box-home " href='<%= Page.ResolveUrl(string.Format("~/admin/default.aspx?mid=3&cid=3&action=list&l={0}",BicHtml.GetRequestString("l") == "" ?  BicLanguage.CurrentLanguageAdmin : BicHtml.GetRequestString("l"))) %>'><%=BicResource.GetValue("Admin","Admin_Menu_HeThongMenuWebSite") %></a>
            <a class="box-manager-news text-box-home " href='<%= Page.ResolveUrl(string.Format("~/admin/default.aspx?mid=5&cid=4&action=list&l={0}",BicHtml.GetRequestString("l") == "" ? BicLanguage.CurrentLanguageAdmin : BicHtml.GetRequestString("l"))) %>'><%=BicResource.GetValue("Admin","Admin_Menu_DanhSachTin") %></a>
            <a class="box-manager-product text-box-home " href='<%= Page.ResolveUrl(string.Format("~/admin/default.aspx?mid=82&cid=31&action=list&l={0}",BicHtml.GetRequestString("l") == "" ? BicLanguage.CurrentLanguageAdmin : BicHtml.GetRequestString("l"))) %>'><%=BicResource.GetValue("Admin","Admin_Menu_DanhSachSanPham") %></a>
            <a class="box-manager-adv text-box-home " href='<%= Page.ResolveUrl(string.Format("~/admin/default.aspx?mid=38&cid=15&action=list&l={0}",BicHtml.GetRequestString("l") == "" ? BicLanguage.CurrentLanguageAdmin : BicHtml.GetRequestString("l"))) %>'><%=BicResource.GetValue("Admin","Admin_Menu_DanhSachQuangCao") %></a>
        </div>
        <div class="box-address">
            <img src="<%= Page.ResolveUrl(BicResource.GetValue("Admin","Admin_Home_Address")) %>" />
        </div>
    </div>
</div>
<script type="text/javascript">
    $(document).ready(function () {
        function opacityImage(id, opacity) {
            $(id + " img").live("mouseover mouseout", function (e) {
                if (e.type == "mouseover") $(this).stop().animate({ 'opacity': opacity }, 300);
                if (e.type == "mouseout") $(this).stop().animate({ 'opacity': 1 }, 1000);
            });
        }
        opacityImage(".box-home", 0.7);
    }) </script>
