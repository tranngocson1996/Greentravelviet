<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Properties.ascx.cs" Inherits="admin_Components_ImageGallery_Properties" %>
<script language="javascript" type="text/javascript">
    function ImageValue() {document.getElementById("txtUrl").value = "";var imgArr = showModalDialog('Components/ImageGallery/SelectImage.htm', window, 'dialogWidth:700px; dialogHeight:704px;help:0;status:0;resizeable:1');if (imgArr != null) {document.getElementById("txtUrl").value = imgArr["path"];document.getElementById("txtWidth").value = imgArr["width"];document.getElementById("txtHeight").value = imgArr["height"];document.getElementById("<%= hdWidth.ClientID %>").value = imgArr["width"];document.getElementById("<%= hdHeight.ClientID %>").value = imgArr["height"];document.getElementById("hdImageViewer").value = "../ImageViewer.aspx?p=" + imgArr['path'] + "&w=" + parseInt(imgArr['width']) + "&h=" + parseInt(imgArr['height']);ChangeImageContent();}}

    //Hien thi anh tu duong dan ngoai phan quan tri
    function BindPhysicalPath() {var imgSrc = document.getElementById("txtUrl").value;var newImg = new Image();newImg.src = imgSrc;var height = newImg.height;var width = newImg.width;document.getElementById("txtWidth").value = width;document.getElementById("txtHeight").value = height;document.getElementById("<%= hdWidth.ClientID %>").value = width;document.getElementById("<%= hdHeight.ClientID %>").value = height;document.getElementById("<%= hdImageViewer.ClientID %>").value = imgSrc;ChangeImageContent();}

    //Tu dong thay doi Height theo Width
    function WidthClick() {var oWidth = parseInt(document.getElementById("txtWidth").value);var oHeight = parseInt(document.getElementById("txtHeight").value);var oHDWidth = parseInt(document.getElementById("<%= hdWidth.ClientID %>").value);var oHDHeight = parseInt(document.getElementById("<%= hdHeight.ClientID %>").value);var hdLook = document.getElementById("hdLook").value;if (hdLook == 1) {var PercentWidth = ((oWidth - oHDWidth) * 100) / oHDWidth;var PercentHeight = oHDHeight + (oHDHeight * PercentWidth) / 100;document.getElementById("txtHeight").value = Math.round(PercentHeight);}ChangeImageContent();}
    //Tu dong thay doi Width theo Height
    function HeightClick() {var oWidth = parseInt(document.getElementById("txtWidth").value);var oHeight = parseInt(document.getElementById("txtHeight").value);var oHDWidth = parseInt(document.getElementById("<%= hdWidth.ClientID %>").value);var oHDHeight = parseInt(document.getElementById("<%= hdHeight.ClientID %>").value);var hdLook = document.getElementById("hdLook").value;if (hdLook == 1) {var PercentHeght = ((oHeight - oHDHeight) * 100) / oHDHeight;var PercentWidth = oHDWidth + (oHDWidth * PercentWidth) / 100;document.getElementById("txtWidth").value = Math.round(PercentWidth);}ChangeImageContent();}

    //Phuong thuc hien thi anh
    function ChangeImageContent() {var oWidth = parseInt(document.getElementById("txtWidth").value);var oHeight = parseInt(document.getElementById("txtHeight").value);var oVSpace = document.getElementById("txtVSpace");var oBorder = document.getElementById("txtBorder");var oHSpace = document.getElementById("txtHSpace");var oAlign = document.getElementById("slAlign");var oAlternativeText = document.getElementById("txtBriefText");var oSrc = document.getElementById("<%= hdImageViewer.ClientID %>").value;var imgTag = "<img height='" + oHeight + "px' hspace='" + parseInt(oHSpace.value) + "' width='" + oWidth + "px' src='" + oSrc + "' align='" + slAlign.value + "' vspace='" + parseInt(oVSpace.value) + "' border='" + parseInt(oBorder.value) + "' alt='" + oAlternativeText.value + "' />";if (oAlign.value == 'center') {imgTag = "<p align=center><img height='" + oHeight + "px' hspace='" + parseInt(oHSpace.value) + "' width='" + oWidth + "px' src='" + oSrc + "' vspace='" + parseInt(oVSpace.value) + "' border='" + parseInt(oBorder.value) + "' alt='" + oAlternativeText.value + "' /></p>";}var Preview = "<p><div  style='position:relative;float:left;width:345px;height:202px;overflow:auto;'>" + imgTag + "Hãy đến với chúng tôi để có sự lựa chọn tốt nhất cho việc quảng bá hình ảnh của công ty, các bạn sẽ có cách quản lý chuyên nghiệp hơn, sẽ tiếp cận thông tin thương mại một cách nhanh và hiện đại nhất.</p></div>"; //tdPreview.innerHTML = Preview;
        document.getElementById("tdPreview").innerHTML = Preview;}

    //Khoi phuc lai kich co goc
    function Refresh() {document.getElementById("txtWidth").value = document.getElementById("<%= hdWidth.ClientID %>").value;document.getElementById("txtHeight").value = document.getElementById("<%= hdHeight.ClientID %>").value;ChangeImageContent();}
    //Chuyen trang thai cho phep tu dong thay doi kich co
    function Look() {var img = document.getElementById("imgLook");var hdLook = document.getElementById("hdLook").value;if (hdLook == 1) {img.src = "Components/ImageGallery/css/UnLock.gif";document.getElementById("hdLook").value = 0;img.alt = "Anable auto resize";}if (hdLook == 0) {img.src = "Components/ImageGallery/css/Lock.gif";document.getElementById("hdLook").value = 1;img.alt = "Disable auto resize";}}

    function returnImage() {var oWidth = parseInt(document.getElementById("txtWidth").value);var oHeight = parseInt(document.getElementById("txtHeight").value);var oVSpace = document.getElementById("txtVSpace").value;var oBorder = document.getElementById("txtBorder").value;var oHSpace = document.getElementById("txtHSpace").value;var oAlign = document.getElementById("slAlign").value;var oAlternativeText = document.getElementById("txtBriefText").value;var oSrc = document.getElementById("hdImageViewer").value;var imgArr = new Array(8);imgArr["imgSrc"] = oSrc;imgArr["width"] = oWidth;imgArr["height"] = oHeight;imgArr["vspace"] = oVSpace;imgArr["border"] = oBorder;imgArr["hspace"] = oHSpace;imgArr["align"] = oAlign;imgArr["alt"] = oAlternativeText;win = top;win.opener = top;win.parent.returnValue = imgArr;win.close(); //window.parent.returnValue = imgArr;
        //window.parent.close();
    }
