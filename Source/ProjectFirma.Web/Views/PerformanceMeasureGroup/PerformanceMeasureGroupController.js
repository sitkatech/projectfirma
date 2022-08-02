/*-----------------------------------------------------------------------
<copyright file="AttachmentTypeController.js" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
angular.module("ProjectFirmaApp").controller("PerformanceMeasureGroupController", function ($scope, angularModelAndViewData) {


    // Performance Measures
    $scope.getAvailablePerformanceMeasures = function () {
        var usedPerformanceMeasureIDs = $scope.AngularModel.PerformanceMeasureIDs;
        //debugger;
        var filter = _($scope.AngularViewData.AllPerformanceMeasures).filter(function (f) { return !_.contains(usedPerformanceMeasureIDs, f.PerformanceMeasureID); });
        var performanceMeasuresFilteredAndSorted = filter.sortBy(["DisplayName"]).value();
        //debugger;
        jQuery(".selectpicker").selectpicker("refresh");
        return performanceMeasuresFilteredAndSorted;
    };

    $scope.resetPerformanceMeasureIDToAdd = function () {
        $scope.PerformanceMeasureIDToAdd = null;
    };

    $scope.addRowPerformanceMeasure = function () {
        if ($scope.PerformanceMeasureIDToAdd != null) {
            //debugger;
            $scope.AngularModel.PerformanceMeasureIDs.push(Number($scope.PerformanceMeasureIDToAdd));
        }
        $scope.resetPerformanceMeasureIDToAdd();
    };

    $scope.addAllPerformanceMeasures = function () {
        $scope.AngularModel.PerformanceMeasureIDs = [];
        jQuery.each($scope.AngularViewData.AllPerformanceMeasures, function (k, v) {
            $scope.AngularModel.PerformanceMeasureIDs.push(Number(v.PerformanceMeasureID));
        });
    };

    $scope.getPerformanceMeasureDisplayName = function (performanceMeasureID) {
        var performanceMeasure = _.find($scope.AngularViewData.AllPerformanceMeasures, function (x) { return x.PerformanceMeasureID == performanceMeasureID; });
        //debugger;
        return performanceMeasure.DisplayName;
    };

    $scope.deleteRowPerformanceMeasure = function (performanceMeasureID) {
        Sitka.Methods.removeFromJsonArray($scope.AngularModel.PerformanceMeasureIDs, performanceMeasureID);
    };

    $scope.resetPerformanceMeasureIDToAdd();
    $scope.AngularModel = angularModelAndViewData.AngularModel;
    $scope.AngularViewData = angularModelAndViewData.AngularViewData;
});