<%@ Page Language="C#" AutoEventWireup="true" MaintainScrollPositionOnPostback="false" CodeFile="ShoppingCartViewToPrint.aspx.cs" Inherits="ShoppingCart" %>


<%@ Import Namespace="BIC.Utils" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="<%#ResolveUrl("~")%>/Controls/ShoppingCart/ShoppingCart.css" rel="stylesheet" />
    <script src="<%#ResolveUrl("~")%>/Scripts/jquery-1.7.1.min.js"></script>
    <style>
        @page {
            size: auto; /* auto is the current printer page size */
            margin-bottom: 0mm; /* this affects the margin in the printer settings */
        }


        .border {
            border: 1px solid #5555;
        }

        .shop-content {
            margin-top: 30px !important;
            padding: 15px;
        }

        .title {
            background: #ccc none repeat scroll 0 0;
            font-size: 16px;
            font-weight: bold;
            margin-bottom: 15px;
            padding: 10px 5px;
        }

        .break_module {
            margin: 15px 0;
        }

        .printProduct a {
            background: #ccc none repeat scroll 0 0;
            color: #000;
            display: inline-block;
            font-weight: bold;
            padding: 10px;
            text-decoration: none;
        }

        .printProduct {
            text-align: right;
        }
    </style>
    <telerik:RadCodeBlock runat="server">
        <%=Include.LibraryCss() %>
    </telerik:RadCodeBlock>
