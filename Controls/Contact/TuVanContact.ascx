<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TuVanContact.ascx.cs" Inherits="Controls_Contact_TuVanContact" %>
<%@ Register Src="~/Controls/Adv/ScriptAdv.ascx" TagPrefix="uc1" TagName="ScriptAdv" %>


<div class="module-dangky-tuvan">
    <div class="container">
        <div class="wr-box">
            <div class="form-dangky faq-form-content">
                <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
                    <telerik:RadAjaxPanel runat="server" ID="rapContact" LoadingPanelID="RadAjaxLoadingPanel1" CssClass="faq-form-content">
                        <telerik:RadCodeBlock ID="RadCodeBlock2" runat="server">
                            <h4 class="faq-title">Đăng ký nhận thiết kế miễn phí từ chúng tôi</h4>
                            <div class="faq-form">
                                <div class="form-group">
                                    <asp:TextBox runat="server" ID="txtFullName" CssClass="form-control" placeholder='<%$Resources:Resource,FullName %>' TabIndex="1" />
                                </div>
                                <div class="form-group">
                                    <asp:TextBox runat="server" CssClass="form-control" placeholder='<%$Resources:Resource,Phone %>' ID="txtPhone" TabIndex="2" />
                                </div>
                                <div class="form-group">
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" placeholder='<%$Resources:Resource,Email %>' TabIndex="3" />
                                </div>
                                <div class="form-group group-full hidden">
                                    <asp:TextBox runat="server" ID="txtQuestion" CssClass="form-control" TextMode="MultiLine" placeholder='<%$Resources:Resource,Content %>' TabIndex="4" Visible="false" />
                                </div>
                                <div class="form-group text-center">
                                    <asp:LinkButton runat="server" Text="Đăng ký" ID="ibtSend" OnCommand="FeedBack" ValidationGroup="contact" CommandName="Send" CssClass="btn btn-primary" TabIndex="5" />
                                </div>
                            </div>
                            <div class="faq-desc">
                                <uc1:ScriptAdv runat="server" ID="ucDescripBox" TypeOfAdv="8" PageSize="1" />
                                Để khách hàng trải nghiệm dịch vụ, Chúng tôi MIỄN PHÍ 01 bản thiết kế 3D cho quý khách. Hãy đăng ký, chúng tôi sẽ liên hệ để triển khai thiết kế của bạn.
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
                <uc1:ScriptAdv runat="server" ID="ucFanPageFaceBook" TypeOfAdv="5" PageSize="1" />
            </div>
        </div>
    </div>
</div>
