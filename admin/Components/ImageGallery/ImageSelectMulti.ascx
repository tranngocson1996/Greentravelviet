<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ImageSelectMulti.ascx.cs" Inherits="admin_Components_ImageGallery_ImageSelectMulti" %>
<%@ Import Namespace="BIC.Utils" %>
<%= IncludeAdmin.JsImageSelectMulti() %>
<div class="image-muti">
    <div id="ImageGalleryMulti">
        <div style="height: 24px; line-height: 24px;">
            <span class="title arrow"><%--Bộ ảnh--%>
                <telerik:RadCodeBlock ID="RadCodeBlock4" runat="server">
                    <%= BicResource.GetValue("Admin", "Admin_Gallery_Boanh") %>
                </telerik:RadCodeBlock>
            </span><span class="imgCount"><%--(hiện có 0 ảnh)--%>
                       <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
                           <%= BicResource.GetValue("Admin", "Admin_Gallery_Hientaico") %>
                       </telerik:RadCodeBlock>
                   </span>
        </div>
        <div class="selector">
            <div class="image" id="imageClick">
                <img id="htmlImageMulti" alt="" src='<%= Page.ResolveUrl(string.Format("~/admin/Styles/icon/select_image_{0}.jpg", BicLanguage.CurrentLanguageAdmin)) %>' border="0" />
            </div>
        </div>
        <div class="list">
            <div id="listimg">
            </div>
        </div>
        <input id="hdArrImage" runat="server" type="hidden" clientidmode="Static" />
    </div>
</div>