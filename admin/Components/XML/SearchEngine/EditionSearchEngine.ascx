<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditionSearchEngine.ascx.cs" 
            Inherits="Admin_Components_SearchEngine_EditionSearchEngine" %>
<%@ Import Namespace="BIC.Utils" %>
<div class="form-tool">
    <bic:ToolBar ID="tbTop" runat="server" />
    <asp:LinkButton ID="lbtnSave" CssClass="btn-save" runat="server" OnCommand="Save"
                    CommandName="Update"><%=BicResource.GetValue("Admin","Admin_XML_SearchEngine_Save") %></asp:LinkButton>
</div>
<div class="form-caption">
    <%= BicMessage.EditTitle %> <span class="note">
                                            <asp:Literal ID="ltrNote" runat="server" />
                                            <em>*</em> <%= BicMessage.RequireTitle %> </span>
</div>
<div class="form-view">
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <%=BicResource.GetValue("Admin","Admin_XML_SearchEngine_ConfigurationName") %>
            </div>
            <div class="input">
                <asp:Label ID="lblConfigName" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
               <%=BicResource.GetValue("Admin","Admin_XML_SearchEngine_Value") %>
            </div>
            <div class="input">
                <asp:TextBox ID="txtValue" CssClass="input-text" Width="500px" runat="server"
                    />
            </div>
        </div>
    </div>
  

</div>
<div class="form-tool-bottom">
    <bic:ToolBar ID="tbBottom" runat="server" />
    <asp:LinkButton ID="lbtnSave2" CssClass="btn-save" runat="server" OnCommand="Save"
                    CommandName="Update"><%=BicResource.GetValue("Admin","Admin_XML_SearchEngine_Save") %></asp:LinkButton>
</div>
<telerik:RadInputManager runat="server" ID="rimBICCMS" EnableEmbeddedSkins="false"
                         Skin="BICCMS">
    <telerik:TextBoxSetting BehaviorID="bhDisplayName" EmptyMessage="<%$Resources:Admin, System_InputTitle%>" Validation-IsRequired="true">
        <TargetControls>
            <telerik:TargetInput ControlID="txtDisplayName" />
        </TargetControls>
    </telerik:TextBoxSetting>
    <telerik:NumericTextBoxSetting BehaviorID="bhViewNo" EmptyMessage="<%$Resources:Admin, System_InputTitle%>"
                                   DecimalDigits="0">
        <TargetControls>
            <telerik:TargetInput ControlID="txtViewNo" />
        </TargetControls>
    </telerik:NumericTextBoxSetting>
</telerik:RadInputManager>