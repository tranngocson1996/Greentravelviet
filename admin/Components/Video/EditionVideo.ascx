<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditionVideo.ascx.cs" Inherits="Admin_Components_Article_EditionArticle" %>
<%@ Import Namespace="BIC.Utils" %>
<%@ Register Src="~/admin/Components/ImageGallery/ImageSelector.ascx" TagName="ImageSelector" TagPrefix="bic" %>
<%@ Register TagPrefix="uc1" TagName="ImageSelectMulti" Src="~/admin/Components/ImageGallery/ImageSelectMulti.ascx" %>
<%@ Register TagPrefix="bic" TagName="VideoSelector" Src="~/admin/Components/Video/VideoSelector.ascx" %>
<%@ Register TagPrefix="uc2" TagName="relatedarticle" Src="~/admin/Components/Article/RelatedArticle.ascx" %>
<%@ Register Src="~/admin/Components/Article/CommentArticle.ascx" TagName="CommentArticle" TagPrefix="uc3" %>
<div class="form-tool">
    <bic:ToolBar ID="tbTop" runat="server" />
    <asp:LinkButton ID="lbtnSave" CssClass="btn-save" runat="server" OnCommand="Save" CommandName="Update">
        <telerik:RadCodeBlock ID="RadCodeBlock33" runat="server">
            <%=BicResource.GetValue("Admin","Admin_Save") %>
        </telerik:RadCodeBlock>
    </asp:LinkButton>
</div>
<style>
    .pager .num {
        padding: 0 3px;
    }

        .pager .num.select {
            font-size: 14px;
            font-weight: bold;
        }
</style>
<telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
    <div class="form-caption">
        <%= BicMessage.InsertTitle %>
        <span class="note"><em>*</em>
            <%= BicMessage.RequireTitle %></span>
    </div>
