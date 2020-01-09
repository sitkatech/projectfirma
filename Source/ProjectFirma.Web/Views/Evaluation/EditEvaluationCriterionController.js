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
            
            $scope.showSubcategoryValidationWarnings = function(subcategorySimple)
            {
                return _.any($scope.validateSubcategoryDisplayName(subcategorySimple));
            }

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
        });
