<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Map1.aspx.cs" Inherits="Controls_GoogleMap_Map1" %>

<%@ Register Src="Maps.ascx" TagName="Maps" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/GoogleMap/Maps.ascx" TagPrefix="uc2" TagName="Maps" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     
    <div >

        <uc1:Maps ID="Maps1" runat="server" PosX="21.017429" PosY="105.830403" isView="True" Address="Số 23 Phố Nam Đồng mới, Xã Đàn, Đống Đa, Hà Nội" />

            
    </div>
    </form>
</body>
</html>