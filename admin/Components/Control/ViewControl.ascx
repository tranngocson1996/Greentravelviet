<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewControl.ascx.cs" Inherits="Admin_Components_Control_ViewControl" %>
<%@ Import Namespace="BIC.Utils" %>
<div class="form-tool">
    <bic:ToolBar ID="tbTop" runat="server" />
</div>
<div class="form-caption">
    <%=BicResource.GetValue("Admin","Admin_Controls_DetailedContent") %>
</div>
<div class="form-view">
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                  <%=BicResource.GetValue("Admin","Admin_Controls_ControlsName") %>
            </div>
            <div class="input">
                <asp:Label ID="lblDBControlName" CssClass="Label" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                 <%=BicResource.GetValue("Admin","Admin_Controls_DirectoryName") %>
            </div>
            <div class="input">
                <asp:Label ID="lblDBFolderName" CssClass="Label" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                  <%=BicResource.GetValue("Admin","Admin_Controls_Path") %>
            </div>
            <div class="input">
                <asp:Label ID="lblDBControlUrl" CssClass="Label" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                 <%=BicResource.GetValue("Admin","Admin_Controls_Load") %> 
            </div>
            <div class="input">
                <asp:CheckBox Enabled="false" ID="chkLoadUrl" runat="server"></asp:CheckBox></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                 <%=BicResource.GetValue("Admin","System_Browse") %>
            </div>
            <div class="input">
                <asp:CheckBox Enabled="false" ID="chkIsActive" runat="server"></asp:CheckBox></div>
        </div>
    </div>
</div>
<div class="form-tool-bottom">
    <bic:ToolBar ID="tbBottom" runat="server" />
</div>