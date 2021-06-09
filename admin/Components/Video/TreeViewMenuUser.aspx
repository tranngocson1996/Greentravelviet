<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TreeViewMenuUser.aspx.cs" Inherits="admin_Components_Video_TreeViewMenuUser" %>
<%@ Import Namespace="BIC.Utils" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
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
                <asp:Button ID="btnMove" runat="server" Style="margin:0 auto" Text="<%$Resources:Admin,System_Move%>" OnClick="btnMove_Click" OnClientClick="alet()" /><br />
                <telerik:RadScriptManager ID="RadScriptManager1" runat="server" />
                <telerik:RadTreeView runat="server" Skin="Outlook" ID="tvMenuUser" PersistLoadOnDemandNodes="true" LoadingStatusPosition="AfterNodeText"
                                     CollapseAnimation-Duration="100" ExpandAnimation-Duration="100" ExpandAnimation-Type="InQuart" SingleExpandPath="False"
                                     OnNodeExpand="tvMenuUser_NodeExpand">
                </telerik:RadTreeView>
            </div>

        </form>
    </body>

</html>
<script>
    function alet() {

        return confirm('<%=BicResource.GetValue("Admin","Admin_Article_Message5")%>');
    }
</script>