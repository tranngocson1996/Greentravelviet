<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditionCategory.ascx.cs" Inherits="Admin_Components_Category_EditionCategory" %>
<%@ Import Namespace="BIC.Utils" %>
<div class="form-tool">
    <bic:ToolBar ID="tbTop" runat="server" />
    <asp:LinkButton ID="lbtnSave" CssClass="btn-save" Text="Lưu" runat="server" OnCommand="Save"
        CommandName="Update"></asp:LinkButton>
</div>
<div class="form-caption">
    <%=BicMessage.EditTitle%> <span class="note"><em>*</em> <%=BIC.Utils.BicMessage.RequireTitle%> </span>
</div>
<div class="form-view">
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <%=BicResource.GetValue("Admin","System_Language") %>
            </div>
            <div class="input">
                <bic:Language ID="ddlLanguage" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlLanguage_SelectedIndexChanged" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <%= BicResource.GetValue("Admin","System_Method") %>
            </div>
            <div class="input">
                <asp:DropDownList ID="ddlTypeOfCategory" CssClass="input-select" Width="200" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">Tên<span class="validate">*</span> </div>
            <div class="input">
                <asp:TextBox ID="txtName" CssClass="input-select" Width="200" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">Giá trị </div>
            <div class="input">
                <asp:TextBox ID="txtValue" CssClass="input-select" Width="200" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow" runat="server" id="divNote">
        <div class="frow-wrapp">
            <div class="label"><%= BicResource.GetValue("Admin","System_Category_Note") %> </div>
            <div class="input">
                <asp:TextBox ID="txtNote" CssClass="input-select" Width="200" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">Thứ tự </div>
            <div class="input">
                <telerik:RadNumericTextBox ShowSpinButtons="true" IncrementSettings-InterceptArrowKeys="true"
                    IncrementSettings-InterceptMouseWheel="true" Value="1" LabelWidth="" runat="server"
                    ID="ntxPosition" Width="120px" DataType="System.Int64" MinValue="1">
                    <NumberFormat ZeroPattern="n" AllowRounding="False"></NumberFormat>
                </telerik:RadNumericTextBox>
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
    <asp:LinkButton ID="lbtnSave2" Text="Lưu" CssClass="btn-save" runat="server" OnCommand="Save"
        CommandName="Update"></asp:LinkButton>
</div>
<telerik:RadInputManager runat="server" ID="rimBICCMS" EnableEmbeddedSkins="false" Skin="BICCMS">
    <telerik:TextBoxSetting BehaviorID="bhName" EmptyMessage="Nhập tên" Validation-IsRequired="true">
        <TargetControls>
            <telerik:TargetInput ControlID="txtName" />
        </TargetControls>
    </telerik:TextBoxSetting>
</telerik:RadInputManager>
