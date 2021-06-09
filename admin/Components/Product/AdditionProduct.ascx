<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdditionProduct.ascx.cs"
    Inherits="Admin_Components_Product_AdditionProduct" %>
<%@ Import Namespace="BIC.Utils" %>
<%@ Register Src="../ImageGallery/ImageSelectMulti.ascx" TagName="ImageSelectMulti"
    TagPrefix="uc1" %>
<%@ Register Src="~/admin/Components/ImageGallery/ImageSelector.ascx" TagName="ImageSelector"
    TagPrefix="bic" %>
<%@ Register Src="~/admin/Components/Video/VideoSelector.ascx" TagName="VideoSelector"
    TagPrefix="bic" %>
<%@ Register Src="RelatedProduct.ascx" TagName="relatedproduct" TagPrefix="uc2" %>
<%@ Register TagPrefix="bic" TagName="RelatedArticle" Src="~/admin/Components/Article/RelatedArticle.ascx" %>

<telerik:RadCodeBlock runat="server" ID="radCode">
    <script src='<%= Page.ResolveUrl("~/admin/Scripts/jquery.autocomplete.min.js") %>'
        type="text/javascript"> </script>
    <link href='<%= Page.ResolveUrl("~/admin/Scripts/jquery.autocomplete/jquery.autocomplete.css") %>'
        rel="stylesheet" type="text/css" />
    <div class="form-tool product">
        <bic:ToolBar ID="tbTop" runat="server" />
        <asp:LinkButton ID="lbtnSave" CssClass="btn-save" runat="server" OnCommand="Save"
            CommandName="AddNew" ValidationGroup="btnSave">
            <telerik:RadCodeBlock ID="RadCodeBlock41" runat="server">
                <%= BicResource.GetValue("Admin", "Admin_Save") %>
            </telerik:RadCodeBlock>
        </asp:LinkButton>
    </div>
    <div class="form-caption">
        <%= BicMessage.InsertTitle %>
        <span class="note"><em>*</em>
            <%= BicMessage.RequireTitle %></span>
    </div>
