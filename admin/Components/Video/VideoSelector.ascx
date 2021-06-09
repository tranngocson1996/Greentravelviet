<%@ Control Language="C#" AutoEventWireup="true" CodeFile="VideoSelector.ascx.cs" Inherits="admin_Components_Video_VideoSelector" %>

<%= IncludeAdmin.JsVideoSelector() %>
<div id="VideoGallerySelect">
    <div class="Video-selector">
    </div>
    <input id="hdVideoID" runat="server" type="hidden" value="0" clientidmode="Static" />
</div>
<%--<bic:ImageSelector ID="isImageID" runat="server" />--%>