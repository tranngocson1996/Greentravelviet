<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListingDocument.ascx.cs" Inherits="Admin_Components_Document_ListingDocument" %>
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
        <div class="item first">
                <div class="label">
                   Danh mục tài liệu
                </div>
                <div class="input">
                    <bic:MenuRecursion ID="ddlDocumentTypeID" CssClass="input-select" runat="server" />
                </div>
            </div>

        <div class="item bg_none">
            <div class="input">
            </div>
        </div>
        <div class="item bg_none">
            <div class="input">
                <asp:Button runat="server" ID="btnFind" Text="<%$Resources:Admin,Document_Search%>" Height="25px"
                    OnClick="btnSearch_Click" />
            </div>
        </div>
    </div>
        <div class="grid">
            <div class="search-box">
                <asp:TextBox ID="txtSearch" Width="250px" Text="" runat="server" AutoPostBack="True" OnTextChanged="txtSearch_TextChanged"
                    Height="18px"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="" />
            </div>
            <input type="hidden" id="radGridClickedRowIndex" name="radGridClickedRowIndex" />
            <input type="hidden" id="radGridSelectedRowIndex" name="radGridSelectedRowIndex" />
            <input type="hidden" id="confirmdelete" name="confirmdelete" />
            <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
                <script type="text/javascript">
                    function RowGridSelected(sender, args) {
                        key = args.getDataKeyValue("DocumentID");
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
                    $(document).ready(function () {
                        UpdatePosition("DocumentID", "Document", "<%=rgManager.ClientID %>");
                    });

                </script>
            </telerik:RadCodeBlock>
            <telerik:RadAjaxLoadingPanel ID="rgManagerLoading" runat="server" Transparency="25">
                <center>
                    <table width="100%">
                        <tr>
                            <td>
                                <img alt="Loading..." style="margin-top: 80px" src='<%=Page.ResolveUrl("~/admin/styles/img/loading_bicweb_150x29.gif")%>' style="border: 0;" />
                            </td>
                        </tr>
                    </table>
                </center>
            </telerik:RadAjaxLoadingPanel>
            <telerik:RadGrid ID="rgManager" EnableEmbeddedSkins="false" Skin="BICCMS" runat="server" HeaderStyle-CssClass="rgHeader rgHeaderCenter"
                AllowPaging="True" PageSize="10" AllowSorting="False" AllowCustomPaging="True" AllowAutomaticDeletes="true" ShowHeader="true"
                AutoGenerateColumns="False" AllowMultiRowSelection="true" OnNeedDataSource="rgManager_NeedDataSource" GridLines="None"
                OnDeleteCommand="rgManager_DeleteCommand" OnItemCommand="rgManager_ItemCommand" OnItemDataBound="rgManager_ItemDataBound">
                <MasterTableView TableLayout="Fixed" NoMasterRecordsText="Kh&ocirc;ng c&oacute; d&#7919; li&#7879;u..." DataKeyNames="DocumentID"
                    CommandItemDisplay="Top">
                    <CommandItemTemplate>
                        <asp:LinkButton ID="lbtnDeleteSelected" Visible="<%#Deleted%>" CssClass="btn-del" OnClientClick="javascript:return confirm('B&#7841;n ch&#7855;c ch&#7855;n mu&#7889;n x&oacute;a c&aacute;c b&#7843;n ghi &#273;&atilde; ch&#7885;n?')"
                            runat="server" CommandName="DeleteSelected" Text="<%$Resources:Admin,Admin_DeleteAll%>"></asp:LinkButton>
                        <a href='<%#BicAdmin.UrlAdd()%>' class="btn-addnew" visible="<%#Added%>"> <%=BicResource.GetValue("Admin","System_Add") %></a>
                    </CommandItemTemplate>
                    <Columns>
                        <telerik:GridClientSelectColumn UniqueName="column" HeaderStyle-Width="30px" ItemStyle-CssClass="center">
                        </telerik:GridClientSelectColumn>
                        <telerik:GridTemplateColumn HeaderText="STT" HeaderStyle-Width="30px" ItemStyle-CssClass="center">
                            <ItemTemplate>
                                <%#Container.DataSetIndex + 1%>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn HeaderText="Tiêu đề" DataField="DisplayName" HeaderStyle-Width="300" />
                        <telerik:GridBoundColumn HeaderText="Lượt xem" DataField="ViewNo" HeaderStyle-Width="60" ItemStyle-CssClass="center" />
                        <telerik:GridBoundColumn HeaderText="Trích yếu" DataField="BriefDescription" />
                      <%--  <telerik:GridTemplateColumn HeaderText="Thứ tự" HeaderStyle-Width="110px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:DropDownList runat="server" ID="ddlCurrentPosition" Width="45px" ClientIDMode="Static" CssClass='<%#Eval("DocumentID") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </telerik:GridTemplateColumn>--%>
                        <telerik:GridTemplateColumn HeaderText="Duyệt" ItemStyle-CssClass="center" HeaderStyle-Width="40">
                            <ItemTemplate>
                                <asp:ImageButton ID="ibtnIsActive" Enabled='<%#Approved%>' BorderWidth="0px" CommandName="IsActive" CommandArgument='<%#Eval("IsActive") %>'
                                    ImageUrl='<%# Convert.ToBoolean(DataBinder.Eval(Container.DataItem, "IsActive"))? "~/Admin/Styles/Icon/checkmark.gif" : "~/Admin/Styles/Icon/uncheckmark.gif" %>'
                                    Style="cursor: pointer;" runat="server"></asp:ImageButton>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                    </Columns>
                </MasterTableView>
                <SortingSettings SortedAscToolTip="S&#7855;p x&#7871;p t&#259;ng d&#7847;n" SortedDescToolTip="S&#7855;p x&#7871;p gi&#7843;m d&#7847;n"
                    SortToolTip="S&#7855;p x&#7871;p d&#7919; li&#7879;u" />
                <ClientSettings>
                    <Selecting AllowRowSelect="True" EnableDragToSelectRows="true" />
                    <Scrolling AllowScroll="false" UseStaticHeaders="true" SaveScrollPosition="true" />
                    <ClientEvents OnRowContextMenu="RowContextMenu" />
                </ClientSettings>
                <PagerStyle PagerTextFormat="Chuyển trang: {4} &amp;nbsp;Từ &lt;strong&gt;{2}&lt;/strong&gt; tới &lt;strong&gt;{3}&lt;/strong&gt; trong &lt;strong&gt;{5}&lt;/strong&gt; bản ghi"
                    FirstPageToolTip="Trang đầu" LastPageToolTip="Trang cuối" NextPagesToolTip="Các trang sau" NextPageToolTip="Trang sau"
                    PageSizeLabelText="Số trang:" PrevPagesToolTip="Các trang trước" PrevPageToolTip="Trang trước" />
            </telerik:RadGrid>
        </div>
    </telerik:RadAjaxPanel>
</telerik:RadCodeBlock>
<telerik:RadAjaxLoadingPanel runat="server" Skin="Windows7" ID="RadAjaxLoadingPanel1" BackgroundPosition="Center" EnableSkinTransparency="true">
</telerik:RadAjaxLoadingPanel>
<telerik:RadContextMenu ID="radMenuContext" runat="server" OnItemClick="radMenuContext_ItemClick" EnableRoundedCorners="true"
    EnableShadows="true" Skin="WebBlue">
</telerik:RadContextMenu>