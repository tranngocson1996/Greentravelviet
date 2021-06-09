<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ArticleVideoDetail.ascx.cs" Inherits="Controls_Article_ArticleVideoDetail" %>
<%@ Register Src="~/Controls/Video/ArticleVideoReference.ascx" TagPrefix="uc1" TagName="ArticleVideoReference" %>




<%= Include.ArticleToolbar()%>
<%= Include.Video() %>
<div class="video_detail">
    <div class="title">
        <h1>
            <img src="<%=Page.ResolveUrl("~/Styles/img/icon_video.png") %>" /> 
            <asp:Label runat="server" ID="ltlTitle" CssClass="bullet-li title_vddetail"></asp:Label>
        </h1>
    </div>
    <div id="divDetailContent">
        <div class="videodetail">
            <div class="view">
                <div id="videodetail">
                </div>
            </div>
        </div>
    </div>
    <div class="clear"></div>
    <div class="video_content_body">
        <asp:Literal runat="server" ID="ltvideobody"></asp:Literal>
        <div class="clear"></div>
        <uc1:ArticleVideoReference runat="server" id="ArticleVideoReference" />
    </div>
</div>

<%= Include.ColorBox()%>
<script type="text/javascript">
    $(function () {
        $('#divDetailContent img').each(function () {
            var urlImg = $(this).attr('src');
            var wImg = $(this).width();
            var hImg = $(this).height();
            $(this).wrap('<a class="colorbox" style="width:' + wImg + 'px ; height:' + hImg + 'px" href="' + urlImg + '" rel="gallery1"></a>');
        });
        $(".colorbox").colorbox();
    });
</script>
<script type="text/javascript">
        <%= ScriptRunVideo %>
    function RunVideoDetail(_file, _image, _title) {
        jwplayer("videodetail").setup({
            flashplayer: "/Scripts/jwplayer/player.swf",
            height: 312,
            width: 465,
            file: _file,
            image: _image,
            stretching: 'fill',
            autostart: false,
            skin: '/Scripts/jwplayer/skin/stormtrooper/stormtrooper.xml'
        });
    }
</script>
