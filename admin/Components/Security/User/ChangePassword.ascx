<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.ascx.cs" Inherits="Admin_Components_ChangePassword" %>
<%= IncludeAdmin.JqueryUI() %>
<%= IncludeAdmin.DefaultCss() %>
<%@ Import Namespace="BIC.Utils" %>
<div class="form-modal-pass">
    <asp:ChangePassword ID="ChangePassword1" runat="server" ChangePasswordFailureText="<%$Resources:Admin,Admin_Security_User_YouEnterTheOldPassword%>">
        <ChangePasswordTemplate>
            <div class="form-tool">
                <asp:LinkButton ID="CancelPushButton" runat="server" CausesValidation="False" CommandName="Cancel" CssClass="btn-reset"  Text="Làm lại" />
                <asp:LinkButton ID="ChangePasswordPushButton" runat="server" CommandName="ChangePassword" ValidationGroup="ctl00$ChangePassword1" CssClass="btn-save"  Text="Lưu mật khẩu" />
            </div>
            <table class="form-view f3">
                <tr>
                    <td class="label fixed-label">
                        <asp:Label ID="CurrentPasswordLabel" runat="server" AssociatedControlID="CurrentPassword"> <%=BicResource.GetValue("Admin","Admin_Security_User_OldPassword") %></asp:Label>
                    </td>
                    <td class="input">
                        <asp:TextBox ID="CurrentPassword" runat="server" TextMode="Password" CssClass="input-text"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" ControlToValidate="CurrentPassword"  ErrorMessage="<%$Resources:Admin,Admin_Security_User_NoOldPassword%>" ToolTip="<%$Resources:Admin,Admin_Security_User_PasswordIsRequired%>"
                                                    ValidationGroup="ctl00$ChangePassword1">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="alt">
                    <td class="label fixed-label">
                    <asp:Label ID="NewPasswordLabel" runat="server" AssociatedControlID="NewPassword"><%=BicResource.GetValue("Admin","Admin_Security_User_NewPassword") %></asp:Label></tdclass>
                    <td class="input">
                        <asp:TextBox ID="NewPassword" runat="server" TextMode="Password" CssClass="input-text"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword" ErrorMessage="<%$Resources:Admin,Admin_Security_User_DidNotEnterANewPassword%>" ToolTip="<%$Resources:Admin,Admin_Security_User_NewPasswordIsRequired%>"
                                                    ValidationGroup="ctl00$ChangePassword1">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="label fixed-label">
                        <asp:Label ID="ConfirmNewPasswordLabel" runat="server" AssociatedControlID="ConfirmNewPassword"><%=BicResource.GetValue("Admin","Admin_Security_User_RetypeNewPassword") %>  </asp:Label>
                    </td>
                    <td class="input">
                        <asp:TextBox ID="ConfirmNewPassword" runat="server" TextMode="Password" CssClass="input-text"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword" ErrorMessage="<%$Resources:Admin,Admin_Security_User_NotConfirmThePassword%>"
                                                    ToolTip="Confirm New Password is required." ValidationGroup="ctl00$ChangePassword1">*</asp:RequiredFieldValidator>
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
        </td> </tr> </table>
        </ChangePasswordTemplate>
    </asp:ChangePassword>
</div>