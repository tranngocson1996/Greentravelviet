<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditionTour.ascx.cs" Inherits="Admin_Components_Tour_EditionTour" %>
<%@ Import Namespace="BIC.Utils" %>
<%@ Register Src="~/admin/Components/ImageGallery/ImageSelector.ascx" TagName="ImageSelector" TagPrefix="bic" %>
<%@ Register Src="~/admin/Components/ImageGallery/ImageSelectMulti.ascx" TagName="ImageSelectorMulti" TagPrefix="bic" %>
<script type="text/javascript">
    function OnClientDropDownClosedHandler(sender, eventArgs) {
        $("#txtLichTrinhHienThi").val($("#ddlLichTrinh").val());
        if ($("#ddlLichTrinh").val() != "") {
            var list = $("#ddlLichTrinh").val().split(',');
            var combo = $find("ddlKhoiHanhTu");
            var item = combo.findItemByText(list[0]); r
            if (item) {
                item.select();
            }
        }
    }
    function ddlPhuongTien_OnClientDropDownClosedHandler(sender, eventArgs) {
        $("#txtPhuongTienHienThi").val($("#ddlPhuongTien").val());
    }
    $(document).ready(function () {
        $("#txtSoNgay").keyup(function () {
            Ajax($("#txtSoNgay").val());
        }).blur(function () {
            Ajax($("#txtSoNgay").val());
        });
        function Ajax(id) {
            $.ajax({
                type: "POST",
                url: getBaseURL() + 'admin/Components/Tour/Tour.ashx?day=' + id,
                success: function (mess) {
                    $("#txtSoDem").val(mess);
                },
                error: function (errormessage) {
                    //alert(errormessage.responseText);
                    //alert("Chức năng này đang được nâng cấp. Mời bạn quay lại sau.");
                }
            });
        }
    });

</script>
<script type="text/javascript" src="../../Scripts/jquery-1.6.2.min-vsdoc.js"></script>
<script type="text/javascript" src='<%=Page.ResolveUrl("~/admin/Scripts/telerik/radedit.js") %>'></script>
<div class="form-tool">
    <bic:ToolBar ID="tbTop" runat="server" />
    <asp:LinkButton ID="lbtnSave" CssClass="btn-save" runat="server" OnCommand="Save" CommandName="Update">
        <telerik:RadCodeBlock ID="RadCodeBlock31" runat="server">
            <%=BicResource.GetValue("Admin","Admin_Save") %>
        </telerik:RadCodeBlock>
    </asp:LinkButton>
</div>
<div class="form-caption">
    <%=BIC.Utils.BicMessage.InsertTitle%>
    <span class="note"><em>*</em>
        <%=BIC.Utils.BicMessage.RequireTitle%>
    </span>
