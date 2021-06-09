<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderStatusChange.aspx.cs" Inherits="admin_Components_OrderMenu_OrderStatusChange" %>

<%@ Import Namespace="BIC.Utils" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function OnClientClose(oWnd, eventArgs) { //your code here
            //remove the OnClientClose function to avoid
            //adding it for a second time when the window is shown again
            oWnd.remove_close(OnClientClose);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <telerik:RadScriptManager runat="server" ID="RadScriptManager1"></telerik:RadScriptManager>
            <table style="margin-top: 20px;">
                <tr>
                    <td>
                        <telerik:RadCodeBlock runat="server" ID="RadCodeBlock">
                            <%=BicResource.GetValue("Admin","Admin_Search_PaymentStatus") %>
                        </telerik:RadCodeBlock>
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlPaymentStatus">
                            <asp:ListItem Text="-- Chọn trạng thái --" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Chưa thanh toán" Value="Chưa thanh toán"></asp:ListItem>
                            <asp:ListItem Text="Đã thanh toán" Value="Đã thanh toán"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <telerik:RadCodeBlock ID="RadCodeBlock7" runat="server">
                            <%=BicResource.GetValue("Admin","Admin_Search_ShippingStatus") %>
                        </telerik:RadCodeBlock>
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlShippingStatus">
                            <asp:ListItem Text="-- Chọn trạng thái --" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Chưa giao hàng" Value="Chưa giao hàng"></asp:ListItem>
                            <asp:ListItem Text="Đang giao hàng" Value="Đang giao hàng"></asp:ListItem>
                            <asp:ListItem Text="Đã giao hàng" Value="Đã giao hàng"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnMove" runat="server" Style="margin: 0 auto" Text="<%$Resources:Admin,System_Save%>" OnClick="btnMove_Click" OnClientClick="alet()" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
<script>
    function alet() {
        return confirm('<%=BicResource.GetValue("Admin","Admin_Order_Message_Confirm_Change")%>');
    }
</script>
