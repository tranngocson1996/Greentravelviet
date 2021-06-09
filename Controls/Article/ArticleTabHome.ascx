<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ArticleTabHome.ascx.cs" Inherits="Controls_Article_ArticleTabHome" %>
<%@ Import Namespace="BIC.Utils" %>


<div class="module-article">
    <div class="container">
        <div class="panel-product panel-article">
            <!-- Nav tabs -->
            <div class="fw tab-heading panel-heading">
                <div class="box-title">
                    <h2>
                        <bic:MenuCaption runat="server" ID="mnCap" CssClass="text" /></h2>
                </div>
                <bic:MenuListView ID="menuTab" runat="server" SelectFields="ParentId">
                    <LayoutTemplate>
                        <ul class="nav" role="tablist">
                            <asp:PlaceHolder runat="server" ID="ItemPlaceHolder"></asp:PlaceHolder>
                        </ul>
                        <a class="read-more" href="javascript:void(0)">Xem thêm >></a>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <li class="<%# Container.DataItemIndex == 0 ? "active" : "" %>" role="presentation">
                            <a href="#<%# Eval("UrlName") %>" data-link="<%# Eval("URL") %>" aria-controls="<%# Eval("UrlName") %>" role="tab" data-toggle="tab"><%# Eval("Name") %></a>
                        </li>
                    </ItemTemplate>
                </bic:MenuListView>
            </div>
            <!-- Tab panes -->
            <bic:MenuListView ID="menuTabContent" runat="server" SelectFields="ParentId, UrlName" OnItemDataBound="menuTabContent_ItemDataBound">
                <LayoutTemplate>
                    <div class="tab-content">
                        <asp:PlaceHolder runat="server" ID="ItemPlaceHolder"></asp:PlaceHolder>
                    </div>
                </LayoutTemplate>
                <ItemTemplate>
                    <div role="tabpanel" class="products-slide tab-pane fade<%# Container.DataItemIndex == 0 ? " in active" : "" %>" id="<%# Eval("UrlName") %>">
                        <div class="p-items">
                            <bic:ArticleListViewTop runat="server" ID="lvArticleTab" EnableAutoRedirect="False" ExtensionLink="HTML" SelectFields="ImageName,BriefDescription,CreatedDate ">
                                <ItemTemplate>
                                    <div class="col-lg-3 col-md-3 col-sm-4 col-xs-6 p-item">
                                        <div class="item-box">
                                            <figure>
                                                <a href="<%# Eval("Url") %>" title="<%# Eval("Title").ToString().Replace("\"", "") %>" target="<%# BicConvert.ToString(Eval("Target")).Trim() %>">
                                                    <img src="<%# Page.ResolveUrl("~/" + BicImage.GetPathImageByName(Eval("ImageName").ToString(),true)) %>" alt="<%# Eval("Title").ToString().Replace("\"", "") %>" class="img-responsive" />
                                                </a>
                                            </figure>
                                            <div class="p-title">
                                                <a href="<%# Eval("Url") %>" title='<%# Eval("Title").ToString().Replace("\"", "") %>' class='title' target='<%# BicConvert.ToString(Eval("Target")).Trim() %>'>
                                                    <h3><%# Eval("Title")%></h3>
                                                </a>
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </bic:ArticleListViewTop>
                        </div>
                    </div>
                </ItemTemplate>
            </bic:MenuListView>
        </div>
    </div>
</div>
