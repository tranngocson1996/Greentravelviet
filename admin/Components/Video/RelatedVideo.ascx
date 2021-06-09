<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RelatedVideo.ascx.cs" Inherits="admin_Components_Article_RelatedArticle" %>
<%@ Import Namespace="BIC.Utils" %>
<div class="selected-list">
    <div style="font-weight: bold;">
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="Unnamed_Click1" Font-Underline="true"><%=BicResource.GetValue("Admin","Admin_Article_SelectRelevantInformationFromTheMatch") %></asp:LinkButton>
    </div>
    <asp:ListView runat="server" ID="lvArticle">
        <LayoutTemplate>
            <ul style="list-style: inside disc!important;">
                <asp:PlaceHolder runat="server" ID="ItemPlaceHolder"></asp:PlaceHolder>
            </ul>
        </LayoutTemplate>
        <ItemTemplate>
            <li style="list-style: inside disc!important;">
                <%# Eval("Title") %>
                <asp:LinkButton runat="server" ID="articleRemove" OnCommand="articleRemove_Command" CommandName='<%# Container.DataItemIndex %>' CommandArgument='<%# Eval("ArticleId") %>' Title="<%$Resources:Admin,Admin_Article_RemovingNews%>" Font-Underline="true" ForeColor="Red"><img src='<%= Page.ResolveUrl("~/admin/Styles/icon/ContextMenu/delete.gif") %>' /></asp:LinkButton>
            </li>
        </ItemTemplate>
        <EmptyItemTemplate>

            <%=BicResource.GetValue("Admin","Admin_Article_Noposts") %>
        </EmptyItemTemplate>
        <EmptyDataTemplate>
            <%=BicResource.GetValue("Admin","Admin_Article_Noposts") %>
        </EmptyDataTemplate>
    </asp:ListView>
