/*-----------------------------------------------------------------------
<copyright file="ProjectFundingSourceBudgetController.js" company="Tahoe Regional Planning Agency">
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
angular.module("ProjectFirmaApp").controller("ProjectFundingSourceBudgetController", function ($scope, angularModelAndViewData)
{
    $scope.AngularModel = angularModelAndViewData.AngularModel;
    $scope.AngularViewData = angularModelAndViewData.AngularViewData;
    $scope.projectID = $scope.AngularViewData.ProjectID;

    $scope.$watch(function () {
        jQuery(".selectpicker").selectpicker("refresh");
    });

    $scope.resetFundingSourceIDToAdd = function () { $scope.FundingSourceIDToAdd = ($scope.FromFundingSource) ? $scope.getFundingSource(angularModelAndViewData.AngularViewData.FundingSourceID).FundingSourceID : null; };

    $scope.setSelectedFundingTypeID = function() {
        $scope.selectedFundingTypeID = $scope.AngularModel.FundingTypeID;
    };

    $scope.getAllUsedFundingSourceIds = function () {
        return _.map($scope.AngularModel.ProjectFundingSourceBudgets, function (p) { return p.FundingSourceID; });
    };

    $scope.filteredFundingSources = function () {
        var usedFundingSourceIDs = $scope.getAllUsedFundingSourceIds();
        return _($scope.AngularViewData.AllFundingSources).filter(function (f) {
            return f.IsActive && !_.contains(usedFundingSourceIDs, f.FundingSourceID);
        }).sortBy(function (fs) {
            return [fs.FundingSourceName.toLowerCase()];
        }).value();
    };

    $scope.getFundingSourceName = function (projectFundingSourceBudget) {
        var fundingSourceToFind = $scope.getFundingSource(projectFundingSourceBudget.FundingSourceID);
        return fundingSourceToFind.DisplayName;
    };

    $scope.getFundingSource = function (fundingSourceID) {
        return _.find($scope.AngularViewData.AllFundingSources, function (f) { return fundingSourceID == f.FundingSourceID; });
    };

    $scope.getTargetedTotal = function () {
        return Number(_.reduce($scope.AngularModel.ProjectFundingSourceBudgets, function (m, x) { return Number(m) + Number(x.TargetedAmount); }, 0));
    };

    $scope.getSecuredTotal = function () {
        return Number(_.reduce($scope.AngularModel.ProjectFundingSourceBudgets,
            function (m, x) { return Number(m) + Number(x.SecuredAmount); },
            0));
    };

    $scope.getTotal = function () {
        return Number($scope.getTargetedTotal()) + Number($scope.getSecuredTotal());
    }

    $scope.getRowTotal = function (projectFundingSourceBudget) {
        return Number(projectFundingSourceBudget.SecuredAmount) + Number(projectFundingSourceBudget.TargetedAmount);
    }
    
    $scope.findProjectFundingSourceBudgetRow = function(fundingSourceID) { return _.find($scope.AngularModel.ProjectFundingSourceBudgets, function(pfse) { return pfse.ProjectID == $scope.projectID && pfse.FundingSourceID == fundingSourceID; }); }

    $scope.addRow = function()
    {
        if ($scope.FundingSourceIDToAdd == null) {
            return;
        }
        var newProjectFundingSourceBudget = $scope.createNewRow($scope.FundingSourceIDToAdd);
        $scope.AngularModel.ProjectFundingSourceBudgets.push(newProjectFundingSourceBudget);
        $scope.resetFundingSourceIDToAdd();
    };

    $scope.createNewRow = function (fundingSourceID)
    {
        var fundingSource = $scope.getFundingSource(fundingSourceID);
        var newProjectFundingSourceBudget = {
            ProjectID: $scope.projectID,
            FundingSourceID: fundingSource.FundingSourceID,
            SecuredAmount: null,
            TargetedAmount: null
    };
        return newProjectFundingSourceBudget;
    };

    $scope.deleteRow = function (rowToDelete) {
        Sitka.Methods.removeFromJsonArray($scope.AngularModel.ProjectFundingSourceBudgets, rowToDelete);
    };

    $scope.fundingTypes = function() {
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

    $scope.resetFundingSourceIDToAdd();
    $scope.setSelectedFundingTypeID();
});

