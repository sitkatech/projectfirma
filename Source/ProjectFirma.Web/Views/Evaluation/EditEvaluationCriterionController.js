/*-----------------------------------------------------------------------
<copyright file="EditEvaluationCriterionController.js" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
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
//# sourceURL=EditEvaluationCriterionController.js
angular.module("ProjectFirmaApp")
    .controller("EditEvaluationCriterionController",
        function($scope, $timeout, angularModelAndViewData) {
            //debugger;
            $scope.AngularModel = angularModelAndViewData.AngularModel;
            $scope.AngularViewData = angularModelAndViewData.AngularViewData;


            $scope.nextValueID = -1;

            // Iterate decrementing negative IDs for incoming records where ID is already negative
            //_.chain($scope.AngularModel.PerformanceMeasureSubcategorySimples)
            //    .filter(function(subcategorySimple) { return subcategorySimple.PerformanceMeasureSubcategoryID < 0; })
            //    .each(function(subcategorySimple)
            //    {
            //        subcategorySimple.PerformanceMeasureSubcategoryID = $scope.nextSubcategoryID --;
            //    });
            //_.chain($scope.AngularModel.PerformanceMeasureSubcategorySimples)
            //    .map("PerformanceMeasureSubcategoryOptions")
            //    .flatten()
            //    .filter(function(valueSimple) { return valueSimple.PerformanceMeasureSubcategoryOptionID < 0; })
            //    .each(function(valueSimple)
            //    {
            //        valueSimple.PerformanceMeasureSubcategoryOptionID = $scope.nextOptionID--;
            //    });


            $scope.addEvaluationCriterionValue = function()
            {
                console.log("adding evaluation criterion value")
                $scope.AngularModel.EvaluationCriterionValueSimples.push({
                    EvaluationCriterionValueID: $scope.nextValueID--,
                    HasAssociatedActuals: false,
                    SortOrder: $scope.AngularModel.EvaluationCriterionValueSimples.length + 1
                });
                //debugger;
            }

            $scope.removeEvaluationCriterionValue = function(valueSimple)
            {
                Sitka.Methods.removeFromJsonArray($scope.AngularModel.EvaluationCriterionValueSimples, valueSimple);
            }

            //$scope.subcategoryHasAssociatedActuals = function(subcategorySimple)
            //{
            //    return _.chain(subcategorySimple.PerformanceMeasureSubcategoryOptions)
            //        .filter(function(valueSimple) { return valueSimple.HasAssociatedActuals; })
            //        .any()
            //        .value();
            //}

            $scope.showSubcategoryValidationWarnings = function(subcategorySimple)
            {
                return _.any($scope.validateSubcategoryDisplayName(subcategorySimple));
            }

            //$scope.validateSubcategoryDisplayName = function(subcategorySimple)
            //{
            //    var errors = [];
            //    if (Sitka.Methods.isUndefinedNullOrEmpty(subcategorySimple.PerformanceMeasureSubcategoryDisplayName))
            //    {
            //        errors.push("Please specify a name for the subcategory.");
            //    }
            //    else if (_.chain($scope.AngularModel.PerformanceMeasureSubcategorySimples)
            //        .filter(function(x)
            //        {
            //            return x !== subcategorySimple &&
            //                x.PerformanceMeasureSubcategoryDisplayName ===
            //                subcategorySimple.PerformanceMeasureSubcategoryDisplayName;
            //        })
            //        .any()
            //        .value())
            //    {
            //        errors.push("Please specify a unique name for the subcategory.");
            //    }
            //    return errors;
            //}

            $scope.moveCriterionValueUp = function (valueSimple) {
                var valuesForThisEvaluationCriterion = $scope.AngularModel.EvaluationCriterionValueSimples;

                var optionBeforeThis = _.chain(valuesForThisEvaluationCriterion).filter(function(x) {
                    return x.SortOrder < valueSimple.SortOrder;
                }).sortBy(function (x) { return x.SortOrder; }).last().value();

                if (optionBeforeThis != null) {
                    optionBeforeThis.SortOrder++;
                }
                valueSimple.SortOrder--;
            }

            $scope.moveCriterionValueDown = function (valueSimple) {
                var valuesForThisEvaluationCriterion = $scope.AngularModel.EvaluationCriterionValueSimples;

                var optionAfterThis = _.chain(valuesForThisEvaluationCriterion).filter(function (x) {
                    return x.SortOrder > valueSimple.SortOrder;
                }).sortBy(function(x) { return x.SortOrder; }).first().value();

                if (optionAfterThis != null) {
                    optionAfterThis.SortOrder--;
                }
                valueSimple.SortOrder++;
            }

            $scope.showOptionValidationWarnings = function(valueSimple)
            {
                return _.any($scope.validateOptionName(valueSimple)) ||
                    _.any($scope.validateOptionShortname(valueSimple));
            }

            $scope.validateValueRating = function(valueSimple)
            {
                var errors = [];
                if (Sitka.Methods.isUndefinedNullOrEmpty(valueSimple.EvaluationCriterionValueRating))
                {
                    errors.push("Please specify a rating for the value.");
                }

                return errors;
            }

            $scope.validateValueDescription = function (valueSimple) {
                var errors = [];
                if (Sitka.Methods.isUndefinedNullOrEmpty(valueSimple.EvaluationCriterionValueDescription)) {
                    errors.push("Please specify a description for the value.");
                }

                return errors;
            }


            //$scope.$watch("AngularModel.EvaluationCriterionValueSimples",
            //    function() {
            //        var submitButton = jQuery("form").parents(".modal-dialog").find("#ltinfo-modal-dialog-save-button-id");
            //        var subcategoryOptions = _.chain($scope.AngularModel.EvaluationCriterionValueSimples).map("PerformanceMeasureSubcategoryOptions").value();

            //        if ($scope.AngularModel.EvaluationCriterionValueSimples.length > 0 &&
            //            _.reduce(subcategoryOptions, function(a, b) { return a && (b.length > 0) }, true) > 0 &&
            //            !_.some($scope.AngularModel.PerformanceMeasureSubcategorySimples,
            //                $scope.showSubcategoryValidationWarnings) &&
            //            !_.some(_.flatten(subcategoryOptions), $scope.showOptionValidationWarnings))
            //        {
            //            submitButton.prop("disabled", false);
            //        }
            //        else
            //        {
            //            submitButton.prop("disabled", true);
            //        }
            //    },
            //    true);
        });
