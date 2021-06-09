<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListingControl.ascx.cs" Inherits="Admin_Components_Control_ListingControl" %>
<%@ Import Namespace="BIC.Utils" %>
<telerik:RadCodeBlock ID="RadCodeBlock2" runat="server">
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
        <div class="grid">
            <div class="search-box">
                <asp:TextBox ID="txtSearch" Width="250px" Text="" runat="server" AutoPostBack="True" OnTextChanged="txtSearch_TextChanged" Height="18px"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="" />
            </div>
            <input type="hidden" id="radGridClickedRowIndex" name="radGridClickedRowIndex" />
            <input type="hidden" id="radGridSelectedRowIndex" name="radGridSelectedRowIndex" />
            <input type="hidden" id="confirmdelete" name="confirmdelete" />
            <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
                <script type="text/javascript">
                    function RowGridSelected(sender, args) {key = args.getDataKeyValue("ControlID");document.getElementById("radGridSelectedRowIndex").value = key;}
                    function RowContextMenu(sender, eventArgs) {var menu = $find("<%= radMenuContext.ClientID %>");var evt = eventArgs.get_domEvent();if (evt.target.tagName == "INPUT" || evt.target.tagName == "A") {return;}var index = eventArgs.get_itemIndexHierarchical();document.getElementById("radGridClickedRowIndex").value = index;sender.get_masterTableView().selectItem(sender.get_masterTableView().get_dataItems()[index].get_element(), true);menu.show(evt);evt.cancelBubble = true;evt.returnValue = false;if (evt.stopPropagation) {evt.stopPropagation();evt.preventDefault();}}
                </script>
            </telerik:RadCodeBlock>
            <telerik:RadGrid ID="rgManager" EnableEmbeddedSkins="false" Skin="BICCMS" runat="server" HeaderStyle-CssClass="rgHeader rgHeaderCenter" AllowPaging="True"
                             PageSize="20" AllowSorting="False" AllowCustomPaging="true" OnPageIndexChanged="rgManager_PageIndexChanged" AllowAutomaticDeletes="true" ShowHeader="true"
                             AutoGenerateColumns="False" AllowMultiRowSelection="true" OnNeedDataSource="rgManager_NeedDataSource" GridLines="None" OnDeleteCommand="rgManager_DeleteCommand"
                             OnItemCommand="rgManager_ItemCommand">
                <MasterTableView TableLayout="Fixed" NoMasterRecordsText="Kh&ocirc;ng c&oacute; d&#7919; li&#7879;u..." DataKeyNames="ControlID" CommandItemDisplay="Top">
                    <CommandItemTemplate>
                        <asp:LinkButton ID="lbtnDeleteSelected" CssClass="btn-del" OnClientClick="javascript:return confirm('B&#7841;n ch&#7855;c ch&#7855;n mu&#7889;n x&oacute;a c&aacute;c b&#7843;n ghi &#273;&atilde; ch&#7885;n?')"
                                        runat="server" CommandName="DeleteSelected"><%=BicResource.GetValue("Admin","System_Delete") %></asp:LinkButton>
                        <a href='<%# BicAdmin.UrlAdd() %>' class="btn-addnew"><%=BicResource.GetValue("Admin","Admin_Controls_AddNew") %></a>
                    </CommandItemTemplate>
                    <Columns>
                        <telerik:GridClientSelectColumn UniqueName="column" HeaderStyle-Width="30px" ItemStyle-CssClass="center">
                        </telerik:GridClientSelectColumn>
                        <telerik:GridTemplateColumn HeaderText="STT" HeaderStyle-Width="30px" ItemStyle-CssClass="center">
                            <ItemTemplate>
                                <%# Container.DataSetIndex + 1 %>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn HeaderText="<%$Resources:Admin,Admin_Controls_ControlsName%>" DataField="ControlName" />
                        <telerik:GridBoundColumn HeaderText="<%$Resources:Admin,Admin_Controls_DirectoryName%>" DataField="FolderName" HeaderStyle-CssClass="rgHeader" />
                        <telerik:GridCheckBoxColumn HeaderText="<%$Resources:Admin,Admin_Controls_Load%>" DataField="LoadUrl" HeaderStyle-Width="40" />
                        <telerik:GridTemplateColumn HeaderText="<%$Resources:Admin,System_Browse%>" HeaderStyle-Width="40">
                            <ItemTemplate>
                                <asp:ImageButton ID="ibtnIsActive" BorderWidth="0px" CommandName="IsActive" CommandArgument='<%# Eval("IsActive") %>' Enabled='<%# Approved %>' ImageUrl='<%# Convert.ToBoolean(DataBinder.Eval(Container.DataItem, "IsActive")) ? "~/Admin/Styles/Icon/checkmark.gif" : "~/Admin/Styles/Icon/uncheckmark.gif" %>'
                                                 Style="cursor:pointer;" runat="server"></asp:ImageButton></ItemTemplate>
                        </telerik:GridTemplateColumn>
                    </Columns>
                </MasterTableView>
                <SortingSettings SortedAscToolTip="S&#7855;p x&#7871;p t&#259;ng d&#7847;n" SortedDescToolTip="S&#7855;p x&#7871;p gi&#7843;m d&#7847;n" SortToolTip="S&#7855;p x&#7871;p d&#7919; li&#7879;u" />
                <ClientSettings>
                    <Selecting AllowRowSelect="True" EnableDragToSelectRows="true" />
                    <Scrolling AllowScroll="false" UseStaticHeaders="true" SaveScrollPosition="true" />
                    <ClientEvents OnRowContextMenu="RowContextMenu" />
                </ClientSettings>
                <PagerStyle PagerTextFormat="<%$Resources:Admin, Admin_Paging%>"
                            FirstPageToolTip="<%$Resources:Admin, Admin_Paging_FirstPage%>" LastPageToolTip="<%$Resources:Admin, Admin_Paging_LastPage%>" NextPagesToolTip="<%$Resources:Admin, Admin_Paging_NextPages%>" NextPageToolTip="<%$Resources:Admin, Admin_Paging_NextPage%>" PageSizeLabelText="<%$Resources:Admin, Admin_Paging_PageSize%>"
                            PrevPagesToolTip="<%$Resources:Admin, Admin_Paging_PrevPages%>" PrevPageToolTip="<%$Resources:Admin, Admin_Paging_PrevPage%>" />
            </telerik:RadGrid>
        </div>
    </telerik:RadAjaxPanel>
</telerik:RadCodeBlock>
<telerik:RadAjaxLoadingPanel runat="server" Skin="Windows7" ID="RadAjaxLoadingPanel1" BackgroundPosition="Center" EnableSkinTransparency="true">
</telerik:RadAjaxLoadingPanel>
<telerik:RadContextMenu ID="radMenuContext" runat="server" OnItemClick="radMenuContext_ItemClick" EnableRoundedCorners="true" EnableShadows="true" Skin="WebBlue">
</telerik:RadContextMenu>