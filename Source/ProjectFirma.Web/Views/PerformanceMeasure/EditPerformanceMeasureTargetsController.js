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
angular.module("ProjectFirmaApp").controller("EditPerformanceMeasureTargetsController", function ($scope, angularModelAndViewData) {

    $scope.resetReportingPeriodToAdd = function () {

        $scope.ReportingPeriodLabelToAdd = $scope.NextReportingPeriodYear;
        $scope.ReportingPeriodYearToAdd = $scope.NextReportingPeriodYear;

    };

    $scope.addRow = function () {
        if ((Sitka.Methods.isUndefinedNullOrEmpty($scope.ReportingPeriodYearToAdd)) ||
            (Sitka.Methods.isUndefinedNullOrEmpty($scope.ReportingPeriodLabelToAdd))) {
            return;
        }
        var newBulk = $scope.createNewBulkRow($scope.ReportingPeriodYearToAdd, $scope.ReportingPeriodLabelToAdd);
        $scope.AngularModel.PerformanceMeasureReportingPeriodSimples.push(newBulk);
        $scope.NextReportingPeriodYear = $scope.getNextReportingPeriodYear();
        $scope.resetReportingPeriodToAdd();
    };

    $scope.addYearRow = function()
    {
        if (Sitka.Methods.isUndefinedNullOrEmpty($scope.ReportingPeriodYearToAdd))
        {
            return;
        }
        $scope.ReportingPeriodLabelToAdd = $scope.ReportingPeriodYearToAdd;
        $scope.addRow();
    }

    $scope.createNewBulkRow = function (reportingPeriodCalendarYear, reportingPeriodLabel) {
        var newBulk = {
            PerformanceMeasureReportingPeriodCalendarYear: reportingPeriodCalendarYear,
            PerformanceMeasureReportingPeriodLabel: reportingPeriodLabel
        };
        return newBulk;
    };

    $scope.getNextReportingPeriodYear = function()
    {
        return _($scope.AngularModel.PerformanceMeasureReportingPeriodSimples)
            .map(function(bulk) { return bulk.PerformanceMeasureReportingPeriodCalendarYear; })
            .max() + 1;
    }

    $scope.deleteRow = function (rowToDelete) {
        Sitka.Methods.removeFromJsonArray($scope.AngularModel.PerformanceMeasureReportingPeriodSimples, rowToDelete);
    };

    $scope.showRowValidationErrors = function (bulk) {
        var hasValidationErrors = _.includes($scope.AngularModel.PerformanceMeasureTargetsWithValidationErrors, bulk.PerformanceMeasureReportingPeriodLabel);
        return hasValidationErrors;
    };

    $scope.getBulkOrder = function (bulk) { return new Date(bulk.PerformanceMeasureReportingPeriodCalendarYear); }

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

    if ($scope.AngularModel.PerformanceMeasureReportingPeriodSimples.length > 0) {
        $scope.AngularModel.OverallTargetValue = $scope.AngularModel.PerformanceMeasureReportingPeriodSimples[0].TargetValue;
        $scope.AngularModel.OverallTargetValueDescription = $scope.AngularModel.PerformanceMeasureReportingPeriodSimples[0].TargetValueDescription;
    }

    $scope.targetValueTypeChanged();
    $scope.resetReportingPeriodToAdd();
});
