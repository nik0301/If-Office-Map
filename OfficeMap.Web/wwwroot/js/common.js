const showMessage = function (type, message) {
    $(".content .alert").remove();

    switch (type) {
        case "success":
            $(".content").prepend('<div class="alert bg-green">' + message + "</div>");

            setTimeout(function () {
                $(".content .alert").slideUp();
            }, 2000);
            break;
        case "error":
            $(".content").prepend(
                ['<div class="alert bg-red alert-dismissible">',
                    message,
                    '<button type="button" class="close" data-dismiss="alert">',
                    '<span aria-hidden="true">&times;</span>',
                    "</button>",
                    '</div>'].join(""));
            break;
        default:
            $(".content").prepend('<div class="alert bg-default">' + message + "</div>");

            setTimeout(function () {
                $(".content .alert").slideUp();
            }, 2000);
            break;
    }

    $(".content .alert").hide().fadeIn();
}

const clearFormErrors = function (input) {
    $(input).parent().find(".form-error").remove();
    $(input).removeClass("border-red");
}

const showFormError = function (input, msg, showBorder = true) {
    clearFormErrors(input);
    if (showBorder) {
        input.addClass("border-red");
    }
    input.after('<div><span class="text-red form-error">' + msg + '</span></div>');
}
