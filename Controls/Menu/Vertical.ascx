<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Vertical.ascx.cs" Inherits="Controls_Menu_Vertical" %>
<link href='<%=Page.ResolveUrl("~/BICSkins/Menu/Vertical/Vertical.css")%>' rel="stylesheet" type="text/css" /> 
<%=Include.Mmenu() %>
<script type="text/javascript">
    $(function () {
        $('nav#menu').mmenu({
            "offCanvas": {
                "position": "right",
                "zposition": "front"

            },
            onClick: {
                close: true
            }
        });
    })
</script>
<nav id="menu">
    <ul>
    <asp:ListView ID="menuParent" runat="server"  OnItemDataBound="MenuParentItemDataBound">
        <ItemTemplate>
            <li class='c1 <%#settt(Eval("menuUserID").ToString()) %>'>
                <a href='<%#_Getlink(Eval("URL").ToString(),Eval("UrlName").ToString()) %>' title='<%# Eval("Name") %>'>     
                  <%# Eval("Name") %>
                </a>
                <ul>
                    <bic:MenuListView runat="server" ID="menuChild" SelectFields="ParentId">
                        <ItemTemplate>
                            <li class=' c2 <%#settt(Eval("menuUserID").ToString()) %>'>
                               <a href='<%#_Getlink(Eval("URL").ToString(),Eval("UrlName").ToString()) %>' class="<%#getcap3(Eval("MenuUserID").ToString(),Eval("ParentId").ToString()) != ""?"licha2":"" %>" title='<%# Eval("Name") %>'><%# Eval("Name") %> </a>
                                 <%# getcap3(Eval("MenuUserID").ToString(),Eval("ParentId").ToString()) %>
                            </li>
                        </ItemTemplate>
                    </bic:MenuListView>
                </ul>
            </li>
        </ItemTemplate>
    </asp:ListView>
</ul>
</nav>


