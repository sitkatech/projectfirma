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
        
        if ($scope.IsYearInUse) {
            //console.log('Year is already in use');
            return;
        }
        var newBulk = $scope.createNewBulkRow($scope.ReportingPeriodYearToAdd, $scope.ReportingPeriodLabelToAdd);
        $scope.AngularModel.PerformanceMeasureReportingPeriodSimples.push(newBulk);
        $scope.NextReportingPeriodYear = $scope.getNextReportingPeriodYear();
        $scope.resetReportingPeriodToAdd();
    };

    
    $scope.CheckForYearInUse = function () {
        
        if (_.find($scope.AngularModel.PerformanceMeasureReportingPeriodSimples, function (o) { return o.PerformanceMeasureReportingPeriodCalendarYear == $scope.ReportingPeriodYearToAdd; })) {
            $scope.IsYearInUse = true;
            //console.log('year is in use');
        } else {
            $scope.IsYearInUse = false;
            //console.log('year is NOT in use');
        }
    }

    $scope.addYearRow = function()
    {
        if (Sitka.Methods.isUndefinedNullOrEmpty($scope.ReportingPeriodYearToAdd))
        {
            return;
        }
        $scope.CheckForYearInUse();
        $scope.ReportingPeriodLabelToAdd = $scope.ReportingPeriodYearToAdd;
        $scope.addRow();
    }

    $scope.createNewBulkRow = function (reportingPeriodCalendarYear, reportingPeriodLabel) {
        var newBulk = {
            PerformanceMeasureReportingPeriodCalendarYear: reportingPeriodCalendarYear,
            PerformanceMeasureReportingPeriodLabel: reportingPeriodLabel,
            TargetValue: $scope.AngularModel.FixedTargetValue,
            TargetValueLabel: $scope.AngularModel.FixedTargetValueLabel,
            PerformanceMeasureReportingPeriodID: -1,
            PerformanceMeasureTargetID: -1
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


    $scope.showDeleteYear = function (bulk) {
        var hasActuals = _.includes($scope.AngularViewData.ReportingPeriodsWithActuals, bulk.PerformanceMeasureReportingPeriodID);
        return !hasActuals;
    };

    $scope.getBulkOrder = function (bulk) { return new Date(bulk.PerformanceMeasureReportingPeriodCalendarYear); }

    $scope.isPerformanceMeasureTargetValueTypeNoTarget = function () {
        return parseInt($scope.AngularModel.PerformanceMeasureTargetValueTypeID) === $scope.NoTargetID;
    }

    $scope.isPerformanceMeasureTargetValueTypeFixedTarget = function () {
        return parseInt($scope.AngularModel.PerformanceMeasureTargetValueTypeID) === $scope.FixedTargetID;
    }

    $scope.isPerformanceMeasureTargetValueTypeTargetPerYear = function () {
        return parseInt($scope.AngularModel.PerformanceMeasureTargetValueTypeID) === $scope.PerYearTargetID;
    }

    $scope.showAndHideDependingOnTargetValueType = function() {
        if ($scope.isPerformanceMeasureTargetValueTypeNoTarget()) {
            $scope.ShowPerReportingPeriodSection = false;
            $scope.ShowFixedTargetInputs = false;
        }
        else if ($scope.isPerformanceMeasureTargetValueTypeFixedTarget()) {
            $scope.ShowPerReportingPeriodSection = false;
            $scope.ShowFixedTargetInputs = true;
            
        }
        else if ($scope.isPerformanceMeasureTargetValueTypeTargetPerYear()) {
            $scope.ShowPerReportingPeriodSection = true;
            $scope.ShowFixedTargetInputs = false;
        }
        else {
            console.error("Unknown target type: " + $scope.AngularModel.PerformanceMeasureTargetValueTypeID);
        }
    }

    $scope.targetValueTypeChanged = function () {
        $scope.showAndHideDependingOnTargetValueType();
    }

    $scope.populateSimpleTargets = function () {
        _.forEach($scope.AngularModel.PerformanceMeasureReportingPeriodSimples, function (value, key) {
            if (!value.TargetValueLabel) {
                $scope.AngularModel.PerformanceMeasureReportingPeriodSimples[key].TargetValueLabel = $scope.AngularModel.FixedTargetValueLabel;
            }
            if (!value.TargetValue) {
                $scope.AngularModel.PerformanceMeasureReportingPeriodSimples[key].TargetValue = $scope.AngularModel.FixedTargetValue;
            }
        });
    }

    $scope.AngularModel = angularModelAndViewData.AngularModel;
    $scope.AngularViewData = angularModelAndViewData.AngularViewData;
    
    $scope.NoTargetID = _.find($scope.AngularViewData.PerformanceMeasureTargetValueTypes, function (pmtvt) {
        return pmtvt.PerformanceMeasureTargetValueTypeName == "NoTarget";
    }).PerformanceMeasureTargetValueTypeID;

    $scope.FixedTargetID = _.find($scope.AngularViewData.PerformanceMeasureTargetValueTypes, function (pmtvt) {
        return pmtvt.PerformanceMeasureTargetValueTypeName == "FixedTarget";
    }).PerformanceMeasureTargetValueTypeID;

    $scope.PerYearTargetID = _.find($scope.AngularViewData.PerformanceMeasureTargetValueTypes, function (pmtvt) {
        return pmtvt.PerformanceMeasureTargetValueTypeName == "TargetPerYear";
    }).PerformanceMeasureTargetValueTypeID;

    $scope.NextReportingPeriodYear = $scope.AngularViewData.DefaultReportingPeriodYear;
    $scope.ReportingPeriodYearToAdd = $scope.AngularViewData.DefaultReportingPeriodYear;

    if ($scope.AngularModel.PerformanceMeasureTargetValueTypeID == $scope.PerYearTargetID && $scope.AngularModel.PerformanceMeasureReportingPeriodSimples.length > 0) {
        $scope.AngularModel.FixedTargetValue = $scope.AngularModel.PerformanceMeasureReportingPeriodSimples[0].TargetValue;
        $scope.AngularModel.FixedTargetValueLabel = $scope.AngularModel.PerformanceMeasureReportingPeriodSimples[0].TargetValueLabel;
    }

    if (!$scope.AngularModel.FixedTargetValueLabel) {
        $scope.AngularModel.FixedTargetValueLabel = $scope.AngularViewData.DefaultTargetLabel;
    }

    $scope.populateSimpleTargets();
    $scope.showAndHideDependingOnTargetValueType();
    $scope.resetReportingPeriodToAdd();
    $scope.CheckForYearInUse();
});
