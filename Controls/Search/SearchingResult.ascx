<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SearchingResult.ascx.cs" Inherits="Controls_Search_SearchingResult" %>
<%@ Import Namespace="BIC.Utils" %>

<%=Include.Search()%>
<div class="cttin">
    <div class="caption-search">
        <span><%=BicLanguage.CurrentLanguage=="vi"?"Kết quả tìm kiếm:":"Search Results:" %></span><%=BicLanguage.CurrentLanguage=="vi"?"Tìm được":"finding" %> <b>
            <%=Result%>
       <%=BicLanguage.CurrentLanguage == "vi"?"kết quả":"outcome" %></b> <%=BicLanguage.CurrentLanguage == "vi"?"với từ khóa":"with keywords" %> <b>"<%=Keyword%>"</b>
    </div>
    <div class="searchlist">
        <bic:ProductListViewTopPager runat="server" ExtensionLink="HTML" ID="searching" OnItemDataBound="searchingArticle_ItemDataBound" PageSize="10" SelectFields="BriefDescription,MainMenuUserID,ImageName">
            <ItemTemplate>
                <div class='item <%# ((Container.DataItemIndex +1) == 1) ? "first" : "" %>'>
                    <div class="title">
                        <a href="<%#Eval("Url")%>" target='<%#Eval("Target")%>'>
                            <%#BicString.HighlightKeyWords(Convert.ToString(Eval("Title")), Keyword, "highlight", string.Empty)%></a>
                        <%#Eval("NewsIcon")%>
                    </div>
                     <div class="avatar">
                            <div class="avatar-box">
                                 <bic:Image CssClass="aliimg" ID="Image1" runat="server"  ImageName='<%# Eval("ImageName") %>' WidthOfImage="150" HeightOfImage="150"
                                Link='<%# Eval("Url") %>' Target='<%# Eval("Target") %>' Alt='<%# Eval("Title") %>' />
                            </div>
                    </div>
                    <div class="desciption">
                        <%#BicString.HighlightKeyWords(BicString.TrimText(Convert.ToString(Eval("BriefDescription")),230), Keyword, "highlight", string.Empty)%>
                    </div>

                    <div class="order">
                        <%=BicLanguage.CurrentLanguage == "vi"?"Danh mục":"Category" %>: <b>
                            <asp:HyperLink ID="mnuSearch" runat="server"></asp:HyperLink>
                        </b><a href='<%#Eval("Url")%>' target='<%#Eval("Target")%>'> <%=BicLanguage.CurrentLanguage == "vi"?"Chi tiết":"Details" %></a>
                    </div>
                </div>
            </ItemTemplate>
        </bic:ProductListViewTopPager>
        <div class="page-navi clear fl">
            <bic:PagerUI ID="pager" CssClass="pager" Label='' runat="server" PagerUIStep="10" OnPageIndexChanged="pager_PageIndexChanged" />
        </div>
    </div>
</div>
