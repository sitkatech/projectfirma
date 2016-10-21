angular.module("ProjectFirmaApp").controller("TransportationProjectBudgetController", function ($scope, angularModelAndViewData) {
    $scope.resetFundingSourceToAdd = function () { $scope.FundingSourceToAdd = null; };

    $scope.getAllCalendarYearBudgetsAsFlattenedLoDashArray = function () { return _($scope.AngularModel.TransportationProjectBudgets).pluck("CalendarYearBudgets").flatten(); }

    $scope.getAllUsedCalendarYears = function () { return $scope.getAllCalendarYearBudgetsAsFlattenedLoDashArray().pluck("CalendarYear").flatten().union().sortBy().value(); };

    $scope.getCalendarYearRange = function () { return _.union($scope.getAllUsedCalendarYears(), angularModelAndViewData.AngularViewData.CalendarYearRange); };

    $scope.getAllUsedFundingSourceIds = function () { return _.unique(_.map($scope.AngularModel.TransportationProjectBudgets, function (p) { return p.FundingSourceID; })); };

    $scope.filteredFundingSources = function () {
        var usedFundingSourceIDs = $scope.getAllUsedFundingSourceIds();
        var projectFundingOrganizationFundingSourceIDs = _.map($scope.AngularViewData.AllFundingSources, function (p) { return p.FundingSourceID; });
        if ($scope.ShowOnlyProjectFunders) {
            projectFundingOrganizationFundingSourceIDs = $scope.AngularViewData.ProjectFundingOrganizationFundingSourceIDs;
        }
        return _($scope.AngularViewData.AllFundingSources).filter(function (f) { return f.IsActive && _.contains(projectFundingOrganizationFundingSourceIDs, f.FundingSourceID) && !_.contains(usedFundingSourceIDs, f.FundingSourceID); }).sortByAll(["OrganizationName", "FundingSourceName"]).value();
    };

    $scope.getFundingSourceName = function (fundingSource) { return $scope.getFundingSourceNameById(fundingSource.FundingSourceID); };

    $scope.getFundingSourceNameById = function (fundingSourceId) {
        var fundingSourceToFind = $scope.getFundingSource(fundingSourceId);
        return fundingSourceToFind.DisplayName;
    };

    $scope.getFundingSource = function (fundingSourceId) { return _.find($scope.AngularViewData.AllFundingSources, function (f) { return fundingSourceId == f.FundingSourceID; }); };

    $scope.getTransportationProjectCostTypeName = function (transportationProjectBudget) {
        var transportationProjectCostTypeToFind = $scope.getTransportationProjectCostType(transportationProjectBudget.TransportationProjectCostTypeID);
        return transportationProjectCostTypeToFind.TransportationProjectCostTypeDisplayName;
    };

    $scope.getTransportationProjectCostType = function (transportationProjectCostTypeId) { return _.find($scope.AngularViewData.AllTransportationProjectCostTypes, function (f) { return transportationProjectCostTypeId == f.TransportationProjectCostTypeID; }); };

    $scope.getBudgetTotalForCalendarYear = function (calendarYear) {
        var calendarYearBudgetsAsFlattenedArray = $scope.getAllCalendarYearBudgetsAsFlattenedLoDashArray().filter(function (pfse) { return Sitka.Methods.isUndefinedNullOrEmpty(calendarYear) || pfse.CalendarYear == calendarYear; }).value();
        return $scope.calculateBudgetTotal(calendarYearBudgetsAsFlattenedArray);
    };

    $scope.getBudgetTotalForFundingSourceAndCalendarYear = function (fundingSourceId, calendarYear) {
        var calendarYearBudgetsAsFlattenedArray = _($scope.AngularModel.TransportationProjectBudgets).filter(function (pfse) { return pfse.ProjectID == $scope.AngularViewData.ProjectID && pfse.FundingSourceID == fundingSourceId; }).pluck("CalendarYearBudgets").flatten().filter(function (cye) { return cye.CalendarYear == calendarYear; }).value();
        return $scope.calculateBudgetTotal(calendarYearBudgetsAsFlattenedArray);
    };

    $scope.getBudgetTotalForFundingSource = function (fundingSourceId) {
        var calendarYearBudgetsAsFlattenedArray = _($scope.AngularModel.TransportationProjectBudgets).filter(function (pfse) { return pfse.ProjectID == $scope.AngularViewData.ProjectID && pfse.FundingSourceID == fundingSourceId; }).pluck("CalendarYearBudgets").flatten().value();
        return $scope.calculateBudgetTotal(calendarYearBudgetsAsFlattenedArray);
    };

    $scope.getBudgetTotalForTransportationProjectCostTypeAndCalendarYear = function (transportationProjectCostTypeId, calendarYear) {
        var calendarYearBudgetsAsFlattenedArray = _($scope.AngularModel.TransportationProjectBudgets).filter(function (pfse) { return pfse.ProjectID == $scope.AngularViewData.ProjectID && pfse.TransportationProjectCostTypeID == transportationProjectCostTypeId; }).pluck("CalendarYearBudgets").flatten().filter(function (cye) { return cye.CalendarYear == calendarYear; }).value();
        return $scope.calculateBudgetTotal(calendarYearBudgetsAsFlattenedArray);
    };

    $scope.getBudgetTotalForTransportationProjectCostType = function (transportationProjectCostTypeId) {
        var calendarYearBudgetsAsFlattenedArray = _($scope.AngularModel.TransportationProjectBudgets).filter(function (pfse) { return pfse.ProjectID == $scope.AngularViewData.ProjectID && pfse.TransportationProjectCostTypeID == transportationProjectCostTypeId; }).pluck("CalendarYearBudgets").flatten().value();
        return $scope.calculateBudgetTotal(calendarYearBudgetsAsFlattenedArray);
    };

    $scope.getBudgetTotalForRow = function (transportationProjectBudget) {
        var calendarYearBudgetsAsFlattenedArray = _($scope.AngularModel.TransportationProjectBudgets).filter(function (pfse) { return pfse.ProjectID == transportationProjectBudget.ProjectID && pfse.FundingSourceID == transportationProjectBudget.FundingSourceID && pfse.TransportationProjectCostTypeID == transportationProjectBudget.TransportationProjectCostTypeID; }).pluck("CalendarYearBudgets").flatten().value();
        return $scope.calculateBudgetTotal(calendarYearBudgetsAsFlattenedArray);
    };

    $scope.calculateBudgetTotal = function (expenditures) { return _.reduce(expenditures, function (m, x) { return m + x.MonetaryAmount; }, 0); }

    $scope.addCalendarYear = function (calendarYear) {
        if (Sitka.Methods.isUndefinedNullOrEmpty(calendarYear)) {
            return;
        }
        _.each($scope.getAllUsedFundingSourceIds(), function (fundingSourceId) { $scope.addCalendarYearBudgetRow($scope.ProjectIDToAdd, fundingSourceId, calendarYear); });
    };

    $scope.getTransportationProjectBudgetRowsForFundingSource = function (fundingSourceId) { return _.filter($scope.AngularModel.TransportationProjectBudgets, function (pfse) { return pfse.ProjectID == $scope.AngularViewData.ProjectID && pfse.FundingSourceID == fundingSourceId; }); }

    $scope.getTransportationProjectBudgetRowsForTransportationProjectCostType = function (transportationProjectCostType) { return _.filter($scope.AngularModel.TransportationProjectBudgets, function (pfse) { return pfse.ProjectID == $scope.AngularViewData.ProjectID && pfse.TransportationProjectCostTypeID == transportationProjectCostType.TransportationProjectCostTypeID; }); }

    $scope.addRow = function () {
        if (($scope.FundingSourceToAdd == null) || ($scope.ProjectIDToAdd == null)) {
            return;
        }
        for (var i = 0; i < $scope.AngularViewData.AllTransportationProjectCostTypes.length; ++i) {
            var newTransportationProjectBudget = $scope.createNewRow($scope.ProjectIDToAdd, $scope.FundingSourceToAdd.FundingSourceID, $scope.AngularViewData.AllTransportationProjectCostTypes[i].TransportationProjectCostTypeID, $scope.getCalendarYearRange());
            $scope.AngularModel.TransportationProjectBudgets.push(newTransportationProjectBudget);
        }
        $scope.resetFundingSourceToAdd();
    };

    $scope.createNewRow = function (projectId, fundingSourceId, transportationProjectCostTypeId, calendarYearsToAdd) {
        var newTransportationProjectBudget = {
            ProjectID: projectId,
            FundingSourceID: fundingSourceId,
            TransportationProjectCostTypeID: transportationProjectCostTypeId,
            CalendarYearBudgets: _.map(calendarYearsToAdd, $scope.createNewCalendarYearBudgetRow)
        };
        return newTransportationProjectBudget;
    };

    $scope.addCalendarYearBudgetRow = function (projectId, fundingSourceId, calendarYear) {
        var transportationProjectBudgetRowsForFundingSource = $scope.getTransportationProjectBudgetRowsForFundingSource(fundingSourceId);
        if (transportationProjectBudgetRowsForFundingSource.length > 0) {
            for (var i = 0; i < transportationProjectBudgetRowsForFundingSource.length; ++i) {
                transportationProjectBudgetRowsForFundingSource[i].CalendarYearBudgets.push($scope.createNewCalendarYearBudgetRow(calendarYear));
            }
        }
    };

    $scope.createNewCalendarYearBudgetRow = function (calendarYear) {
        return {
            CalendarYear: calendarYear,
            BudgetAmount: null
        };
    };

    $scope.deleteFundingSourceRow = function (fundingSourceId) {
        var transportationProjectBudgetRowsForFundingSource = $scope.getTransportationProjectBudgetRowsForFundingSource(fundingSourceId);
        if (transportationProjectBudgetRowsForFundingSource.length > 0) {
            for (var i = 0; i < transportationProjectBudgetRowsForFundingSource.length; ++i) {
                Sitka.Methods.removeFromJsonArray($scope.AngularModel.TransportationProjectBudgets, transportationProjectBudgetRowsForFundingSource[i]);
            }
        }
    };

    $scope.setGroupByTransportationProjectCostType = function (showHide) { $scope.IsGroupedByTransportationProjectCostType = showHide; };

    $scope.existsInFundingSourcesNotShowingTransportationProjectCostTypes = function (fundingSourceId) { return _.contains($scope.FundingSourcesNotShowingTransportationProjectCostTypes, fundingSourceId); };

    $scope.removeFromFundingSourcesNotShowingTransportationProjectCostTypes = function (fundingSourceId) { Sitka.Methods.removeFromJsonArray($scope.FundingSourcesNotShowingTransportationProjectCostTypes, fundingSourceId); };

    $scope.addToFundingSourcesNotShowingTransportationProjectCostTypes = function (fundingSourceId) { $scope.FundingSourcesNotShowingTransportationProjectCostTypes.push(fundingSourceId); };

    $scope.showHideTransportationProjectCostTypes = function (fundingSourceId) {
        if ($scope.existsInFundingSourcesNotShowingTransportationProjectCostTypes(fundingSourceId)) {
            $scope.removeFromFundingSourcesNotShowingTransportationProjectCostTypes(fundingSourceId);
        }
        else {
            $scope.addToFundingSourcesNotShowingTransportationProjectCostTypes(fundingSourceId);
        }
    };

    $scope.existsInHiddenTransportationProjectCostTypes = function (transportationProjectCostType) { return _.contains($scope.HiddenTransportationProjectCostTypes, transportationProjectCostType.TransportationProjectCostTypeID); };

    $scope.removeFromHiddenTransportationProjectCostTypes = function (transportationProjectCostType) { Sitka.Methods.removeFromJsonArray($scope.HiddenTransportationProjectCostTypes, transportationProjectCostType.TransportationProjectCostTypeID); };

    $scope.addToHiddenTransportationProjectCostTypes = function (transportationProjectCostType) { $scope.HiddenTransportationProjectCostTypes.push(transportationProjectCostType.TransportationProjectCostTypeID); };

    $scope.showHideFundingSources = function (transportationProjectCostType) {
        if ($scope.existsInHiddenTransportationProjectCostTypes(transportationProjectCostType)) {
            $scope.removeFromHiddenTransportationProjectCostTypes(transportationProjectCostType);
        }
        else {
            $scope.addToHiddenTransportationProjectCostTypes(transportationProjectCostType);
        }
    };

    $scope.AngularModel = angularModelAndViewData.AngularModel;
    $scope.AngularViewData = angularModelAndViewData.AngularViewData;
    $scope.ShowOnlyProjectFunders = false;
    $scope.FundingSourcesNotShowingTransportationProjectCostTypes = [];
    $scope.HiddenTransportationProjectCostTypes = [];
    $scope.IsGroupedByTransportationProjectCostType = false;
    $scope.resetFundingSourceToAdd();
    $scope.ProjectIDToAdd = $scope.AngularViewData.ProjectID;
});