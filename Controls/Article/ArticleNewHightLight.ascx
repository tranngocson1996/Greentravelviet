<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ArticleNewHightLight.ascx.cs" Inherits="Controls_Article_ArticleNewHightLight" %>
<%@ Import Namespace="BIC.Utils" %>
<%=Include.OwlCarousel() %>
<div class="new-hightlight owl-carousel">
    <bic:ArticleListViewTop runat="server" ID="ArticleList" SelectFields="ImageName,BriefDescription,CreatedDate,Target" ExtensionLink="HTML">
        <ItemTemplate>
            <article class="n-item">
                <div class="item-box">
                    <div class="n-title">
                        <a href="<%# Eval("Url") %>" title='<%# Eval("Title").ToString().Replace("\"", "") %>' class='title' target='<%# BicConvert.ToString(Eval("Target")).Trim() %>'>
                            <h3><%#BicString.TrimText(Eval("Title").ToString(),50)%></h3>
                        </a>
                    </div>
                </div>
            </article>
        </ItemTemplate>
    </bic:ArticleListViewTop>
</div>



