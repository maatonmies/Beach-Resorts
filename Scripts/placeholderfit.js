//Set all input field sizes to match placeholder text

$(function () {

    $("input[placeholder]").each(function () {
        $(this).attr('size', $(this).attr('placeholder').length);
    });
});