/*-----------------------------------------------------------------------
<copyright file="ProjectFirmaMaps.js" company="Tahoe Regional Planning Agency">
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
    this.map = L.map(this.MapDivId, options);

    if (streetLayerGroup != null)
    {
        streetLayerGroup.addTo(this.map);
    }

    // add vector layers
    this.vectorLayers = [];

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
    self.setMapBounds(mapInitJson);
};

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
        }
    }).addTo(layerGroup);

    if (currentLayer.LayerInitialVisibility === 1) {
        layerGroup.addTo(this.map);
    }
    if (!currentLayer.HasCustomPopups) {
        layerGeoJson.on("click", function (e) { self.getFeatureInfo(e); });
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

ProjectFirmaMaps.Map.prototype.bindPopupToFeature = function(layer, feature) {
    if (!Sitka.Methods.isUndefinedNullOrEmpty(feature.properties.PopupUrl)) {
        layer.bindPopup("Loading...", { maxWidth: 600 });
        layer.on("click",
            function() {
                //var popup = e.target.getPopup();
                jQuery.get(feature.properties.PopupUrl).done(function(data) {
                    layer.bindPopup(data).openPopup();
                });
            });
    }
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

ProjectFirmaMaps.Map.prototype.getFeatureInfo = function (e)
{
    var self = this,
        latlng = e.latlng,
        html = "<div>";

    html += this.formatLayerProperty("Latitude", L.Util.formatNum(latlng.lat, 4));
    html += this.formatLayerProperty("Longitude", L.Util.formatNum(latlng.lng, 4));

    var match = _(this.vectorLayers)
        .filter(function (layer) {
            return typeof layer.eachLayer !== "undefined" && self.map.hasLayer(layer);
        })
        .map(function (currentLayer) {
            return leafletPip.pointInLayer(latlng, currentLayer, true);
        })
        .flatten()
        .value();

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
        if (group.key !== "Short Name") {
            var key = group.values.length > 1
                    ? group.key + "s" // pluralized
                    : group.key,
                value = group.values.join(", ");
            html += this.formatLayerProperty(key, value);
        }
    }

    html += "</div>";

    this.map.openPopup(L.popup({minWidth: 200, maxWidth: 350}).setLatLng(latlng).setContent(html).openOn(this.map));   
};

ProjectFirmaMaps.Map.prototype.formatLayerProperty = function (propertyName, propertyValue)
{
    if (Sitka.Methods.isUndefinedNullOrEmpty(propertyValue))
    {
        propertyValue = "&nbsp";
    }
    return "<div class=\"row\"><div class=\"col-xs-4\"><strong>" + propertyName + "</strong></div><div class=\"col-xs-8\">" + propertyValue + "</div></div>";
};

ProjectFirmaMaps.Map.prototype.removeLayerFromMap = function (layerToRemove) {
    if (!Sitka.Methods.isUndefinedNullOrEmpty(layerToRemove)) {
        this.map.removeLayer(layerToRemove);
    }
};

ProjectFirmaMaps.Map.prototype.addLayerToLayerControl = function (layer, layerName) {
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
            message: "<span style='font-weight: bold; font-size: 14px; margin: 0 2px'>Location Not Specified</span>",
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

