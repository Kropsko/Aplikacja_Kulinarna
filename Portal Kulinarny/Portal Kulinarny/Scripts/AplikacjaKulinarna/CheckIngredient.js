$(function () {
    $('form').submit(function (e) {
        var ingred = $('#IngredientEditor li INPUT[type = "text"]');

        if (ingred.length <= 0) {
            $("#validationJS").html("Lista składnikow nie może być pusta");
            e.preventDefault();
        }
        else if (ingred.length > 0) {
            ingred.each(function () {
                if ($(this).val().trim() == "") {
                    $("#validationJS").html("Składnik musi posiadać nazwę oraz ilość");
                    e.preventDefault();
                }
                if ($(this).attr("id").match(/_Quantity/) && !($(this).val().match(/^\d+[\.\,]{1}\d+$|^\d+\/{1}\d+$|^\d+\-{1}\d+$|^\d+$/))) {

                    $("#validationJS").html("Pole ilość musi zawierać wartość liczbową(liczba całkowitą, ułamek zwykły lub dziesiętny)");
                    e.preventDefault();
                }
            });
        }
    });
});
