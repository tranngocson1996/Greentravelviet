<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListingComment.ascx.cs" Inherits="Admin_Components_Comment_ListingComment" %>
<%@ Import Namespace="BIC.Utils" %>
<telerik:RadCodeBlock ID="RadCodeBlock2" runat="server">
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
        <div class="input-box">
            <div class="item first">
                <div class="label">
                    Ngôn ngữ
                </div>
                <div class="input">
                    <bic:Language ID="ddlLanguage" runat="server" AutoPostBack="True" CssClass="input-select" OnSelectedIndexChanged="ddlLanguage_SelectedIndexChanged" />
                </div>
            </div>
            <div class="item bg_none">
                <div class="label">
                    <telerik:RadCodeBlock ID="RadCodeBlock4" runat="server">
                        <%=BicResource.GetValue("Admin","System_Browse")%>
                    </telerik:RadCodeBlock>
                </div>
                <div class="input">
                    <%--<bic:DropBoolean runat="server" ID="ddlIsActive" OnSelectedIndexChanged="ddlIsActived_SelectedIndexChanged" CssClass="input-select" DataValueField="key" DataTextField="name" AutoPostBack="True" />--%>
                    <asp:DropDownList runat="server" ID="ddlIsActive" CssClass="input-select" OnSelectedIndexChanged="ddlIsActived_SelectedIndexChanged" AutoPostBack="True">
                        <asp:ListItem Text="<%$Resources:Admin,System_All%>" Value="2" />
                        <asp:ListItem Text="<%$Resources:Admin,Admin_Article_Co%>" Value="1" />
                        <asp:ListItem Text="<%$Resources:Admin,Admin_Article_Khong%>" Value="0" />
                    </asp:DropDownList>
                </div>
            </div>
            <div class="item bg_none">
                <div class="label">
                    <telerik:RadCodeBlock ID="RadCodeBlock3" runat="server">
                        <%=BicResource.GetValue("Admin","System_CategoriesComments")%>
                    </telerik:RadCodeBlock>
                </div>
                <div class="input">
                    <asp:DropDownList ID="ddlTypeOfComment" CssClass="input-select" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlIsActived_SelectedIndexChanged">
                    </asp:DropDownList>
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
                    function RowGridSelected(sender, args) { var key; key = args.getDataKeyValue("CommentID"); document.getElementById("radGridSelectedRowIndex").value = key; }
                    function RowContextMenu(sender, eventArgs) { var menu = $find("<%= radMenuContext.ClientID %>"); var evt = eventArgs.get_domEvent(); if (evt.target.tagName == "INPUT" || evt.target.tagName == "A") { return; } var index = eventArgs.get_itemIndexHierarchical(); document.getElementById("radGridClickedRowIndex").value = index; sender.get_masterTableView().selectItem(sender.get_masterTableView().get_dataItems()[index].get_element(), true); menu.show(evt); evt.cancelBubble = true; evt.returnValue = false; if (evt.stopPropagation) { evt.stopPropagation(); evt.preventDefault(); } }
                </script>
            </telerik:RadCodeBlock>
            <telerik:RadGrid ID="rgManager" EnableEmbeddedSkins="false" Skin="BICCMS" runat="server" HeaderStyle-CssClass="rgHeader rgHeaderCenter" AllowPaging="True" PageSize="20" AllowSorting="False" AllowCustomPaging="True" AllowAutomaticDeletes="true" ShowHeader="true" AutoGenerateColumns="False" AllowMultiRowSelection="true" OnNeedDataSource="rgManager_NeedDataSource" GridLines="None" OnDeleteCommand="rgManager_DeleteCommand" OnItemCommand="rgManager_ItemCommand">
                <MasterTableView TableLayout="Fixed" NoMasterRecordsText="Kh&ocirc;ng c&oacute; d&#7919; li&#7879;u..." DataKeyNames="CommentID" CommandItemDisplay="Top">
                    <CommandItemTemplate>
                        <asp:LinkButton ID="lbtnDeleteSelected" Visible="<%# Deleted %>" CssClass="btn-del" OnClientClick="alet()" runat="server" CommandName="DeleteSelected"><%=BicResource.GetValue("Admin","Admin_DeleteAll") %> </asp:LinkButton>
                    </CommandItemTemplate>
                    <Columns>
                        <telerik:GridClientSelectColumn UniqueName="column" HeaderStyle-Width="30px" ItemStyle-CssClass="center">
                        </telerik:GridClientSelectColumn>
                        <telerik:GridTemplateColumn HeaderText="STT" HeaderStyle-Width="30px" ItemStyle-CssClass="center">
                            <ItemTemplate>
                                <%# Container.DataSetIndex + 1 %>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="<%$Resources:Admin, Admin_Comment_Sender%>" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <span title='<%# Eval("FullName") %>'>
                                    <%# BicString.TrimText(Eval("FullName"), 20) %></span>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="<%$Resources:Admin, Admin_Comment_NewsContent%>">
                            <ItemTemplate>
                                <span style="font-weight: bold">
                                    <%# Eval("Title") %></span>
                                <%--<span title='<%# Eval("Description") %>'>
                                    <%# BicString.TrimText(Eval("Description"), 150) %></span>--%>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="<%$Resources:Admin, System_Locks%>" Visible="False" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:ImageButton ID="ibtnTypeOfComment" BorderWidth="0px" CommandName="TypeOfComment" CommandArgument='<%#Eval("TypeOfComment")%>' ImageUrl='<%# Convert.ToInt32(DataBinder.Eval(Container.DataItem, "TypeOfComment")) == 99 ? "~/Admin/Styles/Icon/checkmark.gif" : "~/Admin/Styles/Icon/uncheckmark.gif" %>' Style="cursor: pointer;" runat="server"></asp:ImageButton>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="<%$Resources:Admin, Admin_Comment_Sex%>" Visible="False" HeaderStyle-Width="60px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <%#(bool) Eval("Gioitinh")?BicResource.GetValue("Admin","Admin_Comment_Sex_Man"):BicResource.GetValue("Admin","Admin_Comment_Sex_Woman") %>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Yes/No" HeaderStyle-Width="60px" Visible="False" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <%# Eval("DongY") %>/<%# Eval("KhongDongY") %>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridDateTimeColumn HeaderText="<%$Resources:Admin, Admin_Comment_CreateDate%>" DataFormatString="{0: dd/MM/yyy}" HeaderStyle-Width="80px" ItemStyle-CssClass="center" DataField="CreateDate" UniqueName="CreateDate" ItemStyle-HorizontalAlign="center">
                        </telerik:GridDateTimeColumn>
                        <telerik:GridTemplateColumn HeaderText="<%$Resources:Admin, System_Browse%>" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:ImageButton ID="ibtnIsActive" BorderWidth="0px" CommandName="IsActive" CommandArgument='<%# Eval("IsActive") %>' Enabled='<%# Approved %>' ImageUrl='<%# Convert.ToBoolean(DataBinder.Eval(Container.DataItem, "IsActive")) ? "~/Admin/Styles/Icon/checkmark.gif" : "~/Admin/Styles/Icon/uncheckmark.gif" %>' Style="cursor: pointer;" runat="server"></asp:ImageButton>
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

<script>
    function alet() {

        return confirm('<%=BicResource.GetValue("Admin","Admin_Comment_Message1")%>');
    }
</script>