</script>
<input id="hdImageViewer" runat="server" type="text" style="width:12px" />
<input runat="server" id="hdWidth" style="width:12px" type="text" />
<input runat="server" id="hdHeight" style="width:12px" type="text" />
<input id="hdLook" style="width:12px" type="text" value="1" />
<input id="hdImageID" style="width:12px" type="text" />
<div class="img_info_frame">
    <div class="img_info_top">
        <input type="text" id="txtUrl" class="textbox_imginfo" onkeyup="BindPhysicalPath()" runat="server" style="width:215px;" />
        <div class="img_info_text_chon">
        </div>
        <div class="img_info_chon" onclick=" javascript:ImageValue(); ">
        </div>
        <div class="img_info_huy" onclick=" javascript:document.getElementById('txtUrl').value = ''; ">
        </div>
    </div>
    <div class="img_info_desc">
        <input type="text" id="txtBriefText" runat="server" class="textbox_imginfo" style="width:180px;" />
    </div>
    <div class="img_info_size">
        <input type="text" id="txtWidth" onkeyup="WidthClick()" class="textbox_imginfo" runat="server" style="width:40px;" />
        &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
        <img id="imgLook" style="cursor:pointer" runat="server" onclick="Look()" src="css/Lock.gif" alt="Disable auto resize" />
        &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <input type="text" id="txtHeight" onkeyup="ChangeImageContent()" class="textbox_imginfo" style="width:40px;" runat="server" />
        <div onclick=" Refresh() " class="img_info_refresh">
        </div>
    </div>
    <div class="img_info_border">
        <input type="text" id="txtBorder" onkeyup="ChangeImageContent()" runat="server" class="textbox_imginfo" style="width:40px;" />
        &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <input id="txtColor" runat="server" class="textbox_imginfo" onkeyup="ChangeImageContent()" style="width:40px;" type="text" />
    </div>
    <div class="img_info_padding">
        <input type="text" id="txtHSpace" onkeyup="ChangeImageContent()" runat="server" class="textbox_imginfo" style="width:40px;" />&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <input type="text" id="txtVSpace" onkeyup="ChangeImageContent()" runat="server" class="textbox_imginfo" style="width:40px;" />
    </div>
    <div class="img_info_align">
        <select id="slAlign" runat="server" border="0px" onchange="ChangeImageContent()" style="width:182px" class="textbox_imginfo_left">
            <option value="left">Left</option>
            <option value="right">Right</option>
            <option value="top">Top</option>
            <option value="middle">Middle</option>
            <option value="center" selected="selected">Center</option>
            <option value="bottom">Bottom</option>
            <option value="absBottom">ABS Bottom</option>
            <option value="absMiddle">ABS Middle</option>
            <option value="baseline">Baseline</option>
            <option value="textTop">Text Top</option>
            <option value="top">Top</option>
        </select>
    </div>
    <div id="tdPreview" class="img_info_preview">
    </div>
    <div class="img_info_thuchien">
        <img src="css/thuchien.jpg" alt="Chọn ảnh" onclick=" returnImage() " style="cursor:pointer" />
    </div>
</div>