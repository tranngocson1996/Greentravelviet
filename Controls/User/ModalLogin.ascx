<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ModalLogin.ascx.cs" Inherits="Controls_User_ModalLogin" %>
<%@ Import Namespace="BIC.Utils" %>
<%@ Register Src="~/Controls/Adv/ScriptAdv.ascx" TagPrefix="uc1" TagName="ScriptAdv" %>


<a class="login hidden" data-toggle="modal" href='#modal-login'>Đăng nhập</a>
<div class="modal fade modal-custom" id="modal-login">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="row">
                <div class="col-md-4 col-sm-4 col-xs-12 pull-right modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title">Quyền lợi khi đăng ký làm thành viên</h4>
                    <uc1:ScriptAdv runat="server" ID="ucQuyenLoi" TypeOfAdv="3" PageSize="1" />
                </div>
                <div class="col-md-8 col-sm-8 col-xs-12  modal-body">
                    <div class="login-form">
                        <h4>Đăng nhập tài khoản</h4>
                        <div class="form-box">
                            <div class="alert alert-danger hidden" role="alert">Tên đăng nhập hoặc mật khẩu không chính xác</div>
                            <div class="form-group">
                                <label for="login-email">Tài khoản hoặc email</label>
                                <input type="text" class="form-control" id="txtLoginEmail" name="login-email" placeholder="Tài khoản hoặc email" />
                            </div>
                            <div class="form-group">
                                <label for="login-pass">Mật khẩu</label>
                                <input type="password" class="form-control" id="txtLoginPass" name="login-pass" placeholder="Mật khẩu" />
                            </div>
                            <div class="form-group text-right">
                                <input type="checkbox" id="chkLoginRemember" name="login-remember" />
                                <label for="login-remember"><%=BicResource.GetValue("UserManager","Remember") %></label>
                            </div>
                            <div class="form-group">
                                <input type="button" value="Đăng nhập" class="btn btn-login" onclick="login()" />
                            </div>
                        </div>
                        <div class="social-login">
                            <span>Hoặc đăng nhập bằng</span>
                            <asp:Button runat="server" ID="facebookloginButton" CssClass="hidden" OnClick="btnLoginFacebook_OnClick" />
                            <asp:Button runat="server" ID="googleloginButton" CssClass="hidden" OnClick="btnLoginGoogle_OnClick" />
                            <a id="facebooklogin" href="javascript:void(0)"><i class="fa fa-facebook" aria-hidden="true"></i>&nbsp; Đăng nhập vào facebook</a>
                            <a id="googlelogin" href="javascript:void(0)"><i class="fa fa-google" aria-hidden="true"></i>&nbsp; Đăng nhập vào gmail</a>
                            <script type="text/javascript">
                                $(document).ready(function () {
                                    $('#facebooklogin')
                                        .click(function () {
                                            $('#<%=facebookloginButton.ClientID %>').click();
                                        });
                                    $('#googlelogin')
                                        .click(function () {
                                            $('#<%=googleloginButton.ClientID %>').click();
                                        });
                                });

                            </script>
                        </div>
                    </div>
                    <div class="form-reset-pw hidden">
                        <h4>Khôi phục mật khẩu</h4>
                        <div class="form-box">
                            <div class="form-group">
                                <label for="">Vui lòng nhập Email hoặc tên tài khoản của bạn để chúng tôi gửi lại mật khẩu</label>
                                <input type="password" class="form-control" id="" placeholder="Địa chỉ email hoặc tên tài khoản">
                            </div>
                            <div class="form-group">
                                <input type="button" value="Lấy lại mật khẩu" class="btn btn-reset-pw" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">
    function login() {
        var username = $("#txtLoginEmail").val();
        var password = $("#txtLoginPass").val();
        var rememberMe = $("#chkLoginRemember").is(":checked");
        if (rememberMe) {
            rememberMe = "checked";
        } else {
            rememberMe = "";
        }

        $.ajax({
            type: "POST",
            url: "<%=Page.ResolveUrl("~/WebService/Login.asmx/VerifyLogin")%>",
            data: "{username: '" + username + "', password:'" + password + "', rememberMe:'" + rememberMe + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.d == true) {
                    window.location = window.location.href;
                }
                else {
                    $('.form-box .alert').removeClass("hidden");
                }
            }
        });
    }

    function logout(username) {
        $.ajax({
            type: "POST",
            url: "<%=Page.ResolveUrl("~/WebService/Login.asmx/Logout")%>",
            data: "{username: '" + username + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.d == true) {
                    window.location = window.location.href;
                }
                else {
                    alert("Error!")
                }
            }
        });
    }
</script>
