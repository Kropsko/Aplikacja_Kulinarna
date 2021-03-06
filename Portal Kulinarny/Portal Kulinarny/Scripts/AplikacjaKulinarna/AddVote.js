﻿var clickedFlag = false;
$(".ratingStar").mouseover(function () {

    var stars = $(this).attr("src", "/Images/Default/ActiveStar.gif").prevAll("img.ratingStar");
    var rateWord = $(".rateWord");

    switch (stars.length + 1) {
        case 1:
            rateWord.text("Słaba");
            break;

        case 2: rateWord.text("Przeciętna");
            break;

        case 3: rateWord.text("Dobra");
            break;

        case 4: rateWord.text("Bardzo dobra");
            break;

        case 5: rateWord.text("Wyśmienita");
            break;

        default: rateWord.text("");
            break;

    }
    stars.attr("src", "/Images/Default/ActiveStar.gif");

});

$(".ratingStar, #radingDiv").mouseout(function () {
    $(this).attr("src", "/Images/Default/ActiveStar.gif");
    $(".rateWord").text("");
});

$("#ratingDiv").mouseout(function () {
    if (!clickedFlag) {
        $(".ratingStar").attr("src", "/Images/Default/ActiveStar.gif");
    }
});

$(".ratingStar").click(function () {
    clickedFlag = true;
    $(".rateWord").text("");

    $(".ratingStar").unbind("mouseout mouseover click").css("cursor", "default");

    var pageUrl = $(".rateWord").data("url");
    var model = $(".rateWord").data("model");

    var url = "/Home/SendRating?r=" + $(this).attr("data-value") + "&s=5&id=" + model + "&url=" + pageUrl;

    var url1 = "/Recipes/CountVotesFromId?id=" + model;

    $.post(url, null, function (data) {
        $(".rateWord").html(data);
        next();
    });

    function next() {
        $.post(url1, null, function (data) {
            $("#voteRating").html(data);
        });
    }
});


$(".rateWord").ajaxStart(function () {
    $(".rateWord").html("Przetwarzanie ....");
});

$(".rateWord").ajaxError(function () {
    $(".rateWord").html("<br />Wystąpił bład.");
});