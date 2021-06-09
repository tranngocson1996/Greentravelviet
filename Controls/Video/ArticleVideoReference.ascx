<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ArticleVideoReference.ascx.cs" Inherits="Controls_Video_ArticleVideoReference" %>
<%@ Import Namespace="BIC.Utils" %>
<telerik:RadAjaxPanel runat="server" ID="rapContact" LoadingPanelID="ralpContact">
    <div class="video_reference">
        <div class="content-video">
            <div class="cap-b">
               Video khác
                <div class="caption_other">
                <a class="next-video"></a>
                <a class="prev-video"></a>
            </div>
            </div>
            
            
            <div class="list">
                <bic:ArticleListViewTopPager runat="server" ExtensionLink="HTML" ID="lvReference" SelectFields="ImageName" TypeOfControl="3"  PageSize="12">
                    <ItemTemplate>
                        <div class='item'>
                            <div class="imageviewer">
                                <bic:Image ID="Image1" runat="server" ImageName='<%# Eval("ImageName") %>'
                                    Link='<%# Eval("Url") %>' Target='<%# Eval("Target") %>' Alt='<%# Eval("Title") %>' />
                                 <a href='<%# Eval("Url") %>' class="video_paly">
                            <img src='<%=Page.ResolveUrl("~/Controls/Video/img/paly_video.png") %>'/>
                        </a>
                            </div>
                            <div class="name">
                                <a href="<%# Eval("Url") %>" target='<%# BicConvert.ToString(Eval("Target")).Trim() %>'>
                                    <img src="/Controls/Video/img/icon_video.png" />
                                    <%# BicString.TrimText(Eval("Title").ToString(),40) %></a>
                            </div>
                        </div>
                    </ItemTemplate>
                </bic:ArticleListViewTopPager>
            </div>
        </div>
    </div>
</telerik:RadAjaxPanel>
<script type="text/javascript">

    $(".video_reference .list").carouFredSel({
        auto: true,
        items: 3,
        scroll: {
            items: 1,
            duration: 1000,
            pauseDuration: 3000,
            pauseOnHover: "immediate"
        },
        prev: ".next-video",
        next: ".prev-video"
    });

</script>

