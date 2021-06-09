<%@ Control Language="C#" AutoEventWireup="true" CodeFile="VideoHome.ascx.cs" Inherits="Controls_Video_VideoHome" %>
<%@ Import Namespace="BIC.Utils" %>
<%= Include.Video() %>
<%= Include.Jwplayer7() %>
<div class="w100 fl VideoHome">
    <div class="row">
        <div class="col-lg-8 col-md-8 col-sm-12 col-xs-12 BenTrai">
            <div id='videoPlayer'></div>
            <div class="title1 w100 fl" id="title">
                <%=FirstTitle %>
            </div>
            <div class="Desc w100 fl" id="desc">
                 <%=FirstDesc %>
            </div>
        </div>
        <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12 BenPhai hidden-xs hidden-sm">
            <div class="w100 fl ListVideoHome">
                <asp:ListView runat="server" ID="lvVideoHome">
                    <ItemTemplate>
                        <div class="item" data-desc="<%#Eval("BriefDescription") %>" data-file="<%#Eval("File") %>" data-image="<%#Eval("Image") %>" data-title="<%#Eval("Title") %>">
                            <img src="<%#Eval("Image") %>" class="img-responsive w100 center-block" title="<%#Eval("Title") %>" />
                            <a class="icon"></a>
                        </div>
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </div>
    </div>
</div>

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
        playlist: [<%= videoList %>],
        width: '100%',
        height: '180',
        skin: {
            name: "vapor"
        },
        logo: {
            file: '/Styles/img/ic_logo.png',
            link: 'http://bicweb.vn',
            position: 'top-left' //top-right (the default), top-left, bottom-right or bottom-left
        }
    });
    function loadVideo(vFile, vImage, vTitle) {
        jwplayer().load([{
            file: vFile,
            image: vImage,
            title: vTitle
        }]);
        //jwplayer().play();
        playerInstance.play();
    };
    
    $('.ListVideoHome .item').click(function () {
        var file = $(this).attr('data-file');
        var image = $(this).attr('data-image');
        var title = $(this).attr('data-title');
        var desc = $(this).attr('data-desc');
        loadVideo(file, image, title);
        $('#title').text(title);
        $('#desc').text(desc);
    });
</script>
