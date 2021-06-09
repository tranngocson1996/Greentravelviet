<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImageEditor.aspx.cs" Inherits="admin_Components_ImageGallery_ImageEditor" %>

<html>
    <head id="Head1">
        <title>Edit Image</title>
        <%= IncludeAdmin.DefaultCss() %>
        <%= IncludeAdmin.JqueryUI() %>
        <%= IncludeAdmin.ImgEditStyles() %>
        <%= IncludeAdmin.JqueryJcrop() %>
        <script type="text/javascript">
        function LoadCrop() {
            jQuery(document).ready(function() {
                jQuery('#imgOriginal').Jcrop({
                    onChange: showCoords,
                    onSelect: showCoords
                });
            });
        }
        function showCoords(c) { jQuery('#CropX').val(c.x); jQuery('#CropY').val(c.y); jQuery('#CropWidth').val(c.w); jQuery('#CropHeight').val(c.h); };

        function ShowImage(imageUrl) { var curentImage=document.getElementById("imgOriginal"); var imageName=imageUrl; curentImage.src="../../../FileUpload/Images/"+imageName+"?"+(new Date()-100); document.getElementById("hdnField1").value=imageName.replace("Images/",""); }
        function OnClientValueChange(sender,args) { document.getElementById(sender.get_id()+"ValueField").value=sender.get_value()+"%"; }
        function isNumberKey(evt) { var charCode=(evt.which)?evt.which:event.keyCode; if(charCode>31&&(charCode<48||charCode>57)) return false; return true; }

        function getImgSize() { var curentImage=document.getElementById("imgOriginal"); document.getElementById("txtImgWidth").value=document.getElementById("hdWidth").value=curentImage.width; document.getElementById("txtImgHeight").value=document.getElementById("hdHeight").value=curentImage.height; }

        function WidthClick() { var oWidth=parseInt(document.getElementById("txtImgWidth").value); var oHeight=parseInt(document.getElementById("txtImgHeight").value); var oHDWidth=parseInt(document.getElementById("hdWidth").value); var oHDHeight=parseInt(document.getElementById("hdHeight").value); var hdLook=document.getElementById("hdLook").value; if(hdLook==1) { if(oWidth==null) { oWidth=0; } var PercentWidth=((oWidth-oHDWidth)*100)/oHDWidth; var PercentHeight=oHDHeight+(oHDHeight*PercentWidth)/100; document.getElementById("txtImgHeight").value=Math.round(PercentHeight); } }

        //Tu dong thay doi Width theo Height
        function HeightClick() { var oWidth=parseInt(document.getElementById("txtImgWidth").value); var oHeight=parseInt(document.getElementById("txtImgHeight").value); var oHDWidth=parseInt(document.getElementById("hdWidth").value); var oHDHeight=parseInt(document.getElementById("hdHeight").value); var hdLook=document.getElementById("hdLook").value; if(hdLook==1) { var PercentHeght=((oHeight-oHDHeight)*100)/oHDHeight; var PercentWidth=oHDWidth+(oHDWidth*PercentWidth)/100; document.getElementById("txtImgWidth").value=Math.round(PercentWidth); } }

        //Khoi phuc lai kich co goc
        function Refresh() { document.getElementById("txtImgWidth").value=document.getElementById("hdWidth").value; document.getElementById("txtImgHeight").value=document.getElementById("hdHeight").value; }
        //Chuyen trang thai cho phep tu dong thay doi kich co
        function Look() { var img=document.getElementById("imgLook"); var hdLook=document.getElementById("hdLook").value; if(hdLook==0) { img.src=getBaseURL()+"admin/Styles/icon/key_lock_9x12.gif"; document.getElementById("hdLook").value=1; img.alt="Tự động thay đổi kích thước"; } if(hdLook==1) { img.src=getBaseURL()+"admin/Styles/icon/key_unlock_9x12.gif"; document.getElementById("hdLook").value=0; img.alt="Không tự động thay đổi kích thước"; } }
        function getBaseURL() {
            var url=window.location.href;
            var baseUrl=url.substring(0,url.indexOf('/',14));
            var host=window.location.host;
            var indexadmin=window.location.pathname.split("/");
            if(baseUrl.indexOf('http://'+host)!=-1&&indexadmin[2]=="admin") {
                var pathname=location.pathname;
                var index1=url.indexOf(pathname);
                var index2=url.indexOf("/",index1+1);
                var baseLocalUrl=url.substr(0,index2);
                return baseLocalUrl+"/";
            }
            else {
                return baseUrl+"/";
            }
        }
