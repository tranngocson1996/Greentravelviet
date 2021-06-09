<%@ Control Language="C#" AutoEventWireup="true" CodeFile="VideoManager.ascx.cs" Inherits="admin_Components_Video_VideoManager" %>
<%@ Import Namespace="BIC.Utils" %>
<telerik:RadCodeBlock runat="server">
    <%= IncludeAdmin.DefaultCss() %>
    <%= IncludeAdmin.JqueryUI() %>
    <%= IncludeAdmin.AdminVideoManager() %>
    <%= IncludeAdmin.JsVideoGallery() %>
</telerik:RadCodeBlock>
<telerik:RadScriptManager runat="server">
</telerik:RadScriptManager>
<telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
    <input id="hdImg" type="hidden" value="0" />
    <div class="body_view">
        <div class="gallery_caption">
            <div class="cate_gallery">
                <telerik:RadCodeBlock ID="RadCodeBlock4" runat="server">
                    <%=BicResource.GetValue("Admin","Admin_Video_Videothuocdanhmuc") %>
                </telerik:RadCodeBlock>
                <bic:MenuRecursion ID="ddlVideoCategoryID" CssClass="input-select" OnSelectedIndexChanged="ddlVideoCategoryID_SelectedIndexChanged" TypeOfControl="video" runat="server" />
            </div>
            <div class="img_name_gallery">
                <asp:TextBox runat="server" ID="txtName" CssClass="input-text" AutoPostBack="True" OnTextChanged="txtName_TextChanged" />
            </div>
            <div class="search_button_gallery">
                <asp:LinkButton runat="server" ID="btnSearch" OnClick="btnSearch_Click"></asp:LinkButton>
            </div>
            <div class="separator">
            </div>
        </div>
        <div class="galery_note">

            <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
                <%=BicResource.GetValue("Admin","Admin_Video_Huongdanclickdupdechenvideo") %>
            </telerik:RadCodeBlock>
        </div>
        <div class="text_result">
            <asp:Label runat="server" ID="lblMessage" Text=""></asp:Label>
        </div>
        <div class="frame_gallery" id="frame_video">
            <asp:ListView ID="dlImage" runat="server" RepeatColumns="5" OnItemDataBound="dlImage_ItemDataBound">
                <ItemTemplate>
                    <div class='<%# (Container.DataItemIndex + 1)%5 != 0 ? "img_detail" : "img_detail img_right" %>' title='<%# Eval("Name") %>'>
                        <div class="size">
                            <%#BicString.TrimText(Eval("Name"),10) %>
                        </div>
                        <div class="image">
                            <img id="htmlImage" clientidmode="Static" class='<%#Eval("VideoID")%>' style="cursor: pointer" src="" alt="" runat="server" />
                        </div>
                        <div class="action">
                            <asp:LinkButton runat="server" ID="lbtnEdit" OnCommand="Action" CommandName="Edit" CommandArgument='<%#Eval("VideoID")%>'>Edit</asp:LinkButton>&nbsp;|
                            <asp:LinkButton runat="server" ID="lbtnDelete" OnCommand="Action" OnClientClick="return confirm('Bạn chắc chắn muốn xóa video?')" CommandName="Delete" CommandArgument='<%#Eval("VideoID")%>'>Delete</asp:LinkButton>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
        <div class="paging">
            <bic:PagerUI ID="Pager1" runat="server" CssClass="pagerImg" PageSize="10" OnPageIndexChanged="Pager1_PageIndexChanged" Next=">>" Previous="<<" />
        </div>
    </div>
</telerik:RadAjaxPanel>
<telerik:RadAjaxLoadingPanel runat="server" Skin="Windows7" ID="RadAjaxLoadingPanel1" BackgroundPosition="Center" EnableSkinTransparency="true">
</telerik:RadAjaxLoadingPanel>
