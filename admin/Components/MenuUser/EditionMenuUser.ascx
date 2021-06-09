<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditionMenuUser.ascx.cs" Inherits="admin_Components_MenuAdmin_EditionMenuUser" %>
<%@ Import Namespace="BIC.Utils" %>
<%@ Register Src="TreeviewMenuUser.ascx" TagName="TreeviewMenuUser" TagPrefix="uc1" %>
<%@ Register Src="~/admin/Components/ImageGallery/ImageSelector.ascx" TagName="ImageSelector" TagPrefix="bic" %>
<%@ Register Src="../ImageGallery/ImageSelectMulti.ascx" TagName="ImageSelectMulti" TagPrefix="uc1" %>
<div id="divUser" title="Chọn tài khoản" class="hidden">
    <iframe id="ifSelectUser" width="100%" height="100%" marginwidth="0" marginheight="0" frameborder="0" scrolling="no" title="Dialog Title">Your browser does
        not support</iframe>
</div>
<telerik:RadCodeBlock runat="server">
    <script type="text/javascript">
        function SelectPermission(txt) {
            var $dialog = $.FrameDialog.create({
                url: '<%= Page.ResolveUrl("~/admin/Components/Security/User/SelectUsers.aspx") %>',
                loadingClass: 'loading-image',
                title: 'Phân quyền cho nhóm tài khoản, tài khoản',
                width: 600,
                height: 430,
                autoOpen: false,
                resizable: false
            })
                .bind('dialogclose', function (event, ui) { users = event.result; $(txt).val(users); }); $dialog.dialog('open');
        }
        function BindDialogUser() {
            $(function () {
                $('[id$="txtUserName"]').click(function () { SelectPermission(this); }); $("#divUser").dialog({
                    autoOpen: false,
                    modal: true,
                    height: 420,
                    width: 603,
                    resizable: false
                });
            });
        }

        $(document).ready(function () { BindDialogUser(); Scroll($("#content1"), $("#slider1")); Scroll($("#content1"), $("#slider2")); });
        function nodeClicking(sender, args) { var comboBox = $find("<%= rcbMenuUser.ClientID %>"); var node = args.get_node(); comboBox.set_text(node.get_text()); comboBox.trackChanges(); comboBox.get_items().getItem(0).set_text(node.get_text()); comboBox.commitChanges(); comboBox.hideDropDown(); }

        function StopPropagation(e) { if (!e) { e = window.event; } e.cancelBubble = true; }

        function OnClientDropDownOpenedHandler(sender, eventArgs) { var tree = sender.get_items().getItem(0).findControl("tvParentId"); var selectedNode = tree.get_selectedNode(); if (selectedNode) { selectedNode.scrollIntoView(); } }
    </script>
</telerik:RadCodeBlock>
<telerik:RadAjaxManager runat="Server" ID="RadManager">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="ddlFrameViewID">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="txtUrl" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>
<telerik:RadAjaxLoadingPanel runat="server" Skin="Windows7" ID="RadAjaxLoadingPanel1" BackgroundPosition="Center" EnableSkinTransparency="true">
</telerik:RadAjaxLoadingPanel>
<div class="input-box">
    <div class="item first">
        <div class="label">
            <telerik:RadCodeBlock ID="RadCodeBlock2" runat="server">
                <%=BicResource.GetValue("Admin", "System_Language") %>
            </telerik:RadCodeBlock>
        </div>
        <div class="input">
            <bic:Language ID="ddlLanguage" runat="server" AutoPostBack="True" CssClass="input-select" OnSelectedIndexChanged="ddlLanguage_SelectedIndexChanged" />
        </div>
    </div>
    <div class="item last">
        <div class="label">
            <telerik:RadCodeBlock ID="RadCodeBlock3" runat="server">
                <%=BicResource.GetValue("Admin", "Admin_MenuUser_ModelMenu") %>
            </telerik:RadCodeBlock>
        </div>
        <div class="input">
            <asp:DropDownList runat="server" ID="ddlModelMenu" AutoPostBack="True" CssClass="input-select" OnSelectedIndexChanged="ddlModelMenu_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
    </div>
