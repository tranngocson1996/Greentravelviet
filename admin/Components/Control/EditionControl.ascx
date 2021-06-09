<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditionControl.ascx.cs" Inherits="Admin_Components_Control_EditionControl" %>
<%@ Import Namespace="BIC.Utils" %>
<div class="form-tool">
    <bic:ToolBar ID="tbTop" runat="server" />
    <asp:LinkButton ID="lbtnSave" CssClass="btn-save" runat="server" OnCommand="Save" CommandName="Update"><%=BicResource.GetValue("Admin","Admin_Controls_Save") %></asp:LinkButton>
</div>
<div class="form-caption">
    <%= BicMessage.EditTitle %>
    <span class="note"><em>*</em>
        <%= BicMessage.RequireTitle %>
    </span>
</div>
<div class="form-view">
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <%=BicResource.GetValue("Admin","Admin_Controls_ControlsName") %><span class="validate">*</span>
            </div>
            <div class="input">
                <asp:TextBox ID="txtControlName" CssClass="input-text" Width="200px" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
               <%=BicResource.GetValue("Admin","Admin_Controls_DirectoryName") %> 
            </div>
            <div class="input">
                <asp:TextBox ID="txtFolderName" CssClass="input-text" Width="200px" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
               <%=BicResource.GetValue("Admin","Admin_Controls_Path") %> 
            </div>
            <div class="input">
                <asp:TextBox ID="txtControlUrl" CssClass="input-text" Width="97%" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
               <%=BicResource.GetValue("Admin","Admin_Controls_Load") %> 
            </div>
            <div class="input">
                <asp:CheckBox ID="chkLoadUrl" CssClass="" Width="" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
              <%=BicResource.GetValue("Admin","System_Browse") %> 
            </div>
            <div class="input">
                <asp:CheckBox ID="chkIsActive" CssClass="" Width="" runat="server" /></div>
        </div>
    </div>
</div>
<div class="form-tool-bottom">
    <bic:ToolBar ID="tbBottom" runat="server" />
    <asp:LinkButton ID="lbtnSave2" CssClass="btn-save" runat="server" OnCommand="Save" CommandName="Update"><%=BicResource.GetValue("Admin","Admin_Controls_Save") %></asp:LinkButton>
</div>