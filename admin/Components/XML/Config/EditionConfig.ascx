<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditionConfig.ascx.cs" Inherits="Admin_Components_Config_EditionConfig" %>
<%@ Import Namespace="BIC.Utils" %>
<div class="form-tool">
    <bic:ToolBar ID="tbTop" runat="server" />
    <asp:LinkButton ID="lbtnSave" CssClass="btn-save" runat="server" OnCommand="Save" CommandName="Update"><%=BicResource.GetValue("Admin","Admin_XML_Config_Save") %></asp:LinkButton>
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
               <%=BicResource.GetValue("Admin","Admin_XML_Config_Category") %>
            </div>
            <div class="input">
                <asp:DropDownList runat="server" ID="ddlType" CssClass="input-select" >
                    <asp:ListItem Text="<%$Resources:Admin, System_All%>" Value="global" />
                    <asp:ListItem Text="<%$Resources:Admin, Admin_XML_Config_News%>" Value="news" />
                    <asp:ListItem Text="<%$Resources:Admin, Admin_XML_Config_Product%>" Value="product" />
                </asp:DropDownList>
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
              <%=BicResource.GetValue("Admin","Admin_XML_Config_ConfigurationName") %> 
            </div>
            <div class="input">
                <asp:TextBox ID="txtName" Width="300px" runat="server" CssClass="input-text" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
               <%=BicResource.GetValue("Admin","Admin_XML_Config_Value") %> 
            </div>
            <div class="input">
                <asp:TextBox ID="txtValue" Width="300px" runat="server" CssClass="input-text" />
            </div>
        </div>
    </div>
    
</div>
<div class="form-tool-bottom">
    <bic:ToolBar ID="tbBottom" runat="server" />
    <asp:LinkButton ID="lbtnSave2" CssClass="btn-save" runat="server" OnCommand="Save" CommandName="Update"><%=BicResource.GetValue("Admin","Admin_XML_Config_Save") %></asp:LinkButton>
</div>
<telerik:RadInputManager runat="server" ID="rimBICCMS" EnableEmbeddedSkins="false" Skin="BICCMS">
    <telerik:TextBoxSetting BehaviorID="bhDisplayName" EmptyMessage="<%$Resources:Admin,System_InputTitle%>" Validation-IsRequired="true">
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