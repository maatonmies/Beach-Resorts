//Autocomplete for inputs

$(function () {

    var submitAutocompleteForm = function (event, ui) {

        var input = $(this);

        input.val(ui.item.label);

        var form = input.parents("form:first");

        form.submit();
    };

    var assignAutoCompleteAction = function () {

        var input = $(this);

        var action = {
            source: input.attr("data-autocomplete-action"),
            select: submitAutocompleteForm
        };

        //Jquery UI autocomplete method

        input.autocomplete(action);
    };

    

    $("input[data-autocomplete-action]").each(assignAutoCompleteAction);

});