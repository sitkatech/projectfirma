function convertJQueryValidationErrorsToQtip() {
    // Run this function for all validation error messages
    $('.field-validation-error').each(function () {
        // Get the name of the element the error message is intended for
        // Note: ASP.NET MVC replaces the '[', ']', and '.' characters with an
        // underscore but the data-valmsg-for value will have the original characters
        var idText = $(this).attr('data-valmsg-for').replace('.', '_').replace('[', '_').replace(']', '_');
        var inputElem = '#' + idText;

        //if the input select is overridden by bootstrap-select, need to grad the data-id instead
        if ($(inputElem).hasClass("selectpicker")) {            
            inputElem = $('[data-id=' + idText+']');
        }

        var corners = ['right center', 'left center'];
        var flipIt = $(inputElem).parents('span.right').length > 0;

        // Hide the default validation error
        $(this).hide();     

        // Show the validation error using qTip
        $(inputElem).filter(':not(.valid)').qtip({
            content: { text: $(this).text() }, // Set the content to be the error message
            position: {            
                my: corners[flipIt ? 0 : 1],
                at: corners[flipIt ? 1 : 0],
                viewport: $(window)
            },
            show: { ready: true },
            hide: false,
            style: { classes: 'ui-tooltip-red' }
        });       
    });
}

convertJQueryValidationErrorsToQtip();