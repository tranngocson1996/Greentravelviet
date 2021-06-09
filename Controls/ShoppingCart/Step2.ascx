<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Step2.ascx.cs" Inherits="Controls_Article_ThongtinDathang" %>
<%@ Import Namespace="BIC.Utils" %>
<div id="Step2" class="w100 fl Step">
     <div class="w100 fl continute">
        <telerik:RadCodeBlock runat="server">
            <a href="<%= Common.GetLinkShort("/vi/shopping-cart.sc1.html") %>" title="Bước">< Quay lại bước trước</a>
        </telerik:RadCodeBlock>       
    </div>
    <telerik:RadAjaxPanel runat="server" ID="rapContact" LoadingPanelID="ralpContact">
        <telerik:RadCodeBlock runat="server">
            <div class="w100 fl listProduct">
                <div class="row">
                    <div class="col-lg-7 col-md-7 col-sm-6 col-xs-12">
                        <div class="VungTrai w100 fl Step2">
                            <div class="myCart w100 fl">Nhập thông tin đặt hàng</div>
                            <div class="VungTraiTable w100 fl">
                                <table>
                                    <tr>
                                        <td class="hidden-xs">Xin vui lòng nhập email: </td>
                                        <td><input type="text" required="true" placeholder="Xin vui lòng nhập email:" class="form-control" runat="server" ID="txtEmail" clientidmode="Static" /></td>
                                    </tr>
                                    <tr class="hidden">
                                        <td class="hidden-xs"></td>
                                        <td>
                                            <input type="radio" checked title="Đặt hàng mà không cần đăng ký" name="dathang[]" runat="server" ID="rbtKhongDangKi" clientidmode="Static"/> Đặt hàng mà không cần đăng ký
                                        </td>
                                    </tr>
                                    <tr class="hidden">
                                        <td class="hidden-xs"></td>
                                        <td>
                                            <telerik:RadCodeBlock runat="server">
                                                <input type="radio" title="Tôi đã có tài khoản" name="dathang[]" runat="server" ID="rbtTaiKhoan" clientidmode="Static"/>Tôi đã có tài khoản
                                            </telerik:RadCodeBlock>
                                        </td>
                                    </tr>
                                    <tr class="cart-login">
                                        <td class="hidden-xs"></td>
                                        <td>
                                            <telerik:RadCodeBlock runat="server">
                                                <input type="text" readonly="true" placeholder="Nhập email hoặc tài khoản" runat="server" ID="txtAccount" class="form-control" clientidmode="Static"/>
                                                <br />
                                                <input type="password" readonly="true" placeholder="Xin vui lòng nhập mật khẩu" runat="server" ID="txtMatKhau" class="form-control" clientidmode="Static"/>
                                            </telerik:RadCodeBlock>                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="hidden-xs"></td>
                                        <td>
                                            <asp:Button runat="server" CssClass="btnThanhToanStep1" ID="btnTiepTuc" Text="Tiếp tục" OnClick="btnThanhToan_OnClick"/>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-5 col-md-5 col-sm-6 col-xs-12 VungListHang">
                        <div class="VungTrai w100 fl">
                            <div class="myCart w100 fl">Thông tin đơn hàng (<asp:Label runat="server" ID="lblNumberProduct"></asp:Label>&nbsp;sản phẩm)
                            </div>
                            <table style="border-collapse: collapse; width: 100%; float: left;">
                                <thead>
                                <tr>
                                    <td>SẢN PHẨM</td>
                                    <td>SỐ LƯỢNG</td>
                                    <td>GIÁ</td>
                                </tr>
                                </thead>
                                <tbody>
                                <asp:ListView ID="lvShoppingCart" OnItemDataBound="ShoppingCart_ItemDataBound" runat="server">
                                    <ItemTemplate>
                                        <tr class="product_item">
                                            <td>
                                                <asp:Label ID="lblID" runat="server" Text='<%#Eval("proID") %>' Visible="False"></asp:Label>
                                                <telerik:RadCodeBlock ID="RadCodeBlock2" runat="server">
                                                    <a class="books-name" target="_blank" runat="server" id="productLink">
                                                        <b><%#Eval("proName") %></b>
                                                    </a>
                                                </telerik:RadCodeBlock>
                                            </td>
                                            <td>
                                                <%#Eval("Quantity") %>
                                            </td>
                                            <td>
                                                <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
                                                    <b><%#string.Format("{0:N0}{1}", BicConvert.ToDouble(Eval("Price").ToString().Replace(" ", "").Replace(",", "")), "&nbsp") %></b>
                                                </telerik:RadCodeBlock>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:ListView>
                                <tr>
                                    <td>Tạm tính:</td>
                                    <td colspan="2"><asp:Label runat="server" ID="lblTotalSaft"></asp:Label> VNĐ</td>
                                </tr>
                                <tr>
                                    <td><b>Thành tiền</b> (Tổng số tiền thanh toán):</td>
                                    <td colspan="2" class="lblTotalMoney"><b><asp:Label runat="server" ID="lblTotalMoney" CssClass="lblTotalMoney"></asp:Label> VNĐ</b></td>
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
<script>
    $(document).ready(function () {
        $("#rbtKhongDangKi, #rbtTaiKhoan").change(function () {
            if ($("#rbtKhongDangKi").is(":checked")) {
                $('.cart-login').hide();
                $('#txtAccount').attr('readonly', true);
                $('#txtMatKhau').attr('readonly', true);
                $('#txtEmail').attr('readonly', false);
            }
            else if ($("#rbtTaiKhoan").is(":checked")) {
                $('.cart-login').show();
                $('#txtAccount').attr('readonly', false);
                $('#txtMatKhau').attr('readonly', false);
                $('#txtEmail').attr('readonly', true);
            }
        });
    });
</script>