</telerik:RadCodeBlock>
<div class="form-view">
    <div class="frow alt">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock4" runat="server">
                    <%=BicResource.GetValue("Admin","Admin_AdminLanguege_Language") %>
                </telerik:RadCodeBlock>
            </div>
            <div class="input">
                <bic:Language ID="ddlLanguage" runat="server" Width="200px" CssClass="input-select"
                    AutoPostBack="true" OnSelectedIndexChanged="ddlLanguage_SelectedIndexChanged">
                </bic:Language>
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock5" runat="server">
                    <%=BicResource.GetValue("Admin","Admin_Article_List") %>
                </telerik:RadCodeBlock>
            </div>
            <div class="input">
                <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
                    <script type="text/javascript">
                        $(document).ready(function () { $.ajax({ type: "POST", url: getBaseURL() + 'admin/Service/ListMenu.ashx?menuid=' + $("#hdTreeMenu").val(), success: function (mess) { $(".menuchoice").html(""); $(".menuchoice").html(mess); }, error: function (errormessage) { alert("Chắc năng này đang được nâng cấp"); } }); $(".menuchoice").ajaxComplete(function (event, request, settings) { $("#MenuDrop li").hover(function () { $("#MenuDrop li").removeClass("hovermenu"); $(this).addClass("hovermenu"); }, function () { $("#MenuDrop li").removeClass("hovermenu"); }); $("#MenuDrop").sortable({ revert: true, stop: function (event, ui) { var s = ""; $("#MenuDrop li").each(function () { s += "," + $.trim($(this).attr("id")); }); $("#hdTreeMenu").val(s); } }); }); });
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

                            $.ajax({ type: "POST", url: getBaseURL() + 'admin/Service/ListMenu.ashx?menuid=' + $("#hdTreeMenu").val(), success: function (mess) { $(".menuchoice").html(""); $(".menuchoice").html(mess); }, error: function (errormessage) { alert("Chắc năng này đang được nâng cấp"); } }); $(".menuchoice").ajaxComplete(function (event, request, settings) { $("#MenuDrop li").hover(function () { $("#MenuDrop li").removeClass("hovermenu"); $(this).addClass("hovermenu"); }, function () { $("#MenuDrop li").removeClass("hovermenu"); }); $("#MenuDrop").sortable({ revert: true, stop: function (event, ui) { var s = ""; $("#MenuDrop li").each(function () { s += "," + $.trim($(this).attr("id")); }); $("#hdTreeMenu").val(s); } }); });
                        }</script>
                </telerik:RadScriptBlock>
                <asp:HiddenField ID="hdTreeMenu" runat="server" ClientIDMode="Static" />
                <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                    <div class="cot-tree">
                        <telerik:RadTreeView runat="server" Skin="Outlook" Width="250px" OnClientNodeChecked="ClientNodeChecked" CheckBoxes="true" ID="tvMenuUser" PersistLoadOnDemandNodes="true" LoadingStatusPosition="AfterNodeText" CollapseAnimation-Duration="0" ExpandAnimation-Duration="0" ExpandAnimation-Type="none">
                        </telerik:RadTreeView>
                    </div>
                    <div class="cot-tree">
                        <telerik:RadTreeView runat="server" Skin="Outlook" Width="250px" OnClientNodeChecked="ClientNodeChecked" CheckBoxes="true" ID="RadTreeView1" PersistLoadOnDemandNodes="true" LoadingStatusPosition="AfterNodeText" CollapseAnimation-Duration="0" ExpandAnimation-Duration="0" ExpandAnimation-Type="none">
                        </telerik:RadTreeView>
                    </div>
                    <div class="cot-tree">
                        <telerik:RadTreeView runat="server" Skin="Outlook" Width="250px" OnClientNodeChecked="ClientNodeChecked" CheckBoxes="true" ID="RadTreeView2" PersistLoadOnDemandNodes="true" LoadingStatusPosition="AfterNodeText" CollapseAnimation-Duration="0" ExpandAnimation-Duration="0" ExpandAnimation-Type="none">
                        </telerik:RadTreeView>
                    </div>
                </telerik:RadAjaxPanel>
            </div>
        </div>
    </div>
    <div class="frow alt">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock2" runat="server">
                    <%=BicResource.GetValue("Admin","Admin_Article_ListOfSelected") %>
                </telerik:RadCodeBlock>
            </div>
            <div class="input">
                <div class="menuchoice">
                    <telerik:RadCodeBlock ID="RadCodeBlock3" runat="server">
                        <%=BicResource.GetValue("Admin","Admin_Article_NoItemsSelected") %>
                    </telerik:RadCodeBlock>
                </div>
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock6" runat="server">
                    <%=BicResource.GetValue("Admin","Admin_Article_Title2") %>
                </telerik:RadCodeBlock>
                <span class="validate">*</span>
            </div>
            <div class="input">
                <asp:TextBox ID="txtTitle" runat="server" CssClass="input-text" MaxLength="180" Width="85%" />
                (Max 180)
            </div>
        </div>
    </div>
    <div class="frow alt">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock7" runat="server">
                    <%=BicResource.GetValue("Admin","System_OtherInformation") %>
                </telerik:RadCodeBlock>
            </div>
            <div class="input group-item">
                <div class="col first selector-image">
                    <div class="title arrow">
                        <telerik:RadCodeBlock ID="RadCodeBlock8" runat="server">
                            <%=BicResource.GetValue("Admin","Admin_Article_ImageDescription") %>
                        </telerik:RadCodeBlock>
                    </div>
                    <bic:ImageSelector ID="isImageId" runat="server" />
                </div>
                <script type="text/javascript">
                    $(document).ready(function () { $("#ddlTypeNews").live("change", function () { if ($(this).val() == 2) { $("#ArrayImage").show(); $("#Video").hide(); } if ($(this).val() == 3) { $("#Video").show(); $("#ArrayImage").hide(); } if ($(this).val() == 1 || $(this).val() == 4) { $("#Video").hide(); $("#ArrayImage").hide(); } }); });
                </script>
                <div class="col first selector-image">
                    <div class="title arrow">
                        <telerik:RadCodeBlock ID="RadCodeBlock9" runat="server">
                            <%=BicResource.GetValue("Admin","Admin_Article_Video") %>
                        </telerik:RadCodeBlock>
                    </div>
                    <bic:VideoSelector ID="isVideoID" runat="server" />
                </div>
                <div class="col c1">
                    <div class="line">
                        <div class="label arrow">
                            <telerik:RadCodeBlock ID="RadCodeBlock10" runat="server">
                                <%=BicResource.GetValue("Admin","System_New") %>
                            </telerik:RadCodeBlock>
                        </div>
                        <div class="input">
                            <asp:CheckBox runat="server" ID="chkNew" />
                        </div>
                    </div>
                    <div class="line">
                        <div class="label arrow">
                            <telerik:RadCodeBlock ID="RadCodeBlock11" runat="server">
                                <%=BicResource.GetValue("Admin","System_Browse") %>
                            </telerik:RadCodeBlock>
                        </div>
                        <div class="input">
                            <asp:CheckBox runat="server" Enable="<%# Approved %>" ID="chkIsActive" />
                        </div>
                    </div>
                    <div class="line">
                        <div class="label arrow">
                            <telerik:RadCodeBlock ID="RadCodeBlock12" runat="server">
                                <%=BicResource.GetValue("Admin","System_Target") %>
                            </telerik:RadCodeBlock>
                        </div>
                        <div class="input">
                            <bic:Target runat="server" ID="cbTarget" CssClass="input-select">
                            </bic:Target>
                        </div>
                    </div>

                </div>
                <div class="col c2">
                    <div class="line hidden">
                        <div class="label arrow">
                            <telerik:RadCodeBlock ID="RadCodeBlock13" runat="server">
                                <%=BicResource.GetValue("Admin","Admin_Article_AppearComment") %>
                            </telerik:RadCodeBlock>
                        </div>
                        <div class="input">
                            <asp:CheckBox runat="server" Checked="false" ID="chkCommentEnable" />
                        </div>
                    </div>
                    <div class="line hidden">
                        <div class="label arrow">
                            <telerik:RadCodeBlock ID="RadCodeBlock14" runat="server">
                                <%=BicResource.GetValue("Admin","System_FullScreen") %>
                            </telerik:RadCodeBlock>
                        </div>
                        <div class="input">
                            <asp:CheckBox runat="server" ID="chkIsFull" />
                        </div>
                    </div>
                    <div class="line hidden">
                        <div class="label arrow">
                            <telerik:RadCodeBlock ID="RadCodeBlock15" runat="server">
                                <%=BicResource.GetValue("Admin","Admin_Article_Views2") %>
                            </telerik:RadCodeBlock>
                        </div>
                        <div class="input">
                            <asp:TextBox runat="server" ID="txtViewCount" CssClass="input-text" Width="116px"
                                Text="1" />
                        </div>
                    </div>
                    <div class="line hidden">
                        <div class="label arrow">
                            <telerik:RadCodeBlock ID="RadCodeBlock16" runat="server">
                                <%=BicResource.GetValue("Admin","System_Source") %>
                            </telerik:RadCodeBlock>
                        </div>
                        <div class="input">
                            <asp:TextBox runat="server" ID="txtSource" CssClass="input-text" Width="108px" />
                        </div>
                    </div>

                    <div class="line hidden">
                        <div class="label arrow">
                            <telerik:RadCodeBlock ID="RadCodeBlock17" runat="server">
                                <%=BicResource.GetValue("Admin","Admin_Article_NewsFocus") %>
                            </telerik:RadCodeBlock>
                        </div>
                        <div class="input">
                            <asp:DropDownList ID="ddlTintieudiem" runat="server" Width="120" />
                        </div>
                    </div>
                    <div class="line hidden">
                        <div class="label arrow">
                            <telerik:RadCodeBlock ID="RadCodeBlock18" runat="server">
                                <%=BicResource.GetValue("Admin","Admin_Article_TypeOfNews") %>
                            </telerik:RadCodeBlock>
                        </div>
                        <div class="input">
                            <asp:DropDownList ID="ddlTypeNews" runat="server" Width="120" ClientIDMode="Static" />
                        </div>
                    </div>
                    <div class="line hidden">
                        <div class="label arrow">
                            <telerik:RadCodeBlock ID="RadCodeBlock19" runat="server">
                                <%=BicResource.GetValue("Admin","Admin_Article_Votes") %>
                            </telerik:RadCodeBlock>
                        </div>
                        <div class="input">
                            <asp:TextBox runat="server" ID="txtVote" CssClass="input-text" Width="108px"></asp:TextBox>
                        </div>
                    </div>

                    <div class="line">
                        <div class="label arrow">
                            <telerik:RadCodeBlock ID="RadCodeBlock20" runat="server">
                                <%=BicResource.GetValue("Admin","Admin_Article_Order") %>
                            </telerik:RadCodeBlock>
                        </div>
                        <div class="input">
                            <telerik:RadNumericTextBox ShowSpinButtons="true" IncrementSettings-InterceptArrowKeys="true"
                                IncrementSettings-InterceptMouseWheel="true" Value="1" LabelWidth="" runat="server"
                                ID="ntxPosition" Width="120px" DataType="System.Int64" MinValue="1">
                                <NumberFormat ZeroPattern="n" AllowRounding="False"></NumberFormat>
                            </telerik:RadNumericTextBox>
                        </div>
                    </div>
                    <asp:Label runat="server" ID="lblPriority" Visible="false" />
                    <div class="line hidden">
                        <div class="label arrow">
                            <telerik:RadCodeBlock ID="RadCodeBlock21" runat="server">
                                <%=BicResource.GetValue("Admin","Admin_Article_Home") %>
                            </telerik:RadCodeBlock>
                        </div>
                        <div class="input">
                            <asp:CheckBox runat="server" ID="chkIsHome" />
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock36" runat="server">
                    <%=BicResource.GetValue("Admin","Admin_Article_Link") %>
                </telerik:RadCodeBlock>
            </div>
            <div class="input">
                <div>
                    <asp:TextBox runat="server" ID="txtLink" CssClass="input-text" MaxLength="180" Width="85%" />
                    (Max 250)
                </div>
            </div>
        </div>
    </div>
    <div id="ArrayImage"  class="frow hidden">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock22" runat="server">
                    <%=BicResource.GetValue("Admin","Admin_Article_Images") %>
                </telerik:RadCodeBlock>
            </div>
            <div class="input group-item">
                <div>
                    <uc1:ImageSelectMulti ID="ismImageId" runat="server" />
                </div>
            </div>
        </div>
    </div>
    <div class="frow alt hidden">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock28" runat="server">
                    <%=BicResource.GetValue("Admin","Admin_Menu_QuanLyComment") %>
                </telerik:RadCodeBlock>
            </div>
            <div class="input">
                <telerik:RadAjaxPanel runat="server" ID="RadAjaxPanel2">
                    <uc3:CommentArticle ID="CommentArticle1" runat="server" />
                </telerik:RadAjaxPanel>
            </div>
        </div>
    </div>
    <div class="frow alt">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock23" runat="server">
                    <%=BicResource.GetValue("Admin","Admin_Article_ShortDescription") %>
                </telerik:RadCodeBlock>
            </div>
            <div class="input">
                <bic:Editor Height="200px" Skin="Office2007" Width="98%" ID="reBriefDescription"
                    ToolbarMode="ShowOnFocus" ToolsFile="~/admin/XMLData/Editor/SmallSetOfTools.xml"
                    runat="server" StripFormattingOnPaste="All" />
            </div>
        </div>
    </div>
    <div class="frow hidden">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock24" runat="server">
                    <%=BicResource.GetValue("Admin","System_DetailedContent") %>
                </telerik:RadCodeBlock>
            </div>
            <div class="input">
                <telerik:RadCodeBlock runat="server" ID="radCode2">
                    <%= IncludeAdmin.RadEditor() %>
                </telerik:RadCodeBlock>
                <bic:Editor Height="700px" ID="reBody" Width="98%" ToolsFile="~/admin/XMLData/Editor/RibbonFullSetOfTools.xml"
                    ContentFilters="None" runat="server" StripFormattingOnPaste="NoneSupressCleanMessage, MSWord, MSWordNoFonts"
                    ToolbarMode="RibbonBarShowOnFocus" Skin="Office2007" />
            </div>
        </div>
    </div>
    <div class="frow hidden">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock25" runat="server">
                    <%=BicResource.GetValue("Admin","Admin_Article_RelatedNews") %>
                </telerik:RadCodeBlock>
            </div>
            <div class="input">
                <telerik:RadAjaxPanel runat="server" ID="radAjax">
                    <uc2:relatedarticle ID="RelatedArticle1" runat="server" />
                </telerik:RadAjaxPanel>
            </div>
        </div>
    </div>
    <asp:TextBox runat="server" ID="txtAllowUser" CssClass="input-text hidden" />
    <div class="frow hidden">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock26" runat="server">
                    <%=BicResource.GetValue("Admin","System_Tags") %>
                </telerik:RadCodeBlock>
            </div>
            <div class="input">
                <asp:TextBox runat="server" ID="txtTag" MaxLength="200" CssClass="input-text" Width="85%" />
                (Max 200)
            </div>
        </div>
    </div>
    <div class="frow alt none">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock27" runat="server">
                    <%=BicResource.GetValue("Admin","System_UrlSEO") %>
                </telerik:RadCodeBlock>
            </div>
            <div class="input">
                <asp:TextBox runat="server" ID="txtSeoTitle" MaxLength="100" CssClass="input-text" Width="85%" />
                (Max 100)
            </div>
        </div>
    </div>
    <div class="frow none">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock29" runat="server">
                    <%=BicResource.GetValue("Admin","Admin_Article_PageTitle") %>
                </telerik:RadCodeBlock>
            </div>
            <div class="input">
                <asp:TextBox runat="server" ID="txtPageTitle" MaxLength="100" CssClass="input-text" Width="85%" />
                (Max 100)
            </div>
        </div>
    </div>
    <div class="frow alt none">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock30" runat="server">
                    <%=BicResource.GetValue("Admin","System_MetaDescription") %>
                </telerik:RadCodeBlock>
            </div>
            <div class="input">
                <asp:TextBox runat="server" ID="txtMetaDescription" MaxLength="170" CssClass="input-text" Width="85%" />
                (Max 170)
            </div>
        </div>
    </div>
    <div class="frow none">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock31" runat="server">
                    <%=BicResource.GetValue("Admin","System_MetaKeyword") %>
                </telerik:RadCodeBlock>
            </div>
            <div class="input">
                <asp:TextBox runat="server" ID="txtMetaKeyword" MaxLength="170" CssClass="input-text" Width="85%" />
                (Max 170)
            </div>
        </div>
    </div>
