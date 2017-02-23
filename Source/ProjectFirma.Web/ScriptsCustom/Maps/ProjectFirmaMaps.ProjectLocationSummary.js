/*-----------------------------------------------------------------------
<copyright file="ProjectFirmaMaps.ProjectLocationSummary.js" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
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
ProjectFirmaMaps.ProjectLocationSummary = function(projectLocationSummaryMapInitJson, projectLocationInformationContainer)
{
    ProjectFirmaMaps.Map.call(this, projectLocationSummaryMapInitJson);

    var projectLocationType = projectLocationSummaryMapInitJson.ProjectLocationSimpleTypeID;

    if (projectLocationType == 1) //ProjectLocationTypeEnum.PointOnMap
    {
        var latLng = new L.LatLng(projectLocationSummaryMapInitJson.ProjectLocationYCoord, projectLocationSummaryMapInitJson.ProjectLocationXCoord);
        if (!Sitka.Methods.isUndefinedNullOrEmpty(projectLocationInformationContainer))
        {
            var infoContainerPointHtml = "<table class=\"summaryLayout\">";
            infoContainerPointHtml += this.formatLayerProperty("Latitude", L.Util.formatNum(latLng.lat, 4));
            infoContainerPointHtml += this.formatLayerProperty("Longitude", L.Util.formatNum(latLng.lng, 4));
            for (var i = 0; i < this.vectorLayers.length; i++)
            {
                var match = leafletPip.pointInLayer(
                    // the clicked point
                    latLng,
                    // this layer
                    this.vectorLayers[i],
                    // whether to stop at first match
                    true);
                // if there's overlap, add some content to the popup: the layer name
                // and a table of attributes
                if (match.length)
                {
                    var properties = match[0].feature.properties;
                    for (var propertyName in properties)
                    {
                        infoContainerPointHtml += this.formatLayerProperty(propertyName, properties[propertyName]);
                    }
                }
            }
            infoContainerPointHtml += "</table>";
            projectLocationInformationContainer.html(infoContainerPointHtml);
        }
    }
    else if (projectLocationType == 2) //ProjectLocationTypeEnum.NamedAreas
    {
        if (!Sitka.Methods.isUndefinedNullOrEmpty(projectLocationInformationContainer))
        {
            var infoContainerNamedAreaHtml = "<span>Named Area: " + projectLocationSummaryMapInitJson.ProjectLocationAreaName + "</span><br />";
            infoContainerNamedAreaHtml += "<span>Area Type: " + projectLocationSummaryMapInitJson.ProjectLocationAreaType + "</span>";
            projectLocationInformationContainer.html(infoContainerNamedAreaHtml);
        }
    }
    else if (projectLocationType == 3)
    {
        if (!projectLocationSummaryMapInitJson.HasDetailedLocation)
        {
            this.blockMap();
        }
    }
    else
    {
        alert("Problem loading map.");
    }
};

ProjectFirmaMaps.ProjectLocationSummary.prototype = Sitka.Methods.clonePrototype(ProjectFirmaMaps.Map.prototype);
