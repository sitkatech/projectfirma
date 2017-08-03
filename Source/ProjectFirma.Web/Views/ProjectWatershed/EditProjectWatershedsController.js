//#sourceUrl=/Views/ProjectWatershed/EditProjectWatershedsController.js
angular.module("ProjectFirmaApp")
    .controller("EditProjectWatershedsController",
        function ($scope, angularModelAndViewData) {
            $scope.AngularModel = angularModelAndViewData.AngularModel;
            $scope.AngularViewData = angularModelAndViewData.AngularViewData;

            $scope.getWatershedName = function (watershedId) {
                return $scope.AngularViewData.WatershedNameByID[watershedId];
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
                        display: "WatershedName",
                        limit: Number.MAX_VALUE
                    });

                finder.bind("typeahead:select",
                    function (event, suggestion) {
                        $scope.toggleWatershed(suggestion.WatershedID, suggestion.WatershedName, function() {
                            $scope.$apply();
                        });
                    });

                jQuery(typeaheadSelectorButton).click(function () { $scope.selectFirstSuggestionFunction(finder); });

                finder.keypress(function (e) {
                    if (e.which === 13) {
                        e.preventDefault();
                        $scope.selectFirstSuggestionFunction(this);
                        $scope.$appy();
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
                var watershedMapSericeLayerName = $scope.AngularViewData.WatershedMapServiceLayerName,
                    mapServiceUrl = $scope.AngularViewData.MapServiceUrl;

                if (!watershedMapSericeLayerName || !mapServiceUrl)
                    return;

                var parameters = L.Util.extend($scope.firmaMap.wfsParams,
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

                        $scope.toggleWatershed(mergedProperties.WatershedID, mergedProperties.WatershedName, function() {
                            $scope.$apply();
                        });

                    },
                    function() {
                        console.error("There was an error selecting the " + $scope.AngularViewData.WatershedFieldDefinitionLabel + " from list");
                    });
            }

            $scope.toggleWatershed = function(watershedId, watershedName, callback) {
                if (watershedName && typeof $scope.AngularViewData.WatershedNameByID[watershedId] === "undefined") {
                    $scope.AngularViewData.WatershedNameByID[watershedId] = watershedName;
                }

                if (_.includes($scope.AngularModel.WatershedIDs, watershedId)) {
                    _.pull($scope.AngularModel.WatershedIDs, watershedId);
                } else {
                    $scope.AngularModel.WatershedIDs.push(watershedId);
                }

                updateSelectedWatershedLayer();

                if (typeof callback === "function") {
                    callback.call();
                }
            }

            function updateSelectedWatershedLayer() {
                //debugger;
                if ($scope.firmaMap.selectedWatershedLayer) {
                    $scope.firmaMap.layerControl.removeLayer($scope.firmaMap.selectedWatershedLayer);
                    $scope.firmaMap.map.removeLayer($scope.firmaMap.selectedWatershedLayer);
                }
                
                var parameters = L.Util.extend(
                    {
                        layers: $scope.AngularViewData.WatershedMapSericeLayerName,
                        cql_filter: "WatershedID in (" + $scope.AngularModel.WatershedIDs.join(",") + ")",
                        styles: "watershed_yellow"
                    },
                    $scope.firmaMap.wmsParams);

                $scope.firmaMap.selectedWatershedLayer = L.tileLayer.wms($scope.AngularViewData.MapServiceUrl, parameters);
                $scope.firmaMap.layerControl.addOverlay($scope.firmaMap.selectedWatershedLayer, "Selected " + $scope.AngularViewData.WatershedFieldDefinitionLabel + "s");
                $scope.firmaMap.map.addLayer($scope.firmaMap.selectedWatershedLayer);
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
                    $scope.AngularViewData.FindWatershedByNameUrl);

                // TODO complete initialization of initial map state
                updateSelectedWatershedLayer();
            };

            initializeMap();
        });