</script>
    </head>
    <body style="margin: 0px 0px;">
        <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="600" />
            <div class="imageeditor">
                <asp:HiddenField ID="hdnField1" runat="server" />
                <input id="hdWidth" style="width: 12px;" type="hidden" />
                <input id="hdHeight" style="width: 12px" type="hidden" />
                <input id="hdLook" style="width: 12px" type="hidden" value="1" />
                <div>
                    <div id="ContentDiv">
                        <asp:UpdatePanel ID="updPanel1" runat="server">
                            <ContentTemplate>
                                <table border="0" cellpadding="0" cellspacing="0" class="table">
                                    <tr>
                                        <td>
                                            <asp:Panel ID="pnlEditImage" runat="server">
                                                <div class="panel">
                                                    <div class="title">
                                                        <div title="Size">
                                                            <span>Kích thước</span></div>
                                                    </div>
                                                    <div class="controlwrapper">
                                                        <table border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td colspan="2">
                                                                    Rộng:
                                                                </td>
                                                                <td>
                                                                    <input type="text" id="txtImgWidth" onkeyup="WidthClick()" style="text-align: center; width: 34px;" runat="server" />
                                                                    px
                                                                </td>
                                                                <td>
                                                                    &nbsp;&nbsp;
                                                                    <img id="imgLook" style="cursor: pointer" onclick=" Look() " src='<%= Page.ResolveUrl("~/admin/Styles/icon/key_lock_9x12.gif") %>' alt="Tự động thay đổi kích thước" />
                                                                </td>
                                                                <td>
                                                                    Tự động thay đổi
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    Cao:
                                                                </td>
                                                                <td>
                                                                    <input id="txtImgHeight" runat="server" onkeyup="HeightClick()" style="text-align: center; width: 34px;" type="text" />
                                                                    px
                                                                </td>
                                                                <td>
                                                                    &nbsp;&nbsp;
                                                                    <img id="imgRefresh" style="cursor: pointer" onclick=" Refresh() " src='<%= Page.ResolveUrl("~/admin/Styles/icon/refresh_14x15.gif") %>' alt="Reset size" />
                                                                </td>
                                                                <td>
                                                                    Kích thước ban đầu
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </div>
                                                <div class="panel">
                                                    <div class="title">
                                                        <div title="Flip">
                                                            <span>Lật ảnh</span></div>
                                                    </div>
                                                    <div class="controlwrapper">
                                                        <asp:RadioButtonList CellPadding="0" RepeatColumns="2" CellSpacing="0" ID="FlipList" runat="server" Width="210px">
                                                            <asp:ListItem Text="Kh&#244;ng" Value="0" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="Ngang" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Thẳng đứng" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Cả hai" Value="3"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                                <div class="panel">
                                                    <div class="title">
                                                        <div title="Rotate">
                                                            <span>Xoay ảnh</span></div>
                                                    </div>
                                                    <div class="controlwrapper">
                                                        <asp:RadioButtonList CellPadding="0" RepeatColumns="2" CellSpacing="0" ID="RotateList" runat="server" Width="173px">
                                                            <asp:ListItem Text="Kh&#244;ng" Value="0" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="90&#176;" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="180&#176;" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="270&#176;" Value="3"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                                <div class="panel">
                                                    <div class="title">
                                                        <div title="Crop">
                                                            <span>Cắt ảnh</span></div>
                                                    </div>
                                                    <div class="controlwrapper">
                                                        <table border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td>
                                                                    Tọa độ x:
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="CropX" runat="server" Onkeypress="return isNumberKey(event)" TextMode="SingleLine" Width="34px"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    px
                                                                </td>
                                                                <td style="padding-left: 16px;">
                                                                    rộng:
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="CropWidth" runat="server" Onkeypress="return isNumberKey(event)" TextMode="SingleLine" Width="34px"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    px
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    Tọa độ y:
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="CropY" runat="server" Onkeypress="return isNumberKey(event)" TextMode="SingleLine" Width="34px"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    px
                                                                </td>
                                                                <td style="padding-left: 16px;">
                                                                    cao:
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="CropHeight" runat="server" Onkeypress="return isNumberKey(event)" TextMode="SingleLine" Width="34px"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    px
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </div>
                                                <div class="panel">
                                                    <div class="title">
                                                        <div>
                                                            <span>Lựa chọn</span></div>
                                                    </div>
                                                    <div class="controlwrapper" style="padding: 19px 4px;">
                                                        <asp:Button ID="btnShowNewImage" runat="server" Text="Xem trước" OnClick="btnShowNewImage_Click" ToolTip="Xem trước" />
                                                        &nbsp; &nbsp;
                                                        <asp:Button ID="Save" runat="server" Text="Lưu" OnClick="Save_Click" ToolTip="Lưu thay đổi" />
                                                        &nbsp; &nbsp;
                                                    </div>
                                                </div>
                                            </asp:Panel>
                                        </td>
                                        <td class="ImageEditArea">
                                            <div class="Image">
                                                <asp:Image ID="imgOriginal" onmousedown="click()" runat="server" />
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                                <script type="text/javascript">
            function UpdateImageEditor(imageURL) { //document.getElementById('ContentDiv').style.display = "";
                document.getElementById('imgOriginal').style.display="block"; ShowImage(imageURL); }
            UpdateImageEditor('<%= Request.QueryString["img"] %>');
</script>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </form>
    </body>
</html>