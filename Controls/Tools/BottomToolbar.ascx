<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BottomToolbar.ascx.cs" Inherits="Controls_Article_Tools_BottomToolbar" %>
<%@ Import Namespace="BIC.Utils" %>
<%@ Register Src="~/Controls/Social/Like.ascx" TagPrefix="uc1" TagName="Like" %>

<div class="BottomToolbar">
    <asp:HyperLink ID="btnGoBack" runat="server" CssClass="back" ToolTip="<%$Resources:Resource,Back%>" ><%=BicResource.GetValue("Back") %></asp:HyperLink>
    <div class="update">
        
        <asp:Literal ID="ltlModifiedDate" runat="server" />
    </div>
    <div class="pageview" runat="server" id="viewcount">
        <asp:Literal ID="ltlViewCount" runat="server" /></div>
    <%--<a class="to-top" href="javascript:goBack()" title='Quay lại'>Quay lại</a>--%>

    <%--<div class="likefacebook">
        <uc1:Like runat="server" ID="Like" />
    </div>--%>
    <a class="to-top" href="#" title='<%=BicResource.GetValue("TopPageToolTip") %>'>
        <%=BicResource.GetValue("TopPage") %></a>
</div>
<%--
<div class="BottomToolbar">
    <div class="update">
        <asp:Literal ID="ltlModifiedDate" runat="server" />
    </div>
    <div class="pageview" runat="server" id="viewcount">
        <asp:Literal ID="ltlViewCount" runat="server" />
    </div>
  
    <div class="divPrint">
        <a href='<%=String.Format("{0}{1}/print-article.html", BicApplication.URLRoot, ArticleID)%>' class="print" title='<%=BicResource.GetValue("PrintToolTip") %>'>
            <%=BicResource.GetValue("Print")%></a>
    </div>
    <div class="social-network">
        <div class="likefacebook">
            <iframe src='http://www.facebook.com/plugins/like.php?href=<%= Request.Url.ToString() %>&amp;send=false&amp;layout=button_count&amp;width=100&amp;show_faces=false&amp;action=like&amp;colorscheme=light&amp;font&amp;height=21'
                scrolling="no" frameborder="0" style="border: none; height: 21px; overflow: hidden; width: 100px;" allowtransparency="true"></iframe>
        </div>
        <div class="likegoogle">
            <div class="g-plusone" data-size="medium" data-href='<%= Request.Url.ToString() %>'>
            </div>
        </div>
        <div class="icon-social">
            <a onclick="zing_click()" class="zing"></a>
            <a onclick="fbs_click()" class="facebook"></a>
            <a onclick="share_google()" class="google"></a>
            <a onclick="" class="youtube last"></a>
        </div>
    </div>
</div>

<script type="text/javascript">    var addthis_config = { "data_track_clickback": true };</script>
<script type="text/javascript" src="http://s7.addthis.com/js/250/addthis_widget.js#pubid=ra-4d9d3d526d0cadfa"></script>
<script type="text/javascript">
    function zing_click() {
        u = location.href; t = document.title;
        window.open("http://link.apps.zing.vn/pro/view/conn/share?fl=&u=" + encodeURIComponent(u) + "&amp;t=" + encodeURIComponent(t) + "&amp;desc=" + encodeURIComponent(t))
    }

    function openRadWinSendMail() {
        if ($.browser.msie) {
            window.open(document.getElementById('txtSendMailUrl').value, null, "height=420,width=371,status=no,toolbar=no,menubar=no,location=no,resize=no");
        }
        else {
            radopen(document.getElementById('txtSendMailUrl').value, "radWinSendMail");
        }

    }

    window.___gcfg = { lang: 'vi' };
    (function () {
        var po = document.createElement('script');
        po.type = 'text/javascript';
        po.async = true;
        po.src = 'https://apis.google.com/js/plusone.js';
        var s = document.getElementsByTagName('script')[0];
        s.parentNode.insertBefore(po, s);
    });

    $(".plusSize").click(function () {
        $("#divDetailContent").css({ "font-size": (parseInt($(".content").css("font-size")) + 1) + 'px', "line-height": "120%" });
    });

    $(".minusSize").click(function () {
        $("#divDetailContent").css({ "font-size": (parseInt($(".content").css("font-size")) - 1) + 'px', "line-height": "120%" });
    });
</script>--%>

    