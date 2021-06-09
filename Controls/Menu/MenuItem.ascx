<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MenuItem.ascx.cs" Inherits="Controls_Menu_MenuItem" %>
<%@ Import Namespace="BIC.Utils" %>
<div class="<%=CssClass %>">
    <bic:MenuListView ID="menuParent" runat="server" SelectFields="ImageID,MenuUserID,Name,UrlName,URL,Description">
        <ItemTemplate>
            <div data-aos="fade-up" data-aos-duration="1000" data-aos-delay="<%# Container.DataItemIndex + 2 %>00" class="item <%# Container.DataItemIndex % 2 == 0 ? "left" : "right"%>">
                <figure>
                    <img src="<%# BicImage.GetPathImage(BicConvert.ToInt32(Eval("ImageID").ToString())) %>" alt="<%# Eval("Name") %>" />
                </figure>
                <h4><a class="text" href='<%#_Getlink(Eval("URL").ToString(),Eval("UrlName").ToString()) %>' title='<%# Eval("Name") %>'>
                    <%#Eval("Name") %>
                </a></h4>
                <div class="desc">
                    <%#BicString.TrimText(Eval("Description").ToString(), 250) %>
                </div>
                <a href="<%#_Getlink(Eval("URL").ToString(),Eval("UrlName").ToString()) %>" class="btn-readmore"><%=BicResource.GetValue("Readmore") %></a>
            </div>
        </ItemTemplate>
    </bic:MenuListView>
</div>
