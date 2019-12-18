/*-----------------------------------------------------------------------
<copyright file="ProjectFirmaMaps.js" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
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
var ProjectFirmaMaps = {};

/* ====== Main Map ====== */
ProjectFirmaMaps.Map = function (mapInitJson, initialBaseLayerShown)
{
    var self = this;
    this.MapDivId = mapInitJson.MapDivID;

    var esriAerialUrl = 'https://services.arcgisonline.com/ArcGIS/rest/services/World_Imagery/MapServer/tile/{z}/{y}/{x}';
    var esriAerial = new L.TileLayer(esriAerialUrl, {});

    var esriStreetUrl = 'https://services.arcgisonline.com/ArcGIS/rest/services/World_Street_Map/MapServer/tile/{z}/{y}/{x}';
    var esriStreet = new L.TileLayer(esriStreetUrl, {});

    var esriTerrainUrl = 'https://services.arcgisonline.com/ArcGIS/rest/services/World_Topo_Map/MapServer/tile/{z}/{y}/{x}';
    var esriTerrain = new L.TileLayer(esriTerrainUrl, {});

    var streetLabelsLayer = new L.TileLayer('https://services.arcgisonline.com/ArcGIS/rest/services/Reference/World_Transportation/MapServer/tile/{z}/{y}/{x}', {});

    var baseLayers = { 'Aerial': esriAerial, 'Street': esriStreet, 'Terrain': esriTerrain };
    var overlayLayers = { 'Street Labels': streetLabelsLayer };

    var streetLayerGroup;
    if (initialBaseLayerShown === "Hybrid")
    {
         streetLayerGroup = new L.LayerGroup();
        initialBaseLayerShown = "Aerial"; //Since switching to ArcGIS maps, there is no "Hybrid", so use "Aerial" instead.
        streetLabelsLayer.addTo(streetLayerGroup);
    }
    else if (Sitka.Methods.isUndefinedNullOrEmpty(initialBaseLayerShown) || baseLayers[initialBaseLayerShown] == null)
    {
        initialBaseLayerShown = "Terrain";
    }    

    var options = {
        scrollWheelZoom: false, // If this is on (default) scrolling down the page will intercept and starting zooming the map
        layers: [baseLayers[initialBaseLayerShown]],
        attributionControl: false,
        fullscreenControl: mapInitJson.AllowFullScreen ? { pseudoFullscreen: true } : false
    };

    // Initialize the map
    this.map = L.map(this.MapDivId, options);

    if (streetLayerGroup != null)
    {
        streetLayerGroup.addTo(this.map);
    }

    // Add external tile layers from ArcGIS Online
    for (var i = 0; i < mapInitJson.ExternalMapLayers.length; ++i) {
        var layerConfig = mapInitJson.ExternalMapLayers[i];
        if (layerConfig.IsTiledMapService) {
            this.addTiledLayerFromAGOL(layerConfig, overlayLayers);
        }
    }

    // add vector layers
    this.vectorLayers = [];

    // Add external vector layers from ArcGIS Online 
    for (var i = 0; i < mapInitJson.ExternalMapLayers.length; ++i) {
        var layerConfig = mapInitJson.ExternalMapLayers[i];
        if (!layerConfig.IsTiledMapService) {
            this.addVectorLayerFromAGOL(layerConfig, overlayLayers, mapInitJson.RequestSupportUrl);
        }
    }


    // Add main layers from geojson
    for (var i = 0; i < mapInitJson.Layers.length; ++i) {
        var currentLayer = mapInitJson.Layers[i];
        switch (currentLayer.LayerType) {
            case "Vector":
                this.addVectorLayer(currentLayer, overlayLayers);
                break;
            case "Wms":
                this.addWmsLayer(currentLayer, overlayLayers);
                break;
            default:
                console.error("Invalid LayerType " + currentLayer.LayerType + " not added to map layers.");
        }
    }

    this.addLayersToMapLayersControl(baseLayers, overlayLayers);

    var modalDialog = jQuery(".modal");
    if (!Sitka.Methods.isUndefinedNullOrEmpty(modalDialog))
    {
        modalDialog.on("shown.bs.modal", function()
        {
            self.map.invalidateSize();
            self.setMapBounds(mapInitJson);
        });
    }
    if (!mapInitJson.DisablePopups) {
        this.map.on("click", function (e) { self.getFeatureInfo(e); });
    }
     
    self.setMapBounds(mapInitJson);
};

