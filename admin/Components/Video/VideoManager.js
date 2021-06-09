$(document).ready(function () {
    window.parent.$('#tabs > ul > li').removeClass('selected'); window.parent.$('#lnkgalery').parent().addClass('selected');
    $("#frame_video .image").live("dblclick", function () {
        var count = true;
        var imgId1 = $.trim("," + $(this).find("#htmlImage").attr("class"));
        if (imgId1 == "") {
            count = false;
        }
        if (count) {
            $("#hdImg").val(imgId1);
            // window.parent.window.parent.$(".ui-dialog-titlebar-close .ui-icon-closethick").trigger("click");
            window.parent.jQuery.FrameDialog.closeDialog();
        }
        else {
            alert("Bạn chưa chọn video nào.");
        } return false;
    });
});