<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TourListing.ascx.cs" Inherits="Controls_Tour_TourListing" %>
<%@ Import Namespace="BIC.Utils" %>
<%@ Register Src="~/Controls/Navigate/NavigatePath.ascx" TagPrefix="uc1" TagName="NavigatePath" %>
<%@ Register Src="~/Controls/Sidebar/SideBarTour.ascx" TagPrefix="uc1" TagName="SideBarTour" %>
<div class="navigate-title">
    <div class="container">
        <div class="box-title">
        </div>
        <uc1:NavigatePath runat="server" ID="NavigatePath" VisibleHomePage="True" />
    </div>
</div>
<section class="page-content page-tour Tour-hot">
    <div class="container">
        <div class="row">
            <aside id="sidebar" class="col-lg-3 col-md-3 col-sm-4 col-xs-12 sidebar">
                <uc1:SideBarTour runat="server" ID="SideBarTour" />
            </aside>
            <div class="col-lg-9 col-md-9 col-sm-8 col-xs-12 tour-listing">
                <div class="box-sx">
                    <div class="title-tourlisting">
                        <h1>
                            <bic:MenuCaption ID="CaptionListing" runat="server" />
                        </h1>
                    </div>
                </div>

                <div class="list tns-items">
                    <bic:TourListViewPager ID="TourListing" runat="server" EnableAutoRedirect="False" ShowTourId="False">
                        <ItemTemplate>
                            <div class="item col-lg-4 col-md-4 col-sm-6 col-xs-12">
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
                                            <div class="transport"><%=BicResource.GetValue("transport") %> : <span>  <%#Eval("PhuongTienHienThi") %></span></div>
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
                <div class="page">
                    <bic:PagerUI ID="pager" CssClass="pager" SelectedCssClass="pager_selected" Label='' runat="server" PagerUIStep="3" OnPageIndexChanged="pager_PageIndexChanged" />
                </div>
            </div>
        </div>
    </div>
</section>

<script type="text/javascript">
    $('.list .image img').addClass('img-responsive');
</script>



