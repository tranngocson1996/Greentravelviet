<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PasswordRecovery.ascx.cs" Inherits="Controls_User_PasswordRecovery" %>
<%= Include.CssAdd("~/Controls/User/CSS/Login.css")%>
<asp:Panel runat="server">
    <div class="desc">
        Để lấy lại mật khẩu, bạn hãy nhập tên tài khoản, địa chỉ Email khi đăng ký tài khoản này, sau đó ấn nút "Gửi". Hệ thống website sau khi nhận được thông
        báo sẽ gửi Email phản hồi cung cấp Mật khẩu mới cho bạn.
    </div>
    <div>
        <label>Tên tài khoản</label>
        <asp:TextBox ID="txtUsername" CssClass="textBox" runat="server" ValidationGroup="passRecover" ClientIDMode="Static" />
    </div>
    <div>
        <label>Email đăng ký</label>
        <asp:TextBox ID="txtEmail" CssClass="textBox" runat="server" ValidationGroup="passRecover" ClientIDMode="Static" />
    </div>
    <div class="clear">
    </div>
    <div class="button">
        <asp:ImageButton ID="ibtnSendPassRecover" runat="server" ImageUrl="/Controls/User/CSS/img/btn_send.png" OnClick="ImageButton1_Click" ValidationGroup="passRecover"
            ClientIDMode="Static" />
    </div>
</asp:Panel>
<script type="text/javascript" language="javascript">
    $("#ibtnSendPassRecover").attr("disabled", "disabled");
    $(document).ready(function () {
        $("#txtEmail").keypress(function (e) {
            $(".button #ibtnSendPassRecover").removeAttr("disabled");
            if (e.which == 13) {
                $("#ibtnSendPassRecover").click();
            }
        });

        $("#txtUsername").keypress(function (e) {
            $(".button #ibtnSendPassRecover").removeAttr("disabled");
            if (e.which == 13) {
                $("#ibtnSendPassRecover").click();
            }
        });
    });
</script>
