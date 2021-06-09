<%@ Page Language="C#" AutoEventWireup="true" MaintainScrollPositionOnPostback="false" CodeFile="ShoppingCart.aspx.cs" Inherits="ShoppingCart" %>

<%@ Import Namespace="BIC.Utils" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <telerik:RadCodeBlock runat="server">
        <%=Include.JqueryUI() %>
        <%=Include.ShoppingCart() %>
    </telerik:RadCodeBlock>
</head>
<body style="margin: 0">
    <form id="form1" runat="server">
        <telerik:RadScriptManager runat="server" ID="rcm1" />
        <div class="header w100 fl">
            <div class="container">
                <div class="row">
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                        <div class="logo">
                            <a href="<%= BicApplication.URLRoot %>">
                                <img src="<%= Page.ResolveUrl("~/Styles/img/logo.png") %>" />
                            </a>
                        </div>
                    </div>
                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                        <div class="step">
                            <div class="step_1 buoc"><span class="so1 so">1</span><span class="line_text"><%= BicResource.GetValue("ShoppingCart_Step1") %></span></div>
                            <div class="step_2 buoc"><span class="so2 so">2</span><span class="line_text"><%= BicResource.GetValue("ShoppingCart_Step2") %></span></div>
                            <div class="step_3 buoc"><span class="so3 so">3</span><span class="line_text"><%= BicResource.GetValue("ShoppingCart_Step3") %></span></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="main_shoppingcart w100 fl">
            <div class="container">
                <asp:PlaceHolder runat="server" ID="phCart"></asp:PlaceHolder>
            </div>
        </div>
        <div class="footer w100 fl">
            <span class="tencongty"><%= BicResource.GetValue("SiteName") %></span>
            <span class="copyright"><%= BicResource.GetValue("Copyright") %></span>
        </div>
    </form>
</body>
</html>
<script type="text/javascript">
    var id = '<%=id%>';
    $(".current").removeClass("current");
    $(".step_" + id).addClass("current");
    $("#progress_icon").removeClass().addClass("step_" + id + "_icon");
    $("#orange_line").removeClass().addClass("step_" + id + "_line");
</script>
