<%@ Control Language="C#" AutoEventWireup="true" CodeFile="~/Controls/Video/VideoCotTrai.ascx.cs" Inherits="Controls_Video_VideoHome" %>
<%@ Import Namespace="BIC.Utils" %>
<%= Include.Jwplayer7() %>
 <div id='videoPlayer'></div>
<script>
    //License Key JwPlayer 7 dadg@bicweb.vn
    jwplayer.key = "YF5WouVCtlsIhBT9mSc5oWNjigOSlwz8ewUnTg==";
    //License Key JwPlayer 6 dadg@bicweb.vn
    //jwplayer.key = "CwSPh1D5QIAfmXvFat3wtU2+3UA7WXd+Iy0+FA==";
    var playerInstance = jwplayer('videoPlayer').setup({
        flashplayer: '<%=Page.ResolveUrl("~/Scripts/jwplayer7/jwplayer.flash.swf") %>',
        controlbar: 'bottom',
        aspectratio: '4:3'
    });
    playerInstance.setup({
        file: '<%=videoUrl%>',
        width: '614',
        height: '372',
        autostart: "true",
        controls: "true"
    });
    //playerInstance.play();
</script>