</div>
<div class="form-tool-bottom">
    <bic:ToolBar ID="tbBottom" runat="server" />
    <asp:LinkButton ID="lbtnSave2" CssClass="btn-save" runat="server" OnCommand="Save" CommandName="Update">
        <telerik:RadCodeBlock ID="RadCodeBlock35" runat="server">
            <%=BicResource.GetValue("Admin","Admin_Save") %>
        </telerik:RadCodeBlock>
    </asp:LinkButton>
</div>
<telerik:RadInputManager runat="server" ID="rim1" EnableEmbeddedSkins="false" Skin="BICCMS">
    <telerik:TextBoxSetting BehaviorID="bhTitle" EmptyMessage="<%$Resources:Admin,System_InputTitle%>" Validation-IsRequired="true">
        <TargetControls>
            <telerik:TargetInput ControlID="txtTitle" />
        </TargetControls>
    </telerik:TextBoxSetting>
    <telerik:NumericTextBoxSetting BehaviorID="bhViewCount" Type="Number" DecimalDigits="0">
        <TargetControls>
            <telerik:TargetInput ControlID="txtViewCount" />
        </TargetControls>
    </telerik:NumericTextBoxSetting>
</telerik:RadInputManager>
<telerik:RadAjaxLoadingPanel runat="server" Skin="Outlook" ID="RadAjaxLoadingPanel1" BackgroundPosition="Center" EnableSkinTransparency="true">
</telerik:RadAjaxLoadingPanel>
<%--Nút lên đầu--%>
<a href="#" class="toTop" style="opacity: 1;"></a>