<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewProduct.ascx.cs" ViewStateMode="Enabled" Inherits="Admin_Components_Product_ViewProduct" %>
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
                Tiêu đề
            </div>
            <div class="input">
                <asp:Literal runat="server" ID="litTitle"></asp:Literal>
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Danh mục
            </div>
            <div class="input">
                <asp:Literal runat="server" ID="litMenuUser"></asp:Literal>
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Vị trí đặc biệt
            </div>
            <div class="input">
                <asp:Literal runat="server" ID="litOtherCategory"></asp:Literal>
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Thông tin khác
            </div>
            <div class="input group-item">
                <div class="col first selector-image">
                    <div class="title">
                        <a href="#">Ảnh mô tả</a>
                    </div>
                    <div class="image">
                        <a runat="server" id="aImage" href="#" onclick="hs.expand(this);">
                            <img runat="server" id="htmlImage" src="~/admin/Styles/icon/selectImage.gif" clientidmode="Static" />
                        </a>
                    </div>
                </div>
                <div class="col c1">
                    <div class="line">
                        <div class="label">
                            <a href="#">Liên hệ qua bài viết</a>
                        </div>
                        <div class="input">
                            <asp:CheckBox runat="server" ID="chkCommentEnable" Enabled="false" />
                        </div>
                    </div>
                    <div class="line">
                        <div class="label">
                            <a href="#">Trang chủ</a>
                        </div>
                        <div class="input">
                            <asp:CheckBox runat="server" ID="chkIsHome" Enabled="false" />
                        </div>
                    </div>
                    <div class="line">
                        <div class="label">
                            <a href="#">Mới</a>
                        </div>
                        <div class="input">
                            <asp:CheckBox runat="server" ID="chkIsNew" Enabled="false" />
                        </div>
                    </div>
                    <div class="line">
                        <div class="label">
                            <a href="#">Duyệt</a>
                        </div>
                        <div class="input">
                            <asp:CheckBox runat="server" ID="chkIsActive" Enabled="false" />
                        </div>
                    </div>
                </div>
                <div class="col c2">
                    <div class="line">
                        <div class="label">
                            <a href="#">Lượt xem</a>
                        </div>
                        <div class="input">
                            <asp:TextBox runat="server" ID="txtViewCount" CssClass="input-text"> </asp:TextBox>
                        </div>
                    </div>
                    <div class="line">
                        <div class="label">
                            <a href="#">Nguồn</a>
                        </div>
                        <div class="input">
                            <asp:TextBox runat="server" ID="txtSource" CssClass="input-text"></asp:TextBox>
                        </div>
                    </div>
                    <div class="line">
                        <div class="label">
                            <a href="#">Link</a>
                        </div>
                        <div class="input">
                            <asp:TextBox runat="server" ID="txtLink" CssClass="input-text"></asp:TextBox>
                        </div>
                    </div>
                    <div class="line">
                        <div class="label">
                            <a href="#">Target</a>
                        </div>
                        <div class="input">
                            <bic:Target runat="server" ID="cbTarget" CssClass="input-select" Enabled="false">
                            </bic:Target>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Mô tả ngắn
            </div>
            <div class="input">
                <asp:Literal runat="server" ID="litBriefDescription"></asp:Literal>
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Nội dung chi tiết
            </div>
            <div class="input">
                <asp:Literal runat="server" ID="litBody"></asp:Literal>
            </div>
        </div>
    </div>
    <asp:TextBox runat="server" ID="txtAllowUser" CssClass="input-text hidden" />
    <%--    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">

            </div>
            <div class="input">

            </div>
        </div>
    </div>--%>
</div>
<div class="form-tool-bottom">
    <bic:ToolBar ID="tbBottom" runat="server" />
</div>