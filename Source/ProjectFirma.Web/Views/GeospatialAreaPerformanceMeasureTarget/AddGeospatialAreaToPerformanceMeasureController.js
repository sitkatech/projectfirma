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



    $scope.addGeospatialArea = function (geospatialAreaID, selectedGeospatialAreaTypeID) {
        //debugger;
        
        var geospatialAreaTypeIdInt = parseInt(selectedGeospatialAreaTypeID, 10);
        var geospatialAreaType = _.find($scope.AngularViewData.GeospatialAreaTypeSimples, { GeospatialAreaTypeID: geospatialAreaTypeIdInt });

        var geospatialAreaIdInt = parseInt(geospatialAreaID, 10);
        var alreadyAdded = _.find($scope.AngularModel.SelectedGeospatialAreas, { GeospatialAreaID: geospatialAreaIdInt });
        debugger;
        if (_.isObject(alreadyAdded)) {
            return;
        }


        var geospatialArea = _.find($scope.AngularViewData.GeospatialAreaSimples, { GeospatialAreaID: geospatialAreaIdInt });
        var combinedName = geospatialAreaType.GeospatialAreaTypeName + " - " + geospatialArea.GeospatialAreaName;

        var newArea = { GeospatialAreaID: geospatialAreaIdInt, GeospatialAreaName: combinedName };
        $scope.AngularModel.SelectedGeospatialAreas.push(newArea);
        //todo: for some reason the area dropdown will update with the removal of the newly selected item, but angular isn't updating so the default selected item doesn't get added. it keeps adding the previously selected area. 
        //jQuery(".selectpicker").selectpicker("refresh");
        //$scope.refreshSelectableGeospatialAreas(selectedGeospatialAreaTypeID);
    };


    $scope.getGeospatialAreaTypes = function () {
        return $scope.AngularViewData.GeospatialAreaTypeSimples;
    };

    $scope.getSelectableGeospatialAreas = function (selectedGeospatialAreaTypeID) {
        //debugger;
        var geospatialAreaTypeID = parseInt(selectedGeospatialAreaTypeID, 10);
        var geospatialAreas = _.where($scope.AngularViewData.GeospatialAreaSimples, { 'GeospatialAreaTypeID': geospatialAreaTypeID });
        var filteredGeospatialAreas = _.filter(geospatialAreas,
                                                function(geospatialArea) {
                                                    var object = _.find($scope.AngularModel.SelectedGeospatialAreas,
                                                        function (selectedGeospatialArea) {
                                                            //console.log('geospatialSelected one' + JSON.stringify(selectedGeospatialArea));
                                                            //console.log('geospatialArea.GeospatialAreaID:' + geospatialArea.GeospatialAreaID + ':VS:selectedGeospatialArea.GeospatialAreaID:');
                                                            return geospatialArea.GeospatialAreaID == selectedGeospatialArea.GeospatialAreaID;
                                                        });
                                                    return !_.isObject(object);
                                                });

        //var mappedGeospatialAreas = _.map(_.sortBy(filteredGeospatialAreas, 'GeospatialAreaName'), _.values);
        //debugger;
        return filteredGeospatialAreas.sort(function (a, b) {
                                                                var nameA = a.GeospatialAreaName.toUpperCase(); // ignore upper and lowercase
                                                                var nameB = b.GeospatialAreaName.toUpperCase(); // ignore upper and lowercase
                                                                if (nameA < nameB) {
                                                                    return -1;
                                                                }
                                                                if (nameA > nameB) {
                                                                    return 1;
                                                                }

                                                                // names must be equal
                                                                return 0;
                                                            });

        
    };

    $scope.refreshSelectableGeospatialAreas = function (selectedGeospatialAreaTypeID) {
        //debugger;
        //$scope.SelectableGeospatialAreas 
        jQuery(".selectpicker").selectpicker("refresh");
        return $scope.getSelectableGeospatialAreas(selectedGeospatialAreaTypeID);
    }


    $scope.deleteGeospatialArea = function (rowToDelete) {
        Sitka.Methods.removeFromJsonArray($scope.AngularModel.SelectedGeospatialAreas, rowToDelete);
    };





    $scope.AngularModel = angularModelAndViewData.AngularModel;
    $scope.AngularViewData = angularModelAndViewData.AngularViewData;

    $scope.SelectedGeospatialAreaID = "";
    $scope.AngularModel.SelectedGeospatialAreas = [];

    //$scope.SelectedGeospatialAreaTypeID = $scope.AngularModel.GeospatialAreaTypeID;
    //if ($scope.SelectedGeospatialAreaTypeID) {
    //    $scope.refreshSelectableGeospatialAreas($scope.SelectedGeospatialAreaTypeID);
    //}

});
