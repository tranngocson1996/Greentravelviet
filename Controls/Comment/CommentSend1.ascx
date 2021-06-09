<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CommentSend1.ascx.cs" Inherits="Controls_Comment_CommentSend1" %>
<%@ Import Namespace="BIC.Utils" %>

<asp:Label runat="server" Visible="False" ID="lblid"></asp:Label>
<asp:Label runat="server" Visible="False" ID="lbltype"></asp:Label>
<asp:Label runat="server" Visible="False" ID="lblarticleid"></asp:Label>
<link href="<%=Page.ResolveUrl("~/Controls/Comment/Comment.css") %>" rel="stylesheet" />
<div class="comment_detail1">
        <telerik:RadCodeBlock runat="server" ID="radCodeBlock5">
            <telerik:RadAjaxPanel runat="server" ID="RadAjaxPanelID">
                <div class="inputBlock" id="Commentary">
                    <div class="inputMark">
                        <telerik:RadCodeBlock runat="server" ID="radCodeBlock1">
                            <asp:TextBox runat="server" ID="txtName1" ValidationGroup="SendComment3" ToolTip="<%$Resources:Resource, Register_FullName%>" Text="<%$Resources:Resource, Register_FullName%>" CssClass="name" ClientIDMode="Static" MaxLength="200" defaultvalue="<%$Resources:Resource, Register_FullName%>" />
                            <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtName1" CultureInvariantValues="True" Display="Dynamic" ErrorMessage="Họ và tên không được để trống" Operator="NotEqual" ValidationGroup="SendComment3" ForeColor="Red" Text="*" ValueToCompare="Họ và tên" SetFocusOnError="True"></asp:CompareValidator>
                        </telerik:RadCodeBlock>
                    </div>
                    <div class="inputMark">
                        <telerik:RadCodeBlock runat="server" ID="radCodeBlock2">
                            <asp:TextBox runat="server" ID="txtDescription1" ValidationGroup="SendComment3" CssClass="des " TextMode="MultiLine" MaxLength="500" Text="<%$Resources:Resource, ContentComent%>" Display="Dynamic" defaultvalue="<%$Resources:Resource, ContentComent%>" />
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtDescription1" CultureInvariantValues="True" ErrorMessage="Nội dung bình luận của bạn (Không quá 500 ký tự)" Operator="NotEqual" ValidationGroup="SendComment3" ForeColor="Red" Text="*" ValueToCompare="Nội dung (không quá 500 ký tự)" SetFocusOnError="True"></asp:CompareValidator>
                        </telerik:RadCodeBlock>
                    </div>
                </div>
                <div class="captraBlock" id="captcha">
                    <telerik:RadCodeBlock runat="server" ID="radCodeBlock3">
                        <telerik:RadCaptcha runat="server" ID="racComment1" ValidationGroup="SendComment3" CaptchaImage-TextLength="3" CaptchaImage-TextChars="Numbers" CaptchaImage="/Controls/Comment/img/anhkhac_gray.png" CaptchaImage-BackgroundNoise="None" EnableRefreshImage="true" CaptchaTextBoxLabel="" CaptchaLinkButtonText="">
                        </telerik:RadCaptcha>
                        <%--<div class="catpcha_change"><%=BicResource.GetValue("Change_Captcha") %></div>--%>
                        <asp:LinkButton runat="server" ID="btnPost" CssClass="send" ValidationGroup="SendComment3" Text="<%$Resources:Resource, Send%>" OnClick="btnPost_Click"></asp:LinkButton>
                    </telerik:RadCodeBlock>
                </div>
            </telerik:RadAjaxPanel>
        </telerik:RadCodeBlock>
    </div>

<script type="text/javascript">

    function pageLoad() {
        

        $('#txtName').focus(function () {
            if (this.value == this.title) {
                $(this).val("");
            }
        }).blur(function () {
            if (this.value == "") {
                $(this).val(this.title);
            }
        });
        $('#txtRegister_Email').focus(function () {
            if (this.value == this.title) {
                $(this).val("");
            }
        }).blur(function () {
            if (this.value == "") {
                $(this).val(this.title);
            }
        });
        $("#Commentary textarea").focus(function () {

            $(this).filter(function () {
                return $(this).val() == "" || $(this).val() == "<%= BicResource.GetValue("ContentComent")%>";

            }).val("");

        });

        $("#Commentary textarea").blur(function () {

            $(this).filter(function () {
                return $(this).val() == "";

            }).val("<%= BicResource.GetValue("ContentComent")%>");

        });


        $("#captcha input[type=text]").val("<%= BicResource.GetValue("Captcha")%>");
        $("#captcha input[type=text]").focus(function () {

            $(this).filter(function () {
                return $(this).val() == "" || $(this).val() == "<%= BicResource.GetValue("Captcha")%>";

            }).val("");

        });

        $("#captcha input[type=text]").blur(function () {

            $(this).filter(function () {
                return $(this).val() == "";

            }).val("<%= BicResource.GetValue("Captcha")%>");

        });
        if ($(location).attr('href').indexOf('#Commentary') > 0) {
            $('#txtName').focus();
        }
    }

</script>
