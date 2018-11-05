/*-----------------------------------------------------------------------
<copyright file="EditStormwaterUserController.js" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
angular.module("ProjectFirmaApp").controller("EditUserStewardshipAreasController", function ($scope, angularModelAndViewData) {
    $scope.AngularModel = angularModelAndViewData.AngularModel;
    $scope.AngularViewData = angularModelAndViewData.AngularViewData;

    $scope.RoleID = $scope.AngularModel.RoleID;

    $scope.$watch(function () {
        jQuery(".selectpicker").selectpicker("refresh");
    });

    $scope.filteredStewardshipAreas = function ()
    {
        var usedStewardshipAreaIDs = ($scope.AngularModel.PersonStewardshipAreaSimples).map(function (s) { return s.StewardshipAreaID });
        var filter = _($scope.AngularViewData.AllStewardshipAreas).filter(function (f) { return !_.includes(usedStewardshipAreaIDs, f.StewardshipAreaID); });
        var orgsFilteredAndSorted = filter.sortBy(["StewardshipAreaName"]).value();
        return orgsFilteredAndSorted;
    };

    $scope.addRow = function() {
        if ($scope.StewardshipAreaIDToAdd == null) {
            return;
        }
        var newStewardshipAreaPersonSimple = {
            StewardshipAreaID: $scope.StewardshipAreaIDToAdd,
        }
        $scope.AngularModel.PersonStewardshipAreaSimples.push(newStewardshipAreaPersonSimple);
        $scope.StewardshipAreaIDToAdd = null;
    };

    $scope.getStewardshipAreaDisplayName = function (stewardshipAreaOnViewModel)
    {
        var stewardshipAreaID = stewardshipAreaOnViewModel.StewardshipAreaID;
        var stewardshipArea = _.find($scope.AngularViewData.AllStewardshipAreas, function (x) { return x.StewardshipAreaID == stewardshipAreaID; });
        return stewardshipArea.StewardshipAreaName;
    };

    $scope.deleteRow = function (stewardshipAreaSimple) {
        Sitka.Methods.removeFromJsonArray($scope.AngularModel.PersonStewardshipAreaSimples, stewardshipAreaSimple);
    };

    $scope.StewardshipAreaIDToAdd = null;
});

