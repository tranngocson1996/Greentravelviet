<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImportExcel.aspx.cs" Inherits="admin_Components_Security_User_ImportExcel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>ImportExcel</title>
    </head>
    <body style="width:288px">
        <form id="form1" runat="server">
            <div>
                <table class="style1">
                    <tr>
                        <td class="style3">
                            <asp:FileUpload ID="fuExcel" runat="server" />
                        </td>
                        <td class="style4">
                            <asp:Button ID="btnImport" runat="server" Text="Import" OnClick="btnImport_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            &nbsp;
                        </td>
                        <td class="style4">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </div>
        </form>
    </body>
</html>