<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BottomToolbar.ascx.cs" Inherits="Controls_Tour_Tools_BottomToolbar" %>
<%@ Import Namespace="BIC.Utils" %>

<div class="BottomToolbarTour">    
    <div class="pageview"><asp:Literal ID="ltlViewCount" runat="server" /></div>    
    <a href='<%=String.Format("{0}{1}/print-tour.bic", BicApplication.URLRoot, Tourid)%>' class="print" title='<%=BicResource.GetValue("PrintToolTip") %>'>
        <%=BicResource.GetValue("Print")%></a> 
        
    <a onclick="yhs_click()" class="yahoo" id="yahoo_share" style="cursor: pointer" title='<%=BicResource.GetValue("YahooToolTip") %>'>
            <%=BicResource.GetValue("Yahoo")%></a> 
    
    <a class="email" title='<%=BicResource.GetValue("EmailToolTip") %>' id="aEmail" onclick='openRadWinSendMail()'><%=BicResource.GetValue("Email")%></a> 
               
    <input type="text" id="txtSendMailUrl" value='<%=SendMailUrl %>' style="display:none" />         
        <telerik:RadWindowManager ID="radWinManSendMail" runat="server" EnableShadow="true">        
        <Windows>
            <telerik:RadWindow
                ID="radWinSendMail" 
                runat="server" 
                showcontentduringload="false" 
                width="370px" 
                height="420px" 
                title='<%#BicResource.GetValue("ShareByEmailCaption") %>'
                behaviors="Default" 
                Localization-Minimize="false" 
                Localization-Maximize="false"
                Localization-Reload="false"
                Localization-PinOff="false"
                Localization-PinOn="false"
                Overlay="true" 
                VisibleStatusbar="false"  >                
            </telerik:RadWindow>
        </Windows>
        </telerik:RadWindowManager>      
    <a class="zing" onclick="share_zing()" style="cursor: pointer" title='<%=BicResource.GetValue("ZingToolTip") %>'></a>
    <a class="facebook" onclick="share_facebook()" style="cursor: pointer" title='<%=BicResource.GetValue("FacebookToolTip") %>'></a>
    <a class="twitter" onclick="share_twitter()" style="cursor: pointer" title='<%=BicResource.GetValue("TwitterToolTip") %>'></a>
    <a class="share" onclick="return addthis_sendto()" onmouseout="addthis_close()"
        onmouseover="return addthis_open(this, '', '[URL]', '[TITLE]')" href="http://www.addthis.com/bookmark.php"
        title='<%=BicResource.GetValue("SocialNetworkToolTip") %>'></a>
</div>

<script type="text/javascript">    var addthis_config = { "data_track_clickback": true };</script>
<script type="text/javascript" src="http://s7.addthis.com/js/250/addthis_widget.js#pubid=ra-4d9d3d526d0cadfa"></script>

<script type="text/javascript">
    function zing_click() {
        u = location.href; t = document.title;
        window.open("http://link.apps.zing.vn/pro/view/conn/share?fl=&u=" + encodeURIComponent(u) + "&amp;t=" + encodeURIComponent(t) + "&amp;desc=" + encodeURIComponent(t))
    }
    function share_facebook() {
        u = location.href;
        t = document.title;
        window.open('http://www.facebook.com/sharer.php?u=' + encodeURIComponent(u) + '&t=' + encodeURIComponent(t), 'sharer', ',width=980,height=600');
        return false;
    }
    function yhs_click() {
        document.getElementById('yahoo_share').href = "ymsgr:im?msg=" + document.title + ' ' + location.href;
    }
    function share_twitter() {
        var uvnn = location.href;
        var tvnn = document.title;
        window.open("http://twitter.com/home?status=" + encodeURIComponent(uvnn));
    }
    function openRadWinSendMail() {
        radopen(document.getElementById('txtSendMailUrl').value, "radWinSendMail");
    }

    $(".plusSize").click(function () {
        $("#divDetailContent").css("font-size", (parseInt($(".content").css("font-size")) + 1) + 'px');
    });

    $(".minusSize").click(function () {
        $("#divDetailContent").css("font-size", (parseInt($(".content").css("font-size")) - 1) + 'px');
    });
</script>
