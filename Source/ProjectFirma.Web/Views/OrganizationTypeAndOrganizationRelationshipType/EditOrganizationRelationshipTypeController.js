angular.module("ProjectFirmaApp").controller("EditOrganizationRelationshipTypeController", function ($scope, $timeout, angularModelAndViewData) {
    $scope.AngularModel = angularModelAndViewData.AngularModel;

    $scope.CanStewardProjects = $scope.AngularModel.CanStewardProjects;
    $scope.IsPrimaryContact = $scope.AngularModel.IsPrimaryContact;
    $scope.CanOnlyBeRelatedOnceToAProject = $scope.AngularModel.CanOnlyBeRelatedOnceToAProject;

    $scope.radioButtonChanged = function () {
        if ($scope.CanStewardProjects === true || $scope.IsPrimaryContact === true) {
            $scope.CanOnlyBeRelatedOnceToAProject = true;
        }
    }
});