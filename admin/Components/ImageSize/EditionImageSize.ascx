<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditionImageSize.ascx.cs" Inherits="Admin_Components_ImageSize_EditionImageSize" %>
<%@ Import Namespace="BIC.Utils" %>
<div class="form-tool">
    <bic:ToolBar ID="tbTop" runat="server" />
    <asp:LinkButton ID="lbtnSave" CssClass="btn-save" runat="server" OnCommand="Save"
                    CommandName="Update"></asp:LinkButton>
</div>
<div class="form-caption">
    <%= BicMessage.EditTitle %> <span class="note"><em>*</em> <%= BicMessage.RequireTitle %> </span>
</div>
<div class="form-view">
    <div class="frow"> <div class="frow-wrapp"> <div class="label">Tiêu đề<span class="validate">*</span> </div> <div class="input"><asp:TextBox ID="txtName" CssClass="input-text" Width="90%" runat="server"/></div></div></div>
    <div class="frow"> <div class="frow-wrapp"> <div class="label">Rộng </div> <div class="input"><asp:TextBox ID="txtImageWidth" CssClass="input-text" Width="50px" runat="server"/></div></div></div>
    <div class="frow"> <div class="frow-wrapp"> <div class="label">Cao </div> <div class="input"><asp:TextBox ID="txtImageHeight" CssClass="input-text" Width="50px" runat="server"/></div></div></div>
    <div class="frow"> <div class="frow-wrapp"> <div class="label">Mặc định </div> <div class="input"><asp:CheckBox ID="chkIsActive" CssClass="" Width="" runat="server"/></div></div></div>
</div>
<div class="form-tool-bottom">
    <bic:ToolBar ID="tbBottom" runat="server" />
    <asp:LinkButton ID="lbtnSave2" CssClass="btn-save" runat="server" OnCommand="Save"
                    CommandName="Update"></asp:LinkButton>
</div>
<telerik:RadInputManager runat="server" ID="rimBICCMS" EnableEmbeddedSkins="false" Skin="BICCMS">
    <telerik:TextBoxSetting BehaviorID="bhName" EmptyMessage="Nhập tiêu đề" Validation-IsRequired="true"><TargetControls><telerik:TargetInput ControlID="txtName" /></TargetControls></telerik:TextBoxSetting>
    <telerik:NumericTextBoxSetting BehaviorID="bhImageWidth" DecimalDigits="0"><TargetControls><telerik:TargetInput ControlID="txtImageWidth" /></TargetControls></telerik:NumericTextBoxSetting>
    <telerik:NumericTextBoxSetting BehaviorID="bhImageHeight" DecimalDigits="0"><TargetControls><telerik:TargetInput ControlID="txtImageHeight" /></TargetControls></telerik:NumericTextBoxSetting>

</telerik:RadInputManager>