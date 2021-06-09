<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdditionTourRoute.ascx.cs" Inherits="Admin_Components_TourRoute_AdditionTourRoute" %>
<div class="form-tool">
    <bic:ToolBar ID="tbTop" runat="server" />
    <asp:LinkButton ID="lbtnSave" CssClass="btn-save" runat="server" OnCommand="Save" CommandName="AddNew"></asp:LinkButton>
</div>
<div class="form-caption">
    <%=BIC.Utils.BicMessage.InsertTitle%>
    <span class="note"><em>*</em>
        <%=BIC.Utils.BicMessage.RequireTitle%>
    </span>
</div>
<div class="form-view">
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Tên địa danh<span class="validate">*</span>
            </div>
            <div class="input">
                <asp:TextBox ID="txtName" CssClass="input-select" Width="95%" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Latitude
            </div>
            <div class="input">
                <asp:TextBox ID="txtLatitude" CssClass="input-select" Width="200" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Longitude
            </div>
            <div class="input">
                <asp:TextBox ID="txtLongitude" CssClass="input-select" Width="200" runat="server" /></div>
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
                <asp:CheckBox runat="server" Enable="<%#Approved%>" Checked="true" ID="chkIsActive" /></div>
        </div>
    </div>
</div>
<div class="form-tool-bottom">
    <bic:ToolBar ID="tbBottom" runat="server" />
    <asp:LinkButton ID="lbtnSave2" CssClass="btn-save" runat="server" OnCommand="Save" CommandName="AddNew"></asp:LinkButton>
</div>
<telerik:RadInputManager runat="server" ID="rimBICCMS" EnableEmbeddedSkins="false" Skin="BICCMS">
    <telerik:TextBoxSetting BehaviorID="bhName" EmptyMessage="Nhập tên địa danh" Validation-IsRequired="true">
        <TargetControls>
            <telerik:TargetInput ControlID="txtName" />
        </TargetControls>
    </telerik:TextBoxSetting>
</telerik:RadInputManager>