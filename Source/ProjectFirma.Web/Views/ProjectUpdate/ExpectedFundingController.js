/*-----------------------------------------------------------------------
<copyright file="ExpectedFundingController.js" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
angular.module("ProjectFirmaApp").controller("ExpectedFundingController", function($scope, angularModelAndViewData)
{
    $scope.AngularModel = angularModelAndViewData.AngularModel;
    $scope.AngularViewData = angularModelAndViewData.AngularViewData;

    $scope.$watch(function () {
        jQuery(".selectpicker").selectpicker("refresh");
    });

    $scope.resetFundingSourceToAdd = function () { $scope.FundingSourceToAdd = null; };

    $scope.getAllUsedFundingSourceIds = function () { return _.map($scope.AngularModel.ProjectFundingSourceBudgetUpdateSimples, function (p) { return p.FundingSourceID; }); };

    $scope.setSelectedFundingTypeID = function () {
        $scope.selectedFundingTypeID = $scope.AngularModel.FundingTypeID;
    };

    $scope.filteredFundingSources = function () {
        var unknownFundingSourceNames = [
            "Unknown/Unassigned",
            "Unknown",
            "Unspecified"
        ];
        var usedFundingSourceIDs = $scope.getAllUsedFundingSourceIds();
        return _($scope.AngularViewData.AllFundingSources).filter(function (f) { return f.IsActive && !_.includes(usedFundingSourceIDs, f.FundingSourceID) && !_.contains(unknownFundingSourceNames, f.FundingSourceName); })
            .sortBy(function (fs) {
                return [fs.FundingSourceName.toLowerCase(), fs.OrganizationName.toLowerCase()];
            }).value();
    };


    $scope.getFundingSourceName = function(projectFundingSourceBudgetUpdateSimple)
    {
        var fundingSourceToFind = $scope.getFundingSource(projectFundingSourceBudgetUpdateSimple.FundingSourceID);
        return fundingSourceToFind.DisplayName;
    };

    $scope.getFundingSource = function (fundingSourceID) { return _.find($scope.AngularViewData.AllFundingSources, function (f) { return fundingSourceID == f.FundingSourceID; }); };

    $scope.getTargetedTotal = function () {
        return Number(_.reduce($scope.AngularModel.ProjectFundingSourceBudgetUpdateSimples, function (m, x) { return Number(m) + Number(x.TargetedAmount); }, 0));
    };

    $scope.getSecuredTotal = function () {
        return Number(_.reduce($scope.AngularModel.ProjectFundingSourceBudgetUpdateSimples,
            function(m, x) { return Number(m) + Number(x.SecuredAmount); },
            0));
    };

    $scope.getTotal = function() {
        return Number($scope.getTargetedTotal()) + Number($scope.getSecuredTotal());
    }

    $scope.getRowTotal = function (projectFundingSourceBudgetUpdateSimple) {
        return Number(projectFundingSourceBudgetUpdateSimple.SecuredAmount) + Number(projectFundingSourceBudgetUpdateSimple.TargetedAmount);
    }

    $scope.getTotalEstimatedCost = function () {
        return Number($scope.AngularModel.NoFundingSourceIdentifiedYet) + $scope.getTotal();
    }

    $scope.findProjectFundingSourceBudgetUpdateSimpleRow = function(projectUpdateBatchID, fundingSourceID) { return _.find($scope.AngularModel.ProjectFundingSourceBudgetUpdateSimples, function(pfse) { return pfse.ProjectUpdateBatchID == projectUpdateBatchID && pfse.FundingSourceID == fundingSourceID; }); }

    $scope.addRow = function()
    {
        if ($scope.FundingSourceIDToAdd == null)
        {
            return;
        }
        var newProjectFundingSourceBudgetUpdateSimple = $scope.createNewRow($scope.ProjectUpdateBatchIDToAdd, $scope.FundingSourceIDToAdd);
        $scope.AngularModel.ProjectFundingSourceBudgetUpdateSimples.push(newProjectFundingSourceBudgetUpdateSimple);
        $scope.resetFundingSourceToAdd();
    };

    $scope.createNewRow = function(projectUpdateBatchID, fundingSourceID)
    {
        var fundingSource = $scope.getFundingSource(fundingSourceID);
        var newProjectFundingSourceBudgetUpdateSimple = {
            ProjectUpdateBatchID: projectUpdateBatchID,
            FundingSourceID: fundingSource.FundingSourceID,
            SecuredAmount: null,
            TargetedAmount: null
        };
        return newProjectFundingSourceBudgetUpdateSimple;
    };

    $scope.budgetVariesByYear = function () {
        return $scope.AngularViewData.FundingTypeID === 1;
    }

    $scope.budgetSameEachYear = function () {
        return $scope.AngularViewData.FundingTypeID === 2;
    }

    $scope.deleteRow = function (rowToDelete) { Sitka.Methods.removeFromJsonArray($scope.AngularModel.ProjectFundingSourceBudgetUpdateSimples, rowToDelete); };

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

    $scope.getYearRange = function () {
        var startYear = $scope.AngularViewData.PlanningDesignStartYear === null
            ? "Start"
            : $scope.AngularViewData.PlanningDesignStartYear;
        var endYear = $scope.AngularViewData.CompletionYear === null
            ? "End"
            : $scope.AngularViewData.CompletionYear;
        return startYear + " - " + endYear;
    }

    $scope.resetFundingSourceToAdd();
    $scope.ProjectUpdateBatchIDToAdd = $scope.AngularViewData.ProjectUpdateBatchID;
    $scope.setSelectedFundingTypeID();
});
