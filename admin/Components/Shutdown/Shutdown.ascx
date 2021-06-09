<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Shutdown.ascx.cs" Inherits="admin_Components_Shutdown_Shutdown" %>
<telerik:RadAjaxPanel ID="rapShutdown" runat="server">
    <table class="TitleCss" width="100%">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Ngừng hoạt động hệ thống" />
            </td>
        </tr>
    </table>
    <div class="CommandArea">
        <asp:Button ID="btnUpdate" runat="server" Text="Cập nhật nội dung" OnClick="btnUpdate_Click" />
        &nbsp;
        <asp:Button ID="btnOnline" runat="server" Text="Mở hệ thống" OnClick="btnOnline_Click" />
    </div>
    <div class="EditDataTable">
        <table style="width:100%;" cellpadding="0" cellspacing="0">
            <tr>
                <td class="LeftCell">
                    Mô tả
                </td>
                <td class="RightCell">
                    &nbsp;Chức năng bật tắt ứng dụng, giúp ngừng hoạt động website để thực hiện nâng cấp, backup dữ liệu,...
                </td>
            </tr>
            <tr>
                <td class="LeftCell">
                    Trạng thái
                </td>
                <td class="RightCell">
                    &nbsp;<asp:Label Font-Bold="true" ForeColor="red" runat="server" ID="lblStatus"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <telerik:RadEditor Height="500px" ID="reNote" Width="98%" EnableResize="true" ToolbarMode="ShowOnFocus" ToolsFile="~/admin/XMLData/Editor/FullSetOfTools.xml"
                                       EnableViewState="False" runat="server" Skin="Windows7" ContentAreaCssFile="~/BICSkins/BICCMS/Editor/EditorContentAreaStyles.css"
                                       StripFormattingOnPaste="NoneSupressCleanMessage, MSWord, MSWordNoFonts">
                        <ImageManager DeletePaths="~/FileUpload/Images/Editor" UploadPaths="~/FileUpload/Images/Editor" ViewPaths="~/FileUpload/Images/Editor"
                                      MaxUploadFileSize="1024000" />
                        <DocumentManager DeletePaths="~/FileUpload/Documents" UploadPaths="~/FileUpload/Documents" ViewPaths="~/FileUpload/Documents"
                                         MaxUploadFileSize="10240000" />
                        <FlashManager DeletePaths="~/FileUpload/Flashs" UploadPaths="~/FileUpload/Flashs" ViewPaths="~/FileUpload/Flashs" MaxUploadFileSize="10240000" />
                        <MediaManager MaxUploadFileSize="10240000" DeletePaths="~/FileUpload/Medias" UploadPaths="~/FileUpload/Medias" ViewPaths="~/FileUpload/Medias" />
                        <TemplateManager DeletePaths="~/FileUpload/Templates" MaxUploadFileSize="10240000" UploadPaths="~/FileUpload/Templates" ViewPaths="~/FileUpload/Templates" />
                    </telerik:RadEditor>
                </td>
            </tr>
        </table>
    </div>
</telerik:RadAjaxPanel>