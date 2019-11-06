/*-----------------------------------------------------------------------
<copyright file="EditPerformanceMeasureTargetsController.js" company="Tahoe Regional Planning Agency">
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
angular.module("CorralApp").controller("EditPerformanceMeasureTargetsController", function ($scope, angularModelAndViewData) {
    $scope.resetReportingPeriodToAdd = function () {
        $scope.ReportingPeriodBeginDateToAdd = "01/01/" + $scope.NextReportingPeriodYear;
        $scope.ReportingPeriodEndDateToAdd = "12/31/" + $scope.NextReportingPeriodYear;
        $scope.ReportingPeriodLabelToAdd = $scope.NextReportingPeriodYear;
        $scope.ReportingPeriodYearToAdd = $scope.NextReportingPeriodYear;
        $scope.ReportedValuesToAdd = _($scope.AngularViewData.ReportingCategoriesForDisplay)
            .sortBy(function(reportingCategoryForDisplay)
            {
                return reportingCategoryForDisplay.SortOrder;
            })
            .map(function (reportingCategoryForDisplay) {
                return {
                    PerformanceMeasureSubcategoryOptionID: reportingCategoryForDisplay.PerformanceMeasureSubcategoryOptionID,
                    ReportedValueAmount: null
                };
            }).value();
    };

    $scope.addRow = function () {
        if ((Sitka.Methods.isUndefinedNullOrEmpty($scope.ReportingPeriodBeginDateToAdd)) ||
            (Sitka.Methods.isUndefinedNullOrEmpty($scope.ReportingPeriodEndDateToAdd)) ||
            (Sitka.Methods.isUndefinedNullOrEmpty($scope.ReportingPeriodLabelToAdd))) {
            return;
        }
        var newBulk = $scope.createNewBulkRow($scope.ReportingPeriodBeginDateToAdd, $scope.ReportingPeriodEndDateToAdd, $scope.ReportingPeriodLabelToAdd, $scope.ReportedValuesToAdd);
        $scope.AngularModel.PerformanceMeasureReportedBulks.push(newBulk);
        $scope.NextReportingPeriodYear = $scope.getNextReportingPeriodYear();
        $scope.resetReportingPeriodToAdd();
    };

    $scope.addYearRow = function()
    {
        if (Sitka.Methods.isUndefinedNullOrEmpty($scope.ReportingPeriodYearToAdd))
        {
            return;
        }
        $scope.ReportingPeriodBeginDateToAdd = "01/01/" + $scope.ReportingPeriodYearToAdd;
        $scope.ReportingPeriodEndDateToAdd = "12/31/" + $scope.ReportingPeriodYearToAdd;
        $scope.ReportingPeriodLabelToAdd = $scope.ReportingPeriodYearToAdd;
        $scope.addRow();
    }

    $scope.createNewBulkRow = function (reportingPeriodBeginDate, reportingPeriodEndDate, reportingPeriodLabel, reportedValuesForDisplay) {
        var newBulk = {
            PerformanceMeasureSubcategoryID: $scope.AngularViewData.PerformanceMeasureSubcategoryID,
            PerformanceMeasureReportingPeriodBeginDate: reportingPeriodBeginDate,
            PerformanceMeasureReportingPeriodEndDate: reportingPeriodEndDate,
            PerformanceMeasureReportingPeriodLabel: reportingPeriodLabel,
            ReportedValuesForDisplay: reportedValuesForDisplay
        };
        return newBulk;
    };

    $scope.getNextReportingPeriodYear = function()
    {
        return _($scope.AngularModel.PerformanceMeasureReportedBulks)
            .map(function(bulk) { return new Date(bulk.PerformanceMeasureReportingPeriodBeginDate).getFullYear(); })
            .max() + 1;
    }

    $scope.deleteRow = function (rowToDelete) {
        Sitka.Methods.removeFromJsonArray($scope.AngularModel.PerformanceMeasureReportedBulks, rowToDelete);
    };

    $scope.showRowValidationErrors = function (bulk) {
        var hasValidationErrors = _.includes($scope.AngularModel.PerformanceMeasureTargetsWithValidationErrors, bulk.PerformanceMeasureReportingPeriodLabel);
        return hasValidationErrors;
    };

    $scope.getFormattedDateLabel = function(bulk)
    {
        var beginDateString = jQuery.datepicker.formatDate("m/d/y", new Date(bulk.PerformanceMeasureReportingPeriodBeginDate));
        var endDateString = jQuery.datepicker.formatDate("m/d/y", new Date(bulk.PerformanceMeasureReportingPeriodEndDate));
        return bulk.PerformanceMeasureReportingPeriodLabel + " (" + beginDateString + " - " + endDateString + ")";
    };

    $scope.getBulkOrder = function (bulk) { return new Date(bulk.PerformanceMeasureReportingPeriodBeginDate); }

    $scope.isPerformanceMeasureTargetValueTypeNoTarget = function () {
        return parseInt($scope.AngularModel.PerformanceMeasureTargetValueTypeID) === $scope.AngularViewData.PerformanceMeasureTargetValueTypes.NoTarget;
    }

    $scope.isPerformanceMeasureTargetValueTypeOverallTarget = function () {
        return parseInt($scope.AngularModel.PerformanceMeasureTargetValueTypeID) === $scope.AngularViewData.PerformanceMeasureTargetValueTypes.OverallTarget;
    }

    $scope.isPerformanceMeasureTargetValueTypeTargetPerReportingPeriod = function () {
        return parseInt($scope.AngularModel.PerformanceMeasureTargetValueTypeID) === $scope.AngularViewData.PerformanceMeasureTargetValueTypes.TargetPerReportingPeriod;
    }

    $scope.targetValueTypeChanged = function()
    {
        if ($scope.isPerformanceMeasureTargetValueTypeNoTarget())
        {
            $scope.ShowPerReportingPeriodTargetColumns = false;
            $scope.ShowOverallTargetInputs = false;
        }
        else if ($scope.isPerformanceMeasureTargetValueTypeOverallTarget())
        {
            $scope.ShowPerReportingPeriodTargetColumns = false;
            $scope.ShowOverallTargetInputs = true;
        }
        else if ($scope.isPerformanceMeasureTargetValueTypeTargetPerReportingPeriod())
        {
            $scope.ShowPerReportingPeriodTargetColumns = true;
            $scope.ShowOverallTargetInputs = false;
        }
        else
        {
            console.error("Unknown target type: " + $scope.AngularModel.PerformanceMeasureTargetValueTypeID);
        }
    }

    $scope.AngularModel = angularModelAndViewData.AngularModel;
    $scope.AngularViewData = angularModelAndViewData.AngularViewData;

    $scope.NextReportingPeriodYear = $scope.AngularViewData.DefaultReportingPeriodYear;
    $scope.ReportingPeriodYearToAdd = $scope.AngularViewData.DefaultReportingPeriodYear;

    if ($scope.AngularModel.PerformanceMeasureReportedBulks.length > 0) {
        $scope.AngularModel.OverallTargetValue = $scope.AngularModel.PerformanceMeasureReportedBulks[0].TargetValue;
        $scope.AngularModel.OverallTargetValueDescription = $scope.AngularModel.PerformanceMeasureReportedBulks[0].TargetValueDescription;
    }

    $scope.targetValueTypeChanged();
    $scope.resetReportingPeriodToAdd();
});
