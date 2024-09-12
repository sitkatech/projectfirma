angular.module("ProjectFirmaApp").controller("EditOrganizationRelationshipTypeController", function ($scope, $timeout, angularModelAndViewData) {
    $scope.AngularModel = angularModelAndViewData.AngularModel;

    $scope.IsPrimaryContact = $scope.AngularModel.IsPrimaryContact;
    $scope.IsOrganizationRelationshipTypeRequired = $scope.AngularModel.IsOrganizationRelationshipTypeRequired;

    $scope.radioButtonChanged = function () {
        if ($scope.IsPrimaryContact === true) {
            $scope.IsOrganizationRelationshipTypeRequired = true;
        }
    }
});