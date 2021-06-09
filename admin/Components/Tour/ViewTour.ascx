<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewTour.ascx.cs" Inherits="Admin_Components_Tour_ViewTour" %>
<%@ Register Assembly="BICLib" Namespace="BIC.WebControls" TagPrefix="bic" %>
<div class="form-tool">
    <bic:ToolBar ID="tbTop" runat="server" />
</div>
<div class="form-caption">
    Chi tiết nội dung
</div>
<div class="form-view">
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Tên tour<span class="validate">*</span>
            </div>
            <div class="input">
                <asp:Label ID="lblDBTenTour" CssClass="Label" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Danh mục
            </div>
            <div class="input">
                <asp:Label ID="lblDBNhomTour" CssClass="Label" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Mã tour
            </div>
            <div class="input">
                <asp:Label ID="lblDBMaTour" CssClass="Label" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Giá
            </div>
            <div class="input">
                <asp:Label ID="lblDBGiaHienThi" CssClass="Label" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Chi tiết giá
            </div>
            <div class="input">
                <asp:Label ID="lblDBChiTietGia" CssClass="Label" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Số ngày
            </div>
            <div class="input">
                <asp:Label ID="lblDBSoNgay" CssClass="Label" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Số đêm
            </div>
            <div class="input">
                <asp:Label ID="lblDBSoDem" CssClass="Label" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Lịch trình
            </div>
            <div class="input">
                <asp:Label ID="lblDBLichTrinh" CssClass="Label" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Lịch trình hiển thị
            </div>
            <div class="input">
                <asp:Label ID="lblDBLichTrinhHienThi" CssClass="Label" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Phương tiện
            </div>
            <div class="input">
                <asp:Label ID="lblDBPhuongTien" CssClass="Label" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Phương tiện hiển thị
            </div>
            <div class="input">
                <asp:Label ID="lblDBPhuongTienHienThi" CssClass="Label" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Khởi hành từ
            </div>
            <div class="input">
                <asp:Label ID="lblDBKhoiHanhTu" CssClass="Label" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Giới thiệu chung
            </div>
            <div class="input">
                <asp:Label ID="lblDBGioiThieuChung" CssClass="Label" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Chi tiết
            </div>
            <div class="input">
                <asp:Label ID="lblDBGioiThieuChiTiet" CssClass="Label" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Tags
            </div>
            <div class="input">
                <asp:Label ID="lblTag" CssClass="Label" runat="server" />
            </div>
        </div>
    </div>

    <div class="frow"> <div class="frow-wrapp"> <div class="label">Tiêu đề SEO</div> <div class="input"> <asp:Label ID="lblSeoTitle" CssClass="Label" runat="server" /> </div> </div> </div>


    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Ảnh đại diện
            </div>
            <div class="input">
                <img runat="server" id="isImageID" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Thư viện ảnh
            </div>
            <div class="input">
                <asp:Label ID="lblDBThuVienAnh" CssClass="Label" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Video
            </div>
            <div class="input">
                <asp:Label ID="lblDBVideo" CssClass="Label" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Lượt xem
            </div>
            <div class="input">
                <asp:Label ID="lblDBLuotXem" CssClass="Label" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Mới
            </div>
            <div class="input">
                <asp:CheckBox Enabled="false" ID="chkIsNew" runat="server"></asp:CheckBox></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Duyệt
            </div>
            <div class="input">
                <asp:CheckBox Enabled="false" ID="chkIsActive" runat="server"></asp:CheckBox></div>
        </div>
    </div>
</div>
<div class="form-tool-bottom">
    <bic:ToolBar ID="tbBottom" runat="server" />
</div>