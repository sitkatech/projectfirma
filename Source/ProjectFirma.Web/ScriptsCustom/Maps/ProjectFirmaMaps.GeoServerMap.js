ProjectFirmaMaps.GeoServerMap = function (parcelLocationSummaryMapInitJson, initialBaseLayerShown, geoserverUrl) {
    ProjectFirmaMaps.Map.call(this, parcelLocationSummaryMapInitJson, initialBaseLayerShown);

    this.geoserverUrlOWS = geoserverUrl;

    this.wmsParams = {
        service: "WMS",
        transparent: true,
        version: "1.1.1",
        format: "image/png",
        info_format: "application/json",
        tiled: true
//        tilesorigin: [this.map.getBounds().getSouthWest().lng, this.map.getBounds().getSouthWest().lat]
    };

    this.wfsParams = {
        service: "WFS",
        version: "2.0",
        request: "GetFeature",
        outputFormat: "application/json",
        SrsName: "EPSG:4326"
    };
};

ProjectFirmaMaps.GeoServerMap.prototype = Sitka.Methods.clonePrototype(ProjectFirmaMaps.Map.prototype);

ProjectFirmaMaps.GeoServerMap.prototype.createWmsParamsWithLayerName = function (layerName) {
    var customParams = {
        layers: layerName
    };

    var wmsParams = L.Util.extend(this.wmsParams, customParams);
    return wmsParams;
};

ProjectFirmaMaps.GeoServerMap.prototype.createWfsParamsWithLayerName = function (layerName) {
    var customParams = {
        typeName: layerName
    };

    var wfsParams = L.Util.extend(this.wfsParams, customParams);
    return wfsParams;
};

ProjectFirmaMaps.GeoServerMap.prototype.addWmsLayer = function (layerName, layerControlDisplayName) {
    var wmsParams = this.createWmsParamsWithLayerName(layerName);
    var wmsLayer = L.tileLayer.wms(this.geoserverUrlOWS, wmsParams).addTo(this.map);
    this.addLayerToLayerControl(wmsLayer, layerControlDisplayName);
    return wmsLayer;
};