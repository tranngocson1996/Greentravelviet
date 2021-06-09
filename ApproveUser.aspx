<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ApproveUser.aspx.cs" Inherits="admin_ApproveUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox runat="server" ID="txtUser"></asp:TextBox>
            <asp:Button runat="server" Text="Approve" ID="btnSave" OnClick="btnSave_Click" />
            &nbsp;&nbsp;&nbsp;
        <asp:Button runat="server" Text="ResetPass" ID="btnResetPass" OnClick="btnResetPass_Click" />
        </div>
    </form>
</body>
</html>
