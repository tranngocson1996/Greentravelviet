<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListingRoles.ascx.cs" Inherits="Admin_Components_Roles_ListingRoles" %>
<script type="text/javascript">
    function AddRoles() {var $dialog = $.FrameDialog.create({
        url: 'Components/Roles/AdditionRoles.aspx',
        loadingClass: 'loading-image',
        title: 'Thêm nhóm tài khoản',
        width: 280,
        height: 80,
        autoOpen: false,
        resizable: false
    })
        .bind('dialogclose', function(event, ui) { location.reload(true); });$dialog.dialog('open');}
    $(function() { $('a.btn-addnew').click(function() {AddRoles();$(this).val('href', '#');return false;}); });

</script>
<telerik:RadCodeBlock ID="RadCodeBlock2" runat="server">
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
        <div class="grid">
            <input type="hidden" id="radGridClickedRowIndex" name="radGridClickedRowIndex" />
            <input type="hidden" id="radGridSelectedRowIndex" name="radGridSelectedRowIndex" />
            <input type="hidden" id="confirmdelete" name="confirmdelete" />
            <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
                <script type="text/javascript">
                    function RowGridSelected(sender, args) {key = args.getDataKeyValue("RoleName");document.getElementById("radGridSelectedRowIndex").value = key;}
                    function RowContextMenu(sender, eventArgs) {var menu = $find("<%= radMenuContext.ClientID %>");var evt = eventArgs.get_domEvent();if (evt.target.tagName == "INPUT" || evt.target.tagName == "A") {return;}var index = eventArgs.get_itemIndexHierarchical();document.getElementById("radGridClickedRowIndex").value = index;sender.get_masterTableView().selectItem(sender.get_masterTableView().get_dataItems()[index].get_element(), true);menu.show(evt);evt.cancelBubble = true;evt.returnValue = false;if (evt.stopPropagation) {evt.stopPropagation();evt.preventDefault();}}
                </script>
            </telerik:RadCodeBlock>
            <telerik:RadGrid ID="rgManager" EnableEmbeddedSkins="false" Skin="BICCMS" runat="server" HeaderStyle-CssClass="rgHeader rgHeaderCenter" AllowPaging="True"
                             PageSize="10" AllowSorting="False" AllowCustomPaging="false" AllowAutomaticDeletes="true" ShowHeader="true" AutoGenerateColumns="False" AllowMultiRowSelection="true"
                             OnNeedDataSource="rgManager_NeedDataSource" GridLines="None">
                <MasterTableView TableLayout="Fixed" NoMasterRecordsText="Kh&ocirc;ng c&oacute; d&#7919; li&#7879;u..." DataKeyNames="RoleName" ClientDataKeyNames="RoleName"
                                 CommandItemDisplay="Top">
                    <CommandItemTemplate>
                        <a class="btn-addnew"></a>
                    </CommandItemTemplate>
                    <Columns>
                        <telerik:GridTemplateColumn HeaderText="STT" HeaderStyle-Width="30px" ItemStyle-CssClass="center">
                            <ItemTemplate>
                                <%# Container.DataSetIndex + 1 %>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn HeaderText="<%$Resources:Admin, Admin_Roles_ListingRoles%>" DataField="RoleName"
                                                 UniqueName="RoleName" HeaderStyle-CssClass="rgHeader" />
                        <telerik:GridBoundColumn HeaderText="<%$Resources:Admin, Admin_Roles_NumberAcount%>" HeaderStyle-Width="150px" DataField="RoleNumber" UniqueName="RoleNumber" HeaderStyle-CssClass="rgHeader rgHeaderCenter"
                                                 ItemStyle-CssClass="center">
                        </telerik:GridBoundColumn>
                    </Columns>
                </MasterTableView>
                <SortingSettings SortedAscToolTip="S&#7855;p x&#7871;p t&#259;ng d&#7847;n" SortedDescToolTip="S&#7855;p x&#7871;p gi&#7843;m d&#7847;n" SortToolTip="S&#7855;p x&#7871;p d&#7919; li&#7879;u" />
                <ClientSettings>
                    <Selecting AllowRowSelect="True" EnableDragToSelectRows="true" />
                    <ClientEvents OnRowContextMenu="RowContextMenu" OnRowSelected="RowGridSelected" />
                </ClientSettings>
                                <PagerStyle PagerTextFormat="<%$Resources:Admin, Admin_Paging%>"
                            FirstPageToolTip="<%$Resources:Admin, Admin_Paging_FirstPage%>" LastPageToolTip="<%$Resources:Admin, Admin_Paging_LastPage%>" NextPagesToolTip="<%$Resources:Admin, Admin_Paging_NextPages%>" NextPageToolTip="<%$Resources:Admin, Admin_Paging_NextPage%>" PageSizeLabelText="<%$Resources:Admin, Admin_Paging_PageSize%>"
                            PrevPagesToolTip="<%$Resources:Admin, Admin_Paging_PrevPages%>" PrevPageToolTip="<%$Resources:Admin, Admin_Paging_PrevPage%>" />
            </telerik:RadGrid>
        </div>
        <telerik:RadContextMenu ID="radMenuContext" runat="server" OnItemClick="radMenuContext_ItemClick" EnableRoundedCorners="true" EnableShadows="true" Skin="WebBlue">
        </telerik:RadContextMenu>
    </telerik:RadAjaxPanel>
</telerik:RadCodeBlock>
<telerik:RadAjaxLoadingPanel runat="server" Skin="Windows7" ID="RadAjaxLoadingPanel1" BackgroundPosition="Center" EnableSkinTransparency="true">
</telerik:RadAjaxLoadingPanel>