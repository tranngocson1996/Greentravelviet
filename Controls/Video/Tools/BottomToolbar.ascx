<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BottomToolbar.ascx.cs" Inherits="Controls_Article_Tools_BottomToolbar" %>
<%@ Import Namespace="BIC.Utils" %>
<div class="BottomToolbar">
    <div class="update">
        <asp:Literal ID="ltlModifiedDate" runat="server" />
    </div>
    <div class="pageview" runat="server" id="viewcount"><%=BicResource.GetValue("ViewCount") %>
        <asp:Literal ID="ltlViewCount" runat="server" /></div>
    <a class="to-top" href="#" title='<%=BicResource.GetValue("TopPageToolTip") %>'>
        <%=BicResource.GetValue("TopPage") %></a>

    <a class="zing" onclick="google_click()" style="cursor: pointer" title='<%=BicResource.GetValue("GoogleToolTip") %>'></a>
    <a class="facebook" onclick="fbs_click()" style="cursor: pointer" title='<%=BicResource.GetValue("FacebookToolTip") %>'></a>
    <a class="twitter" onclick="share_twitter()" style="cursor: pointer" title='<%=BicResource.GetValue("TwitterToolTip") %>'></a>
    <a class="share" onclick="return addthis_sendto()" onmouseout="addthis_close()" onmouseover="return addthis_open(this, '', '[URL]', '[TITLE]')" href="http://www.addthis.com/bookmark.php" title='<%=BicResource.GetValue("SocialNetworkToolTip") %>'></a>
</div>
<script type="text/javascript">
    function google_click() {
        u = location.href; t = document.title;
        window.open("https://accounts.google.com/ServiceLogin?hl=vi&continue=http://www.google.com.vn/" + encodeURIComponent(u) + "&amp;t=" + encodeURIComponent(t) + "&amp;desc=" + encodeURIComponent(t))
    }

</script>
