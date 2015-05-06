$(function () {
    $("#AddIngredient").click(function (e) {
        e.preventDefault();
        $.get('/Recipes/IngredientEntryRow', function (template) {
            $("#IngredientEditor").append(template);

            var newNameField = ($('[data-url]', template).attr('id'));

            $("#" + newNameField).autocomplete({
                minLength: 0,
                source: function (request, response) {
                    var url = $(this.element).data('url');

                    $.getJSON(url, { term: request.term }, function (data) {
                        response(data);
                    });
                }
            });
        })
            .fail(function () {
                alert("error");
            });
    });
});