<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewRoom.ascx.cs" Inherits="Admin_Components_Room_ViewRoom" %>
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
                Tên phòng<span class="validate">*</span>
            </div>
            <div class="input">
                <asp:Label ID="lblDBRoomName" CssClass="Label" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Giá phòng
            </div>
            <div class="input">
                <asp:Label ID="lblDBPrice" CssClass="Label" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Ảnh đại diện
            </div>
            <div class="input">
                <a runat="server" id="aImage" href="#" onclick="hs.expand(this);">
                    <img runat="server" id="htmlImage" src="~/admin/Styles/icon/selectImage.gif" clientidmode="Static" />
                </a>
            </div>
        </div>
        <div class="frow">
            <div class="frow-wrapp">
                <div class="label">
                    Các ảnh khác
                </div>
                <div class="input">
                    <asp:Label ID="lblDBImageArray" CssClass="Label" runat="server" /></div>
            </div>
        </div>
        <div class="frow">
            <div class="frow-wrapp">
                <div class="label">
                    Mô tả ngắn
                </div>
                <div class="input">
                    <asp:Label ID="lblDBBriefDescription" CssClass="Label" runat="server" /></div>
            </div>
        </div>
        <div class="frow">
            <div class="frow-wrapp">
                <div class="label">
                    Chi tiết phòng
                </div>
                <div class="input">
                    <asp:Label ID="lblDBDescription" CssClass="Label" runat="server" /></div>
            </div>
        </div>
        <div class="frow">
            <div class="frow-wrapp">
                <div class="label">
                    Lượt
                </div>
                <div class="input">
                    <asp:Label ID="lblDBViewed" CssClass="Label" runat="server" /></div>
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
</div>
<div class="form-tool-bottom">
    <bic:ToolBar ID="tbBottom" runat="server" />
</div>