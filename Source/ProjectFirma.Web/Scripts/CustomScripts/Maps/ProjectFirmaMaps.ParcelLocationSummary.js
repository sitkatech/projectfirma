ProjectFirmaMaps.ParcelLocationSummary = function (parcelLocationSummaryMapInitJson, initialBaseLayerShown) {
    ProjectFirmaMaps.Map.call(this, parcelLocationSummaryMapInitJson, initialBaseLayerShown);

    if (!parcelLocationSummaryMapInitJson.HasParcelLocation) {
        this.blockMap();
    }
};

ProjectFirmaMaps.ParcelLocationSummary.prototype = Sitka.Methods.clonePrototype(ProjectFirmaMaps.Map.prototype);