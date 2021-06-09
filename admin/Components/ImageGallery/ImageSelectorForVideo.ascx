<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ImageSelectorForVideo.ascx.cs" Inherits="admin_Components_ImageGallery_ImageSelectorForVideo" %>
<%= IncludeAdmin.JsImageSelectorForVideo() %>
<div id="ImageGallerySelect">
    <div class="image-selector">
    </div>
    <input id="hdImageID" runat="server" type="hidden" value="0" clientidmode="Static" />
</div>