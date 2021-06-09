<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ChangeOtherPassword.ascx.cs" Inherits="Admin_Components_ChangeOtherPassword" %>
<%= IncludeAdmin.DefaultCss() %>
<%@ Import Namespace="BIC.Utils" %>
<%= IncludeAdmin.JqueryUI() %>

<script type="text/javascript">
    $(function() {var username = window.top.$("#radGridSelectedRowIndex").val();$('#txtUserName').val(username);$('#lblUserName').html(username);$('#btncancel').click(function() {$('input[type="password"]').val('');return false;});});
</script>
<input type="hidden" id="txtUserName" name="txtUserName" />
<div class="form-modal-pass">
    <div class="form-tool">
        <a id="btncancel" class="btn-reset" href="#"></a>
        <asp:LinkButton ID="ChangePasswordPushButton" runat="server" OnCommand="Save" CommandName="ChangePassword" Text="" ValidationGroup="ctl00$ChangePassword1"
                        CssClass="btn-save" />
    </div>
    <table class="form-view f3">
        <tr>
            <td class="label fixed-label">
                 <%=BicResource.GetValue("Admin","Admin_Security_User_AcountName") %>
            </td>
            <td class="input">
                <asp:Label runat="server" ID="lblUserName" ClientIDMode="Static" />
            </td>
        </tr>
        <tr class="alt">
            <td class="label fixed-label">
                <asp:Label ID="NewPasswordLabel" runat="server" AssociatedControlID="NewPassword"><%=BicResource.GetValue("Admin","Admin_Security_User_NewPassword") %></asp:Label>
            </td>
            <td class="input">
                <asp:TextBox ID="NewPassword" runat="server" TextMode="Password" CssClass="input-text"></asp:TextBox>
                <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword" ErrorMessage="<%$Resources:Admin,Admin_Security_User_DidNotEnterANewPassword%>" ToolTip="<%$Resources:Admin,Admin_Security_User_NewPasswordIsRequired%>"
                                            ValidationGroup="ctl00$ChangePassword1">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="label fixed-label">
                <asp:Label ID="ConfirmNewPasswordLabel" runat="server" AssociatedControlID="ConfirmNewPassword"><%=BicResource.GetValue("Admin","Admin_Security_User_RetypeNewPassword") %></asp:Label>
            </td>
            <td class="input">
                <asp:TextBox ID="ConfirmNewPassword" runat="server" TextMode="Password" CssClass="input-text"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword" ErrorMessage="<%$Resources:Admin,Admin_Security_User_YetToConfirmThePassword%>"  
                                            ToolTip="<%$Resources:Admin,Admin_Security_User_ConfirmNewPasswordIsRequired%>" ValidationGroup="ctl00$ChangePassword1">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr class="alt">
            <td align="center" colspan="2" style="color:red;height:20px;">
                <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword" Display="Dynamic" ErrorMessage="<%$Resources:Admin,Admin_Security_User_PasswordConfirmationDoesNotMatch%>"
                                      ValidationGroup="ctl00$ChangePassword1"></asp:CompareValidator>
                <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
            </td>
        </tr>
    </table>
</div>