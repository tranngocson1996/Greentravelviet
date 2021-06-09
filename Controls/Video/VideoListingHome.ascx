<%@ Control Language="C#" AutoEventWireup="true" CodeFile="VideoListingHome.ascx.cs" Inherits="Controls_Video_VideoListingHome" %>
<%@ Import Namespace="BIC.Utils" %>
<%= Include.fancybox() %>
<section class="videos-home">
    <div class="container">
        <div class="text-title">
            <h2>
                <bic:MenuCaption runat="server" ID="mnCap" CssClass="text" /></h2>
            <div class="mn-desc">
                <asp:Label ID="lblCap" runat="server" />
            </div>
        </div>
        <div class="items">
            <bic:ArticleListViewTop runat="server" ID="articleVideoList" EnableAutoRedirect="False" ExtensionLink="HTML" SelectFields="ImageID">
                <ItemTemplate>
                    <div class="item">
                        <figure>
                            <a href="<%# Eval("Url").ToString().Replace("watch?v=","embed/") %>" class="various fancybox fancybox.iframe" title="<%#Eval("Title") %>">
                                <img src="<%# getYouTubeThumbnail(Eval("Url").ToString(), Eval("ImageID").ToString()) %>" class="img-responsive" />
                            </a>
                        </figure>
                        <a href="<%# Eval("Url").ToString().Replace("watch?v=","embed/") %>" class="various fancybox fancybox.iframe" title="<%#Eval("Title") %>">
                            <%# BicString.TrimText(Eval("Title").ToString(),120) %>
                        </a>
                    </div>
                </ItemTemplate>
            </bic:ArticleListViewTop>
        </div>
    </div>
</section>
<script type="text/javascript">
    $(document).ready(function () {
        if ($('.fancybox').length) {
            $('.fancybox').fancybox({
                maxWidth: 800,
                maxHeight: 600,
                fitToView: false,
                width: '70%',
                height: '70%',
                autoSize: false,
                closeClick: false,
                openEffect: 'none',
                closeEffect: 'none'
            });
        }
    });
</script>
