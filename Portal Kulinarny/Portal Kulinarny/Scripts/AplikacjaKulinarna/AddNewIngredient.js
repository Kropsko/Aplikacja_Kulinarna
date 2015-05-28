$(function () {
    $("#AddIngredient").click(function (e) {
        e.preventDefault();
        $.get('/Recipes/IngredientEntryRow', function (template) {
            $("#IngredientEditor").append(template);

        })
            .fail(function () {
                alert("error");
            });
    });
});