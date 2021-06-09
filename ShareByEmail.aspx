<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShareByEmail.aspx.cs" Inherits="ShareByEmail" %>
<%@ Register Src="~/Controls/Tools/ShareByEmail.ascx" TagPrefix="uc1" TagName="ShareByEmail" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Share by email</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:ShareByEmail runat="server" ID="UcShareByEmail" />
        </div>
    </form>
</body>
</html>
