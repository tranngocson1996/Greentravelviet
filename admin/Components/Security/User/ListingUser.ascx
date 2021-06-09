<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListingUser.ascx.cs" Inherits="admin_Components_Security_ListingUser" %>
<%@ Import Namespace="BIC.Utils" %>
<div id="divDialogOtherChangePass" title="Đổi mật khẩu" class="hidden">
    <iframe id="ifDialogChangeOtherPass" width="100%" height="100%" marginwidth="0" marginheight="0" frameborder="0" scrolling="no" title="Dialog Title">Your
        browser does not support</iframe>
</div>
<script type="text/javascript">
    $.fx.speeds._default = 1000;
    function showChangeOtherPass() {
        $("#divDialogOtherChangePass").dialog("open");
        $("#ifDialogChangeOtherPass").attr("src", '<%= Page.ResolveUrl("~/admin/Components/Security/User/ChangeOtherPassword.aspx?l="+BicLanguage.CurrentLanguageAdmin) %>');
        return false;
    }
    function BindDialogChangePass() {$(function() { $("#divDialogOtherChangePass").dialog({
        autoOpen: false,
        modal: true,
        height: 218,
        width: 379,
        resizable: false
    }); });}
</script>
<script type="text/javascript">
    function ImportExcel() {var $dialog = $.FrameDialog.create({
        url: 'Components/Security/User/ImportExcel.aspx',
        loadingClass: 'loading-image',
        title: 'Import tài khoản từ file Excel',
        width: 320,
        height: 80,
        autoOpen: false,
        resizable: false
    })
        .bind('dialogclose', function(event, ui) { location.reload(true); });$dialog.dialog('open');}
    $(function() { $('a.btn-ipExcel').click(function() {ImportExcel();$(this).val('href', '#');return false;}); });

</script>
<script type="text/javascript">
    Sys.Application.add_load(BindDialogChangePass);
</script>
<%--<div class="input-box">
            <div class="item first">
                <div class="label">
                   Số thành viên đã đăng ký:
                     <asp:Label ID="ltlRegisted" runat="server" />
                </div>
            </div>
            <div class="item">
                <div class="label">
                    Số thành viên đang trực tuyến:
                     <asp:Label CssClass="Label" ID="ltlOnline" runat="server" />
                 </div>
             </div>
</div>--%>
<%--    <div class="input-box">
            <div class="item first">
                <div class="label">
                    Nhóm tài khoản</div>
                <div class="input">
                    <asp:DropDownList ID="ddlRole" runat="server" AutoPostBack="True" CssClass="input-select"
                        OnSelectedIndexChanged="ddlRole_SelectedIndexChanged" />
                </div>
            </div>
        </div>--%>
