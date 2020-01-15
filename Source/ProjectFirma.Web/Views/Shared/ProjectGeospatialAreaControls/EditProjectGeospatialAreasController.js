//#sourceUrl=/Views/ProjectGeospatialArea/EditProjectGeospatialAreasController.js
angular.module("ProjectFirmaApp")
    .controller("EditProjectGeospatialAreasController",
        function ($scope, angularModelAndViewData) {
            $scope.AngularModel = angularModelAndViewData.AngularModel;
            $scope.AngularViewData = angularModelAndViewData.AngularViewData;

            $scope.getGeospatialAreaName = function (geospatialAreaId) {
                return $scope.AngularViewData.GeospatialAreaNameByID[geospatialAreaId];
            };

            var typeaheadSearch = function (typeaheadSelector, typeaheadSelectorButton, summaryUrl) {
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
                        display: "GeospatialAreaName",
                        limit: Number.MAX_VALUE
                    });

                finder.bind("typeahead:select",
                    function (event, suggestion) {
                        $scope.toggleGeospatialArea(suggestion.GeospatialAreaID, suggestion.GeospatialAreaName, function() {
                            $scope.$apply();
                        });
                    });

                jQuery(typeaheadSelectorButton).click(function () { $scope.selectFirstSuggestionFunction(finder); });

                finder.keypress(function (e) {
                    if (e.which === 13) {
                        e.preventDefault();
                        $scope.selectFirstSuggestionFunction(this);
                        $scope.$apply();
                    }
                });
            };

            $scope.selectFirstSuggestionFunction = function () {
                var selectables = jQuery($scope.typeaheadSelectorButton).siblings(".tt-menu").find(".tt-selectable");
                if (selectables.length > 0) {
                    jQuery(selectables[0]).trigger("click");
                }
            };

            function onMapClick(event) {
                var geospatialAreaMapSericeLayerName = $scope.AngularViewData.GeospatialAreaMapServiceLayerName,
                    mapServiceUrl = $scope.AngularViewData.MapServiceUrl;

                if (!geospatialAreaMapSericeLayerName || !mapServiceUrl)
                    return;

                var latlng = event.latlng;
                var latlngWrapped = latlng.wrap();
                var parameters = L.Util.extend($scope.firmaMap.wfsParams,
                    {
                        typeName: geospatialAreaMapSericeLayerName,
                        cql_filter: "intersects(GeospatialAreaFeature, POINT(" + latlngWrapped.lat + " " + latlngWrapped.lng + "))"
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

                        $scope.toggleGeospatialArea(mergedProperties.GeospatialAreaID, mergedProperties.GeospatialAreaName, function() {
                            $scope.$apply();
                        });

                    },
                    function() {
                        console.error("There was an error selecting the " + $scope.AngularViewData.GeospatialAreaTypeName + " from list");
                    });
            }

            $scope.toggleGeospatialArea = function(geospatialAreaId, geospatialAreaName, callback) {
                if (geospatialAreaName && typeof $scope.AngularViewData.GeospatialAreaNameByID[geospatialAreaId] === "undefined") {
                    $scope.AngularViewData.GeospatialAreaNameByID[geospatialAreaId] = geospatialAreaName;
                }

                if (_.includes($scope.AngularModel.GeospatialAreaIDs, geospatialAreaId)) {
                    _.pull($scope.AngularModel.GeospatialAreaIDs, geospatialAreaId);
                } else {
                    $scope.AngularModel.GeospatialAreaIDs.push(geospatialAreaId);
                }

                updateSelectedGeospatialAreaLayer();

                if (typeof callback === "function") {
                    callback.call();
                }
            }

            function updateSelectedGeospatialAreaLayer() {
                if ($scope.AngularModel.GeospatialAreaIDs == null) {
                    $scope.AngularModel.GeospatialAreaIDs = [];
                }

                if ($scope.firmaMap.selectedGeospatialAreaLayer) {
                    $scope.firmaMap.layerControl.removeLayer($scope.firmaMap.selectedGeospatialAreaLayer);
                    $scope.firmaMap.map.removeLayer($scope.firmaMap.selectedGeospatialAreaLayer);
                }
                
                var wmsParameters = L.Util.extend($scope.firmaMap.wmsParams, 
                    {
                        layers: $scope.AngularViewData.GeospatialAreaMapServiceLayerName,
                        cql_filter: "GeospatialAreaID in (" + $scope.AngularModel.GeospatialAreaIDs.join(",") + ")",
                        styles: "geospatialArea_yellow"
                    });

                $scope.firmaMap.selectedGeospatialAreaLayer = L.tileLayer.wms($scope.AngularViewData.MapServiceUrl, wmsParameters);
                $scope.firmaMap.layerControl.addOverlay($scope.firmaMap.selectedGeospatialAreaLayer, "Selected " + $scope.AngularViewData.GeospatialAreaTypeName + "s");
                $scope.firmaMap.map.addLayer($scope.firmaMap.selectedGeospatialAreaLayer);

                // Update map extent to selected geospatialAreas
                if (_.any($scope.AngularModel.GeospatialAreaIDs)) {
                    var wfsParameters = L.Util.extend($scope.firmaMap.wfsParams,
                        {
                            typeName: $scope.AngularViewData.GeospatialAreaMapServiceLayerName,
                            cql_filter: "GeospatialAreaID in (" + $scope.AngularModel.GeospatialAreaIDs.join(",") + ")"
                        });
                    SitkaAjax.ajax({
                            url: $scope.AngularViewData.MapServiceUrl + L.Util.getParamString(wfsParameters),
                            dataType: "json",
                            jsonpCallback: "getJson"
                        },
                        function (response) {
                            if (response.features.length === 0)
                                return;

                            $scope.firmaMap.map.fitBounds(new L.geoJSON(response).getBounds());
                        },
                        function () {
                            console.error("There was an error setting map extent to the selected " + $scope.AngularViewData.GeospatialAreaTypeName + "s");
                        });
                }
            };

            ProjectFirmaMaps.Map.prototype.handleWmsPopupClickEventWithCurrentLayer = function() {
                // Override parent to do nothing
                return function() {};
            };

            function initializeMap() {
                $scope.firmaMap = new ProjectFirmaMaps.Map($scope.AngularViewData.MapInitJson);
                $scope.firmaMap.map.on("click", onMapClick);
                $scope.firmaMap.map.scrollWheelZoom.enable();

                typeaheadSearch("#" + $scope.AngularViewData.TypeAheadInputId,
                    "#" + $scope.AngularViewData.TypeAheadInputId + "Button",
                    $scope.AngularViewData.FindGeospatialAreaByNameUrl);
                
                updateSelectedGeospatialAreaLayer();
            };

            initializeMap();

            $scope.noGeospatialAreasSelected = function () {
                return !$scope.AngularModel.GeospatialAreaIDs || $scope.AngularModel.GeospatialAreaIDs.length < 1;
            };

            $scope.canSetGeospatialAreaFromProjectLocation = function () {
                return $scope.AngularViewData.HasProjectLocationPoint &&
                    $scope.AngularViewData.GeospatialAreaIDsContainingProjectSimpleLocation.length > 0;
            };

            $scope.setGeospatialAreaFromProjectLocation = function () {
                $scope.AngularModel.GeospatialAreaIDs = [];
                _.forEach($scope.AngularViewData.GeospatialAreaIDsContainingProjectSimpleLocation, function (geospatialAreaID) {                    
                    $scope.AngularModel.GeospatialAreaIDs.push(geospatialAreaID);
                });

                updateSelectedGeospatialAreaLayer();
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

            $scope.getGeospatialAreaTableStyles = function () {
                var returnValue = "overflow-y: auto;";
                if ($scope.selectedGeospatialAreaDoesNotMatchProjectLocation() && $scope.canSetGeospatialAreaFromProjectLocation() && !$scope.noGeospatialAreasSelected()) {
                    returnValue += "max-height: 200px;";
                } else {
                    returnValue += "max-height: 350px;";
                }
                

                return returnValue;
            };
        });
