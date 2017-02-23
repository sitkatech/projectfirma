$(function () {
    jQuery.validator.unobtrusive.adapters.add("fileextensions", ["fileextensions"], function (options) {
        var params = {
            fileextensions: options.params.fileextensions.split(",")
        };

        options.rules["fileextensions"] = params;
        if (options.message) {
            options.messages["fileextensions"] = options.message;
        }
    });

    jQuery.validator.addMethod("fileextensions", function (value, element, param) {
        var extension = getFileExtension(value);
        var validExtension = $.inArray(extension, param.fileextensions) !== -1;
        return validExtension;
    });

    function getFileExtension(fileName) {
        var extension = (/[.]/.exec(fileName)) ? /[^.]+$/.exec(fileName) : undefined;
        if (extension != undefined) {
            return extension[0].toLowerCase();
        }
        return extension;
    };
}(jQuery));