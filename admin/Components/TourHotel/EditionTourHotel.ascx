<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditionTourHotel.ascx.cs" Inherits="Admin_Components_TourHotel_EditionTourHotel" %>
<%@ Register Src="~/admin/Components/ImageGallery/ImageSelector.ascx" TagName="ImageSelector" TagPrefix="bic" %>
<%@ Register Src="~/admin/Components/ImageGallery/ImageSelectMulti.ascx" TagName="ImageSelectorMulti" TagPrefix="bic" %>
<div class="form-tool">
    <bic:ToolBar ID="tbTop" runat="server" />
    <asp:LinkButton ID="lbtnSave" CssClass="btn-save" runat="server" OnCommand="Save" CommandName="Update"></asp:LinkButton>
</div>
<div class="form-caption">
    <%=BIC.Utils.BicMessage.EditTitle%>
    <span class="note"><em>*</em>
        <%=BIC.Utils.BicMessage.RequireTitle%>
    </span>
</div>
<div class="form-view">
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Ngôn ngữ
            </div>
            <div class="input">
                <bic:Language ID="ddlLanguage" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Tên khách sạn<span class="validate">*</span>
            </div>
            <div class="input">
                <asp:TextBox ID="txtTenKhachSan" CssClass="input-select" Width="95%" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Thành phố
            </div>
            <div class="input">
                <telerik:RadTreeView runat="server" Skin="Outlook" Width="500px" CheckBoxes="true" ID="tvMenuUser" PersistLoadOnDemandNodes="true"
                    LoadingStatusPosition="AfterNodeText" CollapseAnimation-Duration="200" ExpandAnimation-Duration="200" ExpandAnimation-Type="InQuart"
                    SingleExpandPath="False">
                </telerik:RadTreeView>
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Loại đánh giá
            </div>
            <div class="input">
                <telerik:RadComboBox ClientIDMode="Static" ID="ddlKieu" runat="Server" HighlightTemplatedItems="true" Width="200" CssClass="input-select"
                    CollapseDelay="300" AllowCustomText="false">
                    <Items>
                        <telerik:RadComboBoxItem Value="Hotel" Text="Hotel" />
                        <telerik:RadComboBoxItem Value="Resort" Text="Resort" />
                    </Items>
                </telerik:RadComboBox>
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Hạng
            </div>
            <div class="input">
                <telerik:RadRating ID="radRating" runat="server" ItemCount="5" SelectionMode="Continuous" Orientation="Horizontal" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Ảnh đại diện
            </div>
            <div class="input">
                <bic:ImageSelector ID="isImageId" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Ảnh khách sạn
            </div>
            <div class="input">
                <bic:ImageSelectorMulti ID="ismAnhKhachSan" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Địa chỉ
            </div>
            <div class="input">
                <asp:TextBox ID="txtDiachi" CssClass="input-text" Width="300" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Số điện thoại
            </div>
            <div class="input">
                <asp:TextBox ID="txtSoDienThoai" CssClass="input-text" Width="300" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Website
            </div>
            <div class="input">
                <asp:TextBox ID="txtWebsite" CssClass="input-text" Width="300" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Email
            </div>
            <div class="input">
                <asp:TextBox ID="txtEmail" CssClass="input-text" Width="300" runat="server" /></div>
        </div>
    </div>
    <div class="frow" style="display:none">
        <div class="frow-wrapp">
            <div class="label">
                Giá hiển thị
            </div>
            <div class="input">
                <asp:TextBox ID="txtPrice" CssClass="input-text" Width="" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Giá từ
            </div>
            <div class="input">
                <asp:TextBox ID="txtGiaTu" CssClass="input-text" Width="" runat="server" /></div>
        </div>
    </div>
    <div class="frow" style="display:none">
        <div class="frow-wrapp">
            <div class="label">
                Giá chi tiết
            </div>
            <div class="input">
                <bic:Editor Height="600px" Width="98%" ID="reGiaChiTiet" EnableResize="true" ToolbarMode="RibbonBar" ToolsFile="~/admin/XMLData/Editor/RibbonFullSetOfTools.xml"
                    runat="server" StripFormattingOnPaste="NoneSupressCleanMessage, MSWord, MSWordNoFonts" Skin="Office2007" Visible="false" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Mô tả
            </div>
            <div class="input">
                <bic:Editor Height="600px" Width="98%" ID="reMoTaChiTiet" EnableResize="true" ToolbarMode="RibbonBar" ToolsFile="~/admin/XMLData/Editor/RibbonFullSetOfTools.xml"
                    runat="server" StripFormattingOnPaste="NoneSupressCleanMessage, MSWord, MSWordNoFonts" Skin="Office2007" />
            </div>
        </div>
    </div>
    <div class="frow" style="display:none">
        <div class="frow-wrapp">
            <div class="label">
                Tags
            </div>
            <div class="input">
                <asp:TextBox ID="txtTag" CssClass="input-text" Width="500" runat="server" />
            </div>
        </div>
    </div>

    <div class="frow" style="display:none">
        <div class="frow-wrapp">
            <div class="label">
                Tiêu đề SEO
            </div>
            <div class="input">
                <asp:TextBox runat="server" ID="txtSeoTitle" CssClass="input-text" Width="95%" />
            </div>
        </div>
    </div>

    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Phòng
            </div>
            <div class="input">
                <bic:Editor Height="600px" Width="98%" ID="reRoom" EnableResize="true" ToolbarMode="RibbonBar" ToolsFile="~/admin/XMLData/Editor/RibbonFullSetOfTools.xml"
                    runat="server" StripFormattingOnPaste="NoneSupressCleanMessage, MSWord, MSWordNoFonts" Skin="Office2007" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Thiết bị phòng
            </div>
            <div class="input">
                <bic:Editor Height="600px" Width="98%" ID="reThietBiPhong" EnableResize="true" ToolbarMode="RibbonBar" ToolsFile="~/admin/XMLData/Editor/RibbonFullSetOfTools.xml"
                    runat="server" StripFormattingOnPaste="NoneSupressCleanMessage, MSWord, MSWordNoFonts" Skin="Office2007" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Lượt xem
            </div>
            <div class="input">
                <asp:TextBox ID="txtLuotXem" CssClass="input-text" Width="100" runat="server" /></div>
        </div>
    </div>
    <div class="frow hidden">
        <div class="frow-wrapp">
            <div class="label">
                Thứ tự</div>
            <div class="input">
                <asp:DropDownList runat="server" ID="ddlPosition" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Duyệt
            </div>
            <div class="input">
                <asp:CheckBox runat="server" Enable="<%#Approved%>" Checked="true" ID="chkIsActive" /></div>
        </div>
    </div>
</div>
<div class="form-tool-bottom">
    <bic:ToolBar ID="tbBottom" runat="server" />
    <asp:LinkButton ID="lbtnSave2" CssClass="btn-save" runat="server" OnCommand="Save" CommandName="Update"></asp:LinkButton>
</div>
<telerik:RadInputManager runat="server" ID="rimBICCMS" EnableEmbeddedSkins="false" Skin="BICCMS">
    <telerik:TextBoxSetting BehaviorID="bhTenKhachSan" EmptyMessage="Nhập tên khách sạn" Validation-IsRequired="true">
        <TargetControls>
            <telerik:TargetInput ControlID="txtTenKhachSan" />
        </TargetControls>
    </telerik:TextBoxSetting>
    <telerik:NumericTextBoxSetting BehaviorID="bhHang" DecimalDigits="0">
        <TargetControls>
            <telerik:TargetInput ControlID="txtHang" />
        </TargetControls>
    </telerik:NumericTextBoxSetting>
    <telerik:NumericTextBoxSetting BehaviorID="bhLuotXem" DecimalDigits="0">
        <TargetControls>
            <telerik:TargetInput ControlID="txtLuotXem" />
        </TargetControls>
    </telerik:NumericTextBoxSetting>
</telerik:RadInputManager>