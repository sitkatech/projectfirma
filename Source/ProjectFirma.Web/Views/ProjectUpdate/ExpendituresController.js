angular.module("ProjectFirmaApp").controller("ExpendituresController", function($scope, angularModelAndViewData)
{
    $scope.resetFundingSourceToAdd = function() { $scope.FundingSourceToAdd = null; };

    $scope.getAllCalendarYearExpendituresAsFlattenedLoDashArray = function() { return _($scope.AngularModel.ProjectFundingSourceExpenditures).pluck("CalendarYearExpenditures").flatten(); }

    $scope.getAllUsedCalendarYears = function() { return $scope.getAllCalendarYearExpendituresAsFlattenedLoDashArray().pluck("CalendarYear").flatten().union().sortBy().value(); };

    $scope.getCalendarYearRange = function() { return _.union($scope.getAllUsedCalendarYears(), angularModelAndViewData.AngularViewData.CalendarYearRange); };

    $scope.getAllUsedFundingSourceIds = function() { return _.map($scope.AngularModel.ProjectFundingSourceExpenditures, function(p) { return p.FundingSourceID; }); };

    $scope.filteredFundingSources = function()
    {
        var usedFundingSourceIDs = $scope.getAllUsedFundingSourceIds();
        var projectFundingOrganizationFundingSourceIDs = _.map($scope.AngularViewData.AllFundingSources, function(p) { return p.FundingSourceID; });
        if ($scope.ShowOnlyProjectFunders)
        {
            projectFundingOrganizationFundingSourceIDs = $scope.AngularViewData.ProjectFundingOrganizationFundingSourceIDs;
        }
        return _($scope.AngularViewData.AllFundingSources).filter(function(f) { return f.IsActive && _.contains(projectFundingOrganizationFundingSourceIDs, f.FundingSourceID) && !_.contains(usedFundingSourceIDs, f.FundingSourceID); }).sortByAll(["OrganizationName", "FundingSourceName"]).value();
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

    $scope.deleteRow = function(rowToDelete) { Sitka.Methods.removeFromJsonArray($scope.AngularModel.ProjectFundingSourceExpenditures, rowToDelete); };

    $scope.AngularModel = angularModelAndViewData.AngularModel;
    $scope.AngularViewData = angularModelAndViewData.AngularViewData;
    $scope.ShowOnlyProjectFunders = false;
    $scope.resetFundingSourceToAdd();
    $scope.ProjectIDToAdd = $scope.AngularViewData.ProjectID;
});