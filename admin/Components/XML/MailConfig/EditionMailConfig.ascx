<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditionMailConfig.ascx.cs" Inherits="Admin_Components_Support_EditionSupport" %>
<%@ Import Namespace="BIC.Utils" %>
<div class="form-tool">
    <bic:ToolBar ID="tbTop" runat="server" />
    <asp:LinkButton ID="lbtnSave" CssClass="btn-save" runat="server" OnCommand="Save" CommandName="Update"><%=BicResource.GetValue("Admin","Admin_XML_MailConfig_Save") %></asp:LinkButton>
</div>
<div class="form-caption">
    <%= BicMessage.EditTitle %>
    <span class="note">
        <asp:Literal ID="ltrNote" runat="server" />
        <em>*</em>
        <%= BicMessage.RequireTitle %>
    </span>
</div>
<div class="form-view">
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
              <%=BicResource.GetValue("Admin","Admin_XML_MailConfig_ConfigurationName") %>  
            </div>
            <div class="input">
                <asp:Label ID="lblConfigName" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow" id="divNotPass" runat="server">
        <div class="frow-wrapp">
            <div class="label">
          <%=BicResource.GetValue("Admin","Admin_XML_MailConfig_Value") %>  
            </div>
            <div class="input">
                <asp:TextBox runat="server" ID="txtValue" CssClass="input-text" Width="500px" />
            </div>
        </div>
    </div>
    <div class="frow" id="divPass" runat="server">
        <div class="frow-wrapp">
            <div class="label">
                         <%=BicResource.GetValue("Admin","Admin_XML_MailConfig_PassWord") %> 
            </div>
            <div class="input">
                <asp:TextBox runat="server" ID="txtPass2" TextMode="Password" CssClass="input-text" Width="200px" />
                <asp:CompareValidator ID="cvPass" runat="server" ErrorMessage="*" ControlToCompare="txtPass1" ControlToValidate="txtPass2"></asp:CompareValidator>
            </div>
        </div>
    </div>
    <div class="frow" id="divPass2" runat="server">
        <div class="frow-wrapp">
            <div class="label">
               <%=BicResource.GetValue("Admin","System_Reset") %> 
            </div>
            <div class="input">
                <asp:TextBox runat="server" ID="txtPass1" TextMode="Password" CssClass="input-text" Width="200px" />
            </div>
        </div>
    </div>
</div>
<div class="form-tool-bottom">
    <bic:ToolBar ID="tbBottom" runat="server" />
    <asp:LinkButton ID="lbtnSave2" CssClass="btn-save" runat="server" OnCommand="Save" CommandName="Update"><%=BicResource.GetValue("Admin","Admin_XML_MailConfig_Save") %></asp:LinkButton>
</div>
<telerik:RadInputManager runat="server" ID="rimBICCMS" EnableEmbeddedSkins="false" Skin="BICCMS">
    <telerik:TextBoxSetting BehaviorID="bhDisplayName" EmptyMessage="<%$Resources:Admin, Admin_XML_MailConfig_EnterATitle%>" Validation-IsRequired="true">
        <TargetControls>
            <telerik:TargetInput ControlID="txtDisplayName" />
        </TargetControls>
    </telerik:TextBoxSetting>
    <telerik:NumericTextBoxSetting BehaviorID="bhViewNo" EmptyMessage="<%$Resources:Admin,System_InputViewCount%>" DecimalDigits="0">
        <TargetControls>
            <telerik:TargetInput ControlID="txtViewNo" />
        </TargetControls>
    </telerik:NumericTextBoxSetting>
</telerik:RadInputManager>