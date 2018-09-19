angular.module("ProjectFirmaApp")
    .controller("ProjectLocationSimpleController",
        function ($scope, angularModelAndViewData) {
            $scope.AngularModel = angularModelAndViewData.AngularModel;
            $scope.AngularViewData = angularModelAndViewData.AngularViewData;

            $scope.selectedStyle = {
                fillColor: "#FFFF00",
                fill: true,
                fillOpacity: 0.2,
                color: "#FFFF00",
                weight: 5,
                stroke: true
            };

            $scope.unselectedStyle = {
                fillColor: "#405d74",
                fill: true,
                fillOpacity: 0.2,
                color: "#405d74",
                weight: 1,
                stroke: true
            };

            $scope.toggleMap = function() {
                switch ($scope.AngularModel.ProjectLocationSimpleType) {
                case "PointOnMap":
                    document.getElementById($scope.AngularViewData.MapInitJson.MapDivID).style.cursor = "crosshair";
                    $scope.projectLocationMap.unblockMap();
                    $scope.projectLocationMap.map.scrollWheelZoom.enable();

                    if ($scope.projectLocationMap.currentSelectedPoint) {
                        $scope.projectLocationMap.map.addLayer($scope.projectLocationMap.currentSelectedPoint);
                    }

                    if ($scope.projectLocationMap.currentSelectedGeometry) {
                        $scope.projectLocationMap.map.removeLayer($scope.projectLocationMap.currentSelectedGeometry);
                    }
                    break;
                case "None":
                    document.getElementById($scope.AngularViewData.MapInitJson.MapDivID).style.cursor = "default";
                    $scope.projectLocationMap.map.scrollWheelZoom.disable();

                    if ($scope.projectLocationMap.currentSelectedPoint) {
                        $scope.projectLocationMap.map.removeLayer($scope.projectLocationMap.currentSelectedPoint);
                    }

                    if ($scope.projectLocationMap.currentSelectedGeometry) {
                        $scope.projectLocationMap.map.removeLayer($scope.projectLocationMap.currentSelectedGeometry);
                    }
                    $scope.projectLocationMap.blockMap();
                    break;
                }
            };

            function onMapClick(event) {
                switch ($scope.AngularModel.ProjectLocationSimpleType) {
                case "PointOnMap":
                    onMapClickSetPointOnMap(event,
                        function() {
                            $scope.$apply();
                        });
                    break;
                case "None": // Do nothing
                    break;
                }
            }

            function onMapClickSetPointOnMap(event, callback) {
                var latlng = event.latlng;
                var latlngWrapped = latlng.wrap();

                var propertiesForDisplay = {
                    Latitude: L.Util.formatNum(latlngWrapped.lat, 4),
                    Longitude: L.Util.formatNum(latlngWrapped.lng, 4)
                };

                var watershedMapServiceLayerName = $scope.AngularViewData.WatershedMapSericeLayerName,
                    mapServiceUrl = $scope.AngularViewData.MapServiceUrl;

                if (Sitka.Methods.isUndefinedNullOrEmpty(watershedMapServiceLayerName) || Sitka.Methods.isUndefinedNullOrEmpty(mapServiceUrl)) {
                    setPointOnMap(latlng);
                    $scope.propertiesForPointOnMap = propertiesForDisplay;
                    if (callback) {
                        callback.call();
                    }
                }
                else {
                    var parameters = L.Util.extend($scope.projectLocationMap.wfsParams,
                        {
                            typeName: watershedMapServiceLayerName,
                            cql_filter: "intersects(Ogr_Geometry, POINT(" +
                                latlngWrapped.lat +
                                " " +
                                latlngWrapped.lng +
                                "))"
                        });
                    SitkaAjax.ajax({
                            url: mapServiceUrl + L.Util.getParamString(parameters),
                            dataType: "json",
                            jsonpCallback: "getJson"
                        },
                        function(response) {
                            setPointOnMap(latlng);
                            if (response.features.length > 0) {
                                var mergedProperties = _.merge.apply(_, _.map(response.features, "properties"));
                                propertiesForDisplay[$scope.AngularViewData.WatershedFieldDefinitionLabel] =
                                    mergedProperties.WatershedName;
                            }

                            $scope.propertiesForPointOnMap = propertiesForDisplay;

                            if (callback) {
                                callback.call();
                            }
                        },
                        function() {
                            console.error(
                                "There was an error selecting the " +
                                $scope.AngularViewData.ProjectLocationFieldDefinitionLabel +
                                " area from list.");
                        });
                }
            }

            function setPointOnMap(latlng) {
                $scope.AngularModel.ProjectLocationPointX = L.Util.formatNum(latlng.lng);
                $scope.AngularModel.ProjectLocationPointY = L.Util.formatNum(latlng.lat);

                if ($scope.projectLocationMap.currentSelectedPoint) {
                    $scope.projectLocationMap.map.removeLayer(
                        $scope.projectLocationMap.currentSelectedPoint);
                }

                $scope.projectLocationMap.currentSelectedPoint = L.marker(latlng,
                    {
                        icon: L.MakiMarkers.icon({
                            icon: "marker",
                            color: $scope.selectedStyle.color,
                            size: "m"
                        })
                    });

                $scope.projectLocationMap.map.addLayer($scope.projectLocationMap.currentSelectedPoint);
                $scope.projectLocationMap.map.panTo(latlng);
            }

            $scope.getProjectLocationProperties = function() {
                switch ($scope.AngularModel.ProjectLocationSimpleType) {
                case "PointOnMap":
                    return $scope.propertiesForPointOnMap;
                case "None": // Do nothing
                    break;
                }
                return null;
            };

            ProjectFirmaMaps.Map.prototype.handleWmsPopupClickEventWithCurrentLayer  = function() {
                // Override parent to do nothing
                return function () { };
            };

            var initializeMap = function () {
                $scope.projectLocationMap = new ProjectFirmaMaps.Map($scope.AngularViewData.MapInitJson);
                $scope.projectLocationMap.map.on("click", onMapClick);

                if ($scope.AngularViewData.CurrentFeature) {
                    // ReSharper disable once InconsistentNaming
                    $scope.projectLocationMap.currentSelectedGeometry = new L.geoJSON(
                        $scope.AngularViewData.CurrentFeature,
                        {
                            style: function() {
                                return $scope.selectedStyle;
                            }
                        });

                    $scope.propertiesForNamedArea = {};
                    $scope.propertiesForNamedArea[$scope.AngularViewData.WatershedFieldDefinitionLabel] = $scope.AngularViewData.InitialWatershedName;
                }

                if ($scope.AngularModel.ProjectLocationPointX && $scope.AngularModel.ProjectLocationPointY) {
                    var latlng = new L.LatLng($scope.AngularModel.ProjectLocationPointY, $scope.AngularModel.ProjectLocationPointX);
                    var latlngWrapped = latlng.wrap();
                    $scope.projectLocationMap.currentSelectedPoint = L.marker(latlng, { icon: L.MakiMarkers.icon({ icon: "marker", color: $scope.selectedStyle.color, size: "m" }) });

                    $scope.propertiesForPointOnMap = {
                        Latitude: L.Util.formatNum(latlngWrapped.lat, 4),
                        Longitude: L.Util.formatNum(latlngWrapped.lng, 4)
                    };

                    // Get the initial Location Information from the WMS service
                    if ($scope.AngularViewData.MapServiceUrl && $scope.AngularViewData.WatershedMapSericeLayerName) {
                        SitkaAjax.ajax({
                                url: $scope.AngularViewData.MapServiceUrl +
                                    L.Util.getParamString(L.Util.extend($scope.projectLocationMap.wfsParams,
                                        {
                                            typeName: $scope.AngularViewData.WatershedMapSericeLayerName,
                                            cql_filter: "intersects(Ogr_Geometry, POINT(" + latlngWrapped.lat + " " + latlngWrapped.lng + "))"
                                        })),
                                dataType: "json",
                                jsonpCallback: "getJson"
                            },
                            function(response) {
                                if (response.features.length === 0)
                                    return;

                                var mergedProperties = _.merge.apply(_, _.map(response.features, "properties"));
                                $scope.propertiesForPointOnMap[$scope.AngularViewData.WatershedFieldDefinitionLabel] = mergedProperties.WatershedName;
                                $scope.$apply();
                            },
                            function() {
                                console.error("There was an error getting the initial " + $scope.AngularViewData.WatershedFieldDefinitionLabel + " name to display.");
                            });
                    }
                }
            };

            initializeMap();
            $scope.toggleMap();
        });