ProjectFirmaMaps.Map.prototype.addTiledLayerFromAGOL = function (layerConfig, overlayLayers) {
    var tileLayer = L.esri.tiledMapLayer({ url: layerConfig.LayerUrl });
    overlayLayers[layerConfig.DisplayName] = tileLayer;
    // Add to map if layer is on by default
    if (layerConfig.LayerIsOnByDefault) {
        tileLayer.addTo(this.map);
    }
}

ProjectFirmaMaps.Map.prototype.addVectorLayerFromAGOL = function (layerConfig, overlayLayers, requestSupportUrl) {
    var featureLayer = L.esri.featureLayer({ url: layerConfig.LayerUrl });
    if (layerConfig.FeatureNameField) {
        featureLayer.bindPopup(function (evt) {
            var latlng = this.getLatLng();
            if (evt.feature.properties[layerConfig.FeatureNameField]) {
                return L.Util.template('<strong>' + layerConfig.DisplayName + ': </strong> {' + layerConfig.FeatureNameField + '}<br \><strong>Location: </strong>' + latlng.lat.toFixed(4) + ', ' + latlng.lng.toFixed(4), evt.feature.properties);
            }
            return L.Util.template('<div class="alert alert-danger">The configured Feature Name was not found. <a href="' + requestSupportUrl + '" target="_blank">Request Support</a> to notify Administrators</div>', evt.feature.properties);
        });
    }
    overlayLayers[layerConfig.DisplayName] = featureLayer;
    // Add to map if layer is on by default
    if (layerConfig.LayerIsOnByDefault) {
        featureLayer.addTo(this.map);
    }
}

ProjectFirmaMaps.Map.prototype.addVectorLayer = function (currentLayer, overlayLayers) {
    var self = this;

    var layerGroup = new L.LayerGroup();
    var layerGeoJson = L.geoJson(currentLayer.GeoJsonFeatureCollection, {
        pointToLayer: function (feature, latlng) {
            var featureColor = feature.properties.FeatureColor == null ? currentLayer.LayerColor : feature.properties.FeatureColor;
            var marker = L.marker(latlng, { icon: L.MakiMarkers.icon({ icon: "marker", color: featureColor, size: "s" }) });
            return marker;
        },
        style: function (feature) {
            var fillPolygonByDefault = _.includes(["Polygon", "MultiPolygon"], feature.geometry.type);
            return {
                color: feature.properties.FeatureColor == null ? currentLayer.LayerColor : feature.properties.FeatureColor,
                weight: feature.properties.FeatureWeight == null ? 2 : feature.properties.FeatureWeight,
                fill: feature.properties.FillPolygon == null ? fillPolygonByDefault : feature.properties.FillPolygon,
                fillOpacity: feature.properties.FillOpacity == null ? 0.2 : feature.properties.FillOpacity
            };
        },
        onEachFeature: function(feature, layer) {
            self.bindPopupToFeature(layer, feature);
            self.bindHoverToFeature(layer, feature);
        }
    }).addTo(layerGroup);

    if (currentLayer.LayerInitialVisibility === 1) {
        layerGroup.addTo(this.map);
    }
   
    overlayLayers[currentLayer.LayerName] = layerGroup;
    this.vectorLayers.push(layerGeoJson);
};

ProjectFirmaMaps.Map.prototype.addWmsLayer = function (currentLayer, overlayLayers) {
    var layerGroup = new L.LayerGroup(),
        wmsParams = L.Util.extend(this.wmsParams, { layers: currentLayer.MapServerLayerName }),
        wmsLayer = L.tileLayer.wms(currentLayer.MapServerUrl, wmsParams).addTo(layerGroup);

    if (currentLayer.LayerInitialVisibility === 1) {
        layerGroup.addTo(this.map);
    }
    wmsLayer.on("click", function (e) { self.getFeatureInfo(e); });

    overlayLayers[currentLayer.LayerName] = layerGroup;
    this.vectorLayers.push(wmsLayer);
};

