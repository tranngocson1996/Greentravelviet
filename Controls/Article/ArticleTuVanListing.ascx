<%@ Control Language="C#" CodeFile="ArticleTuVanListing.ascx.cs" Inherits="Controls_Article_ArticleTuVanListing" %>
<%@ Import Namespace="BIC.Utils" %>
<%@ Register Src="~/Controls/Navigate/NavigatePath.ascx" TagPrefix="uc1" TagName="NavigatePath" %>
<%@ Register Src="~/Controls/Menu/MenuLeft2.ascx" TagPrefix="uc1" TagName="MenuLeft2" %>

<section class="page-content page-article-tuvan">
    <div class="container">
        <uc1:NavigatePath runat="server" ID="ucNavigatePath" VisibleHomePage="true" />
        <div class="row">
            <div class="col-lg-9 col-md-9 col-sm-8 col-xs-12 article-listing">
                <div class="box-title">
                    <h1>
                        <bic:MenuCaption ID="mnCap" runat="server" CssClass="text" /></h1>
                    <asp:Literal ID="ltrDesc" runat="server"></asp:Literal>
                </div>
                <div class="n-items">
                    <bic:ArticleListViewTopPager ID="ArticleList" runat="server" PageSize="6" ExtensionLink="HTML" SelectFields="ImageName,BriefDescription,CreatedDate " EnableAutoRedirect="True" Prefix="">
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
                                        <%# BicString.TrimText(BicString.StripHtml(Eval("BriefDescription").ToString()), 250) %>
                                        <p><a class="more-link" href="<%# Eval("Url") %>"><%= BicResource.GetValue("ReadMore") %></a></p>
                                    </div>
                                </div>
                            </article>
                        </ItemTemplate>
                    </bic:ArticleListViewTopPager>
                </div>
                <div class="divPage">
                    <bic:PagerUI ID="pager" PageSize="5" CssClass="paged" SelectedCssClass="current" Label='' runat="server" PagerUIStep="3" OnPageIndexChanged="pager_PageIndexChanged" />
                </div>
            </div>
            <aside id="sidebar" class="col-lg-3 col-md-3 col-sm-4 col-xs-12 sidebar">
              <div class="widget widget-menu">
                    <div class="box-title">
                        <h2 class="text">Thiết kế nội thất</h2>
                        <span class="toggle-btn icon-plus"></span>
                    </div>
                    <div class="menu-content mobile-collapse">
                        <uc1:MenuLeft2 runat="server" ID="ucMenuLeft2" MenuUserID="2" EnableGetByParentId="true" />
                    </div>
                </div>
            </aside>
        </div>
    </div>
</section>
<%= Include.StickSidebar() %>
<script type="text/javascript">
    jQuery("#sidebar").theiaStickySidebar({
        additionalMarginTop: 50
    });

    $(window).load(function () {
        $('.article-listing figure').each(function () {
            $(this).height($(this).width() / 1.5);
        });
        $(window).resize(function () {
            //Resize product image box
            $('.article-listing figure').each(function () {
                $(this).height($(this).width() / 1.5);
            });
        });
    });
</script>



