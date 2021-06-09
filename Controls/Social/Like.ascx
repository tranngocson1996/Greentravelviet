<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Like.ascx.cs" Inherits="Controls_Social_Like" %>
<%@ Import Namespace="BIC.Utils" %>
<div class="DivbtLike">
    <div class="btfbl">
        <div class="fb-like" data-href='<%= Request.Url.ToString() %>' data-layout="button_count" data-action="like" data-show-faces="true" data-share="false"></div>
    </div>
    <div class="btfbs">
        <div class="fb-share-button" data-href='<%= Request.Url.ToString() %>' data-layout="button_count"></div>
    </div>
    <div class="btgg">
        <div class="g-plusone" data-size="medium" data-href='<%= Request.Url.ToString() %>'></div>
    </div>
</div>
<div style="clear: both;"></div>
<div class="likegoogle">
    <script type="text/javascript">
        window.twttr = (function (d, s, id) { var t, js, fjs = d.getElementsByTagName(s)[0]; if (d.getElementById(id)) { return } js = d.createElement(s); js.id = id; js.src = "https://platform.twitter.com/widgets.js"; fjs.parentNode.insertBefore(js, fjs); return window.twttr || (t = { _e: [], ready: function (f) { t._e.push(f) } }) }(document, "script", "twitter-wjs"));
    </script>
    <script type="text/javascript">
        window.fbAsyncInit = function () {
            FB.init({
                appId: '<%= BicXML.ToString("FacebookAppID","SearchEngine") %>',
                xfbml: true,
                version: 'v2.8'
            });
            FB.AppEvents.logPageView();
        };

        (function (d, s, id) {
            var js, fjs = d.getElementsByTagName(s)[0];
            if (d.getElementById(id)) { return; }
            js = d.createElement(s); js.id = id;
            js.src = "//connect.facebook.net/en_US/sdk.js";
            fjs.parentNode.insertBefore(js, fjs);
        }(document, 'script', 'facebook-jssdk'));

        window.___gcfg = { lang: 'vi' };
        (function () {

            var po = document.createElement('script'); po.type = 'text/javascript'; po.async = true;

            po.src = 'https://apis.google.com/js/plusone.js';

            var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(po, s);

        })();

    </script>
</div>
