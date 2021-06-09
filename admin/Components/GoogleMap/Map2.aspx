<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Map2.aspx.cs" Inherits="Controls_GoogleMap_Map2" %>

<%@ Register Src="Maps.ascx" TagName="Maps" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:Maps ID="Maps1" runat="server" PosX="21.012682" PosY="105.828348" Address="Số 39 Phố Hồ Đắc Di, Đống Đa, Hà Nội" isView="True" />
    </div>
    </form>
</body>
</html>