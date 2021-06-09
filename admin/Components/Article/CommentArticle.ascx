<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CommentArticle.ascx.cs" Inherits="admin_Components_Article_CommentArticle" %>
<%@ Import Namespace="BIC.Utils" %>
<asp:ListView runat="server" ID="lvRelatedArticle" OnItemCommand="lvRelatedArticle_ItemCommand" DataKeyNames="CommentID">

    <ItemTemplate>
        <div style="background: #DDEBF1; border-left: 1px solid #fff; clear: both; height: 32px; line-height: 32px; width:740px">
            <div title="<%# Eval("Description") %>" style="border-left: 1px solid #fff; color: #2f5d78; float: left; font-size: 12px; height: 32px; line-height: 32px; padding-left: 8px; padding-right: 8px; width: 670px; overflow: hidden">
                <%# Eval("Description") %>
            </div>
            <div style="border-left: 1px solid #fff; color: #2f5d78; float: left; font-size: 12px; height: 32px; line-height: 32px; padding-top:9px; text-align:center; width: 50px;">
                <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("CommentID") %>' />
                <asp:ImageButton ID="ibtnIsActive" BorderWidth="0px" CommandName="IsActive" CommandArgument='<%# Eval("IsActive") %>' ImageUrl='<%# Convert.ToBoolean(DataBinder.Eval(Container.DataItem, "IsActive")) ? "~/Admin/Styles/Icon/checkmark.gif" : "~/Admin/Styles/Icon/uncheckmark.gif" %>' Style="cursor: pointer;" runat="server"></asp:ImageButton>
            </div>
        </div>
    </ItemTemplate>
    <%--<AlternatingItemTemplate>
        <div style="background: #fff; border-left: 1px solid #fff; clear: both; height: 32px; line-height: 32px;">
            <div title='<%# Eval("Description") %>' style="border-left: 1px solid #DDEBF1; color: #2f5d78; float: left; font-size: 12px; height: 32px; line-height: 32px; padding-left: 8px; padding-right: 8px; width: 500px; overflow: hidden">
                <%# Eval("Description") %>
            </div>
            <div style="border-left: 1px solid #fff; color: #2f5d78; float: left; font-size: 12px; height: 32px; line-height: 32px; padding-left: 17px; padding-right: 8px;">
                <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("CommentID") %>' />
                <asp:ImageButton ID="ibtnIsActive" BorderWidth="0px" CommandName="IsActive" CommandArgument='<%# Eval("IsActive") %>' ImageUrl='<%# Convert.ToBoolean(DataBinder.Eval(Container.DataItem, "IsActive")) ? "~/Admin/Styles/Icon/checkmark.gif" : "~/Admin/Styles/Icon/uncheckmark.gif" %>' Style="cursor: pointer;" runat="server"></asp:ImageButton>
            </div>
        </div>
    </AlternatingItemTemplate>--%>
    <EmptyDataTemplate>
        <div style="padding: 10px 0; text-align: center;">
        <%=BicResource.GetValue("Admin","System_NoComment") %>   
        </div>
    </EmptyDataTemplate>

</asp:ListView>
<div style="background: #9EC4D4; text-align: left; width:740px">
    <bic:PagerUI runat="server" ID="pRelatedArticle" PagerUIStep="10" Label="<%$Resources:Admin,Admin_Article_Page%> " PageSize="10" />
</div>
