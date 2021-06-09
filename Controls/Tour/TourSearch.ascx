<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TourSearch.ascx.cs" Inherits="Controls_Tour_TourSearch" %>
<%@ Import Namespace="BIC.Utils" %>
<%@ Register Src="~/Controls/Navigate/NavigatePath.ascx" TagPrefix="uc1" TagName="NavigatePath" %>



<div class="navigate-title">
    <div class="container">
        <div class="box-title">
        </div>
        <uc1:NavigatePath runat="server" ID="NavigatePath" />
    </div>
</div>
<div class="Tour-hot Result-tour">
    <div class="container">
        <div class="caption-search">
            <%=BicResource.GetValue("SearchResults") %> <b>
                <%=result%>
                <%=BicResource.GetValue("KetQua") %></b>
        </div>
        <br />
        <div class="list w100 fl">
            <div class="row">
                <bic:TourSearchListView ID="lvpTourListing" runat="server" EnableAutoRedirect="False" ShowTourId="False">
                    <ItemTemplate>
                        <div class="item col-lg-3 col-md-3 col-sm-4 col-xs-12">
                            <div class="tns-item">
                                <div class="image">
                                    <bic:Image CssClass="image" Title='<%#Eval("TenTour")%>' ID="Image1" LoadThumbnail="False" runat="server" ImageId='<%# Eval("ImageID") %>' Link='<%# Eval("Url") %>' Alt='<%# Eval("TenTour") %>' />
                                </div>
                                <div class="info-hottour">
                                    <div class="number"><%#Eval("SoNgay") %> <%=BicResource.GetValue("day") %> <%#Eval("SoDem") %> <%=BicResource.GetValue("sodem") %></div>
                                    <div class='title'>
                                        <a href='<%#Eval("Url")%>' title='<%#Eval("TenTour")%>'><%#Eval("TenTour").ToString().Trim()%></a>
                                    </div>
                                    <div class="content">
                                        <div class="transport"><%=BicResource.GetValue("transport") %> : <span><%#Eval("PhuongTienHienThi") %></span></div>
                                        <%--<div class="arrive"><%=BicResource.GetValue("arrive") %> : <span><%#Eval("Mota3") %></span></div>--%>
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
                </bic:TourSearchListView>
            </div>
        </div>
    </div>
</div>


<div class="page">
    <bic:PagerUI ID="pager" CssClass="pager" SelectedCssClass="pager_selected" Label='' runat="server" PagerUIStep="10" OnPageIndexChanged="pager_PageIndexChanged" />
</div>
<script type="text/javascript">
    $('.list .image img').addClass('img-responsive');
</script>


