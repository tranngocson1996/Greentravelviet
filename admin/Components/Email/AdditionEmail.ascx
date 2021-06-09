<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdditionEmail.ascx.cs" Inherits="Admin_Components_Email_AdditionEmail" %>
<%@ Import Namespace="BIC.Utils" %>
<div class="form-tool">
    <bic:ToolBar ID="tbTop" runat="server" />
    <asp:LinkButton ID="lbtnSave" CssClass="btn-save" runat="server" OnCommand="Save"
        CommandName="AddNew"><%=BicResource.GetValue("Admin","Admin_Save") %></asp:LinkButton>
</div>
<div class="form-caption">
    <%=BIC.Utils.BicMessage.InsertTitle%> <span class="note"><em>*</em> <%=BIC.Utils.BicMessage.RequireTitle%> </span>
</div>
<div class="form-view">
<div class="frow"> <div class="frow-wrapp"> <div class="label">Email đăng ký<span class="validate">*</span> </div> <div class="input"><asp:TextBox ID="txtEmail" CssClass="input-text" Width="95%" runat="server"/></div></div></div>
<div class="frow"> <div class="frow-wrapp"> <div class="label">Tần xuất nhận tin </div> <div class="input"><asp:TextBox ID="txtInterval" CssClass="input-text" Width="100" runat="server"/></div></div></div>
<div class="frow"> <div class="frow-wrapp"> <div class="label">Lần gửi cuối </div> <div class="input"><asp:TextBox ID="txtLastSend" CssClass="" Width="" runat="server"/></div></div></div>
<%--<div class="frow"> <div class="frow-wrapp"> <div class="label">Thứ tự</div> <div class="input"><asp:DropDownList runat="server" ID="ddlPosition" /></div> </div>    </div>--%>
<div class="frow"> <div class="frow-wrapp"> <div class="label"><%=BicResource.GetValue("Admin","Admin_Comment_CreateDate") %> </div> <div class="input"><asp:TextBox ID="txtCreatedTime" CssClass="" Width="" runat="server"/></div></div></div>
<div class="frow"> <div class="frow-wrapp"> <div class="label"><%=BicResource.GetValue("Admin","System_Browse") %> </div> <div class="input"><asp:CheckBox runat="server" Enable="<%#Approved%>" Checked="true" ID="chkIsActive" /></div> </div>    </div>
</div>
<div class="form-tool-bottom">
    <bic:ToolBar ID="tbBottom" runat="server" />
    <asp:LinkButton ID="lbtnSave2" CssClass="btn-save" runat="server" OnCommand="Save"
        CommandName="AddNew"><%=BicResource.GetValue("Admin","Admin_Save") %></asp:LinkButton>
</div>

<telerik:RadInputManager runat="server" ID="rimBICCMS" EnableEmbeddedSkins="false" Skin="BICCMS">
<telerik:TextBoxSetting BehaviorID="bhEmail" EmptyMessage="Nhập email đăng ký" Validation-IsRequired="true"><TargetControls><telerik:TargetInput ControlID="txtEmail" /></TargetControls></telerik:TextBoxSetting>
<telerik:NumericTextBoxSetting BehaviorID="bhInterval" DecimalDigits="0"><TargetControls><telerik:TargetInput ControlID="txtInterval" /></TargetControls></telerik:NumericTextBoxSetting>




</telerik:RadInputManager>
