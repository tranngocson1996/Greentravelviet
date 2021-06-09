$(document).ready(function(){ 
    $(".form-view .frow:not(.hidden):even").addClass("alt"); $('a.highslide').click(function () { return hs.expand(this, { wrapperClassName: 'highslide-black', outlineType: 'rounded-white', dimmingOpacity: 0.75, align: 'center' }); });
}); function fixgalleryimage() { var height = screen.height; if (height > 600) $(".ui-dialog").addClass("fixed"); } function Scroll(content, slider) { var maxScroll = content.attr("scrollWidth") - content.width(); if (maxScroll <= 0) { slider.parent().css("display", "none"); } slider.slider({ animate: true, change: function (e, ui) { var maxScroll = content.attr("scrollWidth") - content.width(); content.animate({ scrollLeft: ui.value * (maxScroll / 100) }, 1000); }, slide: function (e, ui) { var maxScroll = content.attr("scrollWidth") - content.width(); content.attr({ scrollLeft: ui.value * (maxScroll / 100) }); } }); } function UpdatePosition(columID, tableName, gridID) { $("#ddlCurrentPosition").live("click", function () { $("." + $(this).attr("class")).change(function () { var params = ""; var queryString = $.param(params); Ajax(queryString); }); }); function Ajax(queryString) { $.ajax({ type: "POST", url: getBaseURL() + 'admin/Service/UpdatePosition.ashx?' + queryString, success: function (mess) { }, error: function (errormessage) { } }); } } function getBaseURL() { var url = window.location.href; var baseUrl = url.substring(0, url.indexOf('/', 14)); var host = window.location.host; var indexadmin = window.location.pathname.split("/"); if (baseUrl.indexOf('http://' + host) != -1 && indexadmin[2] == "admin") { var pathname = location.pathname; var index1 = url.indexOf(pathname); var index2 = url.indexOf("/", index1 + 1); var baseLocalUrl = url.substr(0, index2); return baseLocalUrl + "/"; } else { return baseUrl + "/"; } }

//không cho gõ ký tự
function keypress(e) {
    var keypressed = null;
    if (window.event) {
        keypressed = window.event.keyCode; //IE
    }
    else {

        keypressed = e.which; //NON-IE, Standard
    }
    if (keypressed < 48 || keypressed > 57) {
        if (keypressed == 8 || keypressed == 127) {
            return;
        }
        return false;
    }
}