<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewTypeOfRoom.ascx.cs" Inherits="Admin_Components_TypeOfRoom_ViewTypeOfRoom" %>

<%@ Register Assembly="BICLib" Namespace="BIC.WebControls" TagPrefix="bic" %>


<div class="form-tool">
    <bic:ToolBar ID="tbTop" runat="server" />
</div>
<div class="form-caption">
        Chi tiết nội dung
</div>
<div class ="form-view">
<div class="frow"> <div class="frow-wrapp"> <div class="label">Tên phòng </div> <div class="input"><asp:Label ID="lblDBRoomName" CssClass="Label" runat="server"/></div></div> </div>
<div class="frow"> <div class="frow-wrapp"> <div class="label">Kiểu giường<span class="validate">*</span> </div> <div class="input"><asp:Label ID="lblDBName" CssClass="Label" runat="server"/></div></div> </div>
<div class="frow"> <div class="frow-wrapp"> <div class="label">Giá </div> <div class="input"><asp:Label ID="lblDBPrice" CssClass="Label" runat="server"/></div></div> </div>
<div class="frow"> <div class="frow-wrapp"> <div class="label">Duyệt </div> <div class="input"><asp:CheckBox Enabled="false" ID="chkIsActive"  runat="server"></asp:CheckBox></div></div> </div>
</div>
<div class="form-tool-bottom">
         <bic:ToolBar ID="tbBottom" runat="server" />
</div>

