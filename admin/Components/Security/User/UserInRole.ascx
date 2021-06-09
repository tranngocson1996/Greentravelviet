<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserInRole.ascx.cs" Inherits="admin_Components_Security_UserInRole" %>
<%@ Import Namespace="BIC.Utils" %>
<div id="divDialogOtherChangePass" title="Đổi mật khẩu" class="hidden">
    <iframe id="ifDialogChangeOtherPass" width="100%" height="100%" marginwidth="0" marginheight="0" frameborder="0" scrolling="no" title="Dialog Title">Your
        browser does not support</iframe>
</div>
<script type="text/javascript">
    $.fx.speeds._default = 1000;
    function showChangeOtherPass() { $("#divDialogOtherChangePass").dialog("open"); $("#ifDialogChangeOtherPass").attr("src", '<%= Page.ResolveUrl("~/admin/Components/Security/User/ChangeOtherPassword.aspx") %>'); return false; }
    function BindDialogChangePass() {
        $(function () {
            $("#divDialogOtherChangePass").dialog({
                autoOpen: false,
                modal: true,
                height: 218,
                width: 379,
                resizable: false
            });
        });
    }
</script>
<script type="text/javascript">
    function ImportExcel() {
        var $dialog = $.FrameDialog.create({
            url: 'Components/Security/User/ImportExcel.aspx',
            loadingClass: 'loading-image',
            title: 'Import tài khoản từ file Excel',
            width: 320,
            height: 80,
            autoOpen: false,
            resizable: false
        })
            .bind('dialogclose', function (event, ui) { location.reload(true); }); $dialog.dialog('open');
    }
    $(function () { $('a.btn-ipExcel').click(function () { ImportExcel(); $(this).val('href', '#'); return false; }); });

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
<div class="input-box">
    <div class="item first">
        <div class="label">
            <%=BicResource.GetValue("Admin","System_GroupAcounts") %>
        </div>
        <div class="input">
            <asp:DropDownList ID="ddlRole" runat="server" AutoPostBack="True" CssClass="input-select" OnSelectedIndexChanged="ddlRole_SelectedIndexChanged" />
        </div>
    </div>
</div>
<div class="grid">
    <div class="search-box-user">
        <div class="txt-frame">
            <asp:DropDownList ID="ddlSearchType" CssClass="input-select" runat="server">
                <asp:ListItem Value="0" Text="<%$Resources:Admin,Admin_Security_User_UserName%>">User Name</asp:ListItem>
                <asp:ListItem Value="1" Text="<%$Resources:Admin,Admin_Security_User_Email%>">Email</asp:ListItem>
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
                var firstDataItem = $find("<%= rgManager.ClientID %>").get_masterTableView().get_dataItems()[0]; var keyValues =
                    'UserName: "' +
                        firstDataItem.getDataKeyValue("UserName"); alert(keyValues);
            }
            function RowGridSelected(sender, args) { key = args.getDataKeyValue("UserName"); document.getElementById("radGridSelectedRowIndex").value = key; }
            function RowContextMenu(sender, eventArgs) { var menu = $find("<%= radMenuContext.ClientID %>"); var evt = eventArgs.get_domEvent(); if (evt.target.tagName == "INPUT" || evt.target.tagName == "A") { return; } var index = eventArgs.get_itemIndexHierarchical(); document.getElementById("radGridClickedRowIndex").value = index; sender.get_masterTableView().selectItem(sender.get_masterTableView().get_dataItems()[index].get_element(), true); menu.show(evt); evt.cancelBubble = true; evt.returnValue = false; if (evt.stopPropagation) { evt.stopPropagation(); evt.preventDefault(); } }
        </script>
    </telerik:RadCodeBlock>
    <div class="deleteUser">
        <asp:LinkButton ID="lbtnDeleteSelected" CssClass="btn-del"
            OnClientClick="return MesDelete();"
            runat="server" OnClick="LbtnDeleteSelectedClick">
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
    <telerik:RadGrid ID="rgManager" EnableEmbeddedSkins="false" Skin="BICCMS" runat="server" HeaderStyle-CssClass="rgHeader rgHeaderCenter" AllowPaging="True"
        PageSize="10" AllowSorting="False" AllowCustomPaging="True" K AllowAutomaticDeletes="true" ShowHeader="true" AutoGenerateColumns="False" AllowMultiRowSelection="true"
        GridLines="None" OnDeleteCommand="rgManager_DeleteCommand" OnItemCommand="rgManager_ItemCommand">
        <MasterTableView TableLayout="Fixed" NoMasterRecordsText="Kh&ocirc;ng c&oacute; d&#7919; li&#7879;u..." CommandItemDisplay="Top" DataKeyNames='UserName'>
            <CommandItemTemplate>
               <%-- <asp:LinkButton ID="lbtnDeleteSelected" CssClass="btn-del" OnClientClick="javascript:return confirm('Bạn chắc chắn muốn xóa các bạn ghi đã chọn?')" runat="server"
                    CommandName="DeleteSelected"></asp:LinkButton>
                <asp:LinkButton ID="btnAddNew" CssClass="btn-addnew" runat="server" Visible="<%# Added %>" CommandName="AddNew"></asp:LinkButton>--%>
                <asp:LinkButton ID="lbtnImportExcel" runat="server" CommandName="ImportExcel" CssClass="btn-ipExcel" />
                <asp:LinkButton ID="lbtnExportExcel" runat="server" CommandName="ExportExcel" CssClass="btn-epExcel" />
            </CommandItemTemplate>
            <Columns>
                <telerik:GridClientSelectColumn UniqueName="column" HeaderStyle-Width="30px" ItemStyle-CssClass="center">
                </telerik:GridClientSelectColumn>
                <telerik:GridTemplateColumn HeaderText="<%$Resources:Admin,Admin_Security_User_UserName%>" HeaderStyle-CssClass="rgHeader">
                    <ItemTemplate>
                        <%-- <%#Container.DataItem%>--%>
                        <%# Eval("UserName") %>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="<%$Resources:Admin,System_FullScreen%>">
                    <ItemTemplate>
                        <%# GetProfile(Convert.ToString(Eval("UserName"))).FullName %>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="<%$Resources:Admin,Admin_Security_User_Tell%>">
                    <ItemTemplate>
                        <%# GetProfile(Convert.ToString(Eval("UserName"))).Mobile %>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="<%$Resources:Admin,Admin_Security_User_Email%>">
                    <ItemTemplate>
                        <%# Membership.GetUser(Convert.ToString(Eval("UserName"))).Email %>
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
