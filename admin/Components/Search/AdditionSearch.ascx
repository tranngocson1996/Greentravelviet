<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdditionSearch.ascx.cs" Inherits="Admin_Components_Search_AdditionSearch" %>
<%@ Import Namespace="BIC.Utils" %>
<%@ Register Src="~/admin/Components/ImageGallery/ImageSelector.ascx" TagName="ImageSelector" TagPrefix="bic" %>
<div class="form-tool">
    <bic:ToolBar ID="tbTop" runat="server" />
    <asp:LinkButton ID="lbtnSave" CssClass="btn-save" runat="server" OnCommand="Save" CommandName="AddNew"></asp:LinkButton>
</div>
<div class="form-caption">
    <%= BicMessage.InsertTitle %>
    <span class="note"><em>*</em>
        <%= BicMessage.RequireTitle %>
    </span>
</div>
<div class="form-view">
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Ngôn ngữ
            </div>
            <div class="input">
                <bic:Language ID="ddlLanguage" runat="server" Width="200px" CssClass="input-select">
                </bic:Language>
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Tiêu đề
            </div>
            <div class="input">
                <asp:TextBox ID="txtKeyword" CssClass="input-text" Width="600" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Mô tả
            </div>
            <div class="input">
                <asp:TextBox ID="txtDescription" CssClass="input-text" Width="600" runat="server" TextMode="MultiLine" Height="80" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Số điện thoại
            </div>
            <div class="input">
                <asp:TextBox ID="txtPhone" CssClass="input-text" Width="600" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Ảnh
            </div>
            <div class="input">
                <bic:ImageSelector ID="isImageID" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Link
            </div>
            <div class="input">
                <asp:TextBox ID="txtLink" CssClass="input-text" Width="600" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Thứ tự</div>
            <div class="input">
                <asp:DropDownList runat="server" ID="ddlPosition" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Duyệt
            </div>
            <div class="input">
                <asp:CheckBox runat="server" Enable="<%# Approved %>" Checked="true" ID="chkIsActive" /></div>
        </div>
    </div>
</div>
<div class="form-tool-bottom">
    <bic:ToolBar ID="tbBottom" runat="server" />
    <asp:LinkButton ID="lbtnSave2" CssClass="btn-save" runat="server" OnCommand="Save" CommandName="AddNew"></asp:LinkButton>
</div>
<telerik:RadInputManager runat="server" ID="rimBICCMS" EnableEmbeddedSkins="false" Skin="BICCMS">
</telerik:RadInputManager>