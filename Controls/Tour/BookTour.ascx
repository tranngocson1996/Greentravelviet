<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BookTour.ascx.cs" Inherits="Controls_Tour_BookTour" %>
<%@ Import Namespace="BIC.Utils" %>
<%@ Register Src="~/Controls/Navigate/NavigatePath.ascx" TagPrefix="uc1" TagName="NavigatePath" %>
<%= Include.JqueryUi() %>
<div class="navigate-title">
    <div class="container">
        <div class="box-title">
        </div>
        <uc1:NavigatePath runat="server" ID="NavigatePath" />
    </div>
</div>
<div class="tns-booktour">
    <div class="container">
        <div class="fl w100">
            <div class="captionBookTour w100 fl">
                <bic:MenuCaption ID="CaptionTourInfor" runat="server">
            <%=BicResource.GetValue("ThongTinTour") %>
                </bic:MenuCaption>
            </div>
            <div class="w100 fl thongtintour">
                <div class="col-md-12 col-lg-12 col-xs-12 col-sm-12 tentour">
                    <div class="row">
                        <asp:Literal runat="server" ID="ltrTenTour"></asp:Literal>
                    </div>
                </div>
                <div class="col-md-12 col-lg-12 col-xs-12 col-sm-12">
                    <div class="row">
                        <div class="col-md-4 col-lg-4 col-sm-6 col-xs-12">
                            <div class="row">
                                <%=BicResource.GetValue("MaTour") %>:<span>
                                    <asp:Literal runat="server" ID="ltrMaTour"></asp:Literal>
                                </span>
                            </div>
                        </div>

                        <div class="col-md-4 col-lg-4 col-sm-6 col-xs-12 hidden">
                            <div class="row">
                                <%=BicResource.GetValue("NgayBatDau") %>:<span>
                                    <asp:Literal runat="server" ID="ltrNgayBatDau"></asp:Literal>
                                </span>
                            </div>
                        </div>

                        <div class="col-md-4 col-lg-4 col-sm-6 col-xs-12 hidden">
                            <div class="row">
                                <%=BicResource.GetValue("NgayKetThuc") %>:<span>
                                    <asp:Literal runat="server" ID="ltrNgayKetThuc"></asp:Literal>
                                </span>
                            </div>
                        </div>
                        <div class="col-md-4 col-lg-4 col-sm-6 col-xs-12">
                            <div class="row">
                                <%=BicResource.GetValue("TimeWant") %>:<span>
                                    <input type="text" runat="server" placeholder="Pick" id="c_lich" style="width: 100%;" />
                                </span>
                            </div>
                        </div>
                        <div class="col-md-4 col-lg-4 col-sm-6 col-xs-12">
                            <div class="row">
                                <%=BicResource.GetValue("NumberDays") %>:<span>
                                    <asp:Literal runat="server" ID="ltrSoNgay"></asp:Literal>
                                    <%=BicResource.GetValue("day") %>
                                </span>
                            </div>
                        </div>

                        <div class="col-md-4 col-lg-4 col-sm-6 col-xs-12 <%=CssClass %>">
                            <div class="row ">
                                <%=BicResource.GetValue("Price") %>:<span>
                                    <asp:Literal runat="server" ID="ltrGiaHienThi"></asp:Literal>
                                    <%=BicResource.GetValue("donvigia") %>
                                </span>
                            </div>
                        </div>
                        <div class="col-md-4 col-lg-4 col-sm-6 col-xs-12">
                            <div class="row">
                                <%=BicResource.GetValue("DiemDi") %>:<span>
                                    <asp:Literal runat="server" ID="ltrDiemDi"></asp:Literal>
                                </span>

                            </div>
                        </div>
                        <div class="col-md-4 col-lg-4 col-sm-6 col-xs-12">
                            <div class="row">
                                <%=BicResource.GetValue("DiemDen") %>:<span>
                                    <asp:Literal runat="server" ID="ltrDiemDen"></asp:Literal>
                                </span>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="fl w100 contact-top">
            <div class="captionBookTour w100 fl">
                <bic:MenuCaption ID="CaptionLienHe" runat="server">
            <%=BicResource.GetValue("CaptionLienHe") %>
                </bic:MenuCaption>
            </div>
            <div class="contact-form w100 fl">
                <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
                    <telerik:RadAjaxPanel runat="server" ID="rapContact" LoadingPanelID="RadAjaxLoadingPanel1">
                        <div class="labelsColumn">
                            <telerik:RadCodeBlock ID="RadCodeBlock2" runat="server">
                                <label>
                                    <%=(BicLanguage.CurrentLanguage=="vi"?"Họ và tên *":"FullName *") %>
                                </label>
                                <label>
                                    <%=(BicLanguage.CurrentLanguage=="vi"?"Điện thoại *":"Phone *") %>
                                </label>
                                <label>
                                    Email
                                </label>
                                <label>
                                    <%=(BicLanguage.CurrentLanguage=="vi"?"Địa chỉ *":"Address *") %>
                                </label>

                            </telerik:RadCodeBlock>
                        </div>
                        <div class="textBoxsColumn">
                            <asp:TextBox runat="server" class="textbox" ID="txtFullName" />
                            <asp:TextBox runat="server" class="textbox" ID="txtPhone" />
                            <asp:TextBox runat="server" class="textbox" ID="txtEmail" />
                            <asp:TextBox runat="server" class="textbox" ID="txtAddress" />
                        </div>
                        <div class="imgLoader">
                            <telerik:RadAjaxLoadingPanel runat="server" ID="RadAjaxLoadingPanel1">
                                <asp:Image ID="Image1" CssClass="imgLoading" runat="server" AlternateText="Loadding..." ImageUrl="~/Controls/Contact/img/loading.gif" />
                            </telerik:RadAjaxLoadingPanel>
                        </div>
                    </telerik:RadAjaxPanel>
                </telerik:RadCodeBlock>
            </div>
        </div>
        <div class="w100 fl hinhthucthanhtoan hidden">
            <div class="captionBookTour w100 fl">
                <bic:MenuCaption ID="captionHttt" runat="server">
            <%=BicResource.GetValue("CaptionThanhToan") %>
                </bic:MenuCaption>
            </div>
            <div class="thanh-toan w100 fl">
                <div class="col-md-2 col-lg-2 col-sm-3 col-xs-6">
                    <div class="row">
                        <asp:RadioButton runat="server" Text="<%$Resources:Resource,TienMat%>" GroupName="rbnThanhToan" ID="rbnTienMat" />
                    </div>
                </div>
                <div class="col-md-3 col-lg-3 col-sm-3 col-xs-6">
                    <div class="row">
                        <asp:RadioButton runat="server" Text="<%$Resources:Resource,ChuyenKhoan%>" GroupName="rbnThanhToan" ID="rbnChuyenKhoan" />
                    </div>
                </div>
                <div class="col-md-4 col-lg-4 col-sm-4 col-xs-12">
                    <div class="row">
                        <asp:RadioButton runat="server" Text="<%$Resources:Resource,Online%>" GroupName="rbnThanhToan" ID="rbnOnline" />
                    </div>
                </div>
            </div>
        </div>

        <div class="booktour w100 fl">
            <div class="btncontact">
                <div class="bgsend">
                    <asp:LinkButton runat="server" Text="<%$Resources:Resource,ContactSendCss%>" ID="ibtSend" OnCommand="FeedBack" ValidationGroup="contact" CommandName="Send" />
                </div>
            </div>
        </div>
        <telerik:RadInputManager runat="server" ID="rim1">
            <telerik:TextBoxSetting BehaviorID="bhFullName" ErrorMessage='<%$Resources:Resource,Required %>' Validation-IsRequired="true" Validation-ValidationGroup="contact">
                <TargetControls>
                    <telerik:TargetInput ControlID="txtFullName" />
                </TargetControls>
            </telerik:TextBoxSetting>
            <telerik:RegExpTextBoxSetting BehaviorID="bhEmail" Validation-IsRequired="true" Validation-ValidationGroup="contact" ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" ErrorMessage='<%$Resources:Resource,NotMatch %>'>
                <TargetControls>
                    <telerik:TargetInput ControlID="txtEmail" />
                </TargetControls>
            </telerik:RegExpTextBoxSetting>
            <telerik:RegExpTextBoxSetting BehaviorID="bhPhone" Validation-IsRequired="False" ValidationExpression="^(?!\s*$).+" ErrorMessage='<%$Resources:Resource,NotMatch %>'>
                <TargetControls>
                    <telerik:TargetInput ControlID="txtPhone" />
                </TargetControls>
            </telerik:RegExpTextBoxSetting>
        </telerik:RadInputManager>
    </div>
</div>
<script type="text/javascript">
    $('#<%=c_lich.ClientID%>').datepicker();
</script>
