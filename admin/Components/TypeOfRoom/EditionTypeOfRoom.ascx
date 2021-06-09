<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditionTypeOfRoom.ascx.cs"
    Inherits="Admin_Components_TypeOfRoom_EditionTypeOfRoom" %>
<%@ Import Namespace="BIC.Utils" %>
<div class="form-tool">
    <bic:ToolBar ID="tbTop" runat="server" />
    <asp:LinkButton ID="lbtnSave" CssClass="btn-save" runat="server" OnCommand="Save"
        ValidationGroup="admin" CommandName="Update">
        <%= BicResource.GetValue("Admin","Admin_Save") %>
    </asp:LinkButton>
</div>
<div class="form-caption">
    <%=BIC.Utils.BicMessage.EditTitle%>
    <span class="note"><em>*</em>
        <%=BIC.Utils.BicMessage.RequireTitle%>
    </span>
</div>
<div class="form-view">
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Ngôn ngữ
            </div>
            <div class="input">
                <bic:Language ID="ddlLanguage" runat="server" Width="119px" CssClass="input-select"
                    AutoPostBack="true" OnSelectedIndexChanged="rcbLanguage_SelectedIndexChanged">
                </bic:Language>
            </div>
        </div>
    </div>
    <div class="frow" style="display: none">
        <div class="frow-wrapp">
            <div class="label">
                Khách sạn
            </div>
            <div class="input">
                <asp:DropDownList runat="server" ID="ddlHotel" CssClass="input-select"
                    AutoPostBack="True" OnSelectedIndexChanged="ddlHotel_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Tên phòng
            </div>
            <div class="input">
                <asp:DropDownList ID="ddlRoomName" CssClass="input-select" Width="" runat="server" />
                <asp:RequiredFieldValidator ID="rfvRoomName" runat="server" ErrorMessage="*" ValidationGroup="admin"
                    ControlToValidate="ddlRoomName" InitialValue="0"></asp:RequiredFieldValidator>
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Kiểu giường<span class="validate">*</span>
            </div>
            <div class="input">
                <asp:TextBox ID="txtName" CssClass="input-text" Width="90%" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Giá
            </div>
            <div class="input">
                <asp:TextBox ID="txtPrice" CssClass="input-text" Width="100px" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Số người cho phép
            </div>
            <div class="input">
                <asp:TextBox ID="txtMaxPerson" CssClass="input-text" Width="100px" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Duyệt
            </div>
            <div class="input">
                <asp:CheckBox ID="chkIsActive" CssClass="" Width="" runat="server" />
            </div>
        </div>
    </div>
</div>
<div class="form-tool-bottom">
    <bic:ToolBar ID="tbBottom" runat="server" />
    <asp:LinkButton ID="lbtnSave2" CssClass="btn-save" runat="server" OnCommand="Save"
        ValidationGroup="admin" CommandName="Update">
        <%= BicResource.GetValue("Admin","Admin_Save") %>
    </asp:LinkButton>
</div>
<telerik:RadInputManager runat="server" ID="rimBICCMS" EnableEmbeddedSkins="false"
    Skin="BICCMS">
    <telerik:TextBoxSetting BehaviorID="bhName" EmptyMessage="Nhập kiểu giường" Validation-IsRequired="true">
        <TargetControls>
            <telerik:TargetInput ControlID="txtName" />
        </TargetControls>
    </telerik:TextBoxSetting>
    <telerik:NumericTextBoxSetting BehaviorID="bhViewCount" Type="Number" DecimalDigits="0">
        <TargetControls>
            <telerik:TargetInput ControlID="txtViewCount" />
        </TargetControls>
    </telerik:NumericTextBoxSetting>
</telerik:RadInputManager>
