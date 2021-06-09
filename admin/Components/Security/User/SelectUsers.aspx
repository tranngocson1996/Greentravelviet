<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectUsers.aspx.cs" Inherits="StoreInfo.SelectUsers" %>
<%@ Import Namespace="BIC.Utils" %>
<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
        <%= IncludeAdmin.JqueryUI() %>
        <%= IncludeAdmin.SelectUsers() %>
        <%= IncludeAdmin.HighSlide() %>
        <script type="text/javascript">
            function SelectUser() {var users = $('#txtTo').val();window.jQuery.FrameDialog.setResult(users);window.jQuery.FrameDialog.closeDialog();}
            function CloseDialogUser() {window.jQuery.FrameDialog.closeDialog();}

            function BindingEvent() {$(function() {$('.all_item .item').hover(function() { $(this).toggleClass('highlight'); });$('.all_item .item:odd').addClass('alt');$('#btnOK').click(function() { SelectUser(); });});}
        </script>
    </head>
    <body>
        <form id="form1" runat="server">
            <div>
                <script type="text/javascript">
                    Sys.Application.add_load(BindingEvent);
                </script>
                <telerik:RadScriptManager runat="server">
                </telerik:RadScriptManager>
                <telerik:RadAjaxPanel runat="server">
                    <div class="select_users_frame">
                        <div class="top">
                            <div class="search">
                                <div class="title">
                                    <span class="caption"><%=BicResource.GetValue("Admin","System_Search") %> :</span>
                                    <asp:RadioButtonList ID="rdSearchType" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True" Value="0" Text="<%$Resources:Admin,Admin_Security_User_Name%>"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="<%$Resources:Admin,Admin_Security_User_Email%>"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                                <asp:TextBox runat="server" ID="txtSearch" class="text_box"></asp:TextBox>
                                <asp:Button runat="server" ID="btnSearch" Text="Tìm" OnClick="btnSearch_Click" />
                            </div>
                            <div class="group">
                                <div class="title">
                                    <span class="caption"><%=BicResource.GetValue("Admin","Admin_Security_User_AccordingToTheList") %>:</span></div>
                                <asp:DropDownList runat="server" ID="ddlRole" AutoPostBack="True" OnSelectedIndexChanged="ddlRole_SelectedIndexChanged" Width="300">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="meddium">
                            <asp:ListView runat="server" ID="dlUser" OnItemCommand="dlUser_ItemCommand" DataKeyNames="UserName">
                                <LayoutTemplate>
                                    <div class="users_table" id="itemPlaceholderContainer" runat="server">
                                        <div class="head">
                                            <div class="name">
                                               <%=BicResource.GetValue("Admin","System_Account") %></div>
                                            <div class="display_name">
                                              <%=BicResource.GetValue("Admin","System_FullScreen") %>
                                            </div>
                                            <div class="email">
                                              <%=BicResource.GetValue("Admin","Admin_Security_User_EmailAddress") %></div>
                                        </div>
                                        <div class="all_item">
                                            <div id="itemPlaceholder" runat="server">
                                            </div>
                                        </div>
                                    </div>
                                </LayoutTemplate>
                                <ItemTemplate>
                                    <div class="item">
                                        <div class="name">
                                            <asp:LinkButton ID="lbtnSelect" ToolTip="Chọn user" runat="server" Text='<%# Eval("UserName") %>' CommandName="SelectUser" CommandArgument='<%# Container.DataItem %>' />
                                        </div>
                                        <div class="display_name">
                                            <%# GetProfile(Eval("UserName").ToString()).FullName %></div>
                                        <%--                            <div class="email">
                                <%# GetProfile(Eval("UserName").ToString()).Email%></div>--%>
                                        <div style="clear:both;">
                                        </div>
                                    </div>
                                </ItemTemplate>
                                <EmptyDataTemplate>
                                    <div class="users_table">
                                        <div class="head">
                                            <div class="name">
                                                <%=BicResource.GetValue("Admin","Admin_Security_User_Name") %> </div>
                                            <div class="display_name">
                                                <%=BicResource.GetValue("Admin","Admin_Security_User_DisplayName") %> </div>
                                            <div class="email">
                                                <%=BicResource.GetValue("Admin","Admin_Security_User_EmailAddress") %></div>
                                        </div>
                                        <div class="all_item">
                                            <%=BicResource.GetValue("Admin","Admin_Security_User_NoData") %> 
                                        </div>
                                    </div>
                                </EmptyDataTemplate>
                            </asp:ListView>
                        </div>
                        <div id="divPage" class="divPage" runat="server">
                            <cc1:CollectionPager ID="pager" runat="server" BackText="" LabelText="Trang:" NextText="" ResultsFormat="Hiển thị kết quả {0}-{1} (Tổng {2})" BackNextLinkSeparator=""
                                                 BackNextLocation="None" MaxPages="20" PageSize="10" PageNumbersSeparator="&amp;nbsp;" PageNumbersStyle=" &amp;nbsp;" ResultsLocation="None" ControlCssClass="pager"
                                                 LabelStyle="FONT-WEIGHT: bold;padding-right:3px;" PageNumberStyle="padding:0px 3px;">
                            </cc1:CollectionPager>
                        </div>
                        <div class="bottom">
                            <div class="line_bottom">
                                <asp:TextBox runat="server" ID="txtTo" CssClass="text_box" ClientIDMode="Static"></asp:TextBox>
                            </div>
                            <div class="control_left">
                                <asp:Button runat="server" ID="btnRole" Text="<%$Resources:Admin,Admin_Security_User_SlectGroup%>" OnClick="btnRole_Click" />
                                <asp:Button runat="server" ID="btnAll" Text="<%$Resources:Admin,Admin_Security_User_SlectAll%>" OnClick="btnAll_Click" />
                                <asp:Button ID="btnDelAll" runat="server" Text="<%$Resources:Admin,System_Delete%>" OnClick="btnDelAll_Click" />
                            </div>
                            <div class="control">
                                <asp:Button ID="btnOK" runat="server" Text="<%$Resources:Admin,Admin_Security_Agree%>" ClientIDMode="Static" />
                                <input id="btnCancel" type="button" value="<%$Resources:Admin,Admin_Security_Cancel%>" onclick=" return CloseDialogUser(); " runat="server" />
                            </div>
                        </div>
                    </div>
                </telerik:RadAjaxPanel>
            </div>
        </form>
    </body>
</html>