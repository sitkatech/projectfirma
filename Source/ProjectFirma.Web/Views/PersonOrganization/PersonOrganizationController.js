/*-----------------------------------------------------------------------
<copyright file="PersonOrganizationController.js" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
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
angular.module("ProjectFirmaApp").controller("PersonOrganizationController", function ($scope, angularModelAndViewData)
{
    $scope.filteredOrganizations = function ()
    {
        var usedOrganizationIDs = $scope.AngularModel.OrganizationIDs;
        var filter = _($scope.AngularViewData.AllOrganizations).filter(function (f) { return !_.contains(usedOrganizationIDs, f.OrganizationID); });
        var orgsFilteredAndSorted = filter.sortBy(["DisplayName"]).value();
        return orgsFilteredAndSorted;
    };

    $scope.addRow = function()
    {
        if ($scope.OrganizationToAdd != null)
        {
            $scope.AngularModel.OrganizationIDs.push($scope.OrganizationToAdd.OrganizationID);
        }
    };

    $scope.getOrganizationDisplayName = function (organizationId)
    {
        var organization = _.find($scope.AngularViewData.AllOrganizations, function(x) { return x.OrganizationID == organizationId; });
        return organization.DisplayName;
    };

    $scope.deleteRow = function (organizationId) {
        Sitka.Methods.removeFromJsonArray($scope.AngularModel.OrganizationIDs, organizationId);
    };

    $scope.AngularModel = angularModelAndViewData.AngularModel;
    $scope.AngularViewData = angularModelAndViewData.AngularViewData;
});

