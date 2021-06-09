<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ArticleTestimonial.ascx.cs" Inherits="Controls_Article_ArticleTestimonial" %>
<%@ Import Namespace="BIC.Utils" %>
<%= Include.OwlCarousel() %>
<div class="testimonial">
    <div class="caption-text">
        <h2><bic:MenuCaption runat="server" ID="mnCap" CssClass="text" /></h2>
    </div>
    <div class="n-items tes-items">
        <bic:ArticleListViewTop ID="ArticleList" runat="server">
            <ItemTemplate>
                <article class="n-item">
                    <figure>
                        <bic:Image ID="Image1" runat="server" LoadThumbnail="True" ImageName='<%# Eval("ImageName") %>' 
                            Link='<%# Eval("Url") %>' Target='<%# Eval("Target") %>' Alt='<%# Eval("Title") %>' />
                    </figure>
                    <div class="n-desc ">
                        <div class="n-title">
                            <h4><a href="<%# Eval("Url") %>" title='<%# Eval("Title") %>' target='<%# BicConvert.ToString(Eval("Target")).Trim() %>'>
                                <%# Eval("Title") %>
                            </a></h4>
                        </div>                        
                        <div class="description show">
                            <%# BicString.TrimText(Eval("BriefDescription").ToString(),160) %>
                        </div>
                    </div>
                </article>
            </ItemTemplate>
        </bic:ArticleListViewTop>
    </div>
</div>


