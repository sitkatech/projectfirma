angular.module("ProjectFirmaApp").controller("MonitoringProgramPartnerController", function ($scope, angularModelAndViewData)
{
    $scope.resetOrganizationToAdd = function () { $scope.OrganizationToAdd = null; };

    $scope.filteredOrganizations = function () {
        var usedOrganizationIDs = _.map($scope.AngularModel.MonitoringProgramPartners, function (p) { return p.OrganizationID; });
        return _($scope.AngularViewData.AllOrganizations).filter(function (f) { return !_.contains(usedOrganizationIDs, f.OrganizationID); }).sortBy(["DisplayName"]).value();
    };

    $scope.getOrganizationName = function (monitoringProgramPartner) {
        var organizationToFind = $scope.getOrganization(monitoringProgramPartner.OrganizationID);
        return organizationToFind.DisplayName;
    };

    $scope.getOrganization = function (organizationId) {
        return _.find($scope.AngularViewData.AllOrganizations, function (f) { return organizationId == f.OrganizationID; });
    };

    $scope.addRow = function()
    {
        if ($scope.OrganizationToAdd != null)
        {
            var newMonitoringProgramPartner = $scope.createNewRow($scope.MonitoringProgramIDToAdd, $scope.OrganizationToAdd);
            $scope.AngularModel.MonitoringProgramPartners.push(newMonitoringProgramPartner);
            $scope.resetOrganizationToAdd();
        }
    };

    $scope.createNewRow = function (monitoringProgramId, organization) {
        var newMonitoringProgramPartner = {
            MonitoringProgramID: monitoringProgramId,
            OrganizationID: organization.OrganizationID
        };
        return newMonitoringProgramPartner;
    };

    $scope.deleteRow = function (rowToDelete) {
        Sitka.Methods.removeFromJsonArray($scope.AngularModel.MonitoringProgramPartners, rowToDelete);
    };

    $scope.AngularModel = angularModelAndViewData.AngularModel;
    $scope.AngularViewData = angularModelAndViewData.AngularViewData;
    $scope.resetOrganizationToAdd();
    $scope.MonitoringProgramIDToAdd = $scope.AngularViewData.MonitoringProgramID;
});

