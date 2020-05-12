/*-----------------------------------------------------------------------
<copyright file="DocumentLibraryController.js" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
angular.module("ProjectFirmaApp").controller("DocumentLibraryController", function ($scope, angularModelAndViewData) {

    $scope.getAvailableCustomPages = function () {
        var usedCustomPageIDs = $scope.AngularModel.CustomPageIDs;
        var filter = _($scope.AngularViewData.AllCustomPages).filter(function (f) { return !_.contains(usedCustomPageIDs, f.CustomPageID); });
        var customPagesFilteredAndSorted = filter.sortBy(["CustomPageDisplayName"]).value();
        jQuery(".selectpicker").selectpicker("refresh");
        return customPagesFilteredAndSorted;
    };

    $scope.resetCustomPageIDToAdd = function() {
        $scope.CustomPageIDToAdd = null;
    };

    $scope.addRow = function () {
        if (!Sitka.Methods.isUndefinedNullOrEmpty($scope.CustomPageIDToAdd)) {
            $scope.AngularModel.CustomPageIDs.push(Number($scope.CustomPageIDToAdd));
        }
        $scope.resetCustomPageIDToAdd();
    };

    $scope.getCustomPagesForOtherDocumentLibraries = function () {
        var usedCustomPageIDs = $scope.AngularModel.CustomPageIDs;
        var filter = _($scope.AngularViewData.AllCustomPages).filter(function (cp) { return _.contains(usedCustomPageIDs, cp.CustomPageID) && cp.DocumentLibraryID != null && cp.DocumentLibraryID != $scope.AngularModel.DocumentLibraryID;});
        return filter.sortBy(["CustomPageDisplayName"]).value();
    };

    $scope.addAllCustomPages = function () {
        $scope.AngularModel.CustomPageIDs = [];
        jQuery.each($scope.AngularViewData.AllCustomPages, function (k, v) {
            $scope.AngularModel.CustomPageIDs.push(Number(v.CustomPageID));
        });
    };

    $scope.getCustomPageDisplayName = function (customPageID) {
        var customPage = _.find($scope.AngularViewData.AllCustomPages, function (x) { return x.CustomPageID == customPageID; });
        return customPage.CustomPageDisplayName;
    };

    $scope.deleteRow = function (customPageID) {
        Sitka.Methods.removeFromJsonArray($scope.AngularModel.CustomPageIDs, customPageID);
    };

    $scope.resetCustomPageIDToAdd();
    $scope.AngularModel = angularModelAndViewData.AngularModel;
    $scope.AngularViewData = angularModelAndViewData.AngularViewData;
});