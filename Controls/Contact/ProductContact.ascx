<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductContact.ascx.cs" Inherits="Controls_Contact_ProductContact" %>
<%@ Register Src="~/Controls/Adv/ScriptAdv.ascx" TagPrefix="uc1" TagName="ScriptAdv" %>

<div class="wr-box">
    <div class="form-muahang faq-form-content">
        <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
            <telerik:RadAjaxPanel runat="server" ID="rapContact" LoadingPanelID="RadAjaxLoadingPanel1" CssClass="faq-form-content">
                <telerik:RadCodeBlock ID="RadCodeBlock2" runat="server">
                    <div class="faq-form">
                        <div class="form-group">
                            <label>Tên sản phẩm</label>
                            <span><%= ProductName %></span>
                        </div>
                        <div class="form-group">
                            <label>Họ và tên</label>
                            <asp:TextBox runat="server" ID="txtFullName" CssClass="form-control" TabIndex="1" />
                        </div>
                        <div class="form-group">
                            <label>Điện thoại</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtPhone" TabIndex="2" />
                        </div>
                        <div class="form-group">
                            <label>Email</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" TabIndex="3" />
                        </div>
                        <div class="form-group text-center">
                            <label></label>
                            <asp:LinkButton runat="server" Text="Đăng ký" ID="ibtSend" OnCommand="FeedBack" ValidationGroup="contact" CommandName="Send" CssClass="btn btn-primary" TabIndex="5" />
                        </div>
                    </div>
                </telerik:RadCodeBlock>
            </telerik:RadAjaxPanel>
        </telerik:RadCodeBlock>
        <telerik:RadAjaxLoadingPanel runat="server" Skin="Default" ID="RadAjaxLoadingPanel1"
            BackgroundPosition="Center" EnableSkinTransparency="true">
        </telerik:RadAjaxLoadingPanel>
        <telerik:RadInputManager runat="server" ID="rim1">
            <telerik:TextBoxSetting BehaviorID="bhFullName" ErrorMessage='Vui lòng nhập thông tin' Validation-IsRequired="true" Validation-ValidationGroup="contact">
                <TargetControls>
                    <telerik:TargetInput ControlID="txtFullName" />
                </TargetControls>
            </telerik:TextBoxSetting>
            <telerik:RegExpTextBoxSetting BehaviorID="bhEmail" Validation-IsRequired="true" Validation-ValidationGroup="contact" ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" ErrorMessage='Email không hợp lệ'>
                <TargetControls>
                    <telerik:TargetInput ControlID="txtEmail" />
                </TargetControls>
            </telerik:RegExpTextBoxSetting>
            <telerik:RegExpTextBoxSetting BehaviorID="bhPhone" Validation-IsRequired="true" Validation-ValidationGroup="contact" ValidationExpression="^[0-9]{0,15}$" ErrorMessage='Số điện thoại không hợp lệ'>
                <TargetControls>
                    <telerik:TargetInput ControlID="txtPhone" />
                </TargetControls>
            </telerik:RegExpTextBoxSetting>
        </telerik:RadInputManager>
        <script type="text/javascript">
            $(document).ready(function () {
                $(".faq-form input").not($(":submit, :button")).keypress(function (evt) {
                    if (evt.keyCode == 13) {
                        var next = $('[tabindex="' + (this.tabIndex + 1) + '"]');
                        if (next.length)
                            next.focus()
                        else
                            $('[tabindex="1"]').focus();
                        return false;
                        
                    }
                });
            });
        </script>

    </div>
    <div class="banner-box">
        <uc1:ScriptAdv runat="server" ID="ucFanPageFaceBook" TypeOfAdv="3" PageSize="1" />
    </div>
</div>
