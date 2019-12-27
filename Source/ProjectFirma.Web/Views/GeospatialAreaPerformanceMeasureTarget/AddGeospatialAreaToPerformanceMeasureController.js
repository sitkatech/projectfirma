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

    $scope.GeospatialAreaDropdownOptions = [];

    $scope.addGeospatialArea = function (geospatialArea, selectedGeospatialAreaTypeID) {
        //console.log('inside addGeospatialArea');
        //console.log('geospatialAreaID:' + geospatialAreaID);
        //console.log('selectedGeospatialAreaTypeID:' + selectedGeospatialAreaTypeID);
        var geospatialAreaTypeIdInt = parseInt(selectedGeospatialAreaTypeID, 10);
        var geospatialAreaType = _.find($scope.AngularViewData.GeospatialAreaTypeSimples, { GeospatialAreaTypeID: geospatialAreaTypeIdInt });

        var geospatialAreaID = geospatialArea.GeospatialAreaID;

        if (!geospatialAreaID)
        {
            var firstItem = _.first($scope.GeospatialAreaDropdownOptions);
            geospatialAreaID = firstItem.GeospatialAreaID;
            //console.log('geospatialAreaID:' + geospatialAreaID);
        }
        var geospatialAreaIdInt = parseInt(geospatialAreaID, 10);
        //console.log('geospatialAreaIdInt:' + geospatialAreaIdInt);
        var alreadyAdded = _.find($scope.AngularModel.SelectedGeospatialAreas, { GeospatialAreaID: geospatialAreaIdInt });

        if (_.isObject(alreadyAdded)) {
            //console.log('alreadyAdded:' + JSON.stringify(alreadyAdded));
            return;
        }

        var geospatialArea = _.find($scope.AngularViewData.GeospatialAreaSimples, { GeospatialAreaID: geospatialAreaIdInt });
        var combinedName = geospatialAreaType.GeospatialAreaTypeName + " - " + geospatialArea.GeospatialAreaName;
        var newArea = { GeospatialAreaID: geospatialAreaIdInt, GeospatialAreaName: combinedName };
        $scope.AngularModel.SelectedGeospatialAreas.push(newArea);
        var indexOfCurrentItem = $scope.selectableGeospatialAreas.indexOf($scope.SelectedGeospatialArea);
        if (typeof $scope.selectableGeospatialAreas[indexOfCurrentItem + 1] !== 'undefined') {
            $scope.SelectedGeospatialArea = $scope.selectableGeospatialAreas[indexOfCurrentItem + 1];
        }
        
        $scope.refreshSelectableGeospatialAreas();
    };


    $scope.getGeospatialAreaTypes = function () {
        return $scope.AngularViewData.GeospatialAreaTypeSimples;
    };

    $scope.isAddButtonDisabled = function () {
        var returnValue = true;
        if ($scope.GeospatialAreaDropdownOptions.length > 0) {
            
            returnValue = false;
        }
        return returnValue;
    };

    $scope.getSelectableGeospatialAreas = function (selectedGeospatialAreaTypeID) {
        //debugger;
        var geospatialAreaTypeID = parseInt(selectedGeospatialAreaTypeID, 10);
        var geospatialAreas = _.where($scope.AngularViewData.GeospatialAreaSimples, { 'GeospatialAreaTypeID': geospatialAreaTypeID });
        var filteredGeospatialAreas = _.filter(geospatialAreas,
                                                function(geospatialArea) {
                                                    var object = _.find($scope.AngularModel.SelectedGeospatialAreas,
                                                        function (selectedGeospatialArea) {
                                                            return geospatialArea.GeospatialAreaID == selectedGeospatialArea.GeospatialAreaID;
                                                        });
                                                    return !_.isObject(object);
                                                });
        
        $scope.GeospatialAreaDropdownOptions = filteredGeospatialAreas.sort(function (a, b) {
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
        return $scope.GeospatialAreaDropdownOptions;


    };

    $scope.selectableGeospatialAreas = [];

    $scope.refreshSelectableGeospatialAreas = function () {
        
        $scope.selectableGeospatialAreas = $scope.getSelectableGeospatialAreas($scope.SelectedGeospatialAreaTypeID);
        setTimeout(function () {
            jQuery(".selectpicker").selectpicker("refresh");
        }, 50);
    }


    $scope.deleteGeospatialArea = function (rowToDelete) {
        Sitka.Methods.removeFromJsonArray($scope.AngularModel.SelectedGeospatialAreas, rowToDelete);
    };

    
    $scope.AngularModel = angularModelAndViewData.AngularModel;
    $scope.AngularViewData = angularModelAndViewData.AngularViewData;

    $scope.SelectedGeospatialAreaID = "";
    $scope.SelectedGeospatialArea = {};
    $scope.AngularModel.SelectedGeospatialAreas = [];
   

});
