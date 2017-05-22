/*-----------------------------------------------------------------------
<copyright file="EditSubcategoriesAndOptionsController.js" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
<author>Sitka Technology Group</author>
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
//# sourceURL=EditSubcategoriesAndOptionsController.js
angular.module("ProjectFirmaApp")
    .controller("EditSubcategoriesAndOptionsController",
        function($scope, $timeout, angularModelAndViewData)
        {
            $scope.AngularModel = angularModelAndViewData.AngularModel;
            $scope.AngularViewData = angularModelAndViewData.AngularViewData;

            $scope.nextSubcategoryID = -1;
            $scope.nextOptionID = -1;

            // Iterate decrementing regative IDs for incoming records where ID is already negative
            _.chain($scope.AngularModel.PerformanceMeasureSubcategorySimples)
                .filter(function(subcategorySimple) { return subcategorySimple.PerformanceMeasureSubcategoryID < 0; })
                .each(function(subcategorySimple)
                {
                    subcategorySimple.PerformanceMeasureSubcategoryID = $scope.nextSubcategoryID --;
                });
            _.chain($scope.AngularModel.PerformanceMeasureSubcategorySimples)
                .map("PerformanceMeasureSubcategoryOptions")
                .flatten()
                .filter(function(optionSimple) { return optionSimple.PerformanceMeasureSubcategoryOptionID < 0; })
                .each(function(optionSimple)
                {
                    optionSimple.PerformanceMeasureSubcategoryOptionID = $scope.nextOptionID--;
                });

            $scope.addSubcategory = function()
            {
                $scope.AngularModel.PerformanceMeasureSubcategorySimples.push({
                    PerformanceMeasureSubcategoryID: $scope.nextSubcategoryID--,
                    PerformanceMeasureSubcategoryOptions: []
                });
            }

            $scope.removeSubcategory = function(subcategorySimple)
            {
                Sitka.Methods.removeFromJsonArray($scope.AngularModel.PerformanceMeasureSubcategorySimples,
                    subcategorySimple);
            }

            $scope.addSubcategoryOption = function(subcategorySimple)
            {
                subcategorySimple.PerformanceMeasureSubcategoryOptions.push({
                    PerformanceMeasureSubcategoryOptionID: $scope.nextOptionID--,
                    HasAssociatedActuals: false,
                    SortOrder: subcategorySimple.PerformanceMeasureSubcategoryOptions.length + 1
                });
            }

            $scope.removeSubcategoryOption = function(subcategorySimple, optionSimple)
            {
                Sitka.Methods.removeFromJsonArray(subcategorySimple.PerformanceMeasureSubcategoryOptions, optionSimple);
            }

            $scope.subcategoryHasAssociatedActuals = function(subcategorySimple)
            {
                return _.chain(subcategorySimple.PerformanceMeasureSubcategoryOptions)
                    .filter(function(optionSimple) { return optionSimple.HasAssociatedActuals; })
                    .any()
                    .value();
            }

            $scope.showSubcategoryValidationWarnings = function(subcategorySimple)
            {
                return _.any($scope.validateSubcategoryDisplayName(subcategorySimple));
            }

            $scope.validateSubcategoryDisplayName = function(subcategorySimple)
            {
                var errors = [];
                if (Sitka.Methods.isUndefinedNullOrEmpty(subcategorySimple.PerformanceMeasureSubcategoryDisplayName))
                {
                    errors.push("Please specify a name for the subcategory.");
                }
                else if (_.chain($scope.AngularModel.PerformanceMeasureSubcategorySimples)
                    .filter(function(x)
                    {
                        return x !== subcategorySimple &&
                            x.PerformanceMeasureSubcategoryDisplayName ===
                            subcategorySimple.PerformanceMeasureSubcategoryDisplayName;
                    })
                    .any()
                    .value())
                {
                    errors.push("Please specify a unique name for the subcategory.");
                }
                return errors;
            }

            $scope.moveSubcategoryUp = function (subcategorySimple, optionSimple) {
                var subcategoryOptionsForThisPerformanceMeasureSubcategory = _.find($scope.AngularModel.PerformanceMeasureSubcategorySimples,
                    function(x) {
                        return x.PerformanceMeasureSubcategoryID === subcategorySimple.PerformanceMeasureSubcategoryID;
                    }
                ).PerformanceMeasureSubcategoryOptions;

                var optionBeforeThis = _.chain(subcategoryOptionsForThisPerformanceMeasureSubcategory).filter(function(x) {
                    return x.SortOrder < optionSimple.SortOrder;
                }).sortBy(function (x) { return x.SortOrder; }).last().value();

                if (optionBeforeThis != null) {
                    optionBeforeThis.SortOrder++;
                }
                optionSimple.SortOrder--;
            }

            $scope.moveSubcategoryDown = function (subcategorySimple, optionSimple) {
                var subcategoryOptionsForThisPerformanceMeasureSubcategory = _.find($scope.AngularModel.PerformanceMeasureSubcategorySimples,
                    function (x) {
                        return x.PerformanceMeasureSubcategoryID === subcategorySimple.PerformanceMeasureSubcategoryID;
                    }
                ).PerformanceMeasureSubcategoryOptions;

                var optionAfterThis = _.chain(subcategoryOptionsForThisPerformanceMeasureSubcategory).filter(function (x) {
                    return x.SortOrder > optionSimple.SortOrder;
                }).sortBy(function(x) { return x.SortOrder; }).first().value();

                if (optionAfterThis != null) {
                    optionAfterThis.SortOrder--;
                }
                optionSimple.SortOrder++;
            }

            $scope.showOptionValidationWarnings = function(optionSimple)
            {
                return _.any($scope.validateOptionName(optionSimple)) ||
                    _.any($scope.validateOptionShortname(optionSimple));
            }

            $scope.validateOptionName = function(optionSimple)
            {
                var errors = [];
                if (Sitka.Methods.isUndefinedNullOrEmpty(optionSimple.PerformanceMeasureSubcategoryOptionName))
                {
                    errors.push("Please specify a name for the option.");
                }
                else if (_.chain($scope.AngularModel.PerformanceMeasureSubcategorySimples)
                    .filter(function(subcategorySimple)
                    {
                        return _.find(subcategorySimple.PerformanceMeasureSubcategoryOptions, optionSimple);
                    })
                    .map("PerformanceMeasureSubcategoryOptions")
                    .flatten()
                    .filter(function(x)
                    {
                        return x !== optionSimple &&
                            x.PerformanceMeasureSubcategoryOptionName ===
                            optionSimple.PerformanceMeasureSubcategoryOptionName;
                    })
                    .any()
                    .value())
                {
                    errors.push("Please specify a unique name for the subcategory.");
                }
                return errors;
            }

            $scope.validateOptionShortname = function(optionSimple)
            {
                var errors = [];
                if (!Sitka.Methods.isUndefinedNullOrEmpty(optionSimple.ShortName) &&
                    _.chain($scope.AngularModel.PerformanceMeasureSubcategorySimples)
                    .filter(function(subcategorySimple)
                    {
                        return _.find(subcategorySimple.PerformanceMeasureSubcategoryOptions, optionSimple);
                    })
                    .map("PerformanceMeasureSubcategoryOptions")
                    .flatten()
                    .filter(function(x) { return x !== optionSimple && x.ShortName === optionSimple.ShortName; })
                    .any()
                    .value())
                {
                    errors.push("Please specify a unique shortname for the subcategory.");
                }
                return errors;
            }

            $scope.$watch("AngularModel.PerformanceMeasureSubcategorySimples",
                function()
                {
                    var submitButton = jQuery("form")
                            .parents(".modal-dialog")
                            .find("#ltinfo-modal-dialog-save-button-id"),
                        subcategoryOptions = _.chain($scope.AngularModel.PerformanceMeasureSubcategorySimples)
                            .map("PerformanceMeasureSubcategoryOptions")
                            .value();

                    if ($scope.AngularModel.PerformanceMeasureSubcategorySimples.length > 0 &&
                        _.reduce(subcategoryOptions, function(a, b) { return a && (b.length > 0) }, true) > 0 &&
                        !_.some($scope.AngularModel.PerformanceMeasureSubcategorySimples,
                            $scope.showSubcategoryValidationWarnings) &&
                        !_.some(_.flatten(subcategoryOptions), $scope.showOptionValidationWarnings))
                    {
                        submitButton.prop("disabled", false);
                    }
                    else
                    {
                        submitButton.prop("disabled", true);
                    }
                },
                true);
        });
