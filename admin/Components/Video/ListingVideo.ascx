<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListingVideo.ascx.cs"
    Inherits="Admin_Components_Video_ListingArticle" %>
<%@ Import Namespace="BIC.Utils" %>

<telerik:RadCodeBlock ID="RadCodeBlock2" runat="server">
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
        <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
            <script type="text/javascript">

                function pageLoad() {

                }
                function RowGridSelected(sender, args) { key = args.getDataKeyValue("ArticleID"); document.getElementById("radGridSelectedRowIndex").value = key; } function RowContextMenu(sender, eventArgs) {
                    var menu = $find("<%= radMenuContext.ClientID %>"); var evt = eventArgs.get_domEvent(); if (evt.target.tagName == "INPUT" || evt.target.tagName == "A") { return; } var index = eventArgs.get_itemIndexHierarchical(); document.getElementById("radGridClickedRowIndex").value = index; sender.get_masterTableView().selectItem(sender.get_masterTableView().get_dataItems()[index].get_element(), true); menu.show(evt); evt.cancelBubble = true; evt.returnValue = false; if (evt.stopPropagation) { evt.stopPropagation(); evt.preventDefault(); }
                }

                function ClientNodeChecked(sender, eventArgs) {
                    var node = eventArgs.get_node();
                    if (node.get_checked()) {
                        var list1 = $("#hdTreeMenu").val();
                        var arr1 = list1.split(',');
                        var count = 0;
                        for (var i = 0; i < arr1.length; i++) {
                            if (
                                arr1[i] == node.get_value()) count++;
                        };
                        if (count == 0) $("#hdTreeMenu").val($("#hdTreeMenu").val() + ',' + node.get_value());
                        $("#hdTreeMenu").val($("#hdTreeMenu").val().replace(",,", ","));
                    }
                    else {
                        var list2 = $("#hdTreeMenu").val();
                        var arr2 = list2.split(',');
                        var menuid = "";
                        for (var j = 0; j < arr2.length; j++) {
                            if (arr2[j] != node.get_value()) {
                                menuid = menuid + "," + arr2[j];
                            }
                        };
                        $("#hdTreeMenu").val(menuid.replace(",,", ","));
                    };
                }

            </script>
            <div class="input-box">
                <div class="item first">
                    <div class="label">

                        <%=BicResource.GetValue("Admin","Admin_AdminLanguege_Language") %>
                        <bic:Language AutoPostBack="True" ID="ddlLanguage" runat="server" CssClass="input-select" OnSelectedIndexChanged="ddlLanguage_SelectedIndexChanged" />
                    </div>
                </div>
                <div class="item">
                    <div class="label">

                        <%=BicResource.GetValue("Admin","System_Browse") %>
                    </div>
                    <div class="input">
                        <bic:DropBoolean runat="server" ID="ddlIsActive" CssClass="input-select" DataValueField="key"
                            DataTextField="name" />
                    </div>
                </div>
                <div class="item" style="display: none !important">
                    <div class="label">

                        <%=BicResource.GetValue("Admin","Admin_Article_Spotlight") %>
                    </div>
                    <div class="input">
                        <bic:DropBoolean runat="server" ID="ddlTinTieuDiem" CssClass="input-select" DataValueField="key"
                            DataTextField="name" />
                    </div>
                </div>
                <div class='item <%=BicXML.ToBoolean("EnableComment","SettingArticle") == false? "hidden" : "" %>'>
                    <div class="label">

                        <%=BicResource.GetValue("Admin","Admin_Article_Comment") %>
                    </div>
                    <div class="input">
                        <asp:DropDownList runat="server" ID="ddlCommentNew" CssClass="input-select">
                            <asp:ListItem Text="<%$Resources:Admin,System_All%>" Value="2" />
                            <asp:ListItem Text="<%$Resources:Admin,Admin_Article_Havebrowse%>" Value="1" />
                            <asp:ListItem Text="<%$Resources:Admin,System_NoBrowse%>" Value="0" />
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="item bg_none">
                    <div class="label">

                        <%=BicResource.GetValue("Admin","Admin_Article_FromDate") %>
                    </div>
                    <div class="input">
                        <telerik:RadDatePicker ID="radBDBeginDate" runat="server" CssClass="input-date" Width="120px" DateInput-EmptyMessage="<%$Resources:Admin, Admin_Article_SelectDate%>"
                            DateInput-DateFormat="dd/MM/yyyy" ShowPopupOnFocus="True">
                        </telerik:RadDatePicker>
                    </div>
                </div>
                <div class="item">
                    <div class="label">

                        <%=BicResource.GetValue("Admin","Admin_Article_ToDay") %>
                    </div>
                    <div class="input">
                        <telerik:RadDatePicker ID="radBDEndDate" runat="server" CssClass="input-date" Width="120px" DateInput-EmptyMessage="<%$Resources:Admin, Admin_Article_SelectDate%>"
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
                            OnClick="btnFind_OnClick" />
                    </div>
                </div>
            </div>
            <div class="input-side">
                <div class="tree-box">
                    <div class="tree-title">

                        <%=BicResource.GetValue("Admin","Admin_Article_SortResults") %>
                    </div>
                    <div style="background-color: #FFF; width: 220px; height: 30px; padding-top: 5px; padding-left: 10px; font-size: 13px">
                        <asp:DropDownList runat="server" ID="rblSort" Width="170px">
                            <asp:ListItem Value="8" Text="<%$Resources:Admin,Admin_Article_PriorityAscending%>"></asp:ListItem>
                            <asp:ListItem Value="9" Text="<%$Resources:Admin,Admin_Article_PriorityDescending%>"></asp:ListItem>
                            <asp:ListItem Value="0" Text="<%$Resources:Admin,Admin_Article_DateCreationDescending%>"></asp:ListItem>
                            <asp:ListItem Value="1" Text="<%$Resources:Admin,Admin_Article_DateCreationAscending%>"></asp:ListItem>
                            <asp:ListItem Value="2" Text="<%$Resources:Admin,Admin_Article_ViewsDescending%>"></asp:ListItem>
                            <asp:ListItem Value="3" Text="<%$Resources:Admin,Admin_Article_ViewsAscending%>"></asp:ListItem>
                            <asp:ListItem Value="4" Text="<%$Resources:Admin,Admin_Article_CommentDescending%>"></asp:ListItem>
                            <asp:ListItem Value="5" Text="<%$Resources:Admin,Admin_Article_CommentAscending%>"></asp:ListItem>
                            <asp:ListItem Value="6" Text="<%$Resources:Admin,Admin_Article_DateModificationDescending%>"></asp:ListItem>
                            <asp:ListItem Value="7" Text="<%$Resources:Admin,Admin_Article_DateModificationAscending%>"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="tree-title">

                        <%=BicResource.GetValue("Admin","Admin_Article_SearchByCategory") %>
                    </div>
                    <div class="tree-content">
                        <telerik:RadTreeView runat="server" Skin="Outlook" CheckBoxes="true" ID="tvMenuUser"
                            PersistLoadOnDemandNodes="true" LoadingStatusPosition="None" CollapseAnimation-Duration="0"
                            ExpandAnimation-Duration="0" ExpandAnimation-Type="none" OnClientNodeChecked="ClientNodeChecked">
                        </telerik:RadTreeView>
                        <asp:HiddenField ID="hdTreeMenu" runat="server" ClientIDMode="Static" />
                    </div>
                </div>
            </div>
        </telerik:RadCodeBlock>
        <div class="grid-side">
            <input type="hidden" id="radGridClickedRowIndex" name="radGridClickedRowIndex" />
            <input type="hidden" id="radGridSelectedRowIndex" name="radGridSelectedRowIndex" />
            <input type="hidden" id="confirmdelete" name="confirmdelete" />
            <div class="search-box">
                <asp:TextBox ID="txtSearch" Width="250px" Text="" runat="server" AutoPostBack="True"
                    OnTextChanged="txtSearch_TextChanged" Height="18px"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="" />
            </div>
            <div class="deleteall">

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
                <a class="btn-movenew" onclick="onClickedMove();">
                    <telerik:RadCodeBlock ID="RadCodeBlock4" runat="server">
                        <%=BicResource.GetValue("Admin","System_Move") %>
                    </telerik:RadCodeBlock>
                </a>
            </div>

            <telerik:RadGrid ID="rgManager" EnableEmbeddedSkins="false"
                Skin="BICCMS" runat="server" HeaderStyle-CssClass="rgHeader rgHeaderCenter" AllowPaging="True" PageSize="20" AllowCustomPaging="True"
                OnPageIndexChanged="rgManager_PageIndexChanged"
                AllowAutomaticDeletes="true" ShowHeader="true" OnItemCreated="rgManager_ItemCreated" AutoGenerateColumns="False" AllowMultiRowSelection="true"
                GridLines="None" OnDeleteCommand="rgManager_DeleteCommand"
                OnItemCommand="rgManager_ItemCommand">
                <MasterTableView TableLayout="Fixed" NoMasterRecordsText="Kh&ocirc;ng c&oacute; d&#7919; li&#7879;u..."
                    DataKeyNames="ArticleID,UrlName" ClientDataKeyNames="ArticleID" CommandItemDisplay="Top">
                    <CommandItemTemplate>
                    </CommandItemTemplate>
                    <Columns>
                        <telerik:GridClientSelectColumn UniqueName="ClientSelectColumn" HeaderStyle-Width="30px" ItemStyle-CssClass="center">
                        </telerik:GridClientSelectColumn>
                        <telerik:GridBoundColumn UniqueName="UniqueID" DataField="ArticleID">
                            <HeaderStyle Width="1" />
                            <ItemStyle Width="1" />
                        </telerik:GridBoundColumn>
                          <telerik:GridTemplateColumn HeaderText="Thứ tự" UniqueName="TemplateColumn" HeaderStyle-Width="50px">
                            <ItemTemplate>
                                 <%#Container.ItemIndex+1 %>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="<%$Resources:Admin,System_Image%>" ItemStyle-VerticalAlign="Middle" HeaderStyle-Width="40px" ItemStyle-CssClass="imagecell">
                            <ItemTemplate>
                                <img runat="server" width="40" height="30" src='<%#Page.ResolveUrl("~/FileUpload/Images/thumb/") + Eval("ImageName")%>' id="imgImageID" alt="" />
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn HeaderText="<%$Resources:Admin,Admin_Article_Title%>"
                            DataField="Title" UniqueName="Title" HeaderStyle-CssClass="rgHeader" />
                        <telerik:GridBoundColumn HeaderText="<%$Resources:Admin,Admin_Article_List%>" DataField="Nhom" HeaderStyle-Width="200px" />
                        <telerik:GridTemplateColumn Visible="False" HeaderText="<%$Resources:Admin,Admin_Article_Comment%>" HeaderStyle-Width="60px" ItemStyle-CssClass="center">
                            <ItemTemplate>
                                <div title="<%=BicResource.GetValue("Admin","Admin_Article_CommentState") %>"><%# Eval("InActiveComment") + " / " + Eval("ActiveComment") %></div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridDateTimeColumn HeaderText="<%$Resources:Admin,System_DatePosted%>" DataFormatString="{0:HH:ss - dd/MM/yyy}"
                            HeaderStyle-Width="110px" Visible="False" ItemStyle-CssClass="center" DataField="CreatedDate"
                            UniqueName="CreatedDate">
                        </telerik:GridDateTimeColumn>
                        <telerik:GridDateTimeColumn HeaderText="<%$Resources:Admin,Admin_Article_Update%>" DataFormatString="{0: dd/MM/yyy}"
                            HeaderStyle-Width="75px" ItemStyle-CssClass="center" DataField="ModifiedDate"
                            UniqueName="ModifiedDate">
                        </telerik:GridDateTimeColumn>
                        <telerik:GridBoundColumn HeaderText="<%$Resources:Admin,System_View%>" DataField="ViewCount" UniqueName="ViewCount"
                            HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="center">
                        </telerik:GridBoundColumn>
                        <telerik:GridTemplateColumn HeaderText="<%$Resources:Admin,System_New%>" UniqueName="TemplateColumn" HeaderStyle-Width="40px">
                            <ItemTemplate>
                                <asp:ImageButton ID="ibtnIsNew" BorderWidth="0px" Enabled='<%#EnableIsNew(Eval("CreatedDate")) %>'
                                    CommandName="IsNew" CommandArgument='<%#Eval("IsNew")%>' ImageUrl='<%# (Convert.ToBoolean(DataBinder.Eval(Container.DataItem, "IsNew")) && EnableIsNew(Eval("CreatedDate")))? "~/Admin/Styles/Icon/checkmark.gif" : (EnableIsNew(Eval("CreatedDate")) ? "~/Admin/Styles/Icon/uncheckmark.gif" : "~/Admin/Styles/Icon/DenableIsNew.gif") %>'
                                    Style="cursor: pointer;" runat="server"></asp:ImageButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="<%$Resources:Admin,System_Browse%>" UniqueName="TemplateColumn" ItemStyle-HorizontalAlign="Center"
                            HeaderStyle-Width="45px">
                            <ItemTemplate>
                                <asp:ImageButton ID="ibtnIsActive" BorderWidth="0px" Enabled="<%# Approved %>" CommandName="IsActive" CommandArgument='<%#Eval("IsActive") %>' ImageUrl='<%# Convert.ToBoolean(DataBinder.Eval(Container.DataItem, "IsActive"))? "~/Admin/Styles/Icon/checkmark.gif" : "~/Admin/Styles/Icon/uncheckmark.gif" %>' Style="cursor: pointer;" runat="server"></asp:ImageButton>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="<%$Resources:Admin,System_Edit%>" UniqueName="TemplateColumn" ItemStyle-HorizontalAlign="Center"
                            HeaderStyle-Width="40px">
                            <ItemTemplate>
                                <asp:ImageButton ID="ibtnEdit" BorderWidth="0px" Visible="<%# Edited %>" CommandName="Edit" CommandArgument='<%# Eval("ArticleID") %>'
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
                    <ClientEvents OnRowContextMenu="RowContextMenu" OnRowSelected="RowGridSelected" />

                </ClientSettings>
                <PagerStyle PagerTextFormat="<%$Resources:Admin, Admin_Paging%>" Mode="NextPrev"
                    FirstPageToolTip="<%$Resources:Admin, Admin_Paging_FirstPage%>" LastPageToolTip="<%$Resources:Admin, Admin_Paging_LastPage%>" NextPagesToolTip="<%$Resources:Admin, Admin_Paging_NextPages%>" NextPageToolTip="<%$Resources:Admin, Admin_Paging_NextPage%>" PageSizeLabelText="<%$Resources:Admin, Admin_Paging_PageSize%>" Position="TopAndBottom"
                    PrevPagesToolTip="<%$Resources:Admin, Admin_Paging_PrevPages%>" PrevPageToolTip="<%$Resources:Admin, Admin_Paging_PrevPage%>" />
            </telerik:RadGrid>
        </div>
    </telerik:RadAjaxPanel>
