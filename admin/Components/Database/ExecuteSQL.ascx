<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ExecuteSQL.ascx.cs" Inherits="admin_Components_Database_ExecuteSQL" %>
<div class="grid sql">
    <asp:TextBox TextMode="MultiLine" runat="server" Height="300px" Width="90%" ID="txtSQL" />
    <asp:Button runat="server" ID="btnExecute" OnClick="btnExecute_Click" Text="Thực Hiện" CssClass="btnsql" />
    <div class="contentSql">
        <asp:GridView ID="gvData" Width="90%" AutoGenerateColumns="true" runat="server">
        </asp:GridView>
    </div>
</div>