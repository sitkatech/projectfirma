/*-----------------------------------------------------------------------
<copyright file="ExpectedFundingByCostTypeController.js" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
angular.module("ProjectFirmaApp").controller("ExpectedFundingByCostTypeController", function($scope, angularModelAndViewData)
{
    $scope.AngularModel = angularModelAndViewData.AngularModel;
    $scope.AngularViewData = angularModelAndViewData.AngularViewData;

    $scope.$watch(function () {
        jQuery(".selectpicker").selectpicker("refresh");
    });

    $scope.resetfundingSourceIDToAdd = function () { $scope.fundingSourceIDToAdd = null; };

    $scope.setSelectedFundingTypeID = function () {
        $scope.selectedFundingTypeID = $scope.AngularModel.FundingTypeID;
    };

    $scope.getAllCalendarYearBudgetsAsFlattenedLoDashArray = function () { return _($scope.AngularModel.ProjectFundingSourceBudgets).map("CalendarYearBudgets").flatten(); }

    $scope.getAllUsedCalendarYears = function () { return $scope.getAllCalendarYearBudgetsAsFlattenedLoDashArray().map("CalendarYear").flatten().union().sortBy().value(); };

    $scope.getAllUsedCalendarYearsNoFundingSourceIdentifieds = function () { return _($scope.AngularModel.NoFundingSourceAmounts).map("CalendarYear").flatten().union().sortBy().value(); };

    $scope.getCalendarYearRange = function() {
        return _.sortBy(_.union($scope.getAllUsedCalendarYears(), $scope.getAllUsedCalendarYearsNoFundingSourceIdentifieds(), angularModelAndViewData.AngularViewData.CalendarYearRange));
    };

    $scope.getAllUsedFundingSourceIds = function () { return _.uniq(_.map($scope.AngularModel.ProjectFundingSourceBudgets, function (p) { return p.FundingSourceID; })); };

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

    $scope.getCostTypeName = function (projectFundingSourceBudget) {
        var costTypeToFind = $scope.getCostType(projectFundingSourceBudget.CostTypeID);
        return costTypeToFind.CostTypeName;
    };

    $scope.getCostType = function (costTypeId) { return _.find($scope.AngularViewData.AllCostTypes, function (f) { return costTypeId == f.CostTypeID; }); };

    $scope.getBudgetTotalForCalendarYear = function (calendarYear, isSecured) {
        var calendarYearBudgetsAsFlattenedArray = $scope.getAllCalendarYearBudgetsAsFlattenedLoDashArray().filter(function (pfse) { return Sitka.Methods.isUndefinedNullOrEmpty(calendarYear) || pfse.CalendarYear == calendarYear; }).value();
        if (isSecured == null) {
            return $scope.calculateBudgetTotal(calendarYearBudgetsAsFlattenedArray);
        } else if (isSecured) {
            return $scope.calculateBudgetSecuredTotal(calendarYearBudgetsAsFlattenedArray);
        } else {
            return $scope.calculateBudgetTargetedTotal(calendarYearBudgetsAsFlattenedArray);
        }
    };

    $scope.getTotalForCalendarYear = function (calendarYear, isSecured) {
        return $scope.getBudgetTotalForCalendarYear(calendarYear, isSecured) +
            $scope.getNoFundingSourceIdentifiedTotalForCalendarYear(calendarYear);
    };

    $scope.getTotalSameEachYear = function (isSecured) {
        if (isSecured == null) {
            // return secured + targeted + no funding source
            return $scope.calculateBudgetTotal($scope.AngularModel.ProjectFundingSourceBudgets) + Number($scope.AngularModel.NoFundingSourceIdentifiedYet);
        } else if (isSecured) {
            // return secured
            return $scope.calculateBudgetSecuredTotal($scope.AngularModel.ProjectFundingSourceBudgets);
        } else {
            // return targeted + no funding source (which is in the target column)
            return $scope.calculateBudgetTargetedTotal($scope.AngularModel.ProjectFundingSourceBudgets) + Number($scope.AngularModel.NoFundingSourceIdentifiedYet);
        }
    };

    $scope.getNoFundingSourceIdentifiedTotalForCalendarYear = function (calendarYear) {
        var calendarYearNoFundingSourceIdentifiedArray =
            $scope.AngularModel.NoFundingSourceAmounts.filter(
                function(pfse) {
                    return Sitka.Methods.isUndefinedNullOrEmpty(calendarYear) || pfse.CalendarYear == calendarYear;
                });
        return $scope.calculateNoFundingSourceIdentifiedTotal(calendarYearNoFundingSourceIdentifiedArray);
    };

    $scope.getBudgetTotalForFundingSourceAndCalendarYear = function (fundingSourceId, calendarYear, isSecured) {
        var calendarYearBudgetsAsFlattenedArray = _($scope.AngularModel.ProjectFundingSourceBudgets)
            .filter(function (pfse) {
                return pfse.ProjectID == $scope.AngularViewData.ProjectID &&
                    pfse.FundingSourceID == fundingSourceId;
            }).map("CalendarYearBudgets").flatten().filter(function (cye) {
                return cye.CalendarYear == calendarYear;
            }).value();

        if (isSecured) {
            return $scope.calculateBudgetSecuredTotal(calendarYearBudgetsAsFlattenedArray);
        } else {
            return $scope.calculateBudgetTargetedTotal(calendarYearBudgetsAsFlattenedArray);
        }
    };

    $scope.getBudgetTotalForFundingSource = function (fundingSourceId) {
        var calendarYearBudgetsAsFlattenedArray = _($scope.AngularModel.ProjectFundingSourceBudgets)
            .filter(function (pfse) {
                return pfse.ProjectID == $scope.AngularViewData.ProjectID &&
                    pfse.FundingSourceID == fundingSourceId;
            }).map("CalendarYearBudgets").flatten().value();
        return $scope.calculateBudgetTotal(calendarYearBudgetsAsFlattenedArray);
    };

    $scope.getBudgetTotalForFundingSourceSameEachYear = function (fundingSourceId, isSecured) {
        var budgetsForFundingSourceArray =
            $scope.AngularModel.ProjectFundingSourceBudgets.filter(
                function (pfse) {
                    return pfse.ProjectID == $scope.AngularViewData.ProjectID &&
                        pfse.FundingSourceID == fundingSourceId;
                });

        if (isSecured == null) {
            // get secured + targeted total
            return $scope.calculateBudgetTotal(budgetsForFundingSourceArray);
        } else if (isSecured) {
            return $scope.calculateBudgetSecuredTotal(budgetsForFundingSourceArray);
        } else {
            return $scope.calculateBudgetTargetedTotal(budgetsForFundingSourceArray);
        }
    }

    $scope.getBudgetTotalForRow = function (projectFundingSourceBudget) {
        var calendarYearBudgetsAsFlattenedArray = _($scope.AngularModel.ProjectFundingSourceBudgets)
            .filter(function (pfse) {
                return pfse.ProjectID == projectFundingSourceBudget.ProjectID &&
                    pfse.FundingSourceID == projectFundingSourceBudget.FundingSourceID &&
                    pfse.CostTypeID ==
                    projectFundingSourceBudget.CostTypeID;
            }).map("CalendarYearBudgets").flatten().value();
        return $scope.calculateBudgetTotal(calendarYearBudgetsAsFlattenedArray);
    };

    $scope.getBudgetTotalForRowSameEachYear = function (projectFundingSourceBudget) {
        return Number(projectFundingSourceBudget.SecuredAmount) + Number(projectFundingSourceBudget.TargetedAmount);
    };

    $scope.calculateBudgetTotal = function (budgets) {
        return $scope.calculateBudgetSecuredTotal(budgets) + $scope.calculateBudgetTargetedTotal(budgets);
    };

    $scope.calculateBudgetSecuredTotal = function (budgets) {
        return _(budgets)
            .filter(function (f) { return !Sitka.Methods.isUndefinedNullOrEmpty(f.SecuredAmount); })
            .reduce(function (m, x) { return Number(m) + Number(x.SecuredAmount); }, 0);
    };

    $scope.calculateBudgetTargetedTotal = function (budgets) {
        return _(budgets)
            .filter(function (f) { return !Sitka.Methods.isUndefinedNullOrEmpty(f.TargetedAmount); })
            .reduce(function (m, x) { return Number(m) + Number(x.TargetedAmount); }, 0);
    };

    $scope.calculateNoFundingSourceIdentifiedTotal = function (noFundingSourceIdentifieds) {
        return _(noFundingSourceIdentifieds)
            .filter(function (f) { return !Sitka.Methods.isUndefinedNullOrEmpty(f.MonetaryAmount); })
            .reduce(function (m, x) { return Number(m) + Number(x.MonetaryAmount); }, 0);
    }

    $scope.addCalendarYear = function (calendarYear) {
        if (Sitka.Methods.isUndefinedNullOrEmpty(calendarYear)) {
            return;
        }
        _.each($scope.getAllUsedFundingSourceIds(), function (fundingSourceId) { $scope.addCalendarYearBudgetRow($scope.AngularViewData.ProjectID, fundingSourceId, calendarYear); });
        $scope.addCalendarYearNoFundingSourceIdentifiedRow($scope.AngularViewData.ProjectID, calendarYear);
    };

    $scope.getProjectFundingSourceBudgetRowsForFundingSource = function (fundingSourceId) {
        return _.filter($scope.AngularModel.ProjectFundingSourceBudgets,
            function (pfse) {
                return pfse.ProjectID == $scope.AngularViewData.ProjectID && pfse.FundingSourceID == fundingSourceId;
            });
    }

    $scope.getProjectFundingSourceBudgetRowsForCostType = function (fundingSourceID) { return _.filter($scope.AngularModel.ProjectFundingSourceBudgets, function (pfse) { return pfse.ProjectID == $scope.AngularViewData.ProjectID && pfse.FundingSourceID == fundingSourceID; }); }


    $scope.getCalendarYearBudgets = function (projectFundingSourceBudget) {
        // when switching from "budget is the same each year" to "budget varies by year" the CalendarYearBudgets can be empty
        $scope.populateCalendarYearBudgets(projectFundingSourceBudget);
        return projectFundingSourceBudget.CalendarYearBudgets;
    }

    $scope.populateCalendarYearBudgets = function (projectFundingSourceBudget) {
        // TODO actually implement this correctly. Trying to do it too quickly and failing :( 
        var calendarYearsToAdd = _.difference($scope.getCalendarYearRange(), _(projectFundingSourceBudget.CalendarYearBudgets).map("CalendarYear").flatten().union().sortBy().value());
        if (calendarYearsToAdd.length > 0) {
            var projectFundingSourceBudgetsToUpdate = _.filter($scope.AngularModel.ProjectFundingSourceBudgets,
                function (pfsb) {
                    return pfsb.ProjectID == $scope.AngularViewData.ProjectID &&
                        pfsb.FundingSourceID == projectFundingSourceBudget.FundingSourceID;
                });
            _.each(projectFundingSourceBudgetsToUpdate,
                function (pfsb) {
                    if (Sitka.Methods.isUndefinedNullOrEmpty(pfsb.CalendarYearBudgets)) {
                        pfsb.CalendarYearBudgets = [];
                    }
                    _.each(calendarYearsToAdd, function (calendarYear) {
                        pfsb.CalendarYearBudgets.push($scope.createNewCalendarYearBudgetRow(calendarYear));
                    });
                });
        }
    }

    $scope.addRow = function () {
        if ($scope.fundingSourceIDToAdd == null) {
            return;
        }
        for (var i = 0; i < $scope.AngularViewData.AllCostTypes.length; ++i) {
            var newProjectFundingSourceBudget = $scope.createNewRow($scope.AngularViewData.ProjectID, parseInt($scope.fundingSourceIDToAdd), $scope.AngularViewData.AllCostTypes[i].CostTypeID, $scope.getCalendarYearRange());
            $scope.AngularModel.ProjectFundingSourceBudgets.push(newProjectFundingSourceBudget);
        }
        $scope.resetfundingSourceIDToAdd();
    };

    $scope.createNewRow = function (projectId, fundingSourceId, costTypeId, calendarYearsToAdd) {
        var newProjectFundingSourceBudget = {
            ProjectID: projectId,
            FundingSourceID: fundingSourceId,
            CostTypeID: costTypeId,
            CalendarYearBudgets: _.map(calendarYearsToAdd, $scope.createNewCalendarYearBudgetRow)
        };
        return newProjectFundingSourceBudget;
    };

    $scope.addCalendarYearBudgetRow = function (projectId, fundingSourceId, calendarYear) {
        var projectFundingSourceBudgetRowsForFundingSource = $scope.getProjectFundingSourceBudgetRowsForFundingSource(fundingSourceId);
        if (projectFundingSourceBudgetRowsForFundingSource.length > 0) {
            for (var i = 0; i < projectFundingSourceBudgetRowsForFundingSource.length; ++i) {
                projectFundingSourceBudgetRowsForFundingSource[i].CalendarYearBudgets.push($scope.createNewCalendarYearBudgetRow(calendarYear));
            }
        }
    };

    $scope.createNewCalendarYearBudgetRow = function (calendarYear) {
        return {
            CalendarYear: calendarYear,
            SecuredAmount: null,
            TargetedAmount: null
        };
    };

    $scope.getNoFundingSourceAmounts = function () {
        var calendarYearsToAdd = _.difference($scope.getCalendarYearRange(), $scope.getAllUsedCalendarYearsNoFundingSourceIdentifieds());
        _.each(calendarYearsToAdd, function (calendarYear) { $scope.addCalendarYearNoFundingSourceIdentifiedRow($scope.AngularViewData.ProjectID, calendarYear); });

        return $scope.AngularModel.NoFundingSourceAmounts;
    }

    $scope.addCalendarYearNoFundingSourceIdentifiedRow = function (projectId, calendarYear) {
        if ($scope.AngularModel.NoFundingSourceAmounts == null) {
            $scope.AngularModel.NoFundingSourceAmounts = []
        }
        $scope.AngularModel.NoFundingSourceAmounts.push(
            $scope.createNewCalendarYearNoFundingIdentifiedRow(calendarYear));
    };

    $scope.createNewCalendarYearNoFundingIdentifiedRow = function (calendarYear) {
        return {
            CalendarYear: calendarYear,
            NoFundingSourceAmount: null
        };
    };

    $scope.getCalendarYearNoFundingSourceIdentifieds = function() {
        var projectNoFundingSourceIdentifieds = $scope.AngularModel.NoFundingSourceIdentifieds;
        return projectNoFundingSourceIdentifieds.CalendarYearNoFundingSourceIdentifieds;
    }

    $scope.deleteFundingSourceRow = function (fundingSourceId) {
        var projectFundingSourceBudgetRowsForFundingSource = $scope.getProjectFundingSourceBudgetRowsForFundingSource(fundingSourceId);
        if (projectFundingSourceBudgetRowsForFundingSource.length > 0) {
            for (var i = 0; i < projectFundingSourceBudgetRowsForFundingSource.length; ++i) {
                Sitka.Methods.removeFromJsonArray($scope.AngularModel.ProjectFundingSourceBudgets, projectFundingSourceBudgetRowsForFundingSource[i]);
            }
        }
    };

    $scope.fundingTypes = function () {
        return $scope.AngularViewData.FundingTypes;
    }

    $scope.budgetVariesByYear = function () {
        var selectedFundingTypeID = typeof $scope.selectedFundingTypeID === "number" ? $scope.selectedFundingTypeID : parseInt($scope.selectedFundingTypeID);
        return selectedFundingTypeID === 1;
    }

    $scope.budgetSameEachYear = function () {
        var selectedFundingTypeID = typeof $scope.selectedFundingTypeID === "number" ? $scope.selectedFundingTypeID : parseInt($scope.selectedFundingTypeID);
        return selectedFundingTypeID === 2;
    }

    $scope.budgetTypeNotSelected = function () {
        return !$scope.budgetVariesByYear() && !$scope.budgetSameEachYear();
    }

    $scope.resetfundingSourceIDToAdd();
    $scope.setSelectedFundingTypeID();
});
