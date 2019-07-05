angular.module("ProjectFirmaApp").controller(
    "EditBudgetTypeController", function($scope, $timeout, angularModelAndViewData) {
        $scope.AngularViewData = angularModelAndViewData.AngularViewData;
        // The viewModel contains stuff that can't be serialized, so not using it for this mini-form

        $scope.originalCostTypes = $scope.AngularViewData.CostTypes.slice(); // Make a copy so list won't change

        $scope.model = {
            costTypes: $scope.AngularViewData.CostTypes,
            enteredCostType: "",
            selectedBudgetTypeID: $scope.AngularViewData.BudgetTypeID
        };

    $scope.getBudgetTypeID = function(budgetTypeDisplayName) {
        var id = _.findKey($scope.AngularViewData.BudgetTypes,
            function(x) {
                return x === budgetTypeDisplayName;
            });
        return parseInt(id);
    }

    $scope.isSelected = function (budgetTypeDisplayName) {
        return $scope.getBudgetTypeID(budgetTypeDisplayName) === $scope.AngularViewData.BudgetTypeID;
    }

    $scope.isDisabled = function(budgetTypeDisplayName) {
        return budgetTypeDisplayName === "No Budget" || budgetTypeDisplayName === "Annual Budget";
    }

    $scope.budgetTypeRequiresCostTypes = function () {
        var requiresBudgetTypeID = $scope.AngularViewData.BudgetTypeIDRequiringCostType;
        return parseInt($scope.model.selectedBudgetTypeID) === requiresBudgetTypeID;
    }

    $scope.addCostType = function () {
        if ($scope.model.costTypes.indexOf($scope.model.enteredCostType) === -1) {
            $scope.model.costTypes.push($scope.model.enteredCostType);
        }
        $scope.model.enteredCostType  = ""; // Why isn't this clearing  the input field?
    }

    $scope.removeCostType = function(costType) {
        if ($scope.model.costTypes.indexOf(costType) > -1) {
            $scope.model.costTypes.splice($scope.model.costTypes.indexOf(costType), 1);
        }
    }

    $scope.willDeleteCostType = function () {
        var missingValues = _.filter($scope.originalCostTypes, function(x) {
            return $scope.model.costTypes.indexOf(x) === -1;
        });
        return missingValues.length > 0;
    }
});