ProjectFirmaMaps.Map.prototype.wmsParams = {
    service: "WMS",
    transparent: true,
    version: "1.1.1",
    format: "image/png",
    info_format: "application/json",
    tiled: true
};

ProjectFirmaMaps.Map.prototype.wfsParams = {
    service: "WFS",
    version: "2.0",
    request: "GetFeature",
    outputFormat: "application/json",
    SrsName: "EPSG:4326"
};

ProjectFirmaMaps.Map.prototype.addLayersToMapLayersControl = function(baseLayers, overlayLayers) {
    this.layerControl = L.control.layers(baseLayers, overlayLayers);
    this.layerControl.addTo(this.map);
};

ProjectFirmaMaps.Map.prototype.setMapBounds = function(mapInitJson) {
    this.map.fitBounds([
        [mapInitJson.BoundingBox.Northeast.Latitude, mapInitJson.BoundingBox.Northeast.Longitude],
        [mapInitJson.BoundingBox.Southwest.Latitude, mapInitJson.BoundingBox.Southwest.Longitude]
    ]);
};

ProjectFirmaMaps.Map.prototype.bindPopupToFeature = function (layer, feature) {
    var self = this;
    if (!Sitka.Methods.isUndefinedNullOrEmpty(feature.properties.PopupUrl)) {
        layer.bindPopup("Loading...");
        layer.on("click",
            function(e) {
                //var popup = e.target.getPopup();
                self.map.setView(e.target.getLatLng());
                jQuery.get(feature.properties.PopupUrl).done(function(data) {
                    layer.bindPopup(data).openPopup({});
                });

            });
    }
};

ProjectFirmaMaps.Map.prototype.bindHoverToFeature = function (layer, feature) {
    if (!Sitka.Methods.isUndefinedNullOrEmpty(feature.properties["Hover Name"])) {
        layer.bindTooltip(feature.properties["Hover Name"], { direction: "auto", sticky: "true" });

        var originalFillOpacity = layer.options.fillOpacity;
        layer.on("mouseover",
            function () {
                layer.setStyle({ fillOpacity: Math.min(originalFillOpacity + 0.4, 1) });
            });
        layer.on("mouseout",
            function () {
                layer.setStyle({ fillOpacity: originalFillOpacity });
            });
    };
    return layer;
};

ProjectFirmaMaps.Map.prototype.assignClickEventHandler = function(clickEventFunction) {
    var self = this;
    for (var i = 0; i < this.vectorLayers.length; ++i) {
        var currentLayer = this.vectorLayers[i];
        currentLayer.on("click", function(e) { clickEventFunction(self, e); });
    }
    this.map.on("click", function(e) { clickEventFunction(self, e); });
};

