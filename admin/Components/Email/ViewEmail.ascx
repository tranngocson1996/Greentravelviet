<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewEmail.ascx.cs" Inherits="Admin_Components_Email_ViewEmail" %>

<%@ Register Assembly="BICLib" Namespace="BIC.WebControls" TagPrefix="bic" %>


<div class="form-tool">
    <bic:ToolBar ID="tbTop" runat="server" />
</div>
<div class="form-caption">
        Chi tiết nội dung
</div>
<div class ="form-view">
<div class="frow"> <div class="frow-wrapp"> <div class="label">Email đăng ký<span class="validate">*</span> </div> <div class="input"><asp:Label ID="lblDBEmail" CssClass="Label" runat="server"/></div></div> </div>
<div class="frow"> <div class="frow-wrapp"> <div class="label">Tần xuất nhận tin </div> <div class="input"><asp:Label ID="lblDBInterval" CssClass="Label" runat="server"/></div></div> </div>
<div class="frow"> <div class="frow-wrapp"> <div class="label">Lần gửi cuối </div> <div class="input"><asp:Label ID="lblDBLastSend" CssClass="Label" runat="server"/></div></div> </div>

<div class="frow"> <div class="frow-wrapp"> <div class="label">Ngày tạo </div> <div class="input"><asp:Label ID="lblDBCreatedTime" CssClass="Label" runat="server"/></div></div> </div>
<div class="frow"> <div class="frow-wrapp"> <div class="label">Duyệt </div> <div class="input"><asp:CheckBox Enabled="false" ID="chkIsActive"  runat="server"></asp:CheckBox></div></div> </div>
</div>
<div class="form-tool-bottom">
         <bic:ToolBar ID="tbBottom" runat="server" />
</div>

