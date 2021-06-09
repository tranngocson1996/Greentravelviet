<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ArticleHot.ascx.cs" Inherits="Controls_Article_ArticleHot" %>
<%@ Import Namespace="BIC.Utils" %>
<div class="box-title">
    <h2>
        <bic:MenuCaption runat="server" ID="mnCap" CssClass="text" /></h2>
</div>
<div class="n-items owl-carousel">
    <bic:ArticleListViewTop ID="ArticleList" runat="server">
        <ItemTemplate>
            <div class="article-item">
                <div class="item-box">
                    <figure>
                        <a href="<%# Eval("Url") %>" title="<%# Eval("Title").ToString().Replace("\"", "") %>" target="<%# BicConvert.ToString(Eval("Target")).Trim() %>">
                            <img src="<%# Page.ResolveUrl("~/" + BicImage.GetPathImageByName(Eval("ImageName").ToString(),true)) %>" alt="<%# Eval("Title").ToString().Replace("\"", "") %>" class="img-responsive" />
                        </a>
                    </figure>
                    <div class="article-title">
                        <a href="<%# Eval("Url") %>" title='<%# Eval("Title").ToString().Replace("\"", "") %>' class='title' target='<%# BicConvert.ToString(Eval("Target")).Trim() %>'>
                            <h3><%# Eval("Title")%></h3>
                        </a>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </bic:ArticleListViewTop>
</div>

