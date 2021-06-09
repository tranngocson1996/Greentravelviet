<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdditionFAQ.ascx.cs" Inherits="Admin_Components_FAQ_AdditionFAQ" %>
<div class="form-tool">
    <bic:ToolBar ID="tbTop" runat="server" />
    <asp:LinkButton ID="lbtnSave" CssClass="btn-save" runat="server" OnCommand="Save" CommandName="AddNew">Lưu nội dung</asp:LinkButton>
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
                <bic:Language ID="ddlLanguage" runat="server" OnSelectedIndexChanged="ddlLanguage_SelectedIndexChanged" AutoPostBack="true" />
            </div>
        </div>
    </div>


    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Tiêu đề<span class="validate">*</span>
            </div>
            <div class="input">
                <asp:TextBox ID="txtTitle" CssClass="input-text" Width="95%" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Câu hỏi<span class="validate">*</span>
            </div>
            <div class="input">
                <telerik:RadEditor Height="300px" Width="98%" ID="txtFaqQuestion" EnableResize="true" ToolbarMode="ShowOnFocus" ToolsFile="~/admin/XMLData/Editor/SmallSetOfTools.xml"
                    EnableViewState="False" runat="server" Skin="Windows7" StripFormattingOnPaste="MSWord" ContentAreaCssFile="~/BICSkins/BICCMS/Editor/EditorContentAreaStyles.css">
                    <ImageManager DeletePaths="~/FileUpload/Images/Editor" UploadPaths="~/FileUpload/Images/Editor" ViewPaths="~/FileUpload/Images/Editor"
                        MaxUploadFileSize="1024000" />
                    <DocumentManager DeletePaths="~/FileUpload/Documents" UploadPaths="~/FileUpload/Documents" ViewPaths="~/FileUpload/Documents"
                        MaxUploadFileSize="10240000" />
                    <FlashManager DeletePaths="~/FileUpload/Flashs" UploadPaths="~/FileUpload/Flashs" ViewPaths="~/FileUpload/Flashs" MaxUploadFileSize="10240000" />
                    <MediaManager MaxUploadFileSize="10240000" DeletePaths="~/FileUpload/Medias" UploadPaths="~/FileUpload/Medias" ViewPaths="~/FileUpload/Medias" />
                    <TemplateManager DeletePaths="~/FileUpload/Templates" MaxUploadFileSize="10240000" UploadPaths="~/FileUpload/Templates" ViewPaths="~/FileUpload/Templates" />
                </telerik:RadEditor>
              
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Câu trả lời
            </div>
            <div class="input">
                <telerik:RadEditor Height="300px" Width="98%" ID="reFaqAnswer" EnableResize="true" ToolbarMode="ShowOnFocus" ToolsFile="~/admin/XMLData/Editor/SmallSetOfTools.xml"
                    EnableViewState="False" runat="server" Skin="Windows7" StripFormattingOnPaste="MSWord" ContentAreaCssFile="~/BICSkins/BICCMS/Editor/EditorContentAreaStyles.css">
                    <ImageManager DeletePaths="~/FileUpload/Images/Editor" UploadPaths="~/FileUpload/Images/Editor" ViewPaths="~/FileUpload/Images/Editor"
                        MaxUploadFileSize="1024000" />
                    <DocumentManager DeletePaths="~/FileUpload/Documents" UploadPaths="~/FileUpload/Documents" ViewPaths="~/FileUpload/Documents"
                        MaxUploadFileSize="10240000" />
                    <FlashManager DeletePaths="~/FileUpload/Flashs" UploadPaths="~/FileUpload/Flashs" ViewPaths="~/FileUpload/Flashs" MaxUploadFileSize="10240000" />
                    <MediaManager MaxUploadFileSize="10240000" DeletePaths="~/FileUpload/Medias" UploadPaths="~/FileUpload/Medias" ViewPaths="~/FileUpload/Medias" />
                    <TemplateManager DeletePaths="~/FileUpload/Templates" MaxUploadFileSize="10240000" UploadPaths="~/FileUpload/Templates" ViewPaths="~/FileUpload/Templates" />
                </telerik:RadEditor>
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Tên người gửi
            </div>
            <div class="input">
                <asp:TextBox ID="txtFullName" CssClass="input-text" Width="200px" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Email
            </div>
            <div class="input">
                <asp:TextBox ID="txtEmail" CssClass="input-text" Width="200px" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Điện thoại
            </div>
            <div class="input">
                <asp:TextBox ID="txtMobile" CssClass="input-text" Width="200px" runat="server" /></div>
        </div>
    </div>

    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Duyệt
            </div>
            <div class="input">
                <asp:CheckBox ID="chkIsActive" CssClass="" Width="" runat="server" /></div>
        </div>
    </div>
</div>
<div class="form-tool-bottom">
    <bic:ToolBar ID="tbBottom" runat="server" />
    <asp:LinkButton ID="lbtnSave2" CssClass="btn-save" runat="server" OnCommand="Save" CommandName="AddNew">Lưu nội dung</asp:LinkButton>
</div>
<telerik:RadInputManager runat="server" ID="rimBICCMS" EnableEmbeddedSkins="false" Skin="BICCMS">
    <telerik:TextBoxSetting BehaviorID="bhTitle" EmptyMessage="Nhập tiêu đề" Validation-IsRequired="true">
        <TargetControls>
            <telerik:TargetInput ControlID="txtTitle" />
        </TargetControls>
    </telerik:TextBoxSetting>
    <telerik:TextBoxSetting BehaviorID="bhFaqQuestion" EmptyMessage="Nhập câu hỏi" Validation-IsRequired="true">
        <TargetControls>
            <telerik:TargetInput ControlID="txtFaqQuestion" />
        </TargetControls>
    </telerik:TextBoxSetting>
</telerik:RadInputManager>