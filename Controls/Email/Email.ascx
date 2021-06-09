<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Email.ascx.cs" Inherits="Controls_Email_Email" %>
<%@ Import Namespace="BIC.Utils" %>
<div class="subscribe">
    <div class="subscribe-title"><%= BicResource.GetValue("SubscribeTitle") %></div>
    <div class="subscribe-control">
        <div class="bao">
            <asp:TextBox ID="txtsend" CssClass="input-email" ClientIDMode="Static" runat="server" placeholder="<%$Resources:Resource,EmailAddress%>" onkeypress="return EnterEmailEvent(event)" Text="" ValidationGroup="email"></asp:TextBox>
            <asp:Button ID="lnkSend" CssClass="btn-subscribe" runat="server" OnClick="ibtSend_Click" Text="<%$Resources:Resource,Subscribe %>" ValidationGroup="email"></asp:Button>
        </div>
    </div>
    <div class="subscribe-desc">
        <%= BicResource.GetValue("SubscribeDesc") %>
    </div>
</div>
<script type="text/javascript">
    function EnterEmailEvent(e) {
        if (e.keyCode == 13) {
            __doPostBack('<%=lnkSend.UniqueID%>', "");
        }
    }
</script>