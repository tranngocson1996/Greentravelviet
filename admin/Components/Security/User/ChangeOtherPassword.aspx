<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangeOtherPassword.aspx.cs" Inherits="admin_Components_Security_User_ChangePassword" %>
<%@ Register Src="ChangeOtherPassword.ascx" TagName="ChangeOtherPassword" TagPrefix="uc2" %>
<%@ Import Namespace="BIC.Utils" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title><%=BicResource.GetValue("Admin","Admin_Security_User_ChangeThePassword") %></title>
    </head>
    <body>
        <form id="form1" runat="server">
            <uc2:ChangeOtherPassword ID="ChangeOtherPassword1" runat="server" />
        </form>
    </body>
</html>