</telerik:RadCodeBlock>
<telerik:RadContextMenu ID="radMenuContext" runat="server" OnItemClick="radMenuContext_ItemClick"
    EnableRoundedCorners="true" OnClientItemClicking="onClientItemClicked" EnableShadows="true"
    Skin="WebBlue">
</telerik:RadContextMenu>
<telerik:RadAjaxLoadingPanel runat="server" Skin="Outlook" ID="RadAjaxLoadingPanel1"
    BackgroundPosition="Center" EnableSkinTransparency="true">
</telerik:RadAjaxLoadingPanel>
<telerik:RadWindowManager ID="RadWindowManager1" runat="server" EnableShadow="true"
    OnClientClose="onClientClose">
    <Windows>
        <telerik:RadWindow ID="MenuUserListDialog" runat="server" Title="Move content"
            Height="520px" Width="410px" Left="150px" ReloadOnShow="true" ShowContentDuringLoad="True"
            Modal="true" />
    </Windows>
</telerik:RadWindowManager>
<telerik:RadScriptBlock ID="RadCodeBlock3" runat="server">
    <script type="text/javascript">
        function onClientItemClicked(sender, args) {
            var commandName = args.get_item().get_value();
            if (commandName == "Move") {
                var grid = $find("<%= rgManager.MasterTableView.ClientID %>");
                ShowMenuUser(GetSelectedID(grid)); args.set_cancel(true); sender.hide();
            }
        } function ShowMenuUser(id) {
            window.radopen('<%= Page.ResolveUrl("~/admin/Components/Article/TreeViewMenuUser.aspx?id=' + id + '&l=' + AdminLanguage + '") %>', "MenuUserListDialog");
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
        return confirm('<%=BicResource.GetValue("Admin","Admin_Article_Message7")%>');
    }
</script>

