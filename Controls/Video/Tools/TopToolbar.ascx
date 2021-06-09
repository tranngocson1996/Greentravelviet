<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TopToolbar.ascx.cs" Inherits="Controls_Article_Tools_TopToolbar" %>
<%@ Import Namespace="BIC.Utils" %>
<%=Include.Simplemodal()%>
<%=Include.CssAdd("Controls/Gallery/Tools/Toolbar.css")%>
<div class="TopToolbar">
    <div class="update">
        <asp:Literal ID="ltlModifiedDate" runat="server" />
    </div>
    <div class="pageview" runat="server" id="viewcount"><%=BicResource.GetValue("ViewCount") %>
        <asp:Literal ID="ltlViewCount" runat="server" /></div>
    <span class="seperator"></span>
    <div id="ShareToobar">
    <a onclick="fbs_click()"></a>
        <a onclick="share_google()"></a>
</div>
    <div id="like">
                        <div class="likegoogle">
                            <div class="g-plusone" data-size="medium" data-href='<%= Request.Url.ToString() %>'>
                            </div>
                        </div>
                        <div class="likefacebook">
                            <iframe src='http://www.facebook.com/plugins/like.php?href=<%= Request.Url.ToString() %>&amp;send=false&amp;layout=button_count&amp;width=100&amp;show_faces=false&amp;action=like&amp;colorscheme=light&amp;font&amp;height=21'
                                scrolling="no" frameborder="0" style="border: none; height: 21px; overflow: hidden; width: 90px;" allowtransparency="true"></iframe>
                        </div>

                    </div>

</div>
<script type="text/javascript" src="http://s7.addthis.com/js/250/addthis_widget.js#pubid=ra-4d9d3d526d0cadfa"></script>

<script type="text/javascript">
    function fbs_click() {
        var u = location.href;
        var t = document.title;
        window.open('http://www.facebook.com/sharer.php?u=' + encodeURIComponent(u) + '&t=' + encodeURIComponent(t), 'sharer', ',width=600,height=480');
        return false;
    }
    function share_google() {
        var u = location.href;
        var t = document.title;
        window.open("https://plus.google.com/share?url=" + encodeURIComponent(u) + '&t=' + encodeURIComponent(t), 'sharer', ',width=600,height=480');

    }
    (function () {
        var po = document.createElement('script'); po.type = 'text/javascript'; po.async = true;
        po.src = 'https://apis.google.com/js/plusone.js';
        var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(po, s);
    })();
</script>