<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Admin_Login" %>

<%@ Register Src="~/admin/Controls/AdminLanguage.ascx" TagPrefix="uc1" TagName="AdminLanguage" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng nhập hệ thống</title>
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <%= IncludeAdmin.LoginCss()%>
    </telerik:RadCodeBlock>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="header">
                <div class="logo">
                </div>
            </div>
            <div class="main">
                <div class="login-frame">
                    <asp:Login ID="lgMain" runat="server" CreateUserText="Tạo tài khoản mới" PasswordRecoveryText="Quên mật khẩu"
                        FailureText="Đăng nhập không thành công, hãy thử lại" ToolTip="Đăng nhập hệ thống" OnLoggedIn="lgMain_LoggedIn" OnLoggingIn="lgMain_LoggingIn">
                        <LayoutTemplate>
                            <asp:Label ID="FailureText" runat="server" CssClass="fail-text" EnableViewState="False"></asp:Label>
                            <asp:TextBox ID="UserName" runat="server" CssClass="input-user" TabIndex="1" ValidationGroup="login"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="UerNameRequired" runat="server" CssClass="valid-user" ControlToValidate="UserName" ErrorMessage="Nhập tên đăng nhập."
                                ValidationGroup="lgMain">*</asp:RequiredFieldValidator>
                            <asp:TextBox ID="Password" runat="server" TextMode="password" CssClass="input-pass" TabIndex="2" ValidationGroup="login"></asp:TextBox></td>
                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" CssClass="valid-pass" ControlToValidate="Password" ErrorMessage="Nhập mật khẩu."
                            ValidationGroup="login">*</asp:RequiredFieldValidator></tr>
                        <asp:CheckBox ID="RememberMe" Visible="true" runat="server" CssClass="input-remember" TabIndex="3" ValidationGroup="login" />
                            <asp:ImageButton runat="server" ID="ibtnLogin" CommandName="Login" ImageUrl="~/admin/Styles/icon/BUTTON_LOGIN_88X24.gif"
                                CssClass="input-login" TabIndex="4" ValidationGroup="login" />
                            
                            <asp:DropDownList ID="ddlAdminLanguage" runat="server" />
                        </LayoutTemplate>
                    </asp:Login>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
