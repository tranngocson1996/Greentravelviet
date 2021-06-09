<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewHotel.ascx.cs" Inherits="Admin_Components_Hotel_ViewHotel" %>

<%@ Register Assembly="BICLib" Namespace="BIC.WebControls" TagPrefix="bic" %>


<div class="form-tool">
    <bic:ToolBar ID="tbTop" runat="server" />
</div>
<div class="form-caption">
        Chi tiết nội dung
</div>
<div class ="form-view">
<div class="frow"> <div class="frow-wrapp"> <div class="label">Tên khách sạn<span class="validate">*</span> </div> <div class="input"><asp:Label ID="lblDBHotelName" CssClass="Label" runat="server"/></div></div> </div>
<div class="frow"> <div class="frow-wrapp"> <div class="label">Ảnh mô tả </div> <div class="input"><asp:Label ID="lblDBImageID" CssClass="Label" runat="server"/></div></div> </div>
<div class="frow"> <div class="frow-wrapp"> <div class="label">Mô tả </div> <div class="input"><asp:Label ID="lblDBDescription" CssClass="Label" runat="server"/></div></div> </div>
</div>
<div class="form-tool-bottom">
         <bic:ToolBar ID="tbBottom" runat="server" />
</div>

