/*-----------------------------------------------------------------------
<copyright file="LayerGeoJson.cs" company="Tahoe Regional Planning Agency">
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
using System.Drawing;
using System.Linq;
using GeoJSON.Net.Feature;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    /// <summary>
    /// example: Jurisdiction layer or Road layer
    /// </summary>
    public class LayerGeoJson
    {
        public readonly decimal LayerOpacity;
        public readonly LayerInitialVisibility LayerInitialVisibility;
        public readonly string LayerName;
        public readonly string LayerColor;
        public readonly FeatureCollection GeoJsonFeatureCollection;
        public readonly bool HasCustomPopups;

        public LayerGeoJson(string layerName, FeatureCollection geoJsonFeatureCollection, string layerColor, decimal layerOpacity, LayerInitialVisibility layerInitialVisibility)
        {
            LayerOpacity = layerOpacity;
            LayerInitialVisibility = layerInitialVisibility;
            LayerName = layerName;

            if (layerColor.StartsWith("#"))
            {
                LayerColor = layerColor;   
            }
            else
            {                
                var color = Color.FromName(layerColor);
                LayerColor = string.Format("#{0:x2}{1:x2}{2:x2}", color.R, color.G, color.B);
            }
            
            GeoJsonFeatureCollection = geoJsonFeatureCollection;
            HasCustomPopups = geoJsonFeatureCollection.Features.Any(x => x.Properties.ContainsKey("PopupUrl"));
        }

        public string ToGeoJsonString()
        {
            return JsonTools.SerializeObject(this);
        }
    }
}