</telerik:RadCodeBlock>
<div class="form-view">
    <!--Language-->
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock4" runat="server">
                    <%= BicResource.GetValue("Admin", "Admin_AdminLanguege_Language") %>
                </telerik:RadCodeBlock>
            </div>
            <div class="input">
                <bic:Language ID="ddlLanguage" runat="server" Width="200px" CssClass="input-select"
                    AutoPostBack="true" OnSelectedIndexChanged="ddlLanguage_SelectedIndexChanged">
                </bic:Language>
            </div>
        </div>
    </div>
    <!--Menu User-->
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock5" runat="server">
                    <%= BicResource.GetValue("Admin", "Admin_Product_List") %>
                </telerik:RadCodeBlock>
            </div>
            <div class="input">
                <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
                    <script type="text/javascript">                        function ClientNodeChecked(sender, eventArgs) { var node = eventArgs.get_node(); if (node.get_checked()) { var list1 = $("#hdTreeMenu").val(); var arr1 = list1.split(','); var count = 0; for (var i = 0; i < arr1.length; i++) { if (arr1[i] == node.get_value()) count++; }; if (count == 0) $("#hdTreeMenu").val($("#hdTreeMenu").val() + ',' + node.get_value()); } else { var list2 = $("#hdTreeMenu").val(); var arr2 = list2.split(','); var menuid = ""; for (var j = 0; j < arr2.length; j++) { if (arr2[j] != node.get_value()) { menuid = menuid + "," + arr2[j]; } }; $("#hdTreeMenu").val(menuid.replace(",,", ",")); }; $.ajax({ type: "POST", url: getBaseURL() + 'admin/Service/ListMenu.ashx?menuid=' + $("#hdTreeMenu").val(), success: function (mess) { $(".menuchoice").html(""); $(".menuchoice").html(mess); }, error: function (errormessage) { alert("Chắc năng này đang được nâng cấp"); } }); $(".menuchoice").ajaxComplete(function (event, request, settings) { $("#MenuDrop li").hover(function () { $("#MenuDrop li").removeClass("hovermenu"); $(this).addClass("hovermenu"); }, function () { $("#MenuDrop li").removeClass("hovermenu"); }); $("#MenuDrop").sortable({ revert: true, stop: function (event, ui) { var s = ""; $("#MenuDrop li").each(function () { s += "," + $.trim($(this).attr("id")); }); $("#hdTreeMenu").val(s); } }); }); }</script>
                </telerik:RadScriptBlock>
                <asp:HiddenField ID="hdTreeMenu" runat="server" ClientIDMode="Static" />
                <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                    <div class="cot-tree">
                        <telerik:RadTreeView runat="server" Skin="Outlook" Width="250px" OnClientNodeChecked="ClientNodeChecked"
                            CheckBoxes="true" ID="tvMenuUser" PersistLoadOnDemandNodes="true" LoadingStatusPosition="AfterNodeText"
                            CollapseAnimation-Duration="0" ExpandAnimation-Duration="0" ExpandAnimation-Type="none"
                            OnNodeCheck="tvMenuUser_OnNodeCheck">
                        </telerik:RadTreeView>
                    </div>
                    <div class="cot-tree">
                        <telerik:RadTreeView runat="server" Skin="Outlook" Width="250px" OnClientNodeChecked="ClientNodeChecked"
                            CheckBoxes="true" ID="RadTreeView1" PersistLoadOnDemandNodes="true" LoadingStatusPosition="AfterNodeText"
                            CollapseAnimation-Duration="0" ExpandAnimation-Duration="0" ExpandAnimation-Type="none"
                            OnNodeCheck="tvMenuUser_OnNodeCheck">
                        </telerik:RadTreeView>
                    </div>
                    <div class="cot-tree">
                        <telerik:RadTreeView runat="server" Skin="Outlook" Width="250px" OnClientNodeChecked="ClientNodeChecked"
                            CheckBoxes="true" ID="RadTreeView2" PersistLoadOnDemandNodes="true" LoadingStatusPosition="AfterNodeText"
                            CollapseAnimation-Duration="0" ExpandAnimation-Duration="0" ExpandAnimation-Type="none"
                            OnNodeCheck="tvMenuUser_OnNodeCheck">
                        </telerik:RadTreeView>
                    </div>
                </telerik:RadAjaxPanel>
            </div>
        </div>
    </div>
    <!--Select Menu-->
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
                    <%= BicResource.GetValue("Admin", "Admin_Product_ListOfSelected") %>
                </telerik:RadCodeBlock>
            </div>
            <div class="input">
                <div class="menuchoice">
                    <telerik:RadCodeBlock ID="RadCodeBlock2" runat="server">
                        <%= BicResource.GetValue("Admin", "Admin_Product_NoItemsSelected") %>
                    </telerik:RadCodeBlock>
                </div>
            </div>
        </div>
    </div>
    <!--Title-->
    <div class="frow ">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock3" runat="server">
                    <%= BicResource.GetValue("Admin", "Admin_Product_Title2") %>
                </telerik:RadCodeBlock>
                <span class="validate">*</span>
            </div>
            <div class="input">
                <asp:TextBox ID="txtTitle" runat="server" CssClass="input-text" MaxLength="180" Width="85%" />
                (Max 180)
            </div>
        </div>
    </div>
    <!--Product Property Default-->
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock6" runat="server">
                    <%= BicResource.GetValue("Admin", "System_OtherInformation") %>
                </telerik:RadCodeBlock>
            </div>
            <div class="input group-item">
                <div class="col c2 first">
                    <telerik:RadAjaxPanel ID="RadAjaxPanel4" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                        <telerik:RadCodeBlock ID="RadCodeBlock61" runat="server">
                            <!--Product Code-->
                            <div class="line">
                                <div class="label">
                                    <telerik:RadCodeBlock ID="RadCodeBlock22" runat="server">
                                        Mã sản phẩm
                                    </telerik:RadCodeBlock>
                                </div>
                                <div class="input">
                                    <asp:TextBox runat="server" ID="txtCode" CssClass="input-text" Width="116px" />
                                </div>
                            </div>
                            <!--Product Old Price-->
                            <div class="line">
                                <div class="label">
                                    <telerik:RadCodeBlock ID="RadCodeBlock24" runat="server">
                                        <%= BicResource.GetValue("Admin", "Admin_Product_OldPrice") %>
                                    </telerik:RadCodeBlock>
                                </div>
                                <div class="input">
                                    <asp:TextBox runat="server" ID="txtOldPrice" CssClass="input-text" Width="116px" onkeypress="return keypress(event);" />
                                </div>
                            </div>
                            <!--Product Price-->
                            <div class="line">
                                <div class="label">
                                    <telerik:RadCodeBlock ID="RadCodeBlock23" runat="server">
                                        <%= BicResource.GetValue("Admin", "Admin_Product_Price") %>
                                    </telerik:RadCodeBlock>
                                </div>
                                <div class="input">
                                    <asp:TextBox runat="server" ID="txtPrice" CssClass="input-text" Width="116px" onkeypress="return keypress(event);" />
                                </div>
                            </div>
                            <!--Product SaleOff-->
                            <div class="line">
                                <div class="label">
                                    <telerik:RadCodeBlock ID="RadCodeBlock62" runat="server">
                                        Giảm giá (%)
                                    </telerik:RadCodeBlock>
                                </div>
                                <div class="input">
                                    <asp:TextBox runat="server" ID="txtSaleOff" CssClass="input-text" Width="116px" onkeypress="return keypress(event);" />
                                </div>
                            </div>
                        </telerik:RadCodeBlock>
                    </telerik:RadAjaxPanel>
                </div>
                <div class="col c1">
                    <!--Priority-->
                    <div class="line">
                        <div class="label arrow">
                            <telerik:RadCodeBlock ID="RadCodeBlock19" runat="server">
                                <%= BicResource.GetValue("Admin", "Admin_Product_Order") %>
                            </telerik:RadCodeBlock>
                        </div>
                        <div class="input">
                            <telerik:RadNumericTextBox ShowSpinButtons="true" IncrementSettings-InterceptArrowKeys="true"
                                IncrementSettings-InterceptMouseWheel="true" Value="1" LabelWidth="" runat="server"
                                ID="ntxPosition" Width="70px" DataType="System.Int64" MinValue="1">
                                <NumberFormat ZeroPattern="n" AllowRounding="False"></NumberFormat>
                            </telerik:RadNumericTextBox>
                        </div>
                    </div>
                    <asp:Label runat="server" ID="lblPriority" Visible="false" />
                    <!--Comment Setting-->
                    <telerik:RadCodeBlock ID="RadCodeBlock42" runat="server">
                        <div class="line  <%= BicXML.ToBoolean("EnableComment", "SettingProduct") == false ? "hidden" : "" %>">
                            <div class="label arrow">
                                <telerik:RadCodeBlock ID="RadCodeBlock8" runat="server">
                                    <%= BicResource.GetValue("Admin", "Admin_Product_AppearComment") %>
                                </telerik:RadCodeBlock>
                            </div>
                            <div class="input">
                                <asp:CheckBox runat="server" ID="chkCommentEnable" />
                            </div>
                        </div>
                    </telerik:RadCodeBlock>
                    <!--IsNew-->
                    <div class="line">
                        <div class="label arrow">
                            <telerik:RadCodeBlock ID="RadCodeBlock9" runat="server">
                                <%= BicResource.GetValue("Admin", "System_New") %>
                            </telerik:RadCodeBlock>
                        </div>
                        <div class="input">
                            <asp:CheckBox runat="server" ID="chkNew" />
                        </div>
                    </div>
                    <!--IsActive-->
                    <div class="line">
                        <div class="label arrow">
                            <telerik:RadCodeBlock ID="RadCodeBlock10" runat="server">
                                <%= BicResource.GetValue("Admin", "System_Browse") %>
                            </telerik:RadCodeBlock>
                        </div>
                        <div class="input">
                            <asp:CheckBox runat="server" Enable="<%# Approved %>" ID="chkIsActive" />
                        </div>
                    </div>
                    <!--IsFull-->
                    <div class="line hidden">
                        <div class="label arrow">
                            <telerik:RadCodeBlock ID="RadCodeBlock11" runat="server">
                                <%= BicResource.GetValue("Admin", "System_FullScreen") %>
                            </telerik:RadCodeBlock>
                        </div>
                        <div class="input">
                            <asp:CheckBox runat="server" ID="chkIsFull" />
                        </div>
                    </div>

                    <div class="line hidden">
                        <div class="label arrow">
                            <telerik:RadCodeBlock ID="RadCodeBlock16" runat="server">
                                <%= BicResource.GetValue("Admin", "Admin_Product_NewsFocus") %>
                            </telerik:RadCodeBlock>
                        </div>
                        <div class="input">
                            <asp:DropDownList ID="ddlTintieudiem" runat="server" Width="120" />
                        </div>
                    </div>
                    <!--TypeOfProduct-->
                    <div class="line hidden">
                        <div class="label arrow">
                            <telerik:RadCodeBlock ID="RadCodeBlock17" runat="server">
                                <%= BicResource.GetValue("Admin", "Admin_Product_TypeOfNews") %>
                            </telerik:RadCodeBlock>
                        </div>
                        <div class="input">
                            <asp:DropDownList ID="ddlTypeproducts" runat="server" Width="120" ClientIDMode="Static" />
                        </div>
                    </div>
                    <!--IsHome-->
                    <div class="line hidden">
                        <div class="label arrow">
                            <telerik:RadCodeBlock ID="RadCodeBlock20" runat="server">
                                <%= BicResource.GetValue("Admin", "Admin_Product_Home") %>
                            </telerik:RadCodeBlock>
                        </div>
                        <div class="input">
                            <asp:CheckBox runat="server" ID="chkIsHome" />
                        </div>
                    </div>
                    <!--IsStock-->
                    <div class="line">
                        <div class="label arrow">
                            <telerik:RadCodeBlock ID="RadCodeBlock31" runat="server">
                                <%= BicResource.GetValue("Admin", "Admin_Product_InStock") %>
                            </telerik:RadCodeBlock>
                        </div>
                        <div class="input">
                            <asp:CheckBox runat="server" Checked="true" ID="chkOutOfStock" />
                        </div>
                    </div>
                </div>
                <div class="col c2">
                    <!--Target-->
                    <div class="line">
                        <div class="label arrow">
                            <telerik:RadCodeBlock ID="RadCodeBlock12" runat="server">
                                <%= BicResource.GetValue("Admin", "System_Target") %>
                            </telerik:RadCodeBlock>
                        </div>
                        <div class="input">
                            <bic:Target runat="server" ID="cbTarget" CssClass="input-select">
                            </bic:Target>
                        </div>
                    </div>
                    <!--Vote-->
                    <div class="line hidden">
                        <div class="label arrow">
                            <telerik:RadCodeBlock ID="RadCodeBlock18" runat="server">
                                <%= BicResource.GetValue("Admin", "Admin_Product_Votes") %>
                            </telerik:RadCodeBlock>
                        </div>
                        <div class="input">
                            <asp:TextBox runat="server" ID="txtVote" CssClass="input-text" Width="108px"></asp:TextBox>
                        </div>
                    </div>
                    <!--Product ViewCount-->
                    <telerik:RadCodeBlock ID="RadCodeBlock13" runat="server">
                        <div class="line <%= BicXML.ToBoolean("EnableView", "SettingProduct") == false ? "hidden" : "" %>">
                            <div class="label arrow">
                                <%= BicResource.GetValue("Admin", "Admin_Product_Views2") %>
                            </div>
                            <div class="input">
                                <asp:TextBox runat="server" ID="txtViewCount" CssClass="input-text" Width="116px"
                                    Text="1" />
                            </div>
                        </div>
                    </telerik:RadCodeBlock>
                    <!--Link-->
                    <div class="line">
                        <div class="label arrow">
                            <telerik:RadCodeBlock ID="RadCodeBlock15" runat="server">
                                <%= BicResource.GetValue("Admin", "Admin_Product_Link") %>
                            </telerik:RadCodeBlock>
                        </div>
                        <div class="input">
                            <asp:TextBox runat="server" ID="txtLink" CssClass="input-text" Width="108px" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!--Product Property-->
    <telerik:RadCodeBlock ID="RadCodeBlock59" runat="server">
        <div class="frow">
            <%-- <div class="frow  <%= BicXML.ToBoolean("EnableProperty", "SettingProduct") == false ? "hidden" : "" %>">--%>
            <div class="frow-wrapp">
                <div class="label">
                    <telerik:RadCodeBlock ID="RadCodeBlock21" runat="server">
                        <%= BicResource.GetValue("Admin", "Admin_Product_Property") %>
                    </telerik:RadCodeBlock>
                </div>
                <div class="input group-item">
                    <div class="col c2 first">
                        <!--Product Manufacture-->
                        <div class="line">
                            <div class="label">
                                <telerik:RadCodeBlock ID="RadCodeBlock34" runat="server">
                                    <%= BicResource.GetValue("Admin", "System_Manufacture") %>
                                </telerik:RadCodeBlock>
                            </div>
                            <div class="input">
                                <asp:TextBox runat="server" ID="txtManufactory" CssClass="input-text" Width="116px" />
                            </div>
                        </div>
                        <div class="line">
                            <div class="label">
                                <telerik:RadCodeBlock ID="RadCodeBlock48" runat="server">
                                    Bảo hành
                                </telerik:RadCodeBlock>
                            </div>
                            <div class="input">
                                <asp:TextBox runat="server" ID="txtBaoHanh" CssClass="input-text" Width="116px" />
                            </div>
                        </div>
                    </div>
                    <div class="col c2 hidden">
                    </div>
                    <div class="col c3 hidden">
                    </div>
                </div>
            </div>
        </div>
    </telerik:RadCodeBlock>

    <!--Image Gallery-->
    <telerik:RadCodeBlock ID="RadCodeBlock60" runat="server">
        <div class="frow">
            <div class="frow-wrapp">
                <div class="label">
                    <telerik:RadCodeBlock ID="RadCodeBlock36" runat="server">
                        <%= BicResource.GetValue("Admin", "Admin_Product_Images") %>
                    </telerik:RadCodeBlock>
                </div>
                <div class="input group-item">
                    <div class="col first selector-image">
                        <div class="title arrow">
                            <telerik:RadCodeBlock ID="RadCodeBlock7" runat="server">
                                <%= BicResource.GetValue("Admin", "Admin_Product_ImageDescription") %>
                            </telerik:RadCodeBlock>
                        </div>
                        <bic:ImageSelector ID="isImageId" runat="server" />
                    </div>
                    <div id="ArrayImage" class="col <%= BicXML.ToBoolean("EnableArrayImage", "SettingProduct") == false ? "hidden" : "" %>">
                        <uc1:ImageSelectMulti ID="ismImageId" runat="server" />
                    </div>
                </div>
            </div>
        </div>
    </telerik:RadCodeBlock>
    <script type="text/javascript">
        $(document).ready(function () { $("#ddlTypeproducts").live("change", function () { if ($(this).val() == 2) { $("#ArrayImage").show(); $("#Video").hide(); } if ($(this).val() == 3) { $("#Video").show(); $("#ArrayImage").hide(); } if ($(this).val() == 1 || $(this).val() == 4) { $("#Video").hide(); $("#ArrayImage").hide(); } }); });
    </script>

    <!--Video-->
    <div class="frow hidden" id="Video">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock37" runat="server">
                    <%= BicResource.GetValue("Admin", "Admin_Product_Video") %>
                </telerik:RadCodeBlock>
            </div>
            <div class="input group-item">
                <div class="col first video-image">
                    <bic:VideoSelector ID="isVideoID" runat="server" />
                </div>
            </div>
        </div>
    </div>

    <!--EDITER-->
    <!--ShortDescription-->
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock38" runat="server">
                    <%= BicResource.GetValue("Admin", "Admin_Product_ShortDescription") %>
                </telerik:RadCodeBlock>
            </div>
            <div class="input">
                <bic:Editor Height="200px" ID="reBriefDescription" Width="98%" ToolsFile="~/admin/XMLData/Editor/SmallSetOfTools.xml"
                    ContentFilters="None" runat="server" StripFormattingOnPaste="NoneSupressCleanMessage, MSWord, MSWordNoFonts"
                    ToolbarMode="ShowOnFocus" Skin="Office2007" />
            </div>
        </div>
    </div>
    <!--FullDescription-->
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock39" runat="server">
                    Chi tiết sản phẩm
                </telerik:RadCodeBlock>
            </div>
            <div class="input">
                <telerik:RadCodeBlock runat="server" ID="radCode2">
                    <%= IncludeAdmin.RadEditor() %>
                </telerik:RadCodeBlock>
                <bic:Editor Height="600px" ID="reBody" Width="98%" ToolsFile="~/admin/XMLData/Editor/RibbonFullSetOfTools.xml"
                    ContentFilters="None" runat="server" StripFormattingOnPaste="NoneSupressCleanMessage, MSWord, MSWordNoFonts"
                    ToolbarMode="RibbonBar" Skin="Office2007" />
            </div>
        </div>
    </div>
    <!--NewColumn1-->
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock70" runat="server">
                    Video sản phẩm
                </telerik:RadCodeBlock>
            </div>
            <div class="input">
                <bic:Editor Height="600px" ID="reNewColumn1" Width="98%" ToolsFile="~/admin/XMLData/Editor/RibbonFullSetOfTools.xml"
                    ContentFilters="None" runat="server" StripFormattingOnPaste="NoneSupressCleanMessage, MSWord, MSWordNoFonts"
                    ToolbarMode="RibbonBar" Skin="Office2007" />
            </div>
        </div>
    </div>
    <!--NewColumn2-->
    <div class="frow hidden">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock63" runat="server">
                    NewColumn2
                </telerik:RadCodeBlock>
            </div>
            <div class="input">
                <telerik:RadCodeBlock runat="server" ID="RadCodeBlock64">
                    <%= IncludeAdmin.RadEditor() %>
                </telerik:RadCodeBlock>
                <bic:Editor Height="400px" ID="reNewColumn2" Width="98%" ToolsFile="~/admin/XMLData/Editor/RibbonFullSetOfTools.xml"
                    ContentFilters="None" runat="server" StripFormattingOnPaste="NoneSupressCleanMessage, MSWord, MSWordNoFonts"
                    ToolbarMode="RibbonBarShowOnFocus" Skin="Office2007" />
            </div>
        </div>
    </div>
    <!--NewColumn3-->
    <div class="frow hidden">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock65" runat="server">
                    NewColumn3
                </telerik:RadCodeBlock>
            </div>
            <div class="input">
                <telerik:RadCodeBlock runat="server" ID="RadCodeBlock66">
                    <%= IncludeAdmin.RadEditor() %>
                </telerik:RadCodeBlock>
                <bic:Editor Height="500px" ID="reNewColumn3" Width="98%" ToolsFile="~/admin/XMLData/Editor/RibbonFullSetOfTools.xml"
                    ContentFilters="None" runat="server" StripFormattingOnPaste="NoneSupressCleanMessage, MSWord, MSWordNoFonts"
                    ToolbarMode="RibbonBarShowOnFocus" Skin="Office2007" />
            </div>
        </div>
    </div>
    <!--NewColumn4-->
    <div class="frow hidden">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock67" runat="server">
                    NewColumn4
                </telerik:RadCodeBlock>
            </div>
            <div class="input">
                <telerik:RadCodeBlock runat="server" ID="RadCodeBlock68">
                    <%= IncludeAdmin.RadEditor() %>
                </telerik:RadCodeBlock>
                <bic:Editor Height="500px" ID="reNewColumn4" Width="98%" ToolsFile="~/admin/XMLData/Editor/RibbonFullSetOfTools.xml"
                    ContentFilters="None" runat="server" StripFormattingOnPaste="NoneSupressCleanMessage, MSWord, MSWordNoFonts"
                    ToolbarMode="RibbonBarShowOnFocus" Skin="Office2007" />
            </div>
        </div>
    </div>
    <!--END EDITER-->

    <!--Related Product-->
    <telerik:RadCodeBlock ID="RadCodeBlock43" runat="server">
        <div class="frow  <%= BicXML.ToBoolean("EnableRelatedProduct", "SettingProduct") == false ? "hidden" : "" %>">
            <div class="frow-wrapp">
                <div class="label">
                    <telerik:RadCodeBlock ID="RadCodeBlock25" runat="server">
                        <%= BicResource.GetValue("Admin", "Admin_Product_RelatedProducts") %>
                    </telerik:RadCodeBlock>
                </div>
                <div class="input">
                    <telerik:RadCodeBlock ID="RadCodeBlock46" runat="server">
                        <telerik:RadAjaxPanel runat="server" ID="radAjax">
                            <uc2:relatedproduct ID="RelatedProduct1" runat="server" />
                        </telerik:RadAjaxPanel>
                    </telerik:RadCodeBlock>
                </div>
            </div>
        </div>
    </telerik:RadCodeBlock>

    <!--Related News-->
    <telerik:RadCodeBlock ID="RadCodeBlock44" runat="server">
        <div class="frow  <%= BicXML.ToBoolean("EnableRelatedNews", "SettingProduct") == false ? "hidden" : "" %>">
            <div class="frow-wrapp">
                <div class="label">
                    <telerik:RadCodeBlock ID="RadCodeBlock40" runat="server">
                        <%= BicResource.GetValue("Admin", "Admin_Product_RelatedNews") %>
                    </telerik:RadCodeBlock>
                </div>
                <div class="input">
                    <telerik:RadCodeBlock ID="RadCodeBlock47" runat="server">
                        <telerik:RadAjaxPanel runat="server" ID="RadAjaxPanel3">
                            <bic:RelatedArticle runat="server" ID="RelatedArticle" />
                        </telerik:RadAjaxPanel>
                    </telerik:RadCodeBlock>
                </div>
            </div>
        </div>
    </telerik:RadCodeBlock>

    <asp:TextBox runat="server" ID="txtAllowUser" CssClass="input-text hidden" />
    <!--Tag-->
    <telerik:RadCodeBlock ID="RadCodeBlock58" runat="server">
        <div class="frow  <%= BicXML.ToBoolean("EnableTags", "SettingProduct") == false ? "hidden" : "" %>">
            <div class="frow-wrapp">
                <div class="label">
                    <telerik:RadCodeBlock ID="RadCodeBlock26" runat="server">
                        <%= BicResource.GetValue("Admin", "System_Tags") %>
                    </telerik:RadCodeBlock>
                </div>
                <div class="input">
                    <asp:TextBox runat="server" ID="txtTag" MaxLength="200" CssClass="input-text" Width="85%" />
                    (Max 200)
                </div>
            </div>
        </div>
    </telerik:RadCodeBlock>

    <!--SEO-->
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock28" runat="server">
                    <%= BicResource.GetValue("Admin", "System_UrlSEO") %>
                </telerik:RadCodeBlock>
            </div>
            <div class="input">
                <asp:TextBox runat="server" ID="txtSeoTitle" MaxLength="100" CssClass="input-text" Width="85%" />
                (Max 100)
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock27" runat="server">
                    <%= BicResource.GetValue("Admin", "Admin_Product_PageTitle") %>
                </telerik:RadCodeBlock>
            </div>
            <div class="input">
                <asp:TextBox runat="server" ID="txtPageTitle" MaxLength="100" CssClass="input-text" Width="85%" />
                (Max 100)
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock29" runat="server">
                    <%= BicResource.GetValue("Admin", "System_MetaDescription") %>
                </telerik:RadCodeBlock>
            </div>
            <div class="input">
                <asp:TextBox runat="server" ID="txtMetaDescription" MaxLength="170" CssClass="input-text" Width="85%" />
                (Max 170)
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock30" runat="server">
                    <%= BicResource.GetValue("Admin", "System_MetaKeyword") %>
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
    <asp:LinkButton ID="lbtnSave2" CssClass="btn-save" runat="server" OnCommand="Save"
        CommandName="AddNew" ValidationGroup="btnSave">
        <telerik:RadCodeBlock ID="RadCodeBlock32" runat="server">
            <%= BicResource.GetValue("Admin", "Admin_Save") %>
        </telerik:RadCodeBlock>
    </asp:LinkButton>
