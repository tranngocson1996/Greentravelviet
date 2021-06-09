<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ArticleSidebar.ascx.cs" Inherits="Controls_Article_ArticleSidebar" %>
<%@ Import Namespace="BIC.Utils" %>

<div class="widget-title box-title">
    <h2>
        <span class="text"><%=BicLanguage.CurrentLanguage== "vi"? "Tin xem nhiều nhất": "News viewed" %></span>
    </h2>
</div>
<div class="n-items">
    <bic:ArticleListViewTop ID="ArticleList" runat="server">
        <ItemTemplate>
            <div class="n-item">
                <div class="item-box">
                    <figure>
                        <a href="<%# Eval("Url") %>" title="<%# Eval("Title").ToString().Replace("\"", "") %>" target="<%# BicConvert.ToString(Eval("Target")).Trim() %>">
                            <img src="<%# Page.ResolveUrl("~/" + BicImage.GetPathImageByName(Eval("ImageName").ToString(),true)) %>" alt="<%# Eval("Title").ToString().Replace("\"", "") %>" class="img-responsive" />
                        </a>
                    </figure>
                    <div class="n-title">
                        <a href="<%# Eval("Url") %>" title='<%# Eval("Title") %>' target='<%# BicConvert.ToString(Eval("Target")).Trim() %>'>
                            <%#BicString.TrimText(Eval("Title").ToString(),50) %>
                        </a>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </bic:ArticleListViewTop>
</div>


