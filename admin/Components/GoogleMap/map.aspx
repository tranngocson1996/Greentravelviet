<%@ Page Language="C#" AutoEventWireup="true" CodeFile="map.aspx.cs"
    Inherits="Samples_MapWithTooltips" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>B
<%@ Register Src="~/Controls/GoogleMap/Maps.ascx" TagPrefix="uc1" TagName="Maps" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div style="width: 720px; height: 420px; float: left;position:relative"  title="Click chuột trái, phải 2 lần để phóng to, thu nhỏ">
            <uc1:Maps runat="server" ID="Maps" />
        </div>
    </form>


</body>
</html>
