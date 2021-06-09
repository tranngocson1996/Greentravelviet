<%@ Control Language="C#" CodeFile="ArticleKhachHang.ascx.cs" Inherits="Controls_Article_ArticleKhachHang" %>
<%@ Import Namespace="BIC.Utils" %>
<%@ Register Src="~/Controls/Navigate/NavigatePath.ascx" TagPrefix="uc1" TagName="NavigatePath" %>
<%@ Register Src="~/Controls/Sidebar/SideBarArticle.ascx" TagPrefix="uc1" TagName="SideBarArticle" %>


<bic:ArticleListViewTopPager ID="ArticleList" runat="server" PageSize="5" ExtensionLink="HTML" SelectFields="ImageName,BriefDescription,CreatedDate,Body " EnableAutoRedirect="True" Prefix="">
    <ItemTemplate>
        <article>
            <div class="item">
                <div class="image">
                    <img src="<%# Page.ResolveUrl("~/" + BicImage.GetPathImageByName(Eval("ImageName").ToString(),false)) %>" alt="<%# Eval("Title").ToString().Replace("\"", "") %>" class="img-editor" />
                </div>
                <div class="content">
                    <div class="text-comment">
                        <%# Eval("Body")%>
                    </div>
                    <div class="text-name">
                        <%# Eval("Title")%>
                    </div>
                    <div class="text-job">
                        <%# Eval("BriefDescription")%>
                    </div>
                </div>
            </div>
        </article>
    </ItemTemplate>
</bic:ArticleListViewTopPager>




