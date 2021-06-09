<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ShareByEmail.ascx.cs" Inherits="Controls_Article_Tools_ShareByEmail" %>
<%@ Import Namespace="BIC.Utils" %>
<%=Include.ShareByEmail()%>
<div class="shareByEmailFrame">
    <div class="shareByEmailBlock">
        <div class="label">
            <%=BicResource.GetValue("ShareByEmail_Sender")%></div>
        <asp:TextBox runat="server" ID="txtSender" CssClass="textBox" />
        <div class="label">
            <%=BicResource.GetValue("ShareByEmail_EmailFrom")%></div>
        <asp:TextBox runat="server" ID="txtEmailFrom" CssClass="textBox" />
        <div class="label">
            <%=BicResource.GetValue("ShareByEmail_EmailTo")%></div>
        <asp:TextBox runat="server" ID="txtEmailTo" CssClass="multiTextBox" TextMode="MultiLine" />
        <div class="label">
            <%=BicResource.GetValue("ShareByEmail_Note")%></div>
        <asp:TextBox runat="server" ID="txtEmailContent" TextMode="MultiLine" CssClass="multiTextBox" />
        <div class="buttonBar">
            <div class="button">
                <asp:ImageButton runat="server" ID="ibtSend" ImageUrl="<%$Resources:Resource, SharedByEmail_Send%>" OnClick="ibtSend_Click" /></div>
            <div class="button">
                <asp:ImageButton runat="server" ID="ibtReset" ImageUrl="<%$Resources:Resource, SharedByEmail_Reset%>" OnClick="ibtReset_Click" /></div>
        </div>
    </div>
</div>