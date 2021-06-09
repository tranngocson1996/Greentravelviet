<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ArticleReference.ascx.cs" Inherits="Controls_Article_ArticleReference" %>
<%@ Import Namespace="BIC.Utils" %>

<div class="widget-title related-title">
    <h2>
        <span class="text"><%= BicResource.GetValue("RelatedArticle") %></span>
    </h2>
</div>
<div class="related-content">
    <bic:ArticleListViewRef runat="server" ID="lvReference" SelectFields="ImageName,BriefDescription,CreatedDate,Target" ExtensionLink="HTML">
        <ItemTemplate>
            <article class="n-item">
                <div class="item-box">
                    <figure>
                        <a href="<%# Eval("Url") %>" title="<%# Eval("Title").ToString().Replace("\"", "") %>" target="<%# BicConvert.ToString(Eval("Target")).Trim() %>">
                            <img src="<%# Page.ResolveUrl("~/" + BicImage.GetPathImageByName(Eval("ImageName").ToString(),true)) %>" alt="<%# Eval("Title").ToString().Replace("\"", "") %>" class="img-responsive" />
                        </a>
                    </figure>
                    <div class="n-title">
                        <a href="<%# Eval("Url") %>" title='<%# Eval("Title").ToString().Replace("\"", "") %>' class='title' target='<%# BicConvert.ToString(Eval("Target")).Trim() %>'>
                            <h3><%# Eval("Title")%></h3>
                        </a>
                    </div>
                    <div class="n-desc">
                        <%# BicString.TrimText(BicString.StripHtml(Eval("BriefDescription").ToString()),100)%>
                        <p><a class="more-link" href="<%# Eval("Url") %>"><%= BicResource.GetValue("ReadMore") %></a></p>
                    </div>
                    <span class="date-notification"><%#CovertDate((Eval("CreatedDate").ToString()))%>                 
                    </span>
                </div>
            </article>
        </ItemTemplate>
    </bic:ArticleListViewRef>
</div>