<div class="grid">
    <div class="search-box-user">
        <div class="txt-frame">
            <asp:DropDownList ID="ddlSearchType" CssClass="input-select" runat="server">
                <asp:ListItem Value="0" Text="<%$Resources:Admin,Admin_Security_User_UserName%>"></asp:ListItem>
                <asp:ListItem Value="1" Text="<%$Resources:Admin,Admin_Security_User_Email%>"></asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox ID="txtSearchText" Text="" runat="server" AutoPostBack="True" OnTextChanged="txtSearchText_TextChanged"></asp:TextBox>
        </div>
        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="" />
    </div>
    <input type="hidden" id="radGridClickedRowIndex" name="radGridClickedRowIndex" />
    <input type="hidden" id="radGridSelectedRowIndex" name="radGridSelectedRowIndex" />
    <input type="hidden" id="confirmdelete" name="confirmdelete" />
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            function GetDatakey() { //Get Datakey
                var firstDataItem = $find("<%= rgManager.ClientID %>").get_masterTableView().get_dataItems()[0];var keyValues =
                    'UserName: "' +
                        firstDataItem.getDataKeyValue("UserName");alert(keyValues);}
            function RowGridSelected(sender, args) {key = args.getDataKeyValue("UserName");document.getElementById("radGridSelectedRowIndex").value = key;}
            function RowContextMenu(sender, eventArgs) {var menu = $find("<%= radMenuContext.ClientID %>");var evt = eventArgs.get_domEvent();if (evt.target.tagName == "INPUT" || evt.target.tagName == "A") {return;}var index = eventArgs.get_itemIndexHierarchical();document.getElementById("radGridClickedRowIndex").value = index;sender.get_masterTableView().selectItem(sender.get_masterTableView().get_dataItems()[index].get_element(), true);menu.show(evt);evt.cancelBubble = true;evt.returnValue = false;if (evt.stopPropagation) {evt.stopPropagation();evt.preventDefault();}}
        </script>
    </telerik:RadCodeBlock>
    <telerik:RadGrid ID="rgManager" EnableEmbeddedSkins="false" Skin="BICCMS" runat="server" HeaderStyle-CssClass="rgHeader rgHeaderCenter" AllowPaging="True"
                     PageSize="20" AllowSorting="False" AllowCustomPaging="false" AllowAutomaticDeletes="true" ShowHeader="true" AutoGenerateColumns="False" AllowMultiRowSelection="true"
                     OnNeedDataSource="rgManager_NeedDataSource" GridLines="None" OnDeleteCommand="rgManager_DeleteCommand" OnItemCommand="rgManager_ItemCommand">
        <MasterTableView TableLayout="Fixed" NoMasterRecordsText="Kh&ocirc;ng c&oacute; d&#7919; li&#7879;u..." DataKeyNames="UserName" ClientDataKeyNames="UserName"
                         CommandItemDisplay="Top">
            <CommandItemTemplate>
                <asp:LinkButton ID="lbtnDeleteSelected" Visible="<%# Deleted %>" CssClass="btn-del" OnClientClick="javascript:return confirm('Bạn chắc chắn muốn xóa các bạn ghi đã chọn?')"
                                runat="server" CommandName="DeleteSelected"><%=BicResource.GetValue("Admin","Admin_DeleteAll") %></asp:LinkButton>
                <a href='<%# BicAdmin.UrlAdd() %>' class="btn-addnew" visible="<%# Added %>"><%=BicResource.GetValue("Admin","System_Add") %></a>
                <asp:LinkButton ID="lbtnImportExcel" runat="server" CommandName="ImportExcel" CssClass="btn-ipExcel" />
                <asp:LinkButton ID="lbtnExportExcel" runat="server" CommandName="ExportExcel" CssClass="btn-epExcel" />
            </CommandItemTemplate>
            <Columns>
                <telerik:GridClientSelectColumn UniqueName="column" HeaderStyle-Width="30px" ItemStyle-CssClass="center">
                </telerik:GridClientSelectColumn>
                <telerik:GridTemplateColumn HeaderText="<%$Resources:Admin,Admin_Security_User_AcountName%>" HeaderStyle-CssClass="rgHeader">
                    <ItemTemplate>
                        <%# Eval("UserName") %>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="<%$Resources:Admin,Admin_Security_User_Tell%>">
                    <ItemTemplate>
                        <%# GetProfile(Eval("UserName").ToString()).Mobile %>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="<%$Resources:Admin,Admin_Security_User_Email%>">
                    <ItemTemplate>
                        <%# Membership.GetUser(Eval("UserName").ToString()).Email %>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridBoundColumn HeaderText="<%$Resources:Admin,Admin_Security_User_LastLogin%>" DataFormatString="{0:dd/MM/yyyy-HH:mm:ss}" DataField="LastLoginDate">
                    <HeaderStyle CssClass="rgHeader rgHeaderCenter" Width="120px" />
                    <ItemStyle CssClass="center" />
                </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn HeaderText="<%$Resources:Admin,System_Locks%>" UniqueName="IsLockedOut">
                    <HeaderStyle CssClass="rgHeader rgHeaderCenter" Width="40px" />
                    <ItemStyle CssClass="center" HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:ImageButton ID="ibtnIsLockedOut" BorderWidth="0px" CommandName="IsLockedOut" CommandArgument='<%# Eval("UserName") %>' ImageUrl='<%# (bool) Eval("IsLockedOut") ? "~/Admin/Styles/icon/lock.gif" : "~/Admin/Styles/icon/unlock.gif" %>'
                                         Style="cursor:pointer;" runat="server"></asp:ImageButton>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <%--            <telerik:GridTemplateColumn HeaderText="Trực tuyến" UniqueName="IsOnline">
                <HeaderStyle CssClass="rgHeader rgHeaderCenter" Width="70px" />
                <ItemStyle CssClass="center" />
                <ItemTemplate>
                    <img runat="server" src='<%# (bool)Eval("IsOnline") ? "~/Admin/Styles/icon/Online.gif" : "~/Admin/Styles/icon/Offline.gif" %>' />
                </ItemTemplate>
            </telerik:GridTemplateColumn>--%>
                <telerik:GridTemplateColumn HeaderText="<%$Resources:Admin,Admin_Security_Browser%>" UniqueName="IsApproved">
                    <HeaderStyle CssClass="rgHeader rgHeaderCenter" Width="40px" />
                    <ItemStyle CssClass="center" HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:ImageButton ID="ibtnIsApproved" BorderWidth="0px" CommandName="IsApproved" CommandArgument='<%# Eval("UserName") %>' ImageUrl='<%# Convert.ToBoolean(DataBinder.Eval(Container.DataItem, "IsApproved")) ? "~/Admin/Styles/icon/checkmark.gif" : "~/Admin/Styles/icon/uncheckmark.gif" %>'
                                         Style="cursor:pointer;" runat="server" />
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>
        </MasterTableView>
        <SortingSettings SortedAscToolTip="S&#7855;p x&#7871;p t&#259;ng d&#7847;n" SortedDescToolTip="S&#7855;p x&#7871;p gi&#7843;m d&#7847;n" SortToolTip="S&#7855;p x&#7871;p d&#7919; li&#7879;u" />
        <ClientSettings>
            <Scrolling AllowScroll="false" UseStaticHeaders="true" SaveScrollPosition="true" />
            <Selecting AllowRowSelect="True" />
            <ClientEvents OnRowContextMenu="RowContextMenu" OnRowSelected="RowGridSelected" />
        </ClientSettings>
      <PagerStyle PagerTextFormat="<%$Resources:Admin, Admin_Paging%>"
                            FirstPageToolTip="<%$Resources:Admin, Admin_Paging_FirstPage%>" LastPageToolTip="<%$Resources:Admin, Admin_Paging_LastPage%>" NextPagesToolTip="<%$Resources:Admin, Admin_Paging_NextPages%>" NextPageToolTip="<%$Resources:Admin, Admin_Paging_NextPage%>" PageSizeLabelText="<%$Resources:Admin, Admin_Paging_PageSize%>"
                            PrevPagesToolTip="<%$Resources:Admin, Admin_Paging_PrevPages%>" PrevPageToolTip="<%$Resources:Admin, Admin_Paging_PrevPage%>" />
    </telerik:RadGrid>
    <telerik:RadContextMenu ID="radMenuContext" runat="server" OnItemClick="radMenuContext_ItemClick" EnableRoundedCorners="true" EnableShadows="true" Skin="WebBlue">
    </telerik:RadContextMenu>
</div>