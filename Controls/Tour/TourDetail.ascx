<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TourDetail.ascx.cs" Inherits="Controls_Tour_TourDetail" %>
<%@ Register Src="~/Controls/Tour/TourReference.ascx" TagPrefix="uc1" TagName="TourReference" %>
<%@ Register Src="~/Controls/Sidebar/SideBarTour.ascx" TagPrefix="uc1" TagName="SideBarTour" %>
<%@ Register Src="~/Controls/Navigate/NavigatePath.ascx" TagPrefix="uc1" TagName="NavigatePath" %>
<%@ Register Src="~/Controls/Social/Like.ascx" TagPrefix="uc1" TagName="Like" %>

<%@ Import Namespace="BIC.Utils" %>
<%=Include.Slick() %>
<%= Include.StickSidebar() %>
<div class="navigate-title">
    <div class="container">
        <div class="box-title">
        </div>
        <uc1:NavigatePath runat="server" ID="NavigatePath" />
    </div>
</div>
<section class="page-content page-tour ">
    <div class="container">
        <div class="row">
            <aside id="sidebar" class="col-lg-3 col-md-3 col-sm-4 col-xs-12 sidebar">
                <uc1:SideBarTour runat="server" ID="SideBarTour" />
            </aside>
            <div class="col-lg-9 col-md-9 col-sm-8 col-xs-12 tour_detail">
                <div class="col-lg-7 col-md-7 col-sm-6 col-xs-12 gallery-detail-tour">
                    <!--Main Slider Container-->
                    <div class="slider-container" id="mainSlider" runat="server" clientmode="static">
                        <div id="slider" class="slider owl-carousel">
                            <asp:Repeater runat="server" ID="rptImageArr">
                                <ItemTemplate>
                                    <div class="item">
                                        <img class="img-responsive" src='<%# Eval("UrlFull") %>' />
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <div class="slider-controls">
                            <a class="slider-left" href="javascript:;"><span><</span></a>
                            <a class="slider-right" href="javascript:;"><span>></span></a>
                        </div>
                    </div>

                    <!--Thumbnail slider container-->
                    <div class="thumbnail-slider-container" id="thumbSlider" runat="server" clientmode="static">
                        <div id="thumbnailSlider" class="thumbnail-slider owl-carousel">
                            <asp:Repeater runat="server" ID="rptImageArrThumb">
                                <ItemTemplate>
                                    <div class="item">
                                        <img class="img-responsive" src='<%# Eval("Url") %>' />
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
                <div class="col-lg-5 col-md-5 col-sm-6 col-xs-12 info-detail-tour">
                    <div class="title">
                        <h1>
                            <asp:Label runat="server" ID="lblTitle" />
                        </h1>
                    </div>
                    <div class="content">
                        <div class="matour <%=CssClassMa %>">
                            <span class="lable"><%=BicResource.GetValue("Matour") %>: </span><%=MaTour %>
                        </div>
                        <div class="daynumber <%=CssClassTime %>">
                            <span class="lable <%=CssClassTime1 %>"><%=BicResource.GetValue("NumberDays") %>: <%=Ngay %> <%=BicResource.GetValue("day") %> / <%=Dem %> <%=BicResource.GetValue("sodem") %></span>
                            <span class="lable <%=CssClassTime2 %>"><%=BicResource.GetValue("NumberDays") %>: <%=Ngay %> <%=BicResource.GetValue("days") %> / <%=Dem %> <%=BicResource.GetValue("sodem") %></span>
                            <span class="lable <%=CssClassTime3 %>"><%=BicResource.GetValue("NumberDays") %>: <%=Ngay %> <%=BicResource.GetValue("days") %> / <%=Dem %> <%=BicResource.GetValue("sodems") %></span>
                            <span class="lable <%=CssClassTime4 %>"><%=BicResource.GetValue("NumberDays") %>: <%=Ngay %> <%=BicResource.GetValue("day") %> </span>
                        </div>
                        <div class="daysto <%= CssClassNgayDi %>">
                            <span class="lable"><%=BicResource.GetValue("Daysto") %>: </span><%=DateBegin %>
                        </div>
                        <div class="daycomehome <%= CssClassNgayVe %>">
                            <span class="lable"><%=BicResource.GetValue("Dayscomehome") %>: </span><%=DateFini %>
                        </div>
                        <div class="daycomehome <%= CssClassTrung %>">
                            <span class="lable"><%=BicResource.GetValue("TourTrongNgay") %></span>
                        </div>
                        <div class="transport"><%=BicResource.GetValue("transport") %> : <span><%=PhuongTienHienThi %></span></div>
                        <div class="price">
                            <%=PriceOld %>
                        </div>
                        <div class="target-contact">
                            <div class="dattour">
                                <a onclick="saveTour(<%=TourId%>)">
                                    <%=BicLanguage.CurrentLanguage=="vi"?"Đặt tour":"Book now" %>
                                </a>
                            </div>
                            <div class="hotline">
                                <a href="tel:(84-234) 882678"></a>
                            </div>
                        </div>
                    </div>
                    <uc1:Like runat="server" ID="ucLike" />
                </div>
                <div class="detail-tour-desc">
                    <div class="detail-tour-infor detail-tour-box">
                        <div class="detail-tour-title"><%=BicResource.GetValue("GioiThieuChung") %></div>
                        <asp:Literal ID="ltrDetail" runat="server">
                                
                        </asp:Literal>
                    </div>
                    <div class="detail-tour-schedule detail-tour-box">
                        <div class="detail-tour-title"><%=BicResource.GetValue("LichTrinhCuThe") %></div>
                        <asp:Literal ID="ltrLichTrinhCuThe" runat="server">
                                
                        </asp:Literal>
                    </div>
                    <div class="detail-tour-price detail-tour-box">
                        <div class="detail-tour-title"><%=BicResource.GetValue("ChiTietGia") %></div>
                        <asp:Literal ID="ltrChiTietGia" runat="server">
                                
                        </asp:Literal>
                    </div>
                    <div class="<%=CssClass %> detail-tour-box">
                        <div class="detail-tour-title"><%=BicResource.GetValue("Video") %></div>
                        <asp:Literal ID="ltrVideo" runat="server">
                               
                        </asp:Literal>
                    </div>
                </div>
                <div class="tourRef w100 fl">
                    <uc1:TourReference runat="server" ID="ucTourReference" />
                </div>
            </div>


        </div>
    </div>
</section>



<script type="text/javascript">

    $(document).ready(function () {
        $('.btn_BookTour').click(function () {
            $('.formBook').removeClass("hidden");
        });
    });

</script>


