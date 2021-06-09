<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewTourType.ascx.cs" Inherits="Admin_Components_TourType_ViewTourType" %>

<%@ Register Assembly="BICLib" Namespace="BIC.WebControls" TagPrefix="bic" %>


<div class="form-tool">
    <bic:ToolBar ID="tbTop" runat="server" />
</div>
<div class="form-caption">
        Chi tiết nội dung
</div>
<div class ="form-view">
<div class="frow"> <div class="frow-wrapp"> <div class="label">Tên hình thức<span class="validate">*</span> </div> <div class="input"><asp:Label ID="lblDBTenHinhThuc" CssClass="Label" runat="server"/></div></div> </div>
<div class="frow"> <div class="frow-wrapp"> <div class="label">Mô tả </div> <div class="input"><asp:Label ID="lblDBMota" CssClass="Label" runat="server"/></div></div> </div>
<div class="frow"> <div class="frow-wrapp"> <div class="label">Thứ tự </div> <div class="input"><asp:Label ID="lblDBPriority" CssClass="Label" runat="server"/></div></div> </div>
<div class="frow"> <div class="frow-wrapp"> <div class="label">Duyệt </div> <div class="input"><asp:CheckBox Enabled="false" ID="chkIsActive"  runat="server"></asp:CheckBox></div></div> </div>
</div>
<div class="form-tool-bottom">
         <bic:ToolBar ID="tbBottom" runat="server" />
</div>

