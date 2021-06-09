<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ArticleOffer.ascx.cs" Inherits="Controls_Article_ArticleOffer" %>
<%@ Import Namespace="BIC.Utils" %>
<div data-aos="fade-up" data-aos-duration="1000" data-aos-delay="600" class="offer">
    <div class="text-title">
        <h2>
            <bic:MenuCaption runat="server" ID="mnCap" /></h2>
    </div>
    <div class="n-items">
        <bic:ArticleListViewTop ID="ArticleList" runat="server">
            <ItemTemplate>
                <article class="n-item">
                    <figure>
                        <bic:Image ID="Image1" runat="server" LoadThumbnail="True" ImageName='<%# Eval("ImageName") %>'
                            Link='<%# Eval("Url") %>' Target='<%# Eval("Target") %>' Alt='<%# Eval("Title") %>' />
                    </figure>
                    <div class="n-desc">
                        <div class="n-title">
                            <h4><a href="<%# Eval("Url") %>" title='<%# Eval("Title") %>' target='<%# BicConvert.ToString(Eval("Target")).Trim() %>'>
                                <%# Eval("Title") %>
                            </a></h4>
                        </div>
                    </div>
                </article>
            </ItemTemplate>
        </bic:ArticleListViewTop>
    </div>
</div>


