$(document).ready(function(){
    function selectuser(txtInput, img, list, alt){
        $(img).toggle(function(){
            $.ajax({
                type : "POST",
                url : getBaseURL() + 'admin/Components/Document/ListUser.ashx',
                success : function(mess){
                    $(alt).html(" ").removeClass("listuser");
                    $(list).addClass("listuser").html(mess);
                }
            });
        }, function(){
            if($(list).hasClass("listuser"))
                $(list).html(" ").removeClass("listuser");
            else{
                $.ajax({
                    type : "POST",
                    url : getBaseURL() + 'admin/Components/Document/ListUser.ashx',
                    success : function(mess){
                        $(alt).html(" ").removeClass("listuser");
                        $(list).addClass("listuser").html(mess);
                    },
                });
            }
        }).ajaxComplete(function(event, request, settings){
            if(list == "#listuserview")
                $(list).css("top", "395px");
            else
                $(list).css("top", "250px");
            checkAll(list + " #checkkall", '#browser');

            function addUser(userid, controlID){
                $(userid).click(function(){
                    if($(this).is(":checked")){
                        if( ! $(controlID).val().match($.trim($(this).val()))){
                            $("div.match").remove();
                            $(controlID).val($(controlID).val() + ($(controlID).val() == "" ? "" : ",") + $(this).val());
                        }
                        else{
                            $("div.match").remove();
                            $(controlID).before("<div class='match'> Nhóm hoặc tài khoản <span style='color:red'>" + username + "</span> đã được thêm rồi.</div>");
                        }
                        if($(this).hasClass("roles")){
                            var rolesid = "#" + $("#" + $(this).attr("id")).parent().parent("li").attr("id");
                            $(rolesid).find(':checkbox').attr('checked', true);
                            $(rolesid).find("input.user").each(function(){
                                $(controlID).val($(controlID).val().replace($(this).val(), ""));
                            })
                        }
                        $(controlID).val($(controlID).val().replace(",,", ","));
                        if($(controlID).val().indexOf(',') == 0)
                            $(controlID).val($(controlID).val().substring(1, $(controlID).val().length));
                        if($(controlID).val().lastIndexOf(',') == $(controlID).val().length)
                            $(controlID).val($(controlID).val().substring(0, $(controlID).val().length - 1));
                        if($(this).hasClass("user")){
                            if($(this).parent().parent("ul").find("input:checked").length == $(this).parent().parent("ul").find("input").length)
                                $(this).parent().parent("ul").prev("span").find("input.roles").attr('checked', true);
                        }
                    }
                    else{
                        if($(this).hasClass("roles")){
                            var rolesid = "#" + $("#" + $(this).attr("id")).parent().parent("li").attr("id");
                            $(rolesid).find(':checkbox').attr('checked', false);
                            $(rolesid).find("input.user").each(function(){
                                $(controlID).val($(controlID).val().replace($(this).val(), ""));
                            })
                        }
                        $(controlID).val($(controlID).val().replace($(this).val(), ""));
                        $(controlID).val($(controlID).val().replace(",,", ","));
                        if($(controlID).val().indexOf(',') == 0)
                            $(controlID).val($(controlID).val().substring(1, $(controlID).val().length));
                        if($(controlID).val().lastIndexOf(',') == $(controlID).val().length - 1)
                            $(controlID).val($(controlID).val().substring(0, $(controlID).val().length - 1));
                        if($(this).parent().parent("ul").find("input:checked").length < $(this).parent().parent("ul").find("input").length)
                            $(this).parent().parent("ul").prev("span").find("input.roles").attr('checked', false);
                        if($(this).parent().parent("ul").find("input:checked").length <= 0){
                            $(this).parent().parent("ul").prev("span").find("input.roles").attr('checked', false);
                            $(controlID).val($(controlID).val().replace($(this).parent().parent("ul").prev("span").find("input.roles").val(), ""));
                        }
                    }
                });
            }
            if($(txtInput).val() != ""){
                $(list + " input").each(function(index){
                    if($(txtInput).val().match($.trim($(this).val()))){
                        $(this).attr('checked', true);
                        if($(this).hasClass("roles")){
                            var rolesid = "#" + $("#" + $(this).attr("id")).parent().parent("li").attr("id");
                            $(rolesid).find(':checkbox').attr('checked', true);
                        }
                    }
                });
            }
            $(list + " #checkkall").click(function(){
                if($(this).is(":checked")){
                    $(txtInput).val("");
                    $(list + " ul li input.roles").each(function(index){
                        $(txtInput).val($(txtInput).val() + (index == 0 ? "" : ",") + $(this).val());
                    });
                }
                else{
                    $(txtInput).val("");
                }
            });
            addUser(list + " ul li .roles", txtInput);
            addUser(list + " .user", txtInput);
        });
    }

    selectuser("#txtUserNameView", "#imgview", "#listuserview", "#listuseredit");

    selectuser("#txtUserNameEdit", "#imgedit", "#listuseredit", "#listuserview");

    $(".input-area").focus(function(){
        $("#listuserview").html(" ").removeClass("listuser");
        $("#listuseredit").html(" ").removeClass("listuser");
    });

    function checkAll(id, div){
        $(id).click(function(){
            $(div).find(':checkbox').attr('checked', this.checked);
        });
    }
    function Ajax(username, id, err){
        var nameview = $(id);
        $.ajax({
            type : "POST",
            url : getBaseURL() + 'WebService/Register.asmx/checkuser',
            data : "{'username':'" + username + "'}",
            contentType : "application/json; charset=utf-8",
            dataType : "json",
            success : function(mess){
                if( ! mess.d){
                    $("div." + err).remove();
                    nameview.before("<div class='" + err + "'> Nhóm hoặc tài khoản <span style='color:red'>" + username + "</span> không tồn tại.</div>");
                    nameview.val(nameview.val().substring(0, (nameview.val().indexOf(username)) - 1));
                }
                else
                    $("div." + err).remove();
            },
            error : function(errormessage){
                //alert(errormessage.responseText);
            }
        });
    };
    function ignoreSpaces(string){
        var temp = "";
        string = '' + string;
        splitstring = string.split(" ");
        for(i = 0; i < splitstring.length; i ++ )
            temp += splitstring[i];
        return temp;
    }
    
    function permistion(id, err){
        $(id).autocomplete(getBaseURL() + "admin/Components/Document/Handler.ashx",
        {
            minChars : 1,
            delay : 200,
            multiple : true,
            multipleSeparator : ",",
            striped : 'auto-complete-striped'
        }).keydown(function(e){
            if((e.which == 188 || e.which == 13) && $(id).val() != ""){
                var str = $.trim($(id).val());
                if(str.split(',').length > 1){
                    for(var i = 0; i < str.split(',').length; i ++ ){
                        if(str.split(',')[i] != "")
                            Ajax($.trim(str.split(',')[i]), id, err);
                    }
                }
                else
                    Ajax(str.replace(',', ""), id, err);
            }
        }).blur(function(){
            var str = $.trim($(id).val());
            if(str.split(',').length > 1){
                for(var i = 0; i < str.split(',').length; i ++ ){
                    if(str.split(',')[i] != "")
                        Ajax($.trim(str.split(',')[i]), id, err);
                }
            }
            else{
                Ajax(str.replace(',', ""), id, err);
            }
            if(str != ""){
                $("input").each(function(index){
                    if($(this).is(":checked")){
                        if( ! str.match($.trim($(this).val())))
                            $(this).attr('checked', false);
                    }
                });
            }
            if($(id).val().lastIndexOf(',') == $(id).val().length - 1)
                $(id).val($(id).val().substring(0, $(id).val().length - 1));
        });
    }
    
    permistion("#txtUserNameView", "err1");
    permistion("#txtUserNameEdit", "err2");
});