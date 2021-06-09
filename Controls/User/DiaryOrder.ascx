<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DiaryOrder.ascx.cs" Inherits="Controls_User_DiaryOrder" %>
<%@ Import Namespace="BIC.Utils" %>
<asp:DataGrid ID="grdOrder" DataKeyField="OrderCode" CssClass="table table-bordered" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="True"
    OnPageIndexChanged="grdOrder_PageIndexChanged" PagerStyle-Mode="NumericPages" PagerStyle-HorizontalAlign="Center" OnItemCommand="grdOrder_ItemCommand">
    <HeaderStyle CssClass="info"></HeaderStyle>
    <ItemStyle CssClass="success"></ItemStyle>
    <AlternatingItemStyle CssClass="default"></AlternatingItemStyle>
    <Columns>
        <asp:BoundColumn DataField="ModifiedDate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Ngày đặt hàng" Visible="true" />
        <asp:BoundColumn DataField="OrderCode" HeaderText="Mã Đơn Hàng" Visible="true" />
        <asp:TemplateColumn>
            <HeaderTemplate>
                <div class="text-center">Xem</div>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:LinkButton runat="server" CommandName="ViewDetail" CommandArgument='<%# Eval("OrderMenuID") %>' ID="lbtnDetail" Text="Chi tiết"></asp:LinkButton>
            </ItemTemplate>
            <ItemStyle CssClass="price"></ItemStyle>
        </asp:TemplateColumn>
        <asp:TemplateColumn>
            <HeaderTemplate>
                <div class="text-center">Tổng tiền thanh toán</div>
            </HeaderTemplate>
            <ItemTemplate>
                <%# string.Format("{0:N0}", BicConvert.ToDouble(Eval("OrderSubTotal"))) %>
            </ItemTemplate>
            <ItemStyle CssClass="orderstatus"></ItemStyle>
        </asp:TemplateColumn>
        <asp:BoundColumn DataField="PaymentStatus" HeaderText="Trạng thái thanh toán" Visible="true" />
        <asp:TemplateColumn>
            <HeaderTemplate>
                <div class="text-center">Trạng thái giao hàng</div>
            </HeaderTemplate>
            <ItemTemplate>
                <%# Eval("ShippingStatus") %>
                <%--                <div class='<%# string.IsNullOrEmpty(Eval("Column4").ToString()) ? "hidden" : string.Empty %>'>
                    <a href='<%# "http://mc.shipchung.vn/van-don.html?sc_code=" + Eval("Column4") %>' target="_blank">Kiểm tra</a>
                </div>--%>
            </ItemTemplate>
            <ItemStyle CssClass="shipstatus"></ItemStyle>
        </asp:TemplateColumn>
    </Columns>
    <PagerStyle CssClass="Paging" Position="Bottom" NextPageText="Previous" PrevPageText="Next"></PagerStyle>
