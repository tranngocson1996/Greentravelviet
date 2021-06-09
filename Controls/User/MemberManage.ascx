<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MemberManage.ascx.cs" Inherits="Controls_User_MemberManage" %>
<%@ Import Namespace="BIC.Utils" %>

<link href="<%=Page.ResolveUrl("~") %>Controls/User/CSS/MemberManage.css" rel="stylesheet" />
<script src="<%=Page.ResolveUrl("~") %>Controls/User/MemberManage.js"></script>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always" style="float: left;">
    <ContentTemplate>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
            <ProgressTemplate>
                <div class="loading">
                    <%=BicResource.GetValue("UserManager","ProcessingData") %>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:Panel ID="From_DN" runat="server">
            <div id="Login" class="Exist">
                <ul>
                    <li class="login">
                        <asp:LinkButton ID="LinkButton2" CssClass="submit_btn" Text="<%$ Resources:Resource,LoginBar_LoginButton %>" runat="server" OnClick="lb_Login_Click" OnClientClick="loadLoginBox();"></asp:LinkButton>|</li>
                    <li>
                        <asp:LinkButton ClientIDMode="Static" ID="LinkButton1" CssClass="submit_btn" Text="<%$ Resources:Resource,LoginBar_RegisterButton %>" runat="server" OnClick="lb_Register_Onclick"></asp:LinkButton></li>
                    <li class="shopping-cart" runat="server" ID="liCart"> <a href="<%=ResolveUrl("~")+BicLanguage.CurrentLanguage%>/shopping-cart.sc1.html">GIỎ HÀNG CỦA BẠN</a><span class="sum-product">(CÓ <span id="TotalQuanlity"><%=Session["TotalQuanlity"] != null ? BicConvert.ToString(Session["TotalQuanlity"]) : "0" %></span> SẢN PHẨM)</span></li>
                    <%--<li>
                        <asp:LinkButton ID="LinkButton4" CssClass="submit_btn text-mypage" Text="Trang cá nhân" runat="server" OnClick="lb_Login_Click2" OnClientClick="loadLoginBox();"></asp:LinkButton></li>--%>
                </ul>
            </div>
        </asp:Panel>
        <div id="box_user" class="<%=LoginStatus %>">
            <ul>
                <li>
                    <asp:LinkButton ID="LBtCancel" runat="server" CssClass="submit_btn" Text="<%$Resources:UserManager, Bt_Close%>" OnClick="Cancel"></asp:LinkButton></li>
                <li>|<asp:LinkButton ID="LinkButton3" CssClass="submit_btn text-mypage" Text="Trang cá nhân" runat="server" OnClick="lb_Login_Click2" OnClientClick="loadLoginBox();"></asp:LinkButton></li>
                <li class="shopping-cart" runat="server" ID="liCart2"> <a href="<%=ResolveUrl("~")+BicLanguage.CurrentLanguage%>/shopping-cart.sc1.html">GIỎ HÀNG CỦA BẠN</a><span class="sum-product">(CÓ <span id="TotalQuanlity"><%=Session["TotalQuanlity"] != null ? BicConvert.ToString(Session["TotalQuanlity"]) : "0" %></span> SẢN PHẨM)</span></li>
                <%--<li><a class="edit"  href="<%=Page.ResolveUrl("~") %><%=BicLanguage.CurrentLanguage %>/edit-profile.html"><%= BicResource.GetValue("UserManager","EditProfile") %></a></li>--%>
            </ul>

            <%--| <a id="username">
                  <%=BicResource.GetValue("UserManager","Hello") %>: 
                <%=BicMemberShip.CurrentUserName%>
              </a> | --%>
        </div>
        <div id="Panel_Register" runat="server" clientidmode="Static" style="display: none;">
            <div class="background-opacity">
            </div>
            <div id="regis-form">
                <div class="title">
                    <div class="dn">
                        <%=BicResource.GetValue("UserManager","RigisterAccount") %>
                    </div>
                    <asp:LinkButton ID="Close_Register" class="close" Text="X" runat="server" OnClientClick="unloadRegisBox();"
                        OnClick="Close_Register_Click"></asp:LinkButton>
                </div>
                <table>
                    <tr>
                        <td class="td">
                            <%=BicResource.GetValue("UserManager","UserName") %> :
                        </td>
                        <td>
                            <%-- <input id="Txt_TenDangNhap" runat="server" name="Txt_TenDangNhap" onkeypress="return SpacePress(event);"
                                onchange="CheckUserName(this.value);" />--%>
                            <input id="Txt_TenDangNhap" runat="server" name="Txt_TenDangNhap" onkeyup="CheckUserName(this.value);" /><span class="star">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td class="td">
                            <%=BicResource.GetValue("UserManager","Password") %> :
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="Txt_MatKhau" TextMode="Password"></asp:TextBox><span class="star">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td class="td">
                            <%=BicResource.GetValue("UserManager","ConfirmPassword") %>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="Txt_XacNhanMatKhau" TextMode="Password"></asp:TextBox><span class="star">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td class="td">
                            <%=BicResource.GetValue("UserManager","FullName") %> 
                        </td>
                        <td>
                            <asp:TextBox ID="Txt_Ten" runat="server"></asp:TextBox><span class="star">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td class="td">
                            <%=BicResource.GetValue("UserManager","Phone") %>
                        </td>
                        <td>
                            <asp:TextBox ID="Txt_DienThoai" runat="server" name="Txt_DienThoai"></asp:TextBox><span class="star">*</span>
                            <%--<asp:RegularExpressionValidator ValidationGroup="2" ID="RegularExpressionValidator1" runat="server" ControlToValidate="Txt_DienThoai" Display="Dynamic"  ErrorMessage="*" ForeColor="#FF3300" ValidationExpression="^\d*\.?\d*$"></asp:RegularExpressionValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td class="td">
                            <%=BicResource.GetValue("UserManager","DateOfBirth") %> :
                        </td>
                        <td>
                            <asp:DropDownList runat="server" ID="ddlDay" CssClass="ddlDate" />
                            <asp:DropDownList runat="server" ID="ddlMonth" CssClass="ddlDate" />
                            <asp:DropDownList runat="server" ID="ddlYear" CssClass="ddlDate" />

                            <asp:TextBox ID="txtDateOfBirth" runat="server" CssClass="hidden" name="Txt_DateOfBirth" ClientIDMode="Static"></asp:TextBox>
                            <%--<script type="text/javascript">
                                $(function () {
                                    $("#txtDateOfBirth").datepicker({
                                        showOn: "button",
                                        buttonImage: "/styles/icon/calendar.jpg",
                                        buttonImageOnly: true,
                                        dateFormat: 'dd/mm/yy'
                                    });
                                });
                            </script>--%>
                            <%--<asp:RegularExpressionValidator ValidationGroup="2" ID="RegularExpressionValidator1" runat="server" ControlToValidate="Txt_DienThoai" Display="Dynamic"  ErrorMessage="*" ForeColor="#FF3300" ValidationExpression="^\d*\.?\d*$"></asp:RegularExpressionValidator>--%>
                        </td>
                    </tr>
                    <%--<tr>
                        <td class="td">
                            <%=BicResource.GetValue("UserManager","Nip") %> 
                        </td>
                        <td>
                            <asp:TextBox ID="txtNip" runat="server"></asp:TextBox><span class="star">*</span>
                        </td>
                    </tr>--%>
                    <tr>
                        <td class="td">
                            <%=BicResource.GetValue("UserManager","Company") %> :
                        </td>
                        <td>
                            <asp:TextBox ID="txtCompany" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="td">
                            <%=BicResource.GetValue("UserManager","Register_Address") %>
                            
                        </td>
                        <td>
                            <asp:TextBox ID="txtAddress" CssClass="textBox" runat="server" /><span class="star">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td class="td">
                            <%=BicResource.GetValue("UserManager","Register_City") %>
                            
                        </td>
                        <td>
                            <asp:DropDownList runat="server" ID="ddlCity" OnSelectedIndexChanged="ddlCity_OnSelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                            <%--<asp:TextBox ID="TextBox1" CssClass="textBox" runat="server" /><span class="star">*</span>--%>
                        </td>
                    </tr>
                    <tr>
                        <td class="td">
                            <%=BicResource.GetValue("UserManager","Register_District") %>
                            
                        </td>
                        <td>
                            <asp:DropDownList runat="server" ID="ddlDistrict"></asp:DropDownList>
                            <%--<asp:TextBox ID="TextBox1" CssClass="textBox" runat="server" /><span class="star">*</span>--%>
                        </td>
                    </tr>
                    <tr id="trEmail" runat="server" clientidmode="Static">
                        <td class="td">
                            <%=BicResource.GetValue("UserManager","EmailAddress") %>
                        </td>
                        <td>
                            <input id="Txt_Email" runat="server" name="Txt_Email" onblur="ChecEmail(this.value);" /><span class="star">*</span>
                        </td>
                    </tr>
                    <%--<tr>
                        <td class="td"></td>
                        <td>
                            <asp:CheckBox CssClass="chkInput" runat="server" ID="chkNotEmail" Text='<%$Resources:UserManager, DontEmail%>' />
                        </td>
                    </tr>--%>
                    <%--  <tr>
                        <td class="td">
                            <%=BicResource.GetValue("UserManager","Confirmemail") %>
                            
                        </td>
                        <td>
                            <input id="Txt_XacNhanEmail" runat="server" name="Txt_XacNhanEmail" /><span class="star">*</span>
                        </td>
                    </tr>--%>
                    <%--   <tr>
                        <td class="td">
                            <%=BicResource.GetValue("UserManager","Register_City") %>
                            
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCity" runat="server" CssClass="textBox list" ClientIDMode="Static" Width="206px" Height="25px" Style="padding: 3px;" />
                        </td>
                    </tr>--%>


                    <%--<tr>
                        <td class="td">
                            <%=BicResource.GetValue("UserManager","Register_Mobile") %>
                        </td>
                        <td>
                            <asp:TextBox ID="Txt_Mobile"  runat="server" name="Txt_Mobile"></asp:TextBox>
                             
                        </td>
                    </tr>--%>


                    <tr>
                        <td class="td">
                            <%=BicResource.GetValue("UserManager","Code") %>
                        </td>
                        <td>
                            <div class="captraBlock controlCol">
                                <telerik:RadCodeBlock runat="server" ID="radCodeBlock2">
                                    <telerik:RadCaptcha runat="server" ID="capComment" CaptchaImage-TextLength="3" EnableRefreshImage="true" CaptchaLinkButtonText="Ảnh khác" CaptchaTextBoxLabel="" CaptchaMaxTimeout="0">
                                    </telerik:RadCaptcha> 
                                    <div class="errMsg captcha" runat="server" visible="false" id="err_captcha">
                                        <%=BicResource.GetValue("UserManager", "REGISTER_ERR_CAPTCHA") %>
                                    </div>
                                </telerik:RadCodeBlock>
                            </div>
                            <span style="margin: -20px 0 0 202px;position: absolute;" class="star">*</span>
                        </td>
                    </tr>


                    <%--<tr>
                        <td class="tdCode" colspan="2" style="height: 35px; text-align: center; color: #006997;">

                          

                            <asp:CheckBox ID="chkTermAgree" runat="server" Text=" <%$Resources:UserManager, REGISTER_ERR_TERM_AGGREEMENT%>" />
                        </td>
                    </tr>--%>
                </table>
                <div id="Message_Server" runat="server" class="Div_Message">
                </div>
                <div class="btDK">
                    <asp:LinkButton CssClass="btn_dangky" class="btn_dangky" runat="server" ID="btn_dangky"
                        Text="<%$Resources:UserManager, Bt_Register%>" OnClick="btn_dangky_Click" OnClientClick="return Register();" />
                </div>
            </div>
            <script>
                function clickButton1(e, buttonid) {
                    var evt = e ? e : window.event;
                    var bt = document.getElementById(buttonid);
                    if (bt) {
                        if (evt.keyCode == 13) {
                            bt.click();
                            return false;
                        }
                    }
                }
            </script>
        </div>
        <div id="Panel_Login" runat="server" clientidmode="Static" style="display: none">
            <div class="background-opacity">
            </div>
            <div id="login-form">
                <div class="title">
                    <div class="dn">
                        <%=BicResource.GetValue("UserManager","Login") %>
                    </div>
                    <asp:LinkButton ID="Close_Login" class="close" Text="X" runat="server" OnClientClick="unloadPopupBox();"
                        OnClick="Close_Login_Click"></asp:LinkButton>
                </div>
                <div style="display: block;">
                    <asp:Label ID="LbThongBao" runat="server"></asp:Label>
                    <div id="Message_Login"></div>
                </div>
                <div class="content">
                    <table cellspacing="5" cellpadding="0">
                        <tr>
                            <td class="td">
                                <%=BicResource.GetValue("UserManager","Username") %>  &nbsp;
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="Txt_User" autocomplete="on" CssClass="inputtext"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="td">
                                <%=BicResource.GetValue("UserManager","Password") %> &nbsp;
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="Txt_Password" TextMode="Password" CssClass="inputtext"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td style="height: 30px;">
                                <span style="color: #006997; font-size: 12px; float: left">
                                    <asp:CheckBox Style="margin-left: 0" ID="CK_NhoMK" runat="server" Text=" <%$Resources:UserManager, Remember%>" />
                                </span>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="login_event">
                    <div class="mtop10">
                        <asp:LinkButton CssClass="btn_login" runat="server" ID="btn_login" Text="<%$Resources:UserManager, Bt_Login%>"
                            OnClientClick="Login(); return false;" />
                        <%--<a href="#" onclick="Login(); return  false;" class="btn_login"></a>--%>
                        <asp:LinkButton runat="server" ID="Call_Forgot_Pass" CssClass="quenmk" Text="<%$Resources:UserManager, Forgotpassword%>"
                            OnClick="Call_Forgot_Pass_Click"></asp:LinkButton>
                        <asp:LinkButton ID="Lbt_DK" class="btn_dangky" runat="server" Text="<%$Resources:UserManager, Bt_Register%>" OnClick="lb_Register_Onclick"></asp:LinkButton>
                    </div>
                    <%-- <div class="mtop15">
                        <b><%=BicResource.GetValue("UserManager","NoAccount") %></b>
                        <asp:LinkButton ID="Lbt_DK" class="btn_dangky" runat="server" Text="<%$Resources:UserManager, Bt_Register%>" OnClick="lb_Register_Onclick"></asp:LinkButton>
                    </div>--%>
                </div>
                <script>
                    function clickButton(e, buttonid) {
                        var evt = e ? e : window.event;
                        var bt = document.getElementById(buttonid);
                        if (bt) {
                            if (evt.keyCode == 13) {
                                bt.click();
                                return false;
                            }
                        }
                    }
                </script>
            </div>
        </div>
        <asp:Panel ID="Panel_ForgotPass" runat="server" DefaultButton="Lbt_Send" Visible="false">
            <div class="background-opacity">
            </div>
            <div id="forgotpass-form">
                <div class="title">
                    <div class="dn">
                        <%=BicResource.GetValue("UserManager","Forgotpassword") %>
                    </div>
                    <asp:LinkButton ID="Close_ForgotPass" class="close" Text="X" runat="server" OnClick="Close_ForgotPass_Click"></asp:LinkButton>
                </div>
                <div style="margin: 0px 10px 10px; display: inline-block;">
                    <asp:Label ID="lblCorrectCode" runat="server"></asp:Label>
                    <div id="Div_Forgot" runat="server" class="messageForgot">
                    </div>
                    <%--<div id="messageForgot"></div>--%>
                    <div class="item">
                        <span><%=BicResource.GetValue("UserManager","Username") %></span>
                        <input id="txtUser_Forgot_Pass" runat="server" name="txtUser_Forgot_Pass" onkeyup="CheckUserNameForgot(this.value);" />
                    </div>
                    <div style="clear: both;"></div>
                    <div class="item">
                        <span><%=BicResource.GetValue("UserManager","EmailRigister") %></span>
                        <input id="txtEmail_Forgot_Pass" runat="server" name="txtEmail_Forgot_Pass" onkeyup="CheckEmail_Forgot(this.value);" />
                    </div>
                    <div style="clear: both;"></div>
                    <span><%=BicResource.GetValue("UserManager","NotForgot") %> <%=BicXML.ToString("Domain", "MailConfig") %></span>
                    <asp:LinkButton runat="server" ID="Lbt_Send" CssClass="send-bt" OnClick="Lbt_Send_Click" Style="display: none;"></asp:LinkButton>
                    <a class="send-bt" onclick="Send_Forgot();"><%=BicResource.GetValue("UserManager","Bt_Send") %></a>
                    <asp:LinkButton runat="server" ID="Lbt_Huy" CssClass="cancel-bt" Text="<%$Resources:UserManager, Bt_Cancel%>" OnClick="Close_ForgotPass_Click"></asp:LinkButton>
                </div>
            </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<script type="text/javascript">


    Message = "";
    Message_Error = "";
    Message_Email = "";

    Txt_Ten = '#<%=Txt_Ten.ClientID%>';
    Txt_TenDangNhap = '#<%=Txt_TenDangNhap.ClientID%>';
    Txt_MatKhau = '#<%=Txt_MatKhau.ClientID%>';
    Txt_XacNhanMatKhau = '#<%=Txt_XacNhanMatKhau.ClientID%>';
    Txt_Email = '#<%=Txt_Email.ClientID%>';
    //Txt_XacNhanEmail = '#<Txt_XacNhanEmail.ClientID%>';
    Txt_DienThoai = '#<%=Txt_DienThoai.ClientID%>';
    Txt_Address = '#<%=txtAddress.ClientID%>';
    //Txt_Company = '#<%=txtCompany.ClientID%>';
    //Txt_Nip = '#';



    function Register() {
        debugger;
        $(".error").removeClass("error");


        if ($(Txt_TenDangNhap).val().length == 0) {
            $(Txt_TenDangNhap).addClass("error");
            Message = "<%=BicResource.GetValue("UserManager","NotUserName") %>";
        }
        else if ($(Txt_MatKhau).val().length == 0) {
            $(Txt_MatKhau).addClass("error");
            Message = "<%=BicResource.GetValue("UserManager","NotPassword") %>";
        }
        else if ($(Txt_XacNhanMatKhau).val().length == 0) {
            $(Txt_XacNhanMatKhau).addClass("error");
            Message = "<%=BicResource.GetValue("UserManager","NotCongirmPass") %>";
        } //so sanh mat khau
        else if ($(Txt_XacNhanMatKhau).val() != $(Txt_MatKhau).val()) {
            $(Txt_MatKhau).addClass("error");
            $(Txt_XacNhanMatKhau).addClass("error");
            Message = "<%=BicResource.GetValue("UserManager","REGISTER_ERR_NOT_MATCH_PASS") %>";
        }
        else if ($(Txt_Ten).val().length == 0) {
            $(Txt_Ten).addClass("error");
            Message = "<%=BicResource.GetValue("UserManager","NotName") %>";
            var tt = "#<%=Message_Server.ClientID%>";
            $(tt).text(Message_Error);
        }
        else if ($(Txt_DienThoai).val().length == 0) {
            $(Txt_DienThoai).addClass("error");
            Message = "<%=BicResource.GetValue("UserManager","NotPhone") %>";
        }


            <%--else if ($(Txt_Nip).val().length == 0) {
            $(Txt_Nip).addClass("error");
            Message = "<%=BicResource.GetValue("UserManager","NotNip") %>";
        }--%>
        <%--else if ($(Txt_Company).val().length == 0) {
            $(Txt_Company).addClass("error");
            Message = "<%=BicResource.GetValue("UserManager","NotCompany") %>";
        }--%>
        else if ($(Txt_Address).val().length == 0) {
            $(Txt_Address).addClass("error");
            Message = "<%=BicResource.GetValue("UserManager","NotAddress") %>";
        }
        else if ($(Txt_Email).val().length == 0) {
            $(Txt_Email).addClass("error");
            Message = "<%=BicResource.GetValue("UserManager","NotEmail") %>";
            }
            else {
                Message = "";
                //$(".Div_Message").removeClass("ThongBao").text(Message);
            }

    if (Message != "") {
        $(".Div_Message").addClass("ThongBao").text(Message);
    }
    else if (Message_Error != "") {
        $(Txt_TenDangNhap).addClass("error");
        $(".Div_Message").addClass("ThongBao").text(Message_Error);
        //CheckUserName(document.getElementById(Txt_TenDangNhap).value);
    }
        //else if (Message_Email != "") {
        //    alert(Message_Email);
        //    $(Txt_Email).addClass("error");
        //    $(".Div_Message").addClass("ThongBao").text(Message_Email);
        //}
    else {
        $(".Div_Message").removeClass("ThongBao").text("");
        __doPostBack('<%=btn_dangky.UniqueID%>', '');
    }
    return false;



}
function CheckUserName(value) {
    if (value.length < 6 || value.length > 20) {
        $(Txt_TenDangNhap).addClass("error");
        Message_Error = "<%=BicResource.GetValue("UserManager","UserNameFalse") %>";
        $(".Div_Message").addClass("ThongBao").text(Message_Error);
        return false;
    }
    if (checkRegexp(value, /^[a-z]([0-9a-z_])+$/i) == false) {
        Message_Error = "<%=BicResource.GetValue("UserManager","REGISTER_ERR_FORMAT_USERNAME") %>";
            $(".Div_Message").addClass("ThongBao").text(Message_Error);
            var NewValue = locdau(value);
            NewValue = NewValue.replace(/ /g, "");
            document.getElementById('<%=Txt_TenDangNhap.ClientID%>').value = NewValue;
        }
        else {
            $.ajax
            ({
                type: "POST",
                data: "{username: '" + value + "' }",
                contentType: "application/json; charset=utf-8",
                url: "/WebService/Register.asmx/user_validation",
                url: '<%=Page.ResolveUrl("~/WebService/Register.asmx/user_validation")%>',
                dataType: "json",
                success: function (data) {
                    if (data.d == 1) {
                        $(Txt_TenDangNhap).addClass("error");
                        Message_Error = "<%=BicResource.GetValue("UserManager","REGISTER_ERR_EXIST_USERNAME") %>";
                        $(".Div_Message").addClass("ThongBao").text(Message_Error);
                    }
                    else {
                        $(Txt_TenDangNhap).removeClass("error");
                        $(".Div_Message").removeClass("ThongBao").text("");
                        Message_Error = "";
                    }
                },
                error: function (fail) {
                    //alert("Kết nối thất bại!" + fail.status);
                    $(Txt_TenDangNhap).addClass("error");
                    Message_Error = "<%=BicResource.GetValue("UserManager","REGISTER_ERR_EXIST_USERNAME") %>";
                    $(".Div_Message").addClass("ThongBao").text(Message_Error);
                }
            });
        }
    }

    function ChecEmail(value) {
        //var text = Txt_Email.val();
        var checkEmail = checkRegexp(value, /^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i, "Email không đúng định dạng.");
        if (checkEmail == true) {

            $(Txt_Email).removeClass("error");
            $(".Div_Message").removeClass("ThongBao").text("");
            $.ajax
            ({
                type: "POST",
                data: "{email: '" + value + "' }",
                contentType: "application/json; charset=utf-8",
                url: "<%=Page.ResolveUrl("~/WebService/Login.asmx/email_validation")%>",
                dataType: "json",
                success: function (data) {
                    if (data.d == 1) {
                        $(Txt_Email).addClass("error");
                        Message_Email = "<%=BicResource.GetValue("UserManager","REGISTER_ERR_EXIST_EMAIL") %>";
                        $(".Div_Message").addClass("ThongBao").text(Message_Email);
                    }
                    else {
                        $(Txt_Email).removeClass("error");
                        $(Txt_XacNhanEmail).removeClass("error");
                        $(".Div_Message").removeClass("ThongBao").text("");
                        Message_Email = "";
                    }
                },
                error: function () {
                    $(Txt_Email).addClass("error");
                    Message_Email = "Server đang bận. vui lòng nhấn F5 và thử lại.";
                    $(".Div_Message").addClass("ThongBao").text(Message_Email);
                }
            });
        }
        else {
            $(Txt_Email).addClass("error");
            Message_Email = "<%=BicResource.GetValue("UserManager","REGISTER_ERR_FORMAT_EMAIL") %>";
            $(".Div_Message").addClass("ThongBao").text(Message_Email);
        }
    }

