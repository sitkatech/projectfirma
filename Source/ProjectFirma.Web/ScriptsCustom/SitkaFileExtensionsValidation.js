/*-----------------------------------------------------------------------
<copyright file="SitkaFileExtensionsValidation.js" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
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
