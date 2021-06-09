<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditionPromotion.ascx.cs"
            Inherits="Admin_Components_Promotion_EditionPromotion" %>
<%@ Import Namespace="BIC.Utils" %>
<div class="form-tool">
    <bic:ToolBar ID="tbTop" runat="server" />
    <asp:LinkButton ID="lbtnSave" CssClass="btn-save" runat="server" OnCommand="Save"
                    CommandName="Update"><%=BicResource.GetValue("Admin","Admin_Save") %></asp:LinkButton>
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
              <%=BicResource.GetValue("Admin","Admin_XML_Support_Langue") %> </div>
            <div class="input">
                <bic:Language ID="ddlLanguage" runat="server" CssClass="input-select" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                 <%=BicResource.GetValue("Admin","Admin_XML_Promotion_Title") %>
            </div>
            <div class="input">
                <asp:TextBox ID="txtName" Width="300px" runat="server" CssClass="input-text" />
            </div>
        </div>
    </div>
  <%--  <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
               <%=BicResource.GetValue("Admin","Admin_XML_Support_TypeOfContact") %>
            </div>
            <div class="input">
                <asp:DropDownList runat="server" ID="ddlType" CssClass="input-select">
                    <asp:ListItem Text="info" />
                    <asp:ListItem Text="yahoo" />
                    <asp:ListItem Text="skype" />
                    <asp:ListItem Text="email" />
                    <asp:ListItem Text="website" />
                </asp:DropDownList>
            </div>
        </div>
    </div>--%>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
               <%=BicResource.GetValue("Admin","Admin_XML_Promotion_Content") %>
            </div>
            <div class="input">
                <asp:TextBox ID="txtValue" Width="300px" runat="server" CssClass="input-text" /> (%)
            </div>
        </div>
    </div>
     <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
               <%=BicResource.GetValue("Admin","System_Description")%> 
            </div>
            <div class="input">
                <asp:TextBox ID="txtDescription" Width="300px" runat="server" CssClass="input-text" />
            </div>
        </div>
    </div>
</div>
<div class="form-tool-bottom">
    <bic:ToolBar ID="tbBottom" runat="server" />
    <asp:LinkButton ID="lbtnSave2" CssClass="btn-save" runat="server" OnCommand="Save"
                    CommandName="Update"><%=BicResource.GetValue("Admin","Admin_Save") %></asp:LinkButton>
</div>
<telerik:RadInputManager runat="server" ID="rimBICCMS" EnableEmbeddedSkins="false"
                         Skin="BICCMS">
    <telerik:TextBoxSetting BehaviorID="bhDisplayName" EmptyMessage="<%$Resources:Admin, System_InputTitle%>" Validation-IsRequired="true">
        <TargetControls>
            <telerik:TargetInput ControlID="txtDisplayName" />
        </TargetControls>
    </telerik:TextBoxSetting>
    <telerik:NumericTextBoxSetting BehaviorID="bhViewNo" EmptyMessage="<%$Resources:Admin, System_InputViewCount%>"
                                   DecimalDigits="0">
        <TargetControls>
            <telerik:TargetInput ControlID="txtViewNo" />
        </TargetControls>
    </telerik:NumericTextBoxSetting>
</telerik:RadInputManager>