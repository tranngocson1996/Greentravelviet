<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditionFrameView.ascx.cs" Inherits="Admin_Components_FrameView_EditionFrameView" %>
<%@ Import Namespace="BIC.Utils" %>
<div class="form-tool">
    <bic:ToolBar ID="tbTop" runat="server" />
    <asp:LinkButton ID="lbtnSave" CssClass="btn-save" runat="server" OnCommand="Save" CommandName="Update"><%=BicResource.GetValue("Admin","Admin_FrameView_Save") %></asp:LinkButton>
</div>
<div class="form-caption">
    <%= BicMessage.EditTitle %>
    <span class="note"><em>*</em>
        <%= BicMessage.RequireTitle %>
    </span>
</div>
<div class="form-view">
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <%=BicResource.GetValue("Admin","Admin_FrameView_FunctionName") %><span class="validate">*</span>
            </div>
            <div class="input">
                <asp:TextBox ID="txtName" CssClass="input-text" Width="97%" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <%=BicResource.GetValue("Admin","Admin_FrameView_Law") %>
            </div>
            <div class="input">
                <asp:TextBox ID="txtURLControl" CssClass="input-text" Width="300px" runat="server" />
                <%=BicResource.GetValue("Admin","Admin_FrameView_Oder") %>: {1}: MenuID, {2}:ParentID, {3}:Name, {4}:LanguageKey
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <%=BicResource.GetValue("Admin","Admin_FrameView_GroupName") %>
            </div>
            <div class="input">
                <asp:TextBox ID="txtGroupName" CssClass="input-text" Width="300px" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <%=BicResource.GetValue("Admin","Admin_FrameView_ResourceKey") %>
            </div>
            <div class="input">
                <asp:TextBox ID="txtResourceKey" CssClass="input-text" Width="300px" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <%=BicResource.GetValue("Admin","Admin_FrameView_StyleFunction") %>
            </div>
            <div class="input">
                <asp:DropDownList ID="ddlTypeOfControl" CssClass="input-select" Width="" runat="server">
                    <asp:ListItem Value="news" Text="<%$Resources:Admin, Admin_FrameView_News%>"></asp:ListItem>
                    <asp:ListItem Value="products" Text="<%$Resources:Admin, Admin_FrameView_Product%>"></asp:ListItem>
                    <asp:ListItem Value="docs" Text="<%$Resources:Admin, Admin_FrameView_Document%>"></asp:ListItem>
                    <asp:ListItem Value="faq" Text="<%$Resources:Admin, Admin_FrameView_Faq%>"></asp:ListItem>
                    <asp:ListItem Value="video" Text="<%$Resources:Admin, Admin_FrameView_Video%>"></asp:ListItem>
                    <asp:ListItem Value="gallery" Text="<%$Resources:Admin, Admin_FrameView_GalleryListing%>"></asp:ListItem>
                    <asp:ListItem Value="room" Text="<%$Resources:Admin,Admin_FrameView_Room%>"></asp:ListItem>
                    <asp:ListItem Value="tours" Text="<%$Resources:Admin,Admin_FrameView_Tour%>"></asp:ListItem>
                    <asp:ListItem Value="home" Text="Trang chủ"></asp:ListItem>
                    <asp:ListItem Value="contact" Text="Trang liên hệ"></asp:ListItem>
                    <asp:ListItem Value="des" Text="Điểm đến"></asp:ListItem>
                    <asp:ListItem Value="Other" Text="<%$Resources:Admin,Admin_FrameView_Other%>"></asp:ListItem>
                    <asp:ListItem Value="all" Text="<%$Resources:Admin,System_All%>"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
    </div>
     <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Đường dẫn đến file UC (dạng danh sách)
            </div>
            <div class="input">
                <asp:TextBox ID="txtListingPath" CssClass="input-text" Width="300px" runat="server" />
                ex: Controls/Article/ArticleListing.ascx => vào trang danh sách tin tức
            </div>
        </div>
    </div>
      <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Đường dẫn đến file UC (dạng chi tiết)
            </div>
            <div class="input">
                <asp:TextBox ID="txtDetailPath" CssClass="input-text" Width="300px" runat="server" />
                ex: Controls/Article/ArticleDetail.ascx => vào trang chi tiết tin tức
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <%=BicResource.GetValue("Admin","Admin_FrameView_Browse") %>
            </div>
            <div class="input">
                <asp:CheckBox runat="server" Enable="<%# Approved %>" ID="chkIsActive" />
            </div>
        </div>
    </div>
</div>
<div class="form-tool-bottom">
    <bic:ToolBar ID="tbBottom" runat="server" />
    <asp:LinkButton ID="lbtnSave2" CssClass="btn-save" runat="server" OnCommand="Save" CommandName="Update"><%=BicResource.GetValue("Admin","Admin_FrameView_Save") %></asp:LinkButton>
</div>
<telerik:RadInputManager runat="server" ID="rimBICCMS" EnableEmbeddedSkins="false" Skin="BICCMS">
    <telerik:TextBoxSetting BehaviorID="bhName" EmptyMessage="<%$Resources:Admin,Admin_FrameView_EnterTheFunctionName%>" Validation-IsRequired="true">
        <TargetControls>
            <telerik:TargetInput ControlID="txtName" />
        </TargetControls>
    </telerik:TextBoxSetting>
</telerik:RadInputManager>
