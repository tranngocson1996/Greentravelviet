<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdditionTourType.ascx.cs" Inherits="Admin_Components_TourType_AdditionTourType" %>
<div class="form-tool">
    <bic:ToolBar ID="tbTop" runat="server" />
    <asp:LinkButton ID="lbtnSave" CssClass="btn-save" runat="server" OnCommand="Save" CommandName="AddNew"></asp:LinkButton>
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
                Tên hình thức<span class="validate">*</span>
            </div>
            <div class="input">
                <asp:TextBox ID="txtTenHinhThuc" CssClass="input-select" Width="95%" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Mô tả
            </div>
            <div class="input">
                <script type="text/javascript" src='<%=Page.ResolveUrl("~/admin/Scripts/telerik/radedit.js") %>'></script>
                <bic:Editor Height="600px" Width="98%" ID="reMota" EnableResize="true" ToolbarMode="RibbonBar" ToolsFile="~/admin/XMLData/Editor/RibbonFullSetOfTools.xml"
                    runat="server" StripFormattingOnPaste="NoneSupressCleanMessage, MSWord, MSWordNoFonts" Skin="Office2007" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Thứ tự
            </div>
            <div class="input">
                <asp:DropDownList ID="ddlPriority" CssClass="input-select" Width="50" runat="server" />
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
    <asp:LinkButton ID="lbtnSave2" CssClass="btn-save" runat="server" OnCommand="Save" CommandName="AddNew"></asp:LinkButton>
</div>
<telerik:RadInputManager runat="server" ID="rimBICCMS" EnableEmbeddedSkins="false" Skin="BICCMS">
    <telerik:TextBoxSetting BehaviorID="bhTenHinhThuc" EmptyMessage="Nhập tên hình thức" Validation-IsRequired="true">
        <TargetControls>
            <telerik:TargetInput ControlID="txtTenHinhThuc" />
        </TargetControls>
    </telerik:TextBoxSetting>
</telerik:RadInputManager>