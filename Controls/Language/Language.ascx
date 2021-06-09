<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Language.ascx.cs" Inherits="Controls_Language" %>



<div id="languages-block" class="language">
    <div class=" current top-inner">
        <div class="c-logolang">
            <asp:Literal ID="ltrCoverImage" runat="server" />
            <span class="language-key"><%= TextLanguge %></span>
            <i class="fa fa-sort-desc" aria-hidden="true"></i>
        </div>
    </div>
    <ul id="languages" class="language-select top-sub">
        <li class="selected">
            <img src='/Styles/images/vi.jpg' class='c-lang' />
            <asp:LinkButton runat="server" CssClass="vi" ID="btnVI" Text="VIETNAM" OnCommand="LanguageCommand" CommandName="vi" />
        <li>
            <img src='/Styles/images/en.png' class='c-lang' />
            <asp:LinkButton runat="server" CssClass="en" ID="LinkButton1" Text="ENGLISH" OnCommand="LanguageCommand" CommandName="en" />
        </li>
    </ul>
</div>
