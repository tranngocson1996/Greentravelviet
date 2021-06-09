<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewSearch.ascx.cs" Inherits="Admin_Components_Search_ViewSearch" %>


<div class="form-tool">
    <bic:ToolBar ID="tbTop" runat="server" />
</div>
<div class="form-caption">
    Chi tiết nội dung
</div>
<div class ="form-view">
    <div class="frow"> <div class="frow-wrapp"> <div class="label">Mô tả </div> <div class="input"><asp:Label ID="lblDBDescription" CssClass="Label" runat="server"/></div></div> </div>
    <div class="frow"> <div class="frow-wrapp"> <div class="label">Từ khóa </div> <div class="input"><asp:Label ID="lblDBKeyword" CssClass="Label" runat="server"/></div></div> </div>
    <div class="frow"> <div class="frow-wrapp"> <div class="label">Ảnh </div> <div class="input"> <img runat="server" id="isImageID" /></div></div> </div>
    <div class="frow"> <div class="frow-wrapp"> <div class="label">Link </div> <div class="input"><asp:Label ID="lblDBLink" CssClass="Label" runat="server"/></div></div> </div>

    <div class="frow"> <div class="frow-wrapp"> <div class="label">Duyệt </div> <div class="input"><asp:CheckBox Enabled="false" ID="chkIsActive"  runat="server"></asp:CheckBox></div></div> </div>
</div>
<div class="form-tool-bottom">
    <bic:ToolBar ID="tbBottom" runat="server" />
</div>