</div>
<telerik:RadInputManager runat="server" ID="rim1" EnableEmbeddedSkins="false" Skin="BICCMS">
    <telerik:TextBoxSetting BehaviorID="bhTitle" EmptyMessage="<%$Resources:Admin,System_InputTitle%>" Validation-IsRequired="true"
        Validation-ValidationGroup="btnSave">
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
<telerik:RadAjaxLoadingPanel runat="server" Skin="Outlook" ID="RadAjaxLoadingPanel1"
    BackgroundPosition="Center" EnableSkinTransparency="true">
</telerik:RadAjaxLoadingPanel>
<%--Nút lên đầu--%>
<a href="#" class="toTop" style="opacity: 0; filter: alpha(opacity=0)"></a>
<telerik:RadCodeBlock runat="server" ID="RadCodeBlock">
    <script type="text/javascript">
        $("#<%= txtOldPrice.ClientID %>").on("change", function () {
            var price = parseFloat($("#<%= txtPrice.ClientID %>").val());
            var oldPrice = parseFloat($(this).val());
            if (price > 0) {
                var discount = (oldPrice - price) / (oldPrice / 100);
                if (!isNaN(discount)) {
                    //Làm tròn số 0.5 => 0 ; 0.6 => 1
                    $("#<%= txtSaleOff.ClientID %>").val(Math.round(discount));
                } else {
                    $("#<%= txtSaleOff.ClientID %>").val(0);
                }
            }
        });
        $("#<%= txtPrice.ClientID %>").on("change", function () {
            var price = parseFloat($(this).val());
            var oldPrice = parseFloat($("#<%= txtOldPrice.ClientID %>").val());
            if (oldPrice > 0) {
                var discount = (oldPrice - price) / (oldPrice / 100);
                if (!isNaN(discount)) {
                    //Làm tròn số 0.5 => 0 ; 0.6 => 1
                    $("#<%= txtSaleOff.ClientID %>").val(Math.round(discount));
                }
                else {
                    $("#<%= txtSaleOff.ClientID %>").val(0);
                }
            }
            else if (oldPrice < price) {
                alert("Giá bán cao hơn giá gốc.");
            }
            else {
                alert("Bạn chưa nhập giá gốc.");
            }
        });
        $("#<%= txtSaleOff.ClientID %>").on("change", function () {
            var sale = parseFloat($(this).val());
            var price = parseFloat($("#<%= txtPrice.ClientID %>").val());
            var oldPrice = parseFloat($("#<%= txtOldPrice.ClientID %>").val());
            if (oldPrice >= 0) {
                price = (oldPrice * sale) / 100;
                $("#<%= txtPrice.ClientID %>").val(price);
            }
            else {
                alert("Bạn chưa nhập giá gốc.");
            }
        });
    </script>
</telerik:RadCodeBlock>
<script type="text/javascript">
    $(".toTop").live("click", function (event) {
        $(this).stop().animate({ opacity: 0 });
    });
    $(window).load(function () {
        var n = $(this).scrollTop();
        n = n > 300 ? 300 : n;
        $(".toTop").stop().animate({ opacity: n / 300 }, { duration: n });
    });
    $(window).scroll(function () {
        var n = $(this).scrollTop();
        n = n > 300 ? 300 : n;
        $(".toTop").stop().animate({ opacity: n / 300 }, { duration: n });
    });
</script>
<style type="text/css">
    .c3 .line .label {
        width: 106px !important;
    }
</style>
