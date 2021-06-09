<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListingOrderMenu.ascx.cs" Inherits="Admin_Components_OrderMenu_ListingOrderMenu" %>
<%@ Import Namespace="BIC.Utils" %>
<link href='<%= Page.ResolveUrl("~/BICSkins/BICCMS/Grid.BICCMS.css") %>' rel="stylesheet"
    type="text/css" />
<asp:LinkButton ID="lbtnExportExcel" runat="server" OnClick="lbtnExportExcel_OnClick" CssClass="btn-export" Style="margin-left: 400px;" Text="Xuất ra Excel (Danh sách)" />
<asp:LinkButton ID="lbtnExportExcel1" runat="server" OnClick="lbtnExportExcel1_OnClick" CssClass="btn-export" Style="margin-left: 600px;" Text="Xuất ra Excel (Chi tiết)" />
<telerik:RadCodeBlock ID="RadCodeBlock2" runat="server">
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
        <div class="input-box">
            <div class="item">
                <div class="label">
                    <telerik:RadCodeBlock ID="RadCodeBlock3" runat="server">
                        <%=BicResource.GetValue("Admin","Admin_Search_PaymentMethods") %>
                    </telerik:RadCodeBlock>
                </div>
                <div class="input">
                    <asp:DropDownList runat="server" ID="ddlPaymentMethod" CssClass="input-select">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="item">
                <div class="label">
                    <telerik:RadCodeBlock ID="RadCodeBlock4" runat="server">
                        <%=BicResource.GetValue("Admin","Admin_Search_PaymentStatus") %>
                    </telerik:RadCodeBlock>
                </div>
                <div class="input">
                    <asp:DropDownList runat="server" ID="ddlPaymentStatus" CssClass="input-select">
                        <asp:ListItem Text="-- Chọn trạng thái --" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Chưa thanh toán" Value="Chưa thanh toán"></asp:ListItem>
                        <asp:ListItem Text="Đã thanh toán" Value="Đã thanh toán"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="item">
                <div class="label">
                    <telerik:RadCodeBlock ID="RadCodeBlock7" runat="server">
                        <%=BicResource.GetValue("Admin","Admin_Search_ShippingStatus") %>
                    </telerik:RadCodeBlock>
                </div>
                <div class="input">
                    <asp:DropDownList runat="server" ID="ddlShippingStatus" CssClass="input-select">
                        <asp:ListItem Text="-- Chọn trạng thái --" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Chưa giao hàng" Value="Chưa giao hàng"></asp:ListItem>
                        <asp:ListItem Text="Đang giao hàng" Value="Đang giao hàng"></asp:ListItem>
                        <asp:ListItem Text="Đã giao hàng" Value="Đã giao hàng"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="item bg_none">
                <div class="label">
                    <telerik:RadCodeBlock ID="RadCodeBlock5" runat="server">
                        <%=BicResource.GetValue("Admin","Admin_Article_FromDate") %>
                    </telerik:RadCodeBlock>
                </div>
                <div class="input">
                    <telerik:RadDatePicker ID="radBDBeginDate" runat="server" OnSelectedDateChanged="radBDBeginDate_OnSelectedDateChanged" CssClass="input-date" Width="120px" DateInput-EmptyMessage="<%$Resources:Admin, Admin_Article_SelectDate%>"
                        DateInput-DateFormat="dd/MM/yyyy" ShowPopupOnFocus="True">
                    </telerik:RadDatePicker>
                </div>
            </div>
            <div class="item">
                <div class="label">
                    <telerik:RadCodeBlock ID="RadCodeBlock6" runat="server">
                        <%=BicResource.GetValue("Admin","Admin_Article_ToDay") %>
                    </telerik:RadCodeBlock>
                </div>
                <div class="input">
                    <telerik:RadDatePicker ID="radBDEndDate" runat="server" OnSelectedDateChanged="radBDEndDate_OnSelectedDateChanged" CssClass="input-date" Width="120px" DateInput-EmptyMessage="<%$Resources:Admin, Admin_Article_SelectDate%>"
                        DateInput-DateFormat="dd/MM/yyyy" ShowPopupOnFocus="True">
                    </telerik:RadDatePicker>
                </div>
            </div>
            <div class="item bg_none">
                <div class="input">
                    <asp:Button runat="server" ID="btnclear" Height="25px" Text="<%$Resources:Admin, Admin_Article_SkipConditions%>" OnClick="btnclear_OnClick" />
                </div>
            </div>
            <div class="item bg_none">
                <div class="input">
                    <asp:Button runat="server" ID="btnFind" Text="<%$Resources:Admin,System_Search%>" Height="25px"
                        OnClick="btnSearch_Click" />
                </div>
            </div>
        </div>
        <div class="input-box">
            <div class="item" style="display: none">
                <div class="label">
                    Tổng điểm tích lũy
                </div>
                <div class="input">
                    <asp:Label runat="server" CssClass="txtpoint" ID="lblTotalpoint"></asp:Label>

                </div>
            </div>
            <div class="item" style="display: none">
                <div class="label">
                    Tổng điểm sử dụng
                </div>
                <div class="input">
                    <asp:Label runat="server" CssClass="txtpoint" ID="lblTotalUsePoint"></asp:Label>
                </div>
            </div>
            <div class="item">
                <div class="label">
                    Tổng tiền
                </div>
                <div class="input">
                    <asp:Label runat="server" CssClass="txtpoint" ID="lblTotal"></asp:Label>
                </div>
            </div>
        </div>
        <div class="grid">
            <div class="search-box">
                <asp:TextBox ID="txtSearch" Width="250px" Text="" runat="server" AutoPostBack="True"
                    OnTextChanged="txtSearch_TextChanged" Height="18px"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="" />
            </div>
            <input type="hidden" id="radGridClickedRowIndex" name="radGridClickedRowIndex" />
            <input type="hidden" id="radGridSelectedRowIndex" name="radGridSelectedRowIndex" />
            <input type="hidden" id="confirmdelete" name="confirmdelete" />
            <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
                <script type="text/javascript">
                    function RowGridSelected(sender, args) {
                        key = args.getDataKeyValue("OrderMenuID");
                        document.getElementById("radGridSelectedRowIndex").value = key;
                    }
                    function RowContextMenu(sender, eventArgs) {
                        var menu = $find("<%=radMenuContext.ClientID %>");
                        var evt = eventArgs.get_domEvent();

                        if (evt.target.tagName == "INPUT" || evt.target.tagName == "A") {
                            return;
                        }

                        var index = eventArgs.get_itemIndexHierarchical();
                        document.getElementById("radGridClickedRowIndex").value = index;

                        sender.get_masterTableView().selectItem(sender.get_masterTableView().get_dataItems()[index].get_element(), true);

                        menu.show(evt);

                        evt.cancelBubble = true;
                        evt.returnValue = false;

                        if (evt.stopPropagation) {
                            evt.stopPropagation();
                            evt.preventDefault();
                        }

                    }
                    $(document).ready(function () {
                        UpdatePosition("OrderMenuID", "OrderMenu", "<%=rgManager.ClientID %>");
                    });
                </script>
            </telerik:RadCodeBlock>
            <div class="deleteUser">
                <asp:LinkButton ID="lbtnDeleteSelected" CssClass="btn-del"
                    OnClientClick="return MesDelete();"
                    runat="server" OnClick="lbtnDeleteSelected_Click">
                    <telerik:RadCodeBlock ID="RadCodeBlock11" runat="server">
                        <%=BicResource.GetValue("Admin","Admin_DeleteAll") %>
                    </telerik:RadCodeBlock>
                </asp:LinkButton>
                <%-- <a id="addLink" runat="server" class="btn-addnew">
                    <telerik:RadCodeBlock ID="RadCodeBlock12" runat="server">
                        <%=BicResource.GetValue("Admin","System_Add") %>
                    </telerik:RadCodeBlock>
                </a>--%>
                <telerik:RadCodeBlock ID="RadCodeBlock8" runat="server">
                    <a class="btn-movenew" onclick="onClickedMove();">
                        <%=BicResource.GetValue("Admin","System_Update_Order") %>
                    </a>
                </telerik:RadCodeBlock>
            </div>
            <telerik:RadGrid ID="rgManager" EnableEmbeddedSkins="false"
                Skin="BICCMS" runat="server" HeaderStyle-CssClass="rgHeader rgHeaderCenter" AllowPaging="True" PageSize="20" AllowCustomPaging="True"
                OnPageIndexChanged="rgManager_PageIndexChanged"
                AllowAutomaticDeletes="true" ShowHeader="true" OnItemCreated="rgManager_ItemCreated" AutoGenerateColumns="False" AllowMultiRowSelection="true"
                GridLines="None" OnItemCommand="rgManager_ItemCommand">
                <MasterTableView TableLayout="Fixed" NoMasterRecordsText="Kh&ocirc;ng c&oacute; d&#7919; li&#7879;u..."
                    DataKeyNames="OrderMenuID" ClientDataKeyNames="OrderMenuId" CommandItemDisplay="Top">
                    <CommandItemTemplate>
                    </CommandItemTemplate>
                    <Columns>
                        <telerik:GridBoundColumn UniqueName="UniqueID" DataField="OrderMenuID">
                            <HeaderStyle Width="1" />
                            <ItemStyle Width="1" />
                        </telerik:GridBoundColumn>
                        <telerik:GridClientSelectColumn UniqueName="column" HeaderStyle-Width="30px" ItemStyle-CssClass="center"></telerik:GridClientSelectColumn>
                        <telerik:GridTemplateColumn HeaderText="STT" HeaderStyle-Width="30px" ItemStyle-CssClass="center">
                            <ItemTemplate>
                                <%#Container.DataSetIndex + 1%>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn HeaderText="<%$Resources:Admin,Admin_Order_Header_Order_Code %>" DataField="OrderCode" HeaderStyle-Width="100" ItemStyle-CssClass="center" />
                        <%--<telerik:GridBoundColumn HeaderText="<%$Resources:Admin,Admin_Order_Header_Order_Status %>" DataField="OrderStatus" />--%>
                        <%-- <telerik:GridTemplateColumn HeaderText="<%$Resources:Admin,Admin_Order_Header_Order_Customer %>" ItemStyle-HorizontalAlign="Center"
                            HeaderStyle-Width="125">
                            <ItemTemplate>
                                <%# GetFullName(Eval("Customer").ToString()) %>
                                
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>--%>
                        <telerik:GridTemplateColumn HeaderText="<%$Resources:Admin,Admin_Order_Header_Order_Customer %>" ItemStyle-HorizontalAlign="Center"
                            HeaderStyle-Width="125">
                            <ItemTemplate>
                                <%# GetCusName(Eval("Customer").ToString(),BicConvert.ToInt32(Eval("OrderMenuID"))) %>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <%--<telerik:GridTemplateColumn HeaderText="<%$Resources:Admin,Admin_Order_Header_Order_Customer %>" DataField="ShippingFullName" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="125"/>--%>
                        <telerik:GridBoundColumn HeaderText="<%$Resources:Admin,Admin_Order_Header_Order_PaymentMethods %>" DataField="PaymentMethod" ItemStyle-HorizontalAlign="Center" />
                        <telerik:GridBoundColumn HeaderText="<%$Resources:Admin,Admin_Order_Header_Order_ShippingEmail %>" DataField="ShippingEmail" ItemStyle-HorizontalAlign="Center" />
                        <telerik:GridBoundColumn HeaderText="<%$Resources:Admin,Admin_Order_Header_Order_ShippingPhone %>" DataField="ShippingPhone" ItemStyle-HorizontalAlign="Center" />
                        <telerik:GridBoundColumn HeaderText="<%$Resources:Admin,Admin_Order_Header_Order_ShippingStatus %>" DataField="ShippingStatus" ItemStyle-HorizontalAlign="Center" />
                        <telerik:GridBoundColumn HeaderText="<%$Resources:Admin,Admin_Order_Header_Order_SavePoint %>" DataField="SavePoint" DataFormatString="{0:N0}" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="75" Display="false" />
                        <telerik:GridBoundColumn HeaderText="<%$Resources:Admin,Admin_Order_Header_Order_UsePoint %>" DataField="UsePoint" DataFormatString="{0:N0}" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="75" Display="false" />
                        <telerik:GridBoundColumn HeaderText="<%$Resources:Admin,Admin_Order_Header_Order_OrderSubTotal %>" DataField="OrderSubTotal" DataFormatString="{0:N0}" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="95" />
                        <telerik:GridDateTimeColumn HeaderStyle-Width="75" ItemStyle-CssClass="center" HeaderText="<%$Resources:Admin,Admin_Order_Header_Order_OrderDate %>" DataField="ShippingDate" DataFormatString="{0: dd/MM/yyyy}" />
                        <telerik:GridTemplateColumn HeaderText="<%$Resources:Admin,System_View%>" UniqueName="TemplateColumn" ItemStyle-HorizontalAlign="Center"
                            HeaderStyle-Width="50">
                            <ItemTemplate>
                                <asp:ImageButton ID="ibtnEdit" BorderWidth="0px" Visible="<%# Edited %>" CommandName="View" CommandArgument='<%# Eval("OrderMenuID") %>'
                                    ImageUrl='~/admin/Styles/icon/Edit.png' Style="cursor: pointer;" runat="server"></asp:ImageButton>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                    </Columns>
                </MasterTableView>
                <SortingSettings SortedAscToolTip="S&#7855;p x&#7871;p t&#259;ng d&#7847;n" SortedDescToolTip="S&#7855;p x&#7871;p gi&#7843;m d&#7847;n"
                    SortToolTip="S&#7855;p x&#7871;p d&#7919; li&#7879;u" />
                <ClientSettings>
                    <Selecting AllowRowSelect="True" EnableDragToSelectRows="true" />
                    <Scrolling AllowScroll="false" UseStaticHeaders="true" SaveScrollPosition="true" />
                    <ClientEvents OnRowContextMenu="RowContextMenu" />
                </ClientSettings>
                <PagerStyle PagerTextFormat="Chuyển trang: {4} &amp;nbsp;Từ &lt;strong&gt;{2}&lt;/strong&gt; tới &lt;strong&gt;{3}&lt;/strong&gt; trong &lt;strong&gt;{5}&lt;/strong&gt; bản ghi"
                    FirstPageToolTip="Trang đầu" LastPageToolTip="Trang cuối" NextPagesToolTip="Các trang sau"
                    NextPageToolTip="Trang sau" PageSizeLabelText="Số trang:" PrevPagesToolTip="Các trang trước"
                    PrevPageToolTip="Trang trước" />
            </telerik:RadGrid>
        </div>
    </telerik:RadAjaxPanel>