</div>
<div class="form-tool">
    <bic:ToolBar ID="tbTop" runat="server" />
    <asp:LinkButton ID="lbtnSave" CssClass="btn-save" runat="server" OnCommand="Save" ValidationGroup="admin" CommandName="Edit">

        <telerik:RadCodeBlock ID="RadCodeBlock19" runat="server">
            <%=BicResource.GetValue("Admin", "Admin_MenuUser_Save") %>
        </telerik:RadCodeBlock>
    </asp:LinkButton>
</div>
<div class="form-caption">
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <%= BicMessage.UpdateTitle %>
        <span class="note"><em>*</em>
            <%= BicMessage.RequireTitle %></span>
    </telerik:RadCodeBlock>
</div>
<div class="form-view-tree">
    <div class="main-wrapp">
        <div class="main">
            <div class="form-view f2">
                <div class="frow">
                    <div class="label">
                        <telerik:RadCodeBlock ID="RadCodeBlock4" runat="server">
                            <%=BicResource.GetValue("Admin", "Admin_MenuUser_Title") %>
                        </telerik:RadCodeBlock>
                        <span class="validate">*</span>
                    </div>
                    <div class="input">
                        <asp:TextBox type="text" runat="server" ID="txtName" Width="98%" />
                    </div>
                </div>
                <div class="frow">
                    <div class="label">
                        <telerik:RadCodeBlock ID="RadCodeBlock5" runat="server">
                            <%=BicResource.GetValue("Admin", "Admin_MenuUser_Function") %>
                        </telerik:RadCodeBlock>
                    </div>
                    <div class="input">
                        <asp:DropDownList ID="ddlFrameViewID" class="input-select w1" runat="server" CausesValidation="false" AutoPostBack="True" OnSelectedIndexChanged="ddlFrameViewID_SelectedIndexChanged" />
                    </div>
                </div>
                <telerik:RadCodeBlock ID="RadCodeBlock26" runat="server">
                    <div class="frow alt <%=BicXML.ToBoolean("EnableRefrenceMenu","SettingMenuUser") == false? "hidden" : "" %>">
                        <div class="label">
                            <telerik:RadCodeBlock ID="RadCodeBlock20" runat="server">
                                <%=BicResource.GetValue("Admin","Admin_MenuUser_Connection")%>
                            </telerik:RadCodeBlock>
                        </div>
                        <div class="input">
                            <asp:DropDownList runat="server" ID="ddlRefrenceMenu" DataValueField="key" DataTextField="name" CssClass="input-select">
                            </asp:DropDownList>
                        </div>
                    </div>
                </telerik:RadCodeBlock>
                <div class="frow">
                    <div class="label">
                        <telerik:RadCodeBlock ID="RadCodeBlock6" runat="server">
                            <%=BicResource.GetValue("Admin", "Admin_MenuUser_ParentCategories") %>
                        </telerik:RadCodeBlock>
                    </div>
                    <div class="input">
                        <asp:Label runat="server" ID="lblParentId" /><asp:HiddenField runat="server" ID="hfParentId" />
                        <telerik:RadComboBox runat="server" ID="rcbMenuUser" Width="250px" DataValueField="MenuUserID" DataTextField="Name" HighlightTemplatedItems="true" OnClientDropDownOpened="OnClientDropDownOpenedHandler"
                            Skin="Web20" EmptyMessage="<%$Resources:Admin, Admin_MenuUser_OriginalList %>" Visible="False">
                            <ItemTemplate>
                                <div id="div1">
                                    <telerik:RadTreeView runat="server" OnClientNodeClicking="nodeClicking" Skin="Outlook" ID="tvParentId">
                                    </telerik:RadTreeView>
                                </div>
                            </ItemTemplate>
                            <Items>
                                <telerik:RadComboBoxItem Text="" />
                            </Items>
                        </telerik:RadComboBox>
                    </div>
                </div>
                <div class="frow">
                    <div class="label">
                        <telerik:RadCodeBlock ID="RadCodeBlock7" runat="server">
                            <%=BicResource.GetValue("Admin", "Admin_MenuUser_Link") %>
                        </telerik:RadCodeBlock>
                    </div>
                    <div class="input">
                        <asp:TextBox type="text" runat="server" ID="txtUrl" ClientIDMode="Static" class="input-text" Width="260px" />
                    </div>
                </div>

                <div class="frow">
                    <div class="label">
                        <telerik:RadCodeBlock ID="RadCodeBlock9" runat="server">
                            <%=BicResource.GetValue("Admin", "System_OtherInformation") %>
                        </telerik:RadCodeBlock>
                    </div>
                    <div class="input group-item">
                        <telerik:RadCodeBlock ID="RadCodeBlock24" runat="server">
                            <div class="col first selector-image  <%=BicXML.ToBoolean("EnableImageDescription","SettingMenuUser") == false? "hidden" : "" %>">
                                <div class="title arrow">
                                    <telerik:RadCodeBlock ID="RadCodeBlock10" runat="server">
                                        <%=BicResource.GetValue("Admin", "Admin_MenuUser_ImageDescription") %>
                                    </telerik:RadCodeBlock>
                                </div>
                                <bic:ImageSelector ID="isImageID" runat="server" />
                            </div>
                        </telerik:RadCodeBlock>
                        <div class="col c1">
                            <div class="line" runat="server" clientidmode="Static" visible="false">
                                <div class="label">
                                    <a href="#">
                                        <telerik:RadCodeBlock ID="RadCodeBlock11" runat="server">
                                            <%=BicResource.GetValue("Admin", "System_New") %>
                                        </telerik:RadCodeBlock>

                                    </a>
                                </div>
                                <div class="input">
                                    <asp:CheckBox runat="server" ID="chkIsNew" />
                                </div>
                            </div>
                            <div class="line">
                                <div class="label">
                                    <a href="#">
                                        <telerik:RadCodeBlock ID="RadCodeBlock12" runat="server">
                                            <%=BicResource.GetValue("Admin", "System_Browse") %>
                                        </telerik:RadCodeBlock>
                                    </a>
                                </div>
                                <div class="input">
                                    <asp:CheckBox runat="server" ID="chkIsActive" Checked="true" />
                                </div>
                            </div>
                            <div class="line hidden">
                                <div class="label">
                                    <a href="#">
                                        <telerik:RadCodeBlock ID="RadCodeBlock21" runat="server">
                                            <%=BicResource.GetValue("Admin","Admin_MenuUser_ExclusiveSiteMap") %>
                                        </telerik:RadCodeBlock>
                                    </a>
                                </div>
                                <div class="input">
                                    <asp:CheckBox runat="server" ID="chkExclusiveSiteMap" Checked="true" />
                                </div>
                            </div>
                            <div class="line hidden">
                                <div class="label">
                                    <a href="#">
                                        <telerik:RadCodeBlock ID="RadCodeBlock22" runat="server">
                                            <%=BicResource.GetValue("Admin","Admin_MenuUser_ExclusiveNavigatePath") %>
                                        </telerik:RadCodeBlock>
                                    </a>
                                </div>
                                <div class="input">
                                    <asp:CheckBox runat="server" ID="chkExclusiveNavigatePath" Checked="true" />
                                </div>
                            </div>
                            <div class="line hidden">
                                <div class="label">
                                    <a href="#">
                                        <telerik:RadCodeBlock ID="RadCodeBlock23" runat="server">
                                            <%=BicResource.GetValue("Admin","Admin_MenuUser_ExclusiveMenu") %>
                                        </telerik:RadCodeBlock>
                                    </a>
                                </div>
                                <div class="input">
                                    <asp:CheckBox runat="server" ID="chkExclusiveMenu" Checked="true" />
                                </div>
                            </div>
                            <telerik:RadCodeBlock ID="RadCodeBlock25" runat="server">
                                <div class="line <%=BicXML.ToBoolean("EnableRequireLogin","SettingMenuUser") == false? "hidden" : "" %>" clientidmode="Static">
                                    <div class="label">
                                        <a href="#">
                                            <telerik:RadCodeBlock ID="RadCodeBlock13" runat="server">
                                                <%=BicResource.GetValue("Admin", "Admin_MenuUser_LoginRequired") %>
                                            </telerik:RadCodeBlock>
                                        </a>
                                    </div>
                                    <div class="input">
                                        <asp:CheckBox runat="server" ID="chkRequireLogin" Checked="true" />
                                    </div>
                                </div>
                            </telerik:RadCodeBlock>
                        </div>
                        <div class="col c1">
                            <div class="line">
                                <div class="label" title="Số bản ghi/trang dữ liệu">
                                    <a href="#">
                                        <telerik:RadCodeBlock ID="RadCodeBlock14" runat="server">
                                            <%=BicResource.GetValue("Admin", "Admin_MenuUser_Pagesize") %>
                                        </telerik:RadCodeBlock>
                                    </a>
                                </div>
                                <div class="input">
                                    <asp:TextBox runat="server" ID="txtPageSize" Width="80px" />
                                </div>
                            </div>
                            <div class="line" runat="server" clientidmode="Static" visible="false">
                                <div class="label">
                                    <a href="#">
                                        <telerik:RadCodeBlock ID="RadCodeBlock15" runat="server">
                                            <%=BicResource.GetValue("Admin", "System_Account") %>
                                        </telerik:RadCodeBlock>
                                    </a>
                                </div>
                                <div class="input">
                                    <input type="text" runat="server" id="txtUserName" class="input-text" />
                                </div>
                            </div>
                            <div class="line">
                                <div class="label">
                                    <a href="#">
                                        <telerik:RadCodeBlock ID="RadCodeBlock16" runat="server">
                                            <%=BicResource.GetValue("Admin", "System_Target") %>
                                        </telerik:RadCodeBlock>
                                    </a>
                                </div>
                                <div class="input">
                                    <bic:Target runat="server" ID="ddlTarget" CssClass="input-select">
                                    </bic:Target>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <telerik:RadCodeBlock ID="RadCodeBlock27" runat="server">
                    <div id="ArrayImage " class="frow alt <%=BicXML.ToBoolean("EnableArrayImage","SettingMenuUser") == false? "hidden" : "" %>">
                        <div class="label">
                            Bộ ảnh
                        </div>
                        <div class="input group-item" style="height: 125px">
                            <div>
                                <uc1:ImageSelectMulti ID="ismImageId" runat="server" />
                            </div>
                        </div>
                    </div>
                </telerik:RadCodeBlock>
                <telerik:RadCodeBlock ID="RadCodeBlock28" runat="server">
                    <div class="frow">
                        <div class="label">
                            <telerik:RadCodeBlock ID="RadCodeBlock17" runat="server">
                                <%=BicResource.GetValue("Admin","System_Description") %>
                            </telerik:RadCodeBlock>
                        </div>
                        <div class="input">
                            <telerik:RadCodeBlock runat="server" ID="radCode2">
                                <%= IncludeAdmin.RadEditor() %>
                            </telerik:RadCodeBlock>
                            <bic:Editor Height="500px" EnableResize="True" ID="reDescription" Width="100%" ToolsFile="~/admin/XMLData/Editor/MenuFullTools.xml"
                                ContentFilters="None" runat="server" StripFormattingOnPaste="NoneSupressCleanMessage, MSWord, MSWordNoFonts"
                                ToolbarMode="Default" Skin="Office2007" />
                        </div>
                    </div>
                </telerik:RadCodeBlock>
                <div class="frow alt">
                    <div class="label">
                        <telerik:RadCodeBlock ID="RadCodeBlock31" runat="server">
                            <%=BicResource.GetValue("Admin","System_PageTitle") %>
                        </telerik:RadCodeBlock>
                        <%--<span class="validate">*</span>--%>
                    </div>
                    <div class="input">
                        <asp:TextBox type="text" runat="server" ID="txtPageTitle" class="input-text" Width="85%" />
                        (Max 100)
                    </div>
                </div>
                <div class="frow alt">
                    <div class="label">
                        <telerik:RadCodeBlock ID="RadCodeBlock8" runat="server">
                            <%=BicResource.GetValue("Admin","System_UrlSEO") %>
                        </telerik:RadCodeBlock>
                        <span class="validate">*</span>
                    </div>
                    <div class="input">
                        <asp:TextBox type="text" runat="server" ID="txtSEOTitle" class="input-text" Width="85%" />
                        (Max 100)
                    </div>
                </div>
                <div class="frow ">
                    <div class="label">
                        <telerik:RadCodeBlock ID="RadCodeBlock29" runat="server">
                            <%=BicResource.GetValue("Admin","System_MetaDescription") %>
                        </telerik:RadCodeBlock>
                    </div>
                    <div class="input">
                        <asp:TextBox runat="server" ID="txtMetaDescription" CssClass="input-text" Width="85%" MaxLength="170" />
                        (Max 170)
                    </div>
                </div>
                <div class="frow alt">
                    <div class="label">
                        <telerik:RadCodeBlock ID="RadCodeBlock30" runat="server">
                            <%=BicResource.GetValue("Admin","System_MetaKeyword") %>
                        </telerik:RadCodeBlock>
                    </div>
                    <div class="input">
                        <asp:TextBox runat="server" ID="txtMetaKeyword" CssClass="input-text" Width="85%" MaxLength="170" />
                        (Max 170)
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="side-wrapp">
        <div class="slider-wrapper-top">
            <div class="content-slider" id="slider2">
            </div>
        </div>
        <div class="side" id="content1">
            <uc1:TreeviewMenuUser ID="tvMenuUser" runat="server" />
        </div>
        <div class="slider-wrapper">
            <div class="content-slider" id="slider1">
            </div>
        </div>
    </div>
