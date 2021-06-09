<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditionVideoType.ascx.cs" Inherits="Admin_Components_VideoType_EditionVideoType" %>
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
    <div class="frow"> <div class="frow-wrapp"> <div class="label">Kiểu video<span class="validate">*</span> </div> <div class="input"><asp:TextBox ID="txtName" CssClass="input-text" Width="95%" runat="server"/></div></div></div>
    <div class="frow"> <div class="frow-wrapp"> <div class="label">Code nhúng </div> <div class="input"><telerik:RadEditor Height="300px" Width="98%" ID="reEmbedCode" EnableResize="true" ToolbarMode="ShowOnFocus" ToolsFile="~/admin/XMLData/Editor/SmallSetOfTools.xml" EnableViewState="False" runat="server" Skin="Windows7" StripFormattingOnPaste="MSWord" ContentAreaCssFile="~/BICSkins/BICCMS/Editor/EditorContentAreaStyles.css"> <ImageManager DeletePaths="~/FileUpload/Images/Editor" UploadPaths="~/FileUpload/Images/Editor" ViewPaths="~/FileUpload/Images/Editor" MaxUploadFileSize="1024000" /> <DocumentManager DeletePaths="~/FileUpload/Documents" UploadPaths="~/FileUpload/Documents" ViewPaths="~/FileUpload/Documents" MaxUploadFileSize="10240000" /> <FlashManager DeletePaths="~/FileUpload/Flashs" UploadPaths="~/FileUpload/Flashs" ViewPaths="~/FileUpload/Flashs" MaxUploadFileSize="10240000" /> <MediaManager MaxUploadFileSize="10240000" DeletePaths="~/FileUpload/Medias" UploadPaths="~/FileUpload/Medias" ViewPaths="~/FileUpload/Medias" /> <TemplateManager DeletePaths="~/FileUpload/Templates" MaxUploadFileSize="10240000" UploadPaths="~/FileUpload/Templates" ViewPaths="~/FileUpload/Templates" /> </telerik:RadEditor></div> </div></div>
    <div class="frow"> <div class="frow-wrapp"> <div class="label">Duyệt </div> <div class="input"><asp:CheckBox ID="chkIsActive" CssClass="" Width="" runat="server"/></div></div></div>
</div>
<div class="form-tool-bottom">
    <bic:ToolBar ID="tbBottom" runat="server" />
    <asp:LinkButton ID="lbtnSave2" CssClass="btn-save" runat="server" OnCommand="Save"
                    CommandName="Update"></asp:LinkButton>
</div>
<telerik:RadInputManager runat="server" ID="rimBICCMS" EnableEmbeddedSkins="false" Skin="BICCMS">
    <telerik:TextBoxSetting BehaviorID="bhName" EmptyMessage="Nhập kiểu video" Validation-IsRequired="true"><TargetControls><telerik:TargetInput ControlID="txtName" /></TargetControls></telerik:TextBoxSetting>


</telerik:RadInputManager>