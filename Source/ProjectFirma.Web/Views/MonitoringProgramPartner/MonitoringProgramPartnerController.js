/*-----------------------------------------------------------------------
<copyright file="MonitoringProgramPartnerController.js" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

