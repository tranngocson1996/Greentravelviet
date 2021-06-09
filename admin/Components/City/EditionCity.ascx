<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditionCity.ascx.cs" Inherits="Admin_Components_City_EditionCity" %>
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
            <div class="label">Tên Tỉnh/Thành phố<span class="validate">*</span> </div>
            <div class="input">
                <asp:TextBox ID="txtCityName" CssClass="input-select" Width="200" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">Phí chuyển phát nhanh<span class="validate">*</span> </div>
            <div class="input">
                <asp:TextBox ID="txtChuyenNhanh" CssClass="input-select" Width="200" runat="server" onkeypress="return keypress(event);"/>
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">Đk miễn phí chuyển phát nhanh<span class="validate">*</span> </div>
            <div class="input">
                <asp:TextBox ID="txtMienPhiNhanh" CssClass="input-select" Width="200" runat="server" onkeypress="return keypress(event);"/>
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">Phí chuyển chậm<span class="validate">*</span> </div>
            <div class="input">
                <asp:TextBox ID="txtChuyenCham" CssClass="input-select" Width="200" runat="server" onkeypress="return keypress(event);"/>
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">Đk miễn phí chuyển chậm<span class="validate">*</span> </div>
            <div class="input">
                <asp:TextBox ID="txtMienPhiCham" CssClass="input-select" Width="200" runat="server" onkeypress="return keypress(event);"/>
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">Thứ tự</div>
            <div class="input">
                <asp:DropDownList runat="server" ID="ddlPosition" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">Duyệt </div>
            <div class="input">
                <asp:CheckBox runat="server" Enable="<%#Approved%>" Checked="true" ID="chkIsActive" />
            </div>
        </div>
    </div>
</div>
<div class="form-tool-bottom">
    <bic:ToolBar ID="tbBottom" runat="server" />
    <asp:LinkButton ID="lbtnSave2" CssClass="btn-save" runat="server" OnCommand="Save"
        CommandName="Update"></asp:LinkButton>
</div>
<telerik:RadInputManager runat="server" ID="rimBICCMS" EnableEmbeddedSkins="false" Skin="BICCMS">
    <telerik:TextBoxSetting BehaviorID="bhCityName" EmptyMessage="Nhập tên tỉnh/thành phố" Validation-IsRequired="true">
        <TargetControls>
            <telerik:TargetInput ControlID="txtCityName" />
        </TargetControls>
    </telerik:TextBoxSetting>


</telerik:RadInputManager>
