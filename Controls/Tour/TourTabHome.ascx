<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TourTabHome.ascx.cs" Inherits="Controls_Tour_TourTabHome" %>
<%@ Import Namespace="BIC.Utils" %>



<div class="Lich-khoi-hanh">
    <div class="caption-tour">
        <h2>
            <bic:MenuCaption runat="server" ID="mnCap" CssClass="detail-caption" /></h2>
    </div>
    <bic:MenuListView ID="menuTab" runat="server" SelectFields="ParentId">
        <LayoutTemplate>
            <ul class="nav menu-lich" role="tablist">
                <asp:PlaceHolder runat="server" ID="ItemPlaceHolder"></asp:PlaceHolder>
            </ul>
        </LayoutTemplate>
        <ItemTemplate>
            <li class="item <%# Container.DataItemIndex == 0 ? "active" : "" %>" role="presentation">
                <a class="text-auto" href="#<%# Eval("UrlName") %>" data-link="<%# Eval("URL") %>" aria-controls="<%# Eval("UrlName") %>" role="tab" data-toggle="tab"><%# Eval("Name") %></a>
            </li>
        </ItemTemplate>
    </bic:MenuListView>
</div>
<!-- Tab panes -->
<bic:MenuListView ID="menuTabContent" runat="server" SelectFields="ParentId, UrlName" OnItemDataBound="menuTabContent_ItemDataBound">
    <LayoutTemplate>
        <div class="tab-content">
            <asp:PlaceHolder runat="server" ID="ItemPlaceHolder"></asp:PlaceHolder>
        </div>
    </LayoutTemplate>
    <ItemTemplate>
        <div role="tabpanel" class="tab-pane fade<%# Container.DataItemIndex == 0 ? " in active" : "" %>" id="<%# Eval("UrlName") %>">
            <div class="tns-items">
                <table class="table tns-item">
                    <tr class="item">
                        <td style="width: 210px">Hình ảnh
                        </td>
                        <td style="width: 250px">Tuyến du lịch
                        </td>
                        <td>Ngày khởi hành
                        </td>
                        <td>Ngày về
                        </td>
                        <td>Xe/HHK
                        </td>
                        <td>Giá tour(VND)
                        </td>
                        <td style="width: 170px"></td>

                    </tr>
                    <bic:TourListViewPager runat="server" ID="lvArticleTab" EnableAutoRedirect="False" ExtensionLink="HTML" ShowTourId="False">
                        <ItemTemplate>
                            <tr class="item">
                                <td class="image-lich">
                                    <div class="image">
                                        <bic:Image CssClass="image" Title='<%#Eval("TenTour")%>' ID="Image1" LoadThumbnail="True" runat="server" ImageId='<%# Eval("ImageID") %>' Link='<%# Eval("Url") %>' Alt='<%# Eval("TenTour") %>' />
                                    </div>
                                </td>
                                <td>
                                    <div class='title'>
                                        <a href='<%#Eval("Url")%>' title='<%#Eval("TenTour")%>'><%#Eval("TenTour").ToString().Trim()%></a>
                                    </div>
                                    <div class="number"><%#Eval("SoNgay") %> <%=BicResource.GetValue("day") %> / <%#Eval("SoDem") %> <%=BicResource.GetValue("sodem") %></div>
                                </td>
                                <td>
                                    <div class='daybegin'>
                                        <%#Common.ConvertDate(Eval("NoiDi").ToString()) %>
                                    </div>
                                </td>
                                <td>
                                    <div class='dayfini'>
                                        <%#Common.ConvertDate(Eval("NoiDen").ToString()) %>
                                    </div>
                                </td>
                                <td>
                                    <div class="transport"><%#Eval("PhuongTienHienThi") %></div>
                                </td>
                                <td>
                                    <div class="price-older">
                                        <%#ToNo(Eval("Mota2").ToString()) %>
                                    </div>
                                </td>
                                <td>
                                    <div class="button-target">
                                        <div class="chitiet">
                                            <a>
                                                <%=BicLanguage.CurrentLanguage=="vi"?"Chi tiết":"Detail" %>
                                            </a>
                                        </div>
                                        <div class="dattour">
                                            <a onclick="saveTour(<%#Eval("TourID")%>)">
                                                <%=BicLanguage.CurrentLanguage=="vi"?"Đặt tour":"Book now" %>
                                            </a>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </bic:TourListViewPager>
                </table>
            </div>
        </div>
    </ItemTemplate>
</bic:MenuListView>
