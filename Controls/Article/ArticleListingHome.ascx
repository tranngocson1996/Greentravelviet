<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ArticleListingHome.ascx.cs" Inherits="Controls_Article_ArticleListingHome" %>
<%@ Import Namespace="BIC.Utils" %>
<%=Include.OwlCarousel() %>
<section class="article-home">
    <div class="container">
        <div class="article-slider-home">         
            <div class="caption-tour new-event-title">
                <h2>
                    <span class="text detail-caption"><%= BicResource.GetValue("ServiceArticle") %></span>
                </h2>
            </div>
            <div class="new-event-content owl-carousel">
               <bic:ArticleListViewTop runat="server" ID="ArticleList" SelectFields="ImageName,BriefDescription,CreatedDate,Target" ExtensionLink="HTML">
                    <ItemTemplate>
                        <article class="n-item">
                            <div class="item-box">
                                <figure>
                                    <a href="<%# Eval("Url") %>" title="<%# Eval("Title").ToString().Replace("\"", "") %>" target="<%# BicConvert.ToString(Eval("Target")).Trim() %>">
                                        <img src="<%# Page.ResolveUrl("~/" + BicImage.GetPathImageByName(Eval("ImageName").ToString(),false)) %>" alt="<%# Eval("Title").ToString().Replace("\"", "") %>" class="img-responsive" />
                                    </a>
                                </figure>
                                <div class="n-title">
                                    <a href="<%# Eval("Url") %>" title='<%# Eval("Title").ToString().Replace("\"", "") %>' class='title' target='<%# BicConvert.ToString(Eval("Target")).Trim() %>'>
                                        <h3><%# Eval("Title")%></h3>
                                    </a>
                                </div>
                                <div class="n-desc">
                                    <%# BicString.TrimText(BicString.StripHtml(Eval("BriefDescription").ToString()),100)%>
                                </div>
                            </div>
                        </article>
                    </ItemTemplate>
                </bic:ArticleListViewTop>
            </div>
        </div>
    </div>
</section>


