<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ImageManagerForVideo.ascx.cs" Inherits="admin_Components_ImageGallery_ImageManagerForVideo" %>
<%@ Import Namespace="BIC.Utils" %>
<telerik:RadCodeBlock runat="server">
    <%= IncludeAdmin.DefaultCss() %>
    <%= IncludeAdmin.JqueryUI() %>
    <%= IncludeAdmin.AdminImageManager() %>
    <%= IncludeAdmin.JsImageGalleryForVideo() %>
    <%= IncludeAdmin.HighSlide() %>
    <script type="text/javascript">
        hs.graphicsDir = '<%= Page.ResolveUrl("~/admin/Scripts/highslide/graphics/") %>';
    </script>
</telerik:RadCodeBlock>
<telerik:RadScriptManager runat="server">
</telerik:RadScriptManager>
<telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
    <%--<asp:HiddenField ID="hdfLangForVideo" runat="server" />--%>
    <asp:HiddenField ID="hdfLangManager" runat="server" ClientIDMode="Static" />
    <div class="body_view">
        <%--<div class="gallery_caption">
           
            <div class="img_name_gallery">
                <asp:TextBox runat="server" ID="txtName" CssClass="input-text" AutoPostBack="True" OnTextChanged="txtName_TextChanged" />
            </div>
            <div class="search_button_gallery">
                <asp:LinkButton runat="server" ID="btnSearch" OnClick="btnSearch_Click"></asp:LinkButton>
            </div>
            <div class="separator">
            </div>
        </div>--%>
        <div class="text_result">
            <div class="cate_gallery">
                <%-- Ảnh thuộc danh mục--%>
                <telerik:RadCodeBlock ID="RadCodeBlock4" runat="server">
                    <%= BicResource.GetValue("Admin", "Admin_Gallery_ImageType") %>
                </telerik:RadCodeBlock>
                <asp:DropDownList ID="ddlImageTypeID" runat="server" CssClass="input-select" AutoPostBack="True" OnSelectedIndexChanged="ddlImageTypeID_SelectedIndexChanged" />
            </div>
            <%--<asp:Label runat="server" ID="lblMessage" Text=""></asp:Label>--%>
            <div class="uncheckmark ckhall">
                <%-- Chọn tất cả--%>
                <telerik:RadCodeBlock ID="RadCodeBlock2" runat="server">
                    <%= BicResource.GetValue("Admin", "Admin_Gallery_CheckAll") %>
                </telerik:RadCodeBlock>
            </div>
            <div id="btnAddImg">
                <%-- Chèn ảnh đã chọn--%>
                <telerik:RadCodeBlock ID="RadCodeBlock3" runat="server">
                    <%= BicResource.GetValue("Admin", "Admin_Gallery_InsertImage") %>
                </telerik:RadCodeBlock>
            </div>
            <div id="btnDelImg">
                <%-- Xóa ảnh đã chọn--%>
                <telerik:RadCodeBlock ID="RadCodeBlock5" runat="server">
                    <%= BicResource.GetValue("Admin", "Admin_Gallery_DeleteImage") %>
                </telerik:RadCodeBlock>
            </div>
        </div>
        <!-- END MESSAGE -->
        <!--- khung anh -->
        <div class="frame_gallery" id="frame_gallery">
            <asp:HiddenField ID="hdImageManager" runat="server" ClientIDMode="Static" />
            <asp:ListView ID="dlImage" runat="server" RepeatColumns="5" OnItemDataBound="dlImage_ItemDataBound">
                <ItemTemplate>
                    <div class='<%# (Container.DataItemIndex + 1)%5 != 0 ? "img_detail" : "img_detail img_right" %>'>
                        <div class="uncheckmark chkimg" id='<%# Eval("ImageID") %>'>
                        </div>
                        <div class="size">
                            <%# !string.IsNullOrEmpty(Convert.ToString(Eval("Name"))) ? (Eval("Width") + " x") : string.Empty %>
                            <%# !string.IsNullOrEmpty(Convert.ToString(Eval("Name"))) ? Eval("Height") : string.Empty %>
                        </div>
                        <div class="image" title='<%# Eval("Name") %>'>
                            <img id="htmlImage" class='<%# Eval("ImageID") %>' style="cursor: pointer" src="" runat="server" clientidmode="Static" />
                        </div>
                        <div class="action">
                            <a runat="server" id="fullExpand">Zoom</a>&nbsp;|
                            <a href="#" onclick=' return EditImage("<%# Eval("Name") %>","<%# Eval("ImageID") %>");return false;'>Edit</a>&nbsp;|
                            <asp:LinkButton runat="server" ID="lbtnDelete" OnCommand="Action" OnClientClick="return confirm('Bạn chắc chắn muốn xóa ảnh?')" CommandName="Delete" CommandArgument='<%# Eval("ImageID") %>'>Delete</asp:LinkButton>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
        <div class="paging">
            <bic:PagerUI ID="Pager1" runat="server" CssClass="pagerImg" PageSize="10" OnPageIndexChanged="Pager1_PageIndexChanged" Next=">>" Previous="<<" />
        </div>
    </div>
</telerik:RadAjaxPanel>
<telerik:RadAjaxLoadingPanel runat="server" Skin="Windows7" ID="RadAjaxLoadingPanel1" BackgroundPosition="Center" EnableSkinTransparency="true">
</telerik:RadAjaxLoadingPanel>