</div>
<div class="form-view">
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock4" runat="server">
                    <%=BicResource.GetValue("Admin","Admin_AdminLanguege_Language") %>
                </telerik:RadCodeBlock>
            </div>
            <div class="input">
                <bic:Language ID="ddlLanguage" runat="server" Width="200px" CssClass="input-select" AutoPostBack="true" OnSelectedIndexChanged="ddlLanguage_SelectedIndexChanged" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock3" runat="server">
                    <%=BicResource.GetValue("Admin","Admin_Article_Title2") %>
                </telerik:RadCodeBlock>
                <span class="validate">*</span>
            </div>
            <div class="input">
                <asp:TextBox ID="txtTenTour" CssClass="input-select" Width="95%" runat="server" />
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
                <div class="cot-tree">
                    <telerik:RadTreeView runat="server" Skin="Outlook" Width="500px" CheckBoxes="true" ID="tvMenuUser" PersistLoadOnDemandNodes="true"
                        LoadingStatusPosition="AfterNodeText" CollapseAnimation-Duration="200" ExpandAnimation-Duration="200" ExpandAnimation-Type="InQuart"
                        SingleExpandPath="False">
                    </telerik:RadTreeView>
                </div>
                <div class="cot-tree">
                    <telerik:RadTreeView runat="server" Skin="Outlook" Width="500px" CheckBoxes="true" ID="tvMenuUser2" PersistLoadOnDemandNodes="true"
                        LoadingStatusPosition="AfterNodeText" CollapseAnimation-Duration="200" ExpandAnimation-Duration="200" ExpandAnimation-Type="InQuart"
                        SingleExpandPath="False">
                    </telerik:RadTreeView>
                </div>
                <div class="cot-tree">
                    <telerik:RadTreeView runat="server" Skin="Outlook" Width="500px" CheckBoxes="true" ID="tvMenuUser3" PersistLoadOnDemandNodes="true"
                        LoadingStatusPosition="AfterNodeText" CollapseAnimation-Duration="200" ExpandAnimation-Duration="200" ExpandAnimation-Type="InQuart"
                        SingleExpandPath="False">
                    </telerik:RadTreeView>
                </div>
            </div>

        </div>
    </div>
    <div class="frow hidden">
        <div class="frow-wrapp">
            <div class="label">
                Mô tả chung
            </div>
            <div class="input">
                <bic:Editor Height="400px" Width="98%" ID="reMoTaChung" EnableResize="true" ToolbarMode="RibbonBar" ToolsFile="~/admin/XMLData/Editor/RibbonFullSetOfTools.xml"
                    runat="server" StripFormattingOnPaste="NoneSupressCleanMessage, MSWord, MSWordNoFonts" Skin="Office2007" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Mã tour
            </div>
            <div class="input">
                <asp:TextBox ID="txtMaTour" CssClass="input-select" Width="200" runat="server" />
            </div>
        </div>
    </div>

    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <telerik:RadAjaxPanel runat="server" ID="rapContact" LoadingPanelID="RadAjaxLoadingPanel1">
            <div class="frow">
                <div class="frow-wrapp">
                    <div class="label">
                        <telerik:RadCodeBlock ID="RadCodeBlock23" runat="server">
                            <%=BicResource.GetValue("Admin","Admin_Tour_Group") %>
                        </telerik:RadCodeBlock>
                    </div>
                    <div class="input">
                        <asp:DropDownList runat="server" ID="ddlVungMien" Width="207" CssClass="input-select" AutoPostBack="True" OnSelectedIndexChanged="ddlVungMien_SelectedIndexChanged">
                        </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:DropDownList runat="server" ID="ddlVungMienSub" Width="200" CssClass="input-select" AutoPostBack="True">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="frow">
                <div class="frow-wrapp">
                    <div class="label">
                        <telerik:RadCodeBlock ID="RadCodeBlock2" runat="server">
                            <%=BicResource.GetValue("Admin","Admin_Tour_Country") %>
                        </telerik:RadCodeBlock>
                    </div>
                    <div class="input">
                        <asp:DropDownList runat="server" ID="ddlQuocGia" CssClass="input-select" AutoPostBack="True" />
                    </div>
                </div>
            </div>
            <div class="frow">
                <div class="frow-wrapp">
                    <div class="label">
                        <telerik:RadCodeBlock ID="RadCodeBlock17" runat="server">
                            <%=BicResource.GetValue("Admin","IdeasTour") %>
                        </telerik:RadCodeBlock>
                    </div>
                    <div class="input">
                        <asp:DropDownList runat="server" ID="ddlYTuong" CssClass="input-select" AutoPostBack="True" />
                    </div>
                </div>
            </div>
        </telerik:RadAjaxPanel>
    </telerik:RadCodeBlock>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock7" runat="server">
                    <%=BicResource.GetValue("Admin","Admin_Article_ImageDescription") %> (408px-246px)
                </telerik:RadCodeBlock>
            </div>
            <div class="input">
                <bic:ImageSelector ID="isImageID" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Thư viện ảnh
            </div>
            <div class="input">
                <bic:ImageSelectorMulti ID="ismThuVienAnh" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock16" runat="server">
                    <%-- <%=BicResource.GetValue("Admin","Admin_Product_Price") %>--%>
                Giá cũ
                </telerik:RadCodeBlock>
            </div>
            <div class="input">
                <asp:TextBox ID="txtGiaHienThi" CssClass="input-select" Width="200" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock19" runat="server">
                    <%-- <%=BicResource.GetValue("Admin","Admin_Product_Price") %>--%>
                    Giá mới
                </telerik:RadCodeBlock>
            </div>
            <div class="input">
                <asp:TextBox ID="txtGiaCu" CssClass="input-text" Width="195" runat="server" />
            </div>
        </div>
    </div>

    <div class="frow hidden">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock15" runat="server">
                    <%=BicResource.GetValue("Admin","Product_CatGiam") %>(%)
                </telerik:RadCodeBlock>
            </div>
            <div class="input">
                <asp:TextBox ID="txtSale" CssClass="input-text" Width="195" runat="server" />%
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock14" runat="server">
                    <%--  <%=BicResource.GetValue("NumberDays") %>--%>
                    Số Ngày
                </telerik:RadCodeBlock>
            </div>
            <div class="input">
                <asp:TextBox ID="txtSoNgay" CssClass="input-text" Width="100" runat="server" ClientIDMode="Static" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock13" runat="server">
                    <%-- <%=BicResource.GetValue("Daysto") %>--%>
                     Ngày đi
                </telerik:RadCodeBlock>
            </div>
            <div class="input">
                <%--<asp:TextBox ID="txtNgayDi" CssClass="input-text" Width="195" runat="server" ClientIDMode="Static" />--%>
                <telerik:RadDatePicker ID="txtNgayDi" runat="server" CssClass="input-date" Width="120px" DateInput-EmptyMessage="<%$Resources:Admin, Admin_Article_SelectDate%>"
                    DateInput-DateFormat="dd/MM/yyyy" ShowPopupOnFocus="True">
                </telerik:RadDatePicker>
            </div>
        </div>
    </div>
    <%-- </div>
        <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Điểm xuất phát
            </div>
            <div class="input">
                <asp:TextBox ID="txtBatDau" CssClass="input-select" Width="200" runat="server" /></div>
        </div>
    </div>--%>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Ngày về
            </div>
            <div class="input">
                <%--<asp:TextBox ID="txtNgayVe" CssClass="input-select" Width="200" runat="server" />--%>
                <telerik:RadDatePicker ID="txtNgayVe" runat="server" CssClass="input-date" Width="120px" DateInput-EmptyMessage="<%$Resources:Admin, Admin_Article_SelectDate%>"
                    DateInput-DateFormat="dd/MM/yyyy" ShowPopupOnFocus="True">
                </telerik:RadDatePicker>
            </div>
        </div>
    </div>
    <div class="frow hidden">
        <div class="frow-wrapp">
            <div class="label">
                Điểm xuất phát
            </div>
            <div class="input">
                <asp:TextBox ID="txtStart" CssClass="input-text" Width="100" runat="server" ClientIDMode="Static" />
            </div>
        </div>
    </div>
    <div class="frow hidden">
        <div class="frow-wrapp">
            <div class="label">
                Điểm kết thúc
            </div>
            <div class="input">
                <asp:TextBox ID="txtEnd" CssClass="input-text" Width="100" runat="server" ClientIDMode="Static" />
            </div>
        </div>
    </div>

    <div class="frow hidden">
        <div class="frow-wrapp">
            <div class="label">
                txthighlight
            </div>
            <div class="input">
                <asp:TextBox ID="txthighlight" CssClass="input-text" Width="95%" runat="server" ClientIDMode="Static" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Lịch trình 
            </div>
            <div class="input">
                <telerik:RadComboBox ClientIDMode="Static" ID="ddlLichTrinh" runat="Server" HighlightTemplatedItems="true" Width="200" CssClass="input-select"
                    DataTextField="Name" DataValueField="TourRouteID" CheckBoxes="True" CollapseDelay="300" AllowCustomText="false" OnClientDropDownClosed="OnClientDropDownClosedHandler" CheckedItemsTexts="DisplayAllInInput">
                </telerik:RadComboBox>
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Lịch trình hiển thị
            </div>
            <div class="input">
                <asp:TextBox ID="txtLichTrinhHienThi" CssClass="input-select" Width="95%" runat="server" ClientIDMode="Static" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Khởi hành
            </div>
            <div class="input">
                <asp:TextBox ID="txtKhoiHanh" CssClass="input-select" Width="95%" runat="server" ClientIDMode="Static" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Phương tiện
            </div>
            <div class="input">
                <telerik:RadComboBox ID="ddlPhuongTien" runat="Server" HighlightTemplatedItems="true" Width="200" CssClass="input-select" CheckedItemsTexts="DisplayAllInInput"
                    DataTextField="TenPhuongTien" DataValueField="TransportationID" CheckBoxes="True" CollapseDelay="300" AllowCustomText="false"
                    OnClientDropDownClosed="ddlPhuongTien_OnClientDropDownClosedHandler" ClientIDMode="Static">
                </telerik:RadComboBox>
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Phương tiện hiển thị
            </div>
            <div class="input">
                <asp:TextBox ID="txtPhuongTienHienThi" CssClass="input-select" Width="95%" runat="server" ClientIDMode="Static" />
            </div>
        </div>
    </div>
    <div class="frow hidden">
        <div class="frow-wrapp">
            <div class="label">
                Khởi hành từ
            </div>
            <div class="input">
                <telerik:RadComboBox ClientIDMode="Static" ID="ddlKhoiHanhTu" runat="Server" HighlightTemplatedItems="true" Width="200" CssClass="input-select"
                    DataTextField="Name" DataValueField="TourRouteID" CollapseDelay="300" AllowCustomText="false">
                </telerik:RadComboBox>
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Giới thiệu chung
            </div>
            <div class="input">
                <bic:Editor Height="600px" Width="98%" ID="reGioiThieuChung" EnableResize="true" ToolbarMode="RibbonBar" ToolsFile="~/admin/XMLData/Editor/RibbonFullSetOfTools.xml"
                    runat="server" StripFormattingOnPaste="NoneSupressCleanMessage, MSWord, MSWordNoFonts" Skin="Office2007" />
            </div>
        </div>
    </div>
    <div class="frow" runat="server" visible="true">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock12" runat="server">
                    <%-- <%=BicResource.GetValue("Admin","Admin_Controls_DetailedContent") %>--%>
                    Lịch trình chi tiết
                </telerik:RadCodeBlock>
            </div>
            <div class="input">
                <bic:Editor Height="600px" Width="98%" ID="reGioiThieuChiTiet" EnableResize="true" ToolbarMode="RibbonBar" ToolsFile="~/admin/XMLData/Editor/RibbonFullSetOfTools.xml"
                    runat="server" StripFormattingOnPaste="NoneSupressCleanMessage, MSWord, MSWordNoFonts" Skin="Office2007" />
            </div>
        </div>
    </div>

    <div class="frow hidden">
        <div class="frow-wrapp">
            <div class="label">
                Lịch khởi hành
            </div>
            <div class="input">
                <bic:Editor Height="600px" Width="98%" ID="reMota3" EnableResize="true" ToolbarMode="RibbonBar" ToolsFile="~/admin/XMLData/Editor/RibbonFullSetOfTools.xml"
                    runat="server" StripFormattingOnPaste="NoneSupressCleanMessage, MSWord, MSWordNoFonts" Skin="Office2007" />
            </div>
        </div>
    </div>

    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Chi tiết giá
            </div>
            <div class="input">
                <bic:Editor Height="600px" Width="98%" ID="txtChiTietGia" EnableResize="true" ToolbarMode="RibbonBar" ToolsFile="~/admin/XMLData/Editor/RibbonFullSetOfTools.xml"
                    runat="server" StripFormattingOnPaste="NoneSupressCleanMessage, MSWord, MSWordNoFonts" Skin="Office2007" />
            </div>
        </div>
    </div>
    <div class="frow hidden">
        <div class="frow-wrapp">
            <div class="label">
                Tags
            </div>
            <div class="input">
                <asp:TextBox ID="txtTag" CssClass="input-text" Width="500" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow" style="display: none">
        <div class="frow-wrapp">
            <div class="label">
                Tiêu đề SEO
            </div>
            <div class="input">
                <asp:TextBox runat="server" ID="txtSeoTitle" CssClass="input-text" Width="95%" />
            </div>
        </div>
    </div>
    <div class="frow" runat="server" visible="true">
        <div class="frow-wrapp">
            <div class="label">
                Video
            </div>
            <
            <div class="input">
                <bic:Editor Height="600px" Width="98%" ID="reVideo" EnableResize="true" ToolbarMode="RibbonBar" ToolsFile="~/admin/XMLData/Editor/RibbonFullSetOfTools.xml"
                    runat="server" StripFormattingOnPaste="NoneSupressCleanMessage, MSWord, MSWordNoFonts" Skin="Office2007" />
            </div>
            <%-- <div class="input">
                <asp:TextBox runat="server" ID="txtLinkVideo" CssClass="input-text" Width="95%" />
            </div>--%>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock9" runat="server">
                    <%=BicResource.GetValue("Admin","System_Priority") %>
                </telerik:RadCodeBlock>
            </div>
            <div class="input">
                <asp:TextBox ID="txtPosition" CssClass="input-text" Width="100" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow hidden">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock11" runat="server">
                    <%=BicResource.GetValue("Admin","Admin_Adv_Views") %>
                </telerik:RadCodeBlock>
            </div>
            <div class="input">
                <asp:TextBox ID="txtLuotXem" CssClass="input-text" Width="100" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock8" runat="server">
                    <%=BicResource.GetValue("Admin","System_New") %>
                </telerik:RadCodeBlock>
            </div>
            <div class="input">
                <asp:CheckBox ID="chkIsNew" CssClass="" Width="" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow hidden">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock6" runat="server">
                    <%=BicResource.GetValue("Admin","System_Hot") %>
                </telerik:RadCodeBlock>
            </div>
            <div class="input">
                <asp:CheckBox ID="chkIsHot" CssClass="" Width="" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock10" runat="server">
                    <%=BicResource.GetValue("Admin","System_Browse") %>
                </telerik:RadCodeBlock>
            </div>
            <div class="input">
                <asp:CheckBox runat="server" Enable="<%#Approved%>" Checked="true" ID="chkIsActive" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock27" runat="server">
                    <%=BicResource.GetValue("Admin","Admin_Article_PageTitle") %>
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
                    <%=BicResource.GetValue("Admin","System_MetaDescription") %>
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
                    <%=BicResource.GetValue("Admin","System_MetaKeyword") %>
                </telerik:RadCodeBlock>
            </div>
            <div class="input">
                <asp:TextBox runat="server" ID="txtMetaKeyword" MaxLength="170" CssClass="input-text" Width="85%" />
                (Max 170)
            </div>
        </div>
    </div>

    <div class="form-tool-bottom">
        <bic:ToolBar ID="tbBottom" runat="server" />
        <asp:LinkButton ID="lbtnSave2" CssClass="btn-save" runat="server" OnCommand="Save" CommandName="Update">
            <telerik:RadCodeBlock ID="RadCodeBlock18" runat="server">
                <%=BicResource.GetValue("Admin","Admin_Save") %>
            </telerik:RadCodeBlock>
        </asp:LinkButton>
    </div>
