var searchlink = getBaseURL() + "vi/{0}/search.html";
var webservice = getBaseURL() + "WebService/{0}";
$(document).ready(function () {

    //$(".captraBlock input[type=text]").attr("defaultvalue", "Введите код");
    $("#captcha input[type=text]").val("Введите код");
    $("#captcha input[type=text]").focus(function () {

        $(this).filter(function () {
            return $(this).val() == "" || $(this).val() == "Введите код";

        }).val("");

    });
    $("input[type=text],textarea").each(function () {
        $(this).val($(this).val() == '' ? $(this).attr("defaultvalue") : $(this).val());
    }).live("focusin focusout keyup keydown", function (event) {
        var defaultvalue = $(this).attr("defaultvalue");
        if (event.type == "focusin") {
            if ($(this).val() == defaultvalue) {
                $(this).val("");
            }
        }
        if (event.type == "focusout") {
            if ($(this).val() == "") {
                $(this).val(defaultvalue);
            }
        }
        if (event.type == "keyup") {
            if ($(this).val() == defaultvalue || $(this).val() == "") {
                $(this).next().removeAttr("href");

            } else
                $(this).next().attr("href", searchlink.replace("{0}", $(this).val()));
        }
        if ($("#SearchContent").attr("id") != undefined && "keydown".match(event.type) != '') {
            if (event.keyCode == 13) {
                event.stopPropagation();
                event.preventDefault();
                if ($(this).val() != defaultvalue && $(this).val() != "")
                    window.location = $(this).next().attr("href");
            }
        }

    });
    $('.orderby .asc,.orderby .desc').live("click", function () {
        var a = $(this).parent();
        $(".orderby.select").removeClass("select");
        if ($(this).hasClass("asc") && a.hasClass("desc"))
            a.removeClass("desc");
        if ($(this).hasClass("desc"))
            a.addClass("desc");
        $("." + a.parent().attr("class") + " input").removeAttr("checked");
        a.addClass("select").next().children().attr("checked", "checked");
        $.jcookie("direct", $(this).attr("class"));
    });
    $("#ctl00_cphMain_sr1_AdvanceOption1_txtKeyword").live("keydown", function (event) {
        if (event.keyCode == 13) {
            event.stopPropagation();
            event.preventDefault();
        }
    });
    $(".scViewInfo a").live("click", function (event) {
        event.preventDefault();
        var target = $($(this).attr("href"));
        var offSetTop = target.offset().top;
        $('html,body').stop().animate({ scrollTop: offSetTop }, offSetTop, 'easeInOutCirc');
    });
});
function CheckSearchValue() {
    var a = $("#ctl00_cphMain_sr1_AdvanceOption1_txtKeyword");
    if (a.val() == a.attr("defaultValue") || a.val() == "") {
        return false;
    }
}
