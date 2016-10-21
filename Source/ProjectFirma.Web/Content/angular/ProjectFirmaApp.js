(function () {
    "use strict";
    // create the angular app
    angular.module("ProjectFirmaApp", [
        "ng-currency",
        "server-validate",
        "ui.bootstrap"
    ]);

    angular.module("ProjectFirmaApp").filter("nfcurrency", ["$filter", "$locale", function ($filter, $locale) {
        var currency = $filter("currency"), formats = $locale.NUMBER_FORMATS;
        return function (amount, symbol) {
            var value = currency(amount, symbol);
            if (Sitka.Methods.isUndefinedNullOrEmpty(value))
            {
                return value;
            }
            return value.replace(new RegExp("\\" + formats.DECIMAL_SEP + "\\d{2}"), "");
        };
    }]);
}());

