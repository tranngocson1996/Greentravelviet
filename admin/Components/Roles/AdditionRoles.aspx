<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdditionRoles.aspx.cs" Inherits="admin_Components_Roles_AdditionRoles" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
        <style type="text/css">
            body {margin:0px;}
            .style1 {width:27%;}
        </style>
    </head>
    <body>
        <form id="form1" runat="server">
            <div>
                <table class="style1">
                    <tr>
                        <td>
                            <asp:TextBox ID="txtRole" runat="server" Width="201px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btnAdd" runat="server" Text="Thêm" OnClick="btnAdd_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </div>
        </form>
    </body>
</html>