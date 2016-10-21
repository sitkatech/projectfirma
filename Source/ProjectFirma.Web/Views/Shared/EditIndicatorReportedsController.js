angular.module("ProjectFirmaApp").controller("EditIndicatorReportedController", function ($scope, angularModelAndViewData) {
    $scope.resetReportingPeriodToAdd = function () {
        $scope.ReportingPeriodBeginDateToAdd = "01/01/" + $scope.NextReportingPeriodYear;
        $scope.ReportingPeriodEndDateToAdd = "12/31/" + $scope.NextReportingPeriodYear;
        $scope.ReportingPeriodLabelToAdd = $scope.NextReportingPeriodYear;
        $scope.ReportingPeriodYearToAdd = $scope.NextReportingPeriodYear;
        $scope.ReportedValuesToAdd = _($scope.getReportingCategoriesForDisplay())
            .sortBy(function(reportingCategoryForDisplay)
            {
                return reportingCategoryForDisplay.SortOrder;
            })
            .map(function (reportingCategoryForDisplay) {
                return {
                    IndicatorSubcategoryOptionID: reportingCategoryForDisplay.IndicatorSubcategoryOptionID,
                    ReportedValueAmount: null
                };
            }).value();
    };

    $scope.getReportingCategoriesForDisplay = function () {
        return $scope.AngularViewData.ReportingCategoriesForDisplay;
    };

    $scope.addRow = function () {
        if ((Sitka.Methods.isUndefinedNullOrEmpty($scope.ReportingPeriodBeginDateToAdd)) ||
            (Sitka.Methods.isUndefinedNullOrEmpty($scope.ReportingPeriodEndDateToAdd)) ||
            (Sitka.Methods.isUndefinedNullOrEmpty($scope.ReportingPeriodLabelToAdd))) {
            return;
        }
        var newBulk = $scope.createNewBulkRow($scope.ReportingPeriodBeginDateToAdd, $scope.ReportingPeriodEndDateToAdd, $scope.ReportingPeriodLabelToAdd, $scope.ReportedValuesToAdd);
        $scope.AngularModel.IndicatorReportedBulks.push(newBulk);
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
            IndicatorSubcategoryID: $scope.AngularViewData.IndicatorSubcategoryID,
            IndicatorReportingPeriodBeginDate: reportingPeriodBeginDate,
            IndicatorReportingPeriodEndDate: reportingPeriodEndDate,
            IndicatorReportingPeriodLabel: reportingPeriodLabel,
            ReportedValuesForDisplay: reportedValuesForDisplay
        };
        return newBulk;
    };

    $scope.getNextReportingPeriodYear = function()
    {
        return _($scope.AngularModel.IndicatorReportedBulks)
            .map(function(bulk) { return new Date(bulk.IndicatorReportingPeriodBeginDate).getFullYear(); })
            .max() + 1;
    }

    $scope.deleteRow = function (rowToDelete) {
        Sitka.Methods.removeFromJsonArray($scope.AngularModel.IndicatorReportedBulks, rowToDelete);
    };

    $scope.showRowValidationErrors = function (bulk) {
        var hasValidationErrors = _.contains($scope.AngularModel.IndicatorReportedsWithValidationErrors, bulk.IndicatorReportingPeriodLabel);
        return hasValidationErrors;
    };

    $scope.getFormattedDateLabel = function(bulk)
    {
        var beginDateString = jQuery.datepicker.formatDate("m/d/y", new Date(bulk.IndicatorReportingPeriodBeginDate));
        var endDateString = jQuery.datepicker.formatDate("m/d/y", new Date(bulk.IndicatorReportingPeriodEndDate));
        return bulk.IndicatorReportingPeriodLabel + " (" + beginDateString + " - " + endDateString + ")";
    };

    $scope.getBulkOrder = function (bulk) { return new Date(bulk.IndicatorReportingPeriodBeginDate); }

    $scope.isIndicatorTargetValueTypeNoTarget = function () {
        return parseInt($scope.AngularModel.IndicatorTargetValueTypeID) === $scope.AngularViewData.IndicatorTargetValueTypes.NoTarget;
    }

    $scope.isIndicatorTargetValueTypeOverallTarget = function () {
        return parseInt($scope.AngularModel.IndicatorTargetValueTypeID) === $scope.AngularViewData.IndicatorTargetValueTypes.OverallTarget;
    }

    $scope.isIndicatorTargetValueTypeTargetPerReportingPeriod = function () {
        return parseInt($scope.AngularModel.IndicatorTargetValueTypeID) === $scope.AngularViewData.IndicatorTargetValueTypes.TargetPerReportingPeriod;
    }

    $scope.targetValueTypeChanged = function()
    {
        if ($scope.isIndicatorTargetValueTypeNoTarget())
        {
            $scope.ShowPerReportingPeriodTargetColumns = false;
            $scope.ShowOverallTargetInputs = false;
        }
        else if ($scope.isIndicatorTargetValueTypeOverallTarget())
        {
            $scope.ShowPerReportingPeriodTargetColumns = false;
            $scope.ShowOverallTargetInputs = true;
        }
        else if ($scope.isIndicatorTargetValueTypeTargetPerReportingPeriod())
        {
            $scope.ShowPerReportingPeriodTargetColumns = true;
            $scope.ShowOverallTargetInputs = false;
        }
        else
        {
            console.error("Unknown target type: " + $scope.AngularModel.IndicatorTargetValueTypeID);
        }
    }

    $scope.AngularModel = angularModelAndViewData.AngularModel;
    $scope.AngularViewData = angularModelAndViewData.AngularViewData;

    $scope.NextReportingPeriodYear = $scope.AngularViewData.DefaultReportingPeriodYear;
    $scope.ReportingPeriodYearToAdd = $scope.AngularViewData.DefaultReportingPeriodYear;

    if ($scope.AngularModel.IndicatorReportedBulks.length > 0) {
        $scope.AngularModel.OverallTargetValue = $scope.AngularModel.IndicatorReportedBulks[0].TargetValue;
        $scope.AngularModel.OverallTargetValueDescription = $scope.AngularModel.IndicatorReportedBulks[0].TargetValueDescription;
    }

    $scope.targetValueTypeChanged();
    $scope.resetReportingPeriodToAdd();
});