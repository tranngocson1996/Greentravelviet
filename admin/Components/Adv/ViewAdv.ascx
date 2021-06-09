<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewAdv.ascx.cs" Inherits="Admin_Components_Adv_ViewAdv" %>
<%@ Import Namespace="BIC.Utils" %>
<div class="form-tool">
    <bic:ToolBar ID="tbTop" runat="server" />
</div>
<div class="form-caption">
  <%=BicResource.GetValue("Admin","Admin_Adv_DetailedContents") %> 
</div>
<div class="form-view">
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
               <%=BicResource.GetValue("Admin","Admin_Adv_NameAd") %> <span class="validate">*</span>
            </div>
            <div class="input">
                <asp:Label ID="lblDBName" CssClass="Label" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
               <%=BicResource.GetValue("Admin","Admin_Adv_AdGroup") %>  
            </div>
            <div class="input">
                <asp:Label ID="lblDBTypeOfAdvID" CssClass="Label" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                URL
            </div>
            <div class="input">
                <asp:Label ID="lblDBURL" CssClass="Label" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
               <%=BicResource.GetValue("Admin","System_Target") %>  Target
            </div>
            <div class="input">
                <asp:Label ID="lblDBTarget" CssClass="Label" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
               <%=BicResource.GetValue("Admin","Admin_Adv_Views") %>
            </div>
            <div class="input">
                <asp:Label ID="lblDBViewCount" CssClass="Label" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
               <%=BicResource.GetValue("Admin","Admin_Adv_Expires") %> 
            </div>
            <div class="input">
                <asp:Label ID="lblDBExpireDate" CssClass="Label" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
              <%=BicResource.GetValue("Admin","System_Content") %>  
            </div>
            <div class="input">
                <asp:Label ID="lblDBDescription" CssClass="Label" runat="server" /></div>
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