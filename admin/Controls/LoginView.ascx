<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LoginView.ascx.cs" Inherits="admin_Controls_LoginView" %>
<%@ Import Namespace="BIC.Utils" %>
<div id="divDialogChangePass" title="Đổi mật khẩu" class="hidden">
    <iframe id="ifDialogChangePass" width="100%" height="100%" marginwidth="0" marginheight="0" frameborder="0" scrolling="no"
        title="Dialog Title">Your browser does not support</iframe>
</div>
<script type="text/javascript">
    $.fx.speeds._default = 1000;
    function showChangePass() {
        $("#divDialogChangePass").dialog("open");
        $("#ifDialogChangePass").attr("src", '<%= Page.ResolveUrl("~/admin/Components/Security/User/ChangePassword.aspx?l="+BicLanguage.CurrentLanguageAdmin) %>');
        return false;
    }
    function BindDialogChangePass() {
        $(function () {
            $("#divDialogChangePass").dialog({
                autoOpen: false,
                modal: true,
                height: 240,
                width: 390,
                resizable: false
            });
        });
    }
</script>
<script type="text/javascript">
    Sys.Application.add_load(BindDialogChangePass);
</script>
<div class="login-view">
    <asp:LoginName ID="lnAdmin" runat="server" CssClass="login-name" />
    ( <a href='#' onclick=" return showChangePass();return false; "><%=BicResource.GetValue("Admin","Admin_LoginView_ChangePassword") %></a> |
    <asp:LoginStatus ID="lsAdmin" runat="server" LoginText="<%$Resources:Admin, Admin_LoginView_Login%>" LogoutAction="RedirectToLoginPage" LogoutText="<%$Resources:Admin, Admin_LoginView_Exit%>"
        OnLoggingOut="lsAdmin_LoggingOut" ToolTip="Thoát" />
    )
</div>
