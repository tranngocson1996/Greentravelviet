<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintArticle.aspx.cs" Inherits="PrintArticle" %>

<%@ Register Src="~/Controls/Tools/PrintArticle.ascx" TagPrefix="uc1" TagName="PrintArticle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:PrintArticle runat="server" ID="UcPrintArticle" />
        </div>
    </form>
</body>
</html>
