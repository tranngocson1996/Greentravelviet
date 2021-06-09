<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListingTour.ascx.cs" Inherits="Admin_Components_Tour_ListingTour" %>
<%@ Import Namespace="BIC.Utils" %>
<telerik:RadCodeBlock ID="RadCodeBlock2" runat="server">
    <telerik:RadAjaxPanel RestoreOriginalRenderDelegate="false" ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
        <div class="input-side">
            <div class="item first">
                <div class="label">
                    Ngôn ngữ</div>
                <div class="input">
                    <bic:Language ID="ddlLanguage" runat="server" AutoPostBack="True" CssClass="input-select" OnSelectedIndexChanged="ddlLanguage_SelectedIndexChanged" />
                <asp:HiddenField ID="txtLanguage" runat="server" />
                
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
                        PersistLoadOnDemandNodes="true" LoadingStatusPosition="AfterNodeText" CollapseAnimation-Duration="200" ExpandAnimation-Duration="200" Height="515"
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
                    function pageLoad() {
                    }
                    function RowGridSelected(sender, args) { key = args.getDataKeyValue("TourID"); document.getElementById("radGridSelectedRowIndex").value = key; }
                    function RowContextMenu(sender, eventArgs) {
                        var menu = $find("<%= radMenuContext.ClientID %>");
                    var evt = eventArgs.get_domEvent();
                    if (evt.target.tagName == "INPUT" || evt.target.tagName == "A") { return; }
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
                        UpdatePosition("TourID", "Tour", "<%=rgManager.ClientID %>");
                    });
                </script>
            </telerik:RadCodeBlock>
            <telerik:RadAjaxLoadingPanel ID="rgManagerLoading" runat="server" Transparency="25">
                <center>
                    <table width="100%">
                        <tr>
                            <td>
                                <img alt="Loading..." style="margin-top: 80px; border: 0;" src='<%=Page.ResolveUrl("~/admin/css/img/loading_bicweb_150x29.gif")%>' />
                            </td>
                        </tr>
                    </table>
                </center>
            </telerik:RadAjaxLoadingPanel>
            <telerik:RadGrid ID="rgManager" EnableViewState="false" EnableEmbeddedSkins="false" Skin="BICCMS" runat="server" HeaderStyle-CssClass="rgHeader rgHeaderCenter"
                AllowPaging="True" PageSize="10" AllowSorting="true" AllowCustomPaging="false" AllowAutomaticDeletes="true" ShowHeader="true"
                AutoGenerateColumns="False" AllowMultiRowSelection="true" OnNeedDataSource="rgManager_NeedDataSource" GridLines="None"
                OnDeleteCommand="rgManager_DeleteCommand" OnItemCommand="rgManager_ItemCommand" OnItemDataBound="rgManager_ItemDataBound">
                <MasterTableView TableLayout="Fixed" NoMasterRecordsText="Kh&ocirc;ng c&oacute; d&#7919; li&#7879;u..." DataKeyNames="TourID" ClientDataKeyNames="TourID"
                    CommandItemDisplay="Top">
                    <CommandItemTemplate>
                        <div class="deleteUser">
                        <asp:LinkButton ID="lbtnDeleteSelected" Visible="<%#Deleted%>" CssClass="btn-del" OnClientClick="javascript:return confirm('B&#7841;n ch&#7855;c ch&#7855;n mu&#7889;n x&oacute;a c&aacute;c b&#7843;n ghi &#273;&atilde; ch&#7885;n?')"
                            runat="server" CommandName="DeleteSelected">
                             <%=BicResource.GetValue("Admin","Admin_DeleteAll") %>
                        </asp:LinkButton>
                        <a href='<%#BicAdmin.UrlAdd()%>' runat="server" visible="<%#Added%>" class="btn-addnew">
                             <%=BicResource.GetValue("Admin","System_Add") %>
                        </a>
                            </div>
                    </CommandItemTemplate>
                    <Columns>
                        <telerik:GridClientSelectColumn UniqueName="ClientSelectColumn" HeaderStyle-Width="30px" ItemStyle-CssClass="center">
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
                        <telerik:GridBoundColumn HeaderText="Tên tour" DataField="TenTour" />
                        <telerik:GridBoundColumn HeaderText="Nhóm tour" DataField="Nhom" />
                        <%--<telerik:GridBoundColumn HeaderText="Giá" DataField="GiaHienThi" HeaderStyle-Width="150px" />
                        <telerik:GridBoundColumn HeaderText="Số ngày" DataField="SoNgay" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="60px" />
                        <telerik:GridBoundColumn HeaderText="Số đêm" DataField="SoDem" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="60px" />
                        <telerik:GridTemplateColumn HeaderText="Thứ tự" HeaderStyle-Width="80px">
                            <ItemTemplate>
                                <asp:DropDownList runat="server" ID="ddlCurrentPosition" Width="45px" ClientIDMode="Static" CssClass='<%#Eval("TourID") %>' />
                                <div style="float: right; position: relative;">
                                    <asp:ImageButton runat="server" ImageUrl="~/Admin/Styles/Icon/updown_30x20.png" ID="lbtnChange" CommandName="Change" /></div>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </telerik:GridTemplateColumn>--%>
                        <telerik:GridBoundColumn HeaderText="Lượt xem" DataField="LuotXem" HeaderStyle-Width="50" ItemStyle-HorizontalAlign="Center" />
                        <telerik:GridTemplateColumn HeaderText="HOT" HeaderStyle-Width="50">
                            <ItemTemplate>
                                <asp:ImageButton ID="ibtnIsNew" BorderWidth="0px" CommandName="IsNew" CommandArgument='<%#Eval("Mota1") %>' ImageUrl='<%# (Eval("Mota1").ToString() == "True")? "~/Admin/Styles/Icon/checkmark.gif" : "~/Admin/Styles/Icon/uncheckmark.gif" %>'
                                    Style="cursor: pointer;" runat="server"></asp:ImageButton></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Duyệt" HeaderStyle-Width="50">
                            <ItemTemplate>
                                <asp:ImageButton ID="ibtnIsActive" BorderWidth="0px" CommandName="IsActive" CommandArgument='<%#Eval("IsActive") %>' ImageUrl='<%# Convert.ToBoolean(DataBinder.Eval(Container.DataItem, "IsActive"))? "~/Admin/Styles/Icon/checkmark.gif" : "~/Admin/Styles/Icon/uncheckmark.gif" %>'
                                    Style="cursor: pointer;" runat="server"></asp:ImageButton></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
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
    OnClientItemClicking="onClientItemClicked" EnableShadows="true" Skin="WebBlue">
</telerik:RadContextMenu>
<telerik:RadWindowManager ID="RadWindowManager1" runat="server" EnableShadow="true" OnClientClose="onClientClose">
    <Windows>
        <telerik:RadWindow ID="MenuUserListDialog" runat="server" Title="Cập nhật nhóm tin" Height="450px" Width="410px" Left="150px"
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
        La = "";
        function pageLoad() {
            La = $("#ctl05_txtLanguage").attr("value");
        }
            function ShowMenuUser(id) {
                id = id.replace(",", "");
                //window.radopen('<%= Page.ResolveUrl(string.Format( "~/admin/Components/Tour/TreeViewMenuUser.aspx?id=' + id + '&l={0}",txtLanguage.Value)) %>', "MenuUserListDialog");
                window.radopen('<%= Page.ResolveUrl("~")%>' + "admin/Components/Tour/TreeViewMenuUser.aspx?id=" +<%= id %> + "&l=" + La, "MenuUserListDialog");
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