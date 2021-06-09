<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListingTourHotel.ascx.cs" Inherits="Admin_Components_TourHotel_ListingTourHotel" %>
<%@ Import Namespace="BIC.Utils" %>
<link href='<%= Page.ResolveUrl("~/BICSkins/BICCMS/Grid.BICCMS.css") %>' rel="stylesheet" type="text/css" />
<telerik:RadCodeBlock ID="RadCodeBlock2" runat="server">
    <telerik:RadAjaxPanel RestoreOriginalRenderDelegate="false" ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
        <div class="input-side">
            <div class="item first">
                <div class="label">
                    Ngôn ngữ</div>
                <div class="input">
                    <bic:Language ID="ddlLanguage" runat="server" AutoPostBack="True" CssClass="input-select" OnSelectedIndexChanged="ddlLanguage_SelectedIndexChanged" />
                </div>
            </div>
            <div class="item bg_none">
                <div class="label">
                    Duyệt</div>
                <div class="input">
                    <bic:DropBoolean runat="server" ID="ddlIsActive" OnSelectedIndexChanged="ddlLanguage_SelectedIndexChanged" AutoPostBack="True" />
                </div>
            </div>
            <div class="tree-box">
                <div class="tree-title">
                    Tìm kiếm theo danh mục
                </div>
                <div class="tree-content">
                    <telerik:RadTreeView runat="server" Skin="Outlook" Width="185px" CheckBoxes="true" ID="tvMenuUser" OnNodeCheck="tvMenuUser_NodeCheck"
                        PersistLoadOnDemandNodes="true" LoadingStatusPosition="AfterNodeText" CollapseAnimation-Duration="200" ExpandAnimation-Duration="200" Height="420"
                        ExpandAnimation-Type="InQuart" OnNodeExpand="tvMenuUser_NodeExpand">
                    </telerik:RadTreeView>
                </div>
            </div>
        </div>
        <div class="grid-side">
            <div class="search-box">
                <asp:TextBox ID="txtSearch" Width="250px" Text="" runat="server" AutoPostBack="True" OnTextChanged="txtSearch_TextChanged"
                    Height="18px"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="" />
            </div>
            <input type="hidden" id="radGridClickedRowIndex" name="radGridClickedRowIndex" />
            <input type="hidden" id="radGridSelectedRowIndex" name="radGridSelectedRowIndex" />
            <input type="hidden" id="confirmdelete" name="confirmdelete" />
            <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
                <script type="text/javascript">
                    function RowGridSelected(sender, args) {
                        key = args.getDataKeyValue("TourHotelID");
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
                        UpdatePosition("TourHotelID", "TourHotel", "<%=rgManager.ClientID %>");
                    });
                </script>
            </telerik:RadCodeBlock>
            <telerik:RadAjaxLoadingPanel ID="rgManagerLoading" runat="server" Transparency="25">
                <center>
                    <table width="100%">
                        <tr>
                            <td>
                                <img alt="Loading..." style="margin-top: 80px" src='<%=Page.ResolveUrl("~/admin/css/img/loading_bicweb_150x29.gif")%>' style="border: 0;" />
                            </td>
                        </tr>
                    </table>
                </center>
            </telerik:RadAjaxLoadingPanel>
            <telerik:RadGrid ID="rgManager" EnableViewState="false" EnableEmbeddedSkins="false" Skin="BICCMS" runat="server" HeaderStyle-CssClass="rgHeader rgHeaderCenter"
                AllowPaging="True" PageSize="10" AllowSorting="true" AllowCustomPaging="false" AllowAutomaticDeletes="true" ShowHeader="true"
                AutoGenerateColumns="False" AllowMultiRowSelection="true" OnNeedDataSource="rgManager_NeedDataSource" GridLines="None"
                OnDeleteCommand="rgManager_DeleteCommand" OnItemCommand="rgManager_ItemCommand" OnItemDataBound="rgManager_ItemDataBound">
                <MasterTableView TableLayout="Fixed" NoMasterRecordsText="Kh&ocirc;ng c&oacute; d&#7919; li&#7879;u..." DataKeyNames="TourHotelID"
                    CommandItemDisplay="Top">
                    <CommandItemTemplate>
                        <asp:LinkButton ID="lbtnDeleteSelected" Visible="<%#Deleted%>" CssClass="btn-del" OnClientClick="javascript:return confirm('B&#7841;n ch&#7855;c ch&#7855;n mu&#7889;n x&oacute;a c&aacute;c b&#7843;n ghi &#273;&atilde; ch&#7885;n?')"
                            runat="server" CommandName="DeleteSelected"></asp:LinkButton>
                        <a href='<%#BicAdmin.UrlAdd()%>' runat="server" visible="<%#Added%>" class="btn-addnew"></a>
                    </CommandItemTemplate>
                    <Columns>
                        <telerik:GridClientSelectColumn UniqueName="column" HeaderStyle-Width="30px" ItemStyle-CssClass="center">
                        </telerik:GridClientSelectColumn>
                        <telerik:GridBoundColumn UniqueName="UniqueID" DataField="TourID">
                            <HeaderStyle Width="1" />
                            <ItemStyle Width="1" />
                        </telerik:GridBoundColumn>
                        <telerik:GridTemplateColumn HeaderText="STT" HeaderStyle-Width="30px" ItemStyle-CssClass="center">
                            <ItemTemplate>
                                <%#Container.DataSetIndex + 1%>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn HeaderText="Tên khách sạn" DataField="TenKhachSan" />
                        <telerik:GridBoundColumn HeaderText="Danh mục" DataField="Nhom" />
                        <telerik:GridBoundColumn HeaderText="Lượt xem" DataField="LuotXem" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Center" />
                        <telerik:GridTemplateColumn HeaderText="Thứ tự" HeaderStyle-Width="110px">
                            <ItemTemplate>
                                <asp:DropDownList runat="server" ID="ddlCurrentPosition" Width="45px" ClientIDMode="Static" CssClass='<%#Eval("TourHotelID") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Duyệt" HeaderStyle-Width="50">
                            <ItemTemplate>
                                <asp:ImageButton ID="ibtnIsActive" BorderWidth="0px" CommandName="IsActive" CommandArgument='<%#Eval("IsActive") %>' ImageUrl='<%# Convert.ToBoolean(DataBinder.Eval(Container.DataItem, "IsActive"))? "~/Admin/Styles/Icon/checkmark.gif" : "~/Admin/Styles/Icon/uncheckmark.gif" %>'
                                    Style="cursor: pointer;" runat="server"></asp:ImageButton>
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
                    FirstPageToolTip="Trang đầu" LastPageToolTip="Trang cuối" NextPagesToolTip="Các trang sau" NextPageToolTip="Trang sau"
                    PageSizeLabelText="Số trang:" PrevPagesToolTip="Các trang trước" PrevPageToolTip="Trang trước" />
            </telerik:RadGrid>
        </div>
    </telerik:RadAjaxPanel>
