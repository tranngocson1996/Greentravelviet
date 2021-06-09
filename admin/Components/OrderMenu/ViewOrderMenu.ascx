<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewOrderMenu.ascx.cs" Inherits="Admin_Components_OrderMenu_ViewOrderMenu" %>
<%@ Import Namespace="BIC.Utils" %>

<%= Include.CssAdd(Page.ResolveUrl("~/admin/Styles/Layout.css")) %>
<div class="form-tool">
    <%--<bic:ToolBar ID="tbTop" runat="server" />--%>
    <div id="info">
        Thông tin chung đơn hàng
    </div>
    <div id="billing">
        Người đặt và người nhận
    </div>
    <div id="products">
        Danh sách sản phẩm
    </div>
    <div id="OrderNote">
        Ghi chú
    </div>
    <div id="OrderDetail">
        Chi tiết đơn hàng
    </div>
</div>
<%--<div class="form-caption">
   
</div>--%>
<div class="form-view" id="content_info">
    <div id="orderinfo" runat="server" clientidmode="Static">
        <div class="frow height10">
            Thông tin đơn hàng
        </div>
        <div class="frow">
            <div class="frow-wrapp">
                <div class="label">Mã đơn hàng </div>
                <div class="input">
                    <asp:Label ID="lblDBOrderCode" CssClass="Label" runat="server" />
                </div>
            </div>
        </div>
        <div class="frow hidden">
            <div class="frow-wrapp">
                <div class="label">Mã người đặt hàng</div>
                <div class="input">
                    <asp:Label ID="lblUserID" CssClass="Label" runat="server" />
                </div>
            </div>
        </div>

        <div class="frow">
            <div class="frow-wrapp">
                <div class="label">Ngày đặt hàng</div>
                <div class="input">
                    <asp:Label ID="lblDBShippingDate" CssClass="Label" runat="server" />
                </div>
            </div>
        </div>
        <div class="frow">
            <div class="frow-wrapp">
                <div class="label">Phương thức thanh toán </div>
                <div class="input">
                    <asp:Label ID="lblDBPaymentMethod" CssClass="Label" runat="server" />
                </div>
            </div>
        </div>
        <div class="frow">
            <div class="frow-wrapp">
                <div class="label">Phương thức vận chuyển </div>
                <div class="input">
                    <asp:Label ID="lblDBShippingMethod" CssClass="Label" runat="server" />
                </div>
            </div>
        </div>
        <div class="frow hidden">
            <div class="frow-wrapp">
                <div class="label">Địa chỉ nhận hóa đơn </div>
                <div class="input">
                    <asp:Label ID="lblInvoiceAddress" CssClass="Label" runat="server" />
                </div>
            </div>
        </div>
        <div class="frow hidden">
            <div class="frow-wrapp">
                <div class="label">Tiền trước thuế </div>
                <div class="input">
                    <asp:Label ID="lblDBOrderSubTotal" CssClass="Label" runat="server" />
                </div>
            </div>
        </div>
        <div class="frow hidden">
            <div class="frow-wrapp">
                <div class="label">Thuế </div>
                <div class="input">
                    <asp:Label ID="lblDBOrderTax" CssClass="Label" runat="server" />
                </div>
            </div>
        </div>
        <div class="frow hidden">
            <div class="frow-wrapp">
                <div class="label">Giảm giá </div>
                <div class="input">
                    <asp:Label ID="lblDBOrderDiscount" CssClass="Label" runat="server" />
                </div>
            </div>
        </div>
        <div class="frow hidden">
            <div class="frow-wrapp">
                <div class="label">Phí vận chuyển </div>
                <div class="input">
                    <asp:Label ID="lblDBOrderShippingFee" CssClass="Label" runat="server" />
                    <span id="editShippingFree">Thay đổi</span>
                    <asp:TextBox runat="server" ID="txtShippingFee" AutoPostBack="True" ClientIDMode="Static" OnTextChanged="txtShippingFee_TextChanged"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="frow">
            <div class="frow-wrapp">
                <div class="label">Trạng thái thanh toán </div>
                <div class="input">
                    <asp:Label ID="lblDBPaymentStatus" CssClass="Label" runat="server" />
                    <span id="editPaymentStatus">Thay đổi</span>
                    <asp:DropDownList runat="server" ID="ddlPaymentStatus" AutoPostBack="True" ClientIDMode="Static" OnSelectedIndexChanged="ddlPaymentStatus_SelectedIndexChanged">
                        <Items>
                            <asp:ListItem Text="-- Chọn trạng thái thanh toán --" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Chưa thanh toán" Value="Chưa thanh toán"></asp:ListItem>
                            <asp:ListItem Text="Đã thanh toán" Value="Đã thanh toán"></asp:ListItem>
                        </Items>
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="frow">
            <div class="frow-wrapp">
                <div class="label">Trạng thái vận chuyển </div>
                <div class="input">
                    <asp:Label ID="lblDBShippingStatus" CssClass="Label" runat="server" />
                    <span id="editShippingStatus">Thay đổi</span>
                    <asp:DropDownList runat="server" ID="ddlShippingStatus" AutoPostBack="True" ClientIDMode="Static" OnSelectedIndexChanged="ddlShippingStatus_SelectedIndexChanged">
                        <Items>
                            <asp:ListItem Text="-- Chọn trạng thái vận chuyển --" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Chưa giao hàng" Value="Chưa giao hàng"></asp:ListItem>
                            <asp:ListItem Text="Đang giao hàng" Value="Đang giao hàng"></asp:ListItem>
                            <asp:ListItem Text="Đã giao hàng" Value="Đã giao hàng"></asp:ListItem>
                        </Items>
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="frow">
            <div class="frow-wrapp">
                <div class="label">Hình thức vận chuyển</div>
                <div class="input">
                    <asp:Label ID="lbHinhThucVanChuyen" CssClass="Label" runat="server" />
                </div>
            </div>
        </div>
        <div class="frow">
            <div class="frow-wrapp">
                <div class="label">Mã vận chuyển </div>
                <div class="input">
                    <asp:Label ID="lblShippingCode" CssClass="Label" runat="server" />
                    <span id="editShippingCode">Thay đổi</span>
                    <asp:TextBox runat="server" ID="txtShippingCode" ClientIDMode="Static" AutoPostBack="True" OnTextChanged="txtShippingCode_OnTextChanged" CssClass="hidden"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="frow">
            <div class="frow-wrapp">
                <div class="label">Trạng thái đơn hàng</div>
                <div class="input">
                    <asp:Label ID="lblDBOrderStatus" CssClass="Label" runat="server" />
                    <%--<span id="editOrderstatus">Thay đổi</span>
                    <asp:DropDownList runat="server" ID="ddlOrderStatus" AutoPostBack="True" ClientIDMode="Static" OnSelectedIndexChanged="ddlOrderStatus_SelectedIndexChanged">
                        <Items>
                            <asp:ListItem Text="Mới tiếp nhận" Value="Mới tiếp nhận"></asp:ListItem>
                            <asp:ListItem Text="Đang xử lý" Value="Đang xử lý"></asp:ListItem>
                            <asp:ListItem Text="Hoàn tất" Value="Hoàn tất"></asp:ListItem>
                        </Items>
                    </asp:DropDownList>--%>
                </div>
            </div>
        </div>
        <div class="frow hidden">
            <div class="frow-wrapp">
                <div class="label">Điểm tích lũy</div>
                <div class="input">
                    <asp:Label ID="lblSavePoint" CssClass="Label" runat="server" />
                </div>
            </div>
        </div>
        <div class="frow hidden">
            <div class="frow-wrapp">
                <div class="label">Điểm sử dụng</div>
                <div class="input">
                    <asp:Label ID="lblUsePoint" CssClass="Label" runat="server" />
                </div>
            </div>
        </div>
        <div class="frow">
            <div class="frow-wrapp">
                <div class="label">Tổng tiền thanh toán </div>
                <div class="input">
                    <asp:Label ID="lblTongTien" Style="font-weight: bold; color: red" CssClass="Label" runat="server" />
                </div>
            </div>
        </div>
    </div>

    <%--//==================================//--%>

    <div id="billinginfo" runat="server" clientidmode="Static">
        <div class="frow height10">
            Thông tin người đặt hàng
        </div>
        <div class="frow">
            <div class="frow-wrapp">
                <div class="label">Tên người đặt hàng </div>
                <div class="input">
                    <asp:Label ID="lblBillingName" CssClass="Label" runat="server" />
                </div>
            </div>
        </div>
        <div class="frow">
            <div class="frow-wrapp">
                <div class="label">Mã người đặt hàng</div>
                <div class="input">
                    <asp:Label ID="lblDBCustomer" CssClass="Label" runat="server" />
                </div>
            </div>
        </div>
        <div class="frow">
            <div class="frow-wrapp">
                <div class="label">Email</div>
                <div class="input">
                    <asp:Label ID="lblBillingEmail" CssClass="Label" runat="server" />
                </div>
            </div>
        </div>
        <div class="frow">
            <div class="frow-wrapp">
                <div class="label">Điện thoại </div>
                <div class="input">
                    <asp:Label ID="lblBillingPhone" CssClass="Label" runat="server" />
                </div>
            </div>
        </div>
        <div class="frow hidden">
            <div class="frow-wrapp">
                <div class="label">Mã số thuế/Fax </div>
                <div class="input">
                    <asp:Label ID="lblNip" CssClass="Label" runat="server" />
                </div>
            </div>
        </div>
        <div class="frow hidden">
            <div class="frow-wrapp">
                <div class="label">Công ty </div>
                <div class="input">
                    <asp:Label ID="lblBillingAddress" CssClass="Label" runat="server" />
                </div>
            </div>
        </div>
        <div class="frow">
            <div class="frow-wrapp">
                <div class="label">Địa chỉ người gửi</div>
                <div class="input">
                    <asp:Label ID="lblBillingCompany" CssClass="Label" runat="server" />
                </div>
            </div>
        </div>
        <%--    <div class="frow">
                    <div class="frow-wrapp">
                        <div class="label">Thành phố</div>
                        <div class="input">
                            <asp:Label ID="lblBillingCity" CssClass="Label" runat="server" />
                        </div>
                    </div>
                </div>--%>
        <div class="frow height10">
            Thông tin người nhận hàng
        </div>
        <div class="frow">
            <div class="frow-wrapp">
                <div class="label">Tên người nhận hàng </div>
                <div class="input">
                    <asp:Label ID="lblDBShippingFullName" CssClass="Label" runat="server" />
                </div>
            </div>
        </div>
        <div class="frow">
            <div class="frow-wrapp">
                <div class="label">Email người nhận hàng </div>
                <div class="input">
                    <asp:Label ID="lblDBShippingEmail" CssClass="Label" runat="server" />
                </div>
            </div>
        </div>
        <div class="frow">
            <div class="frow-wrapp">
                <div class="label">Điện thoại  </div>
                <div class="input">
                    <asp:Label ID="lblDBShippingPhone" CssClass="Label" runat="server" />
                </div>
            </div>
        </div>
        <div class="frow hidden">
            <div class="frow-wrapp">
                <div class="label">Mã số thuế/Fax </div>
                <div class="input">
                    <asp:Label ID="lblNip2" CssClass="Label" runat="server" />
                </div>
            </div>
        </div>
        <%--<div class="frow"> <div class="frow-wrapp"> <div class="label">Tên công ty người nhận hàng </div> <div class="input"><asp:Label ID="lblDBShippingCompany" CssClass="Label" runat="server"/></div></div> </div>--%>
        <div class="frow hidden">
            <div class="frow-wrapp">
                <div class="label">Công ty</div>
                <div class="input">
                    <asp:Label ID="lblDBShippingAddress" CssClass="Label" runat="server" />
                </div>
            </div>
        </div>
        <div class="frow">
            <div class="frow-wrapp">
                <div class="label">Địa chỉ người nhận</div>
                <div class="input">
                    <asp:Label ID="lblShippingCompany" CssClass="Label" runat="server" />
                </div>
            </div>
        </div>
        <div class="frow hidden">
            <div class="frow-wrapp">
                <div class="label">Ngày nhận hàng </div>
                <div class="input">
                    <asp:Label ID="lblDBShippingDeliveredDate" CssClass="Label" runat="server" />
                </div>
            </div>
        </div>

        <div class="frow hidden">
            <div class="frow-wrapp">
                <div class="label">Thành phố nhận hàng </div>
                <div class="input">
                    <asp:Label ID="lblDBShippingCity" CssClass="Label" runat="server" />
                </div>
            </div>
        </div>
    </div>



    <div id="productdetail" runat="server" clientidmode="Static">
        <asp:Panel runat="server" ID="pnUpdateProduct" Visible="False">

            <div class="updateProduct">
                <table>
                    <tr>
                        <td>Tên sản phẩm</td>
                        <td>
                            <asp:Literal runat="server" ID="ltProductName"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td>Mã sản phẩm</td>
                        <td>
                            <asp:Literal runat="server" ID="ltProductCode"></asp:Literal></td>
                    </tr>
                    <tr>
                        <td>Số lượng</td>
                        <td>
                            <asp:TextBox runat="server" ID="txtTotal">
                            </asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnSubmit" runat="server" Text="Cập nhật" OnClick="btnSubmit_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btbCancel" runat="server" Text="Hủy bỏ" />
                        </td>
                    </tr>
                    <asp:HiddenField runat="server" ID="IdOrderDetail" />
                </table>
            </div>
        </asp:Panel>



        <div style="width: 99%; margin: 0 auto; text-align: left">
            <asp:LinkButton runat="server" ClientIDMode="Static" ID="lbtDeleteAll" Text="Xóa nhiều bản ghi" OnClientClick='return confirm("Bạn có chắc chắn muốn xóa?");' OnClick="lbtDeleteAll_Click"></asp:LinkButton>
            &nbsp;&nbsp;           
        </div>
        <div id="printcontent">
            <asp:GridView ID="grvView" runat="server" AutoGenerateColumns="False" CssClass="grv table-check"
                Width="99%" HeaderStyle-CssClass="grid-header" OnRowCommand="grvView_RowCommand"
                ForeColor="#000" GridLines="None" DataKeyNames="OrderDetailID"
                Style="margin: 5px; margin-bottom: 0; border: 1px solid rgb(93, 140, 201)"
                ShowFooter="True" OnRowDataBound="grvView_RowDataBound">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                        <HeaderStyle HorizontalAlign="Center" CssClass="grid-header" />
                        <HeaderTemplate>
                            <asp:CheckBox ID="chkSelectAll" runat="server" CssClass="checkallinput" />
                        </HeaderTemplate>
                        <HeaderStyle CssClass="grid-header" />
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" CssClass="chkcheck" runat="server" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="30px" CssClass="grid-item"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="STT">
                        <HeaderStyle HorizontalAlign="Center" CssClass="grid-header" Width="30px" />
                        <ItemTemplate>
                            <%# Container.DataItemIndex +1 %>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="30px" CssClass="grid-item"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Ảnh sản phẩm">
                        <HeaderStyle CssClass="grid-header" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <img src='<%# GetImage(BicConvert.ToInt32(Eval("ProductID"))) %>' style="width: 40px; height: 40px" />
                            <asp:HiddenField runat="server" ID="GetOrderDetailId" Value='<%# Eval("OrderDetailID") %>' />
                            <asp:HiddenField runat="server" ID="GetProductID" Value='<%# Eval("ProductID") %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" CssClass="grid-item"></ItemStyle>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Mã sản phẩm" DataField="ProductCode" ItemStyle-HorizontalAlign="Center">
                        <HeaderStyle HorizontalAlign="Center" CssClass="grid-header" />
                        <ItemStyle HorizontalAlign="Center" CssClass="grid-item" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ProductName" HeaderText="Tên sản phẩm" ItemStyle-HorizontalAlign="Center">
                        <HeaderStyle HorizontalAlign="Center" CssClass="grid-header" />
                        <ItemStyle HorizontalAlign="Center" CssClass="grid-item" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Giá" DataField="ProductPrice" DataFormatString="{0:##,###}">
                        <HeaderStyle HorizontalAlign="Center" CssClass="grid-header" />
                        <ItemStyle HorizontalAlign="Center" CssClass="grid-item" />
                    </asp:BoundField>
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Số lượng">
                        <HeaderStyle HorizontalAlign="Center" CssClass="grid-header" />
                        <ItemTemplate>
                            <telerik:RadNumericTextBox runat="server" ID="txtSoluong" OnTextChanged="OnNumber1Changed" AutoPostBack="True" Type="Number" Width="50px" Value='<%#BicConvert.ToInt32(Eval("Total"))%>' ShowSpinButtons="false" NumberFormat-DecimalDigits="0" MaxValue="5000" Enabled="False">
                            </telerik:RadNumericTextBox>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" CssClass="grid-item"></ItemStyle>
                    </asp:TemplateField>
                    <%--  <asp:TemplateField >
                   <HeaderStyle HorizontalAlign="Center" CssClass="pad0" />
                   <ItemTemplate>
                       <asp:HiddenField runat="server" ID="GetOrderDetailId" Value='<%# Eval("OrderDetailID") %>' />
                   </ItemTemplate>
                   <ItemStyle HorizontalAlign="Center" ></ItemStyle>
               </asp:TemplateField>--%>
                    <%--  <asp:BoundField HeaderText="Số lượng" DataField="Total">
                    <HeaderStyle HorizontalAlign="Center" CssClass="grid-header" Width="90px" />
                    <ItemStyle HorizontalAlign="Center" CssClass="grid-item" />
                </asp:BoundField>--%>
                    <asp:BoundField HeaderText="Tổng tiền" DataField="SubTotal" DataFormatString="{0:##,###}">
                        <HeaderStyle HorizontalAlign="Center" CssClass="grid-header" Width="90px" />
                        <ItemStyle HorizontalAlign="Center" CssClass="grid-item" />
                    </asp:BoundField>
                    <%-- <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Thao tác">
                        <HeaderStyle HorizontalAlign="Center" CssClass="grid-header" />
                        <ItemTemplate>--%>
                    <%-- <asp:LinkButton ID="lnkEdit"  runat="server" CommandName="EditItem" CommandArgument='<%# Eval("OrderDetailID") %>'
                            CausesValidation="False" Text=" " ToolTip="Sửa"
                            CssClass="update-link-button" />--%>
                    <%--<asp:LinkButton ID="lnkDelete" runat="server" CommandName="DeleteItem" CommandArgument='<%# Eval("OrderDetailID") %>'
                                OnClientClick='return confirm("Bạn có chắc chắn muốn xóa?");'
                                CausesValidation="False" Text=" " ToolTip="Xóa"
                                CssClass="delete-link-button" />--%>
                    <%--<asp:HyperLink ID="lnkEdit" runat="server" NavigateUrl='<%# Utility.UrlNav("item","edit",Eval("ItemId")) %>'
                            Text="" ToolTip="Sửa" CssClass="update-link-button" />

                        <asp:LinkButton  ID="lnkDelete" runat="server" CommandName="DeleteItem" CommandArgument='<%# Eval("ItemId") %>'
                            OnClientClick='return confirm("Bạn có chắc chắn muốn xóa?");'
                            CausesValidation="False" Text=" " ToolTip="Xóa" 
                            CssClass="delete-link-button" />
                        <asp:LinkButton ID="lnkActive" runat="server" CommandName="Active" CommandArgument='<%# Eval("ItemId") %>'
                            CausesValidation="false" Text=" " Visible='<%# !Utility.ActiveStatus(Eval("IsActive")) %>' ToolTip="Hiển thị" OnClientClick='return confirm("Bạn có chắc chắn muốn hiển thị sản phẩm này?");'
                            CssClass="inactive-link-button" />
                         <asp:LinkButton ID="lnkInActive" runat="server" CommandName="InActive" CommandArgument='<%# Eval("ItemId") %>'
                                    CausesValidation="false" Text=" " ToolTip="Thôi hiển thị" OnClientClick='return confirm("Bạn có chắc chắn muốn thôi hiển thị sản phẩm này?");'
                                    Visible='<%# Utility.ActiveStatus(Eval("IsActive")) %>' CssClass="active-link-button" />--%>
                    <%--</ItemTemplate>
                        <HeaderStyle Width="100px" CssClass="grid-header" />
                        <ItemStyle HorizontalAlign="Center" CssClass="grid-item"></ItemStyle>
                    </asp:TemplateField>--%>
                </Columns>

                <%--<RowStyle BackColor="#f7f7de" /> --%>
            </asp:GridView>
        </div>

    </div>



    <div id="ordernotedetail">
        <div class="frow" runat="server" id="Note1" clientidmode="Static">
            <div class="frow-wrapp">
                <div class="label">Ghi chú người đặt hàng </div>
                <div class="input">
                    <asp:Label ID="lblNoteBilling" runat="server" />
                </div>
            </div>
        </div>
        <div class="frow" runat="server" id="Note2" clientidmode="Static">
            <div class="frow-wrapp">
                <div class="label">Ghi chú người nhận hàng </div>
                <div class="input">
                    <asp:Label ID="lblNoteShipping" runat="server" />
                </div>
            </div>
        </div>
    </div>
</div>
<div class="form-tool-bottom">
    <bic:ToolBar ID="tbBottom" runat="server" />
</div>

<script type="text/javascript">
    $(function () {
        $(".pad0").text("");
        $("#billinginfo").hide();
        $("#ordernotedetail").hide();
        $("#productdetail").hide();
        var stt = '<%= Session["StatusOrder"]%>';
        if (stt == "1") {
            $("#productdetail").show();
            $("#orderinfo").hide();
            $("#billinginfo").hide();
            $("#ordernotedetail").hide();

            $("#products").addClass("content_active");
        } else {
            $("#info").addClass("content_active");
        }
        $("#ddlOrderStatus").addClass("hidden");
        $("#ddlShippingStatus").addClass("hidden");
        $("#txtShippingFee").addClass("hidden");
        $("#ddlPaymentStatus").addClass("hidden");
        $("#editPaymentStatus").click(function () {
            $("#ddlPaymentStatus").removeClass("hidden");
            $(this).css("display", "none !important");
        });
        $("#editOrderstatus").click(function () {
            $("#ddlOrderStatus").removeClass("hidden");
            $(this).css("display", "none !important");
        });
        $("#editShippingFree").click(function () {
            $("#txtShippingFee").removeClass("hidden");
            $(this).css("display", "none !important");
        });
        $("#editShippingStatus").click(function () {
            $("#ddlShippingStatus").removeClass("hidden");
            $(this).css("display", "none !important");
        });
        $("#editShippingCode").click(function () {
            $("#txtShippingCode").removeClass("hidden");
            $(this).css("display", "none !important");
        });
        $("#info").click(function () {
            $("#orderinfo").show();
            $("#billinginfo").hide();
            $("#productdetail").hide();
            $("#ordernotedetail").hide();
            $(".form-tool>div").removeClass("content_active");
            $(this).addClass("content_active");
        });

        $("#products").click(function () {
            $("#productdetail").show();
            $("#orderinfo").hide();
            $("#billinginfo").hide();
            $("#ordernotedetail").hide();
            $(".form-tool>div").removeClass("content_active");
            $(this).addClass("content_active");
        });
        $("#OrderNote").click(function () {
            $(".form-tool>div").removeClass("content_active");
            $(this).addClass("content_active");
            $("#ordernotedetail").show();
            $("#productdetail").hide();
            $("#orderinfo").hide();
            $("#billinginfo").hide();
        });
        $("#billing").click(function () {
            $("#orderinfo").hide();
            $("#billinginfo").show();
            $("#productdetail").hide();
            $("#ordernotedetail").hide();
            $(".form-tool>div").removeClass("content_active");
            $(this).addClass("content_active");
        });
        $("#OrderDetail").click(function () {
            $("#productdetail").hide();
            $("#orderinfo").hide();
            $("#billinginfo").hide();
            $("#ordernotedetail").hide();
            $(".form-tool>div").removeClass("content_active");
            $(this).addClass("content_active");
            var id = '<%= BicHtml.GetRequestString("id", 0) %>';
            window.open("/vi/ShoppingCartToPrint.i" + id + ".html");
        });
    });

    function PrintElem(elem) {
        Popup($(elem).html());
    }

    function Popup(data) {
        var mywindow = window.open('', 'In danh sách sản phẩm', 'height=700,width=1100');
        mywindow.document.write('<html><head>In danh sách sản phẩm<title>Danh sách sản phẩm trong đơn hàng</title>');
        /*optional stylesheet*/ //mywindow.document.write('<link rel="stylesheet" href="main.css" type="text/css" />');
        mywindow.document.write('<link rel="stylesheet" href="/admin/Styles/style.css" type="text/css" />');
        mywindow.document.write('</head><body >');
        mywindow.document.write(data);
        mywindow.document.write('</body></html>');
        mywindow.print();
        mywindow.close();
        return true;
    }


</script>
