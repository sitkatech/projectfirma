angular.module("ProjectFirmaApp").controller("EditFundingSourceCustomAttributeTypeController", function ($scope, $timeout, angularModelAndViewData) {
    $scope.AngularModel = angularModelAndViewData.AngularModel;
    $scope.AngularViewData = angularModelAndViewData.AngularViewData;
    $scope.OptionsSchema = JSON.parse($scope.AngularModel.FundingSourceCustomAttributeTypeOptionsSchema) == undefined ? [] : JSON.parse($scope.AngularModel.FundingSourceCustomAttributeTypeOptionsSchema);


    $scope.getFundingSourceCustomAttributeDataType = function (idToFind) {
        return Sitka.Methods.findElementInJsonArray($scope.AngularViewData.FundingSourceCustomAttributeDataTypes, "ID", idToFind);
    }

    $scope.updateFundingSourceCustomAttributeDataType = function () {
        var customAttributeDataType = $scope.getFundingSourceCustomAttributeDataType($scope.FundingSourceCustomAttributeDataTypeID);
        $scope.FundingSourceCustomAttributeDataTypeSelected = customAttributeDataType;

        if ($scope.OptionsSchema.length == 0) {
            $scope.addInput();
        }
    }

    $scope.selectedFundingSourceCustomAttributeDataTypeHasMeasurementUnit = function () {
        return $scope.FundingSourceCustomAttributeDataTypeSelected != null &&
            $scope.FundingSourceCustomAttributeDataTypeSelected.HasMeasurementUnit;
    }

    $scope.selectedFundingSourceCustomAttributeDataTypeHasOptions = function () {
        return $scope.FundingSourceCustomAttributeDataTypeSelected != null &&
            $scope.FundingSourceCustomAttributeDataTypeSelected.HasOptions;
    }

    $scope.addInput = function () {
        $scope.OptionsSchema.push("");
    }

    $scope.removeInput = function (index) {
        $scope.OptionsSchema.splice(index, 1);
    }

    $scope.submit = function () {
        $scope.AngularModel.FundingSourceCustomAttributeTypeOptionsSchema = JSON.stringify($scope.OptionsSchema);
    }

    $scope.FundingSourceCustomAttributeDataTypeSelected = $scope.AngularModel.FundingSourceCustomAttributeDataTypeID != null
        ? Sitka.Methods.findElementInJsonArray($scope.AngularViewData.FundingSourceCustomAttributeDataTypes,
            "ID",
            $scope.AngularModel.FundingSourceCustomAttributeDataTypeID)
        : null;
});