</div>
<telerik:RadInputManager runat="server" ID="rimBICCMS" EnableEmbeddedSkins="false" Skin="BICCMS">
    <telerik:TextBoxSetting BehaviorID="bhTenTour" EmptyMessage="Nhập tên tour" Validation-IsRequired="true">
        <TargetControls>
            <telerik:TargetInput ControlID="txtTenTour" />
        </TargetControls>
    </telerik:TextBoxSetting>
    <%--<telerik:NumericTextBoxSetting BehaviorID="bhSoNgay" DecimalDigits="0">
        <TargetControls>
            <telerik:TargetInput ControlID="txtSoNgay" />
        </TargetControls>
    </telerik:NumericTextBoxSetting>--%>
    <telerik:NumericTextBoxSetting BehaviorID="bhSoDem" DecimalDigits="0">
        <TargetControls>
            <telerik:TargetInput ControlID="txtSoDem" />
        </TargetControls>
    </telerik:NumericTextBoxSetting>
    <telerik:NumericTextBoxSetting BehaviorID="bhPriority" DecimalDigits="0">
        <TargetControls>
            <telerik:TargetInput ControlID="txtPriority" />
        </TargetControls>
    </telerik:NumericTextBoxSetting>
    <telerik:NumericTextBoxSetting BehaviorID="bhLuotXem" DecimalDigits="0">
        <TargetControls>
            <telerik:TargetInput ControlID="txtLuotXem" />
        </TargetControls>
    </telerik:NumericTextBoxSetting>
</telerik:RadInputManager>
