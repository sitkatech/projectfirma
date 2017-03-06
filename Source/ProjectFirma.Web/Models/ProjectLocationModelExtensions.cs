/*-----------------------------------------------------------------------
<copyright file="ProjectLocationModelExtensions.cs" company="Tahoe Regional Planning Agency">
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
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.GeoJson;

namespace ProjectFirma.Web.Models
{
    public static class ProjectLocationModelExtensions
    {
        public static GeoJSON.Net.Feature.FeatureCollection ToGeoJsonFeatureCollection(this IEnumerable<IProjectLocation> projectLocations)
        {
            return new GeoJSON.Net.Feature.FeatureCollection(projectLocations.Where(x => DbGeometryToGeoJsonHelper.CanParseGeometry(x.ProjectLocationGeometry)).Select(x =>
            {
                var feature = DbGeometryToGeoJsonHelper.FromDbGeometry(x.ProjectLocationGeometry);
                feature.Properties.Add("Info", x.Annotation);
                return feature;
            }).ToList());
        }

        public static string ToGeoJsonString(this GeoJSON.Net.Feature.FeatureCollection featureCollection)
        {
            return JsonTools.SerializeObject(featureCollection);
        }
    }
}
