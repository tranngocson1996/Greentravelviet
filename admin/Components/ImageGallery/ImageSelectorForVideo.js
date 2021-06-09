$(document).ready(function () {
    //var lang = $("#UpVideo1_hdfLangManager").val();
    var lang = $("#hdfLangForVideo").val();
    if ($.trim(lang) == 'undefined')
        lang = 'vi';
    $("body #ImageGallerySelect").each(function(index) {
        $(this).replaceWith("<div class='ImageGallerySelectParent' id='ImageGallerySelectParent" + index + "'>" + $(this).html() + "</div>");
        imgSelectSingle("#ImageGallerySelectParent" + index);
    });
    var titlePage;
    var mes1;
    var mes2;
    switch (lang) {
        case 'ru':
            titlePage = 'Фотогалерея';
            mes1 = 'Функция обновления.';
            mes2 = 'Вы уверены?';
            break;
        case 'en':
            titlePage = 'Gallery manager ';
            mes1 = 'Updating function.';
            mes2 = 'Are you sure?';
            break;
        default:
            titlePage = 'Thư viện ảnh';
            mes1 = 'Chức năng này đang được nâng cấp. Mời bạn quay lại sau.';
            mes2 = 'Bạn chắc chắn muốn xóa ảnh này?';
    }
    function imgSelectSingle(imageGallerySelectParentId) {
        function selectPhotoMuti(url) {
            var $dialog = $.FrameDialog.create({ url: url, loadingClass: 'loading-image', title: titlePage, width: 690, height: 570, autoOpen: false, resizable: false }).bind('dialogclose', function (event, ui) {
                var imgArr = event.result;
                if (imgArr != null) {
                    var str = "";
                    if (imgArr["imgID"] != undefined) {
                        str = (str == "" ? "" : ",") + imgArr["imgID"];
                    } else {
                        str = imgArr;
                    }
                    $(imageGallerySelectParentId + " #hdImageID").val(str);
                    ajaxImage(str);
                }
            });
            $dialog.dialog('open');
        }

        function ajaxImage(id) {
            $.ajax({
                type: "POST", url: getBaseURL() + 'admin/Components/ImageGallery/ListImg.ashx?id=' + id + '&ismulti=0' + '&l=' + lang,
                success: function (mess) {
                    $(imageGallerySelectParentId + " .image-selector").empty();
                    $(imageGallerySelectParentId + " .image-selector").html(mess);
                },
                error: function (errormessage) { alert(mes1); }
            });
        }

        if ($(imageGallerySelectParentId + " #hdImageID").val() != "") {
            ajaxImage($.trim($(imageGallerySelectParentId + " #hdImageID").val()));
        }
        $(imageGallerySelectParentId + " .image-selector").ajaxComplete(function (event, request, settings) {

            if (settings.url.match("ismulti")) {
                $(imageGallerySelectParentId + " div.image-del").click(function () {
                    if (confirm(mes2)) {
                        ajaxImage("0");
                        $(imageGallerySelectParentId + " #hdImageID").val("0");
                    }
                });
                $(imageGallerySelectParentId + " .image-selector img.imgSelect").unbind("click").bind("click", function () {
                    var _url = getBaseURL() + "admin/Components/ImageGallery/ImageManagerForVideo.aspx?ismulti=0" + "&l=" + lang;//Đoạn này là mở khi click vào phần chọn ảnh
                    selectPhotoMuti(_url);
                    fixgalleryimage();
                    return false;
                });
            }
        });
    }

    ;
});

function fixgalleryimage() {
    //var height = 500;
    //if (height > 600) $(".ui-dialog").addClass("fixed");
}