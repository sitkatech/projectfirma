/*-----------------------------------------------------------------------
<copyright file="BudgetsController.js" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
angular.module("ProjectFirmaApp").controller("ProjectBudgetController", function ($scope, angularModelAndViewData) {
    $scope.resetFundingSourceToAdd = function () { $scope.FundingSourceToAdd = null; };

    $scope.getAllCalendarYearBudgetsAsFlattenedLoDashArray = function () { return _($scope.AngularModel.ProjectBudgets).pluck("CalendarYearBudgets").flatten(); }

    $scope.getAllUsedCalendarYears = function () { return $scope.getAllCalendarYearBudgetsAsFlattenedLoDashArray().pluck("CalendarYear").flatten().union().sortBy().value(); };

    $scope.getCalendarYearRange = function () { return _.union($scope.getAllUsedCalendarYears(), angularModelAndViewData.AngularViewData.CalendarYearRange); };

    $scope.getAllUsedFundingSourceIds = function () { return _.unique(_.map($scope.AngularModel.ProjectBudgets, function (p) { return p.FundingSourceID; })); };

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

    $scope.getProjectCostTypeName = function (ProjectBudget) {
        var ProjectCostTypeToFind = $scope.getProjectCostType(ProjectBudget.ProjectCostTypeID);
        return ProjectCostTypeToFind.ProjectCostTypeDisplayName;
    };

    $scope.getProjectCostType = function (ProjectCostTypeId) { return _.find($scope.AngularViewData.AllProjectCostTypes, function (f) { return ProjectCostTypeId == f.ProjectCostTypeID; }); };

    $scope.getBudgetTotalForCalendarYear = function (calendarYear) {
        var calendarYearBudgetsAsFlattenedArray = $scope.getAllCalendarYearBudgetsAsFlattenedLoDashArray().filter(function (pfse) { return Sitka.Methods.isUndefinedNullOrEmpty(calendarYear) || pfse.CalendarYear == calendarYear; }).value();
        return $scope.calculateBudgetTotal(calendarYearBudgetsAsFlattenedArray);
    };

    $scope.getBudgetTotalForFundingSourceAndCalendarYear = function (fundingSourceId, calendarYear) {
        var calendarYearBudgetsAsFlattenedArray = _($scope.AngularModel.ProjectBudgets).filter(function (pfse) { return pfse.ProjectID == $scope.AngularViewData.ProjectID && pfse.FundingSourceID == fundingSourceId; }).pluck("CalendarYearBudgets").flatten().filter(function (cye) { return cye.CalendarYear == calendarYear; }).value();
        return $scope.calculateBudgetTotal(calendarYearBudgetsAsFlattenedArray);
    };

    $scope.getBudgetTotalForFundingSource = function (fundingSourceId) {
        var calendarYearBudgetsAsFlattenedArray = _($scope.AngularModel.ProjectBudgets).filter(function (pfse) { return pfse.ProjectID == $scope.AngularViewData.ProjectID && pfse.FundingSourceID == fundingSourceId; }).pluck("CalendarYearBudgets").flatten().value();
        return $scope.calculateBudgetTotal(calendarYearBudgetsAsFlattenedArray);
    };

    $scope.getBudgetTotalForProjectCostTypeAndCalendarYear = function (ProjectCostTypeId, calendarYear) {
        var calendarYearBudgetsAsFlattenedArray = _($scope.AngularModel.ProjectBudgets).filter(function (pfse) { return pfse.ProjectID == $scope.AngularViewData.ProjectID && pfse.ProjectCostTypeID == ProjectCostTypeId; }).pluck("CalendarYearBudgets").flatten().filter(function (cye) { return cye.CalendarYear == calendarYear; }).value();
        return $scope.calculateBudgetTotal(calendarYearBudgetsAsFlattenedArray);
    };

    $scope.getBudgetTotalForProjectCostType = function (ProjectCostTypeId) {
        var calendarYearBudgetsAsFlattenedArray = _($scope.AngularModel.ProjectBudgets).filter(function (pfse) { return pfse.ProjectID == $scope.AngularViewData.ProjectID && pfse.ProjectCostTypeID == ProjectCostTypeId; }).pluck("CalendarYearBudgets").flatten().value();
        return $scope.calculateBudgetTotal(calendarYearBudgetsAsFlattenedArray);
    };

    $scope.getBudgetTotalForRow = function (ProjectBudget) {
        var calendarYearBudgetsAsFlattenedArray = _($scope.AngularModel.ProjectBudgets).filter(function (pfse) { return pfse.ProjectID == ProjectBudget.ProjectID && pfse.FundingSourceID == ProjectBudget.FundingSourceID && pfse.ProjectCostTypeID == ProjectBudget.ProjectCostTypeID; }).pluck("CalendarYearBudgets").flatten().value();
        return $scope.calculateBudgetTotal(calendarYearBudgetsAsFlattenedArray);
    };

    $scope.calculateBudgetTotal = function (expenditures) { return _.reduce(expenditures, function (m, x) { return m + x.MonetaryAmount; }, 0); }

    $scope.addCalendarYear = function (calendarYear) {
        if (Sitka.Methods.isUndefinedNullOrEmpty(calendarYear)) {
            return;
        }
        _.each($scope.getAllUsedFundingSourceIds(), function (fundingSourceId) { $scope.addCalendarYearBudgetRow($scope.ProjectIDToAdd, fundingSourceId, calendarYear); });
    };

    $scope.getProjectBudgetRowsForFundingSource = function (fundingSourceId) { return _.filter($scope.AngularModel.ProjectBudgets, function (pfse) { return pfse.ProjectID == $scope.AngularViewData.ProjectID && pfse.FundingSourceID == fundingSourceId; }); }

    $scope.getProjectBudgetRowsForProjectCostType = function (ProjectCostType) { return _.filter($scope.AngularModel.ProjectBudgets, function (pfse) { return pfse.ProjectID == $scope.AngularViewData.ProjectID && pfse.ProjectCostTypeID == ProjectCostType.ProjectCostTypeID; }); }

    $scope.addRow = function () {
        if (($scope.FundingSourceToAdd == null) || ($scope.ProjectIDToAdd == null)) {
            return;
        }
        for (var i = 0; i < $scope.AngularViewData.AllProjectCostTypes.length; ++i) {
            var newProjectBudget = $scope.createNewRow($scope.ProjectIDToAdd, $scope.FundingSourceToAdd.FundingSourceID, $scope.AngularViewData.AllProjectCostTypes[i].ProjectCostTypeID, $scope.getCalendarYearRange());
            $scope.AngularModel.ProjectBudgets.push(newProjectBudget);
        }
        $scope.resetFundingSourceToAdd();
    };

    $scope.createNewRow = function (projectId, fundingSourceId, ProjectCostTypeId, calendarYearsToAdd) {
        var newProjectBudget = {
            ProjectID: projectId,
            FundingSourceID: fundingSourceId,
            ProjectCostTypeID: ProjectCostTypeId,
            CalendarYearBudgets: _.map(calendarYearsToAdd, $scope.createNewCalendarYearBudgetRow)
        };
        return newProjectBudget;
    };

    $scope.addCalendarYearBudgetRow = function (projectId, fundingSourceId, calendarYear) {
        var ProjectBudgetRowsForFundingSource = $scope.getProjectBudgetRowsForFundingSource(fundingSourceId);
        if (ProjectBudgetRowsForFundingSource.length > 0) {
            for (var i = 0; i < ProjectBudgetRowsForFundingSource.length; ++i) {
                ProjectBudgetRowsForFundingSource[i].CalendarYearBudgets.push($scope.createNewCalendarYearBudgetRow(calendarYear));
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
        var ProjectBudgetRowsForFundingSource = $scope.getProjectBudgetRowsForFundingSource(fundingSourceId);
        if (ProjectBudgetRowsForFundingSource.length > 0) {
            for (var i = 0; i < ProjectBudgetRowsForFundingSource.length; ++i) {
                Sitka.Methods.removeFromJsonArray($scope.AngularModel.ProjectBudgets, ProjectBudgetRowsForFundingSource[i]);
            }
        }
    };

    $scope.setGroupByProjectCostType = function (showHide) { $scope.IsGroupedByProjectCostType = showHide; };

    $scope.existsInFundingSourcesNotShowingProjectCostTypes = function (fundingSourceId) { return _.contains($scope.FundingSourcesNotShowingProjectCostTypes, fundingSourceId); };

    $scope.removeFromFundingSourcesNotShowingProjectCostTypes = function (fundingSourceId) { Sitka.Methods.removeFromJsonArray($scope.FundingSourcesNotShowingProjectCostTypes, fundingSourceId); };

    $scope.addToFundingSourcesNotShowingProjectCostTypes = function (fundingSourceId) { $scope.FundingSourcesNotShowingProjectCostTypes.push(fundingSourceId); };

    $scope.showHideProjectCostTypes = function (fundingSourceId) {
        if ($scope.existsInFundingSourcesNotShowingProjectCostTypes(fundingSourceId)) {
            $scope.removeFromFundingSourcesNotShowingProjectCostTypes(fundingSourceId);
        }
        else {
            $scope.addToFundingSourcesNotShowingProjectCostTypes(fundingSourceId);
        }
    };

    $scope.existsInHiddenProjectCostTypes = function (ProjectCostType) { return _.contains($scope.HiddenProjectCostTypes, ProjectCostType.ProjectCostTypeID); };

    $scope.removeFromHiddenProjectCostTypes = function (ProjectCostType) { Sitka.Methods.removeFromJsonArray($scope.HiddenProjectCostTypes, ProjectCostType.ProjectCostTypeID); };

    $scope.addToHiddenProjectCostTypes = function (ProjectCostType) { $scope.HiddenProjectCostTypes.push(ProjectCostType.ProjectCostTypeID); };

    $scope.showHideFundingSources = function (ProjectCostType) {
        if ($scope.existsInHiddenProjectCostTypes(ProjectCostType)) {
            $scope.removeFromHiddenProjectCostTypes(ProjectCostType);
        }
        else {
            $scope.addToHiddenProjectCostTypes(ProjectCostType);
        }
    };

    $scope.AngularModel = angularModelAndViewData.AngularModel;
    $scope.AngularViewData = angularModelAndViewData.AngularViewData;
    $scope.ShowOnlyProjectFunders = false;
    $scope.FundingSourcesNotShowingProjectCostTypes = [];
    $scope.HiddenProjectCostTypes = [];
    $scope.IsGroupedByProjectCostType = false;
    $scope.resetFundingSourceToAdd();
    $scope.ProjectIDToAdd = $scope.AngularViewData.ProjectID;
});
