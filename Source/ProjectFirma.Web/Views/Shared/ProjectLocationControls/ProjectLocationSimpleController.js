angular.module("ProjectFirmaApp")
    .controller("ProjectLocationSimpleController",
        function ($scope, angularModelAndViewData) {
            $scope.AngularModel = angularModelAndViewData.AngularModel;
            $scope.AngularViewData = angularModelAndViewData.AngularViewData;
            $scope.hasGeospatialAreaTypeLayers = $scope.AngularViewData.GeospatialAreaMapSericeLayerNames.length > 0;
            $scope.GeospatialAreaMapSericeLayerNamesCommaSeparated =
                $scope.AngularViewData.GeospatialAreaMapSericeLayerNames.join(",");


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

            $scope.toggleMap = function () {
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
                case "LatLngInput":
                    document.getElementById($scope.AngularViewData.MapInitJson.MapDivID).style.cursor = "default";
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

            $scope.changedLatLngInput = function () {
                if (isNaN($scope.AngularModel.ProjectLocationPointY) || isNaN($scope.AngularModel.ProjectLocationPointX)) {
                    return;
                }

                // if either the lat or lng are falsy we should remove the selected point from the map
                if (!$scope.AngularModel.ProjectLocationPointY || !$scope.AngularModel.ProjectLocationPointX) {
                    $scope.projectLocationMap.map.removeLayer($scope.projectLocationMap.currentSelectedPoint);
                    return;
                }

                var latlng = new L.LatLng($scope.AngularModel.ProjectLocationPointY, $scope.AngularModel.ProjectLocationPointX);

                // if we haven't returned (the lat lng numbers look good enough for the setPointOnMap function) we can set the point on the map
                setPointOnMap(latlng);
            }

            function onMapClick(event) {
                switch ($scope.AngularModel.ProjectLocationSimpleType) {
                case "PointOnMap":
                    onMapClickSetPointOnMap(event,
                        function() {
                            $scope.$apply();
                        });
                    break;
                case "LatLngInput":
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

                if (!$scope.hasGeospatialAreaTypeLayers) {
                    setPointOnMap(latlng);
                    $scope.propertiesForPointOnMap = propertiesForDisplay;
                    if (callback) {
                        callback.call();
                    }
                }
                else {
                    var parameters = L.Util.extend($scope.projectLocationMap.wfsParams,
                        {
                            typeName: $scope.GeospatialAreaMapSericeLayerNamesCommaSeparated,
                            cql_filter: "intersects(Ogr_Geometry, POINT(" +
                                latlngWrapped.lat +
                                " " +
                                latlngWrapped.lng +
                                "))"
                        });
                    SitkaAjax.ajax({
                        url: $scope.AngularViewData.MapServiceUrl + L.Util.getParamString(parameters),
                            dataType: "json",
                            jsonpCallback: "getJson"
                        },
                        function(response) {
                            setPointOnMap(latlng);
                            if (response.features.length > 0) {
                                var mergedProperties = _.merge.apply(_, _.map(response.features, "properties"));
                                propertiesForDisplay[$scope.AngularViewData.GeospatialAreaFieldDefinitionLabel] =
                                    mergedProperties.GeospatialAreaName;
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

                var latlngWrapped = latlng.wrap();
                $scope.propertiesForPointOnMap = {
                    Latitude: L.Util.formatNum(latlngWrapped.lat, 4),
                    Longitude: L.Util.formatNum(latlngWrapped.lng, 4)
                };
            }

            $scope.getProjectLocationProperties = function() {
                switch ($scope.AngularModel.ProjectLocationSimpleType) {
                case "PointOnMap":
                    return $scope.propertiesForPointOnMap;
                case "LatLngInput":
                case "None": // Do nothing
                    break;
                }
                return null;
            };

            $scope.displayLatLngInputs = function() {
                return ($scope.AngularModel.ProjectLocationSimpleType === "LatLngInput");
            }

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
                    $scope.propertiesForNamedArea[$scope.AngularViewData.GeospatialAreaFieldDefinitionLabel] = $scope.AngularViewData.InitialGeospatialAreaName;
                }

                if ($scope.AngularModel.ProjectLocationPointX && $scope.AngularModel.ProjectLocationPointY) {
                    var latlng = new L.LatLng($scope.AngularModel.ProjectLocationPointY, $scope.AngularModel.ProjectLocationPointX);
                    var latlngWrapped = latlng.wrap();
                    $scope.projectLocationMap.currentSelectedPoint = L.marker(latlng, { icon: L.MakiMarkers.icon({ icon: "marker", color: $scope.selectedStyle.color, size: "m" }) });
                    // set the point on the map if it is initialized with data
                    setPointOnMap(latlng);

                    $scope.propertiesForPointOnMap = {
                        Latitude: L.Util.formatNum(latlngWrapped.lat, 4),
                        Longitude: L.Util.formatNum(latlngWrapped.lng, 4)
                    };

                    // Get the initial Location Information from the WMS service
                    if ($scope.hasGeospatialAreaTypeLayers) {
                        SitkaAjax.ajax({
                                url: $scope.AngularViewData.MapServiceUrl +
                                    L.Util.getParamString(L.Util.extend($scope.projectLocationMap.wfsParams,
                                        {
                                            typeName: $scope.GeospatialAreaMapSericeLayerNamesCommaSeparated,
                                            cql_filter: "intersects(Ogr_Geometry, POINT(" + latlngWrapped.lat + " " + latlngWrapped.lng + "))"
                                        })),
                                dataType: "json",
                                jsonpCallback: "getJson"
                            },
                            function(response) {
                                if (response.features.length === 0)
                                    return;

                                var mergedProperties = _.merge.apply(_, _.map(response.features, "properties"));
                                $scope.propertiesForPointOnMap[$scope.AngularViewData.GeospatialAreaFieldDefinitionLabel] = mergedProperties.GeospatialAreaName;
                                $scope.$apply();
                            },
                            function() {
                                console.error("There was an error getting the initial " + $scope.AngularViewData.GeospatialAreaFieldDefinitionLabel + " name to display.");
                            });
                    }
                    // 7/29/2019 SMG & TK: Added setTimeout so map pans to lat lng when opening modal dialog, for some reason without setTimeout the map does not pan
                    setTimeout(function () {
                        $scope.projectLocationMap.map.panTo(latlng);
                    }, 1);
                }
            };

            initializeMap();
            $scope.toggleMap();
        });
