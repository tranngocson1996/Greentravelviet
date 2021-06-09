<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListingAdv.ascx.cs" Inherits="Admin_Components_Adv_ListingAdv" %>
<%@ Import Namespace="BIC.Utils" %>
<telerik:RadCodeBlock ID="RadCodeBlock2" runat="server">
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
        <div class="input-box">
            <div class="item first">
                <div class="label">
                    <telerik:RadCodeBlock ID="RadCodeBlock3" runat="server">
                        <%=BicResource.GetValue("Admin","System_Language") %>
                    </telerik:RadCodeBlock>
                </div>
                <div class="input">
                    <bic:Language ID="ddlLanguage" runat="server" AutoPostBack="True" CssClass="input-select" OnSelectedIndexChanged="ddlLanguage_SelectedIndexChanged" />
                </div>
            </div>
            <div class="item">
                <div class="label">
                    <telerik:RadCodeBlock ID="RadCodeBlock4" runat="server">
                        <%=BicResource.GetValue("Admin","Admin_Adv_AdPlacement") %>
                    </telerik:RadCodeBlock>
                </div>
                <div class="input">
                    <asp:DropDownList ID="ddlTypeOfAdvID" CssClass="input-select" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlTypeOfAdvID_SelectedIndexChanged" />
                </div>
            </div>
            <div class="item bg_none">
                <div class="label">

                    <telerik:RadCodeBlock ID="RadCodeBlock5" runat="server">
                        <%=BicResource.GetValue("Admin","System_Browse") %>
                    </telerik:RadCodeBlock>
                </div>
                <div class="input">
                    <bic:DropBoolean runat="server" ID="ddlIsActive" OnSelectedIndexChanged="ddlLanguage_SelectedIndexChanged" CssClass="input-select" DataValueField="key"
                        DataTextField="name" AutoPostBack="True" />
                </div>
            </div>
        </div>
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
                    function RowGridSelected(sender, args) { key = args.getDataKeyValue("AdvID"); document.getElementById("radGridSelectedRowIndex").value = key; }
                    function RowContextMenu(sender, eventArgs) { var menu = $find("<%= radMenuContext.ClientID %>"); var evt = eventArgs.get_domEvent(); if (evt.target.tagName == "INPUT" || evt.target.tagName == "A") { return; } var index = eventArgs.get_itemIndexHierarchical(); document.getElementById("radGridClickedRowIndex").value = index; sender.get_masterTableView().selectItem(sender.get_masterTableView().get_dataItems()[index].get_element(), true); menu.show(evt); evt.cancelBubble = true; evt.returnValue = false; if (evt.stopPropagation) { evt.stopPropagation(); evt.preventDefault(); } }
                </script>
            </telerik:RadCodeBlock>
            <telerik:RadGrid ID="rgManager" EnableEmbeddedSkins="false" Skin="BICCMS" runat="server" HeaderStyle-CssClass="rgHeader rgHeaderCenter" AllowPaging="True"
                PageSize="10" AllowSorting="False" AllowCustomPaging="true" OnPageIndexChanged="rgManager_PageIndexChanged" AllowAutomaticDeletes="true" ShowHeader="true"
                AutoGenerateColumns="False" AllowMultiRowSelection="true" OnNeedDataSource="rgManager_NeedDataSource" GridLines="None" OnDeleteCommand="rgManager_DeleteCommand"
                OnItemCommand="rgManager_ItemCommand">
                <MasterTableView TableLayout="Fixed" NoMasterRecordsText="Kh&ocirc;ng c&oacute; d&#7919; li&#7879;u..." DataKeyNames="AdvID" CommandItemDisplay="Top">
                    <CommandItemTemplate>
                        <asp:LinkButton Visible="<%# Deleted %>" ID="lbtnDeleteSelected" CssClass="btn-del" OnClientClick="javascript:return confirm('B&#7841;n ch&#7855;c ch&#7855;n mu&#7889;n x&oacute;a c&aacute;c b&#7843;n ghi &#273;&atilde; ch&#7885;n?')"
                            runat="server" CommandName="DeleteSelected">
                            <telerik:RadCodeBlock ID="RadCodeBlock4" runat="server">
                                <%=BicResource.GetValue("Admin","Admin_DeleteAll") %>
                            </telerik:RadCodeBlock>
                        </asp:LinkButton>
                        <a href='<%# BicAdmin.UrlAdd() %>' class="btn-addnew" visible="<%# Added %>">
                            <telerik:RadCodeBlock ID="RadCodeBlock6" runat="server">
                                <%=BicResource.GetValue("Admin","System_Add") %>
                            </telerik:RadCodeBlock>
                        </a>
                    </CommandItemTemplate>
                    <Columns>
                        <telerik:GridClientSelectColumn UniqueName="column" HeaderStyle-Width="30px" ItemStyle-CssClass="center">
                        </telerik:GridClientSelectColumn>
                        <telerik:GridTemplateColumn HeaderText="STT" HeaderStyle-Width="30px" ItemStyle-CssClass="center">
                            <ItemTemplate>
                                <%# Container.DataSetIndex + 1 %>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn HeaderText="<%$Resources:Admin, Admin_Adv_NameAd%>" DataField="Name" />
                        <%--  <telerik:GridBoundColumn HeaderText="Lượt xem" DataField="ViewCount" HeaderStyle-Width="80"
                            ItemStyle-CssClass="center" />
                        <telerik:GridDateTimeColumn HeaderText="Ngày hết hạn" DataField="ExpireDate" DataFormatString="{0:dd/MM/yyyy}"
                            HeaderStyle-Width="90" ItemStyle-CssClass="center" />--%>
                        <telerik:GridTemplateColumn HeaderText="<%$Resources:Admin, System_Browse%>" HeaderStyle-Width="40">
                            <ItemTemplate>
                                <asp:ImageButton ID="ibtnIsActive" BorderWidth="0px" CommandName="IsActive" CommandArgument='<%# Eval("IsActive") %>' Enabled='<%# Approved %>' ImageUrl='<%# Convert.ToBoolean(DataBinder.Eval(Container.DataItem, "IsActive")) ? "~/Admin/Styles/Icon/checkmark.gif" : "~/Admin/Styles/Icon/uncheckmark.gif" %>'
                                    Style="cursor: pointer;" runat="server"></asp:ImageButton>
                            </ItemTemplate>
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
