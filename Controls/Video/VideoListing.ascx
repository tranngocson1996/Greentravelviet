<%@ Control Language="C#" AutoEventWireup="true" CodeFile="VideoListing.ascx.cs"
    Inherits="Controls_Gallery_GalleryListing" %>
<%@ Import Namespace="BIC.Utils" %>

<%= Include.Jwplayer7() %>
<%= Include.Video()%>
<div class="ProductListing">
    <div class="container">
        <div class="w100 fl list">
            <div class="row">
                <bic:ArticleListViewTopPager runat="server" ID="ProductList" EnableAutoRedirect="True" ExtensionLink="HTML" SelectFields="ImageName">
                    <ItemTemplate>
                        <div class="item col-lg-3 col-md-3 col-sm-4 col-xs-12">
                            <a data-href="<%# Eval("Url") %>" class='image' target='<%# BicConvert.ToString(Eval("Target")).Trim() %>' title='<%#Eval("Title") %>' data-title="<%#Eval("Title") %>">
                                <img src="/FileUpload/Images/thumb/<%#Eval("ImageName") %>" class="img-responsive w100 center-block" />
                            </a>
                            <a data-href="<%# Eval("Url") %>" class='title' target='<%# BicConvert.ToString(Eval("Target")).Trim() %>' title='<%#Eval("Title") %>' data-title="<%#Eval("Title") %>">
                                <%# BicString.TrimText(Eval("Title").ToString(),120) %> <%#Eval("NewsIcon") %>
                            </a>
                        </div>
                    </ItemTemplate>
                </bic:ArticleListViewTopPager>
            </div>
        </div>
        <div id="divPage" class="w100 fl">
            <bic:PagerUI ID="pager" SelectedCssClass="pager_selected" Label='' runat="server" Next=">>" Previous="<<" EnableNextPrev="True" PagerUIStep="10" OnPageIndexChanged="pager_PageIndexChanged" />
        </div>
        <div class="clear"></div>
    </div>
</div>


<div class="DacDiemLoaiLoading videoDetail" id="DacDiemLoaiLoading">
    <div class="overlay"></div>
    <div class="GalleryLoadingW100H100">
          <div class="GalleryBox">
              <div id='videoPlayer'></div>
              <a class="btclose"></a>
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
        playlist: [<%= VideoList %>],
        width: '100%',
        height: '480',
        skin: {
            name: "vapor"
        },
        logo: {
            file: '/Styles/img/ic_logo.png',
            link: 'http://bicweb.vn',
            position: 'top-left'
        }
    });
    function loadVideo(vFile, vImage, vTitle) {
        jwplayer().load([{
            file: vFile,
            image: vImage,
            title: vTitle
        }]);
        playerInstance.play();
    };

    $('.ProductListing .list .item a').click(function () {
        var file = $(this).attr('data-href');
        var title = $(this).attr('data-title');
        loadVideo(file, '', title);
        $('.videoDetail').fadeIn();
    });
    
    $('.videoDetail .GalleryBox .btclose').click(function (event) {
        jwplayer('videoPlayer').stop();
        $('.videoDetail').fadeOut();
        event.stopPropagation();
    });
    $('.videoDetail').click(function (event) {
        jwplayer('videoPlayer').stop();
        $(this).fadeOut();
        event.stopPropagation();
    });
    $('.videoDetail .GalleryBox').click(function (event) {
        event.stopPropagation();
    });
</script>
