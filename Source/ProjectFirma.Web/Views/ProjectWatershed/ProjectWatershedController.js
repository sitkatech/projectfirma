/*-----------------------------------------------------------------------
<copyright file="ProjectWatershedController.js" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
angular.module("ProjectFirmaApp").controller("ProjectWatershedController", function ($scope, angularModelAndViewData)
{
    $scope.resetWatershedToAdd = function () { $scope.WatershedToAdd = null; };

    $scope.filteredWatersheds = function () {
        var usedWatershedIDs = _.map($scope.AngularModel.ProjectWatersheds, function (p) { return p.WatershedID; });
        return _($scope.AngularViewData.AllWatersheds).filter(function (f) { return !_.contains(usedWatershedIDs, f.WatershedID); }).sortBy(["DisplayName"]).value();
    };

    $scope.getWatershedName = function (projectWatershed) {
        var watershedToFind = $scope.getWatershed(projectWatershed.WatershedID);
        return watershedToFind.DisplayName;
    };

    $scope.getWatershed = function (watershedId) {
        return _.find($scope.AngularViewData.AllWatersheds, function (f) { return watershedId == f.WatershedID; });
    };

    $scope.addRow = function()
    {
        if ($scope.WatershedToAdd != null)
        {
            var newProjectWatershed = $scope.createNewRow($scope.ProjectIDToAdd, $scope.WatershedToAdd);
            $scope.AngularModel.ProjectWatersheds.push(newProjectWatershed);
            $scope.resetWatershedToAdd();
        }
    };

    $scope.createNewRow = function (projectId, watershed) {
        var newProjectWatershed = {
            ProjectID: projectId,
            WatershedID: watershed.WatershedID
        };
        return newProjectWatershed;
    };

    $scope.deleteRow = function (rowToDelete) {
        Sitka.Methods.removeFromJsonArray($scope.AngularModel.ProjectWatersheds, rowToDelete);
    };

    $scope.AngularModel = angularModelAndViewData.AngularModel;
    $scope.AngularViewData = angularModelAndViewData.AngularViewData;
    $scope.resetWatershedToAdd();
    $scope.ProjectIDToAdd = $scope.AngularViewData.ProjectID;
});

