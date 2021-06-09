$(document).ready(function () {
    var scrollbar = $("<div />").attr("class", "scrollbar");
    $("<div />").attr("class", "pointer ui-draggable").attr("style", "position: relative;").appendTo(scrollbar);
    $(".cagree .comment").live("click", function () {
        var cReply = $(this).parent().parent().parent().children(".cReply");
        if ($(this).hasClass("reply")) {
            $(this).removeClass("reply");
            cReply.children(".cSend").stop().slideUp();
        } else {
            $(this).addClass("reply");
            cReply.children(".cSend").stop().slideDown();
        }
    }).each(function () {
        var cReply = $(this).parent().parent().parent().children(".cReply");
        cReply.children(".cSend").hide();
        cReply.stop().slideDown();
        GetComments($(this).attr("value"), cReply.children(".scrollable").children(".scrollcontent"), scrollbar);
    });
    $(".cagree .agree,.cagree .disagree").live("click", function () {
        var a = 0;
        if ($(this).hasClass("disagree")) {
            a = 1;
        }
        var b = $(this).parent();
        $.ajax({
            url:  '/WebService/CommentReview.ashx?id=' + $(this).attr("value") + '&vote=' + a + '&aid=' + $(this).parent().children('.comment').attr("value"),
            success: function (response) {
                b.html(response);
            }, error: function () {
            }
        });
    });
});

function GetComments(a, b, c) {
    $.ajax({
        url:  '/WebService/Comment.ashx?id=' + a,
        success: function (response) {
            b.html(response);
            b.parent().height(b.height());
            if (b.height() > b.parent().height()) {
                b.before(c);
            }
        },
        error: function () {
            b.html(""); 
            }
    });
}