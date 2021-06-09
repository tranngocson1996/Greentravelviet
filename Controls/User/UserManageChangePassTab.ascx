<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserManageChangePassTab.ascx.cs" Inherits="Controls_User_UserManageChangePassTab" %>
<%@ Import Namespace="BIC.Utils" %>
<asp:Panel runat="server">
    <telerik:RadCodeBlock runat="server">
        <telerik:RadAjaxPanel runat="server" ID="rapContact" LoadingPanelID="ralpContact">
            <asp:Panel runat="server">
                <div class="title fw">
                    <%= BicResource.GetValue("Register_Change_Password_Guide") %>
                </div>
                <div class="fw form-ca-nhan">
                      <div class="row">
                    <div class="col-md-6 col-sm-6 col-xs-12 col-lg-6 col-lg-offset-3">
                        <div class="form-group">
                            <div class="row">
                                <label class="control-label col-sm-5 col-lg-4 col-md-4 col-xs-12">
                                    Mật khẩu cũ <span class="text-danger">*</span>
                                </label>
                                <div class="col-sm-7 col-md-8 col-lg-8 col-xs-12">
                                    <input class="form-control input-sm" id="txtPassWord"  type="password" runat="server" ClientIDMode="Static"/>
                                </div>
                                <div class="clear"></div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <label class="control-label col-sm-5 col-lg-4 col-md-4 col-xs-12">
                                    <telerik:RadCodeBlock runat="server">
                                        Mật khẩu mới <span class="text-danger">*</span>
                                    </telerik:RadCodeBlock>
                                </label>
                                <div class="col-sm-7 col-md-8 col-lg-8 col-xs-12">
                                    <input class="form-control input-sm" id="txtNewPassword"  type="password" runat="server" ClientIDMode="Static"/>
                                </div>
                                <div class="clear"></div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <label class="control-label col-sm-5 col-lg-4 col-md-4 col-xs-12">
                                    <telerik:RadCodeBlock runat="server">
                                        Nhập lại mật khẩu mới <span class="text-danger">*</span>
                                    </telerik:RadCodeBlock>
                                </label>
                                <div class="col-sm-7 col-md-8 col-lg-8 col-xs-12">
                                    <input class="form-control input-sm" id="txtReNewPassword"  type="password" runat="server" ClientIDMode="Static"/>
                                </div>
                                <div class="clear"></div>
                            </div>
                        </div>
                         <div class="form-group">
                            <div class="row">
                                <div class="col-sm-offset-4 col-sm-8">
                                     <asp:Button ID="btnChangePass" CssClass="btn btn-success" runat="server" ClientIDMode="Static" OnClick="btnChangePass_Click" Text="<%$Resources:UserManager,Update %>"></asp:Button>
                                </div>
                                <div class="clear"></div>                               
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                       
                    </div>
                    <div class="clear"></div>
                </div>
                </div>
                <div class="clear"></div>
            </asp:Panel>
        </telerik:RadAjaxPanel>
    </telerik:RadCodeBlock>
</asp:Panel>