</telerik:RadCodeBlock>
<telerik:RadContextMenu ID="radMenuContext" runat="server" OnItemClick="radMenuContext_ItemClick" EnableRoundedCorners="true"
    EnableShadows="true" Skin="WebBlue" OnClientItemClicking="onClientItemClicked">
</telerik:RadContextMenu>
<telerik:RadWindowManager ID="RadWindowManager1" runat="server" EnableShadow="true" OnClientClose="onClientClose">
    <Windows>
        <telerik:RadWindow ID="MenuUserListDialog" runat="server" Title="Cập nhật nhóm" Height="450px" Width="410px" Left="150px"
            ReloadOnShow="true" ShowContentDuringLoad="True" Modal="true" />
    </Windows>
</telerik:RadWindowManager>
<telerik:RadScriptBlock ID="RadCodeBlock3" runat="server">
    <script type="text/javascript">
        function onClientItemClicked(sender, args) {
            var commandName = args.get_item().get_value();
            if (commandName == "Move") {
                var grid = $find("<%= rgManager.MasterTableView.ClientID %>");
                ShowMenuUser(GetSelectedID(grid));
                args.set_cancel(true);
                sender.hide();
            }
        }
        function ShowMenuUser(id) {
            window.radopen('<%= Page.ResolveUrl("~/admin/Components/TourHotel/TreeViewMenuUser.aspx?id=' + id + '") %>', "MenuUserListDialog");
        }
        function GetSelectedID(MasterTable) {
            var id = '';
            var SelectedRows = MasterTable.get_selectedItems();
            for (var i = 0; i < SelectedRows.length; i++) {
                var row = SelectedRows[i];
                var cell = MasterTable.getCellByColumnUniqueName(row, "UniqueID");
                if (cell != null) {
                    id += cell.innerHTML + ",";
                }
            }
            return id;
        }
        function onClientClose(sender, args) {
            var grid = $find("<%=rgManager.ClientID %>");
            grid.get_masterTableView().rebind();
        }
    </script>
</telerik:RadScriptBlock>