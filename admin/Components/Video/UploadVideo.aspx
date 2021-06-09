<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UploadVideo.aspx.cs" Inherits="admin_Components_Video_UploadVideo" %>

<%@ Register Src="UpVideo.ascx" TagName="UpVideo" TagPrefix="uc1" %>
<%@ Register Src="EditVideo.ascx" TagName="EditVideo" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <%= IncludeAdmin.DefaultCss() %>
        <%= IncludeAdmin.JqueryUI() %>
        <%= IncludeAdmin.BICSkin() %>
    </telerik:RadCodeBlock>
    <script type="text/javascript">
        window.parent.$('#tabs > ul > li').removeClass('selected'); window.parent.$('#lnkupload').parent().addClass('selected');
</script>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager runat="server">
    </telerik:RadScriptManager>
    <div>
        <asp:HiddenField ID="hdfLangForVideo" runat="server" ClientIDMode="Static" />
        <uc2:EditVideo ID="EditVideo1" runat="server" Visible="False" />
        <uc1:UpVideo ID="UpVideo1" runat="server" />
    </div>
    </form>
</body>
</html>