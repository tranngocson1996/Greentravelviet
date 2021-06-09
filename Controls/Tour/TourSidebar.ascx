<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TourSidebar.ascx.cs" Inherits="Controls_Tour_TourSidebar" %>

<%@ Import Namespace="BIC.Utils" %>

<div class="widget-title box-title">
    <h2>
        <span class="text"><%=BicLanguage.CurrentLanguage== "vi"? "Tour du lịch nổi bật": "Hot tour" %></span>
    </h2>
</div>
<div class="caption-tour hidden">
    <bic:MenuCaption class="detail-caption" ID="hiliTourCaption" runat="server" />
</div>
<bic:TourListViewPager ID="subHiLiTour" runat="server" EnableAutoRedirect="False" ShowTourId="False">
    <ItemTemplate>
        <div class="tns-item">
            <div class="image">
                <bic:Image CssClass="image" Title='<%#Eval("TenTour")%>' ID="Image1" LoadThumbnail="False" runat="server" ImageId='<%# Eval("ImageID") %>' Link='<%# Eval("Url") %>' Alt='<%# Eval("TenTour") %>' />
            </div>
            <div class="info-hottour">
                <div class='title'>
                    <a href='<%#Eval("Url")%>' title='<%#Eval("TenTour")%>'><%#BicString.TrimText(Eval("TenTour").ToString(),20)%></a>
                </div>
                <div class="price-tour">
                    <%# Common.GetPriceDetail(Eval("GiaHienThi").ToString(),Eval("Mota2").ToString()) %>
                </div>
            </div>
        </div>
    </ItemTemplate>
</bic:TourListViewPager>
<script type="text/javascript">
    $('.Tour-hot .list .image img').addClass('img-responsive');
</script>
