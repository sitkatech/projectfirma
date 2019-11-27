/*-----------------------------------------------------------------------
<copyright file="AddGeospatialAreaToPerformanceMeasureController.js" company="Tahoe Regional Planning Agency">
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
angular.module("ProjectFirmaApp").controller("AddGeospatialAreaToPerformanceMeasureController", function ($scope, angularModelAndViewData) {



    $scope.addRow = function () {

        
        if ($scope.IsYearInUse) {
            //console.log('Year is already in use');
            return;
        }
        var newBulk = $scope.createNewBulkRow($scope.ReportingPeriodYearToAdd, $scope.ReportingPeriodLabelToAdd);
        $scope.AngularModel.PerformanceMeasureReportingPeriodSimples.push(newBulk);
        $scope.NextReportingPeriodYear = $scope.getNextReportingPeriodYear();
        $scope.resetReportingPeriodToAdd();
    };


    $scope.getGeospatialAreaTypes = function () {
        return $scope.AngularViewData.GeospatialAreaTypeSimples;
    };

    $scope.getSelectableGeospatialAreas = function (selectedGeospatialAreaTypeID) {
        //debugger;
        var geospatialAreaTypeID = parseInt(selectedGeospatialAreaTypeID, 10);
        var geospatialAreas = _.where($scope.AngularViewData.GeospatialAreaSimples, { 'GeospatialAreaTypeID': geospatialAreaTypeID });

        return geospatialAreas;
    };

    $scope.refreshSelectableGeospatialAreas = function (selectedGeospatialAreaTypeID) {
        debugger;
        //$scope.SelectableGeospatialAreas 
        jQuery(".selectpicker").selectpicker("refresh");
        return $scope.getSelectableGeospatialAreas(selectedGeospatialAreaTypeID);
    }


    $scope.deleteRow = function (rowToDelete) {
        Sitka.Methods.removeFromJsonArray($scope.AngularModel.PerformanceMeasureReportingPeriodSimples, rowToDelete);
    };





    $scope.AngularModel = angularModelAndViewData.AngularModel;
    $scope.AngularViewData = angularModelAndViewData.AngularViewData;
    //debugger;
    if ($scope.GeospatialAreaTypeID) {
        $scope.refreshSelectableGeospatialAreas();
    }
});
