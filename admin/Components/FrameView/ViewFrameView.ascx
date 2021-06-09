<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewFrameView.ascx.cs" Inherits="Admin_Components_FrameView_ViewFrameView" %>
<%@ Import Namespace="BIC.Utils" %>

<div class="form-tool">
    <bic:ToolBar ID="tbTop" runat="server" />
</div>
<div class="form-caption">
   <%=BicResource.GetValue("Admin","Admin_FrameView_DetailedContents") %> 
    
</div>
<div class ="form-view">
    <div class="frow"> <div class="frow-wrapp"> <div class="label"><%=BicResource.GetValue("Admin","Admin_FrameView_FunctionName") %>  </div> <div class="input"><asp:Label ID="lblDBName" CssClass="Label" runat="server"/></div></div> </div>
    <div class="frow"> <div class="frow-wrapp"> <div class="label"><%=BicResource.GetValue("Admin","Admin_FrameView_Law") %>  </div> <div class="input"><asp:Label ID="lblDBURLControl" CssClass="Label" runat="server"/></div></div> </div>
    <div class="frow"> <div class="frow-wrapp"> <div class="label"><%=BicResource.GetValue("Admin","Admin_FrameView_GroupName") %>  </div> <div class="input"><asp:Label ID="lblDBGroupName" CssClass="Label" runat="server"/></div></div> </div>
    <div class="frow"><div class="frow-wrapp"><div class="label"><%=BicResource.GetValue("Admin","Admin_FrameView_ResourceKey") %> </div><div class="input"><asp:TextBox ID="txtResourceKey" CssClass="input-text" Width="300px" runat="server" /></div></div></div>    
    <div class="frow"> <div class="frow-wrapp"> <div class="label"><%=BicResource.GetValue("Admin","Admin_FrameView_StyleFunction") %>  </div> <div class="input"><asp:Label ID="lblDBTypeOfControl" CssClass="Label" runat="server"/></div></div> </div>
    <div class="frow"> <div class="frow-wrapp"> <div class="label"><%=BicResource.GetValue("Admin","Admin_FrameView_Browse") %>  </div> <div class="input"> <asp:CheckBox runat="server" ID="chkIsActive"/></div></div></div></div>
<div class="form-tool-bottom">
    <bic:ToolBar ID="tbBottom" runat="server" />
</div>