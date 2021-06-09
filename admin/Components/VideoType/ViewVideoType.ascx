<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewVideoType.ascx.cs" Inherits="Admin_Components_VideoType_ViewVideoType" %>


<div class="form-tool">
    <bic:ToolBar ID="tbTop" runat="server" />
</div>
<div class="form-caption">
    Chi tiết nội dung
</div>
<div class ="form-view">
    <div class="frow"> <div class="frow-wrapp"> <div class="label">Kiểu video<span class="validate">*</span> </div> <div class="input"><asp:Label ID="lblDBName" CssClass="Label" runat="server"/></div></div> </div>
    <div class="frow"> <div class="frow-wrapp"> <div class="label">Code nhúng </div> <div class="input"><asp:Label ID="lblDBEmbedCode" CssClass="Label" runat="server"/></div></div> </div>
    <div class="frow"> <div class="frow-wrapp"> <div class="label">Duyệt </div> <div class="input"><asp:CheckBox Enabled='<%# Approved %>'  ID="chkIsActive"  runat="server"></asp:CheckBox></div></div> </div>
</div>
<div class="form-tool-bottom">
    <bic:ToolBar ID="tbBottom" runat="server" />
</div>