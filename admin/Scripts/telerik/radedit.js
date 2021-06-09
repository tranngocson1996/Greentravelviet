var RadEditor1ClientObject = null;

Telerik.Web.UI.Editor.CommandList["CustomImageManagement"] =
function CustomImageManagementCommand(commandName, editor, oTool) {
    var lang = $("#hdfLang").val();
    var $dialog = $.FrameDialog.create({
        url: 'Components/ImageGallery/ImageManager.aspx' + '?l=' + lang, //Đoạn này là mở ImageManager từ trong editor
        loadingClass: 'loading-image',
        title: 'Thư viện ảnh',
        width: 690,
        height: 570,
        autoOpen: false,
        resizable: false
    })
    .bind('dialogclose', function (event, ui) {
        imgArr = event.result;
        if (imgArr != null) {
            var str = "";
            if (imgArr["imgID"] != undefined) {
                str = "," + imgArr["imgID"];
            }
            else {
                str = imgArr;
            }
            $.ajax({
                type: "POST",
                url: 'Scripts/telerik/ListImageTelerik.ashx?id=' + str,
                success: function (mess) {
                    editor.pasteHtml(mess);
                },
                error: function (errormessage) {
                    //alert(errormessage.responseText);
                }
            });
        }
    });
    $dialog.dialog('open');
    fixgalleryimage();
};
Telerik.Web.UI.Editor.CommandList["InsertVideo"] =
function CustomImageManagementCommand(commandName, editor, oTool) {
    var $dialog = $.FrameDialog.create({
        url: 'Components/Video/VideoManager.aspx',
        loadingClass: 'loading-image',
        title: 'Thư viện video',
        width: 690,
        height: 510,
        autoOpen: false,
        resizable: false
    })
        .bind('dialogclose', function (event, ui) {
            videoArr = event.result;
            if (videoArr != null) {
                output = "Video:<br/><div  id='video" + videoArr['videoID'] + "'></div>";
                output = "<div class='wrap-viewer'><object width='" + videoArr['width'] + "' height='" + videoArr['height'] + "' type='application/x-shockwave-flash' data='"
                            + videoArr['urlRoot'] + "Scripts/jwplayer/player.swf' id='viewer" + videoArr['videoID'] + "' name='viewer'>";
                output += "<param name='allowfullscreen' value='true'><param name='allowscriptaccess' value='always'>";
                output += "<param name='wmode' value='opaque'>";
                output += "<param name='flashvars' value='id=viewer&amp;file="
                         + videoArr['videoPath'] + "&amp;";
                if (videoArr["imgID"] != '0') {
                    output += "image=" + videoArr["imgPath"];
                }
                output += "&amp;stretching=fill&amp;autostart=false&amp;controlbar.position=bottom&amp;skin="
                                 + videoArr['urlRoot'] + "Scripts/jwplayer/skin/bic/bic.xml'>";
                output += "</object></div>";
                //                output += videoArr['code'];
                editor.pasteHtml(output);
            }
        });
    $dialog.dialog('open');
    fixgalleryimage();
};
function GetImage() {
    var $dialog = $.FrameDialog.create({
        url: 'Components/ImageGallery/ImageManager.aspx',
        loadingClass: 'loading-image',
        title: 'Thư viện ảnh',
        width: 690,
        height: 570,
        autoOpen: false,
        resizable: false
    })
        .bind('dialogclose', function (event, ui) {
            imgArr = event.result;
            if (imgArr != null) {
                return imgArr;
            }
        });
    $dialog.dialog('open');
    fixgalleryimage();
}
function OnClientLoad(editor, args) {
    editor.attachEventHandler("onblur", function (e) {
        editor.set_html(editor.get_html().replace("../FileUpload/", getBaseURL() + "FileUpload/"));
        return false;
    });
}
