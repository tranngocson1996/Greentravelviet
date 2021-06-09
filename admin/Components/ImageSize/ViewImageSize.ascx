<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewImageSize.ascx.cs" Inherits="Admin_Components_ImageSize_ViewImageSize" %>


<div class="form-tool">
    <bic:ToolBar ID="tbTop" runat="server" />
</div>
<div class="form-caption">
    Chi tiết nội dung
</div>
<div class ="form-view">
    <div class="frow"> <div class="frow-wrapp"> <div class="label">Tiêu đề<span class="validate">*</span> </div> <div class="input"><asp:Label ID="lblDBName" CssClass="Label" runat="server"/></div></div> </div>
    <div class="frow"> <div class="frow-wrapp"> <div class="label">Rộng </div> <div class="input"><asp:Label ID="lblDBImageWidth" CssClass="Label" runat="server"/></div></div> </div>
    <div class="frow"> <div class="frow-wrapp"> <div class="label">Cao </div> <div class="input"><asp:Label ID="lblDBImageHeight" CssClass="Label" runat="server"/></div></div> </div>
    <div class="frow"> <div class="frow-wrapp"> <div class="label">Mặc định </div> <div class="input"><asp:CheckBox Enabled="false" ID="chkIsActive"  runat="server"></asp:CheckBox></div></div> </div>
</div>
<div class="form-tool-bottom">
    <bic:ToolBar ID="tbBottom" runat="server" />
</div>