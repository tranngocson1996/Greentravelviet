<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserManageProfileTab.ascx.cs" Inherits="Controls_User_UserProfile" %>
<%@ Import Namespace="BIC.Utils" %>
<telerik:RadCodeBlock runat="server">
    <telerik:RadAjaxPanel runat="server" ID="rapContact" LoadingPanelID="ralpContact">
        <asp:Panel runat="server">
            <div class="title fw">
                <%= BicResource.GetValue("Register_Change_Profile_Guide") %>
            </div>
            <div class="fw form-ca-nhan">
                <div class="row">
                    <div class="col-md-6 col-sm-6 col-xs-12 col-lg-6  <%=CssClass1 %>">
                        <div class="form-group">
                            <div class="row">
                                <label class="control-label col-sm-3 col-lg-3 col-md-3 col-xs-12">Tài khoản:</label>
                                <div class="col-sm-9 col-md-9 col-lg-9 col-xs-9">
                                    <input class="form-control input-sm" id="txtAcount" readonly type="text" runat="server" clientidmode="Static" />
                                </div>
                                <div class="clear"></div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <label class="control-label col-sm-3 col-lg-3 col-md-3 col-xs-12">
                                    <telerik:RadCodeBlock runat="server">
                                        <%= BicResource.GetValue("Register_FullName") %>
                                    </telerik:RadCodeBlock>
                                </label>
                                <div class="col-sm-9 col-md-9 col-lg-9 col-xs-9">
                                    <input class="form-control input-sm" id="txtFullName" type="text" runat="server" clientidmode="Static" />
                                </div>
                                <div class="clear"></div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <label class="control-label col-sm-3 col-lg-3 col-md-3 col-xs-12">
                                    <telerik:RadCodeBlock runat="server">
                                        Email
                                    </telerik:RadCodeBlock>
                                </label>
                                <div class="col-sm-9 col-md-9 col-lg-9 col-xs-9">
                                    <input class="form-control input-sm" id="txtEmail" type="text" runat="server" clientidmode="Static" />
                                </div>
                                <div class="clear"></div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <label class="control-label col-sm-3 col-lg-3 col-md-3 col-xs-12">
                                    Số điện thoại
                                </label>
                                <div class="col-sm-9 col-md-9 col-lg-9 col-xs-9">
                                    <input class="form-control input-sm" id="txtPhone" type="text" runat="server" clientidmode="Static" />
                                </div>
                                <div class="clear"></div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <label class="control-label col-sm-3 col-lg-3 col-md-3 col-xs-12">
                                    <telerik:RadCodeBlock runat="server">
                                        Công ty
                                    </telerik:RadCodeBlock>
                                </label>
                                <div class="col-sm-9 col-md-9 col-lg-9 col-xs-9">
                                    <input class="form-control input-sm" id="txtCompany" type="text" runat="server" clientidmode="Static" />
                                </div>
                                <div class="clear"></div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <label class="control-label col-sm-3 col-lg-3 col-md-3 col-xs-12">
                                    <telerik:RadCodeBlock runat="server">
                                        Thành phố
                                    </telerik:RadCodeBlock>
                                </label>
                                <div class="col-sm-9 col-md-9 col-lg-9 col-xs-9">
                                    <asp:DropDownList runat="server" CssClass="form-control input-sm" ID="ddlThanhPho" AutoPostBack="True" OnSelectedIndexChanged="ddlThanhPho_OnSelectedIndexChanged" />
                                    <%--<input class="form-control input-sm" id="txtThanhPho" type="text" runat="server" ClientIDMode="Static"/>--%>
                                </div>
                                <div class="clear"></div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <label class="control-label col-sm-3 col-lg-3 col-md-3 col-xs-12">
                                    <telerik:RadCodeBlock runat="server">
                                        Quận/huyện
                                    </telerik:RadCodeBlock>
                                </label>
                                <div class="col-sm-9 col-md-9 col-lg-9 col-xs-9">
                                    <asp:DropDownList runat="server" ID="ddlDistrict" CssClass="form-control input-sm" />
                                    <%--<input class="form-control input-sm" id="txtQuanHuyen" type="text" runat="server" ClientIDMode="Static"/>--%>
                                </div>
                                <div class="clear"></div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12 <%= CssClass2 %>">
                        <div class="form-group hidden">
                            <div class="row">
                                <label class="control-label col-sm-3 col-lg-3 col-md-3 col-xs-12">
                                    Facebook ID
                                </label>
                                <div class="col-sm-9 col-md-9 col-lg-9 col-xs-9">
                                    <input class="form-control input-sm" readonly="true" id="txtFacebookID" type="text" runat="server" clientidmode="Static" />
                                </div>
                                <div class="clear"></div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <label class="control-label col-sm-3 col-lg-3 col-md-3 col-xs-12">
                                    Link face cá nhân
                                </label>
                                <div class="col-sm-9 col-md-9 col-lg-9 col-xs-9">
                                    <input class="form-control input-sm" id="txtFacebookLink" type="text" runat="server" clientidmode="Static" />
                                </div>
                                <div class="clear"></div>
                            </div>
                        </div>
                        <div class="form-group hidden">
                            <div class="row">
                                <label class="control-label col-sm-3 col-lg-3 col-md-3 col-xs-12">
                                    Google ID
                                </label>
                                <div class="col-sm-9 col-md-9 col-lg-9 col-xs-9">
                                    <input class="form-control input-sm" readonly="true" id="txtGoogleID" type="text" runat="server" clientidmode="Static" />
                                </div>
                                <div class="clear"></div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <label class="control-label col-sm-3 col-lg-3 col-md-3 col-xs-12">
                                    Google Link
                                </label>
                                <div class="col-sm-9 col-md-9 col-lg-9 col-xs-9">
                                    <input class="form-control input-sm" id="txtGoogleLink" type="text" runat="server" clientidmode="Static" />
                                </div>
                                <div class="clear"></div>
                            </div>
                        </div>
                        <div class="form-group hidden">
                            <div class="row">
                                <label class="control-label col-sm-3 col-lg-3 col-md-3 col-xs-12">
                                    <telerik:RadCodeBlock runat="server">
                                        Tổng điểm
                                    </telerik:RadCodeBlock>
                                </label>
                                <div class="col-sm-9 col-md-9 col-lg-9 col-xs-9">
                                    <input class="form-control input-sm" readonly="true" id="txtPoint" type="text" runat="server" clientidmode="Static" />
                                </div>
                                <div class="clear"></div>
                            </div>
                        </div>
                        <div class="form-group hidden">
                            <div class="row">
                                <label class="control-label col-sm-3 col-lg-3 col-md-3 col-xs-12">
                                    <telerik:RadCodeBlock runat="server">
                                        Đã sử dụng
                                    </telerik:RadCodeBlock>
                                </label>
                                <div class="col-sm-9 col-md-9 col-lg-9 col-xs-9">
                                    <input class="form-control input-sm" readonly="true" id="txtUsedPoint" type="text" runat="server" clientidmode="Static" />
                                </div>
                                <div class="clear"></div>
                            </div>
                        </div>
                        <div class="form-group hidden">
                            <div class="row">
                                <label class="control-label col-sm-3 col-lg-3 col-md-3 col-xs-12">
                                    <telerik:RadCodeBlock runat="server">
                                        Còn lại
                                    </telerik:RadCodeBlock>
                                </label>
                                <div class="col-sm-9 col-md-9 col-lg-9 col-xs-9">
                                    <input class="form-control input-sm" readonly="true" id="txtCurPoint" type="text" runat="server" clientidmode="Static" />
                                </div>
                                <div class="clear"></div>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="row">
                                <label class="control-label col-sm-3 col-lg-3 col-md-3 col-xs-12">
                                    <telerik:RadCodeBlock runat="server">
                                        Note
                                    </telerik:RadCodeBlock>
                                </label>
                                <div class="col-sm-9 col-md-9 col-lg-9 col-xs-9">
                                    <textarea rows="5" cols="5" class="form-control input-sm" readonly="true" id="txtPointNote" type="text" runat="server" clientidmode="Static"></textarea>
                                </div>
                                <div class="clear"></div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                        <div class="form-group">
                            <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <button type="button" class="btn btn-success center-block" onclick="Update()">
                                        Cập nhật
                                    </button>
                                    <asp:Button CssClass="btn btn-success center-block hidden" runat="server" ID="btnUpdate" OnClick="btnUpdate_OnClick" Text="Cập nhật" />
                                </div>
                                <div class="clear"></div>
                            </div>
                        </div>
                    </div>
                    <div class="clear"></div>
                </div>
            </div>
            <div class="clear"></div>

        </asp:Panel>
    </telerik:RadAjaxPanel>

    <telerik:RadAjaxLoadingPanel runat="server" Skin="Windows7" ID="ralpContact" BackgroundPosition="Center" EnableSkinTransparency="true">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadScriptBlock runat="server">
        <script type="text/javascript">
            function Update() {
                var account = $('#txtAcount').val();
                var rFullName = $('#txtFullName').val();
                var rEmail = $('#txtEmail').val();
                var rPhone = $('#txtPhone').val();

                if (account.length == 0) {
                    alert("Bạn chưa nhập tài khoản");
                    return false;
                } else if (rFullName.length == 0) {
                    alert("Bạn chưa nhập họ tên");
                    return false;
                } else if (rEmail.length == 0) {
                    alert("Bạn chưa nhập email");
                    return false;
                } else if (rPhone.length == 0) {
                    alert("Bạn chưa nhập số điện thoại");
                    return false;
                } else {
                    var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;
                    if (reg.test(rEmail) == false) {
                        alert("Email không đúng định dạng");
                        return false;
                    } else {
                        $('#<%= btnUpdate.ClientID %>').click();
                    return true;
                }
            }
}
        </script>
    </telerik:RadScriptBlock>
</telerik:RadCodeBlock>
