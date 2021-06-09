<%@ Control Language="C#" AutoEventWireup="true" CodeFile="QC.ascx.cs" Inherits="Controls_Adv_Adv" %>
<%=Include.CssAdd("~/Controls/Adv/Adv.css") %>
<div class="advqc <%=CssClass%>">
<asp:ListView ID="dlAdvList" runat="server">
    <ItemTemplate>
        <div class="item"> 
            <a id="close">
            <img src="<%=Page.ResolveUrl("/Styles/img/close.png")%>" />
                </a>
        <%#Eval("Description")%>
        </div>
    </ItemTemplate>
</asp:ListView>
    </div>
<script type="text/javascript">
    if ('<%=BIC.Utils.BicSession.ToString("adv_left")%>' == "left") {
   
        $(".adv_left").remove();
    }
    if ('<%=BIC.Utils.BicSession.ToString("adv_right")%>' == "right")
        $(".adv_right").remove();
    $(".adv_left #close").click(function () {
        $(".adv_left").remove();
        hiden("left");
    });
    $(".adv_right #close").click(function () {
        $(".adv_right").remove();
        hiden("right");
    });

    function hiden(adv)
    {
        $.ajax({
            type: "POST",
            url: '<%=Page.ResolveUrl("~")%>' + "WebService/hidenadv.asmx/adv_Click",
            data: "{adv: '" + adv + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json"
               });
    }
</script>