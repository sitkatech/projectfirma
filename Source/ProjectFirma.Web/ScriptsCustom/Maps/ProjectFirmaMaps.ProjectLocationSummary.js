/*-----------------------------------------------------------------------
<copyright file="ProjectFirmaMaps.ProjectLocationSummary.js" company="Tahoe Regional Planning Agency">
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
ProjectFirmaMaps.ProjectLocationSummary = function(projectLocationSummaryMapInitJson,
    projectLocationInformationContainer) {
    ProjectFirmaMaps.Map.call(this, projectLocationSummaryMapInitJson);
   
    if (projectLocationSummaryMapInitJson.HasSimpleLocation) //ProjectLocationTypeEnum.PointOnMap
    {
        var infoContainerPointHtml = "<table class=\"summaryLayout\">";
        var latLng = new L.LatLng(projectLocationSummaryMapInitJson.ProjectLocationYCoord,
            projectLocationSummaryMapInitJson.ProjectLocationXCoord);
        if (!Sitka.Methods.isUndefinedNullOrEmpty(projectLocationInformationContainer)) {
            infoContainerPointHtml += this.formatLayerProperty("Latitude", L.Util.formatNum(latLng.lat, 4));
            infoContainerPointHtml += this.formatLayerProperty("Longitude", L.Util.formatNum(latLng.lng, 4));
            var vectorLayers = _.filter(this.vectorLayers,
                function(layer) { return typeof layer.eachLayer !== "undefined"; });
            for (var i = 0; i < vectorLayers.length; i++) {
                var match = leafletPip.pointInLayer(
                    // the clicked point
                    latLng,
                    // this layer
                    vectorLayers[i],
                    // whether to stop at first match
                    true);
                // if there's overlap, add some content to the popup: the layer name
                // and a table of attributes
                if (match.length) {
                    var properties = match[0].feature.properties;
                    for (var propertyName in properties) {
                        infoContainerPointHtml += this.formatLayerProperty(propertyName, properties[propertyName]);
                    }
                }
            }
            infoContainerPointHtml += "</table>";
            projectLocationInformationContainer.html(infoContainerPointHtml);
        }
    }

    if (!projectLocationSummaryMapInitJson.HasDetailedLocation &&
        !projectLocationSummaryMapInitJson.HasSimpleLocation &&
        !projectLocationSummaryMapInitJson.HasWatersheds) {
        this.blockMap();
    }
};


ProjectFirmaMaps.ProjectLocationSummary.prototype = Sitka.Methods.clonePrototype(ProjectFirmaMaps.Map.prototype);
