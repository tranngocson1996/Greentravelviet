<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ModalRegister.ascx.cs" Inherits="Controls_User_ModalRegister" %>
<%@ Import Namespace="BIC.Utils" %>
<%@ Register Src="~/Controls/Adv/ScriptAdv.ascx" TagPrefix="uc1" TagName="ScriptAdv" %>


<a class="register hidden" data-toggle="modal" href='#modal-register'>Đăng ký</a>
<div class="modal fade modal-custom" id="modal-register">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="row">
                <div class="col-md-4 col-sm-4 col-xs-12 pull-right modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title">Quyền lợi khi đăng ký làm thành viên</h4>
                    <uc1:ScriptAdv runat="server" ID="ucQuyenLoi" TypeOfAdv="3" PageSize="1" />
                </div>
                <div class="col-md-8 col-sm-8 col-xs-12  modal-body">
                    <div class="register-form">
                        <h4><%=BicResource.GetValue("UserManager","RigisterAccount") %></h4>
                        <div class="form-box">
                            <div class="alert alert-danger hidden" role="alert" runat="server" id="messenger"></div>
                            <div class="form-group">
                                <label for="">Tên đăng nhập <span class="text-danger">*</span></label>
                                <input type="text" class="form-control" id="RegUserName" placeholder="Tên đăng nhập" runat="server">
                            </div>
                            <div class="form-group">
                                <label for="">Email <span class="text-danger">*</span></label>
                                <input type="text" class="form-control" id="RegEmail" placeholder="Địa chỉ email" runat="server">
                            </div>
                            <div class="form-group">
                                <label for="">Số điện thoại <span class="text-danger">*</span></label>
                                <input type="text" class="form-control" id="RegPhone" placeholder="Số điện thoại" runat="server">
                            </div>
                            <div class="form-group">
                                <label for="">Mật khẩu <span class="text-danger">*</span></label>
                                <input type="password" class="form-control" id="RegPassword" placeholder="Mật khẩu" runat="server">
                            </div>
                            <div class="form-group">
                                <label for="">Nhập lại mật khẩu</label>
                                <input type="password" class="form-control" id="RegPasswordComfirm" placeholder="Xác nhận mật khẩu" runat="server">
                            </div>
                            <div class="form-group">
                                <input type="button" value="<%= BicResource.GetValue("UserManager","Bt_Register") %>" class="btn btn-register" />
                                <asp:HiddenField ID="hdCheck" runat="server" />
                                <asp:Button ID="btnRegister" runat="server" Text="<%$Resources:UserManager,Bt_Register %>" CssClass="btn hidden" OnClick="btnRegister_Click" />
                            </div>
                        </div>
                        <div class="social-login">
                            <span>Hoặc đăng nhập bằng</span>
                            <asp:Button runat="server" ID="facebookloginButton" CssClass="hidden" OnClick="btnLoginFacebook_OnClick" />
                            <asp:Button runat="server" ID="googleloginButton" CssClass="hidden" OnClick="btnLoginGoogle_OnClick" />
                            <a id="facebookrelogin" href="javascript:void(0)"><i class="fa fa-facebook" aria-hidden="true"></i>&nbsp; Đăng nhập vào facebook</a>
                            <a id="googlerelogin" href="javascript:void(0)"><i class="fa fa-google" aria-hidden="true"></i>&nbsp; Đăng nhập vào gmail</a>
                            <script type="text/javascript">
                                $(document).ready(function () {
                                    $('#facebookrelogin')
                                        .click(function () {
                                            $('#<%=facebookloginButton.ClientID %>').click();
                                        });
                                    $('#googlerelogin')
                                        .click(function () {
                                            $('#<%=googleloginButton.ClientID %>').click();
                                        });
                                });

                            </script>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">
    function IsEmail(email) {
        var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
        return regex.test(email);
    }
    function IsUser(username) {
        var regex = /^[a-z]([0-9a-z_])+$/i;
        return regex.test(username);
    }
    function isValidPhone(p) {
        //var phoneRe = /^[2-9]\d{2}[2-9]\d{2}\d{4}$/;
        //var digits = p.replace(/\D/g, "");
        //return (digits.match(phoneRe) !== null);
        var regex = /^([0-9])+$/i;
        return regex.test(p);
    }
    function checkUsernameExits(username) {
        if (IsUser(username)) {
            $.ajax({
                type: "POST",
                data: "{username: '" + username + "' }",
                contentType: "application/json; charset=utf-8",
                url: '<%=Page.ResolveUrl("~/WebService/Login.asmx/user_validation")%>',
                dataType: "json",
                success: function (data) {
                    if (data.d == 1) {
                        $('#modal-register .alert').html("<%=BicResource.GetValue("UserManager","REGISTER_ERR_EXIST_USERNAME") %>");
                        $('#modal-register .alert').addClass("alert-danger");
                        $('#modal-register .alert').removeClass("alert-success");
                        $('#modal-register .alert').removeClass("hidden");
                        return false;
                    }
                    else {
                        $('#modal-register .alert').html("<%=BicResource.GetValue("UserManager","REGISTER_SUCC_USERNAME") %>");
                        $('#modal-register .alert').addClass("alert-success");
                        $('#modal-register .alert').removeClass("alert-danger");                        
                    }                    
                },
                error: function () {
                    $('#modal-register .alert').html("Server đang bận. vui lòng nhấn F5 và thử lại.");
                    $('#modal-register .alert').removeClass("hidden");
                    return false;
                }
            });
            return true;
        }
        else {
            $('#modal-register .alert').html("<%=BicResource.GetValue("UserManager","REGISTER_ERR_FORMAT_USERNAME") %>");
            $('#modal-register .alert').addClass("alert-danger");
            $('#modal-register .alert').removeClass("alert-success");
            $('#modal-register .alert').removeClass("hidden");
            return false;
        }        
    }

    function checkEmailExits(email) {
        if (IsEmail(email)) {
            $.ajax
            ({
                type: "POST",
                data: "{email: '" + email + "' }",
                contentType: "application/json; charset=utf-8",
                url: "<%=Page.ResolveUrl("~/WebService/Login.asmx/email_validation")%>",
                dataType: "json",
                success: function (data) {
                    if (data.d == 1) {
                        $('#modal-register .alert').html("<%=BicResource.GetValue("UserManager","REGISTER_ERR_EXIST_EMAIL") %>");
                        $('#modal-register .alert').addClass("alert-danger");
                        $('#modal-register .alert').removeClass("alert-success");
                        $('#modal-register .alert').removeClass("hidden");
                        return false;
                    }
                    else {
                        $('#modal-register .alert').html("<%=BicResource.GetValue("UserManager","REGISTER_SUCC_EMAIL") %>");
                        $('#modal-register .alert').addClass("alert-success");
                        $('#modal-register .alert').removeClass("alert-danger");
                    }
                },
                error: function () {
                    $('#modal-register .alert').html("Server đang bận. vui lòng nhấn F5 và thử lại.");
                    $('#modal-register .alert').removeClass("hidden");
                    return false;
                }
            });
            return true;
        }
        else {
            $('#modal-register .alert').html("<%=BicResource.GetValue("UserManager","REGISTER_ERR_FORMAT_EMAIL") %>");
            $('#modal-register .alert').addClass("alert-danger");
            $('#modal-register .alert').removeClass("alert-success");
            $('#modal-register .alert').removeClass("hidden");
            return false;
        }
    }

    function checkPassComfirm() {
        if ($('[id*=RegPasswordComfirm]').val() === $('[id*=RegPassword]').val()) {
            if ($('#modal-register .alert').hasClass("hidden") == false)
                $('#modal-register .alert').addClass("hidden");
            return true;
        }
        else {
            $('#modal-register .alert').html("<%=BicResource.GetValue("UserManager","REGISTER_ERR_NOT_MATCH_PASS") %>");
            $('#modal-register .alert').addClass("alert-danger");
            $('#modal-register .alert').removeClass("alert-success");
            $('#modal-register .alert').removeClass("hidden");
            return false;
        }
    }

    $(document).ready(function () {

        var checkUser;
        var checkEmail;
        var checkPhone;

        $('[id*=RegUserName]').on('blur', function () {
            checkUser = checkUsernameExits($(this).val());
        });

        $('[id*=RegEmail]').on('blur', function () {
            checkEmail = checkEmailExits($(this).val());
        });

        $('[id*=RegPhone]').on('blur', function () {
            var phone = $(this).val();
            if (isValidPhone(phone)) {
                if ($('#modal-register .alert').hasClass("hidden") == false)
                    $('#modal-register .alert').addClass("hidden");
                checkPhone = true;
            }
            else {
                $('#modal-register .alert').html("Số điện thoại không hợp lệ.");
                $('#modal-register .alert').addClass("alert-danger");
                $('#modal-register .alert').removeClass("hidden");
                checkPhone = false;
            }
        });

        $('[id*=RegPasswordComfirm]').on('blur', function () {
            checkPassComfirm();
        });
        $('#modal-register .btn-register').click(function () {
            if (checkUsernameExits($('[id*=RegUserName]').val()) && checkEmailExits($('[id*=RegEmail]').val()) && checkPhone && checkPassComfirm()) {
                $('#<%=btnRegister.ClientID %>').click();
            }
        });
    });
</script>