</script>
<script type="text/javascript">
    function Login() {
        var username = $("#<%=Txt_User.ClientID%>").val();
        var password = $("#<%=Txt_Password.ClientID%>").val();
        var rememberMe = $("#<%=CK_NhoMK.ClientID%>").attr("checked");
        if (rememberMe == "checked") {
            rememberMe = true;
        } else {
            rememberMe = false;
        }

        $.ajax({
            type: "POST",
            url: "<%=Page.ResolveUrl("~/WebService/Login.asmx/VerifyLogin")%>",
            data: "{username: '" + username + "', password:'" + password + "', rememberMe:'" + rememberMe + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.d == true) {
                    unloadPopupBox();
                    __doPostBack('<%=Close_Login.UniqueID%>', '');
                    $("#Login").css("display", "none");
                    $("#box_user").css("display", "block");
                    $("#username").html("<%=BicResource.GetValue("Hello") %> " + username);
                    //$("#Message_Login").addClass("ThongBao").text('Đăng nhập thành công!');
                    window.location = window.location.href;
                }
                else
                    $("#Message_Login").addClass("ThongBao").text('<%=BicResource.GetValue("UserManager","Login_False") %>');
            }
        });
    }
</script>
<script type="text/javascript">
    forgotUser = "";
    forgotEmail = "";
    txtUser_Forgot_Pass = '#<%=txtUser_Forgot_Pass.ClientID%>';
    txtEmail_Forgot_Pass = '#<%=txtEmail_Forgot_Pass.ClientID%>';
    function CheckUserNameForgot(value) {
        if (value.length < 6 || value.length > 20) {
            $(txtUser_Forgot_Pass).addClass("error");
            forgotUser = "<%=BicResource.GetValue("UserManager","UserNameFalse") %>";
            $(".messageForgot").addClass("ThongBao").text(forgotUser);
            return false;
        }
        if (checkRegexp(value, /^[a-z]([0-9a-z_])+$/i) == false) {
            forgotUser = "<%=BicResource.GetValue("UserManager","REGISTER_ERR_FORMAT_USERNAME") %>";
            $(".messageForgot").addClass("ThongBao").text(forgotUser);
            var NewValue = locdau(value);
            NewValue = NewValue.replace(/ /g, "");
            document.getElementById('<%=txtUser_Forgot_Pass.ClientID%>').value = NewValue;
            $(txtUser_Forgot_Pass).addClass("error");
        } else {
            $.ajax({
                type: "POST",
                data: "{username: '" + value + "' }",
                contentType: "application/json; charset=utf-8",
                url: "/WebService/Register.asmx/user_validation",
                url: '<%=Page.ResolveUrl("~/WebService/Register.asmx/user_validation")%>',
                dataType: "json",
                success: function (data) {
                    if (data.d == 0) {
                        $(txtUser_Forgot_Pass).addClass("error");
                        forgotUser = "<%=BicResource.GetValue("UserManager","UsernameNotRegister") %>";
                        $(".messageForgot").addClass("ThongBao").text(forgotUser);
                    } else {
                        $(txtUser_Forgot_Pass).removeClass("error");
                        $(".messageForgot").removeClass("ThongBao").text("");
                        forgotUser = "";
                    }
                },
                error: function (fail) {
                    //alert("Kết nối thất bại!" + fail.status);
                    $(txtUser_Forgot_Pass).addClass("error");
                    forgotUser = "<%=BicResource.GetValue("UserManager","UsernameNotRegister") %>";
                    $(".messageForgot").addClass("ThongBao").text(forgotUser);
                }
            });
        }
    }


    function CheckEmail_Forgot(value) {
        //var text = Txt_Email.val();
        var checkEmail = checkRegexp(value, /^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i, "Email không đúng định dạng.");
        if (checkEmail == true) {
            $(txtEmail_Forgot_Pass).removeClass("error");
            $(".messageForgot").removeClass("ThongBao").text("");
            $.ajax({
                type: "POST",
                data: "{email: '" + value + "' }",
                contentType: "application/json; charset=utf-8",
                url: "<%=Page.ResolveUrl("~/WebService/Login.asmx/email_validation")%>",
                dataType: "json",
                success: function (data) {
                    if (data.d == 0) {
                        $(txtEmail_Forgot_Pass).addClass("error");
                        forgotEmail = "<%=BicResource.GetValue("UserManager","EmailNotRegister") %>";
                        $(".messageForgot").addClass("ThongBao").text(forgotEmail);
                    } else {
                        $(txtEmail_Forgot_Pass).removeClass("error");
                        $(".messageForgot").removeClass("ThongBao").text("");
                        forgotEmail = "";
                        CheckUserEmail(value);
                    }
                },
                error: function () {
                    //alert("Kết nối thất bại!");
                    $(txtEmail_Forgot_Pass).addClass("error");
                    forgotEmail = "<%=BicResource.GetValue("UserManager","EmailNotRegister") %>";
                    $(".messageForgot").addClass("ThongBao").text(forgotEmail);
                }
            });
        } else {
            $(txtEmail_Forgot_Pass).addClass("error");
            forgotEmail = "<%=BicResource.GetValue("UserManager","REGISTER_ERR_FORMAT_EMAIL") %>";
            $(".messageForgot").addClass("ThongBao").text(forgotEmail);
        }
    }

    function CheckUserEmail(email) {
        var user = document.getElementById('<%=txtUser_Forgot_Pass.ClientID%>').value;
        if (user == "" || email == "") {
            forgotEmail = "<%=BicResource.GetValue("UserManager","CheckUserEmail") %>";
            $(".messageForgot").addClass("ThongBao").text(forgotEmail);
            return false;
        }
        $.ajax({
            type: "POST",
            data: "{ username: '" + user + "',email: '" + email + "' }",
            contentType: "application/json; charset=utf-8",
            url: "<%=Page.ResolveUrl("~/WebService/Login.asmx/CheckUsername_Email")%>",
            dataType: "json",
            success: function (data) {
                if (data.d == 0) {
                    forgotEmail = "<%=BicResource.GetValue("UserManager","CheckUserEmail") %>";
                    $(".messageForgot").addClass("ThongBao").text(forgotEmail);
                } else {
                    $(".messageForgot").removeClass("ThongBao").text("");
                    forgotEmail = "";
                }
            },
            error: function () {
                //alert("Kết nối thất bại!");
                $(txtEmail_Forgot_Pass).addClass("error");
                forgotEmail = "<%=BicResource.GetValue("UserManager","EmailNotRegister") %>";
                $(".messageForgot").addClass("ThongBao").text(forgotEmail);

            }
        });
    }

    function Send_Forgot() {
        CheckEmail_Forgot(document.getElementById('<%=txtEmail_Forgot_Pass.ClientID%>').value);
        if (forgotEmail == "") {
            __doPostBack('<%=Lbt_Send.UniqueID%>', '');
        }
    }
</script>
