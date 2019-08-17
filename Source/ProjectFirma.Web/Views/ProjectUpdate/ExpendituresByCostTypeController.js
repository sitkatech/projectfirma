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
angular.module("ProjectFirmaApp").controller("ExpendituresByCostTypeController", function($scope, angularModelAndViewData)
{
    $scope.AngularModel = angularModelAndViewData.AngularModel;
    $scope.AngularViewData = angularModelAndViewData.AngularViewData;

    if ($scope.AngularModel.ProjectFundingSourceExpenditures === null) {
        $scope.AngularModel.ProjectFundingSourceExpenditures = [];
    }

    $scope.$watch(function () {
        jQuery(".selectpicker").selectpicker("refresh");
    });

    $scope.resetfundingSourceIDToAdd = function () { $scope.fundingSourceIDToAdd = null; };

    $scope.getAllCalendarYearExpendituresAsFlattenedLoDashArray = function () {
        var relevantCostTypeIDs = $scope.getRelevantCostTypeIDs();
        return _($scope.AngularModel.ProjectFundingSourceExpenditures).filter(function (f) {
            return _.includes(relevantCostTypeIDs, f.CostTypeID);
        }).map("CalendarYearExpenditures")
            .flatten();
    };

    $scope.getAllUsedFundingSourceIds = function () { return _.uniq(_.map($scope.AngularModel.ProjectFundingSourceExpenditures, function (p) { return p.FundingSourceID; })); };

    $scope.filteredFundingSources = function () {
        var usedFundingSourceIDs = $scope.getAllUsedFundingSourceIds();
        var projectFundingOrganizationFundingSourceIDs = _.map($scope.AngularViewData.AllFundingSources, function (p) { return p.FundingSourceID; });
        var filteredFundingSources = _($scope.AngularViewData.AllFundingSources).filter(function (f) {
            return f.IsActive &&
                _.includes(projectFundingOrganizationFundingSourceIDs, f.FundingSourceID) &&
                !_.includes(usedFundingSourceIDs, f.FundingSourceID);
        }).sortBy(["OrganizationName", "FundingSourceName"]).value();
        return filteredFundingSources;
    };

    $scope.getFundingSourceName = function (fundingSource) { return $scope.getFundingSourceNameById(fundingSource.FundingSourceID); };

    $scope.getFundingSourceNameById = function (fundingSourceId) {
        var fundingSourceToFind = $scope.getFundingSource(fundingSourceId);
        return fundingSourceToFind.DisplayName;
    };

    $scope.getFundingSource = function (fundingSourceId) { return _.find($scope.AngularViewData.AllFundingSources, function (f) { return fundingSourceId == f.FundingSourceID; }); };

    $scope.getRelevantCostTypes = function () {
        var relevantCostTypes = _.sortBy(_.filter($scope.AngularModel.ProjectRelevantCostTypes, function (f) { return f.IsRelevant === true; }),
            function (c) {
                return c.CostTypeName;
            });
        return relevantCostTypes;
    };

    $scope.getRelevantCostTypeIDs = function () {
        return _.map($scope.getRelevantCostTypes(), function (f) { return f.CostTypeID; });
    };

    $scope.getRelevantProjectFundingSourceExpenditures = function () {
        if (!$scope.AngularModel.HasExpenditures) {
            return [];
        }
        var relevantCostTypeIDs = $scope.getRelevantCostTypeIDs();
        return _.filter($scope.AngularModel.ProjectFundingSourceExpenditures, function (f) { return _.includes(relevantCostTypeIDs, f.CostTypeID); });
    };

    $scope.getRelevantCalendarYearExpenditures = function (projectFundingSourceExpenditure) {
        return _.filter(projectFundingSourceExpenditure.CalendarYearExpenditures, function (f) { return f.IsRelevant; });
    };

    $scope.getCostTypeName = function (projectFundingSourceExpenditure) {
        var costTypeToFind = $scope.getCostType(projectFundingSourceExpenditure.CostTypeID);
        return costTypeToFind.CostTypeName;
    };

    $scope.getCostType = function (costTypeId) { return _.find($scope.getRelevantCostTypes(), function (f) { return costTypeId == f.CostTypeID; }); };

    $scope.getExpenditureTotalForCalendarYear = function (calendarYear) {
        var calendarYearExpendituresAsFlattenedArray = $scope.getAllCalendarYearExpendituresAsFlattenedLoDashArray().filter(function (pfse) { return Sitka.Methods.isUndefinedNullOrEmpty(calendarYear) || pfse.CalendarYear == calendarYear; }).value();
        return $scope.calculateExpenditureTotal(calendarYearExpendituresAsFlattenedArray);
    };

    $scope.getExpenditureTotalForFundingSourceAndCalendarYear = function (fundingSourceId, calendarYear) {
        var relevantCostTypeIDs = $scope.getRelevantCostTypeIDs();
        var calendarYearExpendituresAsFlattenedArray = _($scope.AngularModel.ProjectFundingSourceExpenditures)
            .filter(function (pfse) {
                return pfse.ProjectID == $scope.AngularViewData.ProjectID &&
                    pfse.FundingSourceID == fundingSourceId &&
                    _.includes(relevantCostTypeIDs, pfse.CostTypeID);
            }).map("CalendarYearExpenditures").flatten().filter(function (cye) {
                return cye.CalendarYear == calendarYear;
            }).value();
        return $scope.calculateExpenditureTotal(calendarYearExpendituresAsFlattenedArray);
    };

    $scope.getExpenditureTotalForFundingSource = function (fundingSourceId) {
        var relevantCostTypeIDs = $scope.getRelevantCostTypeIDs();
        var calendarYearExpendituresAsFlattenedArray = _($scope.AngularModel.ProjectFundingSourceExpenditures)
            .filter(function (pfse) {
                return pfse.ProjectID == $scope.AngularViewData.ProjectID &&
                    pfse.FundingSourceID == fundingSourceId &&
                    _.includes(relevantCostTypeIDs, pfse.CostTypeID);
            }).map("CalendarYearExpenditures").flatten().value();
        return $scope.calculateExpenditureTotal(_.filter(calendarYearExpendituresAsFlattenedArray, function (f) { return f.IsRelevant; }));
    };

    $scope.getExpenditureTotalForRow = function (projectFundingSourceExpenditure) {
        var calendarYearExpendituresAsFlattenedArray = _($scope.AngularModel.ProjectFundingSourceExpenditures)
            .filter(function (pfse) {
                return pfse.ProjectID == projectFundingSourceExpenditure.ProjectID &&
                    pfse.FundingSourceID == projectFundingSourceExpenditure.FundingSourceID &&
                    pfse.CostTypeID ==
                    projectFundingSourceExpenditure.CostTypeID;
            }).map("CalendarYearExpenditures").flatten().value();
        return $scope.calculateExpenditureTotal(_.filter(calendarYearExpendituresAsFlattenedArray, function (f) { return f.IsRelevant; }));
    };

    $scope.calculateExpenditureTotal = function (expenditures) {
        return _(expenditures)
            .filter(function (f) { return !Sitka.Methods.isUndefinedNullOrEmpty(f.MonetaryAmount); })
            .reduce(function (m, x) { return Number(m) + Number(x.MonetaryAmount); }, 0);
    };

    $scope.addCalendarYear = function (calendarYear) {
        if (Sitka.Methods.isUndefinedNullOrEmpty(calendarYear)) {
            return;
        }
        _.each($scope.getAllUsedFundingSourceIds(), function (fundingSourceId) { $scope.addCalendarYearExpenditureRow(fundingSourceId, calendarYear); });
        $scope.calendarYearRange.splice(_.sortedIndex($scope.calendarYearRange, calendarYear), 0, calendarYear);
    };

    $scope.getProjectFundingSourceExpenditureRowsForFundingSource = function (fundingSourceId) {
        var relevantCostTypeIDs = $scope.getRelevantCostTypeIDs();
        return _.sortBy(_.filter($scope.AngularModel.ProjectFundingSourceExpenditures,
            function (pfse) {
                return pfse.ProjectID == $scope.AngularViewData.ProjectID && pfse.FundingSourceID == fundingSourceId && _.includes(relevantCostTypeIDs, pfse.CostTypeID);
            }), function (f) {
                    return $scope.getCostTypeName(f);
                });
    };

    $scope.addRow = function () {
        if ($scope.fundingSourceIDToAdd == null) {
            return;
        }
        for (var i = 0; i < $scope.AngularModel.ProjectRelevantCostTypes.length; ++i) {
            var projectRelevantCostTypes = $scope.AngularModel.ProjectRelevantCostTypes[i];
            var newProjectFundingSourceExpenditure = $scope.createNewRow($scope.AngularViewData.ProjectID, parseInt($scope.fundingSourceIDToAdd), projectRelevantCostTypes.CostTypeID, $scope.calendarYearRange, projectRelevantCostTypes.IsRelevant);
            $scope.AngularModel.ProjectFundingSourceExpenditures.push(newProjectFundingSourceExpenditure);
        }
        $scope.resetfundingSourceIDToAdd();
    };

    $scope.createNewRow = function (projectId, fundingSourceId, costTypeId, calendarYearsToAdd, isRelevant) {
        var newProjectFundingSourceExpenditure = {
            ProjectID: projectId,
            FundingSourceID: fundingSourceId,
            CostTypeID: costTypeId,
            IsRelevant: isRelevant,
            CalendarYearExpenditures: _.map(calendarYearsToAdd, $scope.createNewCalendarYearExpenditureRow)
        };
        return newProjectFundingSourceExpenditure;
    };

    $scope.addCalendarYearExpenditureRow = function (fundingSourceId, calendarYear) {
        var projectFundingSourceExpenditureRowsForFundingSource = $scope.getProjectFundingSourceExpenditureRowsForFundingSource(fundingSourceId);
        if (projectFundingSourceExpenditureRowsForFundingSource.length > 0) {
            for (var i = 0; i < projectFundingSourceExpenditureRowsForFundingSource.length; ++i) {
                var existingCalendarYearExpenditure = _.find(projectFundingSourceExpenditureRowsForFundingSource[i].CalendarYearExpenditures,
                    function (cye) {
                        return cye.CalendarYear == calendarYear;
                    });
                if (Sitka.Methods.isUndefinedNullOrEmpty(existingCalendarYearExpenditure)) {
                    projectFundingSourceExpenditureRowsForFundingSource[i].CalendarYearExpenditures.push(
                        $scope.createNewCalendarYearExpenditureRow(calendarYear));
                } else {
                    existingCalendarYearExpenditure.IsRelevant = true;
                }
            }
        }
    };

    $scope.createNewCalendarYearExpenditureRow = function (calendarYear) {
        return {
            CalendarYear: calendarYear,
            MonetaryAmount: 0,
            IsRelevant: true
        };
    };

    $scope.deleteFundingSourceRow = function (fundingSourceId) {
        var projectFundingSourceExpenditureRowsForFundingSource = _.filter($scope.AngularModel.ProjectFundingSourceExpenditures,
            function (pfse) {
                return pfse.ProjectID == $scope.AngularViewData.ProjectID && pfse.FundingSourceID == fundingSourceId;
            });
        if (projectFundingSourceExpenditureRowsForFundingSource.length > 0) {
            for (var i = 0; i < projectFundingSourceExpenditureRowsForFundingSource.length; ++i) {
                Sitka.Methods.removeFromJsonArray($scope.AngularModel.ProjectFundingSourceExpenditures, projectFundingSourceExpenditureRowsForFundingSource[i]);
            }
        }
    };

    $scope.deleteCalendarYear = function (calendarYear) {
        _.each($scope.AngularModel.ProjectFundingSourceExpenditures, function (pfse) {
            var calendarYearExpenditures = _.filter(pfse.CalendarYearExpenditures, function (cye) { return cye.CalendarYear == calendarYear });
            _.each(calendarYearExpenditures, function (cye) { cye.IsRelevant = false; });
        });
        _.pull($scope.calendarYearRange, calendarYear);
    };

    $scope.addRemoveCostTypeFromExpenditures = function () {
        // when adding cost types, we need to populate CalendarYearExpenditures with any missing years
        var calendarYearsToAdd = $scope.calendarYearRange;
        if (calendarYearsToAdd.length > 0) {
            var projectFundingSourceExpendituresToUpdate = $scope.getRelevantProjectFundingSourceExpenditures();
            _.each(projectFundingSourceExpendituresToUpdate,
                function (pfse) {
                    if (Sitka.Methods.isUndefinedNullOrEmpty(pfse.CalendarYearExpenditures)) {
                        pfse.CalendarYearExpenditures = [];
                    }
                    _.each(calendarYearsToAdd,
                        function (calendarYear) {
                            var existingCalendarYearExpenditure = _.find(pfse.CalendarYearExpenditures,
                                function (cye) {
                                    return cye.CalendarYear == calendarYear;
                                });
                            if (existingCalendarYearExpenditure == null) {
                                pfse.CalendarYearExpenditures.push($scope.createNewCalendarYearExpenditureRow(calendarYear));
                            }
                        });
                });
        }

        var relevantCostTypeIDs = $scope.getRelevantCostTypeIDs();
        _.each($scope.AngularModel.ProjectFundingSourceExpenditures,
            function (f) {
                f.IsRelevant = _.includes(relevantCostTypeIDs, f.CostTypeID);
            });
    };

    $scope.canDeleteCalendarYear = function (calendarYear) {
        return $scope.calendarYearRange.length > 1 &&
            !_.includes($scope.AngularViewData.RequiredCalendarYearRange, calendarYear);
    };

    $scope.onTextFocus = function ($event) {
        $event.target.select();
    };

    $scope.calendarYearRange = _.sortBy(_.union($scope.getAllCalendarYearExpendituresAsFlattenedLoDashArray().map("CalendarYear").flatten().union().value(), $scope.AngularViewData.RequiredCalendarYearRange));
    $scope.resetfundingSourceIDToAdd();
});
