function LoadCrop() {
    jQuery(document).ready(function () {
        jQuery('#imgOriginal').Jcrop({
            onChange: showCoords,
            onSelect: showCoords
        });
    });
}
function showCoords(c) {
    jQuery('#CropX').val(c.x);
    jQuery('#CropY').val(c.y);
    jQuery('#CropWidth').val(c.w);
    jQuery('#CropHeight').val(c.h);
};

function ShowImage(imageURL) {
    var curentImage = document.getElementById("imgOriginal");
    var imageName = imageURL;
    curentImage.src = getBaseURL() + "FileUpload/Images/" + imageName + "?" + (new Date() - 100);
    document.getElementById("hdnField1").value = imageName.replace("Images/", "");
}
function OnClientValueChange(sender, args) {
    document.getElementById(sender.get_id() + "ValueField").value = sender.get_value() + "%";
}
function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;
    return true;
}

function getImgSize() {
    var curentImage = document.getElementById("imgOriginal");
    document.getElementById("txtImgWidth").value = document.getElementById("hdWidth").value = curentImage.width;
    document.getElementById("txtImgHeight").value = document.getElementById("hdHeight").value = curentImage.height;
}

function WidthClick() {
    var oWidth = parseInt(document.getElementById("txtImgWidth").value);
    var oHeight = parseInt(document.getElementById("txtImgHeight").value);
    var oHDWidth = parseInt(document.getElementById("hdWidth").value);
    var oHDHeight = parseInt(document.getElementById("hdHeight").value);
    var hdLook = document.getElementById("hdLook").value

    if (hdLook == 1) {
        if (oWidth == null) {
            oWidth = 0;
        }
        var PercentWidth = ((oWidth - oHDWidth) * 100) / oHDWidth;
        var PercentHeight = oHDHeight + (oHDHeight * PercentWidth) / 100;
        document.getElementById("txtImgHeight").value = Math.round(PercentHeight);
    }
}

//Tu dong thay doi Width theo Height
function HeightClick() {
    var oWidth = parseInt(document.getElementById("txtImgWidth").value);
    var oHeight = parseInt(document.getElementById("txtImgHeight").value);
    var oHDWidth = parseInt(document.getElementById("hdWidth").value);
    var oHDHeight = parseInt(document.getElementById("hdHeight").value);
    var hdLook = document.getElementById("hdLook").value

    if (hdLook == 1) {
        var PercentHeght = ((oHeight - oHDHeight) * 100) / oHDHeight;
        var PercentWidth = oHDWidth + (oHDWidth * PercentWidth) / 100;
        document.getElementById("txtImgWidth").value = Math.round(PercentWidth);
    }
}

//Khoi phuc lai kich co goc
function Refresh() {
    document.getElementById("txtImgWidth").value = document.getElementById("hdWidth").value
    document.getElementById("txtImgHeight").value = document.getElementById("hdHeight").value
}
//Chuyen trang thai cho phep tu dong thay doi kich co
function Look() {
    var img = document.getElementById("imgLook");
    var hdLook = document.getElementById("hdLook").value;
    if (hdLook == 1) {
        img.src = getBaseURL() + "Styles/icon/key_lock_9x12.gif";
        document.getElementById("hdLook").value = 0;
        img.alt = "Enable auto resize";
    }
    if (hdLook == 0) {
        img.src = getBaseURL() + "Styles/icon/key_unlock_9x12.gif";
        document.getElementById("hdLook").value = 1;
        img.alt = "Disable auto resize";
    }
}