<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UploadForVideo.aspx.cs" Inherits="admin_Components_ImageGallery_UploadForVideo" %>

<%@ Register Src="UploadImageForVideo.ascx" TagName="UploadImageForVideo" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">

    </head>
    <body>
        <form id="form1" runat="server">
            <uc1:UploadImageForVideo ID="UploadImageForVideo1" runat="server" />
        </form>
    </body>
</html>