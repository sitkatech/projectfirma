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

    angular.module("ProjectFirmaApp").directive("pmqtip",
        function($compile, $templateCache) {
            function link(scope, el, attr) {
                var performanceMeasure = scope.text;
                ProjectFirma.Views.Methods.addHelpTooltipPopup(el,
                    performanceMeasure.DisplayName,
                    performanceMeasure.DefinitionAndGuidanceUrl,
                    800);
            }

            return {
                link: link,
                scope: {
                    text: "=pmqtip"
                }
            };
        });
}());

