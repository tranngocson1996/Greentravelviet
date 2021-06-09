<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListingCategory.ascx.cs" Inherits="Admin_Components_Category_ListingCategory" %>
<%@ Import Namespace="BIC.Utils" %>
<link href='<%= Page.ResolveUrl("~/BICSkins/BICCMS/Grid.BICCMS.css") %>' rel="stylesheet"
    type="text/css" />
<telerik:RadCodeBlock ID="RadCodeBlock2" runat="server">
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
        <div class="input-box">
            <div class="item first">
                <div class="item bg_none">
                    <div class="label">Duyệt</div>
                    <div class="input">
                        <bic:DropBoolean runat="server" ID="ddlIsActive" OnSelectedIndexChanged="ddlLanguage_SelectedIndexChanged" AutoPostBack="True" /></div>
                </div>
            </div>
            <div class="item">
                <div class="item bg_none">
                    <div class="label">Kiểu</div>
                    <div class="input">
                    <asp:DropDownList runat="server" ID="ddlTypeOfCategory" OnSelectedIndexChanged="ddlTypeOfCategory_SelectedIndexChanged" AutoPostBack="True" />
                    </div>
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
                        key = args.getDataKeyValue("CategoryID");
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
                        UpdatePosition("CategoryID", "Category", "<%=rgManager.ClientID %>");
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
                <a id="addLink" runat="server" class="btn-addnew">
                    <telerik:RadCodeBlock ID="RadCodeBlock12" runat="server">
                        <%=BicResource.GetValue("Admin","System_Add") %>
                    </telerik:RadCodeBlock>
                </a>
            </div>

            <telerik:RadGrid ID="rgManager" EnableEmbeddedSkins="false"
                Skin="BICCMS" runat="server" HeaderStyle-CssClass="rgHeader rgHeaderCenter" AllowPaging="True" PageSize="20" AllowCustomPaging="True"
                OnPageIndexChanged="rgManager_PageIndexChanged"
                AllowAutomaticDeletes="true" ShowHeader="true" OnItemCreated="rgManager_ItemCreated" AutoGenerateColumns="False" AllowMultiRowSelection="true"
                GridLines="None" OnItemCommand="rgManager_ItemCommand">
                <MasterTableView TableLayout="Fixed" NoMasterRecordsText="Kh&ocirc;ng c&oacute; d&#7919; li&#7879;u..."
                    DataKeyNames="CategoryID" CommandItemDisplay="Top">
                    <CommandItemTemplate>
                    </CommandItemTemplate>
                    <Columns>
                        <telerik:GridClientSelectColumn UniqueName="column" HeaderStyle-Width="30px" ItemStyle-CssClass="center"></telerik:GridClientSelectColumn>
                        <telerik:GridTemplateColumn HeaderText="STT" HeaderStyle-Width="30px" ItemStyle-CssClass="center">
                            <ItemTemplate>
                                <%#Container.DataSetIndex + 1%>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn HeaderText="Tên" DataField="Name" />
                        <telerik:GridBoundColumn HeaderText="Giá trị" DataField="Value" />
                        <telerik:GridTemplateColumn HeaderText="Duyệt" HeaderStyle-Width="50">
                            <ItemTemplate>
                                <asp:ImageButton ID="ibtnIsActive" BorderWidth="0px" CommandName="IsActive" CommandArgument='<%#Eval("IsActive") %>' ImageUrl='<%# Convert.ToBoolean(DataBinder.Eval(Container.DataItem, "IsActive"))? "~/Admin/Styles/Icon/checkmark.gif" : "~/Admin/Styles/Icon/uncheckmark.gif" %>' Style="cursor: pointer;" runat="server"></asp:ImageButton></ItemTemplate>
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
<script>
    function MesDelete() {
        return confirm('Bạn chắc chắn muốn xóa các bản ghi đã chọn?');
    }
</script>

