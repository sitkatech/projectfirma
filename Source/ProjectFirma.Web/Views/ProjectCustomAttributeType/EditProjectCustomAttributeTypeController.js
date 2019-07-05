angular.module("ProjectFirmaApp").controller("EditProjectCustomAttributeTypeController", function ($scope, $timeout, angularModelAndViewData) {
    $scope.AngularModel = angularModelAndViewData.AngularModel;
    $scope.AngularViewData = angularModelAndViewData.AngularViewData;
    $scope.OptionsSchema = JSON.parse($scope.AngularModel.ProjectCustomAttributeTypeOptionsSchema) == undefined ? [] : JSON.parse($scope.AngularModel.ProjectCustomAttributeTypeOptionsSchema);


    $scope.getProjectCustomAttributeDataType = function (idToFind) {
        return Sitka.Methods.findElementInJsonArray($scope.AngularViewData.ProjectCustomAttributeDataTypes, "ID", idToFind);
    }

    $scope.updateProjectCustomAttributeDataType = function () {
        var customAttributeDataType = $scope.getProjectCustomAttributeDataType($scope.ProjectCustomAttributeDataTypeID);
        $scope.ProjectCustomAttributeDataTypeSelected = customAttributeDataType;

        if ($scope.OptionsSchema.length == 0) {
            $scope.addInput();
        }
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

    $scope.submit = function () {
        $scope.AngularModel.ProjectCustomAttributeTypeOptionsSchema = JSON.stringify($scope.OptionsSchema);
    }

    $scope.ProjectCustomAttributeDataTypeSelected = $scope.AngularModel.ProjectCustomAttributeDataTypeID != null
        ? Sitka.Methods.findElementInJsonArray($scope.AngularViewData.ProjectCustomAttributeDataTypes,
            "ID",
            $scope.AngularModel.ProjectCustomAttributeDataTypeID)
        : null;
});