</div>
<div class="form-tool-bottom">
    <bic:ToolBar ID="tbBottom" runat="server" />
    <asp:LinkButton ID="lbtnSave2" CssClass="btn-save" runat="server" OnCommand="Save" CommandName="Edit">

        <telerik:RadCodeBlock ID="RadCodeBlock18" runat="server">
            <%=BicResource.GetValue("Admin", "Admin_MenuUser_Save") %>
        </telerik:RadCodeBlock>
    </asp:LinkButton>
</div>
<telerik:RadInputManager runat="server" ID="rim1" EnableEmbeddedSkins="false" Skin="BICCMS">
    <telerik:TextBoxSetting BehaviorID="bhName" EmptyMessage="<%$Resources:Admin, System_InputCategoryName%>" Validation-IsRequired="true" Validation-ValidationGroup="admin">
        <TargetControls>
            <telerik:TargetInput ControlID="txtName" />
        </TargetControls>
    </telerik:TextBoxSetting>
    <telerik:NumericTextBoxSetting BehaviorID="bhPageSize" Type="Number" DecimalDigits="0">
        <TargetControls>
            <telerik:TargetInput ControlID="txtPageSize" />
        </TargetControls>
    </telerik:NumericTextBoxSetting>
</telerik:RadInputManager>
<telerik:RadCodeBlock ID="RadCodeBlock" runat="server">
    <script>
        $(document).ready(function () {
            $("#<%= chkIsActive.ClientID%>").bind("click", function () {
                var i = $("#<%= chkIsActive.ClientID%>").is(':checked');
                if (i == false) {
                    alert('<%= BicResource.GetValue("Admin", "Admin_MenuUser_DeActive_Menu_Message") %>');
                }
            });
        });
    </script>
</telerik:RadCodeBlock>
