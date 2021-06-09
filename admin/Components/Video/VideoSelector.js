$(document).ready(function () {
    var lang = $("#hdfLang").val();
    $("body #VideoGallerySelect").each(function (index) {
        $(this).replaceWith("<div class='VideoGallerySelectParent' id='VideoGallerySelectParent" + index + "'>" + $(this).html() + "</div>");
        videoSelectSingle("#VideoGallerySelectParent" + index);
    });
    var titlePage;
    var mes1;
    switch (lang) {
        case 'ru':
            titlePage = 'Видеогалерея';
            mes1 = 'Вы уверены?';
            break;
        case 'en':
            titlePage = 'Video manager ';
            mes1 = 'Are you sure?';
            break;
        default:
            titlePage = 'Thư viện video';
            mes1 = 'Bạn chắc chắn muốn xóa ảnh này?';
    }
    function videoSelectSingle(videoGallerySelectParentId) {
        function selectVideoMuti(url) {
            var $dialog = $.FrameDialog.create({ url: url, loadingClass: 'loading-Video', title: titlePage, width: 690, height: 570, autoOpen: false, resizable: false, dialogClass: "videoid" })
                .bind('dialogclose', function (event, ui) {
                    var id = $(".videoid .ui-dialog-content").attr("id") + '-VIEW';
                    var iframeParent = document.getElementById(id);
                    var subIframe = iframeParent.contentWindow.document.getElementById('ifLoad');
                    var hdImg = subIframe.contentWindow.document.getElementById('hdImg');
                    if (hdImg.value != "") {
                        var str = hdImg.value; $(videoGallerySelectParentId + " #hdVideoID").val($.trim(str.replace(',', '')));
                        ajaxVideo(str);
                    }
                }); $dialog.dialog('open');
        }
        function ajaxVideo(id) {
            $.ajax({
                type: "POST", url: getBaseURL() + 'admin/Components/Video/ListImg.ashx?id=' + id, success: function (mess) {
                    $(videoGallerySelectParentId + " .Video-selector").empty();
                    $(videoGallerySelectParentId + " .Video-selector").html(mess);
                }, error: function (errormessage) { /*alert(errormessage.responseText);*/ }
            });
        }
        if ($(videoGallerySelectParentId + " #hdVideoID").val() != "") {
            ajaxVideo($.trim($(videoGallerySelectParentId + " #hdVideoID").val()));
        }
        $(videoGallerySelectParentId + " .Video-selector").ajaxComplete(function (event, request, settings) {
            $(videoGallerySelectParentId + " div.image-del").live("click", function () {
                if (confirm(mes1)) {
                    ajaxVideo("0");
                    $(videoGallerySelectParentId + " #hdVideoID").val("0");
                }
            });
            $(videoGallerySelectParentId + " .Video-selector img.imgSelect").unbind("click").bind("click", function () {
               var url = getBaseURL() + "admin/Components/Video/VideoManager.aspx" + "?l=" + lang;
                selectVideoMuti(url);
                fixgalleryVideo();
                return false;
            });
        });
    };
});
function fixgalleryVideo() {
    var height = screen.height; if (height > 600) $(".ui-dialog").addClass("fixed");
}