<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewFAQ.ascx.cs" Inherits="Admin_Components_FAQ_ViewFAQ" %>

<%@ Register Assembly="BICLib" Namespace="BIC.WebControls" TagPrefix="bic" %>


<div class="form-tool">
    <bic:ToolBar ID="tbTop" runat="server" />
</div>
<div class="form-caption">
        Chi tiết nội dung
</div>
<div class ="form-view">

<div class="frow"> <div class="frow-wrapp"> <div class="label">Tiêu đề<span class="validate">*</span> </div> <div class="input"><asp:Label ID="lblDBTitle" CssClass="Label" runat="server"/></div></div> </div>
<div class="frow"> <div class="frow-wrapp"> <div class="label">Câu hỏi<span class="validate">*</span> </div> <div class="input"><asp:Label ID="lblDBFaqQuestion" CssClass="Label" runat="server"/></div></div> </div>
<div class="frow"> <div class="frow-wrapp"> <div class="label">Câu trả lời </div> <div class="input"><asp:Label ID="lblDBFaqAnswer" CssClass="Label" runat="server"/></div></div> </div>
<div class="frow"> <div class="frow-wrapp"> <div class="label">Tên người gửi </div> <div class="input"><asp:Label ID="lblDBFullName" CssClass="Label" runat="server"/></div></div> </div>
<div class="frow"> <div class="frow-wrapp"> <div class="label">Email </div> <div class="input"><asp:Label ID="lblDBEmail" CssClass="Label" runat="server"/></div></div> </div>
<div class="frow"> <div class="frow-wrapp"> <div class="label">Điện thoại </div> <div class="input"><asp:Label ID="lblDBMobile" CssClass="Label" runat="server"/></div></div> </div>

<div class="frow"> <div class="frow-wrapp"> <div class="label">Duyệt </div> <div class="input"><asp:CheckBox Enabled="false" ID="chkIsActive"  runat="server"></asp:CheckBox></div></div> </div>
</div>
<div class="form-tool-bottom">
         <bic:ToolBar ID="tbBottom" runat="server" />
</div>

