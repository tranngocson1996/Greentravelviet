<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Contact.ascx.cs" Inherits="Controls_Contact_Contact" %>
<%@ Register Src="~/Controls/GoogleMap/GoogleMaps.ascx" TagPrefix="uc1" TagName="GoogleMaps" %>
<%@ Register Src="~/Controls/Adv/ScriptAdv.ascx" TagPrefix="uc1" TagName="ScriptAdv" %>
<%@ Register Src="~/Controls/Navigate/NavigatePath.ascx" TagPrefix="uc1" TagName="NavigatePath" %>


<%@ Import Namespace="BIC.Utils" %>


<div class="navigate-title">
    <div class="container">
        <div class="box-title">
            <h1>
                <bic:MenuCaption ID="mnCap" runat="server" CssClass="text" /></h1>
            <asp:Literal ID="ltrDesc" runat="server"></asp:Literal>
        </div>
        <uc1:NavigatePath runat="server" ID="ucNavigatePath" VisibleHomePage="true" />
    </div>
</div>
<section class="page-content page-contact">

    <div class="contact-content">
        <uc1:GoogleMaps runat="server" ID="ucGoogleMaps" />
        <div class="row">
            <div class="container">
                <div class="contactForm">
                    <div class="title-contact-form">
                        <p><%=BicLanguage.CurrentLanguage== "vi"? "Gửi tin nhắn cho chúng tôi": "Send us a message" %></p>
                    </div>
                    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
                        <telerik:RadAjaxPanel runat="server" ID="rapContact" LoadingPanelID="RadAjaxLoadingPanel1">
                            <telerik:RadCodeBlock ID="RadCodeBlock2" runat="server">
                                <div class="form-horizontal">
                                    <div class="form-group">
                                        <label for="name" class="col-sm-3 control-label"><%=BicResource.GetValue("FullName")%></label>
                                        <div class="col-sm-9">
                                            <asp:TextBox runat="server" ID="txtFullName" CssClass="form-control" EnableViewState="false" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="email" class="col-sm-3  control-label"><%=BicResource.GetValue("Email")%></label>
                                        <div class="col-sm-9">
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" EnableViewState="false" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="phone" class="col-sm-3 control-label"><%=BicResource.GetValue("Phone")%></label>
                                        <div class="col-sm-9">
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtPhone" EnableViewState="false" />
                                        </div>
                                    </div>
                                    <%--<div class="form-group">
                                        <label for="address" class="col-sm-3 control-label"><%=BicResource.GetValue("Address")%></label>
                                        <div class="col-sm-9">
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtAdress" EnableViewState="false"/>
                                        </div>
                                    </div>--%>
                                    <div class="form-group ct-content">
                                        <label for="content" class="col-sm-3 control-label"><%=BicResource.GetValue("Content")%></label>
                                        <asp:TextBox runat="server" ID="txtContent" CssClass="form-control" TextMode="MultiLine" EnableViewState="false" />
                                    </div>
                                    <div class="form-group btn-contact">
                                        <asp:LinkButton runat="server" Text="<%$Resources:Resource,ContactSendCss%>" ID="ibtSend" OnCommand="FeedBack" ValidationGroup="contact" CommandName="Send" CssClass="btn btn-primary" />
                                    </div>
                                </div>
                            </telerik:RadCodeBlock>
                        </telerik:RadAjaxPanel>
                    </telerik:RadCodeBlock>
                </div>
                <div class="contactInfo">
                    <div class="contact-info">
                        <p class="tns-title"><%=BicLanguage.CurrentLanguage== "vi"? "Thông tin liên hệ": "Information contact" %></p>
                        <uc1:ScriptAdv runat="server" ID="ucInfoContact" TypeOfAdv="7" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <telerik:RadAjaxLoadingPanel runat="server" Skin="Default" ID="RadAjaxLoadingPanel1"
        BackgroundPosition="Center" EnableSkinTransparency="true">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadInputManager runat="server" ID="rim1">
        <telerik:TextBoxSetting BehaviorID="bhFullName" ErrorMessage='<%$Resources:Resource,Required %>' Validation-IsRequired="true" Validation-ValidationGroup="contact" ClientEvents-OnKeyPress="disableEnterKey">
            <TargetControls>
                <telerik:TargetInput ControlID="txtFullName" />
            </TargetControls>
        </telerik:TextBoxSetting>
        <telerik:RegExpTextBoxSetting BehaviorID="bhEmail" Validation-IsRequired="true" Validation-ValidationGroup="contact" ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" ErrorMessage='<%$Resources:Resource,NotMatch %>' ClientEvents-OnKeyPress="disableEnterKey">
            <TargetControls>
                <telerik:TargetInput ControlID="txtEmail" />
            </TargetControls>
        </telerik:RegExpTextBoxSetting>
        <telerik:RegExpTextBoxSetting BehaviorID="bhPhone" Validation-ValidationGroup="contact" Validation-IsRequired="true" ValidationExpression="^(?!\s*$).+" ErrorMessage='<%$Resources:Resource,NotMatchPhone %>' ClientEvents-OnKeyPress="disableEnterKey">
            <TargetControls>
                <telerik:TargetInput ControlID="txtPhone" />
            </TargetControls>
        </telerik:RegExpTextBoxSetting>
        <%--<telerik:TextBoxSetting BehaviorID="bhAdress" ErrorMessage='<%$Resources:Resource,Required %>' Validation-IsRequired="true" Validation-ValidationGroup="contact" ClientEvents-OnKeyPress="disableEnterKey">
                <TargetControls>
                    <telerik:TargetInput ControlID="txtAdress" />
                </TargetControls>
            </telerik:TextBoxSetting>--%>
    </telerik:RadInputManager>

</section>

<script type="text/javascript">
    function disableEnterKey(sender, args) {
        if (args.get_keyCode() == '13')
            args.set_cancel(true);
    }
</script>