</telerik:RadCodeBlock>
<telerik:RadContextMenu ID="radMenuContext" runat="server" OnItemClick="radMenuContext_ItemClick"
    EnableRoundedCorners="true" EnableShadows="true" Skin="WebBlue">
</telerik:RadContextMenu>
<telerik:RadAjaxLoadingPanel runat="server" Skin="Outlook" ID="RadAjaxLoadingPanel1"
    BackgroundPosition="Center" EnableSkinTransparency="true">
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" EnableShadow="true"
        OnClientClose="onClientClose">
        <Windows>
            <telerik:RadWindow ID="MenuUserListDialog" runat="server" Title="Xử lý đơn hàng"
                Height="250px" Width="350px" Left="150px" ReloadOnShow="true" ShowContentDuringLoad="True"
                Modal="true" />
        </Windows>
    </telerik:RadWindowManager>
</telerik:RadAjaxLoadingPanel>
<telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
    <script type="text/javascript">
        //function RowGridSelected(sender, args) { key = args.getDataKeyValue("OrderMenuID"); document.getElementById("radGridSelectedRowIndex").value = key; }
        function onClientItemClicked(sender, args) {
            var commandName = args.get_item().get_value();
            if (commandName == "Move") {
                var grid = $find("<%= rgManager.MasterTableView.ClientID %>");
                ShowMenuUser(GetSelectedID(grid)); args.set_cancel(true); sender.hide();
            }
        } function ShowMenuUser(id) {
            window.radopen('<%= Page.ResolveUrl("~/admin/Components/OrderMenu/OrderStatusChange.aspx?id=' + id + '&l=' + AdminLanguage + '") %>', "MenuUserListDialog");
        }
        function GetSelectedID(MasterTable) {
            var id = ''; var SelectedRows = MasterTable.get_selectedItems();
            for (var i = 0; i < SelectedRows.length; i++) {
                var row = SelectedRows[i]; var cell = MasterTable.getCellByColumnUniqueName(row, "UniqueID");
                if (cell != null) { id += cell.innerHTML + ","; }
            } return id;
        } function onClientClose(sender, args) { window.location = window.location; }


        function onClickedMove(sender, args) {
            var grid = $find("<%= rgManager.MasterTableView.ClientID %>");
            ShowMenuUser(GetSelectedID(grid)); args.set_cancel(true); sender.hide();
        }

    </script>
</telerik:RadScriptBlock>
<script>
    function MesDelete() {
        return confirm('Bạn chắc chắn muốn xóa các bản ghi đã chọn?');
    }
</script>

