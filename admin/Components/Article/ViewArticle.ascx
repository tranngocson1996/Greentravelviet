<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewArticle.ascx.cs" ViewStateMode="Enabled" Inherits="Admin_Components_Article_ViewArticle" %>
<%@ Import Namespace="BIC.Utils" %>
<div class="form-tool">
    <bic:ToolBar ID="tbTop" runat="server" />
</div>
<div class="form-caption">
     <%=BicResource.GetValue("Admin","Admin_Article_DetailedContent2") %>
</div>
<div class="form-view">
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                  <%=BicResource.GetValue("Admin","Admin_Article_Title2") %> 
            </div>
            <div class="input">
                <asp:Literal runat="server" ID="litTitle"></asp:Literal>
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                 <%=BicResource.GetValue("Admin","Admin_Article_List") %> 
            </div>
            <div class="input">
                <asp:Literal runat="server" ID="litMenuUser"></asp:Literal>
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                 <%=BicResource.GetValue("Admin","Admin_Article_SpecialPosition") %> 
            </div>
            <div class="input">
                <asp:Literal runat="server" ID="litOtherCategory"></asp:Literal>
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                 <%=BicResource.GetValue("Admin","System_OtherInformation") %> 
            </div>
            <div class="input group-item">
                <div class="col first selector-image">
                    <div class="title">
                        <a href="#">   <%=BicResource.GetValue("Admin","Admin_Article_ImageDescription") %></a>
                    </div>
                    <div class="image">
                        <a runat="server" id="aImage" href="#" onclick="hs.expand(this);">
                            <img runat="server" id="htmlImage" src="~/admin/Styles/icon/selectImage.gif" clientidmode="Static" />
                        </a>
                    </div>
                </div>
                <div class="col c1">
                    <div class="line">
                        <div class="label">
                            <a href="#">   <%=BicResource.GetValue("Admin","Admin_Article_ContactByPost") %></a>
                        </div>
                        <div class="input">
                            <asp:CheckBox runat="server" ID="chkCommentEnable" Enabled="false" />
                        </div>
                    </div>
                    <div class="line">
                        <div class="label">
                            <a href="#">   <%=BicResource.GetValue("Admin","Admin_Article_Home") %></a>
                        </div>
                        <div class="input">
                            <asp:CheckBox runat="server" ID="chkIsHome" Enabled="false" />
                        </div>
                    </div>
                    <div class="line">
                        <div class="label">
                            <a href="#">   <%=BicResource.GetValue("Admin","System_New") %></a>
                        </div>
                        <div class="input">
                            <asp:CheckBox runat="server" ID="chkIsNew" Enabled="false" />
                        </div>
                    </div>
                    <div class="line">
                        <div class="label">
                            <a href="#">   <%=BicResource.GetValue("Admin","System_Browse") %></a>
                        </div>
                        <div class="input">
                            <asp:CheckBox runat="server" ID="chkIsActive" Enabled="false" />
                        </div>
                    </div>
                </div>
                <div class="col c2">
                    <div class="line">
                        <div class="label">
                            <a href="#">   <%=BicResource.GetValue("Admin","Admin_Article_Views2") %></a>
                        </div>
                        <div class="input">
                            <asp:TextBox runat="server" ID="txtViewCount" CssClass="input-text"> </asp:TextBox>
                        </div>
                    </div>
                    <div class="line">
                        <div class="label">
                            <a href="#">   <%=BicResource.GetValue("Admin","System_Source") %></a>
                        </div>
                        <div class="input">
                            <asp:TextBox runat="server" ID="txtSource" CssClass="input-text"></asp:TextBox>
                        </div>
                    </div>
                    <div class="line">
                        <div class="label">
                            <a href="#">   <%=BicResource.GetValue("Admin","Admin_Article_Link") %></a>
                        </div>
                        <div class="input">
                            <asp:TextBox runat="server" ID="txtLink" CssClass="input-text"></asp:TextBox>
                        </div>
                    </div>
                    <div class="line">
                        <div class="label">
                            <a href="#">   <%=BicResource.GetValue("Admin","System_Target") %></a>
                        </div>
                        <div class="input">
                            <bic:Target runat="server" ID="cbTarget" CssClass="input-select" Enabled="false">
                            </bic:Target>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                   <%=BicResource.GetValue("Admin","AAdmin_Article_ShortDescription") %>
            </div>
            <div class="input">
                <asp:Literal runat="server" ID="litBriefDescription"></asp:Literal>
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                  <%=BicResource.GetValue("Admin","System_DetailedContent") %> 
            </div>
            <div class="input">
                <asp:Literal runat="server" ID="litBody"></asp:Literal>
            </div>
        </div>
    </div>
    <asp:TextBox runat="server" ID="txtAllowUser" CssClass="input-text hidden" />
    <%--    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">

            </div>
            <div class="input">

            </div>
        </div>
    </div>--%>
</div>
<div class="form-tool-bottom">
    <bic:ToolBar ID="tbBottom" runat="server" />
</div>