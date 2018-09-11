/*-----------------------------------------------------------------------
<copyright file="ExpendituresController.js" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
angular.module("ProjectFirmaApp").controller("ExpendituresController", function($scope, angularModelAndViewData)
{
    $scope.$watch(function () {
        jQuery(".selectpicker").selectpicker("refresh");
    });

    $scope.resetFundingSourceToAdd = function() { $scope.FundingSourceToAdd = null; };

    $scope.getAllCalendarYearExpendituresAsFlattenedLoDashArray = function() { return _($scope.AngularModel.ProjectFundingSourceExpenditures).pluck("CalendarYearExpenditures").flatten(); }

    $scope.getAllUsedCalendarYears = function() { return $scope.getAllCalendarYearExpendituresAsFlattenedLoDashArray().pluck("CalendarYear").flatten().union().sortBy().value(); };

    $scope.getCalendarYearRange = function() {
        return _.sortBy(_.union($scope.getAllUsedCalendarYears(), $scope.AngularViewData.CalendarYearRange)).reverse();
    };

    $scope.getAllUsedFundingSourceIds = function() { return _.map($scope.AngularModel.ProjectFundingSourceExpenditures, function(p) { return p.FundingSourceID; }); };

    $scope.filteredFundingSources = function()
    {
        var usedFundingSourceIDs = $scope.getAllUsedFundingSourceIds();
        var projectFundingOrganizationFundingSourceIDs = _.map($scope.AngularViewData.AllFundingSources, function(p) { return p.FundingSourceID; });
        if ($scope.ShowOnlyProjectFunders)
        {
            projectFundingOrganizationFundingSourceIDs = $scope.AngularViewData.ProjectFundingOrganizationFundingSourceIDs;
        }
        return _($scope.AngularViewData.AllFundingSources).filter(function(f) { return f.IsActive && _.includes(projectFundingOrganizationFundingSourceIDs, f.FundingSourceID) && !_.includes(usedFundingSourceIDs, f.FundingSourceID); }).sortByAll(["FundingSourceName"]).value();
    };

    $scope.getFundingSourceName = function(projectFundingSourceExpenditure)
    {
        var fundingSourceToFind = $scope.getFundingSource(projectFundingSourceExpenditure.FundingSourceID);
        return fundingSourceToFind.DisplayName;
    };

    $scope.getFundingSource = function(fundingSourceId) { return _.find($scope.AngularViewData.AllFundingSources, function(f) { return fundingSourceId == f.FundingSourceID; }); };

    $scope.getExpenditureTotalForCalendarYear = function(calendarYear)
    {
        var calendarYearExpendituresAsFlattenedArray = $scope.getAllCalendarYearExpendituresAsFlattenedLoDashArray().filter(function(pfse) { return Sitka.Methods.isUndefinedNullOrEmpty(calendarYear) || pfse.CalendarYear == calendarYear; }).value();
        return $scope.calculateExpenditureTotal(calendarYearExpendituresAsFlattenedArray);
    };

    $scope.getExpenditureTotalForRow = function(projectFundingSourceExpenditure)
    {
        var calendarYearExpendituresAsFlattenedArray = _($scope.AngularModel.ProjectFundingSourceExpenditures).filter(function(pfse) { return pfse.ProjectID == projectFundingSourceExpenditure.ProjectID && pfse.FundingSourceID == projectFundingSourceExpenditure.FundingSourceID; }).pluck("CalendarYearExpenditures").flatten().value();
        return $scope.calculateExpenditureTotal(calendarYearExpendituresAsFlattenedArray);
    };

    $scope.calculateExpenditureTotal = function (expenditures) { return _.reduce(expenditures, function (m, x) { return m + x.MonetaryAmount; }, 0); }

    $scope.addCalendarYear = function(calendarYear)
    {
        if (Sitka.Methods.isUndefinedNullOrEmpty(calendarYear))
        {
            return;
        }
        _.each($scope.getAllUsedFundingSourceIds(), function(fundingSourceId) { $scope.addCalendarYearExpenditureRow($scope.ProjectIDToAdd, fundingSourceId, calendarYear); });
    };

    $scope.formatCalendarYear = function (calendarYear) { return $scope.AngularViewData.UseFiscalYears ? "FY" + calendarYear : calendarYear; };

    $scope.findProjectFundingSourceExpenditureRow = function(projectId, fundingSourceId) { return _.find($scope.AngularModel.ProjectFundingSourceExpenditures, function(pfse) { return pfse.ProjectID == projectId && pfse.FundingSourceID == fundingSourceId; }); }

    $scope.addRow = function()
    {
        if (($scope.FundingSourceToAdd == null) || ($scope.ProjectIDToAdd == null))
        {
            return;
        }
        var newProjectFundingSourceExpenditure = $scope.createNewRow($scope.ProjectIDToAdd, $scope.FundingSourceToAdd.FundingSourceID, $scope.getCalendarYearRange());
        $scope.AngularModel.ProjectFundingSourceExpenditures.push(newProjectFundingSourceExpenditure);
        $scope.resetFundingSourceToAdd();
    };

    $scope.createNewRow = function(projectId, fundingSourceId, calendarYearsToAdd)
    {
        var newProjectFundingSourceExpenditure = {
            ProjectID: projectId,
            FundingSourceID: fundingSourceId,
            CalendarYearExpenditures: _.map(calendarYearsToAdd, $scope.createNewCalendarYearExpenditureRow)
        };
        return newProjectFundingSourceExpenditure;
    };

    $scope.addCalendarYearExpenditureRow = function(projectId, fundingSourceId, calendarYear)
    {
        var projectFundingSourceExpenditure = $scope.findProjectFundingSourceExpenditureRow(projectId, fundingSourceId);
        if (!Sitka.Methods.isUndefinedNullOrEmpty(projectFundingSourceExpenditure))
        {
            projectFundingSourceExpenditure.CalendarYearExpenditures.push($scope.createNewCalendarYearExpenditureRow(calendarYear));
        }
    };

    $scope.createNewCalendarYearExpenditureRow = function(calendarYear)
    {
        return {
            CalendarYear: calendarYear,
            ExpenditureAmount: null
        };
    };

    $scope.selectAllYears = function (isChecked) {
        _.each($scope.AngularModel.ProjectExemptReportingYears,
            function(f) {
                f.IsExempt = isChecked;
            });
    };

    $scope.deleteRow = function(rowToDelete) { Sitka.Methods.removeFromJsonArray($scope.AngularModel.ProjectFundingSourceExpenditures, rowToDelete); };

    $scope.AngularModel = angularModelAndViewData.AngularModel;
    if ($scope.AngularModel.ProjectFundingSourceExpenditures == null) {
        $scope.AngularModel.ProjectFundingSourceExpenditures = [];
    }
    $scope.AngularViewData = angularModelAndViewData.AngularViewData;
    $scope.ShowOnlyProjectFunders = false;
    $scope.resetFundingSourceToAdd();
    $scope.ProjectIDToAdd = $scope.AngularViewData.ProjectID;
});
