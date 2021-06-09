<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewDocument.ascx.cs" Inherits="Admin_Components_Document_ViewDocument" %>
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
                Nhóm tài liệu
            </div>
            <div class="input">
                <asp:Label ID="lblDBDocumentTypeID" CssClass="Label" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Tiêu đề<span class="validate">*</span>
            </div>
            <div class="input">
                <asp:Label ID="lblDBDisplayName" CssClass="Label" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Số văn bản
            </div>
            <div class="input">
                <asp:Label ID="lblDBDocumentNo" CssClass="Label" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Lượt xem
            </div>
            <div class="input">
                <asp:Label ID="lblDBViewNo" CssClass="Label" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Trích yếu
            </div>
            <div class="input">
                <asp:Label ID="lblDBBriefDescription" CssClass="Label" runat="server" /></div>
        </div>
    </div>
    <div class="frow hidden">
        <div class="frow-wrapp">
            <div class="label">
                Quyền xem
            </div>
            <div class="input">
                <asp:Label ID="lblDBUserNameView" CssClass="Label" runat="server" /></div>
        </div>
    </div>
    <div class="frow hidden">
        <div class="frow-wrapp">
            <div class="label">
                Quyền sửa
            </div>
            <div class="input">
                <asp:Label ID="lblDBUserNameEdit" CssClass="Label" runat="server" /></div>
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