angular.module("ProjectFirmaApp").controller("EditOrganizationRelationshipTypeController", function ($scope, $timeout, angularModelAndViewData) {
    $scope.AngularModel = angularModelAndViewData.AngularModel;

    $scope.CanStewardProjects = $scope.AngularModel.CanStewardProjects;
    $scope.IsPrimaryContact = $scope.AngularModel.IsPrimaryContact;
    $scope.IsOrganizationRelationshipTypeRequired = $scope.AngularModel.IsOrganizationRelationshipTypeRequired;

    $scope.radioButtonChanged = function () {
        if ($scope.CanStewardProjects === true || $scope.IsPrimaryContact === true) {
            $scope.IsOrganizationRelationshipTypeRequired = true;
        }
    }
});