</asp:DataGrid>
<asp:Panel runat="server" ID="pnOrderDetail" Visible="False">
    <div class="order-detail">
        <div class="box-title">
            <asp:LinkButton runat="server" ID="lbtTitle" CssClass="text" Text="<%$ Resources:ShoppingCart,OrderDetail %>"></asp:LinkButton>
        </div>
        <div class="order-content">
            <div class="order-info">
                <div class="title">
                    <span><%= BicResource.GetValue("ShoppingCart", "OrderInfo") %></span>
                </div>
                <div class="desc">
                    <div class="row">
                        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12 desc-left">
                            <div class="group-text">
                                <label><%= BicResource.GetValue("ShoppingCart", "OrderNumber") %></label>
                                <asp:Label runat="server" ID="lblOrderNo"></asp:Label>
                            </div>
                            <div class="group-text">
                                <label><%= BicResource.GetValue("ShoppingCart", "CreatedDate") %></label>
                                <asp:Label runat="server" ID="lblCreatedDate"></asp:Label>
                            </div>
                            <div class="group-text">
                                <label><%= BicResource.GetValue("ShoppingCart", "Order") %></label>
                                <asp:Literal runat="server" ID="ltrOrder"></asp:Literal>
                            </div>
                            <div class="group-text">
                                <label><%= BicResource.GetValue("ShoppingCart", "StatusShipping") %></label>
                                <asp:Literal runat="server" ID="ltrStatus"></asp:Literal>
                            </div>
                            <div class="group-text">
                                <label><%= BicResource.GetValue("ShoppingCart", "ShippingFee") %></label>
                                <asp:Literal runat="server" ID="ltrShippingFee"></asp:Literal>
                            </div>
                            <div class="group-text" runat="server" id="divShippingType">
                                <label><%= BicResource.GetValue("ShoppingCart", "ShippingType") %></label>
                                <asp:Literal runat="server" ID="ltrShippingType"></asp:Literal>
                            </div>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12 desc-right">
                            <div class="group-text">
                                <label><%= BicResource.GetValue("ShoppingCart", "TenNguoiNhan") %></label>
                                <asp:Literal runat="server" ID="ltrTen2"></asp:Literal>
                            </div>
                            <div class="group-text">
                                <label><%= BicResource.GetValue("AddressGiaoHang") %></label>
                                <asp:Literal runat="server" ID="ltrNgheNghiep2"></asp:Literal>
                            </div>
                            <div class="group-text">
                                <label><%= BicResource.GetValue("ShoppingCart", "PhoneShipping") %></label>
                                <asp:Literal runat="server" ID="ltrPhone2"></asp:Literal>
                            </div>
                            <div class="group-text">
                                <label><%= BicResource.GetValue("ShoppingCart", "MethodPayment") %></label>
                                <asp:Literal runat="server" ID="ltPayMethod"></asp:Literal>
                            </div>
                            <div class="group-text">
                                <label>Điểm sử dụng:</label>
                                <asp:Literal runat="server" ID="ltrUsePoint"></asp:Literal>
                            </div>
                            <div class="group-text" runat="server" id="div2">
                                <label>Tổng tiền thanh toán:</label>
                                <asp:Literal runat="server" ID="lblMoneyTotal"></asp:Literal>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="clear30"></div>
            <div class="order-cart">
                <table class="table">
                    <tr class="text_title">
                        <td width="58px"><%= BicResource.GetValue("ShoppingCart", "Images") %></td>
                        <td style="padding-left: 20px; text-align: left;"><%= BicResource.GetValue("ShoppingCart", "TenSP") %></td>
                        <td width="60px"><%= BicResource.GetValue("ShoppingCart", "ProductCode") %></td>

                        <td width="60px"><%= BicResource.GetValue("ShoppingCart", "Gia") %></td>
                        <td style="display: none;" width="60px"><%= BicResource.GetValue("ShoppingCart", "Phantram") %></td>
                        <td width="60px"><%= BicResource.GetValue("ShoppingCart", "SoLuong") %></td>
                        <td width="100px"><%= BicResource.GetValue("ShoppingCart", "ThanhTien") %></td>

                        <td style="display: none;" width="40px"><%= BicResource.GetValue("ShoppingCart", "VAT") %></td>
                        <td style="display: none;" width="60px"><%= BicResource.GetValue("ShoppingCart", "TongTienFullVat") %></td>
                        <td width="100px" class="hidden">Đánh giá sản phẩm</td>
                    </tr>
                    <asp:ListView ID="lvShoppingCart" OnItemDataBound="ShoppingCart_ItemDataBound" runat="server">
                        <ItemTemplate>
                            <tr class="product_item">
                                <td class="avatar">
                                    <bic:ImageViewer runat="server" ID="ivArticle" ViewType="Fix" Target="_blank" ImageId='<%# GetImageID(Eval("ProductID")) %>' />
                                    <bic:ImageViewer runat="server" ID="imghover" CssClass="imagehover" ImageId='<%# GetImageID(Eval("ProductID")) %>' />
                                </td>
                                <td>
                                    <div class="tensach">
                                        <asp:Label ID="lblID" runat="server" Text='<%#Eval("ProductID") %>' Visible="False"></asp:Label>
                                        <telerik:RadCodeBlock ID="RadCodeBlock2" runat="server">
                                            <a target="_blank" runat="server" id="productLink" class="books-name">
                                                <%#Eval("ProductName") %>
                                            </a>
                                        </telerik:RadCodeBlock>
                                    </div>
                                </td>
                                <td style="font-weight: bold; text-align: center;">
                                    <telerik:RadCodeBlock ID="RadCodeBlock6" runat="server">
                                        <asp:Label ID="lblCode" runat="server" Text='<%#Eval("ProductCode") %>'></asp:Label>
                                    </telerik:RadCodeBlock>
                                </td>
                                <td style="color: #f15a22; font-weight: bold; text-align: center;">
                                    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
                                        <%#string.Format("{0:N0}{1}", BicConvert.ToDouble(Eval("ProductPrice").ToString().Replace(" ", "").Replace(",", "")), "&nbsp") %>
                                    </telerik:RadCodeBlock>
                                </td>
                                <td style="display: none; font-weight: bold; text-align: center;">
                                    <telerik:RadCodeBlock ID="RadCodeBlock7" runat="server">23%</telerik:RadCodeBlock>
                                </td>
                                <td class="inputnumber" style="text-align: center;">
                                    <telerik:RadCodeBlock ID="RadCodeBlock3" runat="server">
                                        <asp:Label runat="server" ID="txtSoLuong" Text='<%# Eval("Total") %>'></asp:Label>
                                    </telerik:RadCodeBlock>
                                </td>
                                <td style="font-weight: bold; text-align: center;">
                                    <telerik:RadCodeBlock ID="RadCodeBlock4" runat="server">
                                        <asp:Label ID="lblTotal" runat="server" Text='<%#string.Format("{0:N0}{1} ", BicConvert.ToDouble(Eval("SubTotal")), "&nbsp") %>'></asp:Label>
                                    </telerik:RadCodeBlock>
                                </td>
                                <td style="font-weight: bold; text-align: center;" class="hidden">
                                    <telerik:RadCodeBlock ID="RadCodeBlock5" runat="server">
                                        <asp:HyperLink runat="server" ID="ReviewProduct"></asp:HyperLink>
                                    </telerik:RadCodeBlock>
                                </td>
                                <td style="display: none; font-weight: bold; text-align: center;">
                                    <telerik:RadCodeBlock ID="RadCodeBlock8" runat="server">
                                        <asp:Label ID="lblVat" runat="server" Text='<%# string.Format("{0:N0}{1}", GetPriceVAT(Eval("SubTotal")), "&nbsp") %>'></asp:Label>
                                    </telerik:RadCodeBlock>
                                </td>
                                <td style="color: #f15a22; display: none; font-weight: bold; text-align: center;">
                                    <telerik:RadCodeBlock ID="RadCodeBlock9" runat="server">
                                        <asp:Label ID="Label1" runat="server" Text='<%# string.Format("{0:N0}{1}", Convert.ToDouble(GetPriceVAT(Eval("SubTotal"))) + Convert.ToDouble(Eval("SubTotal")), "&nbsp") %>'></asp:Label>
                                    </telerik:RadCodeBlock>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <EmptyDataTemplate>
                            <tr>
                                <td class="empty" colspan="10"><%= BicResource.GetValue("ShoppingCart", "Noproduct") %></td>
                            </tr>
                        </EmptyDataTemplate>
                        <EmptyItemTemplate>
                            <tr>
                                <td class="empty" colspan="10"><%= BicResource.GetValue("ShoppingCart", "Noproduct") %></td>
                            </tr>
                        </EmptyItemTemplate>
                    </asp:ListView>
                    <tr class="totalrows" style="display: none; height: 37px !important;">
                        <td colspan="5" class="totalmoney">
                            <%= BicResource.GetValue("ShoppingCart", "TongTien") %>
                        </td>

                        <td style="text-align: center">
                            <asp:Label class="money" ID="lblOrderSubTotal" runat="server"> </asp:Label>
                        </td>
                        <td style="display: none;">
                            <asp:Label runat="server" CssClass="money" ID="lblFullVat"></asp:Label>
                        </td>

                        <td style="display: none;" class="total">
                            <asp:Label class="money" ID="lblMoneyTotal1" runat="server">

                            </asp:Label>
                        </td>
                    </tr>
                </table>
                <table class="show_cart_table hidden" id="showCartTable" runat="server" clientidmode="Static">
                    <tr>
                        <td colspan="4" style="padding: 5px 8px">
                            <span style="color: #034987; font-weight: bold; text-transform: uppercase;"><%= BicResource.GetValue("ShoppingCart", "Promotion") %></span>
                        </td>
                    </tr>
                    <tr class="text_title">
                        <td style="padding-left: 20px; text-align: center;"><%= BicResource.GetValue("ShoppingCart", "Product_PhanTram") %></td>
                        <td width="200px"><%= BicResource.GetValue("ShoppingCart", "Product_ChietKhau") %></td>
                        <td width="200px"><%= BicResource.GetValue("ShoppingCart", "Product_TongTien") %></td>
                        <td width="260px"><%= BicResource.GetValue("ShoppingCart", "Product_TongTienSauCung") %></td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold; text-align: center;">
                            <asp:Label runat="server" ID="lblPhanTram"></asp:Label>
                            %
                        </td>
                        <td style="font-weight: bold; text-align: center;">
                            <asp:Label runat="server" ID="lblSoTienChietKhau"></asp:Label>
                        </td>
                        <td style="font-weight: bold; text-align: center;">
                            <asp:Label runat="server" ID="lblTongTien"></asp:Label>
                        </td>

                        <td style="background-color: #f2f461; color: #f15a22; font-weight: bold; text-align: center;">
                            <asp:Label runat="server" ID="lblTongTienSauChietKhau"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Panel>
