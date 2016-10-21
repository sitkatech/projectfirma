angular.module("ProjectFirmaApp").controller("IndicatorRelationshipController", function ($scope, angularModelAndViewData)
{
    $scope.ResetThresholdReportingCategoryToAdd = function()
    {
        if ($scope.AngularViewData.FromIndicator)
        {
            $scope.ThresholdReportingCategoryToAdd = null;
        }
        else
        {
            $scope.ThresholdReportingCategoryToAdd = $scope
                .getThresholdReportingCategory($scope.AngularViewData.ThresholdReportingCategoryID);
        }
    };

    $scope.ResetIndicatorToAdd = function()
    {
        if ($scope.AngularViewData.FromIndicator)
        {
            $scope.IndicatorToAdd = $scope
                .getIndicator($scope.AngularViewData.IndicatorID);
        }
        else
        {
            $scope.IndicatorToAdd = null;
        }
    };

    $scope.filteredThresholdReportingCategories = function () {
        var usedThresholdReportingCategoryIDs = _.map($scope.AngularModel.IndicatorRelationships, function (p) { return p.ThresholdReportingCategoryID; });
        return _($scope.AngularViewData.AllThresholdReportingCategories).filter(function (f) { return !_.contains(usedThresholdReportingCategoryIDs, f.ThresholdReportingCategoryID); }).sortBy(["DisplayName"]).value();
    };

    $scope.getThresholdReportingCategoryName = function (thresholdReportingCategory) {
        var thresholdReportingCategoryToFind = $scope.getThresholdReportingCategory(thresholdReportingCategory.ThresholdReportingCategoryID);
        return thresholdReportingCategoryToFind.DisplayName;
    };

    $scope.getThresholdReportingCategory = function (thresholdReportingCategoryID) {
        return _.find($scope.AngularViewData.AllThresholdReportingCategories, function (f) { return thresholdReportingCategoryID == f.ThresholdReportingCategoryID; });
    };

    $scope.filteredIndicators = function () {
        var usedIndicatorIDs = _.map($scope.AngularModel.IndicatorRelationships, function (p) { return p.IndicatorID; });
        return _($scope.AngularViewData.AllIndicators).filter(function (f) { return !_.contains(usedIndicatorIDs, f.IndicatorID); }).sortBy(["DisplayName"]).value();
    };

    $scope.getIndicatorName = function (indicator) {
        var indicatorToFind = $scope.getIndicator(indicator.IndicatorID);
        return indicatorToFind.DisplayName;
    };

    $scope.getIndicator = function (indicatorID) {
        return _.find($scope.AngularViewData.AllIndicators, function (f) { return indicatorID == f.IndicatorID; });
    };

    $scope.addRow = function()
    {
        if ($scope.ThresholdReportingCategoryToAdd != null && $scope.IndicatorToAdd != null)
        {
            var newIndicatorRelationship = $scope.createNewRow($scope.IndicatorToAdd, $scope.ThresholdReportingCategoryToAdd);
            $scope.AngularModel.IndicatorRelationships.push(newIndicatorRelationship);
            $scope.ResetThresholdReportingCategoryToAdd();
            $scope.ResetIndicatorToAdd();
        }
    };

    $scope.createNewRow = function (indicator, thresholdReportingCategory) {
        var newIndicatorRelationship = {
            IndicatorID: indicator.IndicatorID,
            ThresholdReportingCategoryID: thresholdReportingCategory.ThresholdReportingCategoryID,
            IndicatorRelationshipTypeID: 1
        };
        return newIndicatorRelationship;
    };

    $scope.deleteRow = function (rowToDelete) {
        Sitka.Methods.removeFromJsonArray($scope.AngularModel.IndicatorRelationships, rowToDelete);
    };

    $scope.AngularModel = angularModelAndViewData.AngularModel;
    $scope.AngularViewData = angularModelAndViewData.AngularViewData;
    $scope.ResetThresholdReportingCategoryToAdd();
    $scope.ResetIndicatorToAdd();
});

