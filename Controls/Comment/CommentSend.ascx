<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CommentSend.ascx.cs" Inherits="Controls_Comment_CommentSend" %>
<asp:Label runat="server" Visible="False" ID="lblid"></asp:Label>
<asp:Label runat="server" Visible="False" ID="lbltype"></asp:Label>
<asp:Label runat="server" Visible="False" ID="lblarticleid"></asp:Label>
<telerik:RadCodeBlock runat="server" ID="radCodeBlock5">
    <telerik:RadAjaxPanel runat="server" ID="RadAjaxPanelID">
        <div class="inputBlock">
            <div class="inputMark">
                <telerik:RadCodeBlock runat="server" ID="radCodeBlock1">
                    <asp:TextBox runat="server" ID="txtName" CssClass="name" ClientIDMode="Static" MaxLength="200" placeholder="Tên người gửi" TabIndex="1" />
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtName" runat="server" ErrorMessage="*" Display="Dynamic" ValidationGroup="SendComment"></asp:RequiredFieldValidator>--%>
                </telerik:RadCodeBlock>
            </div>
            <div class="inputMark">
                <telerik:RadCodeBlock runat="server" ID="radCodeBlock2">
                    <asp:TextBox runat="server" ID="txtDescription" ClientIDMode="Static" CssClass="des textboxcoment" TextMode="MultiLine" MaxLength="200" placeholder="Nội dung bình luận (không quá 500 ký tự)" TabIndex="2" />
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtDescription" runat="server" ErrorMessage="*" Display="Dynamic" ValidationGroup="SendComment"></asp:RequiredFieldValidator>--%>
                    <div>
                        <span id="charLeft" style="display: none;"></span>
                    </div>
                </telerik:RadCodeBlock>
            </div>
            <div class="inputGender hidden">
                <asp:RadioButtonList ID="rdbList" runat="server" RepeatLayout="Flow" RepeatColumns="2" RepeatDirection="Horizontal" TabIndex="3">
                    <asp:ListItem Text="Nam" Value="1" Selected="True" />
                    <asp:ListItem Text="Nữ" Value="0" />
                </asp:RadioButtonList>
            </div>
        </div>
        <div class="captraBlock">
            <telerik:RadCodeBlock runat="server" ID="radCodeBlock3">
                <telerik:RadCaptcha runat="server" ID="racComment" CaptchaImage-TextLength="3" CaptchaImage-TextChars="Numbers" ValidationGroup="SendComment" CaptchaImage-BackgroundNoise="None" EnableRefreshImage="true" CaptchaTextBoxLabel="Nhập mã xác nhận" CaptchaLinkButtonText="" TabIndex="4">
                </telerik:RadCaptcha>
                <asp:LinkButton ID="btnPost" runat="server" CssClass="send" CommandName="Send" OnCommand="btnPost_OnCommand" ValidationGroup="SendComment" OnClientClick="return ValidForm()">  </asp:LinkButton>
            </telerik:RadCodeBlock>
        </div>
    </telerik:RadAjaxPanel>
</telerik:RadCodeBlock>
<telerik:RadCodeBlock runat="server" ID="RadCodeBlock123">
    <script>
        function ValidForm() {
            if ($("#txtName").val().length == 0) {
                alert("Tên người gửi không được trống !");
                return false;
            }
            if ($("#txtDescription").val().length == 0) {
                alert("Nội dung không được trống !");
                return false;
            }
            if ($("#txtDescription").val().length > 500) {
                alert("Nội dung bình luận không vượt quá 500 ký tự !");
                return false;
            }
            return true;
        }

        function clickButton(e, buttonid) {
            var evt = e ? e : window.event;
            var bt = document.getElementById(buttonid);
            if (bt) {
                if (evt.keyCode == 13) {
                    if (ValidForm() == true) {
                        bt.click();
                    }
                    return false;
                }
            }
        }
    </script>
</telerik:RadCodeBlock>
