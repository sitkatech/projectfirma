angular.module("ProjectFirmaApp").controller("EditBudgetTypeController", function ($scope, $timeout, angularModelAndViewData) {
    $scope.AngularViewData = angularModelAndViewData.AngularViewData;
    // The viewModel contains stuff that can't be serialized, so not using it for this mini-form

    $scope.selectedBudgetTypeID = $scope.AngularViewData.BudgetTypeID; 
    $scope.originalCostTypes = $scope.AngularViewData.CostTypes.slice();  // Make a copy so list won't change
    $scope.costTypes = $scope.AngularViewData.CostTypes;

    $scope.enteredCostType = "";

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
        return parseInt($scope.selectedBudgetTypeID) === requiresBudgetTypeID;
    }

    $scope.addCostType = function (enteredCostType) {
        if ($scope.costTypes.indexOf(enteredCostType) === -1) {
            $scope.costTypes.push(enteredCostType);
        }
    }

    $scope.removeCostType = function(costType) {
        if ($scope.costTypes.indexOf(costType) > -1) {
            $scope.costTypes.splice($scope.costTypes.indexOf(costType), 1);
        }
    }

    $scope.willDeleteCostType = function () {
        var missingValues = _.filter($scope.originalCostTypes, function(x) {
            return $scope.costTypes.indexOf(x) === -1;
        });
        return missingValues.length > 0;
    }


    $scope.selectedProjectCustomAttributeDataTypeHasMeasurementUnit = function () {
        return $scope.ProjectCustomAttributeDataTypeSelected != null &&
            $scope.ProjectCustomAttributeDataTypeSelected.HasMeasurementUnit;
    }

    $scope.selectedProjectCustomAttributeDataTypeHasOptions = function () {
        return $scope.ProjectCustomAttributeDataTypeSelected != null &&
            $scope.ProjectCustomAttributeDataTypeSelected.HasOptions;
    }

    $scope.addInput = function () {
        $scope.OptionsSchema.push("");
    }

    $scope.removeInput = function (index) {
        $scope.OptionsSchema.splice(index, 1);
    }

//    $scope.OptionsSchema = JSON.parse($scope.AngularModel.ProjectCustomAttributeTypeOptionsSchema) == undefined ? [] : JSON.parse($scope.AngularModel.ProjectCustomAttributeTypeOptionsSchema);
//    $scope.ProjectCustomAttributeDataTypeSelected = $scope.AngularModel.ProjectCustomAttributeDataTypeID != null
//        ? Sitka.Methods.findElementInJsonArray($scope.AngularViewData.ProjectCustomAttributeDataTypes,
//            "ID",
//            $scope.AngularModel.ProjectCustomAttributeDataTypeID)
//        : null;
});
