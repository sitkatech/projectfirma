//#sourceUrl=/Views/ProjectGeospatialArea/QuickSetProjectSpatialInformationController.js
angular.module("ProjectFirmaApp")
    .controller("QuickSetProjectSpatialInformationController",
        function ($scope, angularModelAndViewData) {
            $scope.AngularModel = angularModelAndViewData.AngularModel;
            $scope.AngularViewData = angularModelAndViewData.AngularViewData;

            $scope.getGeospatialAreaName = function (geospatialAreaId) {
                return $scope.AngularViewData.GeospatialAreaNameByID[geospatialAreaId];
            };


            ProjectFirmaMaps.Map.prototype.handleWmsPopupClickEventWithCurrentLayer = function() {
                // Override parent to do nothing
                return function() {};
            };

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
                jQuery("input[name='geospatialAreaType']:checked").each(function (index, checkbox) {
                    var geospatialAreaType = _.find($scope.AngularViewData.GeospatialAreaTypes, function (o) { return o.GeospatialAreaTypeID == checkbox.value; });
                    _.forEach(geospatialAreaType.GeospatialAreaIDsContainingProjectSimpleLocation, function (geospatialAreaID) {
                        $scope.AngularModel.GeospatialAreaIDs.push(geospatialAreaID);
                    });   

                    $scope.updateSelectedGeospatialAreaLayer(geospatialAreaType);
                });

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

            $scope.updateSelectedGeospatialAreaLayer = function (geospatialAreaType) {
                if ($scope.AngularModel.GeospatialAreaIDs == null) {
                    $scope.AngularModel.GeospatialAreaIDs = [];
                }

                if ($scope.firmaMap.selectedGeospatialAreaLayer) {
                    $scope.firmaMap.layerControl.removeLayer($scope.firmaMap.selectedGeospatialAreaLayer);
                    $scope.firmaMap.map.removeLayer($scope.firmaMap.selectedGeospatialAreaLayer);
                }

                var wmsParameters = L.Util.extend(
                    {
                        layers: geospatialAreaType.GeospatialAreaTypeLayerName,
                        cql_filter: "GeospatialAreaID in (" + geospatialAreaType.GeospatialAreaIDsContainingProjectSimpleLocation.join(",") + ")",
                        styles: "geospatialArea_yellow"
                    },
                    $scope.firmaMap.wmsParams);

                $scope.firmaMap.selectedGeospatialAreaLayer = L.tileLayer.wms(geospatialAreaType.GeospatialAreaTypeMapServiceUrl, wmsParameters);
                $scope.firmaMap.layerControl.addOverlay($scope.firmaMap.selectedGeospatialAreaLayer, "Selected " + geospatialAreaType.GeospatialAreaTypeNamePluralized);
                $scope.firmaMap.map.addLayer($scope.firmaMap.selectedGeospatialAreaLayer);

                // Update map extent to selected geospatialAreas
                if (_.any(geospatialAreaType.GeospatialAreaIDsContainingProjectSimpleLocation)) {
                    var wfsParameters = L.Util.extend($scope.firmaMap.wfsParams,
                        {
                            typeName: geospatialAreaType.GeospatialAreaTypeLayerName,
                            cql_filter: "GeospatialAreaID in (" + geospatialAreaType.GeospatialAreaIDsContainingProjectSimpleLocation.join(",") + ")"
                        });
                    //debugger;
                    SitkaAjax.ajax({
                        url: geospatialAreaType.GeospatialAreaTypeMapServiceUrl + L.Util.getParamString(wfsParameters),
                        dataType: "json",
                        jsonpCallback: "getJson"
                    },
                        function (response) {
                            if (response.features.length === 0)
                                return;

                            $scope.firmaMap.map.fitBounds(new L.geoJSON(response).getBounds());
                        },
                        function () {
                            console.error("There was an error setting map extent to the selected " + geospatialAreaType.GeospatialAreaTypeNamePluralized);
                        });
                }
            };
        });