ProjectFirmaMaps.Map.prototype.removeClickEventHandler = function() {
    for (var i = 0; i < this.vectorLayers.length; ++i) {
        var currentLayer = this.vectorLayers[i];
        currentLayer.off("click");
    }
    this.map.off("click");
};

    ProjectFirmaMaps.Map.prototype.formatLayerProperty = function (propertyName, propertyValue)
    {
        if (Sitka.Methods.isUndefinedNullOrEmpty(propertyValue))
        {
            propertyValue = "&nbsp";
        }
        return "<span><strong>" + propertyName + ":</strong> " + propertyValue + "</span></br>";
    };
    
    ProjectFirmaMaps.Map.prototype.removeLayerFromMap = function (layerToRemove) {
        if (!Sitka.Methods.isUndefinedNullOrEmpty(layerToRemove)) {
            this.map.removeLayer(layerToRemove);
        }
    };

    ProjectFirmaMaps.Map.prototype.addLayerToLayerControl = function(layer, layerName) {
        this.layerControl.addOverlay(layer, layerName);
    };

    ProjectFirmaMaps.Map.prototype.disableUserInteraction = function() {
        this.map.dragging.disable();
        this.map.touchZoom.disable();
        this.map.doubleClickZoom.disable();
        this.map.scrollWheelZoom.disable();
        this.map.boxZoom.disable();
        this.map.keyboard.disable();
        this.map.attributionControl = false;
        if (this.map.tap) this.map.tap.disable();
        document.getElementById(this.MapDivId).style.cursor = 'default';
        jQuery(".leaflet-control-zoom").css("visibility", "hidden");
        jQuery(".leaflet-control-layers").css("visibility", "hidden");
        this.removeClickEventHandler();
};

    ProjectFirmaMaps.Map.prototype.blockMapImpl = function() {
        this.map.dragging.disable();
        this.map.scrollWheelZoom.disable();
        jQuery("#" + this.MapDivId).block(
            {
                message:
                    "<span style='font-weight: bold; font-size: 14px; margin: 0 2px'>Location Not Specified</span>",
                css: {
                    border: "none",
                    cursor: "default"
                },
                overlayCSS: {
                    backgroundColor: "#D3D3D3",
                    cursor: "default"
                },
                baseZ: 999
            });
    };

    ProjectFirmaMaps.Map.prototype.blockMap = function() {
        var self = this;
        this.blockMapImpl();
        var modalDialog = jQuery(".modal");
        modalDialog.on("shown.bs.modal", function() { self.blockMapImpl(); });
    };

    ProjectFirmaMaps.Map.prototype.unblockMap = function() {
        this.map.dragging.enable();
        jQuery("#" + this.MapDivId).unblock();
    };

    ProjectFirmaMaps.Map.prototype.getFeatureInfo = function(e) {
        var latlng = e.latlng;
        var self = this;

        var wmsLayers = this.vectorLayers.filter(function(layer) {
            return layer.hasOwnProperty('wmsParams') && self.map.hasLayer(layer);
        });

        var vecLayers = this.vectorLayers.filter(function(layer) {
            return !layer.hasOwnProperty('wmsParams') && self.map.hasLayer(layer);
        });

        if (wmsLayers.length > 0) {
            this.popupForWMSAndVectorLayers(wmsLayers, vecLayers, latlng);
        } else {
            this.popupForVectorLayers(vecLayers, latlng);
        }
    };

    ProjectFirmaMaps.Map.prototype.popupForVectorLayers = function (vecLayers, latlng) {
        var allLayers = [];

        for (var j = 0; j < vecLayers.length; ++j) {
            var currentLayer = vecLayers[j];
            var vectorLayerInfoHtmlForPopup = this.getVectorLayerInfoHtmlForPopup(currentLayer, latlng);
            allLayers.push(vectorLayerInfoHtmlForPopup);            
        }

        var lat = L.Util.formatNum(latlng.lat, 4);
        var lon = L.Util.formatNum(latlng.lng, 4);
        allLayers.push({
            label: "Location",
            link: lat + ", " + lon
        });
    
        this.map.setView(latlng);
        this.map.openPopup(L.popup({ maxWidth: 200 }).setLatLng(latlng).setContent(this.htmlPopupContents(allLayers)).openOn(this.map)); 
    };

