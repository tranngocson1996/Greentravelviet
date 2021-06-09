<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewTourHotel.ascx.cs" Inherits="Admin_Components_TourHotel_ViewTourHotel" %>

<%@ Register Assembly="BICLib" Namespace="BIC.WebControls" TagPrefix="bic" %>


<div class="form-tool">
    <bic:ToolBar ID="tbTop" runat="server" />
</div>
<div class="form-caption">
        Chi tiết nội dung
</div>
<div class ="form-view">
<div class="frow"> <div class="frow-wrapp"> <div class="label">Tên khách sạn<span class="validate">*</span> </div> <div class="input"><asp:Label ID="lblDBTenKhachSan" CssClass="Label" runat="server"/></div></div> </div>
<div class="frow"> <div class="frow-wrapp"> <div class="label">Thành phố </div> <div class="input"><asp:Label ID="lblDBThanhPho" CssClass="Label" runat="server"/></div></div> </div>
<div class="frow"> <div class="frow-wrapp"> <div class="label">Hạng </div> <div class="input"><asp:Label ID="lblDBHang" CssClass="Label" runat="server"/></div></div> </div>
<div class="frow"> <div class="frow-wrapp"> <div class="label">Mô tả </div> <div class="input"><asp:Label ID="lblDBMoTaChiTiet" CssClass="Label" runat="server"/></div></div> </div>
<div class="frow"> <div class="frow-wrapp"> <div class="label">Tags </div> <div class="input"> <asp:Label ID="lblTag" CssClass="Label" runat="server" /> </div> </div> </div>
<div class="frow"> <div class="frow-wrapp"> <div class="label">Tiêu đề SEO</div> <div class="input"> <asp:Label ID="lblSeoTitle" CssClass="Label" runat="server" /> </div> </div> </div>

<div class="frow"> <div class="frow-wrapp"> <div class="label">Duyệt </div> <div class="input"><asp:CheckBox Enabled="false" ID="chkIsActive"  runat="server"></asp:CheckBox></div></div> </div>
<div class="frow"> <div class="frow-wrapp"> <div class="label">Ảnh đại diện </div> <div class="input"> <img runat="server" id="isImageId" /></div></div> </div>
<div class="frow"> <div class="frow-wrapp"> <div class="label">Ảnh khách sạn </div> <div class="input"><asp:Label ID="lblDBAnhKhachSan" CssClass="Label" runat="server"/></div></div> </div>
<div class="frow"> <div class="frow-wrapp"> <div class="label">Lượt xem </div> <div class="input"><asp:Label ID="lblDBLuotXem" CssClass="Label" runat="server"/></div></div> </div>
<div class="frow"> <div class="frow-wrapp"> <div class="label">Địa chỉ </div> <div class="input"><asp:Label ID="lblDBDiachi" CssClass="Label" runat="server"/></div></div> </div>
<div class="frow"> <div class="frow-wrapp"> <div class="label">Số điện thoại </div> <div class="input"><asp:Label ID="lblDBSoDienThoai" CssClass="Label" runat="server"/></div></div> </div>
<div class="frow"> <div class="frow-wrapp"> <div class="label">Website </div> <div class="input"><asp:Label ID="lblDBWebsite" CssClass="Label" runat="server"/></div></div> </div>
<div class="frow"> <div class="frow-wrapp"> <div class="label">Email </div> <div class="input"><asp:Label ID="lblDBEmail" CssClass="Label" runat="server"/></div></div> </div>
<div class="frow"> <div class="frow-wrapp"> <div class="label">Giá hiển thị </div> <div class="input"><asp:Label ID="lblDBPrice" CssClass="Label" runat="server"/></div></div> </div>
<div class="frow"> <div class="frow-wrapp"> <div class="label">Giá chi tiết </div> <div class="input"><asp:Label ID="lblDBGiaChiTiet" CssClass="Label" runat="server"/></div></div> </div>
<div class="frow"> <div class="frow-wrapp"> <div class="label">Giá từ </div> <div class="input"><asp:Label ID="lblDBGiaTu" CssClass="Label" runat="server"/></div></div> </div>
</div>
<div class="form-tool-bottom">
         <bic:ToolBar ID="tbBottom" runat="server" />
</div>

