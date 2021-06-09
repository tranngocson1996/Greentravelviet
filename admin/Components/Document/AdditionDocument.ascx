<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdditionDocument.ascx.cs" Inherits="Admin_Components_Document_AdditionDocument" %>
<%=IncludeAdmin.TreeView() %>
<%=IncludeAdmin.Autocomplete() %>
<div class="form-tool">
    <bic:ToolBar ID="tbTop" runat="server" />
    <asp:LinkButton ID="lbtnSave" CssClass="btn-save" runat="server" OnCommand="Save" CommandName="AddNew" Text="<%$Resources:Admin,Admin_Save%>"></asp:LinkButton>
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
                <bic:Language ID="ddlLanguage" runat="server" AutoPostBack="True" CssClass="input-select" OnSelectedIndexChanged="ddlLanguage_SelectedIndexChanged" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Danh mục tài liệu
            </div>
            <div class="input">
                <bic:MenuRecursion ID="ddlDocumentTypeID" CssClass="input-select" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Tài liệu
            </div>
            <div class="input">
                <div class="upload-control">
                    <telerik:RadAsyncUpload HttpHandlerUrl="~/CustomHandler.ashx" Skin="Vista" TemporaryFolder="~/FileUpload/Temp" runat="server"
                        ID="ruDoc" AllowedFileExtensions="txt,doc,docx,ppt,pptx,xls,xlsx,pdf,tif,zip,rar,xps" OnFileUploaded="rauUpload_FileUploaded"
                        MultipleFileSelection="Automatic" TargetFolder="~/FileUpload/Documents">
                        <FileFilters>
                            <telerik:FileFilter Description="Document(*.txt,*.doc,*.docx,*.ppt, *.pptx,*.xls,*.xlsx,*.pdf,*.tif,*.zip,*.rar,*.xps)" Extensions="txt,doc,docx,ppt,pptx,xls,xlsx,pdf,tif,zip,rar,xps" />
                        </FileFilters>
                    </telerik:RadAsyncUpload>
                    <div class="note_upload">
                        ( Định dạng cho phép:*.txt,*.doc,*.docx,*.ppt, *.pptx,*.xls,*.xlsx,*.pdf,*.tif,*.zip,*.rar,*.xps)
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Tiêu đề<span class="validate">*</span>
            </div>
            <div class="input">
                <asp:TextBox ID="txtDisplayName" Width="300px" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow hidden">
        <div class="frow-wrapp">
            <div class="label">
                Số văn bản
            </div>
            <div class="input">
                <div class="err">
                </div>
                <asp:TextBox ID="txtDocumentNo" CssClass="input-text" Width="90px" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Lượt xem
            </div>
            <div class="input">
                <asp:TextBox ID="txtViewNo" CssClass="input-text" Width="100px" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Trích yếu
            </div>
            <div class="input">
                <asp:TextBox ID="txtBriefDescription" CssClass="input-area" Width="290px" runat="server" TextMode="MultiLine" />
            </div>
        </div>
    </div>
    <div class="hidden ">
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Quyền xem
            </div>
            <div class="input">
                <asp:TextBox ID="txtUserNameView" CssClass="input-area" Width="290px" runat="server" ClientIDMode="Static" TextMode="MultiLine" />
                <img id="imgview" src='<%=Page.ResolveUrl("~/Styles/img/Quyen.png") %>' class="imguser" alt="" />
            </div>
        </div>
    </div>
    <div id="listuserview">
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Quyền sửa
            </div>
            <div class="input">
                <asp:TextBox ID="txtUserNameEdit" CssClass="input-area" Width="290px" runat="server" ClientIDMode="Static" TextMode="MultiLine" />
                <img id="imgedit" src='<%=Page.ResolveUrl("~/Styles/img/Quyen.png") %>' class="imguser" alt="" />
            </div>
        </div>
    </div>
    <div id="listuseredit">
    </div>
        </div>
      <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Mới
            </div>
            <div class="input">
                <asp:CheckBox ID="chkIsNews" CssClass="" Width="40" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Duyệt
            </div>
            <div class="input">
                <asp:CheckBox ID="chkIsActive" CssClass="" Width="40" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow hidden">
        <div class="frow-wrapp">
            <div class="label">
                Dạng tài liệu
            </div>
            <div class="input">
                <asp:CheckBox ID="chkIsNew" CssClass="" Width="40" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Thứ tự
            </div>
            <div class="input">
                <%--  <asp:DropDownList runat="server" ID="ddlPosition" />--%>
                <telerik:RadNumericTextBox ShowSpinButtons="true" IncrementSettings-InterceptArrowKeys="true"
                    IncrementSettings-InterceptMouseWheel="true" Value="1" LabelWidth="" runat="server"
                    ID="ntxPosition" Width="120px" DataType="System.Int64" MinValue="1">
                    <NumberFormat ZeroPattern="n" AllowRounding="False"></NumberFormat>
                </telerik:RadNumericTextBox>
            </div>
        </div>
    </div>
</div>
<div class="form-tool-bottom">
    <bic:ToolBar ID="tbBottom" runat="server" />
    <asp:LinkButton ID="lbtnSave2" CssClass="btn-save" runat="server" OnCommand="Save" CommandName="AddNew" Text="<%$Resources:Admin,Admin_Save%>"></asp:LinkButton>
</div>
<telerik:RadInputManager runat="server" ID="rimBICCMS" EnableEmbeddedSkins="false" Skin="BICCMS">
    <telerik:TextBoxSetting BehaviorID="bhDisplayName" EmptyMessage="Nhập tiêu đề" Validation-IsRequired="true">
        <TargetControls>
            <telerik:TargetInput ControlID="txtDisplayName" />
        </TargetControls>
    </telerik:TextBoxSetting>
    <telerik:NumericTextBoxSetting BehaviorID="bhViewNo" EmptyMessage="Nhập lượt xem" DecimalDigits="0">
        <TargetControls>
            <telerik:TargetInput ControlID="txtViewNo" />
        </TargetControls>
    </telerik:NumericTextBoxSetting>
</telerik:RadInputManager>
