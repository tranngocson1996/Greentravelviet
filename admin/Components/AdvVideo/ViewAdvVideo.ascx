<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewAdvVideo.ascx.cs" Inherits="Admin_Components_AdvVideo_ViewAdvVideo" %>


<div class="form-tool">
    <bic:ToolBar ID="tbTop" runat="server" />
</div>
<div class="form-caption">
    Chi tiết nội dung
</div>
<div class ="form-view">
    <div class="frow"> <div class="frow-wrapp"> <div class="label">Tên<span class="validate">*</span> </div> <div class="input"><asp:Label ID="lblDBName" CssClass="Label" runat="server"/></div></div> </div>
    <div class="frow"> <div class="frow-wrapp"> <div class="label">Ngôn ngữ </div> <div class="input"><asp:Label ID="lblDBLanguageKey" CssClass="Label" runat="server"/></div></div> </div>
    <div class="frow"> <div class="frow-wrapp"> <div class="label">Link </div> <div class="input"><asp:Label ID="lblDBURL" CssClass="Label" runat="server"/></div></div> </div>

    <div class="frow"> <div class="frow-wrapp"> <div class="label">Target </div> <div class="input"><asp:Label ID="lblDBTarget" CssClass="Label" runat="server"/></div></div> </div>
    <div class="frow"> <div class="frow-wrapp"> <div class="label">Thời gian bắt đầu </div> <div class="input"><asp:Label ID="lblDBThoiGianBatDau" CssClass="Label" runat="server"/></div></div> </div>
    <div class="frow"> <div class="frow-wrapp"> <div class="label">Khoảng thời gian hiển thị </div> <div class="input"><asp:Label ID="lblDBKhoangThoiGian" CssClass="Label" runat="server"/></div></div> </div>
    <div class="frow"> <div class="frow-wrapp"> <div class="label">Vị trí </div> <div class="input"><asp:Label ID="lblDBTypeOfAdvID" CssClass="Label" runat="server"/></div></div> </div>
    <div class="frow"> <div class="frow-wrapp"> <div class="label">Trang hiển thị </div> <div class="input"><asp:Label ID="lblDBMenuUserID" CssClass="Label" runat="server"/></div></div> </div>
    <div class="frow"> <div class="frow-wrapp"> <div class="label">Chữ hiển thị </div> <div class="input"><asp:Label ID="lblDBTextDisplay" CssClass="Label" runat="server"/></div></div> </div>
    <div class="frow"> <div class="frow-wrapp"> <div class="label">Mô tả </div> <div class="input"><asp:Label ID="lblDBDescription" CssClass="Label" runat="server"/></div></div> </div>
    <div class="frow"> <div class="frow-wrapp"> <div class="label">Lượt xem </div> <div class="input"><asp:Label ID="lblDBViewCount" CssClass="Label" runat="server"/></div></div> </div>

    <div class="frow"> <div class="frow-wrapp"> <div class="label">Duyệt </div> <div class="input"><asp:CheckBox Enabled="false" ID="chkIsActive"  runat="server"></asp:CheckBox></div></div> </div>
</div>
<div class="form-tool-bottom">
    <bic:ToolBar ID="tbBottom" runat="server" />
</div>