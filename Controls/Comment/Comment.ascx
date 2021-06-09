<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Comment.ascx.cs" Inherits="Controls_Comment_Comment" %>
<%@ Import Namespace="BIC.Utils" %>
<%@ Register Src="CommentSend.ascx" TagName="CommentSend" TagPrefix="uc1" %>

<asp:Label ID="lblArticleId" runat="server" Text="" Visible="False"></asp:Label>
<asp:Label ID="lblTypeOfComment" runat="server" Text="" Visible="False"></asp:Label>
<asp:HiddenField runat="server" ID="hfParentID" Value="" />
<script src="/Controls/Comment/Comment.js"></script>
<link href="/Controls/Comment/Comment.css" rel="stylesheet" />

<div id="Commentary" class="wrapper ">
   <%-- <div class="menuCatBlock round5pxtop darkgray">
        <div class="menuCatList">
            <asp:LinkButton OnCommand="ViewAll" CssClass="allcomment" runat="server" ID="lbtnViewAll"></asp:LinkButton>
            <div class="cmt_header">
                <%=BicResource.GetValue("Comment") %>
            </div>
        </div>
    </div>--%>
    <div class="divcontent">
        <div class="cContent">
            <div class="cScroll scrollable">
                <div class="scrollbar right">
                    <div class="pointer">
                    </div>
                </div>
                <asp:ListView runat="server" ID="lvComment">
                    <LayoutTemplate>
                        <div class="scrollcontent">
                            <asp:PlaceHolder runat="server" ID="ItemPlaceHolder"></asp:PlaceHolder>
                        </div>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <div class="ccItem <%#Container.DataItemIndex % 2 == 0?"":"xam" %>">
                            <div class='ccAvatar <%# ((bool)Eval("GioiTinh"))?"male":"female" %> <%# Convert.ToString(Eval("Address")) != string.Empty?"member":"" %>'>
                            </div>
                            <div class="ccInfo">
                                <span class="ccName <%# Convert.ToString(Eval("Address")) != string.Empty?"member":"" %>">
                                    <%# Eval("Fullname") %> <i>(<%# BicDateTime.ToLongDateTime(Convert.ToDateTime(Eval("CreateDate"))) %>)</i></span>
                                <%--<div class="cagree">
                                    <a class="agree" value='<%# Eval("CommentId") %>'><i>(<%# Eval("DongY") %>)</i> Đồng
                                        ý</a>|<a class="disagree" value='<%# Eval("CommentId") %>'><i>(<%# Eval("KhongDongY") %>)</i>
                                            Không đồng ý</a>
                                    | <a class="comment" value="<%# Eval("CommentId") %>">Trả lời</a>
                                </div>--%>
                            </div>
                            <div class="ccComment">
                                <%--<i class="oq"></i>--%>
                                <%# Eval("Description") %>
                            </div>
                            <div class="cReply">
                                <div class='scrollable'>
                                    <div class="scrollbar">
                                        <div class="pointer">
                                        </div>
                                    </div>
                                    <div class="scrollcontent">
                                    </div>
                                </div>
                                <%--<div class="cSend">
                                    <uc1:CommentSend ID="CommentSend2" runat="server" TypeOfComment="2" ButtonLabel="Trả lời" ParentId='<%# Eval("CommentId") %>' RefId='<%# Eval("ID") %>' />
                                </div>--%>
                            </div>
                            <div class="break">
                            </div>
                        </div>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        <div class="scrollcontent" style="text-align: center;">
                            Chưa có bình luận nào cho bài viết này.
                        </div>
                    </EmptyDataTemplate>
                    <EmptyItemTemplate>
                        <div class="scrollcontent" style="text-align: center;">
                            Chưa có bình luận nào cho bài viết này.
                        </div>
                    </EmptyItemTemplate>
                </asp:ListView>

            </div>
            <div style="text-align: center; width: 645px">
                <bic:PagerUI runat="server" ID="pComment" PagerUIStep="15" PageSize="15"
                     OnPageIndexChanged="pager_PageIndexChanged"></bic:PagerUI>
            </div>
            <div class='cSend'>
                <h6>Bình luận của bạn:</h6>
                <uc1:CommentSend ID="CommentSend1" runat="server" ButtonLabel="Gửi bình luận" TypeOfComment="2" />
            </div>
        </div>
    </div>
</div>
