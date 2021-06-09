<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Backup.ascx.cs" Inherits="Admin_Components_Database_Backup" %>
<div class="grid">
    <input type="hidden" id="radGridClickedRowIndex" name="radGridClickedRowIndex" />
    <input type="hidden" id="radGridSelectedRowIndex" name="radGridSelectedRowIndex" />
    <input type="hidden" id="confirmdelete" name="confirmdelete" />
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            function RowGridSelected(sender, args) {
                key = args.getDataKeyValue("FileName");
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
        </script>
    </telerik:RadCodeBlock>
    <telerik:RadGrid ID="rgManager" EnableEmbeddedSkins="false" Skin="BICCMS" runat="server" HeaderStyle-CssClass="rgHeader rgHeaderCenter" AllowPaging="True"
        PageSize="10" AllowSorting="False" AllowCustomPaging="false" AllowAutomaticDeletes="true" ShowHeader="true" AutoGenerateColumns="False" AllowMultiRowSelection="true"
        OnNeedDataSource="rgManager_NeedDataSource" GridLines="None" OnDeleteCommand="rgManager_DeleteCommand" OnItemCommand="rgManager_ItemCommand">
        <MasterTableView TableLayout="Fixed" NoMasterRecordsText="Kh&ocirc;ng c&oacute; d&#7919; li&#7879;u..." DataKeyNames="FileName" ClientDataKeyNames="FileName"
            CommandItemDisplay="Top">
            <EditFormSettings>
                <EditColumn InsertImageUrl="Update.gif" UpdateImageUrl="Update.gif" EditImageUrl="Edit.gif" CancelImageUrl="Cancel.gif">
                </EditColumn>
            </EditFormSettings>
            <CommandItemTemplate>
                <asp:LinkButton ID="lbtnDeleteSelected" CssClass="btn-del" OnClientClick="javascript:return confirm('B&#7841;n ch&#7855;c ch&#7855;n mu&#7889;n x&oacute;a c&aacute;c b&#7843;n ghi &#273;&atilde; ch&#7885;n?')"
                    runat="server" CommandName="DeleteSelected"></asp:LinkButton>
                <asp:LinkButton ID="lbtnBackup" CssClass="btn-backup" runat="server" OnClick="lbtnBackup_Click"></asp:LinkButton>
            </CommandItemTemplate>
            <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>
            <Columns>
                <telerik:GridClientSelectColumn UniqueName="column" HeaderStyle-Width="30px" ItemStyle-CssClass="center">
                    <HeaderStyle Width="30px"></HeaderStyle>
                    <ItemStyle CssClass="center"></ItemStyle>
                </telerik:GridClientSelectColumn>
                <telerik:GridTemplateColumn HeaderText="STT" HeaderStyle-Width="30px" ItemStyle-CssClass="center">
                    <ItemTemplate>
                        <%#Container.DataSetIndex + 1%>
                    </ItemTemplate>
                    <ItemStyle CssClass="center"></ItemStyle>
                </telerik:GridTemplateColumn>
                <telerik:GridBoundColumn HeaderText="Tiêu đề <span class='note'>( Click chuột phải để xem chi tiết, thêm sửa xóa )</span>" DataField="FileName" UniqueName="FileName"
                    HeaderStyle-CssClass="rgHeader">
                    <HeaderStyle CssClass="rgHeader"></HeaderStyle>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="Size (Mb)" HeaderStyle-Width="150px" DataField="FileSize" UniqueName="FileSize" HeaderStyle-CssClass="rgHeader rgHeaderCenter">
                    <HeaderStyle CssClass="rgHeader rgHeaderCenter" Width="150px"></HeaderStyle>
                </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn HeaderText="Lưu" UniqueName="TemplateColumn" HeaderStyle-Width="40px">
                    <ItemTemplate>
                        <asp:ImageButton ID="ibtnDownload" BorderWidth="0px" CommandName="Download" CommandArgument='<%#Eval("FileName") %>' ImageUrl="~/Admin/Styles/Icon/icon_download_10x10.gif"
                            Style="cursor: pointer;" runat="server"></asp:ImageButton>
                    </ItemTemplate>
                    <HeaderStyle Width="40px"></HeaderStyle>
                    <ItemStyle CssClass="center" />
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="Xóa" UniqueName="TemplateColumn" HeaderStyle-Width="40px">
                    <ItemTemplate>
                        <asp:ImageButton ID="ibtnDel" BorderWidth="0px" CommandName="Delete" CommandArgument='<%#Eval("FileName") %>' ImageUrl="~/Admin/Styles/Icon/icon_delete_10x10.gif"
                            OnClientClick="javascript:return confirm('B&#7841;n ch&#7855;c ch&#7855;n mu&#7889;n x&oacute;a c&aacute;c b&#7843;n ghi &#273;&atilde; ch&#7885;n??')"
                            Style="cursor: pointer;" runat="server"></asp:ImageButton>
                    </ItemTemplate>
                    <HeaderStyle Width="40px"></HeaderStyle>
                    <ItemStyle CssClass="center" />
                </telerik:GridTemplateColumn>
            </Columns>
        </MasterTableView>
        <SortingSettings SortedAscToolTip="S&#7855;p x&#7871;p t&#259;ng d&#7847;n" SortedDescToolTip="S&#7855;p x&#7871;p gi&#7843;m d&#7847;n" SortToolTip="S&#7855;p x&#7871;p d&#7919; li&#7879;u" />
        <ClientSettings>
            <Selecting AllowRowSelect="True" EnableDragToSelectRows="true" />
            <Scrolling AllowScroll="false" UseStaticHeaders="true" SaveScrollPosition="true" />
            <ClientEvents OnRowContextMenu="RowContextMenu" OnRowSelected="RowGridSelected" />
        </ClientSettings>
        <HeaderStyle CssClass="rgHeader rgHeaderCenter"></HeaderStyle>
        <PagerStyle PagerTextFormat="Chuyển trang: {4} &amp;nbsp;Từ &lt;strong&gt;{2}&lt;/strong&gt; tới &lt;strong&gt;{3}&lt;/strong&gt; trong &lt;strong&gt;{5}&lt;/strong&gt; bản ghi"
            FirstPageToolTip="Trang đầu" LastPageToolTip="Trang cuối" NextPagesToolTip="Các trang sau" NextPageToolTip="Trang sau" PageSizeLabelText="Số trang:"
            PrevPagesToolTip="Các trang trước" PrevPageToolTip="Trang trước" />
        <FilterMenu EnableEmbeddedSkins="False">
        </FilterMenu>
        <HeaderContextMenu EnableEmbeddedSkins="False">
        </HeaderContextMenu>
    </telerik:RadGrid>
</div>
<telerik:RadContextMenu ID="radMenuContext" runat="server" OnItemClick="radMenuContext_ItemClick" EnableRoundedCorners="true" EnableShadows="true" Skin="WebBlue">
</telerik:RadContextMenu>