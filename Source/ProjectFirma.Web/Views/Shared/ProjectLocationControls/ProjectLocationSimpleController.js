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

            var typeaheadSearch = function (typeaheadSelector, typeaheadSelectorButton, summaryUrl) {
                $scope.typeaheadSelectorButton = typeaheadSelectorButton;
                var finder = jQuery(typeaheadSelector);
                finder.typeahead({
                        highlight: true,
                        minLength: 1
                    },
                    {
                        source: new Bloodhound({
                            datumTokenizer: Bloodhound.tokenizers.whitespace,
                            queryTokenizer: Bloodhound.tokenizers.whitespace,
                            remote: {
                                url: summaryUrl +
                                    "?term=%QUERY",
                                wildcard: "%QUERY"
                            }
                        }),
                        display: "WatershedName",
                        limit: Number.MAX_VALUE
                    });

                finder.bind("typeahead:select",
                    function (ev, suggestion) {
                        $scope.AngularModel.ProjectLocationAreaID = suggestion.ProjectLocationAreaID;
                        setSelectedProjectLocationArea(suggestion.GeoJson, suggestion.WatershedName);
                        $scope.$apply();
                    });

                jQuery(typeaheadSelectorButton).click(function () { $scope.selectFirstSuggestionFunction(); });

                finder.keypress(function (e) {
                    if (e.which === 13) { // handles the enter key; it will autoselect the first result of the list
                        e.preventDefault();
                        $scope.selectFirstSuggestionFunction();
                    }
                });
            };

            $scope.selectFirstSuggestionFunction = function () {
                var selectables = jQuery($scope.typeaheadSelectorButton).siblings(".tt-menu").find(".tt-selectable");
                if (selectables.length > 0) {
                    jQuery(selectables[0]).trigger("click");
                }
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
                case "NamedAreas":
                    document.getElementById($scope.AngularViewData.MapInitJson.MapDivID).style.cursor = null;
                    $scope.projectLocationMap.unblockMap();
                    $scope.projectLocationMap.map.scrollWheelZoom.enable();

                    if ($scope.projectLocationMap.currentSelectedPoint) {
                        $scope.projectLocationMap.map.removeLayer($scope.projectLocationMap.currentSelectedPoint);
                    }

                    if ($scope.projectLocationMap.currentSelectedGeometry) {
                        $scope.projectLocationMap.map.addLayer($scope.projectLocationMap.currentSelectedGeometry);
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
                case "NamedAreas":
                    onMapClickSetNamedArea(event,
                        function() {
                            $scope.$apply();
                        });
                    break;
                case "None": // Do nothing
                    break;
                }
            }

            function onMapClickSetPointOnMap(event, callback) {
                var watershedMapSericeLayerName = $scope.AngularViewData.WatershedMapSericeLayerName,
                    mapServiceUrl = $scope.AngularViewData.MapServiceUrl;

                if (!watershedMapSericeLayerName || !mapServiceUrl)
                    return;

                var parameters = L.Util.extend($scope.projectLocationMap.wfsParams,
                    {
                        typeName: watershedMapSericeLayerName,
                        cql_filter: "intersects(Ogr_Geometry, POINT(" + event.latlng.lat + " " + event.latlng.lng + "))"
                    });
                SitkaAjax.ajax({
                        url: mapServiceUrl + L.Util.getParamString(parameters),
                        dataType: "json",
                        jsonpCallback: "getJson"
                    },
                    function (response) {

                        $scope.AngularModel.ProjectLocationPointX = L.Util.formatNum(event.latlng.lng);
                        $scope.AngularModel.ProjectLocationPointY = L.Util.formatNum(event.latlng.lat);

                        if ($scope.projectLocationMap.currentSelectedPoint) {
                            $scope.projectLocationMap.map.removeLayer($scope.projectLocationMap.currentSelectedPoint);
                        }

                        $scope.projectLocationMap.currentSelectedPoint = L.marker(event.latlng, { icon: L.MakiMarkers.icon({ icon: "marker", color: $scope.selectedStyle.color, size: "m" }) });
                        
                        $scope.projectLocationMap.map.addLayer($scope.projectLocationMap.currentSelectedPoint);
                        $scope.projectLocationMap.map.panTo(event.latlng);

                        var propertiesForDisplay = {
                            Latitude: L.Util.formatNum(event.latlng.lat, 4),
                            Longitude: L.Util.formatNum(event.latlng.lng, 4)
                        };

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
                    function () {
                        console.error(
                            "There was an error selecting the " + $scope.AngularViewData.ProjectLocationFieldDefinitionLabel + " area from list.");
                    });
            }

            function onMapClickSetNamedArea(event, callback) {
                var watershedMapSericeLayerName = $scope.AngularViewData.WatershedMapSericeLayerName,
                    mapServiceUrl = $scope.AngularViewData.MapServiceUrl;

                if (!watershedMapSericeLayerName || !mapServiceUrl)
                    return;

                var parameters = L.Util.extend($scope.projectLocationMap.wfsParams,
                    {
                        typeName: watershedMapSericeLayerName,
                        cql_filter: "intersects(Ogr_Geometry, POINT(" + event.latlng.lat + " " + event.latlng.lng + "))"
                    });
                SitkaAjax.ajax({
                        url: mapServiceUrl + L.Util.getParamString(parameters),
                        dataType: "json",
                        jsonpCallback: "getJson"
                    },
                    function(response) {
                        if (response.features.length === 0)
                            return;

                        var mergedProperties = _.merge.apply(_, _.map(response.features, "properties"));
                        document.getElementById($scope.AngularViewData.TypeAheadInputId).value = mergedProperties.WatershedName;

                        setSelectedProjectLocationArea(response.features, mergedProperties.WatershedName, event.latlng.lat, event.latlng.lng);

                        var projectLocationAreaIdUrl = new Sitka.UrlTemplate($scope.AngularViewData.ProjectLocationAreaIDFromWatershedIDUrlTemplate).ParameterReplace(mergedProperties.WatershedID);
                        jQuery.get(projectLocationAreaIdUrl).done(function (projectLocationAreaId) {
                            $scope.AngularModel.ProjectLocationAreaID = projectLocationAreaId;

                            if (callback) {
                                callback.call();
                            }
                        });

                    },
                    function() {
                        console.error(
                            "There was an error selecting the " + $scope.AngularViewData.ProjectLocationFieldDefinitionLabel + " area from list.");
                    });
            }

            function setSelectedProjectLocationArea(geoJson, watershedName, latitude, longitude) {
                if ($scope.projectLocationMap.currentSelectedGeometry) {
                    $scope.projectLocationMap.map.removeLayer($scope.projectLocationMap.currentSelectedGeometry);
                }

                // ReSharper disable once InconsistentNaming
                $scope.projectLocationMap.currentSelectedGeometry = new L.geoJSON(geoJson,
                    {
                        style: function () {
                            return $scope.selectedStyle;
                        }
                    });
                $scope.projectLocationMap.map.addLayer($scope.projectLocationMap.currentSelectedGeometry);
                $scope.projectLocationMap.map.panTo($scope.projectLocationMap.currentSelectedGeometry.getBounds().getCenter());

                var propertiesForDisplay = {};
                if (latitude && longitude) {
                    propertiesForDisplay["Latitude"] = L.Util.formatNum(latitude, 4);
                    propertiesForDisplay["Longitude"] = L.Util.formatNum(longitude, 4);
                }
                propertiesForDisplay[$scope.AngularViewData.WatershedFieldDefinitionLabel] = watershedName;

                $scope.propertiesForNamedArea = propertiesForDisplay;
            }

            $scope.getProjectLocationProperties = function() {
                switch ($scope.AngularModel.ProjectLocationSimpleType) {
                case "PointOnMap":
                    return $scope.propertiesForPointOnMap;
                case "NamedAreas":
                    return $scope.propertiesForNamedArea;
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

                typeaheadSearch("#" + $scope.AngularViewData.TypeAheadInputId,
                    "#" + $scope.AngularViewData.TypeAheadInputId + "Button",
                    $scope.AngularViewData.FindWatershedByNameUrl);

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
                    $scope.projectLocationMap.currentSelectedPoint = L.marker(latlng, { icon: L.MakiMarkers.icon({ icon: "marker", color: $scope.selectedStyle.color, size: "m" }) });

                    $scope.propertiesForPointOnMap = {
                        Latitude: L.Util.formatNum(latlng.lat, 4),
                        Longitude: L.Util.formatNum(latlng.lng, 4)
                    };

                    // Get the initial Location Information from the WMS service
                    if ($scope.AngularViewData.MapServiceUrl && $scope.AngularViewData.WatershedMapSericeLayerName) {
                        SitkaAjax.ajax({
                                url: $scope.AngularViewData.MapServiceUrl +
                                    L.Util.getParamString(L.Util.extend($scope.projectLocationMap.wfsParams,
                                        {
                                            typeName: $scope.AngularViewData.WatershedMapSericeLayerName,
                                            cql_filter: "intersects(Ogr_Geometry, POINT(" + latlng.lat + " " + latlng.lng + "))"
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
