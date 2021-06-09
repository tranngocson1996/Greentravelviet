<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Default.ascx.cs" Inherits="Controls_Article_ArticleDetail" %>
<%@ Import Namespace="BIC.Utils" %>
<%@ Register Src="~/Controls/Adv/Banner.ascx" TagPrefix="uc1" TagName="Banner" %>
<%@ Register Src="~/Controls/Adv/ScriptAdv.ascx" TagPrefix="uc1" TagName="ScriptAdv" %>
<%@ Register Src="~/Controls/Article/ArticleListingHome.ascx" TagPrefix="uc1" TagName="ArticleListingHome" %>
<%@ Register Src="~/Controls/Tour/HighLightTour.ascx" TagPrefix="uc1" TagName="HighLightTour" %>
<%@ Register Src="~/Controls/Tour/TourNuocNgoai.ascx" TagPrefix="uc1" TagName="TourNuocNgoai" %>
<%@ Register Src="~/Controls/Tour/TourTrongNuoc.ascx" TagPrefix="uc1" TagName="TourTrongNuoc" %>
<%@ Register Src="~/Controls/Search/Searching.ascx" TagPrefix="uc1" TagName="Searching" %>
<%@ Register Src="~/Controls/Tour/CentralTour.ascx" TagPrefix="uc1" TagName="CentralTour" %>
<%@ Register Src="~/Controls/Tour/SouthernTour.ascx" TagPrefix="uc1" TagName="SouthernTour" %>
<%@ Register Src="~/Controls/Article/ArticleKhachHang.ascx" TagPrefix="uc1" TagName="ArticleKhachHang" %>
<%@ Register Src="~/Controls/Tour/GroupTour.ascx" TagPrefix="uc1" TagName="GroupTour" %>







<%= Include.WowJs() %>
<%=Include.OwlCarousel() %>

<section class="banner banner-home">
    <uc1:Banner runat="server" ID="Banner" TypeOfAdv="2" />
    <div class="box-search-tour">
        <uc1:Searching runat="server" ID="ucSearching" />
    </div>
</section>
<!-----MODULE HOT TOUR------>
<section class="module-hottour">
    <div class="container">
        <uc1:HighLightTour runat="server" ID="HighLightTour" />
    </div>
</section>
<!-----MODULE GROUP TOUR------>
<section class="module-grouptour <%=CssClass1 %>">
    <div class="container">
        <uc1:GroupTour runat="server" ID="GroupTour" />
    </div>
</section>
<!-----MODULE INBOUND TOUR------>
<section class="module-inboundtour">
    <div class="container">
        <uc1:TourTrongNuoc runat="server" ID="TourTrongNuoc" />
    </div>
</section>
<!-----MODULE CENTRAL TOUR------>
<section class="module-centraltour <%=CssClass %>">
    <div class="container">
        <uc1:CentralTour runat="server" ID="CentralTour" />
    </div>
</section>
<!-----MODULE SOUTHERN TOUR------>
<section class="module-southerntour <%=CssClass %>">
    <div class="container">
        <uc1:SouthernTour runat="server" ID="SouthernTour" />
    </div>
</section>
<!-----MODULE WORLD TOUR------>
<section class="module-worldtour">
    <div class="container">
        <uc1:TourNuocNgoai runat="server" ID="TourNuocNgoai" />
    </div>
</section>
<!-----MODULE SERVICE------>
<section class="module-service">
    <div class="container">
        <uc1:ArticleListingHome runat="server" ID="ArticleListingHome" />
    </div>
</section>
<!-----MODULE TESTIMONIAL------>
<section class="module-testimonial">
    <div class="container">
        <div class="caption-tour khach-hang-title">
            <h2>
                <span class="text detail-caption"><%=BicLanguage.CurrentLanguage== "vi"? "Khách hàng nói về chúng tôi": "Customer about us we" %></span>
            </h2>
        </div>
        <div class="testimonial owl-carousel">
            <uc1:ArticleKhachHang runat="server" ID="ArticleKhachHang" />
        </div>
    </div>
</section>

<script type="text/javascript">
    new WOW().init();
    (function ($) {
        $(document).ready(function () {
            //$(".header-content .RadMenu_Top .rmFirst a").addClass("expanded");
            $('.header').addClass("header-home");
            $('a[data-toggle="tab"]').on('shown.bs.tab', function (e) {
                //alert(e.target.href);
                //    $('.panel-product .item-box figure').each(function () {
                //        $(this).height($(this).width() / 1.55);
            });

            //Lấy kích thước ảnh đầu tiên (vì chưa lấy được sự kiện chuyển tab của bootstrap
            var prWidth = $('.panel-product .item-box figure:eq(0)').width();
            $('.panel-product .item-box figure').each(function () {
                $(this).height(prWidth / 1.55);
            });
        });

        //Resize product image box
        $(window).resize(function () {
            var prWidth = $('.panel-product .item-box figure:eq(0)').width();

            $('.panel-product .item-box figure').each(function () {
                $(this).height(prWidth / 1.55);
            });
            $('.module-article-home .item-box figure').each(function () {
                $(this).height($(this).width() / 1.55);
            });
        });

        //Khi sử dụng slide Owl cần đưa vào window onLoad
        $(window).on('load', function () {
            $('.module-article-home .item-box figure').each(function () {
                $(this).height($(this).width() / 1.55);
            });
        });
    })(jQuery);
</script>


