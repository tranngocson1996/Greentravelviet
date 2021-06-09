$(document).ready(function () {
    var lang = $("#hdfLang").val();
    $("body #ImageGalleryMulti").each(function (index) {
        $(this).replaceWith("<div class='ImageGalleryMultiParent' id='ImageGalleryMultiParent" + index + "'>" + $(this).html() + "</div>"); ImageGalleryFunction("#ImageGalleryMultiParent" + index);
    }); function ImageGalleryFunction(ImageGalleryMultiParentID) {
        function SelectPhotoMuti1(url) {
            var $dialog = $.FrameDialog.create({
                url: url, loadingClass: 'loading-image', title: 'Thư viện ảnh', width: 690, height: 570, autoOpen: false, resizable: false
            }).bind('dialogclose', function (event, ui) {
                imgArr = event.result; if (imgArr != null) {
                    var str = ""; if (imgArr["imgID"] != undefined) {
                        if (!$(ImageGalleryMultiParentID + " #hdArrImage").val().match($.trim(imgArr["imgID"]))) {
                            str = (str == "" ? "," : ",") + imgArr["imgID"];
                        }
                    } else {
                        if (imgArr.split(',').length > 1) {
                            for (var i = 0; i < imgArr.split(',').length; i++) {
                                if (!$(ImageGalleryMultiParentID + " #hdArrImage").val().match($.trim(imgArr.split(',')[i])) && imgArr.split(',')[i] != "") { str += ("," + $.trim(imgArr.split(',')[i])); }
                            }
                        }
                    } $(ImageGalleryMultiParentID + " #hdArrImage").val($.trim($(ImageGalleryMultiParentID + " #hdArrImage").val()) + $.trim(str)); $.ajax({
                        type: "POST", url: getBaseURL() + 'admin/Components/ImageGallery/ListImg.ashx?id=' + str, success: function (mess) { $(ImageGalleryMultiParentID + " #listimg").append(mess); }, error: function (errormessage) {
                            alert("Chức năng này đang được nâng cấp. Mời bạn quay lại sau.");
                        }
                    });
                }
            }); $dialog.dialog('open');
        }
        $(ImageGalleryMultiParentID + " #listimg").ajaxComplete(function (event, request, settings) {
            $(ImageGalleryMultiParentID + " span.imgCount").text("(hiện có " + $(ImageGalleryMultiParentID + " #listimg .item").length + " ảnh)"); $(ImageGalleryMultiParentID + " #hdArrImage").val($(ImageGalleryMultiParentID + " #hdArrImage").val().replace(',,', ","));
            var _width = 0; $(ImageGalleryMultiParentID + " #listimg .item").each(function () {
                _width += parseInt($(this).outerWidth(true));
            });
            $(ImageGalleryMultiParentID + " #listimg").css("width", _width + "px");
            if (parseInt($(ImageGalleryMultiParentID + " #listimg").parent().innerWidth()) < parseInt(_width)) { $(ImageGalleryMultiParentID + " #listimg").parent().css("height", "114px"); } $(ImageGalleryMultiParentID + " div.img-del").click(function () {
                $(ImageGalleryMultiParentID + " #hdArrImage").val($(ImageGalleryMultiParentID + " #hdArrImage").val().replace($.trim($(this).attr("val")), "")); $(ImageGalleryMultiParentID + " #listimg").css("width", (parseInt($(ImageGalleryMultiParentID + " #listimg").css("width")) - parseInt($("#" + $(this).attr("id")).parent().outerWidth(true))) + "px"); $("#" + $(this).attr("id")).parent().remove(); if (parseInt($(ImageGalleryMultiParentID + " #listimg").parent().innerWidth()) > parseInt($(ImageGalleryMultiParentID + " #listimg").css("width"))) { $(ImageGalleryMultiParentID + " #listimg").parent().css("height", "105px"); } $(ImageGalleryMultiParentID + " #hdArrImage").val($(ImageGalleryMultiParentID + " #hdArrImage").val().replace(',,', ",")); $(ImageGalleryMultiParentID + " span.imgCount").text("(hiện có " + $(ImageGalleryMultiParentID + " #listimg .item").length + " ảnh)");
            }); $(ImageGalleryMultiParentID + " #listimg").sortable({ revert: true, stop: function (event, ui) { var s = ""; $(ImageGalleryMultiParentID + " #listimg .item").each(function () { s += "," + $.trim($(this).find("img").attr("id")); }); $(ImageGalleryMultiParentID + " #hdArrImage").val(s); $(ImageGalleryMultiParentID + " #hdArrImage").val($(ImageGalleryMultiParentID + " #hdArrImage").val().replace(',,', ",")); } }); $(ImageGalleryMultiParentID + " #listimg, " + ImageGalleryMultiParentID + " #listimg .item").disableSelection();
        }); $(ImageGalleryMultiParentID + " #imageClick").click(function () { var _url = getBaseURL() + "admin/Components/ImageGallery/ImageManager.aspx?l=" + lang; SelectPhotoMuti1(_url); fixgalleryimage(); }); if ($(ImageGalleryMultiParentID + " #hdArrImage").val() != "") { $.ajax({ type: "POST", url: getBaseURL() + 'admin/Components/ImageGallery/ListImg.ashx?id=' + $.trim($(ImageGalleryMultiParentID + " #hdArrImage").val()), success: function (mess) { $(ImageGalleryMultiParentID + " #listimg").append(mess); }, error: function (errormessage) { alert("Chức năng này đang được nâng cấp. Mời bạn quay lại sau."); } }); }
    };
}); function fixgalleryimage() { var height = screen.height; if (height > 600) $(".ui-dialog").addClass("fixed"); }