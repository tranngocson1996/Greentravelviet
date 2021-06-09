<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Step3.ascx.cs" Inherits="Controls_Article_ThongtinDathang" %>
<%@ Import Namespace="BIC.Utils" %>
<div id="Step3" class="w100 fl Step">
    <div class="w100 fl continute">
        <telerik:RadCodeBlock runat="server">
            <a href="/vi/shopping-cart.sc2.html" title="Bước">< Quay lại bước trước</a>
        </telerik:RadCodeBlock>
    </div>
    <telerik:RadAjaxPanel runat="server" ID="rapContact" LoadingPanelID="ralpContact">
        <telerik:RadCodeBlock runat="server">
            <div class="w100 fl listProduct">
                <div class="row">
                    <div class="col-lg-7 col-md-7 col-sm-6 col-xs-12">
                        <div class="VungTrai w100 fl Step3">
                            <div class="myCart w100 fl">Địa chỉ giao hàng của quý khách </div>
                            <div class="VungTraiTable w100 fl">
                                <table>
                                    <tr>
                                        <td class="hidden-xs">Họ và tên <span class="text-danger">*</span></td>
                                        <td>
                                            <input type="text" clientidmode="Static" placeholder="Họ và tên" class="form-control" runat="server" id="txtFullName1" /></td>
                                    </tr>
                                    <tr>
                                        <td class="hidden-xs">Địa chỉ <span class="text-danger">*</span></td>
                                        <td>
                                            <textarea type="text" clientidmode="Static" placeholder="Vui lòng điền CHÍNH XÁC tầng, số nhà, đường, xã , phường để tránh trường hợp đơn hàng bị hủy ngoài ý muốn" class="form-control" runat="server" id="txtAddress1" rows="3"></textarea></td>

                                    </tr>
                                    <tr>
                                        <td class="hidden-xs">Tỉnh/Thành phố <span class="text-danger">*</span></td>
                                        <td>
                                            <asp:DropDownList runat="server" ID="ddlCity1" CssClass="form-control" ClientIDMode="Static" OnSelectedIndexChanged="ddlCity1_OnSelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td class="hidden-xs">Quận/huyện <span class="text-danger">*</span></td>
                                        <td>
                                            <asp:DropDownList runat="server" ID="ddlDistrict1" CssClass="form-control" ClientIDMode="Static" OnSelectedIndexChanged="ddlDistrict1_OnSelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td class="hidden-xs">Điện thoại di động <span class="text-danger">*</span></td>
                                        <td>
                                            <input type="text" clientidmode="Static" placeholder="Điện thoại di động" class="form-control" runat="server" id="txtPhone1" />
                                            <span class="captionGt hidden">Gordon hoặc tổng đài tự động của chúng tôi sẽ liên hệ quý khách theo số điện thoại này để xác nhận hoặc thông báo giao hàng
                                            </span>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td class="hidden-xs">Ghi chú</td>
                                        <td>
                                            <textarea type="text" placeholder="Những yêu cầu đặc biệt khác" clientidmode="Static" class="form-control" runat="server" id="txtNode1"></textarea>
                                        </td>

                                    </tr>

                                </table>
                                <div class="w100 fl ThongTinThanhToan">
                                    <div class="myCart2 w100 fl">
                                        <input type="checkbox" id="chkThongTinThanhToanKhac" runat="server" clientidmode="Static" />Thông tin thanh toán khác địa chỉ giao hàng
                                    </div>
                                    <div class="w100 fl" id="VungTraiTableThanhToanKhac" style="display: none;">
                                        <table>
                                            <tr>
                                                <td class="hidden-xs">Họ và tên <span class="text-danger">*</span></td>
                                                <td>
                                                    <input type="text" clientidmode="Static" placeholder="Họ và tên" class="form-control" runat="server" id="txtFullName2" /></td>

                                            </tr>
                                            <tr>
                                                <td class="hidden-xs">Địa chỉ <span class="text-danger">*</span></td>
                                                <td>
                                                    <textarea type="text" clientidmode="Static" placeholder="Vui lòng điền CHÍNH XÁC tầng, số nhà, đường, xã , phường để tránh trường hợp đơn hàng bị hủy ngoài ý muốn" class="form-control" runat="server" id="txtAddress2"></textarea></td>

                                            </tr>
                                            <tr>
                                                <td class="hidden-xs">Tỉnh/Thành phố <span class="text-danger">*</span></td>
                                                <td>
                                                    <asp:DropDownList runat="server" ID="ddlCity2" CssClass="form-control" ClientIDMode="Static" OnSelectedIndexChanged="ddlCity2_OnSelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                                </td>

                                            </tr>
                                            <tr>
                                                <td class="hidden-xs">Quận/huyện <span class="text-danger">*</span></td>
                                                <td>
                                                    <asp:DropDownList runat="server" ID="ddlDistrict2" CssClass="form-control" ClientIDMode="Static" OnSelectedIndexChanged="ddlDistrict1_OnSelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="hidden-xs">Điện thoại di động <span class="text-danger">*</span></td>
                                                <td>
                                                    <input type="text" clientidmode="Static" pattern="\d*" placeholder="Điện thoại di động" class="form-control" runat="server" id="txtPhone2" />
                                                    <span class="captionGt hidden">Chúng tôi sẽ liên hệ quý khách theo số điện thoại này để xác nhận hoặc thông báo giao hàng
                                                    </span>
                                                </td>

                                            </tr>
                                            <tr>
                                                <td class="hidden-xs">Ghi chú</td>
                                                <td>
                                                    <textarea type="text" clientidmode="Static" placeholder="Những yêu cầu đặc biệt khác" class="form-control" runat="server" id="txtNote2"></textarea>
                                                </td>

                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <table style="margin-top: 20px;">
                                    <tr>
                                        <td colspan="1"><b>Thông tin giao hàng</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="hidden-xs">Phương thức giao hàng</td>
                                        <td>
                                            <asp:DropDownList runat="server" ID="ddlShippingMethod" CssClass="form-control" ClientIDMode="Static" AutoPostBack="True" OnSelectedIndexChanged="ddlShippingMethod_OnSelectedIndexChanged"></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="hidden-xs"></td>
                                        <td>
                                            <asp:RadioButtonList ID="tblShippingType" CssClass="tblShippingType" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="tblShippingType_OnSelectedIndexChanged" AutoPostBack="True" Style="float: left;">
                                                <asp:ListItem Text="Chuyển phát nhanh" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Tiết kiệm" Value="1" Selected="True"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="hidden-xs" style="vertical-align: top">Phương thức thanh toán</td>
                                        <td>
                                            <asp:DropDownList runat="server" ID="ddlPayMethod" CssClass="form-control" ClientIDMode="Static"></asp:DropDownList>
                                            <div class="note">
                                                <asp:ListView ID="lvThanhToanInfo" runat="server">
                                                    <ItemTemplate>
                                                        <div class="item" data-item="<%# Eval("CategoryID") %>"><%#  Eval("Note") %></div>
                                                    </ItemTemplate>
                                                </asp:ListView>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="hidden-xs">
                                            <a class="btnThanhToanStep1" href="/"><< Mua thêm hàng</a>
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="lbtNext" CssClass="submit_btnNext" OnClick="lbtNext_OnClick" ClientIDMode="Static" Style="display: none;" runat="server"></asp:LinkButton>
                                            <input type="button" class="btnThanhToanStep1" id="btnTiepTuc" value="Đặt hàng >>" onclick="CheckTT()" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-5 col-md-5 col-sm-6 col-xs-12 VungListHang">
                        <div class="VungTrai w100 fl">
                            <div class="myCart w100 fl">
                                Thông tin đơn hàng (<asp:Label runat="server" ID="lblNumberProduct"></asp:Label>&nbsp;sản phẩm)
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
                                        <td colspan="2">
                                            <asp:Label runat="server" ID="lblTotalSaft"></asp:Label>
                                            VNĐ</td>
                                    </tr>
                                    <tr>
                                        <td>Phí vận chuyển:</td>
                                        <td colspan="2">
                                            <asp:Label runat="server" ID="lblPhiVanChuyen"></asp:Label>
                                            VNĐ</td>
                                    </tr>
                                    <tr>
                                        <td><b>Thành tiền</b> (Tổng số tiền thanh toán):</td>
                                        <td colspan="2" class="lblTotalMoney"><b>
                                            <asp:Label runat="server" ID="lblTotalMoney" CssClass="lblTotalMoney"></asp:Label>
                                            VNĐ</b></td>
                                    </tr>

                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </telerik:RadCodeBlock>
        <telerik:RadScriptBlock runat="server" ID="RadScriptBlock123">
            <script type="text/javascript">
                $(document).ready(function () {
                    $("#chkThongTinThanhToanKhac").change(function () {
                        $("#VungTraiTableThanhToanKhac").toggle();
                    });

                    if ($("#chkThongTinThanhToanKhac").is(":checked")) {
                        $("#VungTraiTableThanhToanKhac").show();
                    }
                });


                var check = 1;
                var check1 = 1;
                function CheckTT() {

                    if ($('#txtFullName1').val().length == 0) {
                        $('#txtFullName1').addClass("error");
                        $('#txtFullName1').focus();
                        check = 0;
                        return false;
                    } else {
                        $('#txtFullName1').removeClass("error");
                        check = 1;
                    }
                    //var checkEmail = checkRegexp($('#txtEmail').val(), /^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i, "Email không đúng định dạng.");
                    //if (checkEmail == false) {
                    //    $('#txtEmail').addClass("error");
                    //    $('#txtEmail').focus();
                    //    check = 0;
                    //    return false;
                    //} else {
                    //    $('#txtEmail').removeClass("error");
                    //    check = 1;
                    //}
                    if ($('#txtAddress1').val().length == 0) {
                        $('#txtAddress1').addClass("error");
                        $('#txtAddress1').focus();
                        check = 0;
                        return false;
                    } else {
                        $('#txtAddress1').removeClass("error");
                        check = 1;
                    }
                    if ($('#ddlCity1').find(":selected").val() == '0') {
                        $('#ddlCity1').addClass("error");
                        $('#ddlCity1').focus();
                        check = 0;
                        return false;
                    } else {
                        $('#ddlCity1').removeClass("error");
                        check = 1;
                    }

                    if ($('#ddlDistrict1').find(":selected").val() == 0) {
                        $('#ddlDistrict1').addClass("error");
                        $('#ddlDistrict1').focus();
                        check = 0;
                        return false;
                    } else {
                        $('#ddlDistrict1').removeClass("error");
                        check = 1;
                    }
                    if ($('#txtPhone1').val().length == 0) {
                        $('#txtPhone1').addClass("error");
                        $('#txtPhone1').focus();
                        check = 0;
                        return false;
                    } else {
                        $('#txtPhone1').removeClass("error");
                        check = 1;
                    }

                    if ($('#ddlShippingMethod').find(":selected").val() == 0) {
                        $('#ddlShippingMethod').addClass("error");
                        $('#ddlShippingMethod').focus();
                        check = 0;
                        return false;
                    } else {
                        $('#ddlShippingMethod').removeClass("error");
                        check = 1;
                    }
                    if ($('#ddlPayMethod').find(":selected").val() == 0) {
                        $('#ddlPayMethod').addClass("error");
                        $('#ddlPayMethod').focus();
                        check = 0;
                        return false;
                    } else {
                        $('#ddlPayMethod').removeClass("error");
                        check = 1;
                    }
                    if (check == 1) {
                        if ($("#chkThongTinThanhToanKhac").is(":checked")) {
                            CheckTT2();
                            if (check1 == 1) {
                                __doPostBack('<%=lbtNext.UniqueID%>', '');
                            }
                        } else {
                            __doPostBack('<%=lbtNext.UniqueID%>', '');
                        }
                    }
                    else {
                        return false;
                    }
                }

                function CheckTT2() {
                    if ($('#txtFullName2').val().length == 0) {
                        $('#txtFullName2').addClass("error");
                        $('#txtFullName2').focus();
                        check1 = 0;
                        return false;
                    } else {
                        $('#txtFullName2').removeClass("error");
                        check1 = 1;
                    }

                    if ($('#txtAddress2').val().length == 0) {
                        $('#txtAddress2').addClass("error");
                        $('#txtAddress2').focus();
                        check1 = 0;
                        return false;
                    } else {
                        $('#txtAddress2').removeClass("error");
                        check1 = 1;
                    }
                    if ($('#ddlCity2').find(":selected").val() == '0') {
                        $('#ddlCity2').addClass("error");
                        $('#ddlCity2').focus();
                        check1 = 0;
                        return false;
                    } else {
                        $('#ddlCity2').removeClass("error");
                        check1 = 1;
                    }

                    if ($('#ddlDistrict2').find(":selected").val() == 0) {
                        $('#ddlDistrict2').addClass("error");
                        $('#ddlDistrict2').focus();
                        check1 = 0;
                        return false;
                    } else {
                        $('#ddlDistrict2').removeClass("error");
                        check1 = 1;
                    }
                    if ($('#txtPhone2').val().length == 0) {
                        $('#txtPhone2').addClass("error");
                        $('#txtPhone2').focus();
                        check1 = 0;
                        return false;
                    } else {
                        $('#txtPhone2').removeClass("error");
                        check1 = 1;
                    }

                    if (check1 == 1) {
                        __doPostBack('<%=lbtNext.UniqueID%>', '');
                    }
                    else {
                        return false;
                    }
                }

                function keydownonlynumber(a) {
                    $(a)
                        .keydown(function (e) {
                            // Allow: backspace, delete, tab, escape, enter and .
                            if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
                                // Allow: Ctrl+A, Command+A
                                (e.keyCode === 65 && (e.ctrlKey === true || e.metaKey === true)) ||
                                // Allow: home, end, left, right, down, up
                                (e.keyCode >= 35 && e.keyCode <= 40)) {
                                // let it happen, don't do anything
                                return;
                            }
                            // Ensure that it is a number and stop the keypress
                            if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
                                e.preventDefault();
                            }
                        });
                }
                //Set only number to phone
                $(document).ready(function () {
                    keydownonlynumber('#txtPhone1');
                    keydownonlynumber('#txtPhone2');
                });

                $('#ddlPayMethod').change(function () {
                    var seclectItem = $(this).val();
                    $('.note .item').each(function () {
                        if ($(this).data("item") == seclectItem) {
                            $(this).parent().show();
                            $(this).addClass("active");
                        }
                        else {
                            $(this).parent().hide();
                            $('.note .item').removeClass("active");
                        }
                    });
                });
            </script>
        </telerik:RadScriptBlock>
    </telerik:RadAjaxPanel>
    <telerik:RadAjaxLoadingPanel runat="server" Skin="Windows7" ID="ralpContact" BackgroundPosition="Center" EnableSkinTransparency="true">
    </telerik:RadAjaxLoadingPanel>
</div>
