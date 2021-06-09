<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UploadImageForVideo.ascx.cs" Inherits="admin_Components_ImageGallery_UploadImageForVideo" %>
<%= IncludeAdmin.DefaultCss() %>
<%= IncludeAdmin.JqueryUI() %>
<%= IncludeAdmin.HighSlide() %>
<%= IncludeAdmin.AdminImageUpload() %>
<%= IncludeAdmin.AdminImageManager() %>
<telerik:RadScriptManager runat="server">
</telerik:RadScriptManager>
<div class="body_view">
    <%-- <div class="gallery_caption2">
        <div class="upload-left">
            <span>1.</span> Chọn danh mục chứa ảnh tải lên
        </div>
        <div class="upload-right">
            <span>2.</span> Chọn ảnh tải lên
        </div>
    </div>--%>
    <div class="upload-frame">
        <div class="upload-left">
            <div class="select-category">
                <asp:DropDownList ID="ddlImageTypeID" runat="server" CssClass="input-select" Width="178" />
                <asp:RequiredFieldValidator ID="rfvImageType" runat="server" ErrorMessage="Chưa chọn danh mục chứa ảnh" ToolTip="Chưa chọn danh mục chứa ảnh" InitialValue="0" ControlToValidate="ddlImageTypeID"></asp:RequiredFieldValidator>
            </div>
            <div>
                <a class="edit-category" href='../../Components/ImageType/ImageTypeManager.htm'>Sửa, Thêm mới danh mục ảnh</a>
            </div>
            <div class="resize">
                <asp:RadioButtonList runat="server" ID="rblResizeWidth">
                </asp:RadioButtonList>
                <span>Chiều cao ảnh sẽ tự động thay đổi đúng tỷ lệ với chiều rộng ảnh đã chọn</span>
            </div>
        </div>
        <div class="upload-right upload-right-user" style="height: 341px">
            <div id="accordion">
                <h3>
                    <a href="#section1">Upload ảnh từ máy tính của bạn</a></h3>
                <div class="upload-control1" id="imgupload">
                    <telerik:RadAsyncUpload OnClientValidationFailed="validationFailed" HttpHandlerUrl="~/CustomHandler.ashx" OnClientFileUploaded="onClientFileUploaded" Skin="Vista"
                                            OnClientAdded="added" TemporaryFolder="~/FileUpload/Temp" runat="server" ID="ruImage" AllowedFileExtensions="jpg,jpeg,png,gif,bmp" OnFileUploaded="rauUpload_FileUploaded"
                                            MultipleFileSelection="Automatic" ClientIDMode="Static" Localization-Remove="Xóa" Localization-Select="Chọn ảnh">
                        <FileFilters>
                            <telerik:FileFilter Description="Ảnh (jpg, jpeg, png, gif, bmp)" Extensions="jpg,jpeg,png,gif,bmp" />
                        </FileFilters>
                    </telerik:RadAsyncUpload>
                    <div class="telerik">
                    </div>
                    <div class="note_upload">
                        - Định dạng ảnh hỗ trợ : <b>*.gif, *.jpg, *.jpeg,*.png, *.bmp.</b><br />
                        - Hỗ trợ kéo thả ảnh từ máy tính để upload.<br />
                        - Trình duyệt hỗ trợ kéo thả: <b>FireFox 4.0+, Chrome, Safari 5.0+</b>
                    </div>
                    <div class="ErrorHolder">
                    </div>
                </div>

            </div>

        </div>
    </div>
    <div class="gallery_caption2">
        <div class="upload-left">
            Hoàn tất tải ảnh <span>>></span>
        </div>
        <div class="upload-right">
            <asp:Button ID="btnUpload" runat="server" CssClass="input-finish" OnClick="btnUpload_Click" />
        </div>
    </div>
</div>