$(document).ready(function() {$("#accordion").accordion({
        autoHeight: false,
        navigation: true,
        change: function(event, ui) {var oldId = $(ui.oldContent);oldId.find("input:text").val(" ");}
    });window.parent.$('#tabs > ul > li').removeClass('selected');window.parent.$('#lnkupload').parent().addClass('selected');$('.edit-category').live("click", function() {window.parent.$('#tabs > ul > li').removeClass('selected');window.parent.$('#lnkcategory').parent().addClass('selected');});$(".ruRename").live("click", function() {$(this).parent().find("br").show();$(this).parent().find(".inputUpload").show();$(this).parent().find(".labelUpload").show();}); //$(".ruDropZone").before("<span class='help-drop'>Kéo thả ảnh vào đây</span>");
});//<![CDATA[
var telerik = $telerik.$;
function pageLoad() {if (!Telerik.Web.UI.RadAsyncUpload.Modules.FileApi.isAvailable()) {telerik(".telerik").replaceWith(
    telerik("<span class='drop'>Trình duyệt của bạn không hỗ trợ kéo thả ảnh để upload.</span>"));$(".help-drop").remove();}}
function added(sender, args) {if (Telerik.Web.UI.RadAsyncUpload.Modules.FileApi.isAvailable()) {telerik(".ruDropZone").html("<span>THẢ FILE UPLOAD TẠI ĐÂY</span>");}$(".help-drop").remove();$(".ruDropZone").before("<span class='help-drop'>Kéo thả ảnh vào đây</span>");}
function onClientFileUploaded(radAsyncUpload, args) {var $row = telerik(args.get_row());var inputName = radAsyncUpload.getAdditionalFieldID("TextBox");var inputType = "text";var inputID = inputName;var input = createInput(inputType, inputID, inputName);var label = createLabel(inputID);$row.append("<input type='button' value='Đổi tên' class='ruButton ruRename'>");$row.append("<br style='display:none'/>");$row.append(label);$row.append(input);}
function createInput(inputType, inputID, inputName) {var input = '<input type="' + inputType + '" id="' + inputID + '" name="' + inputName + '" style="display:none" class="inputUpload"/>';return input;}
function createLabel(forArrt) {var label = '<label for=' + forArrt + ' style="display:none" class="labelUpload">Tên ảnh: </label>';return label;}
function validationFailed(sender, eventArgs) {$(".ErrorHolder").append("<p>Định dạng ảnh '" + eventArgs.get_fileName() + "' không đúng.</p>").fadeIn("slow");}
//]]>