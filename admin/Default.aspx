<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="admin_Default" %>

<%@ Import Namespace="BIC.Utils" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="Controls/LoginView.ascx" TagName="LoginView" TagPrefix="uc2" %>
<%@ Register Src="Controls/Footer.ascx" TagName="Footer" TagPrefix="uc3" %>
<%@ Register Src="Controls/ClockText.ascx" TagName="ClockText" TagPrefix="uc4" %>
<%@ Register Src="Controls/Menu.ascx" TagName="Menu" TagPrefix="uc1" %>
<%@ Register Src="Controls/NavigatePath.ascx" TagName="NavigatePath" TagPrefix="uc5" %>
<%@ Register Src="~/admin/Controls/AdminLanguage.ascx" TagPrefix="uc1" TagName="AdminLanguage" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        <%=BicXML.ToString("AdminTitle", "SearchEngine")%></title>
    <meta http-equiv="Page-Exit" content="progid:DXImageTransform.Microsoft.Fade(duration=.3)" />
    <meta http-equiv="Page-Enter" content="revealTrans(Duration=1.0,Transition=23)" />
    <link rel="shortcut icon" href="Styles/icon/favi_BIC.ico" type="image/x-icon" />
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <%= IncludeAdmin.DefaultCss() %>
        <%= IncludeAdmin.JqueryUI() %>
        <%= IncludeAdmin.BICSkin() %>
        <script type="text/javascript">
            var AdminLanguage = "<%= BicLanguage.CurrentLanguageAdmin %>";
        </script>
    </telerik:RadCodeBlock>
</head>
<body class="admin">
    <form id="adminForm" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server" />
        <asp:HiddenField ID="hdfLang" runat="server" />
        <div class="container">
            <div class="header">
                <a class="logo" href='<%= Page.ResolveUrl(string.Format("~/admin?l={0}",BicHtml.GetRequestString("l") == "" ? BicXML.ToString("DefaultLanguage", "SearchEngine") : BicHtml.GetRequestString("l"))) %>'></a>
                <uc1:AdminLanguage runat="server" ID="AdminLanguage" />
                <uc2:LoginView ID="LoginView1" runat="server" />
                <uc4:ClockText ID="ClockText1" runat="server" />
            </div>
            <div class="main">
                <div class="main-left">
                    <div class="main-right">
                        <div class="main-top-left">
                        </div>
                        <div class="main-top-right">
                        </div>
                        <div class="menu-system">
                            <div class="menu-wrapp">
                                <uc1:Menu ID="Menu1" runat="server" />
                                <asp:LinkButton Text="Clear cache" CssClass="clear-cache" CausesValidation="false" runat="server" ID="lbtnClearCache" OnClick="lbtnClearCache_Click" />
                            </div>
                        </div>
                        <div class="navigate">
                            <div class="navigate-wrapp">
                                <uc5:NavigatePath ID="NavigatePath1" runat="server" />
                            </div>
                        </div>
                        <div class="content">
                            <div class="content-wrapp">
                                <asp:PlaceHolder EnableViewState="true" ID="phMainUserControl" runat="server"></asp:PlaceHolder>
                            </div>

                            <div class="clear">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="footer">
                <div class="footer-left">
                </div>
                <div class="footer-right">
                </div>
                <uc3:Footer ID="Footer1" runat="server" />
            </div>
        </div>
         <script type="text/javascript">
             function heartBeat() {
                 $.get("KeepAlive.ashx?", function (data) {
                 });
             }
             $(function () {
                 setInterval("heartBeat()", 1000 * 120); // 2 phút gửi request một lần
             });

        </script>
    </form>
</body>
</html>