</head>
<body style="margin: 0">
    <form id="form1" runat="server">
        <telerik:RadScriptManager runat="server" ID="rcm1" />
        <div id="wrapper" style="margin-top: 20px">
            <div class="container">
                <div class="shop-cart" style="position: relative;">
                    <div class="header">
                        <div class="logo" style="margin-left: 15px;">
                            <a href="<%= BicApplication.URLRoot %>">
                                <img src="<%=Page.ResolveUrl("~/Styles/img/logo.png") %>" />
                            </a>
                        </div>
                    </div>
                    <div class="cap" style="width: 300px; height: 45px; position: absolute; top: 50px; right: 340px">
                        <div class="cap_center" style="background: none">
                            <div class="nav">
                                <asp:LinkButton runat="server" ID="lbtTitle" Style="color: #6e6e6e; font-size: 20px" Text='<%$ Resources:ShoppingCart,OrderDetail %>'></asp:LinkButton>
                            </div>
                        </div>
                    </div>
                    <%-- <div class="cap">
                        <div class="cap_left">
                        </div>
                        <div class="cap_center">
                            <div class="nav">
                                <asp:LinkButton runat="server" ID="lbtTitle" Text='<%$ Resources:ShoppingCart,OrderDetail %>'></asp:LinkButton>
                            </div>
                        </div>
                        <div class="cap_right"></div>
                    </div>--%>
                    <div class="border shop-content" style="margin-top: 30px">
                        <div style="margin-bottom: 5px; font-size: 12px; font-weight: bold; font-style: italic; text-align: right">
                            <span style="font-weight: normal"><%= BicResource.GetValue("ShoppingCart","OrderNumber") %></span>
                            <asp:Label runat="server" ID="lblOrderNo"></asp:Label>
                            - <span style="font-weight: normal"><%= BicResource.GetValue("CreatedDate") %> </span>
                            <asp:Label runat="server" ID="lblCreatedDate"></asp:Label>
                        </div>
                        <%--<div class="break_module"></div>--%>
                        <div class="temp_3">
                            <div class="title">
                                <div class="fl"></div>
                                <div class="fc"><span><%=BicResource.GetValue("ShoppingCart","NguoiDatHang") %></span></div>
                                <div class="fr"></div>
                            </div>
                            <div class="content payment_step_2">
                                <table cellspacing="0" cellpadding="0" class="order_information">
                                    <tr>
                                        <td class="name"><%=BicResource.GetValue("ShoppingCart","TenNguoiDat") %></td>
                                        <td class="value">
                                            <asp:Literal runat="server" ID="ltrTen"></asp:Literal></td>
                                    </tr>
                                    <tr class="hidden">
                                        <td class="name"><%=BicResource.GetValue("ShoppingCart","Adres") %></td>
                                        <td class="value">
                                            <asp:Literal runat="server" ID="ltrAddress"></asp:Literal></td>
                                    </tr>
                                    <tr>
                                        <td class="name"><%=BicResource.GetValue("ShoppingCart","Phone") %></td>
                                        <td class="value">
                                            <asp:Literal runat="server" ID="ltrPhone"></asp:Literal></td>
                                    </tr>
                                    <tr class="hidden">
                                        <td class="name"><%=BicResource.GetValue("ShoppingCart","Nip") %></td>
                                        <td class="value">
                                            <asp:Literal runat="server" ID="ltrNip"></asp:Literal></td>
                                    </tr>

                                    <%--    <tr>
                                        <td class="name"><%=BicResource.GetValue("ShoppingCart","City") %></td>
                                        <td class="value">
                                            <asp:Literal runat="server" ID="ltrCity"></asp:Literal></td>
                                    </tr>--%>
                                    <tr>
                                        <td class="name"><%=BicResource.GetValue("ShoppingCart","AdresNguoiGui") %></td>
                                        <td class="value">
                                            <asp:Literal runat="server" ID="ltrNgheNghiep"></asp:Literal></td>
                                    </tr>
                                    <tr>
                                        <td class="name"><%=BicResource.GetValue("ShoppingCart","Email") %></td>
                                        <td class="value">
                                            <asp:Literal runat="server" ID="ltrEmail"></asp:Literal></td>
                                    </tr>

                                    <tr>
                                        <td style="vertical-align: top;" class="name"><%=BicResource.GetValue("ShoppingCart","Notes2") %></td>
                                        <td class="value">
                                            <asp:Literal runat="server" ID="ltrNotes"></asp:Literal></td>
                                    </tr>
                                </table>
                            </div>
                            <div class="bottom">
                                <div class="fl"></div>
                                <div class="fr"></div>
                            </div>
                        </div>
                        <div class="break_module"></div>
                        <div class="temp_3">
                            <div class="title">
                                <div class="fl"></div>
                                <div class="fc"><span><%=BicResource.GetValue("ShoppingCart","NguoiNhanHang") %></span></div>
                                <div class="fr"></div>
                            </div>
                            <div class="content payment_step_2">
                                <table cellspacing="0" cellpadding="0" class="order_information">
                                    <tr>
                                        <td class="name"><%=BicResource.GetValue("ShoppingCart","TenNguoiNhan") %></td>
                                        <td class="value">
                                            <asp:Literal runat="server" ID="ltrTen2"></asp:Literal></td>
                                    </tr>
                                    <tr class="hidden">
                                        <td class="name"><%=BicResource.GetValue("ShoppingCart","Adres") %></td>
                                        <td class="value">
                                            <asp:Literal runat="server" ID="ltrAddress2"></asp:Literal></td>
                                    </tr>
                                    <tr>
                                        <td class="name"><%=BicResource.GetValue("ShoppingCart","Phone") %></td>
                                        <td class="value">
                                            <asp:Literal runat="server" ID="ltrPhone2"></asp:Literal></td>
                                    </tr>
                                    <tr class="hidden">
                                        <td class="name"><%=BicResource.GetValue("ShoppingCart","Nip") %></td>
                                        <td class="value">
                                            <asp:Literal runat="server" ID="ltrNip2"></asp:Literal></td>
                                    </tr>
                                    <%-- <tr>
                                        <td class="name"><%=BicResource.GetValue("ShoppingCart","City") %></td>
                                        <td class="value">
                                            <asp:Literal runat="server" ID="ltrCity2"></asp:Literal></td>
                                    </tr>--%>
                                    <tr>
                                        <td class="name"><%=BicResource.GetValue("ShoppingCart","AdresShipping") %></td>
                                        <td class="value">
                                            <asp:Literal runat="server" ID="ltrNgheNghiep2"></asp:Literal></td>
                                    </tr>
                                    <tr>
                                        <td class="name"><%=BicResource.GetValue("ShoppingCart","Email") %></td>
                                        <td class="value">
                                            <asp:Literal runat="server" ID="ltrEmail2"></asp:Literal></td>
                                    </tr>

                                    <tr>
                                        <td style="vertical-align: top;" class="name"><%=BicResource.GetValue("ShoppingCart","Notes2") %></td>
                                        <td class="value">
                                            <asp:Literal runat="server" ID="ltrNotes2"></asp:Literal></td>
                                    </tr>
                                </table>
                            </div>
                            <div class="bottom">
                                <div class="fl"></div>
                                <div class="fr"></div>
                            </div>
                        </div>
                        <div class="break_module"></div>
                        <div class="temp_3 hidden">
                            <div class="title">
                                <div class="fl"></div>
                                <div class="fc"><span><%=BicResource.GetValue("ShoppingCart","AddressRecervedOrder") %></span></div>
                                <div class="fr"></div>
                            </div>
                            <div class="content payment_step_2">
                                <table cellspacing="0" cellpadding="0" class="order_information">
                                    <tr>
                                        <td class="name"><%=BicResource.GetValue("ShoppingCart","AddressRecervedOrder") %> : </td>
                                        <td>
                                            <asp:Literal runat="server" ID="lblAddressRecervedOrder"></asp:Literal></td>
                                    </tr>
                                </table>
                            </div>
                            <div class="bottom">
                                <div class="fl"></div>
                                <div class="fr"></div>
                            </div>
                        </div>
                        <div class="break_module"></div>
                        <div class="temp_3">
                            <div class="title">
                                <div class="fl"></div>
                                <div class="fc"><span><%=BicResource.GetValue("ShoppingCart","ThanhToanVaChuyenHang") %></span></div>
                                <div class="fr"></div>
                            </div>
                            <div class="content payment_step_2">
                                <table cellspacing="0" cellpadding="0" class="order_information">
                                    <tr>
                                        <td class="name"><%=BicResource.GetValue("ShoppingCart","PhuongThucThanhToan") %></td>
                                        <td class="value">
                                            <asp:Literal runat="server" ID="ltPayMethod"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="name"><%=BicResource.GetValue("ShoppingCart","HinhThucVanChuyen") %></td>
                                        <td class="value">
                                            <asp:Literal runat="server" ID="ltShippingMethod"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <div runat="server" id="divShippingType">
                                            <td class="name">
                                                <%=BicResource.GetValue("ShoppingCart","ShippingType") %>:
                                            </td>
                                            <td class="value">
                                                <asp:Literal runat="server" ID="ltrShippingType"></asp:Literal>
                                            </td>
                                        </div>
                                    </tr>
                                </table>
                            </div>
                            <div class="bottom">
                                <div class="fl"></div>
                                <div class="fr"></div>
                            </div>
                        </div>

                        <table class="show_cart_table">
                            <tr class="text_title">
                                <td style="text-align: left; padding-left: 20px"><%=BicResource.GetValue("ShoppingCart","TenSP") %></td>
                                <td width="60px"><%=BicResource.GetValue("ShoppingCart","ProductCode") %></td>
                                <td width="58px"><%=BicResource.GetValue("ShoppingCart","Images") %></td>
                                <td width="60px"><%=BicResource.GetValue("ShoppingCart","Gia") %></td>
                                <td style="display: none;" width="60px"><%=BicResource.GetValue("ShoppingCart","Phantram") %></td>
                                <td width="40px"><%=BicResource.GetValue("ShoppingCart","SoLuong") %></td>
                                <td width="100px"><%=BicResource.GetValue("ShoppingCart","ThanhTien") %></td>
                                <td style="display: none;" width="40px"><%=BicResource.GetValue("ShoppingCart","VAT") %></td>
                                <td style="display: none;" width="60px"><%=BicResource.GetValue("ShoppingCart","TongTienFullVat") %></td>
                            </tr>

                            <asp:ListView ID="lvShoppingCart" OnItemDataBound="ShoppingCart_ItemDataBound" runat="server">
                                <ItemTemplate>
                                    <tr class="product_item">
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
                                        <td style="text-align: center; font-weight: bold">
                                            <telerik:RadCodeBlock ID="RadCodeBlock6" runat="server">
                                                <asp:Label ID="lblCode" runat="server" Text='<%#Eval("ProductCode") %>'></asp:Label>
                                            </telerik:RadCodeBlock>
                                        </td>
                                        <td class="avatar">
                                            <bic:ImageViewer runat="server" ID="ivArticle" ViewType="Fix" Target="_blank" ImageId='<%# GetImageID(Eval("ProductID")) %>' />
                                            <%--CssClass="imagebooka"--%>
                                            <bic:ImageViewer runat="server" ID="imghover" CssClass="imagehover" ImageId='<%# GetImageID(Eval("ProductID")) %>' />
                                        </td>
                                        <td style="text-align: center; color: #f15a22; font-weight: bold">
                                            <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server"><%#string.Format("{0:N0}{1}",BicConvert.ToDouble(Eval("ProductPrice").ToString().Replace(" ","").Replace(",","")),"&nbsp")%></telerik:RadCodeBlock>
                                        </td>
                                        <td style="text-align: center; display: none; font-weight: bold">
                                            <telerik:RadCodeBlock ID="RadCodeBlock7" runat="server">23%</telerik:RadCodeBlock>
                                        </td>
                                        <td class="inputnumber">
                                            <telerik:RadCodeBlock ID="RadCodeBlock3" runat="server">
                                                <asp:Label runat="server" ID="txtSoLuong" Text='<%# Eval("Total") %>'></asp:Label>
                                            </telerik:RadCodeBlock>
                                        </td>

                                        <td style="text-align: center; font-weight: bold">
                                            <telerik:RadCodeBlock ID="RadCodeBlock4" runat="server">
                                                <%--<asp:Label ID="lblTotal" runat="server" Text='<%#string.Format("{0:N0}{1}{2} ",BicConvert.ToDouble(Eval("Total")),"&nbsp",BicResource.GetValue("Product_LoaiTien"))%>'></asp:Label>--%>
                                                <asp:Label ID="lblTotal" runat="server" Text='<%#string.Format("{0:N0}{1} ",BicConvert.ToDouble(Eval("SubTotal")),"&nbsp")%>'></asp:Label>
                                            </telerik:RadCodeBlock>
                                        </td>
                                        <td style="text-align: center; display: none; font-weight: bold">
                                            <telerik:RadCodeBlock ID="RadCodeBlock8" runat="server">
                                                <asp:Label ID="lblVat" runat="server" Text='<%# String.Format("{0:N0}{1}",GetPriceVAT(Eval("SubTotal")),"&nbsp") %>'></asp:Label>
                                            </telerik:RadCodeBlock>
                                        </td>
                                        <td style="text-align: center; display: none; color: #f15a22; font-weight: bold">
                                            <telerik:RadCodeBlock ID="RadCodeBlock9" runat="server">
                                                <asp:Label ID="Label1" runat="server" Text='<%# String.Format("{0:N0}{1}",(Convert.ToDouble(GetPriceVAT(Eval("SubTotal"))) + Convert.ToDouble(Eval("SubTotal"))).ToString(),"&nbsp") %>'></asp:Label>
                                            </telerik:RadCodeBlock>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <EmptyDataTemplate>
                                    <tr>
                                        <td class="empty" colspan="10"><%=BicResource.GetValue("ShoppingCart","Noproduct") %></td>
                                    </tr>
                                </EmptyDataTemplate>
                                <EmptyItemTemplate>
                                    <tr>
                                        <td class="empty" colspan="10"><%=BicResource.GetValue("ShoppingCart","Noproduct") %></td>
                                    </tr>
                                </EmptyItemTemplate>
                            </asp:ListView>
                            <tr style="height: 37px !important">
                                <td colspan="5" class="totalmoney">Phí vận chuyển:
                                </td>
                                <td style="text-align: center">
                                    <asp:Label class="money" ID="lblShippingFee" runat="server"> </asp:Label>
                                </td>
                            </tr>
                            <tr style="height: 37px !important">
                                <td colspan="5" class="totalmoney">Sử dụng điểm tích lũy:
                                </td>
                                <td style="text-align: center">
                                    <asp:Label class="money" ID="lblUsePoint" runat="server"> </asp:Label>
                                </td>
                            </tr>
                            <tr class="totalrows" style="height: 37px !important">
                                <td colspan="5" class="totalmoney">
                                    <%=BicResource.GetValue("ShoppingCart","TongTien") %>
                                </td>

                                <td style="text-align: center">
                                    <asp:Label class="money" ID="lblOrderSubTotal" runat="server"> </asp:Label>
                                </td>
                                <td style="display: none;">
                                    <asp:Label runat="server" CssClass="money" ID="lblFullVat"></asp:Label>
                                </td>

                                <td style="display: none;" class="total">
                                    <asp:Label class="money" ID="lblMoneyTotal" runat="server">
                         
                                    </asp:Label>
                                </td>
                                <%-- <td class="item_remove"></td>--%>
                            </tr>
                        </table>

                        <table class="show_cart_table hidden" id="showCartTable" runat="server" clientidmode="Static">
                            <tr>
                                <td colspan="4" style="padding: 5px 8px">
                                    <span style="text-transform: uppercase; font-weight: bold; color: #034987"><%= BicResource.GetValue("ShoppingCart","Promotion") %></span>
                                </td>
                            </tr>
                            <tr class="text_title">
                                <td style="text-align: center; padding-left: 20px"><%=BicResource.GetValue("ShoppingCart","Product_PhanTram") %></td>
                                <td width="200px"><%=BicResource.GetValue("ShoppingCart","Product_ChietKhau") %></td>
                                <td width="200px"><%=BicResource.GetValue("ShoppingCart","Product_TongTien") %></td>
                                <td width="260px"><%=BicResource.GetValue("ShoppingCart","Product_TongTienSauCung") %></td>

                            </tr>
                            <tr>
                                <td style="text-align: center; font-weight: bold">
                                    <asp:Label runat="server" ID="lblPhanTram"></asp:Label>
                                    %</td>
                                <td style="text-align: center; font-weight: bold">
                                    <asp:Label runat="server" ID="lblSoTienChietKhau"></asp:Label>
                                </td>
                                <td style="text-align: center; font-weight: bold">
                                    <asp:Label runat="server" ID="lblTongTien"></asp:Label></td>

                                <td style="text-align: center; background-color: #f2f461; color: #f15a22; font-weight: bold">
                                    <asp:Label runat="server" ID="lblTongTienSauChietKhau"></asp:Label>
                                </td>
                            </tr>
                        </table>

                        <div class="clear"></div>
                        <div class="printProduct">
                            <a href='' onclick="window.print()">
                                <%--<img src="<%=Page.ResolveUrl("~/Controls/Article/img/Icon_print.png")%>" />--%> <%= BicResource.GetValue("ShoppingCart","PrintOrder") %>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
            <div class="guide"></div>
            <div class="footer"></div>
        </div>
    </form>
</body>
</html>
<script type="text/javascript">
    var id = '<%=id%>';
    $(".current").removeClass("current");
    $(".step_" + id).addClass("current");
    $("#progress_icon").removeClass().addClass("step_" + id + "_icon");
    $("#orange_line").removeClass().addClass("step_" + id + "_line");
</script>
