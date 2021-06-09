<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Step1.ascx.cs" Inherits="Controls_Article_ThongtinDathang" %>
<%@ Import Namespace="BIC.Utils" %>
<div id="Step1" class="w100 fl Step">
    <div class="w100 fl continute">
        <telerik:RadCodeBlock runat="server">
            <a href="<%= BicApplication.URLRoot %>" title="Tiếp tục mua hàng">< Tiếp tục mua hàng</a>
        </telerik:RadCodeBlock>       
    </div>
    <telerik:RadAjaxPanel runat="server" ID="rapContact" LoadingPanelID="ralpContact">
        <telerik:RadCodeBlock runat="server">
            <div class="w100 fl listProduct">
                <div class="row">
                    <div class="col-lg-7 col-md-7 col-sm-6 col-xs-12">
                        <div class="VungTrai w100 fl">
                             <div class="myCart w100 fl">Giỏ hàng của tôi</div>
                            <table style="border-collapse: collapse; width: 100%; float: left;">
                                <thead>
                                <tr>
                                    <th colspan="2">
                                        <asp:Label runat="server" ID="lblNumberProduct"></asp:Label>&nbsp;Sản phẩm</th>
                                    <th>Giá</th>
                                    <th>Số lượng</th>
                                    <th></th>
                                </tr>
                                </thead>
                                <tbody>
                                <asp:ListView ID="lvShoppingCart" OnItemDataBound="ShoppingCart_ItemDataBound" runat="server" OnItemCommand="lvShoppingCart_ItemCommand" OnItemDeleting="lvShoppingCart_ItemDeleting">
                                    <ItemTemplate>
                                        <tr class="product_item">
                                            <td>
                                                <telerik:RadCodeBlock ID="RadCodeBlock6" runat="server">
                                                    <a runat="server" id="imageLink" class="avatar">
                                                        <img src="<%#BicImage.GetPathImageThumb(BicConvert.ToInt32(Eval("ImageId").ToString())) %>" class="img img-responsive "/>
                                                    </a>
                                                </telerik:RadCodeBlock>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblID" runat="server" Text='<%#Eval("proID") %>' Visible="False"></asp:Label>
                                                <telerik:RadCodeBlock ID="RadCodeBlock2" runat="server">
                                                    <a class="books-name" target="_blank" runat="server" id="productLink">
                                                        <b><%#Eval("proName") %></b>
                                                    </a>
                                                </telerik:RadCodeBlock>
                                            </td>

                                            <td>
                                                <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
                                                    <b><%#string.Format("{0:N0}{1}", BicConvert.ToDouble(Eval("Price").ToString().Replace(" ", "").Replace(",", "")), "&nbsp") %></b>
                                                </telerik:RadCodeBlock>
                                            </td>
                                            <td runat="server" id="bodyQuantity">
                                                <telerik:RadCodeBlock ID="RadCodeBlock3" runat="server">
                                                    <telerik:RadNumericTextBox runat="server" ID="txtSoluong" OnTextChanged="OnNumber1Changed" AutoPostBack="True" Type="Number" Width="50px" Value='<%#BicConvert.ToInt32(Eval("Quantity")) %>' ShowSpinButtons="True" NumberFormat-DecimalDigits="0" MinValue="1">
                                                        <IncrementSettings/>
                                                    </telerik:RadNumericTextBox>
                                                </telerik:RadCodeBlock>
                                            </td>
                                            <td runat="server" id="Action" style="text-align: center">
                                                <telerik:RadCodeBlock ID="RadCodeBlock5" runat="server">
                                                    <asp:LinkButton ID='btlDelete' class="lbtDelete" CommandArgument='<%#Eval("proID") %>' OnClientClick="return confirm('Want to delete?');" CommandName="Delete" runat="server" Text="X"/>
                                                </telerik:RadCodeBlock>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <EmptyDataTemplate>
                                        <tr>
                                            <td class="empty" colspan="5"><%= BicResource.GetValue("ShoppingCart", "Noproduct") %></td>
                                        </tr>
                                    </EmptyDataTemplate>
                                    <EmptyItemTemplate>
                                        <tr>
                                            <td class="empty" colspan="5"><%= BicResource.GetValue("ShoppingCart", "Noproduct") %></td>
                                        </tr>
                                    </EmptyItemTemplate>
                                </asp:ListView>
                                </tbody>
                            </table>
                            <div class="clear"></div>
                        </div>                     
                    </div>
                    <div class="col-lg-5 col-md-5 col-sm-6 col-xs-12">
                        <div class="VungTrai w100 fl">
                            <div class="myCart w100 fl">Thông tin đơn hàng</div>
                            <table style="border-collapse: collapse; width: 100%; float: left;">
                                <thead>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>Tạm tính:</td>
                                        <td><asp:Label runat="server" ID="lblTotalSaft"></asp:Label> VNĐ</td>
                                    </tr>
                                <tr>
                                    <td><b>Thành tiền</b> (Tổng số tiền thanh toán):</td>
                                    <td><b><asp:Label runat="server" ID="lblTotalMoney"></asp:Label> VNĐ</b></td>
                                </tr>
                                <tr>
                                    <td colspan="2">                                    
                                        <asp:Button runat="server" CssClass="btnThanhToanStep1"  ID="btnThanhToan" Text="Tiến hành thanh toán" OnClick="btnThanhToan_OnClick"/>
                                    </td>
                                </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>

        </telerik:RadCodeBlock>
    </telerik:RadAjaxPanel>
</div>

