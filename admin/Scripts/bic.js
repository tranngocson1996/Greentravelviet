//this function clears value of textbox
function ClearText(ctrID) {
    document.getElementById(ctrID).value = "";
}
//this function clears a hidenField value and source value of image
function ClearImage(ctrID1, ctrlID2) {
    document.getElementById(ctrID1).value = "";
    document.getElementById(ctrID2).src = "";
}

function Popup(url) {
    if (document.getElementById(url).value == "") {
        alert('Bạn chưa nhập đường dẫn');
    }
    else {
        window.open(document.getElementById(url).value);
    }
}
function PopupUrl(url) {
    if (url != "") {
        window.open(url);
    }
}

/*Script for ImageManager*/
lastDiv = null;
function divClick(theDiv, width, height) {
    if (lastDiv) {
        lastDiv.style.border = "none";
    }
    lastDiv = theDiv;
}

function returnImage(imgID, width, height, path) {
    var arr = new Array(4);
    arr["imgID"] = imgID;
    arr["width"] = width;
    arr["height"] = height;
    arr["path"] = path;
    win = top;
    win.opener = top;
    win.parent.returnValue = arr;
    win.close();
}

function CancelImage(txtSelectImage, imgDescImage) {
    if (confirm('Bạn có chắc chắn xóa không ?')) {
        document.getElementById(txtSelectImage).value = "0";
        document.getElementById(imgDescImage).src = "";
        document.getElementById(imgDescImage).style.display = "none";
    }
}

function SelectPhoto(url, img, containerid) {
    var container = document.getElementById(containerid);
    var img = document.getElementById(img);

    imgArr = showModalDialog(url, window, 'dialogWidth:690px; dialogHeight:560px;help:0;status:0;resizeable:1');
    if (imgArr != null) {
        container.value = imgArr['imgID'];
        if (imgArr['path'] != null) {
            img.style.display = "block";
            img.src = imgArr['path'];
        }
        else
            img.style.display = "none";
    }
}

function SelectPhotoMulti(url, img, containerid) {
    var container = document.getElementById(containerid);
    var img = document.getElementById(img);
    imgArr = showModalDialog(url, window, 'dialogWidth:700px; dialogHeight:720px;help:0;status:0;resizeable:1');
    if (imgArr != null) {
        container.value = imgArr['imgID'];
        if (imgArr['path'] != null) {
            img.style.display = "block";
            img.src = imgArr['path'];
        }
        else
            img.style.display = "none";
    }
}

/*End script for ImageManager*/