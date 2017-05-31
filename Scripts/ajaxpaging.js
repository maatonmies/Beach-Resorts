//Ajax Paging

$(function () {

    var getPage = function() {

        var a = $(this);

        var settings = {
            url: a.attr("href"),
            data: $("form").serialize(), //include form data of the page (search terms for example)
            type: "get"
        };

        $.ajax(settings).done(function(responseData) {

            var target = a.parents("div.pagedList").attr("data-update-target");

            $(target).replaceWith(responseData);

        });
        return false;
    };

    $(".body-content").on("click", "div.pagedList a", getPage);
});
