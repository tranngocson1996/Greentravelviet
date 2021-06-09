<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ArticleDetail.ascx.cs" Inherits="Controls_Article_ArticleDetail" %>
<%@ Import Namespace="BIC.Utils" %>
<%@ Register Src="ArticleReference.ascx" TagName="ArticleReference" TagPrefix="uc3" %>
<%@ Register Src="~/Controls/Social/Like.ascx" TagPrefix="uc3" TagName="Like" %>
<%@ Register Src="~/Controls/Navigate/NavigatePath.ascx" TagPrefix="uc1" TagName="NavigatePath" %>
<%@ Register Src="~/Controls/Sidebar/SideBarArticle.ascx" TagPrefix="uc1" TagName="SideBarArticle" %>
<%@ Register Src="~/Controls/Social/CommentFacebook.ascx" TagPrefix="uc1" TagName="CommentFacebook" %>





<div class="navigate-title">
    <div class="container">
        <div class="box-title">
            <h1>
                <bic:MenuCaption ID="mnCap" runat="server" CssClass="text" /></h1>
            <asp:Literal ID="ltrDesc" runat="server"></asp:Literal>
        </div>
        <uc1:NavigatePath runat="server" ID="ucNavigatePath" VisibleHomePage="true" />
    </div>
</div>
<section class="page-content page-article">
    <div class="container">
        <div class="row">
            <article class="col-lg-9 col-md-9 col-sm-8 col-xs-12 article-detail">
                <div class="n-title">
                    <h1>
                        <asp:Label runat="server" ID="ltlTitle" CssClass="title-article"></asp:Label></h1>
                </div>
                <div class="date">
                    <span><%= BicResource.GetValue("DateCreate")%>
                        <asp:Literal runat="server" ID="ltrDate"></asp:Literal></span> <span><%= BicResource.GetValue("ViewCount")%>
                            <asp:Literal runat="server" ID="ltrview"></asp:Literal></span>
                </div>
                <div class="n-desc">
                    <asp:Literal runat="server" ID="ltlDescription"></asp:Literal>
                </div>
                <div class="meta">
                    <div class="share">
                        <uc3:Like runat="server" ID="Like" />

                    </div>
                    <div class="comment-facebook">
                        <uc1:CommentFacebook runat="server" ID="ucCommentFacebook" />
                    </div>
                </div>
                <div class="related-article hidden">
                    <uc3:ArticleReference ID="articleReference" runat="server" />
                </div>
            </article>
            <uc1:SideBarArticle runat="server" ID="SideBarArticle" />
        </div>
    </div>
</section>
<%= Include.StickSidebar() %>
<script type="text/javascript">
    jQuery("#sidebar").theiaStickySidebar({
        additionalMarginTop: 50
    });
</script>
