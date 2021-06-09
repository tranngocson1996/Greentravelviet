<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TourNuocNgoai.ascx.cs" Inherits="Controls_Tour_TourNuocNgoai" %>

<%@ Import Namespace="BIC.Utils" %>
<%=Include.OwlCarousel() %>
<div class="Tour-hot">
    <div class="caption-tour">
        <bic:MenuCaption class="detail-caption" ID="hiliTourCaption" runat="server" />
    </div>
    <div class="list owl-carousel w100 fl">
        <bic:TourListViewPager ID="subHiLiTour" runat="server" EnableAutoRedirect="False" ShowTourId="False">
            <ItemTemplate>
                <div class="item">
                    <div class="tns-item">
                        <div class="image">
                            <bic:Image CssClass="image" Title='<%#Eval("TenTour")%>' ID="Image1" LoadThumbnail="False" runat="server" ImageId='<%# Eval("ImageID") %>' Link='<%# Eval("Url") %>' Alt='<%# Eval("TenTour") %>' />
                        </div>
                        <div class="info-hottour">
                            <div class='title'>
                                <a href='<%#Eval("Url")%>' title='<%#Eval("TenTour")%>'><%#BicString.TrimText(Eval("TenTour").ToString(),70)%></a>
                            </div>
                            <div class="number"><%#Eval("SoNgay") %> <%=BicResource.GetValue("day") %> <%#Eval("SoDem")%> <%=BicResource.GetValue("sodem") %></div>
                            <div class="content">
                                <div class="transport"><%=BicResource.GetValue("transport") %> : <span><%#Eval("PhuongTienHienThi") %></span></div>
                                <div class="price-tour">
                                    <%# Common.GetPriceDetail(Eval("GiaHienThi").ToString(),Eval("Mota2").ToString()) %>
                                </div>
                                <div class="button-target">
                                    <div class="chitiet">
                                        <a href='<%#Eval("Url")%>'>
                                            <%=BicLanguage.CurrentLanguage=="vi"?"Chi tiết":"Detail" %>
                                        </a>
                                    </div>
                                    <div class="dattour">
                                        <a onclick="saveTour(<%#Eval("TourID")%>)">
                                            <%=BicLanguage.CurrentLanguage=="vi"?"Đặt tour":"Book now" %>
                                        </a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </bic:TourListViewPager>
    </div>
</div>

<script type="text/javascript">
    $('.Tour-hot .list .image img').addClass('img-responsive');
</script>
