//#sourceUrl=/Views/ProjectGeospatialArea/QuickSetProjectSpatialInformationController.js
angular.module("ProjectFirmaApp")
    .controller("QuickSetProjectSpatialInformationController",
        function ($scope, angularModelAndViewData) {
            $scope.AngularModel = angularModelAndViewData.AngularModel;
            $scope.AngularViewData = angularModelAndViewData.AngularViewData;

            $scope.getGeospatialAreaName = function (geospatialAreaId) {
                return $scope.AngularViewData.GeospatialAreaNameByID[geospatialAreaId];
            };


            //ProjectFirmaMaps.Map.prototype.handleWmsPopupClickEventWithCurrentLayer = function() {
            //    // Override parent to do nothing
            //    return function() {};
            //};

            function initializeMap() {
                $scope.firmaMap = new ProjectFirmaMaps.Map($scope.AngularViewData.MapInitJson);
                //$scope.firmaMap.map.on("click", onMapClick);
                $scope.firmaMap.map.scrollWheelZoom.enable();
            };

            initializeMap();

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

            $scope.selectedGeospatialAreaDoesNotMatchProjectLocation = function () {                
                if (!$scope.canSetGeospatialAreaFromProjectLocation()) {
                    return false;
                }
                if ($scope.AngularModel.GeospatialAreaIDs === null ||
                    $scope.AngularModel.GeospatialAreaIDs.length === 0) {
                    return true;
                }

                var selectedAreaMatches = false;

                _.forEach($scope.AngularViewData.GeospatialAreaIDsContainingProjectSimpleLocation, function (geospatialAreaID) {
                    if (!$scope.AngularModel.GeospatialAreaIDs.includes(geospatialAreaID)) {
                        selectedAreaMatches =  true;
                        
                    }
                });                
                return selectedAreaMatches;
            };

            $scope.updateSelectedGeospatialAreaLayer = function (geospatialAreaTypesSelected) {
               
                if ($scope.firmaMap.selectedGeospatialAreaLayers) {

                    _.forEach($scope.firmaMap.selectedGeospatialAreaLayers, function(thisSelectedGeospatialAreaLayer) {
                        $scope.firmaMap.layerControl.removeLayer(thisSelectedGeospatialAreaLayer);
                        $scope.firmaMap.map.removeLayer(thisSelectedGeospatialAreaLayer);
                    });

                }

                $scope.firmaMap.selectedGeospatialAreaLayers = [];

                _.forEach(geospatialAreaTypesSelected, function (thisSelectedGeospatialAreaType) {
                    var wmsParameters = L.Util.extend($scope.firmaMap.wmsParams, 
                        {
                            layers: thisSelectedGeospatialAreaType.GeospatialAreaTypeLayerName,
                            cql_filter: "GeospatialAreaID in (" + thisSelectedGeospatialAreaType.GeospatialAreaIDsContainingProjectSimpleLocation.join(",") + ")",
                            styles: "geospatialArea_yellow"
                        });

                    var tempLayer = L.tileLayer.wms(thisSelectedGeospatialAreaType.GeospatialAreaTypeMapServiceUrl, wmsParameters);

                    $scope.firmaMap.selectedGeospatialAreaLayers.push(tempLayer);
                    $scope.firmaMap.layerControl.addOverlay(tempLayer, "Selected " + thisSelectedGeospatialAreaType.GeospatialAreaTypeNamePluralized);
                    $scope.firmaMap.map.addLayer(tempLayer);

                    // Update map extent to selected geospatialAreas
                    if (_.any(thisSelectedGeospatialAreaType.GeospatialAreaIDsContainingProjectSimpleLocation)) {
                        var wfsParameters = L.Util.extend($scope.firmaMap.wfsParams,
                            {
                                typeName: thisSelectedGeospatialAreaType.GeospatialAreaTypeLayerName,
                                cql_filter: "GeospatialAreaID in (" + thisSelectedGeospatialAreaType.GeospatialAreaIDsContainingProjectSimpleLocation.join(",") + ")"
                            });
                        SitkaAjax.ajax({
                                url: thisSelectedGeospatialAreaType.GeospatialAreaTypeMapServiceUrl + L.Util.getParamString(wfsParameters),
                                dataType: "json",
                                jsonpCallback: "getJson"
                            },
                            function (response) {
                                if (response.features.length === 0)
                                    return;

                                $scope.firmaMap.map.fitBounds(new L.geoJSON(response).getBounds());
                            },
                            function () {
                                console.error("There was an error setting map extent to the selected " + thisSelectedGeospatialAreaType.GeospatialAreaTypeNamePluralized);
                            });
                    }

                    
                });


            };
        });