ProjectFirmaMaps.Map.prototype.htmlPopupContents = function (allLayers) {
    var self = this;
        var uniqueArray = this.removeDuplicatesFromArray(allLayers, "label");

        var html = "<div>";

        _.forEach(uniqueArray,
            function (layer) {
                if (layer.label != null) {
                    html += self.formatLayerProperty(layer.label, layer.link);
                }
                
            });

        html += "</div>";

        return html;
    };



    ProjectFirmaMaps.Map.prototype.getVectorLayerInfoHtmlForPopup = function(currentLayer, latlng) {
        var key = null,
            value = null;
        var match = leafletPip.pointInLayer(
            // the clicked point
            latlng,
            // this layer
            currentLayer,
            // whether to stop at first match
            true);

        var propertiesGroupedByKey = _(match)
        .map(function (x) {
            return _.keys(x.feature.properties);
        })
        .flatten()
        .uniq()
        .map(function (x) {
            return {
                key: x,
                values: _(match)
                    .map(function (y) {
                        return y.feature.properties[x];
                    })
                    .filter()
                    .value()
            };
        })
        .value();

        // if there's overlap, add some content to the popup: the layer name
        // and a table of attributes
        for (var i = 0; i < propertiesGroupedByKey.length; i++) {
            var group = propertiesGroupedByKey[i];
            if (group.key !== "Hover Name") {
                key = group.values.length > 1
                        ? group.key + "s" // pluralized
                        : group.key,
                value = group.values.join(", ");
            }
        }
        
        return {
            label: key,
            link: value
        };
    };

    ProjectFirmaMaps.Map.prototype.popupForWMSAndVectorLayers = function(wmsLayers, vecLayers, latlng) {
        var self = this;

        var point = this.map.latLngToContainerPoint(latlng, this.map.getZoom()),
            size = this.map.getSize(),

            geospatialAreaWMSParams = {
                service: 'WMS',
                version: "1.1.1",
                request: 'GetFeatureInfo',
                layers: wmsLayers[0].wmsParams.layers,
                styles: "",
                srs: 'EPSG:4326',
                bbox: this.map.getBounds().toBBoxString(),
                height: size.y,
                width: size.x,
                query_layers: wmsLayers[0].wmsParams.layers,
                info_format: 'application/json'
            };

        geospatialAreaWMSParams['x'] = point.x;
        geospatialAreaWMSParams['y'] = point.y;

        var ajaxCalls = [];

        for (var j = 0; j < wmsLayers.length; ++j) {
            var layer = wmsLayers[j];
            var query = layer._url + L.Util.getParamString(geospatialAreaWMSParams, null, true);            
            ajaxCalls.push(jQuery.when(jQuery.ajax({ url: query }))
                .then(function (response) { return self.formatGeospatialAreaResponse(response); }));
     
        }        

        this.carryOutPromises(ajaxCalls).then(
            function (responses) {
                var allLayers = [];
                //vector layers
                for (var j = 0; j < vecLayers.length; ++j) {
                    var currentLayer = vecLayers[j];

                    var vectorLayerInfoHtmlForPopup = self.getVectorLayerInfoHtmlForPopup(currentLayer, latlng);
                    allLayers.push(vectorLayerInfoHtmlForPopup);
                }
                //wms layers
                _.forEach(responses,
                    function (resp) {
                        allLayers.push(resp);
                    });
                //lat lon
                var lat = L.Util.formatNum(latlng.lat, 4);
                var lon = L.Util.formatNum(latlng.lng, 4);
                allLayers.push({
                    label: "Location",
                    link: lat + ", " + lon
                });

                self.map.setView(latlng);
                self.map.openPopup(L.popup({ maxWidth: 200 }).setLatLng(latlng).setContent(self.htmlPopupContents(allLayers)).openOn(self.map));
            },
            function(responses) {
                console.log("error getting wms feature info");
            }
        );
};


ProjectFirmaMaps.Map.prototype.carryOutPromises = function (deferreds) {
    var deferred = new jQuery.Deferred();
    $.when.apply(jQuery, deferreds).then(
        function () {
            deferred.resolve(Array.prototype.slice.call(arguments));
        },
        function () {
            deferred.fail(Array.prototype.slice.call(arguments));
        });

    return deferred;
}

ProjectFirmaMaps.Map.prototype.removeDuplicatesFromArray = function (originalArray, prop) {
    var newArray = [];
    var lookupObject = {};

    for (var i in originalArray) {
        lookupObject[originalArray[i][prop]] = originalArray[i];
    }

    for (i in lookupObject) {
        newArray.push(lookupObject[i]);
    }
    return newArray;
}



    ProjectFirmaMaps.Map.prototype.formatGeospatialAreaResponse = function (json) {
        var vectorLayerInfoHtmlForPopup = null;
        if (json.features.length > 0) {

            var atag = "<a title='' href='/GeospatialArea/Detail/" + json.features[0].properties.GeospatialAreaID + "'>" + json.features[0].properties.GeospatialAreaName + "</a>";
            vectorLayerInfoHtmlForPopup = {
                label: json.features[0].properties.GeospatialAreaTypeName,
                link: atag
            }
        }
    return vectorLayerInfoHtmlForPopup;
};
