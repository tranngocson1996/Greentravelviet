<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewCity.ascx.cs" Inherits="Admin_Components_City_ViewCity" %>
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
                Tên Tỉnh/Thành phố
            </div>
            <div class="input">
                <asp:Label ID="lblDBCityName" CssClass="Label" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Phí chuyển phát nhanh
            </div>
            <div class="input">
                <asp:Label ID="lbChuyenNhanh" CssClass="Label" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Điều kiện miễn phí chuyển phát nhanh
            </div>
            <div class="input">
                <asp:Label ID="lbMienPhiNhanh" CssClass="Label" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Phí chuyển chậm
            </div>
            <div class="input">
                <asp:Label ID="lbChuyenCham" CssClass="Label" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Điều kiện miễn phí chuyển chậm
            </div>
            <div class="input">
                <asp:Label ID="lbMienPhiCham" CssClass="Label" runat="server" /></div>
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