//#sourceUrl=/Views/ProjectGeospatialArea/BulkSetProjectSpatialInformationController.js
angular.module("ProjectFirmaApp")
    .controller("BulkSetProjectSpatialInformationController",
        function ($scope, angularModelAndViewData) {
            $scope.AngularModel = angularModelAndViewData.AngularModel;
            $scope.AngularViewData = angularModelAndViewData.AngularViewData;

            $scope.getGeospatialAreaName = function (geospatialAreaId) {
                return $scope.AngularViewData.GeospatialAreaNameByID[geospatialAreaId];
            };

            $scope.noGeospatialAreasSelected = function () {
                return !$scope.AngularModel.GeospatialAreaIDs || $scope.AngularModel.GeospatialAreaIDs.length < 1;
            };

            $scope.canSetGeospatialAreaFromProjectLocation = function () {
                return $scope.AngularViewData.HasProjectLocationPoint &&
                    $scope.AngularViewData.GeospatialAreaIDsContainingProjectSimpleLocation.length > 0;
            };

            $scope.setSelectedGeospatialAreaTypeFromProjectLocation = function () {
                $scope.AngularModel.GeospatialAreaIDs = [];
                var geospatialAreaTypesSelected = [];
                jQuery("input[name='geospatialAreaType']:checked").each(function (index, checkbox) {
                    var geospatialAreaType = _.find($scope.AngularViewData.GeospatialAreaTypes, function (o) { return o.GeospatialAreaTypeID == checkbox.value; });
                    _.forEach(geospatialAreaType.GeospatialAreaIDsContainingProjectSimpleLocation, function (geospatialAreaID) {
                        $scope.AngularModel.GeospatialAreaIDs.push(geospatialAreaID);
                    });
                    geospatialAreaTypesSelected.push(geospatialAreaType);
                    
                });
                $scope.updateSelectedGeospatialAreaLayer(geospatialAreaTypesSelected);
            };

            $scope.selectAll = function (event) {
                var checkboxes = document.getElementsByName('geospatialAreaType');
                for (var i = 0; i < checkboxes.length; i++) {
                    checkboxes[i].checked = event.target.checked;
                }
            };

            $scope.updateSelectedGeospatialAreaLayer = function (geospatialAreaTypesSelected) {
               
                if ($scope.firmaMap.selectedGeospatialAreaLayers) {

                    _.forEach($scope.firmaMap.selectedGeospatialAreaLayers, function(thisSelectedGeospatialAreaLayer) {
                        $scope.firmaMap.layerControl.removeLayer(thisSelectedGeospatialAreaLayer);
                        $scope.firmaMap.map.removeLayer(thisSelectedGeospatialAreaLayer);
                    });

                }

                $scope.firmaMap.selectedGeospatialAreaLayers = [];

                var typeLayerNames = [];
                var mapServiceUrl;
                _.forEach(geospatialAreaTypesSelected, function (thisSelectedGeospatialAreaType) {
                    var wmsParameters = L.Util.extend($scope.firmaMap.wmsParams, 
                        {
                            layers: thisSelectedGeospatialAreaType.GeospatialAreaTypeLayerName,
                            cql_filter: "GeospatialAreaID in (" + $scope.AngularModel.GeospatialAreaIDs.join(",") + ")",
                            styles: "geospatialArea_yellow"
                        });

                    var tempLayer = L.tileLayer.wms(thisSelectedGeospatialAreaType.GeospatialAreaTypeMapServiceUrl, wmsParameters);

                    $scope.firmaMap.selectedGeospatialAreaLayers.push(tempLayer);
                    $scope.firmaMap.layerControl.addOverlay(tempLayer, "Selected " + thisSelectedGeospatialAreaType.GeospatialAreaTypeNamePluralized);
                    $scope.firmaMap.map.addLayer(tempLayer);
                    typeLayerNames.push(thisSelectedGeospatialAreaType.GeospatialAreaTypeLayerName);
                    mapServiceUrl = thisSelectedGeospatialAreaType.GeospatialAreaTypeMapServiceUrl;
                });

                // Update map extent to selected geospatialAreas
                if (_.any($scope.AngularModel.GeospatialAreaIDs)) {
                    var wfsParameters = L.Util.extend($scope.firmaMap.wfsParams,
                        {
                            typeName: typeLayerNames.join(","),
                            cql_filter: "GeospatialAreaID in (" + $scope.AngularModel.GeospatialAreaIDs.join(",") + ")"
                        });
                        SitkaAjax.ajax({
                            url: mapServiceUrl + L.Util.getParamString(wfsParameters),
                            dataType: "json",
                            jsonpCallback: "getJson"
                        },
                        function (response) {
                            if (response.features.length === 0)
                                return;

                            $scope.firmaMap.map.fitBounds(new L.geoJSON(response).getBounds());
                        },
                        function () {
                            console.error("There was an error setting map extent to these types: " + typeLayerNames.join(","));
                        });
                }


            };


            $scope.isGeospatialAreaTypeSet = function(geospatialAreaType) {
                var isSet = false;

                _.forEach($scope.AngularModel.GeospatialAreaIDs, function (geospatialAreaID) {
                    if (geospatialAreaType.GeospatialAreaIDsContainingProjectSimpleLocation.includes(geospatialAreaID) || geospatialAreaType.GeospatialAreaIDsInitiallySelected.includes(geospatialAreaID)) {
                        isSet = true;
                    }
                }); 

                return isSet;
            };

            $scope.getSelectedAreasFromGeospatialAreaType = function(geospatialAreaType) {
                var selectedGeospatialAreas = [];
                
                _.forEach($scope.AngularModel.GeospatialAreaIDs, function (geospatialAreaID) {
                    if (geospatialAreaType.GeospatialAreaIDsContainingProjectSimpleLocation.includes(geospatialAreaID) || geospatialAreaType.GeospatialAreaIDsInitiallySelected.includes(geospatialAreaID)) {
                        selectedGeospatialAreas.push(geospatialAreaID);
                    }
                });

                return selectedGeospatialAreas;
            };

            $scope.removeGeospatialArea = function (geospatialAreaId) {
                var index = $scope.AngularModel.GeospatialAreaIDs.indexOf(geospatialAreaId);
                $scope.AngularModel.GeospatialAreaIDs.splice(index, 1);

                $scope.updateSelectedGeospatialAreaLayer($scope.getSelectedGeospatialAreaTypes());
            };

            $scope.getSelectedGeospatialAreaTypes = function () {
                var selectedGeospatialTypes = [];
                _.forEach($scope.AngularModel.GeospatialAreaIDs, function (geospatialAreaID) {
                    _.forEach($scope.AngularViewData.GeospatialAreaTypes, function (geospatialAreaType) {
                        if (geospatialAreaType.GeospatialAreaIDsContainingProjectSimpleLocation.includes(geospatialAreaID) || geospatialAreaType.GeospatialAreaIDsInitiallySelected.includes(geospatialAreaID)) {
                            if (selectedGeospatialTypes.indexOf(geospatialAreaType) === -1) {
                                selectedGeospatialTypes.push(geospatialAreaType);
                            }
                        }
                    });
                });
                return selectedGeospatialTypes;
            };


            function initializeMap() {
                $scope.firmaMap = new ProjectFirmaMaps.Map($scope.AngularViewData.MapInitJson);
                $scope.firmaMap.map.scrollWheelZoom.enable();
                if ($scope.AngularModel.GeospatialAreaIDs) {
                    $scope.updateSelectedGeospatialAreaLayer($scope.getSelectedGeospatialAreaTypes());
                }
            };

            initializeMap();

        });
