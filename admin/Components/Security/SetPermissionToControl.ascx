<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SetPermissionToControl.ascx.cs" Inherits="admin_Components_Security_SetPermissionToControl" %>
<%@ Import Namespace="BIC.Utils" %>
<telerik:RadCodeBlock ID="RadCodeBlock2" runat="server">
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
        <div class="input-box">
            <div class="item first">
                <div class="label">
                    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
                    <%=BicResource.GetValue("Admin","System_GroupAcounts") %>
                          </telerik:RadCodeBlock>
                        </div>
                <div class="input">
                    <asp:DropDownList ID="ddlRole" runat="server" AutoPostBack="True" CssClass="input-select" OnSelectedIndexChanged="ddlRole_SelectedIndexChanged" />
                </div>
            </div>
        </div>
        <div class="grid">
            <div class="search-box">
                <asp:TextBox ID="txtSearch" Width="250px" Text="" runat="server" AutoPostBack="True" OnTextChanged="txtSearch_TextChanged" Height="18px"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="" />
            </div>
            <telerik:RadGrid ID="rgManager" EnableEmbeddedSkins="false" Skin="BICCMS" runat="server" AllowSorting="true" HeaderStyle-CssClass="rgHeader rgHeaderCenter"
                             AllowPaging="True" PageSize="30" ShowHeader="true" AutoGenerateColumns="False" OnNeedDataSource="rgManager_NeedDataSource" GridLines="None" OnItemCommand="rgManager_ItemCommand">
                <MasterTableView TableLayout="Fixed" NoMasterRecordsText="Kh&ocirc;ng c&oacute; d&#7919; li&#7879;u..." DataKeyNames="ControlRoleID, ControlID" ClientDataKeyNames="ControlRoleID, ControlID"
                                 CommandItemDisplay="Top">
                    <CommandItemTemplate>
                    </CommandItemTemplate>
                    <Columns>
                        <telerik:GridTemplateColumn HeaderText="STT" HeaderStyle-Width="30px" ItemStyle-CssClass="center">
                            <ItemTemplate>
                                <%# Container.DataSetIndex + 1 %>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn HeaderText="<%$Resources:Admin, Admin_Security_NamePanel%>" DataField="ControlName" UniqueName="ControlName" HeaderStyle-CssClass="rgHeader" />
                        <telerik:GridTemplateColumn HeaderText="<%$Resources:Admin, System_All%>" UniqueName="TemplateColumn" HeaderStyle-Width="60px">
                            <ItemTemplate>
                                <asp:ImageButton ID="ibtnAll" BorderWidth="0px" CommandName="CheckAll" CommandArgument='<%# Eval("CheckAll") %>' ImageUrl='<%# Convert.ToBoolean(DataBinder.Eval(Container.DataItem, "CheckAll")) ? "~/Admin/Styles/Icon/checkmark.gif" : "~/Admin/Styles/Icon/uncheckmark.gif" %>'
                                                 Style="cursor:pointer;" runat="server"></asp:ImageButton>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="<%$Resources:Admin, System_View%>" UniqueName="TemplateColumn" HeaderStyle-Width="50px">
                            <ItemTemplate>
                                <asp:ImageButton ID="ibtnViewed" BorderWidth="0px" CommandName="Viewed" CommandArgument='<%# Eval("Viewed") %>' ImageUrl='<%# Convert.ToBoolean(DataBinder.Eval(Container.DataItem, "Viewed")) ? "~/Admin/Styles/Icon/checkmark.gif" : "~/Admin/Styles/Icon/uncheckmark.gif" %>'
                                                 Style="cursor:pointer" runat="server"></asp:ImageButton>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="<%$Resources:Admin, System_Add%>" UniqueName="TemplateColumn" HeaderStyle-Width="50px">
                            <ItemTemplate>
                                <asp:ImageButton ID="ibtnAdded" BorderWidth="0px" CommandName="Added" CommandArgument='<%# Eval("Added") %>' ImageUrl='<%# Convert.ToBoolean(DataBinder.Eval(Container.DataItem, "Added")) ? "~/Admin/Styles/Icon/checkmark.gif" : "~/Admin/Styles/Icon/uncheckmark.gif" %>'
                                                 Style="cursor:pointer;" runat="server"></asp:ImageButton>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="<%$Resources:Admin, System_Edit%>" UniqueName="TemplateColumn" HeaderStyle-Width="50px">
                            <ItemTemplate>
                                <asp:ImageButton ID="ibtnEdited" BorderWidth="0px" CommandName="Edited" CommandArgument='<%# Eval("Edited") %>' ImageUrl='<%# Convert.ToBoolean(DataBinder.Eval(Container.DataItem, "Edited")) ? "~/Admin/Styles/Icon/checkmark.gif" : "~/Admin/Styles/Icon/uncheckmark.gif" %>'
                                                 Style="cursor:pointer;" runat="server"></asp:ImageButton>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="<%$Resources:Admin, System_Delete%>" UniqueName="TemplateColumn" HeaderStyle-Width="50px">
                            <ItemTemplate>
                                <asp:ImageButton ID="ibtnDeleted" BorderWidth="0px" CommandName="Deleted" CommandArgument='<%# Eval("Deleted") %>' ImageUrl='<%# Convert.ToBoolean(DataBinder.Eval(Container.DataItem, "Deleted")) ? "~/Admin/Styles/Icon/checkmark.gif" : "~/Admin/Styles/Icon/uncheckmark.gif" %>'
                                                 Style="cursor:pointer;" runat="server"></asp:ImageButton>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="<%$Resources:Admin, Admin_Security_Browser%>" UniqueName="TemplateColumn" HeaderStyle-Width="50px">
                            <ItemTemplate>
                                <asp:ImageButton ID="ibtnApproved" BorderWidth="0px" CommandName="Approved" CommandArgument='<%# Eval("Approved") %>' ImageUrl='<%# Convert.ToBoolean(DataBinder.Eval(Container.DataItem, "Approved")) ? "~/Admin/Styles/Icon/checkmark.gif" : "~/Admin/Styles/Icon/uncheckmark.gif" %>'
                                                 Style="cursor:pointer;" runat="server"></asp:ImageButton>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                    </Columns>
                </MasterTableView>
                <SortingSettings SortedAscToolTip="S&#7855;p x&#7871;p t&#259;ng d&#7847;n" SortedDescToolTip="S&#7855;p x&#7871;p gi&#7843;m d&#7847;n" SortToolTip="S&#7855;p x&#7871;p d&#7919; li&#7879;u" />
                <ClientSettings>
                    <Selecting AllowRowSelect="True" EnableDragToSelectRows="true" />
                    <Scrolling AllowScroll="false" UseStaticHeaders="true" SaveScrollPosition="true" />
                    <ClientEvents OnRowContextMenu="RowContextMenu" OnRowSelected="RowGridSelected" />
                </ClientSettings>
                    <PagerStyle PagerTextFormat="<%$Resources:Admin, Admin_Paging%>"
                            FirstPageToolTip="<%$Resources:Admin, Admin_Paging_FirstPage%>" LastPageToolTip="<%$Resources:Admin, Admin_Paging_LastPage%>" NextPagesToolTip="<%$Resources:Admin, Admin_Paging_NextPages%>" NextPageToolTip="<%$Resources:Admin, Admin_Paging_NextPage%>" PageSizeLabelText="<%$Resources:Admin, Admin_Paging_PageSize%>"
                            PrevPagesToolTip="<%$Resources:Admin, Admin_Paging_PrevPages%>" PrevPageToolTip="<%$Resources:Admin, Admin_Paging_PrevPage%>" />
            </telerik:RadGrid>
        </div>
    </telerik:RadAjaxPanel>
</telerik:RadCodeBlock>
<telerik:RadAjaxLoadingPanel runat="server" Skin="Windows7" ID="RadAjaxLoadingPanel1" BackgroundPosition="Center" EnableSkinTransparency="false">
</telerik:RadAjaxLoadingPanel>