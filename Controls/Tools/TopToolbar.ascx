<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TopToolbar.ascx.cs" Inherits="Controls_Article_Tools_TopToolbar" %>
<%@ Import Namespace="BIC.Utils" %>
<%@ Register Src="~/Controls/Social/Like.ascx" TagPrefix="uc1" TagName="Like" %>


<%--<%=Include.Simplemodal()%>--%>
<%=Include.ArticleToolbar()%>
<div class="TopToolbar">
    <%--<div class="update">
        <asp:Literal ID="ltlModifiedDate" runat="server" />
    </div>
    <div class="pageview" runat="server" id="viewcount">
        <asp:Literal ID="ltlViewCount" runat="server" /></div>--%>
    <%--<a class="back" href="javascript:history.go(-1);">
        <%=BicResource.GetValue("Back")%></a>--%>
    <span class="seperator"></span>
    <div class="changeTextSize">
        <a class="minusSize" title='<%=BicResource.GetValue("SizeDownToolTip") %>'></a>
        <a class="plusSize" title='<%=BicResource.GetValue("SizeUpToolTip") %>'></a>
        <%=BicResource.GetValue("FontSize") %>
    </div>
    <a class="email" title='<%=BicResource.GetValue("EmailToolTip") %>' id="aEmail" onclick='openRadWinSendMail()'>Email</a>
    <%--<a class="yahoo" id="yahoo_share" style="cursor: pointer" title='<%=BicResource.GetValue("YahooToolTip") %>' onclick="yhs_click();">
        <%=BicResource.GetValue("Yahoo")%></a>--%>
    <a href='<%=String.Format("{0}/{1}/print-article.html", Common.GetSiteUrl(), ArticleID)%>' class="print" title='<%=BicResource.GetValue("PrintToolTip") %>'>
        <%=BicResource.GetValue("Print")%></a>
    <a class="zing" onclick="zing_click()" style="cursor: pointer" title='<%=BicResource.GetValue("ZingToolTip") %>'></a>
    <a class="facebook" onclick="fbs_click()" style="cursor: pointer" title='<%=BicResource.GetValue("FacebookToolTip") %>'></a>
    <a class="google" onclick="share_twitter()" style="cursor: pointer" title='<%=BicResource.GetValue("TwitterToolTip") %>'></a>
    <a class="youtube" onclick="ytb_click()" title='<%=BicResource.GetValue("YoutubeToolTip") %>'></a>
    <input type="text" id="txtSendMailUrl" value='<%=SendMailUrl %>' style="display: none" />
    <telerik:RadWindowManager ID="radWinManSendMail" runat="server" EnableShadow="true">
        <Windows>
            <telerik:RadWindow ID="radWinSendMail" runat="server" ShowContentDuringLoad="false" Width="370px" Height="420px" Title='<%#BicResource.GetValue("ShareByEmailCaption") %>' Behaviors="Default" Localization-Minimize="false" Localization-Maximize="false" Localization-Reload="false" Localization-PinOff="false" Localization-PinOn="false" Overlay="true" VisibleStatusbar="false">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
</div>
<%--<script type="text/javascript">    var addthis_config = { "data_track_clickback": true };</script>
<script type="text/javascript" src="http://s7.addthis.com/js/250/addthis_widget.js#pubid=ra-4d9d3d526d0cadfa"></script>--%>
<script type="text/javascript">
    function google_click() {
        u = location.href; t = document.title;
        window.open("https://accounts.google.com/ServiceLogin?hl=vi&continue=http://www.google.com.vn/" + encodeURIComponent(u) + "&amp;t=" + encodeURIComponent(t) + "&amp;desc=" + encodeURIComponent(t))
    }
    //function zing_click() {
    //    u = location.href; t = document.title;
    //    window.open("http://link.apps.zing.vn/share?url=" + encodeURIComponent(u) + "%23.UeUhcDzgjCw.zingme&title=" + encodeURIComponent(t));
    //}
    function openRadWinSendMail() {
        if ($.browser.msie) {
            window.open(document.getElementById('txtSendMailUrl').value, null, "height=420,width=371,status=no,toolbar=no,menubar=no,location=no,resize=no");
        }
        else {
            radopen(document.getElementById('txtSendMailUrl').value, "radWinSendMail");
        }

    }
    //function ytb_click() {

    //    var u = location.href;
    //    var t = document.title;
    //    window.open('http://www.youtube.com/user/', 'newstools', 'status=yes,scrollbars=yes,resizable=yes,width=980,height=600');
    //    return false;
    //}
    $(".plusSize").click(function () {

        $("#divDetailContent").css({ "font-size": (parseInt($("#divDetailContent").css("font-size")) + 1) + 'px', "line-height": "120%" });
        $("#divDetailContent font").css({ "font-size": (parseInt($("#divDetailContent font").css("font-size")) + 1) + 'px', "line-height": "120%" });
        $("#divDetailContent span").css({ "font-size": (parseInt($("#divDetailContent span").css("font-size")) + 1) + 'px', "line-height": "120%" });
        $("#divDetailContent p").css({ "font-size": (parseInt($("#divDetailContent span").css("font-size")) + 1) + 'px', "line-height": "120%" });
    });

    $(".minusSize").click(function () {
        $("#divDetailContent ").css({ "font-size": (parseInt($("#divDetailContent ").css("font-size")) - 1) + 'px', "line-height": "120%" });
        $("#divDetailContent font").css({ "font-size": (parseInt($("#divDetailContent font").css("font-size")) - 1) + 'px', "line-height": "120%" });
        $("#divDetailContent span").css({ "font-size": (parseInt($("#divDetailContent span").css("font-size")) - 1) + 'px', "line-height": "120%" });
        $("#divDetailContent p").css({ "font-size": (parseInt($("#divDetailContent span").css("font-size")) - 1) + 'px', "line-height": "120%" });
    });
    //function yhs_click() {
    //    document.getElementById("yahoo_share").href = "ymsgr:im?msg=" + document.title + ' ' + location.href;
    //}
</script>
