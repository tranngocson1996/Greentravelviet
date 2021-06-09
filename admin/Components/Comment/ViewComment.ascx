<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewComment.ascx.cs" Inherits="Admin_Components_Comment_ViewComment" %>
<%@ Import Namespace="BIC.Utils" %>
<div class="form-tool">
    <bic:ToolBar ID="tbTop" runat="server" CssEdit="hidden" CssAdd="hidden" />
    <asp:LinkButton CssClass="btn-addnew" runat="server" ID="lbAdd" Visible="False">
                 <%=BicResource.GetValue("Admin","Admin_Save") %>   
    </asp:LinkButton>
</div>
<div class="form-caption">
    <%=BicResource.GetValue("Admin","Admin_Comment_DetailedContents")%>
</div>
<div class="form-view">
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <%=BicResource.GetValue("Admin","Admin_Comment_Sender")%> <span class="validate">*</span>
            </div>
            <div class="input">
                <asp:Label ID="lblDBFullName" CssClass="Label" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow" runat="server" visible="False">
        <div class="frow-wrapp">
            <div class="label">
                <%=BicResource.GetValue("Admin","Admin_Comment_Sex")%>  Giới tính
            </div>
            <div class="input">
                <asp:Label ID="lblSex" CssClass="Label" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow" runat="server" visible="False">
        <div class="frow-wrapp">
            <div class="label">
                <%=BicResource.GetValue("Admin","Admin_Comment_PostSubject")%>
            </div>
            <div class="input">
                <asp:Label ID="lblObjTitle" CssClass="Label" Width="90%" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <%=BicResource.GetValue("Admin","System_Content")%>
            </div>
            <div class="input">
                <asp:Label ID="lblDBDescription" CssClass="Label" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow" runat="server" Visible="False">
        <div class="frow-wrapp">
            <div class="label">
                <%=BicResource.GetValue("Admin","Admin_Comment_AgreeOrNoAgree")%>
            </div>
            <div class="input">
                <asp:Label ID="lbldongy" CssClass="Label" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <%=BicResource.GetValue("Admin","Admin_Comment_DateSubmitted")%>
            </div>
            <div class="input">
                <asp:Label ID="lblCreateDate" CssClass="Label" Width="10%" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <%=BicResource.GetValue("Admin","Admin_Comment_DateEdit")%>
            </div>
            <div class="input">
                <asp:Label ID="lblModifiedDate" CssClass="Label" Width="10%" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow hidden">
        <div class="frow-wrapp">
            <div class="label">
                <%=BicResource.GetValue("Admin","Admin_Comment_Email")%>
            </div>
            <div class="input">
                <asp:Label ID="lblEmail" CssClass="Label" Width="30%" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow" runat="server" Visible="False">
        <div class="frow-wrapp">
            <div class="label">
                <%=BicResource.GetValue("Admin","Admin_Comment_SenderAddress")%>
            </div>
            <div class="input">
                <asp:Label ID="lblAddress" CssClass="Label" Width="30%" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <%=BicResource.GetValue("Admin","System_Browse")%>
            </div>
            <div class="input">
                <asp:CheckBox Enabled="false" ID="chkIsActive" runat="server"></asp:CheckBox>
            </div>
        </div>
    </div>
</div>
<div class="form-tool-bottom">
    <bic:ToolBar ID="tbBottom" runat="server" CssEdit="hidden" CssAdd="hidden" />
</div>
