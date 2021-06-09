<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditionDistrict.ascx.cs" Inherits="Admin_Components_District_EditionDistrict" %>
<div class="form-tool">
    <bic:ToolBar ID="tbTop" runat="server" />
    <asp:LinkButton ID="lbtnSave" CssClass="btn-save" runat="server" OnCommand="Save"
        CommandName="Update"></asp:LinkButton>
</div>
<div class="form-caption">
    <%=BIC.Utils.BicMessage.EditTitle%> <span class="note"><em>*</em> <%=BIC.Utils.BicMessage.RequireTitle%> </span>
</div>
<div class="form-view">
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">Tỉnh/Thành phố </div>
            <div class="input">
                <asp:DropDownList ID="ddlCityID" CssClass="input-select" Width="200" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">Tên Quận/Huyện<span class="validate">*</span> </div>
            <div class="input">
                <asp:TextBox ID="txtDistrictName" CssClass="input-select" Width="95%" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">Phí chuyển phát nhanh </div>
            <div class="input">
                <asp:TextBox ID="txtChuyenNhanh" CssClass="input-select" Width="200" runat="server" onkeypress="return keypress(event);"/>
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">Đk miễn phí chuyển phát nhanh</div>
            <div class="input">
                <asp:TextBox ID="txtMienPhiNhanh" CssClass="input-select" Width="200" runat="server" onkeypress="return keypress(event);"/>
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">Phí chuyển chậm</div>
            <div class="input">
                <asp:TextBox ID="txtChuyenCham" CssClass="input-select" Width="200" runat="server" onkeypress="return keypress(event);"/>
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">Đk miễn phí chuyển chậm</div>
            <div class="input">
                <asp:TextBox ID="txtMienPhiCham" CssClass="input-select" Width="200" runat="server" onkeypress="return keypress(event);"/>
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">Thứ tự</div>
            <div class="input">
                <asp:DropDownList runat="server" ID="ddlPosition" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">Duyệt </div>
            <div class="input">
                <asp:CheckBox runat="server" Enable="<%#Approved%>" Checked="true" ID="chkIsActive" /></div>
        </div>
    </div>
</div>
<div class="form-tool-bottom">
    <bic:ToolBar ID="tbBottom" runat="server" />
    <asp:LinkButton ID="lbtnSave2" CssClass="btn-save" runat="server" OnCommand="Save"
        CommandName="Update"></asp:LinkButton>
</div>
<telerik:RadInputManager runat="server" ID="rimBICCMS" EnableEmbeddedSkins="false" Skin="BICCMS">

    <telerik:TextBoxSetting BehaviorID="bhDistrictName" EmptyMessage="Nhập tên quận/huyện" Validation-IsRequired="true">
        <TargetControls>
            <telerik:TargetInput ControlID="txtDistrictName" />
        </TargetControls>
    </telerik:TextBoxSetting>


</telerik:RadInputManager>
