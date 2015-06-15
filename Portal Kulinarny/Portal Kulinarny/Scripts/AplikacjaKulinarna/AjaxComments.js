function clearContent() {
    $("#Content").val('');
    $('#addComment').attr("disabled", "disabled");
}

$(function () {
    $("#Content").keyup(function () {
        if ($(this).val().trim() == '')
            $('#addComment').attr("disabled", "disabled");
        else
            $('#addComment').removeAttr("disabled");
    });
});

$(function () {
    $('#addComment').attr("disabled", "disabled");

});