</div>
<telerik:RadAjaxPanel runat="server" ID="radAjax">
    <asp:Panel runat="server" ID="listSelect" Style="display: block; height: auto; left: 326px; outline: 0px none; top: 549px; width: 690px; z-index: 1002;" class="ui-dialog ui-widget ui-widget-content ui-corner-all ui-draggable fixed" TabIndex="-1" role="dialog" aria-labelledby="ui-dialog-title-04644c8b64f80a81375df2e2d1" Visible="false">
        <div class="ui-dialog-titlebar ui-widget-header ui-corner-all ui-helper-clearfix">
            <span class="ui-dialog-title" id="Span1"><%=BicResource.GetValue("Admin","Admin_Article_RelatedNewsList") %></span><asp:LinkButton ID="LinkButton2" runat="server" OnClick="Unnamed_Click" class="ui-dialog-titlebar-close ui-corner-all" role="button"><span class="ui-icon ui-icon-closethick"><%=BicResource.GetValue("Admin","Admin_Article_close") %></span></asp:LinkButton>
        </div>
        <div id="Div1" style="border: 0pt none; bottom: 0pt; display: block; left: 0pt; margin: 0pt; min-height: 0px; overflow: hidden; padding: 0pt; right: 0pt; top: 0pt; width: auto;" class="ui-dialog-content ui-widget-content" scrolltop="0" scrollleft="0">
            <div>
                <div style="background: url(<%= Page.ResolveUrl("~/BICSkins/BICCMS/Grid/grid_header_1x35.png") %>) repeat-x scroll 0 0 #FFFFFF; height: 35px; padding: 0 20px;">
                    <span style="background: url(<%= Page.ResolveUrl("~/admin/Styles/icon/label_search_85x35.gif") %>); display: block; float: left; height: 35px; width: 85px"></span>
                    <asp:TextBox runat="server" ID="txtFilter" Width="300" Style='border: 1px solid #ddd; border-right: none; float: left; height: 16px; margin-top: 7px; padding: 2px 5px;'></asp:TextBox>
                    <%--<span style="background: url(<%= Page.ResolveUrl("~/admin/Styles/icon/btn_search_40x20.gif") %>); border: 1px solid #ddd; border-left: none; cursor: pointer; display: block; float: left; height: 20px; margin-top: 7px; width: 40px;"></span>--%>
                    <asp:Button ID="BtSearch" runat="server" Text="" OnClick="BtSearchClick" CssClass="btnSearchRelated" />
                </div>
                <bic:ArticleListViewTopPager runat="server" ID="lvRelatedArticle" ShowTodayCss="True" SelectFields="CreatedDate" PageSize="10" OnItemDataBound="lvRelatedArticle_OnItemDataBound">
                    <LayoutTemplate>
                        <div style="display: inline-block; font-family: arial; width: 100%;">
                            <div class="header" style="background: #FDF7CF; border-bottom: 1px solid #fff; height: 5px;">
                                <%-- <div style="border-left: 1px solid #fff; float: left; height: 36px; width: 26px;">
                            </div>
                            <div style="border-left: 1px solid #fff; color: #2f5d78; float: left; font-size: 12px; font-weight: bold; height: 36px; line-height: 36px; padding-left: 8px;">
                                <%=BicResource.GetValue("Admin","Admin_Article_NewsTitle") %>
                            </div>--%>
                            </div>
                            <asp:PlaceHolder runat="server" ID="GroupPlaceHolder"></asp:PlaceHolder>
                        </div>
                    </LayoutTemplate>
                    <GroupTemplate>
                        <div style="float: left; width: 100%;">
                            <asp:PlaceHolder runat="server" ID="ItemPlaceHolder"></asp:PlaceHolder>
                        </div>
                    </GroupTemplate>
                    <ItemTemplate>
                        <div style="background: #DDEBF1; border-left: 1px solid #fff; clear: both; height: 32px; line-height: 32px;">
                            <div style="border-left: 1px solid #fff; float: left; height: 25px; padding-bottom: 1px; padding-top: 5px; text-align: center; width: 25px;">
                                <asp:CheckBox runat="server" Value='<%# Eval("ArticleId") %>' Title='<%# Eval("Title") %>' ID="chkRelated" AutoPostBack="True" OnCheckedChanged="chkRelated_OnCheckedChanged" />
                            </div>
                            <div style="border-left: 1px solid #fff; color: #2f5d78; float: left; font-size: 12px; height: 32px; line-height: 32px; padding-left: 8px;">
                                <%# Eval("Title") + Eval("CreatedDate", "{0: (dd/MM)}") %>
                            </div>
                        </div>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <div style="background: #fff; border-left: 1px solid #fff; clear: both; height: 32px; line-height: 32px;">
                            <div style="border-left: 1px solid #fff; float: left; height: 25px; padding-bottom: 1px; padding-top: 5px; text-align: center; width: 25px;">
                                <asp:CheckBox runat="server" Value='<%# Eval("ArticleId") %>' Title='<%# Eval("Title") %>' ID="chkRelated" AutoPostBack="True" OnCheckedChanged="chkRelated_OnCheckedChanged" />
                            </div>
                            <div style="border-left: 1px solid #DDEBF1; color: #2f5d78; float: left; font-size: 12px; height: 32px; line-height: 32px; padding-left: 8px;">
                                <%# Eval("Title") + Eval("CreatedDate", "{0: (dd/MM)}") %>
                            </div>
                        </div>
                    </AlternatingItemTemplate>
                </bic:ArticleListViewTopPager>
                <div style="background: #9EC4D4; padding: 2px 5px; text-align: left;">
                    <bic:PagerUI runat="server" ID="pRelatedArticle" PagerUIStep="10" Label="Trang: " PageSize="10" OnPageIndexChanged="pRelatedArticle_OnPageIndexChanged" />
                </div>
            </div>
            <div style="border: 0pt none; bottom: 0pt; display: none; height: 100%; left: 0pt; margin: 0pt; padding: 0pt; position: absolute; right: 0pt; top: 0pt; width: 100%;">
                &nbsp;
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="overlay" runat="server" class="ui-widget-overlay" Style="height: 100%; left: 0; position: fixed; top: 0; width: 100%; z-index: 1001;" Visible="false">
    </asp:Panel>

</telerik:RadAjaxPanel>

<style type="text/css">
    .btnSearchRelated {
        background: url("/admin/Styles/icon/btn_search_40x20.gif");
        border: 1px solid #ddd;
        border-left: none;
        cursor: pointer;
        display: block;
        float: left;
        height: 20px;
        margin-top: 8px;
        margin-left: 10px;
        width: 40px;
    }
</style>
