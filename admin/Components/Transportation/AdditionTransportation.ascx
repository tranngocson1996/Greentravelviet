<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdditionTransportation.ascx.cs" Inherits="Admin_Components_Transportation_AdditionTransportation" %>
<div class="form-tool">
    <bic:ToolBar ID="tbTop" runat="server" />
    <asp:LinkButton ID="lbtnSave" CssClass="btn-save" runat="server" OnCommand="Save"
        CommandName="AddNew"></asp:LinkButton>
</div>
<div class="form-caption">
    <%=BIC.Utils.BicMessage.InsertTitle%> <span class="note"><em>*</em> <%=BIC.Utils.BicMessage.RequireTitle%> </span>
</div>
<div class="form-view">
      <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Ngôn ngữ
            </div>
            <div class="input">
              <bic:Language ID="ddlLanguage" runat="server"/>
            </div>
        </div>
    </div>
<div class="frow"> <div class="frow-wrapp"> <div class="label">Tên phương tiện </div> <div class="input"><asp:TextBox ID="txtTenPhuongTien" CssClass="input-select" Width="95%" runat="server"/></div></div></div>
<div class="frow"> <div class="frow-wrapp"> <div class="label">Thứ tự</div> <div class="input"><asp:DropDownList runat="server" ID="ddlPosition" /></div> </div>    </div>
<div class="frow"> <div class="frow-wrapp"> <div class="label">Duyệt </div> <div class="input"><asp:CheckBox runat="server" Enable="<%#Approved%>" Checked="true" ID="chkIsActive" /></div> </div>    </div>
</div>
<div class="form-tool-bottom">
    <bic:ToolBar ID="tbBottom" runat="server" />
    <asp:LinkButton ID="lbtnSave2" CssClass="btn-save" runat="server" OnCommand="Save"
        CommandName="AddNew"></asp:LinkButton>
</div>

<telerik:RadInputManager runat="server" ID="rimBICCMS" EnableEmbeddedSkins="false" Skin="BICCMS">

<telerik:NumericTextBoxSetting BehaviorID="bhPriority" DecimalDigits="0"><TargetControls><telerik:TargetInput ControlID="txtPriority" /></TargetControls></telerik:NumericTextBoxSetting>

</telerik:RadInputManager>
