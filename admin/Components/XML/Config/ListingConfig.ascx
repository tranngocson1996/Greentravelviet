<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListingConfig.ascx.cs" Inherits="Admin_Components_Config_ListingConfig" %>
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
            <div class="item last">
                <div class="label">
                       <telerik:RadCodeBlock ID="RadCodeBlock4" runat="server">
                    <%=BicResource.GetValue("Admin","Admin_XML_Config_Category") %>
                          </telerik:RadCodeBlock>
                   </div>
                <div class="input">
                    <asp:DropDownList runat="server" ID="ddlType" CssClass="input-select" AutoPostBack="True" OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
                        <asp:ListItem Text="<%$Resources:Admin, System_All%>" Value="" />
                        <asp:ListItem Text="<%$Resources:Admin, Admin_XML_Config_News%>" Value="news" />
                        <asp:ListItem Text="<%$Resources:Admin, Admin_XML_Config_Product%>" Value="product" />
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="grid">
            <input type="hidden" id="radGridClickedRowIndex" name="radGridClickedRowIndex" />
            <input type="hidden" id="radGridSelectedRowIndex" name="radGridSelectedRowIndex" />
            <input type="hidden" id="confirmdelete" name="confirmdelete" />
            <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
                <script type="text/javascript">
                    function RowGridSelected(sender, args) {key = args.getDataKeyValue("key");document.getElementById("radGridSelectedRowIndex").value = key;}
                    function RowContextMenu(sender, eventArgs) {var menu = $find("<%= radMenuContext.ClientID %>");var evt = eventArgs.get_domEvent();if (evt.target.tagName == "INPUT" || evt.target.tagName == "A") {return;}var index = eventArgs.get_itemIndexHierarchical();document.getElementById("radGridClickedRowIndex").value = index;sender.get_masterTableView().selectItem(sender.get_masterTableView().get_dataItems()[index].get_element(), true);menu.show(evt);evt.cancelBubble = true;evt.returnValue = false;if (evt.stopPropagation) {evt.stopPropagation();evt.preventDefault();}}
                </script>
            </telerik:RadCodeBlock>
            <telerik:RadGrid ID="rgManager" EnableEmbeddedSkins="false" Skin="BICCMS" runat="server" HeaderStyle-CssClass="rgHeader rgHeaderCenter"
                             AllowPaging="True" PageSize="20" AllowSorting="False" AllowCustomPaging="false" AllowAutomaticDeletes="true" ShowHeader="true"
                             AutoGenerateColumns="False" AllowMultiRowSelection="true" OnNeedDataSource="rgManager_NeedDataSource" GridLines="None"
                             OnDeleteCommand="rgManager_DeleteCommand">
                <MasterTableView TableLayout="Fixed" NoMasterRecordsText="Kh&ocirc;ng c&oacute; d&#7919; li&#7879;u..." DataKeyNames="datakey"
                                 ClientDataKeyNames="datakey" CommandItemDisplay="Top">
                    <CommandItemTemplate>
                    </CommandItemTemplate>
                    <Columns>
                        <telerik:GridTemplateColumn HeaderText="STT" HeaderStyle-Width="30px" ItemStyle-CssClass="center">
                            <ItemTemplate>
                                <%# Container.DataSetIndex + 1 %>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn HeaderText="<%$Resources:Admin,Admin_XML_Config_ConfigurationName%>" DataField="name" HeaderStyle-Width="30%" />
                        <telerik:GridBoundColumn HeaderText="<%$Resources:Admin,Admin_XML_Config_Value%>" DataField="value" />
                        <telerik:GridBoundColumn HeaderText="<%$Resources:Admin,Admin_XML_Config_Category%>" DataField="type" />
                    </Columns>
                </MasterTableView>
                <SortingSettings SortedAscToolTip="S&#7855;p x&#7871;p t&#259;ng d&#7847;n" SortedDescToolTip="S&#7855;p x&#7871;p gi&#7843;m d&#7847;n"
                                 SortToolTip="S&#7855;p x&#7871;p d&#7919; li&#7879;u" />
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
<telerik:RadAjaxLoadingPanel runat="server" Skin="Windows7" ID="RadAjaxLoadingPanel1" BackgroundPosition="Center" EnableSkinTransparency="true">
</telerik:RadAjaxLoadingPanel>
<telerik:RadContextMenu ID="radMenuContext" runat="server" OnItemClick="radMenuContext_ItemClick" EnableRoundedCorners="true"
                        EnableShadows="true" Skin="WebBlue">
</telerik:RadContextMenu>