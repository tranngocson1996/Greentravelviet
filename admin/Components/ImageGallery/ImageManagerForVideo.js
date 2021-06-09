/*var lang = $("#hdfLangManager").val();
//var lang = $("#hdfLangForVideo").val();
if ($.trim(lang) == 'undefined')
    lang = 'vi';*/
lang = 'vi';
function ImageClick(imgId, width, height, path) {
    var arr = new Array(4); arr["imgID"] = imgId; arr["width"] = width; arr["height"] = height; arr["path"] = path;
    window.parent.jQuery.FrameDialog.setResult(arr);
    window.parent.jQuery.FrameDialog.closeDialog();
}
function EditImage(name, imgid) {

    var $dialog = window.top.$.FrameDialog.create({
        url: getBaseURL() + 'admin/components/ImageGallery/ImageEditor.aspx?img=' + name + '&ID=' + imgid + '&l=' + lang,
        loadingClass: 'loading-image',
        title: 'Chỉnh sửa ảnh',
        width: 690,
        height: 475,
        autoOpen: false,
        resizable: false
    })
        .bind('dialogclose', function (event, ui) { location.reload(true); }); $dialog.dialog('open');
}
$(document).ready(function () {
    window.parent.$('#tabs > ul > li').removeClass('selected'); window.parent.$('#lnkgalery').parent().addClass('selected'); var imgId = $.trim($("#hdImageManager").val().replace(" ", "")); if (imgId != "") { var arr = imgId.split(','); for (var i = 0; i < arr.length; i++) { $("#frame_gallery .chkimg").each(function () { if ($(this).attr("id") == arr[i]) { $(this).removeClass("uncheckmark").addClass("checkmark"); } }); } } $(".ckhall").live("click", function () {
        $(this).toggle(function () {
            $(this).removeClass("uncheckmark").addClass("checkmark");
            $("#frame_gallery").find(".chkimg").removeClass("uncheckmark").addClass("checkmark");

            var imgID = $.trim($("#hdImageManager").val());
            $("#frame_gallery .chkimg").each(function () {
                if ($(this).hasClass("checkmark")) {
                    imgID += "," + $(this).attr("id");
                };
            });
            $("#hdImageManager").val(imgID);
        },
            function () {
                $(this).removeClass("checkmark").addClass("uncheckmark");
                $("#frame_gallery").find(".chkimg").removeClass("checkmark").addClass("uncheckmark");
                var imgID = $.trim($("#hdImageManager").val());
                $("#frame_gallery .chkimg").each(function () {
                    if ($(this).hasClass("uncheckmark")) {
                        imgID = imgID.replace(",", "");
                        imgID = imgID.replace($(this).attr("id"), "");
                    };
                }); imgID = imgID.replace($(this).attr(" "), ""); $("#hdImageManager").val($.trim(imgID));
            }).trigger("click");
    });
    $(".chkimg").live("click", function () {
        if ($(this).hasClass("uncheckmark")) {
            $(this).removeClass("uncheckmark").addClass("checkmark");
            var imgID = $.trim($("#hdImageManager").val().replace(" ", ""));
            var duplicate = false; if (imgID != "") {
                var arr = imgID.split(',');
                for (var i = 0; i < arr.length; i++) { if ($(this).attr("id") == arr[i]) { duplicate = true; } } if (!duplicate) imgID += "," + $(this).attr("id");
            } else { imgID += "," + $(this).attr("id"); } $("#hdImageManager").val($.trim(imgID.replace(" ", ""))); return false;
        } else {
            $(this).removeClass("checkmark").addClass("uncheckmark");
            var imgID = $.trim($("#hdImageManager").val().replace(" ", ""));
            var newImgID = ""; if (imgID != "") { var arr = imgID.split(','); for (var i = 0; i < arr.length; i++) { if ($(this).attr("id") != arr[i]) newImgID += "," + arr[i]; } if (arr.length == 2) newImgID = ""; } newImgID = newImgID.replace(",,", ","); $("#hdImageManager").val($.trim(newImgID.replace(" ", ""))); return false;
        }
    }); $("#btnAddImg").live("click", function () {
        var count = true;
        var imgID = $.trim($("#hdImageManager").val().replace(" ", "")); imgID = imgID.replace(",,", ",");
        if (imgID == "") { count = false; };
        if (count) {
            window.parent.jQuery.FrameDialog.setResult(imgID); window.parent.jQuery.FrameDialog.closeDialog();
        }
        else { alert("Bạn chưa chọn ảnh nào."); } return false;
    }); $("#btnDelImg").live("click", function () {
        var count = true;
        var imgID = $.trim($("#hdImageManager").val().replace(" ", ""));
        imgID = imgID.replace(",,", ",");
        var lang = $("#hdfLang").val();
        if (imgID == "") { count = false; };
        if (count) {
            if (confirm("Bạn chắc chắn muốn xóa các ảnh đã chọn?")) $.ajax({
                type: "POST",
                url: getBaseURL() + 'admin/Components/ImageGallery/DelImg.ashx?id=' + imgID,
                success: function (mess) {
                    if (parseInt(mess) == 0) {
                        alert("Ảnh đã được xóa thành công.");
                        if (location.href.match("ismulti")) { window.location = getBaseURL() + "admin/Components/ImageGallery/GalleryForVideo.aspx?ismulti=0&l=" + lang; }
                        else {
                            window.location = getBaseURL() + "admin/Components/ImageGallery/GalleryForVideo.aspx?l=" + lang;
                        }
                    } else {
                        alert("Có " + mess + " ảnh xóa không thành công.");
                        if (location.href.match("ismulti")) {
                            window.location = getBaseURL() + "admin/Components/ImageGallery/GalleryForVideo.aspx?ismulti=0&l=" + lang;
                        } else { window.location = getBaseURL() + "admin/Components/ImageGallery/GalleryForVideo.aspx?l=" + lang; }
                    }
                },
                error: function (errormessage) { /*alert(errormessage.responseText);alert("Chức năng này đang được nâng cấp. Mời bạn quay lại sau.");*/ }
            });
        } else { alert("Bạn chưa chọn ảnh nào."); } return false;
    });
});