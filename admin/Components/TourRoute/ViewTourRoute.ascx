<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewTourRoute.ascx.cs" Inherits="Admin_Components_TourRoute_ViewTourRoute" %>

<%@ Register Assembly="BICLib" Namespace="BIC.WebControls" TagPrefix="bic" %>


<div class="form-tool">
    <bic:ToolBar ID="tbTop" runat="server" />
</div>
<div class="form-caption">
        Chi tiết nội dung
</div>
<div class ="form-view">
<div class="frow"> <div class="frow-wrapp"> <div class="label">Tên địa danh<span class="validate">*</span> </div> <div class="input"><asp:Label ID="lblDBName" CssClass="Label" runat="server"/></div></div> </div>
<div class="frow"> <div class="frow-wrapp"> <div class="label">Latitude </div> <div class="input"><asp:Label ID="lblDBLatitude" CssClass="Label" runat="server"/></div></div> </div>
<div class="frow"> <div class="frow-wrapp"> <div class="label">Longitude </div> <div class="input"><asp:Label ID="lblDBLongitude" CssClass="Label" runat="server"/></div></div> </div>

<div class="frow"> <div class="frow-wrapp"> <div class="label">Duyệt </div> <div class="input"><asp:CheckBox Enabled="false" ID="chkIsActive"  runat="server"></asp:CheckBox></div></div> </div>
</div>
<div class="form-tool-bottom">
         <bic:ToolBar ID="tbBottom" runat="server" />
</div>

