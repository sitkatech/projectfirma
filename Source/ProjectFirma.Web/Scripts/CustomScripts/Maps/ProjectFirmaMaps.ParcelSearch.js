ProjectFirmaMaps.ParcelSearch = function (parcelLocationSummaryMapInitJson, initialBaseLayer, geoserverUrl, parcelSummaryUrl) {
    ProjectFirmaMaps.GeoServerMap.call(this, parcelLocationSummaryMapInitJson, initialBaseLayer, geoserverUrl);

    this.parcelSummaryUrl = parcelSummaryUrl;

    var allParcelsLayerName = "LakeTahoeInfo:AllParcels";
    this.wmsParams = this.createWmsParamsWithLayerName(allParcelsLayerName);
    this.wfsParams = this.createWfsParamsWithLayerName(allParcelsLayerName);

    this.addWmsLayer(allParcelsLayerName, "All Parcels");
    this.addWmsLayer("LakeTahoeInfo:ParcelDevelopmentRightTransfers", "Development Right Transfers");
    this.map.on('click', this.selectParcel, this);
};

ProjectFirmaMaps.ParcelSearch.prototype = Sitka.Methods.clonePrototype(ProjectFirmaMaps.GeoServerMap.prototype);

ProjectFirmaMaps.ParcelSearch.prototype.findParcelAndAddToMap = function (parcelNumber) {
    var customParams = {
        cql_filter: "ParcelNumber='" + parcelNumber + "'"
    };

    this.selectParcelByWFS(customParams);
};

ProjectFirmaMaps.ParcelSearch.prototype.selectParcelByWFS = function (customParams)
{
    var self = this;
    if (!Sitka.Methods.isUndefinedNullOrEmpty(this.selectedFeature))
    {
        this.map.removeLayer(this.selectedFeature);
        this.layerControl.removeLayer(this.selectedFeature);
    }

    var parameters = L.Util.extend(this.wfsParams, customParams);

    SitkaAjax.ajax({
            url: this.geoserverUrlOWS + L.Util.getParamString(parameters),
            dataType: 'json',
            jsonpCallback: 'getJson'
        },
        function(response)
        {
            self.selectedFeature = L.geoJson(response, {
                style: function(feature)
                {
                    return {
                        stroke: true,
                        strokeColor: "#ff0000",
                        fillColor: 'FFFFFF',
                        fillOpacity: 0
                    };
                },
                onEachFeature: function(feature, layer)
                {
                    jQuery("#parcelAddressFinder").val(feature.properties.ParcelAddress);
                    SitkaAjax.load(jQuery("#parcelAddressResultDetails"), self.parcelSummaryUrl + "/" + feature.properties.ParcelNumber);
                }
            }).addTo(self.map);
            self.map.fitBounds(self.selectedFeature.getBounds());
        });
};

ProjectFirmaMaps.ParcelSearch.prototype.selectParcel = function(evt)
{
    var customParams = {
        cql_filter: 'intersects(Ogr_Geometry, POINT(' + evt.latlng.lat + ' ' + evt.latlng.lng + '))'
    };
    this.selectParcelByWFS(customParams);
};